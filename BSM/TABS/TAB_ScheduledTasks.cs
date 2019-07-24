﻿using MetroFramework;
using System;
using System.Windows.Forms;

namespace Borealis
{
    public partial class TAB_SCHEDULEDTASKS : Form
    {
        public TAB_SCHEDULEDTASKS()
        {
            InitializeComponent();
        }

        private void btnBrowseDestination_Click(object sender, EventArgs e)
        {
            panelAddTask.Visible = true;
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            MetroMessageBox.Show(ActiveForm, "You have not chosen a task to remove.  Please select a task from the list below.", "No Scheduled Task Selected", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            MetroMessageBox.Show(ActiveForm, "You have not chosen a task to modify.  Please select a task from the list below.", "No Scheduled Task Selected", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnAddTask_Click(object sender, EventArgs e)
        {
            if (txtboxTaskName.Text == "" || txtboxCommand.Text == "" || txtboxRunTime.Text == "")
            {
                MetroMessageBox.Show(ActiveForm, "You have not filled out all required fields.", "Empty Field", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                tableScheduledTasks.Rows.Add(txtboxTaskName.Text, txtboxCommand.Text, txtboxRunTime.Text, switchEnabled.Value);
                txtboxTaskName.Text = txtboxCommand.Text = txtboxRunTime.Text = "";
                switchEnabled.Value = true;
                panelAddTask.Visible = false;
            }
        }

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
            txtboxTaskName.Text = txtboxCommand.Text = txtboxRunTime.Text = "";
            switchEnabled.Value = true;
            panelAddTask.Visible = false;
        }

        private void TAB_SCHEDULEDTASKS_Load(object sender, EventArgs e)
        {
            if (GameServerManagement.ServerCollection != null)
            {
                foreach (GameServerObject gameserver in GameServerManagement.ServerCollection)
                {
                    comboboxGameserverList.Items.Add(gameserver.SERVER_name_friendly);
                }
            }
        }
    }
}
