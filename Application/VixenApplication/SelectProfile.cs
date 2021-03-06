﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace VixenApplication
{
    public partial class SelectProfile : Form
    {
        string _dataFolder = "";

        public SelectProfile()
        {
            InitializeComponent();
        }

        public string DataFolder
        {
            get { return _dataFolder; }
            set { _dataFolder = value; }
        }            

        private void SelectProfile_Load(object sender, EventArgs e)
        {
            XMLProfileSettings profile = new XMLProfileSettings();

            int profileCount = profile.GetSetting("Profiles/ProfileCount", 0);
            for (int i = 0; i < profileCount; i++)
            {
                ProfileItem item = new ProfileItem();
                item.Name = profile.GetSetting("Profiles/" + "Profile" + i.ToString() + "/Name", "New Profile");
                item.DataFolder = profile.GetSetting("Profiles/" + "Profile" + i.ToString() + "/DataFolder", "");
                listBoxProfiles.Items.Add(item);
            }
        }

        private void listBoxProfiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadSelectedProfile();
        }

        private void buttonLoad_Click(object sender, EventArgs e)
        {
            LoadSelectedProfile();
        }

        private void LoadSelectedProfile()
        {
            if (listBoxProfiles.SelectedIndex >= 0)
            {
                ProfileItem item = listBoxProfiles.SelectedItem as ProfileItem;
                DataFolder = item.DataFolder;
                DialogResult = System.Windows.Forms.DialogResult.OK;
                Close();
            }
        }
    }
}
