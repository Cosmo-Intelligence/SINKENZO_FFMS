using RADISTA.UIComponent.CustomControl;

namespace RADISTA.CustomComponentTestApp
{
    public partial class Form_RdtForm : RdtForm
    {
        private static int mCounter = 0;
        private string default_text = string.Empty;
        private TitlePositionT default_position;
        private string default_font_color = string.Empty;
        private string default_back_color = string.Empty;
        public Form_RdtForm()
        {
            InitializeComponent();

            default_text = Text;
            default_position = TitlePosition;
            default_font_color = TitleFontColor;
            default_back_color = TitleBackColor;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Text = "左揃えのタイトル";
            this.TitlePosition = TitlePositionT.Left;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Text = "中央揃えのタイトル";
            this.TitlePosition = TitlePositionT.Center;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Text = "右揃えのタイトル";
            this.TitlePosition = TitlePositionT.Right;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Text = default_text;
            this.TitlePosition = default_position;
            this.TitleFontColor = default_font_color;
            this.TitleBackColor = default_back_color;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.TitleBackColor = "#ff0000";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.TitleFontColor = "#000000";
        }

        private void Form_RdtForm_Load(object sender, EventArgs e)
        {
            label_FontType.Text = this.Font.Name;
            label_FontSize.Text = this.Font.Size.ToString();
            label_FontColor.Text = $"#{this.ForeColor.R:X2}{this.ForeColor.G:X2}{this.ForeColor.B:X2}";
            label_BackColor.Text = $"#{this.BackColor.R:X2}{this.BackColor.G:X2}{this.BackColor.B:X2}";
            label_Count.Text = mCounter.ToString();
        }


        private void button7_Click(object sender, EventArgs e)
        {
            this.TitleBackColor = "#0000ff";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.TitleFontColor = "#ffff00";
        }

        private void button_New_Delete_Click(object sender, EventArgs e)
        {
            Form_RdtForm newForm = new Form_RdtForm();
            // 位置を固定（生成破棄の度にズレ防止）
            newForm.StartPosition = FormStartPosition.Manual;
            newForm.Location = this.Location;
            newForm.Show();
            this.Close();
            mCounter++;
        }
    }
}