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
    public partial class Form_Rdtlabel : Form
    {
        private static readonly ILog mLog = LogManager.GetLogger(typeof(Form_Rdtlabel));
        private int mCounter = 0;

        public Form_Rdtlabel()
        {
            InitializeComponent();
        }

        private void Form_Rdtlabel_Load(object sender, EventArgs e)
        {
            label_FontType.Text = rdtLabel_Default.Font.Name;
            label_FontSize.Text = rdtLabel_Default.Font.Size.ToString();
            label_FontColor.Text = $"#{rdtLabel_Default.ForeColor.R:X2}{rdtLabel_Default.ForeColor.G:X2}{rdtLabel_Default.ForeColor.B:X2}";
            label_BackColor.Text = $"#{rdtLabel_Default.BackColor.R:X2}{rdtLabel_Default.BackColor.G:X2}{rdtLabel_Default.BackColor.B:X2}";
            label_InactiveColor.Text = $"#{rdtLabel_Inactive.ForeColor.R:X2}{rdtLabel_Inactive.ForeColor.G:X2}{rdtLabel_Inactive.ForeColor.B:X2}";
            label_BlinkFontColor_1.Text = rdtLabel_BlinkFontColor_FFFFFF.BlinkFontColor;
            label_BlinkBackColor_1.Text = rdtLabel_BlinkBackColor_FF0000.BlinkBackColor;
            label_BorderColor_1.Text = rdtLabel_BorderColor_FF0000.BorderColor;
        }

        private void button_StartBlink_Click(object sender, EventArgs e)
        {
            rdtLabel_IsBlink_True.StartBlink();
            rdtLabel_IsBlink_False.StartBlink();
            rdtLabel_BlinkInterval_1.StartBlink();
            rdtLabel_BlinkInterval_5.StartBlink();
            rdtLabel_BlinkFontColor_FFFFFF.StartBlink();
            rdtLabel_BlinkBackColor_FF0000.StartBlink();
        }

        private void button_StopBlink_Click(object sender, EventArgs e)
        {
            rdtLabel_IsBlink_True.StopBlink();
            rdtLabel_IsBlink_False.StopBlink();
            rdtLabel_BlinkInterval_1.StopBlink();
            rdtLabel_BlinkInterval_5.StopBlink();
            rdtLabel_BlinkFontColor_FFFFFF.StopBlink();
            rdtLabel_BlinkBackColor_FF0000.StopBlink();
        }

        private void button_New_Delete_Click(object sender, EventArgs e)
        {
            RdtLabel? component = new RdtLabel();
            this.Controls.Add(component);

            this.Controls.Remove(component);
            component.Dispose();
            component = null;

            mCounter++;
            label_Count.Text = mCounter.ToString();
        }
    }
}
