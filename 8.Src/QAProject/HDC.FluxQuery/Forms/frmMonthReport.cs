using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Xdgk.Common;
using Xdgk.Common.Export;

namespace HDC.FluxQuery
{
    public partial class frmMonthReport : Form
    {
        public frmMonthReport()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmMonthReport_Load(object sender, EventArgs e)
        {
            this.Text = Strings.StatisticsMonth;
            SetUI();


            this.ucStationDT1Condition1.BindStationName(
                StationNameSourceProvider.GetStationNameKeyValues());

            string xmlString = Strings.MonthReportColumnConfig;
            this.ucDataGridView1.DgvColumnConfigs = DGVColumnConfigCollectionFactory.CreateFromXmlString(xmlString);
            this.ucStationDT1Condition1.QueryEvent += new EventHandler(ucStationDT1Condition1_QueryEvent);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void ucStationDT1Condition1_QueryEvent(object sender, EventArgs e)
        {
            MonthReportFactory f = new MonthReportFactory(this.ucStationDT1Condition1.SelectedStationName,
                this.ucStationDT1Condition1.SelectedDT1);
            f.Create();
            ReportItemCollection ris = f.Items.ToDayReportItems();
            ris.Add(f.Items.ToSumReportItem());
            this.ucDataGridView1.DataSource = ris;
        }

        /// <summary>
        /// 
        /// </summary>
        private void SetUI()
        {
            this.ucStationDT1Condition1.DT1Label.Text = Strings.LabelMonth;
            this.ucStationDT1Condition1.QueryButtonText = Strings.Statistics;
            DateTimePicker dtp = this.ucStationDT1Condition1.DT1DateTimePicker;
            dtp.Format = DateTimePickerFormat.Custom;
            dtp.CustomFormat = "yyyy-MM";
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
