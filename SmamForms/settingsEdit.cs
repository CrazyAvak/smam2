﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmamForms
{
    public partial class settingsEdit : Form
    {
        smamController smam;
        saveUserSettings settings;
        public settingsEdit()
        {
            InitializeComponent();
            CenterToScreen();
            this.BackColor = Color.FromArgb(248, 248, 248);
            setbackground();
            smam = new smamController();
            getSettings();
            labelTitel.Left = (this.ClientSize.Width - labelTitel.Width) / 2;
        }
        private void setbackground()
        {
            foreach (Control item in this.Controls)
            {
                item.BackColor = Color.FromArgb(248, 248, 248);
            }
        }
        private void getSettings()
        {
            settings = new saveUserSettings();
            userSetting userSettings = settings.getSettings();
            textBoxName.Text = userSettings.Name;
            numericUpDown1.Value = Convert.ToDecimal(userSettings.RentDay);
            textBoxCity.Text = userSettings.City;
            textBoxOpleiding.Text = userSettings.Education;
            textBoxSchool.Text = userSettings.School;
            textBoxStreet.Text = userSettings.Street;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            bool isFilledIn = true;
            foreach (Control item in this.Controls)
            {
                if (item is TextBox)
                {
                    if (string.IsNullOrEmpty(((TextBox)item).Text))
                    {
                        isFilledIn = false;
                    }
                }
            }
            if (isFilledIn == false)
            {
                MessageBox.Show("Niet alle velden zijn ingevuld");
            }
            else
            {
                settings.saveUser(textBoxName.Text, textBoxCity.Text, textBoxStreet.Text, textBoxSchool.Text, textBoxOpleiding.Text, numericUpDown1.Value.ToString());
                this.Close();
            }
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Drukte backbutton in");
            this.Hide();
        }


    }
}
