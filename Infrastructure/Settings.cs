using System.IO;
using System.Text.Json;

namespace JsonDiffer.System;

public static class Settings
{
    private static StoredSettings _stored;

    public static StoredSettings Get()
    {
        if (_stored == null)
        {
            if (File.Exists("settings.json"))
                _stored = JsonSerializer.Deserialize<StoredSettings>(File.ReadAllText("settings.json"));
            else
                return new StoredSettings{FirstTimeSetup = true};
        }

        return JsonSerializer.Deserialize<StoredSettings>(JsonSerializer.Serialize(_stored));
    }

    public static void Save(StoredSettings settings)
    {
        var jsonString = JsonSerializer.Serialize(settings);
        File.WriteAllText("settings.json", jsonString);
        _stored = settings;
    }
}

public class StoredSettings
{
    public bool FirstTimeSetup { get; set; }
    public int WindowLocationX { get; set; }
    public int WindowLocationY { get; set; }
    public int WindowSizeHeight { get; set; }
    public int WindowSizeLength { get; set; }
}