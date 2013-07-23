using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Xdgk.Common.Export;

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
            this.Text = Strings.StatisticsYear;
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
            this.ucStationDT1Condition1.DT1Label.Text = Strings.LabelYear;
            this.ucStationDT1Condition1.QueryButtonText = Strings.Statistics;

            DateTimePicker dtp = this.ucStationDT1Condition1.DT1DateTimePicker;
            dtp.Format = DateTimePickerFormat.Custom;
            dtp.CustomFormat = "yyyy";
            dtp.ShowUpDown = true;


            //
            //
            Button exportBtn = new Button();
            exportBtn.Text = Strings.ExportButtonText;
            exportBtn.Click += new EventHandler(exportBtn_Click);
            this.ucStationDT1Condition1.AddExtendButton(exportBtn);

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void exportBtn_Click(object sender, EventArgs e)
        {
            Exporter.Export(ucDataGridView1.DataGridView);
        }
    }
}
