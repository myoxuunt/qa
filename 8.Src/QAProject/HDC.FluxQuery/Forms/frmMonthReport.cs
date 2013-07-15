﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Xdgk.Common;

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
            this.Text = "月统计表";
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
            this.ucStationDT1Condition1.DT1Label.Text = "月份:";
            this.ucStationDT1Condition1.QueryButtonText = "统计";
            DateTimePicker dtp = this.ucStationDT1Condition1.DT1DateTimePicker;
            dtp.Format = DateTimePickerFormat.Custom;
            dtp.CustomFormat = "yyyy-MM";
            dtp.ShowUpDown = true;
        }
    }
}
