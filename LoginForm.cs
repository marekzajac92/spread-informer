using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using pl.xtb.api.message.codes;
using pl.xtb.api.message.command;
using pl.xtb.api.message.records;
using pl.xtb.api.message.response;
using pl.xtb.api.streaming;
using pl.xtb.api.sync;

namespace SpreadInformer
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            XTBObjects.connector = new SyncAPIConnect(ServerData.DevelopmentServers["DEV"]);
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            ErrorLabel.Visible = false;
            try
            {
                BaseCommand loginCmd = APICommandFactory.createLoginCommand(long.Parse(Login.Text), Password.Text, false);
                string responseJSON = XTBObjects.connector.executeCommand(loginCmd.toJSONString());
                LoginResponse resp = new LoginResponse(responseJSON);
                StrList xyz = new StrList();
                XTBObjects.scnn = new StreamingAPIConnect(xyz, ServerData.DevelopmentServers["DEV"], resp);
            }
            catch (Exception ex)
            {
                ErrorLabel.Visible = true;
            }
        }
    }
}
