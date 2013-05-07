using System;
using System.Collections.Generic;
using System.Text;
using Xdgk.Common;

namespace HDC.FluxQuery
{
    public class DGVColumnConfigCollectionFactory
    {
        static public DGVColumnConfig Create(string line)
        {
            string dataPropertyName = string.Empty;
            string format = string.Empty;
            string text = string.Empty;
            int width = 100;
            bool visible = true;

            string[] items = line.Split(';');
            foreach (string item in items)
            {
                if (item.Trim().Length == 0)
                {
                    continue;
                }

                string[] kv = item.Split('=');

                if (kv.Length == 2)
                {
                    string key = kv[0].Trim().ToUpper();
                    string value = kv[1].Trim();

                    switch (key)
                    {
                        case "DATAPROPERTYNAME":
                            dataPropertyName = value;
                            break;

                        case "FORMAT":
                            format = value;
                            break;

                        case "TEXT":
                            text = value;
                            break;

                        case "WIDTH":
                            width = int.Parse(value);
                            break;

                        case "VISIBLE":
                            visible = bool.Parse(value);
                            break;

                        default :
                            throw new FormatException(string.Format("not find key '{0}'", kv[0]));
                    }
                }
                else
                {
                    throw new FormatException(item);
                }
            }
            // dataPropertyName=adfa; b=aaa; c=fdfkdfj;
            DGVColumnConfig r = new DGVColumnConfig(dataPropertyName, format, text);
            r.Width = width;
            r.Visible = visible;
            return r;

        }

        static public DGVColumnConfigCollection Create(string[] lines)
        {
            DGVColumnConfigCollection r = new DGVColumnConfigCollection();
            foreach (string line in lines)
            {
                DGVColumnConfig item = Create(line);
                r.Add(item);
            }
            return r; 
        }
    }
}
