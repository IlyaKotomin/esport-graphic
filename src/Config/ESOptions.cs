using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DuckGame;

namespace EsportGraphics.src.Config
{
    internal static class ESOptions
    {
        public static SettingsData _settingsData = new SettingsData();
        public static ColorsData _colorsData = new ColorsData();
        private static string FileName => DuckFile.optionsDirectory + "EsportGraphics.dat";

        public static void Save()
        {
            var settingsData = new DXMLNode("SettingsData");
            settingsData.Add(_settingsData.Serialize());

            var colorsData = new DXMLNode("ColorsData");
            colorsData.Add(_colorsData.Serialize());

            var xml = new DuckXML();
            xml.Add(settingsData);
            xml.Add(colorsData);
            DuckFile.SaveDuckXML(xml, FileName);
            HUD.AddInputChangeDisplay("Settings Saved");
        }
        public static void Load()
        {
            LoadSettings();
            LoadColors();
            HUD.AddInputChangeDisplay("Settings Loaded");
        }
        public static void LoadSettings()
        {
            DuckXML xml = DuckFile.LoadDuckXML(FileName);

            if (xml is null || xml.Elements("Data") is null)
                return;

            foreach (DXMLNode data in xml.Elements("Data").Elements())
            {
                if (data.Name == "SettingsData")
                {
                    _settingsData.Deserialize(data);
                    break;
                }
            }
        }
        public static void LoadColors()
        {
            DuckXML xml = DuckFile.LoadDuckXML(FileName);

            if (xml is null || xml.Elements("Data") is null)
                return;

            foreach (DXMLNode data in xml.Elements("Data").Elements())
            {
                if (data.Name == "ColorsData")
                {
                    _colorsData.Deserialize(data);
                    break;
                }
            }
        }
    }
}
