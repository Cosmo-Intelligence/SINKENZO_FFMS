using log4net;
using RADISTA.UIComponent.CustomControl;

namespace RADISTA.CustomComponentTestApp
{
    public partial class Form_RdtProgressBar : Form
    {
        private static readonly ILog mLog = LogManager.GetLogger(typeof(Form_Rdtlabel));
        private int mCounter = 0;
        public Form_RdtProgressBar()
        {
            InitializeComponent();
        }

        
        private void Form_RdtProgressBar_Load(object sender, EventArgs e)
        {
            label_fontType.Text = rdtProgressBar_Default.Font.Name;
            label_fontSize.Text = rdtProgressBar_Default.Font.Size.ToString();
            label_showText_default.Text = rdtProgressBar_Default.ShowText.ToString();
            label_progressColor.Text = rdtProgressBar_Default.ProgressColor.ToString();
            label_backgroundColor.Text = rdtProgressBar_Default.BackgroundColor.ToString();
            label_showText_false.Text = rdtProgressBar_showTextFalse.ShowText.ToString();
            label_showText_false_value.Text = rdtProgressBar_showTextFalse.Value.ToString();
            label_showText_true.Text = rdtProgressBar_showTextTrue.ShowText.ToString();
            label_showText_true_value.Text = rdtProgressBar_showTextTrue.Value.ToString();

            label_showtext1_f.Text = rdtProgressBar_color1_f.ShowText.ToString();
            label_progressColor1.Text = rdtProgressBar_color1_f.ProgressColor.ToString();
            label_backgroundcolor1.Text = rdtProgressBar_color1_f.BackgroundColor.ToString();
            label_value1.Text = rdtProgressBar_color1_f.Value.ToString();
            label_showtext1_t.Text = rdtProgressBar_color1_t.ShowText.ToString();

            label_showtext2_f.Text = rdtProgressBar_color2_f.ShowText.ToString();
            label_progressColor2.Text = rdtProgressBar_color2_f.ProgressColor.ToString();
            label_backgroundcolor2.Text = rdtProgressBar_color2_f.BackgroundColor.ToString();
            label_value2.Text = rdtProgressBar_color2_f.Value.ToString();
            label_showtext2_t.Text = rdtProgressBar_color2_t.ShowText.ToString();

            label_showtext3_f.Text = rdtProgressBar_color3_f.ShowText.ToString();
            label_progressColor3.Text = rdtProgressBar_color3_f.ProgressColor.ToString();
            label_backgroundcolor3.Text = rdtProgressBar_color3_f.BackgroundColor.ToString();
            label_value3.Text = rdtProgressBar_color3_f.Value.ToString();
            label_showtext3_t.Text = rdtProgressBar_color3_t.ShowText.ToString();
        }

        private void button_New_Delete_Click(object sender, EventArgs e)
        {
            RdtProgressBar? component = new RdtProgressBar();
            this.Controls.Add(component);

            this.Controls.Remove(component);
            component.Dispose();
            component = null;

            mCounter++;
            label_Count.Text = mCounter.ToString();
        }
    }
}
