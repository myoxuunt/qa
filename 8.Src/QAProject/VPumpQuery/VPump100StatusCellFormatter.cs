using System;
using System.Collections;
using System.Windows.Forms;
using VPump100Common;
using Xdgk.Common;


namespace VPumpQuery
{
    public class VPump100StatusCellFormatter
    {
        private VPump100StatusCellFormatter()
        {

        }

        static public void Format( DataGridView dgv, DataGridViewCellFormattingEventArgs e)
        {
            string s = dgv.Columns[e.ColumnIndex].DataPropertyName;
            if (e.Value != null)
            {
                Type tp = VPump100StatusCellFormatter.GetStatusType(s);
                if (tp != null)
                {
                    object val = VPump100StatusCellFormatter.ConvertToStatusType(tp, (byte)e.Value);
                    if (val != null)
                    {
                        e.Value = VPump100StatusCellFormatter.GetString(val);
                        e.FormattingApplied = true;
                    }
                }
            }
        }

        static public object ConvertToStatusType(Type destType, byte value)
        {
            if (destType == typeof(PumpStatus))
            {
                return (PumpStatus)value;
            }
            else if (destType == typeof(ForceStartStatus))
            {
                return (ForceStartStatus)value;
            }
            else if (destType == typeof(VibrateStatus))
            {
                return (VibrateStatus)value;
            }
            else if (destType == typeof(PumpPowerStatus))
            {
                return (PumpPowerStatus)value;
            }
            else
            {
                //string s = string.Format("Unkonwn destType '{0}'", destType.Name);
                //throw new ArgumentException(s);
                return null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        static object[] _list = new object[] { 
                "PumpStatus", typeof(PumpStatus), 
                "ForceStatus", typeof(ForceStartStatus), 
                "VibrateStatus", typeof(VibrateStatus), 
                "PowerStatus", typeof(PumpPowerStatus) 
            };

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dataPropertyName"></param>
        /// <returns></returns>
        static public Type GetStatusType(string dataPropertyName)
        {
            for (int i = 0; i < _list.Length; i += 2)
            {
                if (StringHelper.Equal(dataPropertyName, (string)_list[i]))
                {
                    return (Type)(_list[i + 1]);
                }
            }

            return null;
        }

        static Hashtable _hash = new Hashtable();

        static public string GetString(object statusValue)
        {
            if (_hash.Contains(statusValue))
            {
                return (string)_hash[statusValue];
            }
            else
            {
                string s = EnumTextAttributeHelper.GetEnumTextAttributeValue(statusValue);
                _hash[statusValue] = s;
                return s;
            }
        }
    }

}
