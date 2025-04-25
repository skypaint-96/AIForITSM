using System.Text.Json;

public class ConfigurationService
{
    private readonly string _filePath = "appsettings.json";

    public async Task DeleteCompanyAsync(string companyName)
    {
        var json = await File.ReadAllTextAsync(_filePath);
        var config = JsonSerializer.Deserialize<Dictionary<string, object>>(json);

        if (config != null && config.ContainsKey("CompanySettings"))
        {
            var companySettings = JsonSerializer.Deserialize<Dictionary<string, object>>(config["CompanySettings"].ToString() ?? "{}");

            if (companySettings != null && companySettings.ContainsKey(companyName))
            {
                companySettings.Remove(companyName);
                config["CompanySettings"] = companySettings;

                var updatedJson = JsonSerializer.Serialize(config, new JsonSerializerOptions { WriteIndented = true });
                await File.WriteAllTextAsync(_filePath, updatedJson);
            }
        }
    }
    public async Task<List<string>> GetCompanyNamesAsync()
    {
        var json = await File.ReadAllTextAsync("appsettings.json");
        var config = JsonSerializer.Deserialize<Dictionary<string, object>>(json);
        if (config != null && config.ContainsKey("CompanySettings"))
        {
            var companySettings = JsonSerializer.Deserialize<Dictionary<string, object>>(config["CompanySettings"].ToString() ?? "{}");
            return companySettings?.Keys.ToList() ?? new List<string>();
        }
        return new List<string>();
    }
    public async Task UpdateCompanyDetailsAsync(string companyName, CompanyConfig config)
    {
        var json = await File.ReadAllTextAsync(_filePath);
        var appConfig = JsonSerializer.Deserialize<Dictionary<string, object>>(json);

        if (appConfig == null) return;

        if (!appConfig.ContainsKey("CompanySettings"))
        {
            appConfig["CompanySettings"] = new Dictionary<string, object>();
        }

        var companySettings = JsonSerializer.Deserialize<Dictionary<string, object>>(appConfig["CompanySettings"].ToString() ?? "{}");

        companySettings[companyName] = config;

        appConfig["CompanySettings"] = companySettings;

        var updatedJson = JsonSerializer.Serialize(appConfig, new JsonSerializerOptions { WriteIndented = true });
        await File.WriteAllTextAsync(_filePath, updatedJson);
    }

    //public async Task<Dictionary<string, string>> GetCompanyDetailsAsync(string companyName)
    //{
    //    var json = await File.ReadAllTextAsync(_filePath);
    //    var config = JsonSerializer.Deserialize<Dictionary<string, object>>(json);

    //    if (config == null || !config.ContainsKey("CompanySettings")) return null;

    //    var companySettings = JsonSerializer.Deserialize<Dictionary<string, object>>(config["CompanySettings"].ToString() ?? "{}");

    //    if (companySettings == null || !companySettings.ContainsKey(companyName)) return null;

    //    var company = JsonSerializer.Deserialize<Dictionary<string, string>>(companySettings[companyName].ToString() ?? "{}");

    //    return new Dictionary<string, string>
    //    {
    //        { "ApiKey", EncryptionHelper.Decrypt(company["ApiKey"]) },
    //        { "Endpoint", EncryptionHelper.Decrypt(company["Endpoint"]) }
    //    };
    //}
    public async Task<CompanyConfig> GetCompanyDetailsAsync(string companyName)
    {
        var json = await File.ReadAllTextAsync(_filePath);
        var config = JsonSerializer.Deserialize<Dictionary<string, object>>(json);

        if (config == null || !config.ContainsKey("CompanySettings")) return null;

        var companySettings = JsonSerializer.Deserialize<Dictionary<string, CompanyConfig>>(config["CompanySettings"].ToString() ?? "{}");

        if (companySettings == null || !companySettings.ContainsKey(companyName)) return null;

        return companySettings[companyName];
    }

}
