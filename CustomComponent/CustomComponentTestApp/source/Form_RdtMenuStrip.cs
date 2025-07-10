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
    public partial class Form_RdtMenuStrip : Form
    {
        private static readonly ILog mLog = LogManager.GetLogger(typeof(Form_RdtMenuStrip));
        private int mCounter = 0;
        private int mCounterMashing = 0;
        public Form_RdtMenuStrip()
        {
            InitializeComponent();
        }

        private void Form_RdtMenuStrip_Load(object sender, EventArgs e)
        {
            label_FontType.Text = rdtMenuStrip1.Font.Name;
            label_FontSize.Text = rdtMenuStrip1.Font.Size.ToString();
            label_FontColor.Text = rdtMenuStrip1.MenuForeColor;
            label_BackColor.Text = rdtMenuStrip1.MenuBackColor;
        }

        private void button_New_Delete_Click(object sender, EventArgs e)
        {
            RdtMenuStrip? component = new RdtMenuStrip();
            this.Controls.Add(component);

            this.Controls.Remove(component);
            component.Dispose();
            component = null;

            mCounter++;
            label_Count.Text = mCounter.ToString();
        }

        private void menu12ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mCounterMashing++;
            label_CountMashing.Text = mCounterMashing.ToString();
        }
    }
}
