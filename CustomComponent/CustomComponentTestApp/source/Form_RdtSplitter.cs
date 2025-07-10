using log4net;
using RADISTA.UIComponent.CustomControl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RADISTA.CustomComponentTestApp
{
    public partial class Form_RdtSplitter : Form
    {
        private static readonly ILog mLog = LogManager.GetLogger(typeof(Form_RdtSplitter));
        private int mCounter = 0;

        private RdtSplitter mSplitter;

        public Form_RdtSplitter()
        {
            InitializeComponent();

            // 確認用のパネルとスプリッターを生成
            Panel panel1 = new Panel();
            panel1.Dock = DockStyle.Left;
            Panel panel2 = new Panel();
            panel2.Dock = DockStyle.Fill;
            mSplitter = new RdtSplitter();
            mSplitter.Dock = DockStyle.Left;

            this.Controls.Add(panel2);
            this.Controls.Add(mSplitter);
            this.Controls.Add(panel1);
        }

        private void Form_RdtSplitter_Load(object sender, EventArgs e)
        {
            label_ComponentEdgeColor.Text = $"#{mSplitter.BackColor.R:X2}{mSplitter.BackColor.G:X2}{mSplitter.BackColor.B:X2}";
        }

        private void button_New_Delete_Click(object sender, EventArgs e)
        {
            RdtSplitter? component = new RdtSplitter();
            this.Controls.Add(component);

            this.Controls.Remove(component);
            component.Dispose();
            component = null;

            mCounter++;
            label_Count.Text = mCounter.ToString();
        }
    }
}
