using DuckGame;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsportGraphics.src.Config
{
    internal static class Config
    {
        private const string ColorsFile = "EsportsGraphicsColors.json";
        private const string SettingsFile = "EsportsGraphicsSettings.json";
        public static Dictionary<string, Color> Colors;
        public static Dictionary<string, bool> Settings;
        public static void LoadAll()
        {
            Load(ref Settings, SettingsFile);
            Load(ref Colors, ColorsFile);
        }
        public static void SaveAll()
        {
            Save(Settings, SettingsFile);
            Save(Colors, ColorsFile);
        }
        private static void Load<Key, Value>(ref Dictionary<Key, Value> pairs, string name) => pairs = File.Exists(name)
                ? JsonConvert.DeserializeObject<Dictionary<Key, Value>>(File.ReadAllText(name))
                : (Dictionary<Key, Value>)GetDefaultDictionary(name);
        private static object GetDefaultDictionary(string name)
        {
            if (name == SettingsFile)
            {
                Save(DefaultSettings, SettingsFile);
                return DefaultSettings;
            }
            else if (name == ColorsFile)
            {
                Save(DefaultColors, ColorsFile);
                return DefaultColors;
            }
            else
                return null;
        }
        private static Dictionary<string, Color> DefaultColors = new Dictionary<string, Color>()
        {
            {"Blocks", Color.Gray },
            {"Back", Color.Black },
            {"DoorsClosed", Color.LightYellow },
            {"ClosedOpened", Color.DarkOrange},
        };
        private static Dictionary<string, bool> DefaultSettings = new Dictionary<string, bool>()
        {
            {"AmmoCounter", true },
            {"Back", true },
            {"Blocks", true},
            {"Doors", true},
            {"Bullets", true },
            {"Ducks", true },
        };
        public static void Save<Key, Value>(Dictionary<Key, Value> pairs, string path) => File.WriteAllText(path, JsonConvert.SerializeObject(pairs));
    }
}
