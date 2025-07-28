using log4net;
using RADISTA.UIComponent.CustomControl;

namespace RADISTA.CustomComponentTestApp
{
    public partial class Form_RdtSpinBox : Form
    {
        private static readonly ILog mLog = LogManager.GetLogger(typeof(Form_Rdtlabel));
        private int mCounter = 0;

        public Form_RdtSpinBox()
        {
            InitializeComponent();
        }

        private void Form_RdtSpinBox_Load(object sender, EventArgs e)
        {
            label_FontType.Text = rdtSpinBox_Default.Font.Name;
            label_FontSize.Text = rdtSpinBox_Default.Font.Size.ToString();
            label_FontColor.Text = $"#{rdtSpinBox_Default.ForeColor.R:X2}{rdtSpinBox_Default.ForeColor.G:X2}{rdtSpinBox_Default.ForeColor.B:X2}";
            label_FontColor_Inactive.Text = $"#{rdtSpinBox_Inactive.ForeColor.R:X2}{rdtSpinBox_Inactive.ForeColor.G:X2}{rdtSpinBox_Inactive.ForeColor.B:X2}";
            label_BackColor.Text = $"#{rdtSpinBox_Default.BackColor.R:X2}{rdtSpinBox_Default.BackColor.G:X2}{rdtSpinBox_Default.BackColor.B:X2}";
            label_IsWrap_f.Text = rdtSpinBox_IsWrap_f.IsWrap.ToString();
            label_IsWrap_t.Text = rdtSpinBox_IsWrap_t.IsWrap.ToString();
        }

        private void button_New_Delete_Click(object sender, EventArgs e)
        {
            RdtSpinBox? component = new RdtSpinBox();
            this.Controls.Add(component);

            this.Controls.Remove(component);
            component.Dispose();
            component = null;

            mCounter++;
            label_Count.Text = mCounter.ToString();
        }
    }
}
