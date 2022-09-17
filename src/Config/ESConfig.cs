using DuckGame;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Config
{
    internal static class ESConfig
    {
        private const string ColorsFile = "EsportsGraphicsColors.json";
        private const string SettingsFile = "EsportsGraphicsSettings.json";
        private const string FloatsFile = "EsportsGraphicsFloats.json";
        public static Dictionary<string, Color> ESColors;
        public static Dictionary<string, bool> Settings;
        public static Dictionary<string, float> Floats;
        public static void LoadAll()
        {
            Load(ref Settings, SettingsFile);
            Load(ref ESColors, ColorsFile);
            Load(ref Floats, FloatsFile);
        }
        public static void SaveAll()
        {
            Save(Settings, SettingsFile);
            Save(ESColors, ColorsFile);
        }
        private static void Load<Key, Value>(ref Dictionary<Key, Value> pairs, string name) => pairs = File.Exists(name)
                ? JsonConvert.DeserializeObject<Dictionary<Key, Value>>(File.ReadAllText(name))
                : (Dictionary<Key, Value>)GetDefaultDictionary(name);
        private static object GetDefaultDictionary(string name)
        {
            switch (name)
            {
                case SettingsFile:
                    Save(DefaultSettings, SettingsFile);
                    return DefaultSettings;
                case ColorsFile:
                    Save(DefaultColors, ColorsFile);
                    return DefaultColors;
                case FloatsFile:
                    Save(DefaultFloats, FloatsFile);
                    return DefaultFloats;
                default:
                    return null;
            }
        }
        private static Dictionary<string, Color> DefaultColors = new Dictionary<string, Color>()
        {
            {"Blocks", Color.Gray },
            {"Back", Color.Black },
            {"Spikes", Color.Red },
            {"DoorClosed", Color.LightYellow },
            {"DoorOpened", Color.DarkOrange },
            {"BarOutLine", Color.Black },
            {"BarBack", Color.White },
            {"BarFront", Color.Green },
            {"EnemyBullet", Color.Red },
            {"EnemyDuck", Color.Pink },
            {"LocalBullet", Color.Green }

        };
        private static Dictionary<string, bool> DefaultSettings = new Dictionary<string, bool>()
        {
            {"Back", true },
            {"Blocks", true},
            {"Spikes", true },
            {"Doors", true},
            {"Bullets", true },
            {"Ducks", true },
            {"ItemSpawnerBar", true },
            {"ItemBoxBar", true },
            {"AmmoCounter", true },
            {"Xray", true }
        };
        private static Dictionary<string, float> DefaultFloats = new Dictionary<string, float>()
        {
            {"BarsAlpha", 0.75f},
            {"XrayAlpha", 0.75f}
        };
        public static void Save<Key, Value>(Dictionary<Key, Value> pairs, string path) => File.WriteAllText(path, JsonConvert.SerializeObject(pairs));
    }
}
