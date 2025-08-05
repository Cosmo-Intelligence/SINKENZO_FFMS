using log4net;
using RADISTA.UIComponent.CustomControl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RADISTA.CustomComponentTestApp
{
    public partial class Form_RdtContextMenuStrip : Form
    {
        private static readonly ILog mLog = LogManager.GetLogger(typeof(Form_RdtContextMenuStrip));
        private int mCounter = 0;
        private int mCountermMashing = 0;

        public Form_RdtContextMenuStrip()
        {
            InitializeComponent();
        }

        private void Form_RdtContextMenuStrip_Load(object sender, EventArgs e)
        {
            label_FontType.Text = rdtContextMenuStrip1.Font.Name;
            label_FontSize.Text = rdtContextMenuStrip1.Font.Size.ToString();
            label_FontColor.Text = rdtContextMenuStrip1.MenuForeColor;
            label_BackColor.Text = rdtContextMenuStrip1.MenuBackColor;
            label_HoverForeColor.Text = rdtContextMenuStrip1.MenuHoverForeColor;
            label_HoverBackColor.Text = rdtContextMenuStrip1.MenuHoverBackColor;
            label_DisableForeColor.Text = rdtContextMenuStrip1.MenuDisableForeColor;
            label_DisableBackColor.Text = rdtContextMenuStrip1.MenuDisableBackColor;
            label_CheckedForeColor.Text = rdtContextMenuStrip1.MenuCheckedForeColor;
            label_CheckedBackColor.Text = rdtContextMenuStrip1.MenuCheckedBackColor;
            label_CheckedHoverForeColor.Text = rdtContextMenuStrip1.MenuCheckedHoverForeColor;
            label_CheckedHoverBackColor.Text = rdtContextMenuStrip1.MenuCheckedHoverBackColor;
        }

        private void button_New_Delete_Click(object sender, EventArgs e)
        {
            RdtContextMenuStrip? component = new RdtContextMenuStrip();

            component.Dispose();
            component = null;

            mCounter++;
            label_Count.Text = mCounter.ToString();
        }

        private void menu3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mCountermMashing++;
            label_CountMashing.Text = mCountermMashing.ToString();
        }
    }
}
