using System.Text.Json;

public static class SettingsService
{
    private const string SettingsKey = "userSettings";

    public static Settings LoadSettings()
    {
        var settingsJson = Preferences.Get(SettingsKey, string.Empty);
        return string.IsNullOrEmpty(settingsJson) ? new Settings() : JsonSerializer.Deserialize<Settings>(settingsJson);
    }

    public static void SaveSettings(Settings settings)
    {
        var settingsJson = JsonSerializer.Serialize(settings);
        Preferences.Set(SettingsKey, settingsJson);
    }
}
