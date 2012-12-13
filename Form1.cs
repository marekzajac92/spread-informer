using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms; 

namespace SpreadInformer
{
    public partial class Form1 : Form
    {
        Graph g;
        Graphics graphic;
        public Form1()
        {
            InitializeComponent();
            g = new Graph();
            double[] p = new double[5];
            p[0] = 1.000;
            p[1] = 1.505;
            p[2] = 3.010;
            p[3] = 2.500;
            p[4] = 2.650;
            g.SetPoints(p);
            label1.Text = (((p[0] - p[0]) / (p[2] - p[0]) * (-(this.Height - 40))) + ((this.Height - 40) - 20)).ToString();
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            graphic = this.CreateGraphics();
            graphic.Clear(Color.Black);
            g.DrawGraph(graphic, this.Width, this.Height);
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            graphic = this.CreateGraphics();
            graphic.Clear(Color.Black);
            g.DrawGraph(graphic, this.Width, this.Height);
        }
    }
}
