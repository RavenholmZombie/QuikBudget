using System;
using System.Collections.Generic;
using System.Text;

namespace QuikBudget
{
    /// <summary>
    /// Helper for fetching company logos from Logo.dev.
    /// </summary>
    public static class LogoDevClient
    {
        // TODO: Set this once at startup (e.g. Program.cs) or here directly.
        // Get your publishable key from https://www.logo.dev/
        public static string ApiToken { get; set; } = "";

        private static readonly HttpClient _httpClient = new HttpClient();

        /// <summary>
        /// Fetches a logo by brand name (e.g., "Verizon Wireless").
        /// Uses the /name/ endpoint.
        /// </summary>
        /// <param name="brandName">Brand name, e.g. "Capital One".</param>
        /// <param name="size">Desired size in pixels (Logo.dev default is 128).</param>
        /// <returns>Image if successful; null if not found or on error.</returns>
        /// 
        public static async Task<Image?> GetLogoByBrandNameAsync(string brandName, int size = 64)
        {
            if (string.IsNullOrWhiteSpace(brandName))
                throw new ArgumentException("Brand name must not be empty.", nameof(brandName));

            EnsureApiToken();

            // URL-encode the brand name as required by Logo.dev
            string encodedName = Uri.EscapeDataString(brandName.Trim());

            // PNG gives you transparency; you can tweak theme/greyscale here if you want
            string url =
                $"https://img.logo.dev/name/{encodedName}?token={ApiToken}&size={size}&format=png";

            return await DownloadImageAsync(url);
        }

        /// <summary>
        /// Fetches a logo by domain (e.g., "verizon.com").
        /// </summary>
        /// <param name="domain">Domain like "verizon.com" (no protocol).</param>
        /// <param name="size">Desired size in pixels.</param>
        /// <returns>Image if successful; null if not found or on error.</returns>
        /// 
        public static async Task<Image?> GetLogoByDomainAsync(string domain, int size = 64)
        {
            if (string.IsNullOrWhiteSpace(domain))
                throw new ArgumentException("Domain must not be empty.", nameof(domain));

            EnsureApiToken();

            string trimmedDomain = domain.Trim();

            string url =
                $"https://img.logo.dev/{trimmedDomain}?token={ApiToken}&size={size}&format=png";

            return await DownloadImageAsync(url);
        }

        /// <summary>
        /// Core helper that downloads the image and converts it to System.Drawing.Image.
        /// Returns null if the request fails.
        /// </summary>
        /// 
        private static async Task<Image?> DownloadImageAsync(string url)
        {
            try
            {
                using (var response = await _httpClient.GetAsync(url))
                {
                    if (!response.IsSuccessStatusCode)
                        return null;

                    using (var stream = await response.Content.ReadAsStreamAsync())
                    {
                        // Image.FromStream needs the stream to stay open until the image is created.
                        return Image.FromStream(stream);
                    }
                }
            }
            catch
            {
                // Swallow network errors; you can log this if you want.
                return null;
            }
        }

        private static void EnsureApiToken()
        {
            if (string.IsNullOrWhiteSpace(ApiToken) ||
                ApiToken == "")
            {
                throw new InvalidOperationException(
                    "LogoDevClient.ApiToken is not set. " +
                    "Set it to your Logo.dev publishable key before calling this method.");
            }
        }
    }
}
