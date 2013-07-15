using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace HDC.FluxQuery
{
    public partial class frmYearReport : Form
    {
        public frmYearReport()
        {
            InitializeComponent();
        }

        private void frmYearReport_Load(object sender, EventArgs e)
        {
            this.Text = "年统计表";
            SetUI();
            this.ucStationDT1Condition1.BindStationName(
                StationNameSourceProvider.GetStationNameKeyValues());

            this.ucDataGridView1.DgvColumnConfigs = Xdgk.Common.DGVColumnConfigCollectionFactory.CreateFromXmlString(
                Strings.YearReportColumnConfig);

            this.ucStationDT1Condition1.QueryEvent += new EventHandler(ucStationDT1Condition1_QueryEvent);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void ucStationDT1Condition1_QueryEvent(object sender, EventArgs e)
        {
            YearReportFactory f = new YearReportFactory(this.ucStationDT1Condition1.SelectedStationName,
                this.ucStationDT1Condition1.SelectedDT1);
            f.Create();

            ReportItemCollection ris = f.Items.ToMonthReportItems();
            ris.Add(f.Items.ToSumReportItem());
            this.ucDataGridView1.DataSource = ris;
        }

        private void SetUI()
        {
            this.ucStationDT1Condition1.DT1Label.Text = "年份:";
            this.ucStationDT1Condition1.QueryButtonText = "统计";

            DateTimePicker dtp = this.ucStationDT1Condition1.DT1DateTimePicker;
            dtp.Format = DateTimePickerFormat.Custom ;
            dtp.CustomFormat = "yyyy";
            dtp.ShowUpDown = true;
        }
    }
}
