﻿using FinancialCrm.Models;
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
    public partial class FrmBanks : Form
    {
        public FrmBanks()
        {
            InitializeComponent();
        }
        FinancialCrmDbEntities db = new FinancialCrmDbEntities();
        private void FrmBanks_Load(object sender, EventArgs e)
        {
            var ziraatBankBalance = db.Banks.Where(x=> x.BankTitle == "Ziraat Bankası").Select(x => x.BankBalance).FirstOrDefault();
            var vakifBankBalance = db.Banks.Where(x => x.BankTitle == "Vakıf Bankası").Select(x => x.BankBalance).FirstOrDefault();
            var isBankBalance = db.Banks.Where(x => x.BankTitle == "İş Bankası").Select(x => x.BankBalance).FirstOrDefault();

            lblZiraatBankBalance.Text = ziraatBankBalance.ToString() + " TL";
            lblVakifBankBalance.Text = vakifBankBalance.ToString() + " TL";
            lblİşBankasiBalance.Text = isBankBalance.ToString() + " TL";

            //Banka Hareketleri
            var bankProcess1 =db.BankProcesses.OrderByDescending(x => x.BankProcessId).Take(1).FirstOrDefault();
            lblBankProcess1.Text = bankProcess1.Description + " " + bankProcess1.Amount + " TL" + " " + bankProcess1.ProcessDate;

            var bankProcess2 =db.BankProcesses.OrderByDescending(x => x.BankProcessId).Take(2).Skip(1).FirstOrDefault();
            lblBankProcess2.Text = bankProcess2.Description + " " + bankProcess2.Amount + " TL" + " " + bankProcess2.ProcessDate;

            var bankProcess3 =db.BankProcesses.OrderByDescending(x => x.BankProcessId).Take(3).Skip(2).FirstOrDefault();
            lblBankProcess3.Text = bankProcess3.Description + " " + bankProcess3.Amount + " TL" + " " + bankProcess3.ProcessDate;

            var bankProcess4 =db.BankProcesses.OrderByDescending(x => x.BankProcessId).Take(4).Skip(3).FirstOrDefault();
            lblBankProcess4.Text = bankProcess4.Description + " " + bankProcess4.Amount + " TL" + " " + bankProcess4.ProcessDate;

            var bankProcess5 =db.BankProcesses.OrderByDescending(x => x.BankProcessId).Take(5).Skip(4).FirstOrDefault();
            lblBankProcess5.Text = bankProcess5.Description + " " + bankProcess5.Amount + " TL" + " " + bankProcess5.ProcessDate;

        }

        private void button4_Click(object sender, EventArgs e)
        {
            FrmDashBoard frm = new FrmDashBoard();
            frm.Show();
            this.Hide();

        }
    }
}
