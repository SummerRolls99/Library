﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace Jeler_Andrei_Biblioteca
{
    public partial class Conectare_admin : Form
    {
        OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Biblioteca.accdb");

        public Conectare_admin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string utilizator, passw;
            utilizator = user.Text;
            passw = pass.Text;
            bool aute = false;
            try
            {
                con.Open();
                OleDbCommand comUtiliz = new OleDbCommand("select * from Admini", con);
                OleDbDataAdapter adapt = new OleDbDataAdapter(comUtiliz);
                DataTable utiliz = new DataTable();
                adapt.Fill(utiliz);
                foreach (DataRow r in utiliz.Rows)
                    if (r["usern"].ToString() == utilizator && r["pass"].ToString() == passw)
                    {
                        Start.id_admin = Convert.ToInt32(r["id"]);
                        aute = true;
                        MessageBox.Show("Autentificare reusita.");
                        Start.nume = Convert.ToString(r["nume"]) + " " + Convert.ToString(r["prenume"]);
                    }
                if (aute == false)
                {
                    Start.id_admin = -1;
                    MessageBox.Show("Autentificare esuata.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            con.Close();
            this.Close();
        }
    }
}
