namespace OricExplorer
{
    using FastColoredTextBoxNS;
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.IO;
    using System.Web.Script.Serialization;
    using static OricExplorer.ConstantsAndEnums;

    public static class Configuration
    {
        private const string DEFAULT_FILENAME = "OricExplorer.json";

        public static Settings Persistent;

        public static bool ListOfFoldersModified = false;

        public static void Init()
        {
            Persistent = Settings.Load();

            foreach (ConstantsAndEnums.SyntaxHighlightingItems item in Enum.GetValues(typeof(ConstantsAndEnums.SyntaxHighlightingItems)))
            {
                if (!Persistent.SyntaxHighlightingStyles.ContainsKey(item))
                {
                    Persistent.SyntaxHighlightingStyles.Add(item, ConstantsAndEnums.SyntaxHighlightingDefaultValues[(int)item]);
                }
            }
        }

        public class Settings : AppSettings<Settings>
        {
            public string DirectoryListingsFolder { get; set; }
            public List<string> TapeFolders { get; set; } = new List<string>();
            public List<string> DiskFolders { get; set; } = new List<string>();
            public List<string> RomFolders { get; set; } = new List<string>();
            public string EmulatorExecutable { get; set; }
            public Machine DefaultMachineForTape { get; set; } = Machine.Atmos;
            public bool CheckForUpdatesOnStartup { get; set; } = false;
            public Color PageBackground { get; set; } = ConstantsAndEnums.BACKGROUND;
            public Dictionary<ConstantsAndEnums.SyntaxHighlightingItems, TextStyle> SyntaxHighlightingStyles { get; set; } = new Dictionary<ConstantsAndEnums.SyntaxHighlightingItems, TextStyle>();
            public bool TapeIndex { get; set; } = true;

            public Point MainWindowLocation { get; set; }
            public Size MainWindowSize { get; set; }
            public bool MainWindowMaximized { get; set; }
            public string DockPanelLayout { get; set; }
        }

        public class AppSettings<T> where T : new()
        {
            public static T Load(string fileName = Configuration.DEFAULT_FILENAME)
            {
                T config = new T();

                if (File.Exists(fileName))
                {
                    JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
                    javaScriptSerializer.RegisterConverters(new JavaScriptConverter[] { new ColorConverter(), new SyntaxHighlightingConverter() });

                    config = javaScriptSerializer.Deserialize<T>(File.ReadAllText(fileName));
                }

                return config;
            }

            public void Save(string fileName = Configuration.DEFAULT_FILENAME)
            {
                JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
                javaScriptSerializer.RegisterConverters(new JavaScriptConverter[] { new ColorConverter(), new SyntaxHighlightingConverter() });

                File.WriteAllText(fileName, javaScriptSerializer.Serialize(this));
            }

            private class ColorConverter : JavaScriptConverter
            {
                public override IEnumerable<Type> SupportedTypes
                {
                    get
                    {
                        return new[] { typeof(Color) };
                    }
                }

                public override object Deserialize(IDictionary<string, object> dictionary, Type type, JavaScriptSerializer serializer)
                {
                    foreach (string key in dictionary.Keys)
                    {
                        if (key.Equals("Color", StringComparison.InvariantCultureIgnoreCase))
                        {
                            return ColorTranslator.FromHtml(dictionary[key].ToString());
                        }
                    }
                    return null;
                }

                public override IDictionary<string, object> Serialize(object obj, JavaScriptSerializer serializer)
                {
                    Color c = (Color)obj;
                    IDictionary<string, object> serialized = new Dictionary<string, object>
                    {
                        ["Color"] = ColorTranslator.ToHtml(c)
                    };
                    return serialized;
                }
            }

            private class SyntaxHighlightingConverter : JavaScriptConverter
            {
                public override IEnumerable<Type> SupportedTypes
                {
                    get
                    {
                        return new[] { typeof(Dictionary<ConstantsAndEnums.SyntaxHighlightingItems, TextStyle>) };
                    }
                }

                public override object Deserialize(IDictionary<string, object> dictionary, Type type, JavaScriptSerializer serializer)
                {
                    Dictionary<ConstantsAndEnums.SyntaxHighlightingItems, TextStyle> dic = new Dictionary<ConstantsAndEnums.SyntaxHighlightingItems, TextStyle>();
                    
                    foreach (var tup in dictionary)
                    {
                        var value = tup.Value.ToString().Split('|');
                        dic[(ConstantsAndEnums.SyntaxHighlightingItems)Enum.Parse(typeof(ConstantsAndEnums.SyntaxHighlightingItems), tup.Key.ToString())] = new TextStyle(new SolidBrush(ColorTranslator.FromHtml(value[0])), null, (FontStyle)int.Parse(value[1]));
                    }

                    return dic;
                }

                public override IDictionary<string, object> Serialize(object obj, JavaScriptSerializer serializer)
                {
                    IDictionary<string, object> serialized = new Dictionary<string, object>();

                    foreach (var tup in (Dictionary<ConstantsAndEnums.SyntaxHighlightingItems, TextStyle>)obj)
                    {
                        serialized[tup.Key.ToString()] = $"{ColorTranslator.ToHtml(((SolidBrush)tup.Value.ForeBrush).Color)}|{(int)tup.Value.FontStyle}";
                    }

                    return serialized;
                }
            }
        }
    }
}
