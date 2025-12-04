using System.Drawing.Printing;
using System.Text.Json;
using System.Windows.Forms;

namespace QuikBudget
{
    public partial class frmMain : Form
    {
        private string? _currentFilePath;
        private DateTime currentDateTime = DateTime.Today;
        private bool _isDirty;
        private readonly AppUpdateChecker _updateChecker;
        public frmMain()
        {
            InitializeComponent();
            printDocument1.PrintPage += printDocument1_PrintPage;
            _updateChecker = new AppUpdateChecker(Application.ProductVersion);
        }

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            Font headerFont = new Font("Segoe UI", 14, FontStyle.Bold);
            Font normalFont = new Font("Segoe UI", 10);
            float y = e.MarginBounds.Top;

            string title = "QuikBudget Report for " + currentDateTime.ToString("dd-MMM-yyyy");
            e.Graphics.DrawString(title, headerFont, Brushes.Black, e.MarginBounds.Left, y);
            y += headerFont.GetHeight(e.Graphics) + 10;

            string budgetLine = $"Budget: {nudBudget.Value:C2}";
            string remainingLine = lblRemainingFunds.Text;

            e.Graphics.DrawString(budgetLine, normalFont, Brushes.Black, e.MarginBounds.Left, y);
            y += normalFont.GetHeight(e.Graphics) + 2;
            e.Graphics.DrawString(remainingLine, normalFont, Brushes.Black, e.MarginBounds.Left, y);
            y += normalFont.GetHeight(e.Graphics) + 10;

            e.Graphics.DrawString("Expenses:", normalFont, Brushes.Black, e.MarginBounds.Left, y);
            y += normalFont.GetHeight(e.Graphics) + 4;

            foreach (var card in fLPExpenses.Controls.OfType<ExpenseControl>())
            {
                string line = $"{card.ExpenseName} ({card.Category}) - {card.Amount:C2}";
                e.Graphics.DrawString(line, normalFont, Brushes.Black,
                    e.MarginBounds.Left + 20, y);
                y += normalFont.GetHeight(e.Graphics) + 2;

                if (y > e.MarginBounds.Bottom)
                {
                    e.HasMorePages = true;
                    return;
                }
            }

            e.HasMorePages = false;
        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            using (var dlg = new frmAddExpense())
            {
                if (dlg.ShowDialog(this) == DialogResult.OK)
                {
                    AddExpenseCard(dlg.ExpenseName, dlg.Category, dlg.Amount);
                }
            }
        }

        private async void AddExpenseCard(string name, string category, decimal amount)
        {
            var card = new ExpenseControl
            {
                ExpenseName = name,
                Category = category,
                Amount = amount,
                Width = 372, // better sizing 372, 46
                Height = 46
            };

            var logo = await LogoDevClient.GetLogoByBrandNameAsync(name, size: 64);
            if (logo != null)
            {
                card.Logo = logo;
            }

            // When user clicks the X on this card
            card.RemoveRequested += ExpenseCard_RemoveRequested;

            fLPExpenses.Controls.Add(card);
            _isDirty = true;
            RecalculateRemaining();
        }

        private void ExpenseCard_RemoveRequested(object sender, EventArgs e)
        {
            if (sender is ExpenseControl card)
            {
                fLPExpenses.Controls.Remove(card);
                card.Dispose(); // optional but nice
                SortExpenseCards();
                _isDirty = true;
                RecalculateRemaining();
            }
        }

        private async void frmMain_Load(object sender, EventArgs e)
        {
            try
            {
                await RunUpdateCheckAsync();
            }
            catch (Exception ex)
            {
                // Swallow the errors.
            }
        }

        private void SortExpenseCards()
        {
            // Grab all ExpenseControls and sort them by ExpenseName
            var ordered = fLPExpenses.Controls
                .OfType<ExpenseControl>()
                .OrderBy(c => c.ExpenseName, StringComparer.CurrentCultureIgnoreCase)
                .ToList();

            fLPExpenses.SuspendLayout();

            for (int i = 0; i < ordered.Count; i++)
            {
                // Ensure the flow panel’s child order matches our sorted order
                fLPExpenses.Controls.SetChildIndex(ordered[i], i);
            }

            fLPExpenses.ResumeLayout();
        }


