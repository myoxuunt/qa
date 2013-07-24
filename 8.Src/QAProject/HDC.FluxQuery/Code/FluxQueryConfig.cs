using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using Xdgk.Common;

namespace HDC.FluxQuery.Code
{
    internal class FluxQueryConfig
    {
        static internal int AlarmCheckInterval
        {
            get 
            {
                int minSecond = 5;
                int maxSecond = 60 * 60;
                int defSecond = 30;

                AppConfigReaderForDll reader = new AppConfigReaderForDll(typeof(FluxQueryConfig));
                string value = reader.GetSettingValue("AlarmCheckSecond");
                if (!string.IsNullOrEmpty(value))
                {
                    int r = 0;
                    bool b = int.TryParse(value, out r);
                    if (b)
                    {
                        if (r >= minSecond && r <= maxSecond)
                        {
                            return r * 1000;
                        }
                    }
                }

                return defSecond * 1000;
            }
        }
    }
}
