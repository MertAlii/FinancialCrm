using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FinancialCrm.Models;

namespace FinancialCrm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        FinancialCrmDbEntities db = new FinancialCrmDbEntities();
        int count = 0;
        private void Form1_Load(object sender, EventArgs e)
        {
            var totalBalance = db.Banks.Sum(x => x.BankBalance);
            lblTotalBalance.Text = totalBalance.ToString() + " TL";

            var lastBankProcessAmount = db.BankProcesses.OrderByDescending(x => x.BankProcessId).Take(1).Select(y => y.Amount).FirstOrDefault();
            lblLastBankProcessAmount.Text = lastBankProcessAmount.ToString();

            //Chart1
            var bankdata = db.Banks.Select(x => new
            {
                x.BankTitle,
                x.BankBalance
            }).ToList();
            chart1.Series.Clear();
            var series = chart1.Series.Add("Series1");
            foreach (var item in bankdata)
            {
                series.Points.AddXY(item.BankTitle, item.BankBalance);
            }

            //chart2
            var billData = db.Bills.Select(x => new
            {
                x.BillTitle,
                x.BillAmount
            }).ToList();
            chart2.Series.Clear();
           
            var series2 = chart2.Series.Add("Series2");
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            foreach (var item in billData)
            {
                series2.Points.AddXY(item.BillTitle, item.BillAmount);
            }

            }

        private void timer1_Tick(object sender, EventArgs e)
        {
            count++;
            if(count % 4 == 1)
            {
                var elektrikfaturası = db.Bills.Where(x => x.BillTitle == "Elektirik Faturası").Select(y=> y.BillAmount).FirstOrDefault();
                lblBillTitle.Text = "Elektrik Faturası";
                lblBillAmount.Text = elektrikfaturası.ToString() + " TL";
            }
            if(count % 4 == 2)
            {
                var DoğalgazFaturası = db.Bills.Where(x => x.BillTitle == "Doğalgaz Faturası").Select(y=> y.BillAmount).FirstOrDefault();
                lblBillTitle.Text = "Doğalgaz Faturası";
                lblBillAmount.Text = DoğalgazFaturası.ToString() + " TL";
            }
            if(count % 4 == 3)
            {
                var SuFaturası = db.Bills.Where(x => x.BillTitle == "Su Faturası").Select(y=> y.BillAmount).FirstOrDefault();
                lblBillTitle.Text = "Su Faturası";
                lblBillAmount.Text = SuFaturası.ToString() + " TL";
            }

        }
    }
}
