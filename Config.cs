using System.Configuration;
using System.Xml.Linq;

namespace AlcLibrary
{
    public class Config
    {
        public static string GetConnectionString()
        {
            string connectionString = GetConfigValue("ConnectionString");
            return connectionString;
        }

        public static string GetConfigValue(string key)
        {
            return ConfigurationManager.AppSettings[key] ?? "";
        }

        private static void CreateConfigFileWithConnectionString(string configFile)
        {
            // Cria um novo arquivo de configuração com a chave ConnectionString
            XDocument doc = new XDocument(
                new XElement("configuration",
                    new XElement("appSettings",
                        new XElement("add",
                            new XAttribute("key", "ConnectionString"),
                            new XAttribute("value", "sua_connection_string_aqui")
                        )
                    )
                )
            );

            doc.Save(configFile);
        }

    }
}
