using log4net;
using RADISTA.UIComponent.CustomControl;

namespace RADISTA.CustomComponentTestApp
{
    public partial class Form_RdtTextBox : Form
    {
        private static readonly ILog mLog = LogManager.GetLogger(typeof(Form_Rdtlabel));
        private int mCounter = 0;

        public Form_RdtTextBox()
        {
            InitializeComponent();
        }

        private void Form_RdtTextBox_Load(object sender, EventArgs e)
        {
            label_FontType.Text = rdtTextBox_Default.Font.Name;
            label_FontSize.Text = rdtTextBox_Default.Font.Size.ToString();
            label_FontColor.Text = $"#{rdtTextBox_Default.ForeColor.R:X2}{rdtTextBox_Default.ForeColor.G:X2}{rdtTextBox_Default.ForeColor.B:X2}";
            label_BackColor.Text = $"#{rdtTextBox_Default.BackColor.R:X2}{rdtTextBox_Default.BackColor.G:X2}{rdtTextBox_Default.BackColor.B:X2}";
            label_InactiveColor.Text = $"#{rdtTextBox_Inactive.ForeColor.R:X2}{rdtTextBox_Inactive.ForeColor.G:X2}{rdtTextBox_Inactive.ForeColor.B:X2}";
            label_BorderColor_1.Text = $"#{rdtTextBox_BorderColor_FF0000.ForeColor.R:X2}{rdtTextBox_BorderColor_FF0000.ForeColor.G:X2}{rdtTextBox_BorderColor_FF0000.ForeColor.B:X2}";
            label_BorderColor_2.Text = rdtTextBox_BorderColor_11111.BorderColor;
            label_BorderColor_3.Text = rdtTextBox_BorderColor_ffff00.BorderColor;
            label_ShowWaterMark.Text = rdtTextBox_Default.ShowWaterMark.ToString();
            label_Borderthick_0.Text = RdtTextBox_BorderThick_0.BorderThick.ToString();
            label_Borderthick_1.Text = RdtTextBox_BorderThick_1.BorderThick.ToString();
            label_Borderthick_5.Text = RdtTextBox_BorderThick_5.BorderThick.ToString();
            label_WaterMarkText.Text = RdtTextBox_WaterMarkText.WaterMarkText;
            label_WaterMarkFontColor.Text = RdtTextBox_WaterMarkFontColor.WaterMarkFontColor;
            label_ellipsis.Text = rdtTextBox_ellipsis.Text;
            label_Multiline1.Text = rdtTextBox_Multiline1.Multiline.ToString();
            label_Multiline1_borderThick.Text = rdtTextBox_Multiline1.BorderThick.ToString();
            label_Multiline2.Text = rdtTextBox_Multiline2.Multiline.ToString();
            label_Multiline2_borderThick.Text = rdtTextBox_Multiline2.BorderThick.ToString();
        }

        private void button_New_Delete_Click(object sender, EventArgs e)
        {
            RdtTextBox? component = new RdtTextBox();
            this.Controls.Add(component);

            this.Controls.Remove(component);
            component.Dispose();
            component = null;

            mCounter++;
            label_Count.Text = mCounter.ToString();
        }
    }
}
