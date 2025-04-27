namespace AIForITSM
{
    using System.Text.Json;

    /// <summary>
    /// Service for managing company configurations stored in appsettings.json.
    /// </summary>
    public class ConfigurationService
    {
        private const string FILE_PATH = "appsettings.json";

        /// <summary>
        /// Deletes a company's configuration from the appsettings.json file.
        /// </summary>
        /// <param name="companyName">The name of the company to delete.</param>
        public async Task DeleteCompanyAsync(string companyName)
        {
            string json = await File.ReadAllTextAsync(FILE_PATH);
            Dictionary<string, object>? config = JsonSerializer.Deserialize<Dictionary<string, object>>(json);
            if (config != null && config.ContainsKey("CompanySettings"))
            {
                Dictionary<string, object>? companySettings = JsonSerializer.Deserialize<Dictionary<string, object>>(config["CompanySettings"]?.ToString() ?? "{}");
                if (companySettings != null && companySettings.ContainsKey(companyName))
                {
                    companySettings.Remove(companyName);
                    config["CompanySettings"] = companySettings;

                    string updatedJson = JsonSerializer.Serialize(config, new JsonSerializerOptions { WriteIndented = true });
                    await File.WriteAllTextAsync(FILE_PATH, updatedJson);
                }
            }
        }

        /// <summary>
        /// Retrieves the list of company names from the appsettings.json file.
        /// </summary>
        /// <returns>A list of company names.</returns>
        public async Task<List<string>> GetCompanyNamesAsync()
        {
            List<string> companyNames = new List<string>();
            string json = await File.ReadAllTextAsync("appsettings.json");
            Dictionary<string, object>? config = JsonSerializer.Deserialize<Dictionary<string, object>>(json);
            if (config != null && config.ContainsKey("CompanySettings"))
            {
                Dictionary<string, object>? companySettings = JsonSerializer.Deserialize<Dictionary<string, object>>(config["CompanySettings"]?.ToString() ?? "{}");
                companyNames = companySettings?.Keys.ToList() ?? new List<string>();
            }

            return companyNames;
        }

        /// <summary>
        /// Updates the configuration details for a specific company in the appsettings.json file.
        /// </summary>
        /// <param name="companyName">The name of the company to update.</param>
        /// <param name="config">The new configuration details for the company.</param>
        public async Task UpdateCompanyDetailsAsync(string companyName, CompanyConfig config)
        {
            string json = await File.ReadAllTextAsync(FILE_PATH);
            Dictionary<string, object>? appConfig = JsonSerializer.Deserialize<Dictionary<string, object>>(json);
            if (appConfig != null)
            {
                if (!appConfig.ContainsKey("CompanySettings"))
                {
                    appConfig["CompanySettings"] = new Dictionary<string, object>();
                }

                Dictionary<string, object>? companySettings = JsonSerializer.Deserialize<Dictionary<string, object>>(appConfig["CompanySettings"]?.ToString() ?? "{}");
                if (companySettings != null)
                {
                    companySettings[companyName] = config;
                    appConfig["CompanySettings"] = companySettings;
                    string updatedJson = JsonSerializer.Serialize(appConfig, new JsonSerializerOptions { WriteIndented = true });
                    await File.WriteAllTextAsync(FILE_PATH, updatedJson);
                }
            }
        }

        /// <summary>
        /// Retrieves the configuration details for a specific company.
        /// </summary>
        /// <param name="companyName">The name of the company to retrieve details for.</param>
        /// <returns>The configuration details of the company.</returns>
        public async Task<CompanyConfig?> GetCompanyDetailsAsync(string companyName)
        {
            CompanyConfig? companyConfig = null;
            string json = await File.ReadAllTextAsync(FILE_PATH);
            Dictionary<string, object>? config = JsonSerializer.Deserialize<Dictionary<string, object>>(json);
            if (config != null && config.ContainsKey("CompanySettings"))
            {
                Dictionary<string, CompanyConfig>? companySettings = JsonSerializer.Deserialize<Dictionary<string, CompanyConfig>>(config["CompanySettings"]?.ToString() ?? "{}");

                if (companySettings != null && companySettings.ContainsKey(companyName))
                {
                    companyConfig = companySettings[companyName];
                }
            }

            return companyConfig;
        }
    }
}
