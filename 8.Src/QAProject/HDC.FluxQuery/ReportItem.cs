
using System;
using System.Data;
using System.Collections.Generic;
using System.Text;


namespace HDC.FluxQuery
{
    public class ReportItem
    {
#region DTText
        /// <summary>
        /// 
        /// </summary>
        public string DTText
        {
            get
            {
                if (_dTText == null)
                {
                    _dTText = string.Empty;
                }
                return _dTText;
            }
            set
            {
                _dTText = value;
            }
        } private string _dTText;
#endregion //DTText

#region BeginDTText
        /// <summary>
        /// 
        /// </summary>
        public string BeginDTText
        {
            get
            {
                if (_beginDTText == null)
                {
                    _beginDTText = string.Empty;
                }
                return _beginDTText;
            }
            set
            {
                _beginDTText = value;
            }
        } private string _beginDTText;
#endregion //BeginDTText

#region EndDTText
        /// <summary>
        /// 
        /// </summary>
        public string EndDTText
        {
            get
            {
                if (_endDTText == null)
                {
                    _endDTText = string.Empty;
                }
                return _endDTText;
            }
            set
            {
                _endDTText = value;
            }
        } private string _endDTText;
#endregion //EndDTText

#region BeginSumText
        /// <summary>
        /// 
        /// </summary>
        public string BeginSumText
        {
            get
            {
                if (_beginSumText == null)
                {
                    _beginSumText = string.Empty;
                }
                return _beginSumText;
            }
            set
            {
                _beginSumText = value;
            }
        } private string _beginSumText;
#endregion //BeginSumText

#region EndSumText
        /// <summary>
        /// 
        /// </summary>
        public string EndSumText
        {
            get
            {
                if (_endSumText == null)
                {
                    _endSumText = string.Empty;
                }
                return _endSumText;
            }
            set
            {
                _endSumText = value;
            }
        } private string _endSumText;
#endregion //EndSumText

#region UsedText
        /// <summary>
        /// 
        /// </summary>
        public string UsedText
        {
            get
            {
                if (_usedText == null)
                {
                    _usedText = string.Empty;
                }
                return _usedText;
            }
            set
            {
                _usedText = value;
            }
        } private string _usedText;
#endregion //UsedText

#region PowerOffRateText
        /// <summary>
        /// 
        /// </summary>
        public string PowerOffRateText
        {
            get
            {
                if (_powerOffRateText == null)
                {
                    _powerOffRateText = string.Empty;
                }
                return _powerOffRateText;
            }
            set
            {
                _powerOffRateText = value;
            }
        } private string _powerOffRateText;
#endregion //PowerOffRateText

    }

}
