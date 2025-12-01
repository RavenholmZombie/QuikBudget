using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace QuikBudget
{
    public partial class frmAbout : Form
    {
        private readonly AppUpdateChecker _updateChecker;
        private int _delay;
        public frmAbout()
        {
            InitializeComponent();
            _updateChecker = new AppUpdateChecker(Application.ProductVersion);
        }

        private void frmAbout_Load(object sender, EventArgs e)
        {
            label3.Text = $"Version {Application.ProductVersion.Split('+')[0]}";
            btnDownload.Hide();
            pBoxStatus.Image = Properties.Resources.info;
        }

        public async void RemoteUpdateTrigger()
        {
            try
            {
                await RunUpdateCheckAsync();
            }
            catch (Exception ex)
            {
                lblUpdateStatus.Text = "Unable to check for updates.\n" + ex;
            }
            finally
            {
                btnCheckForUpdates.Enabled = true;
                ControlBox = true;
            }
        }

        public async Task TriggerUpdateCheckAsync()
        {
            lblUpdateStatus.Text = "Launching update check request...";
            btnCheckForUpdates.Enabled = false;
            ControlBox = false;
            pBoxStatus.Image = Properties.Resources.two_clockwise_circular_rotating_arrows_circle;
            timer1.Start();

            try
            {
                await RunUpdateCheckAsync();
            }
            catch (Exception ex)
            {
                lblUpdateStatus.Text = "Unable to check for updates.\n" + ex;
            }
            finally
            {
                btnCheckForUpdates.Enabled = true;
                ControlBox = true;
                timer1.Stop();
                _delay = 0;
            }
        }

        private async Task RunUpdateCheckAsync()
        {
            await _updateChecker.CheckAsync();

            var current = _updateChecker.CurrentVersion;
            var remote = _updateChecker.RemoteVersion;

            if (!_updateChecker.IsUpdateAvailable)
            {
                lblUpdateStatus.Text =
                    "You are running the latest version.\n\n" +
                    "Your Version: " + current + "\n" +
                    "Latest Version: " + remote;
                pBoxStatus.Image = Properties.Resources._checked;
            }
            else
            {
                lblUpdateStatus.Text =
                    "A new version is available.\n\n" +
                    "Your Version: " + current + "\n" +
                    "Latest Version: " + remote;
                pBoxStatus.Image = Properties.Resources.info;

                btnDownload.Show();
                btnDownload.Enabled = true;
            }
        }

        private async void btnCheckForUpdates_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private async void timer1_Tick(object sender, EventArgs e)
        {
            _delay++;
            if(_delay > 5) timer1.Stop();await TriggerUpdateCheckAsync();
        }
    }
}
