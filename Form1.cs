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
    public partial class Form1 : Form
    {
        Graph g;
        Graphics graphic;
        public Form1()
        {
            InitializeComponent();

            SyncAPIConnect conn = new SyncAPIConnect(ServerData.DevelopmentServers["DEV"]);

            BaseCommand loginCmd = APICommandFactory.createLoginCommand(101195, "uul6rxe", false);
            string responseJSON = conn.executeCommand(loginCmd.toJSONString());
            LoginResponse resp = new LoginResponse(responseJSON);

            CurrentUserDataResponse ud = APICommandFactory.executeCurrentUserDataCommand(conn, false);

            label1.Text = ud.Currency;
        }
    }
}