        private async Task RunUpdateCheckAsync()
        {
            await _updateChecker.CheckAsync();

            var current = _updateChecker.CurrentVersion;
            var remote = _updateChecker.RemoteVersion;

            if (!_updateChecker.IsUpdateAvailable)
            {
                // Do nothing
            }
            else
            {
                if (MessageBox.Show("A newer version of QuikBudget is available. \nDownload Now?", "Update Found", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    var about = new frmAbout();
                    about.Shown += async (s, args) => await about.TriggerUpdateCheckAsync();
                    about.ShowDialog(this);
                }
            }
        }

        private void nudBudget_ValueChanged_1(object sender, EventArgs e)
        {
            _isDirty = true;
            RecalculateRemaining();
        }

        private void RecalculateRemaining()
        {
            decimal budget = nudBudget.Value;

            decimal totalExpenses = fLPExpenses.Controls
                .OfType<ExpenseControl>()
                .Sum(c => c.Amount);

            decimal remaining = budget - totalExpenses;

            lblRemainingFunds.Text = $"Remaining Funds: {remaining:C2}";

            // Optional color change if negative
            lblRemainingFunds.ForeColor = remaining < 0 ?
                System.Drawing.Color.Red :
                System.Drawing.Color.Black;
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog dlg = new SaveFileDialog())
            {
                dlg.Title = "Save Budget File";
                dlg.Filter = "JSON Files (*.json)|*.json|All Files (*.*)|*.*";
                dlg.DefaultExt = "json";
                dlg.FileName = $"Budget for {currentDateTime.ToString("dd-MMM-yyyy")}.json";

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    _currentFilePath = dlg.FileName;
                    SaveBudgetToFile(_currentFilePath);
                }
            }
        }

        private void SaveBudgetToFile(string filePath)
        {
            var data = new BudgetFile
            {
                Budget = nudBudget.Value,
                Expenses = fLPExpenses.Controls
                    .OfType<ExpenseControl>()
                    .Select(c => new ExpenseDto
                    {
                        ExpenseName = c.ExpenseName,
                        Category = c.Category,
                        Amount = c.Amount
                    })
                    .ToList()
            };

            var options = new JsonSerializerOptions { WriteIndented = true };
            string json = JsonSerializer.Serialize(data, options);
            File.WriteAllText(filePath, json);
            _isDirty = false;
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!ConfirmDiscardUnsavedChanges())
                return;

            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                dlg.Title = "Open Budget File";
                dlg.Filter = "JSON Files (*.json)|*.json|All Files (*.*)|*.*";

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    _currentFilePath = dlg.FileName;
                    LoadBudgetFromFile(_currentFilePath);
                    SortExpenseCards();
                }
            }
        }

        private void LoadBudgetFromFile(string filePath)
        {
            if (!File.Exists(filePath))
            {
                MessageBox.Show("File not found.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string json = File.ReadAllText(filePath);
            var data = JsonSerializer.Deserialize<BudgetFile>(json);
            if (data == null)
            {
                MessageBox.Show("Invalid or incompatible budget file.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Clear existing
            foreach (var ctrl in fLPExpenses.Controls.OfType<ExpenseControl>().ToList())
                ctrl.Dispose();
            fLPExpenses.Controls.Clear();

            nudBudget.Value = data.Budget;

            if (data.Expenses != null)
            {
                foreach (var exp in data.Expenses)
                    AddExpenseCard(exp.ExpenseName, exp.Category, exp.Amount);
                _isDirty = false;
            }
            _isDirty = false;
            RecalculateRemaining();
            SortExpenseCards();
            
        }

        private bool ConfirmDiscardUnsavedChanges()
        {
            if (!_isDirty)
                return true;

            var result = MessageBox.Show(
                "You have unsaved changes. Do you want to save your current budget first?",
                "Unsaved Changes",
                MessageBoxButtons.YesNoCancel,
                MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                // If we already have a file, just save.
                if (!string.IsNullOrWhiteSpace(_currentFilePath))
                {
                    SaveBudgetToFile(_currentFilePath);
                    return true;
                }
                else
                {
                    // No file yet → show Save As
                    using (SaveFileDialog dlg = new SaveFileDialog())
                    {
                        dlg.Title = "Save Budget As";
                        dlg.Filter = "JSON Files (*.json)|*.json|All Files (*.*)|*.*";
                        dlg.DefaultExt = "json";
                        dlg.FileName = "budget.json";

                        if (dlg.ShowDialog(this) == DialogResult.OK)
                        {
                            _currentFilePath = dlg.FileName;
                            SaveBudgetToFile(_currentFilePath);
                            return true;
                        }
                        else
                        {
                            // User cancelled Save As
                            return false;
                        }
                    }
                }
            }
            else if (result == DialogResult.No)
            {
                // Discard changes
                return true;
            }
            else // Cancel
            {
                return false;
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(_currentFilePath))
            {
                SaveBudgetToFile(_currentFilePath);
            }
            else
            {
                // No current file yet > fall back to Save As behavior
                saveAsToolStripMenuItem_Click(sender, e);
            }
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (PrintDialog dlg = new PrintDialog())
            {
                dlg.Document = printDocument1;

                if (dlg.ShowDialog(this) == DialogResult.OK)
                {
                    printDocument1.Print();
                }
            }
        }

        private void printPreviewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.Document = printDocument1; // same doc
            printPreviewDialog1.WindowState = FormWindowState.Maximized;
            printPreviewDialog1.ShowDialog(this);
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!ConfirmDiscardUnsavedChanges())
                return;

            _currentFilePath = null; // starting a brand new budget

            // Clear expenses
            foreach (var ctrl in fLPExpenses.Controls.OfType<ExpenseControl>().ToList())
                ctrl.Dispose();
            fLPExpenses.Controls.Clear();

            // Reset budget & remaining
            nudBudget.Value = 0;
            RecalculateRemaining();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        public void CloseApplication()
        {
            Close();
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                if (!ConfirmDiscardUnsavedChanges())
                {
                    e.Cancel = true;   // abort close
                }
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAbout about = new frmAbout();
            about.ShowDialog(this);
        }

        private void fLPExpenses_Paint(object sender, PaintEventArgs e)
        {

        }

        private void sortToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SortExpenseCards();
        }

        private void fLPExpenses_ControlAdded(object sender, ControlEventArgs e)
        {
            SortExpenseCards();
        }
    }

    public class BudgetFile
    {
        public decimal Budget { get; set; }
        public List<ExpenseDto> Expenses { get; set; } = new();
    }
    public class ExpenseDto
    {
        public string ExpenseName { get; set; } = "";
        public string Category { get; set; } = "";
        public decimal Amount { get; set; }
    }
}
