using log4net;
using RADISTA.UIComponent.CustomControl;

namespace RADISTA.CustomComponentTestApp
{
    public partial class Form_RdtRichTextBox : Form
    {
        private static readonly ILog mLog = LogManager.GetLogger(typeof(Form_Rdtlabel));
        private int mCounter = 0;

        public Form_RdtRichTextBox()
        {
            InitializeComponent();
        }

        private void Form_RdtRichTextBox_Load(object sender, EventArgs e)
        {
            label_FontType.Text = rdtRichTextBox_Default.Font.Name;
            label_FontSize.Text = rdtRichTextBox_Default.Font.Size.ToString();
            label_FontColor.Text = $"#{rdtRichTextBox_Default.ForeColor.R:X2}{rdtRichTextBox_Default.ForeColor.G:X2}{rdtRichTextBox_Default.ForeColor.B:X2}";
            label_BackColor.Text = $"#{rdtRichTextBox_Default.BackColor.R:X2}{rdtRichTextBox_Default.BackColor.G:X2}{rdtRichTextBox_Default.BackColor.B:X2}";
            label_BorderColor_1.Text = rdtRichTextBox_BorderColor1.BorderColor.ToString();
            label_Borderthick_1.Text = rdtRichTextBox_BorderThick1.BorderThick.ToString();
            label_BorderColor_2.Text = rdtRichTextBox_BorderColor2.BorderColor.ToString();
            label_Borderthick_2.Text = rdtRichTextBox_BorderThick2.BorderThick.ToString();
            label_FontColor_Inactive.Text = $"#{rdtRichTextBox_Inactive.ForeColor.R:X2}{rdtRichTextBox_Inactive.ForeColor.G:X2}{rdtRichTextBox_Inactive.ForeColor.B:X2}";
        }

        private void button_New_Delete_Click(object sender, EventArgs e)
        {
            RdtRichTextBox? component = new RdtRichTextBox();
            this.Controls.Add(component);

            this.Controls.Remove(component);
            component.Dispose();
            component = null;

            mCounter++;
            label_Count.Text = mCounter.ToString();
        }
    }
}
