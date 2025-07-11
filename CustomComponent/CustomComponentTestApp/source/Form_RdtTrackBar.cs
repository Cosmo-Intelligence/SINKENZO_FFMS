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
    public partial class Form_RdtTrackBar : Form
    {
        private static readonly ILog mLog = LogManager.GetLogger(typeof(Form_Rdtlabel));
        private int mCounter = 0;

        public Form_RdtTrackBar()
        {
            InitializeComponent();
        }

        private void Form_RdtTrackBar_Load(object sender, EventArgs e)
        {
            label_FontType.Text = rdtTrackBar_Default.Font.Name;
            label_BackColor.Text = $"#{rdtTrackBar_Default.BackColor.R:X2}{rdtTrackBar_Default.BackColor.G:X2}{rdtTrackBar_Default.BackColor.B:X2}";
            label_IsincrementButton.Text = rdtTrackBar_Default.IsIncrementButton.ToString();
            label_TickTextStyle.Text = rdtTrackBar_Default.TicktextStyle.ToString();
            label_TickStep.Text = rdtTrackBar_Default.TickStep.ToString();

            label_IsincrementButton_t.Text = rdtTrackBar_IsIncrementButton.IsIncrementButton.ToString();
            label_TickTextStyle_None.Text = rdtTrackBar_TickTextStyle_None.TicktextStyle.ToString();
            label_TickTextStyle_TopLeft.Text = rdtTrackBar_TickTextStyle_TopLeft.TicktextStyle.ToString();
            label_TickTextStyle_BottomRight.Text = rdtTrackBar_TickTextStyle_BottomRight.TicktextStyle.ToString();
            label_TickTextStyle_Both.Text = rdtTrackBar_TickTextStyle_Both.TicktextStyle.ToString();

            label_TickStep_2.Text = rdtTrackBar_TickStep_2.TickStep.ToString();
            label_TickStep_5.Text = rdtTrackBar_TickStep_5.TickStep.ToString();
            label_TickStep_10.Text = rdtTrackBar_TickStep_10.TickStep.ToString();

            label_max_10.Text = rdtTrackBar_TickStep_2.Maximum.ToString();
            label_min_0.Text = rdtTrackBar_TickStep_2.Minimum.ToString();
            label_max_100.Text = rdtTrackBar_TickStep_10.Maximum.ToString();
            label_min_10.Text = rdtTrackBar_TickStep_10.Minimum.ToString();
            label_max_200.Text = rdtTrackBar_TickStep_5.Maximum.ToString();
            label_min_150.Text = rdtTrackBar_TickStep_5.Minimum.ToString();
        }

        private void button_New_Delete_Click(object sender, EventArgs e)
        {
            RdtTrackBar? component = new RdtTrackBar();
            this.Controls.Add(component);

            this.Controls.Remove(component);
            component.Dispose();
            component = null;

            mCounter++;
            label_Count.Text = mCounter.ToString();
        }
    }
}
