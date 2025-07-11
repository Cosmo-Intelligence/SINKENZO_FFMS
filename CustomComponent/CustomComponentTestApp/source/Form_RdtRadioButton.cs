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

namespace CustomComponentTestApp
{
    public partial class Form_RdtRadioButton : Form
    {
        private static readonly ILog mLog = LogManager.GetLogger(typeof(Form_RdtButton));
        private int mCounter = 0;

        public Form_RdtRadioButton()
        {
            InitializeComponent();
            AddLabelText();
        }

        private void AddLabelText()
        {
            #region デフォルト
            Label_FontType.Text += this.Radio_Default.Font.Name;
            Label_FontSize.Text += this.Radio_Default.Font.Size.ToString();
            Label_FontColor.Text += GetColorCode(this.Radio_Default.ForeColor);
            Label_BackColor.Text += GetColorCode(this.Radio_Default.BackColor);
            Label_InactiveColor.Text += "#323232";
            #endregion

            #region 拡張プロパティ
            //カスタムイメージ
            Label_UseCustomImage_true.Text += this.Radio_UseCustomImage_true.UseCustomImage.ToString();
            Label_UseCustomImage_false.Text += this.Radio_UseCustomImage_false.UseCustomImage.ToString();
            #endregion
        }

        private string GetColorCode(Color Color)
        {
            return $"#{Color.R:X2}{Color.G:X2}{Color.B:X2}";
        }

        private void Button_Test_Click(object sender, EventArgs e)
        {
            RdtRadioButton? component = new RdtRadioButton();

            component.CheckedImagePath = "image\\TestImage.png";
            component.UncheckedImagePath = "image\\TestImage.png";

            this.Controls.Add(component);

            this.Controls.Remove(component);
            component.Dispose();
            component = null;

            mCounter++;
            this.Label_TestCount.Text = "回数 = " + mCounter.ToString();
        }
    }
}
