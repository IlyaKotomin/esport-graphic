using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DuckGame;

namespace EsportGraphics.src.Config
{
    internal class Options
    {
        public static Data Data = new Data();
        private static string FileName => DuckFile.optionsDirectory + "EsportGraphics.dat";

        public static void Save()
        {
            var data = new DXMLNode("Data");
            data.Add(Data.Serialize());

            var xml = new DuckXML();
            xml.Add(data);
            DuckFile.SaveDuckXML(xml, FileName);
        }
        public static void Load()
        {
            DuckXML xml = DuckFile.LoadDuckXML(FileName);

            if (xml is null || xml.Elements("Data") is null)
                return;

            foreach (DXMLNode data in xml.Elements("Data").Elements())
            {
                if (data.Name == "Options")
                {
                    Data.Deserialize(data);
                    break;
                }
            }
        }
    }
}
