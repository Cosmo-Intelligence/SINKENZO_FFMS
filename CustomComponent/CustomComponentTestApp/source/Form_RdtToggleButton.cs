using log4net;
using RADISTA.UIComponent.CustomControl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RADISTA.CustomComponentTestApp
{
    public partial class Form_RdtToggleButton : Form
    {
        private static readonly ILog mLog = LogManager.GetLogger(typeof(Form_RdtButton));
        private int mCounter = 0;

        public Form_RdtToggleButton()
        {
            InitializeComponent();
            AddLabelText();
        }

        private void AddLabelText()
        {
            #region デフォルト
            Label_FontType.Text += this.Toggle_Default.Font.Name;
            Label_FontSize.Text += this.Toggle_Default.Font.Size.ToString();
            Label_FontColor.Text += GetColorCode(this.Toggle_Default.ForeColor);
            Label_BackColor.Text += GetColorCode(this.Toggle_Default.BackColor);
            Label_InactiveColor.Text += "#323232";
            #endregion

            #region 拡張プロパティ

            //ボーダーカラー
            Label_BorderColor_00FFFF.Text += this.Toggle_BorderColor_00FFFF.BorderColor;
            Label_BorderColor_FFFF00.Text += this.Toggle_BorderColor_FFFF00.BorderColor;

            //ボーダーの太さ
            Label_Thick_1.Text += this.Toggle_Thick_1.BorderThick.ToString();
            Label_Thick_3.Text += this.Toggle_Thick_3.BorderThick.ToString();
            
            #endregion
        }

        private string GetColorCode(Color Color)
        {
            return $"#{Color.R:X2}{Color.G:X2}{Color.B:X2}";
        }

        private void Toggle_Test_Click(object sender, EventArgs e)
        {
            RdtToggleButton? component = new RdtToggleButton();
            this.Controls.Add(component);

            this.Controls.Remove(component);
            component.Dispose();
            component = null;

            mCounter++;
            this.Label_TestCount.Text = "回数 = " + mCounter.ToString();
        }
    }
}
