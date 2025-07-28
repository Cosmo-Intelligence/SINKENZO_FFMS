using log4net;
using RADISTA.UIComponent.CustomControl;

namespace RADISTA.CustomComponentTestApp
{
    public partial class Form_RdtMaskTextBox : Form
    {
        private static readonly ILog mLog = LogManager.GetLogger(typeof(Form_Rdtlabel));
        private int mCounter = 0;

        public Form_RdtMaskTextBox()
        {
            InitializeComponent();
        }

        private void Form_RdtMaskTextBox_Load(object sender, EventArgs e)
        {
            label_FontType.Text = rdtMaskTextBox_Default.Font.Name;
            label_FontSize.Text = rdtMaskTextBox_Default.Font.Size.ToString();
            label_FontColor.Text = $"#{rdtMaskTextBox_Default.ForeColor.R:X2}{rdtMaskTextBox_Default.ForeColor.G:X2}{rdtMaskTextBox_Default.ForeColor.B:X2}";
            label_BackColor.Text = $"#{rdtMaskTextBox_Default.BackColor.R:X2}{rdtMaskTextBox_Default.BackColor.G:X2}{rdtMaskTextBox_Default.BackColor.B:X2}";
            
            label_FontColor_Inactive.Text = $"#{rdtMaskTextBox_Inactive.ForeColor.R:X2}{rdtMaskTextBox_Inactive.ForeColor.G:X2}{rdtMaskTextBox_Inactive.ForeColor.B:X2}";

            label_BorderColor_1.Text = rdtMaskTextBox_BorderColor1.BorderColor;
            label_BorderColor_2.Text = rdtMaskTextBox_BorderColor2.BorderColor;
            label_Borderthick_1.Text = rdtMaskTextBox_Thick1.BorderThick.ToString();
            label_Borderthick_2.Text = rdtMaskTextBox_Thick2.BorderThick.ToString();


            label_Text_Hide.Text = rdtMaskTextBox_Hide.Text;
            label_Text_Show.Text = rdtMaskTextBox_Show.Text;
            // Toggleクリック処理
            rdtMaskTextBox_Show.TogglePassword();
            label_password_t.Text = rdtMaskTextBox_Hide.UseSystemPasswordChar.ToString();
            label_password_f.Text = rdtMaskTextBox_Show.UseSystemPasswordChar.ToString();
        }

        private void button_New_Delete_Click(object sender, EventArgs e)
        {
            RdtMaskTextBox? component = new RdtMaskTextBox();
            this.Controls.Add(component);

            this.Controls.Remove(component);
            component.Dispose();
            component = null;

            mCounter++;
            label_Count.Text = mCounter.ToString();
        }

    }
}
