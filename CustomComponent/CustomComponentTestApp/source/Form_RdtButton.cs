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
    public partial class Form_RdtButton : Form
    {
        private static readonly ILog mLog = LogManager.GetLogger(typeof(Form_RdtButton));
        private int mCounter = 0;

        public Form_RdtButton()
        {
            InitializeComponent();
            this.AddLabelText();
        }

        private void AddLabelText()
        {
            #region デフォルト
            Label_FontType.Text += this.Button_Default.Font.Name;
            Label_FontSize.Text += this.Button_Default.Font.Size.ToString();
            Label_FontColor.Text += GetColorCode(this.Button_Default.ForeColor);
            Label_BackColor.Text += GetColorCode(this.Button_Default.BackColor);
            Label_InactiveColor.Text += GetColorCode(this.Button_Default.ForeColor);
            #endregion

            #region 拡張プロパティ

            //ボーダーカラー
            Label_Border_FF00FF.Text += this.Button_Border_FF00FF.OuterBorderColor;
            Label_Border_00FFFF.Text += this.Button_Border_00FFFF.OuterBorderColor;

            //ボーダーの太さ
            Label_BorderThick_1.Text += this.Button_BorderThick_1.BorderThick.ToString();
            Label_BorderThick_3.Text += this.Button_BorderThick_3.BorderThick.ToString();

            //内側ボーダーの色
            Label_InnerBorder_FF00FF.Text += this.Button_InnerBorder_FF00FF.InnerBorderColor;
            Label_InnerBorder_00FFFF.Text += this.Button_InnerBorder_00FFFF.InnerBorderColor;

            //ボーダー角度
            Label_BorderRadius_1.Text += this.Button_CornerRadius_1.CornerRadius.ToString();
            Label_CornerRadius_12.Text += this.Button_CornerRadius_12.CornerRadius.ToString();

            //テキストの向き
            Label_Orientation_Horizontal_NoImage.Text += this.Button_Orientation_Horizontal_NoImage.TextOrientation.ToString();
            Label_Orientation_DownWord.Text += this.Button_Orientation_DownWord_NoImage.TextOrientation.ToString();
            Label_Orientation_UpWord.Text += this.Button_Orientation_UpWord_NoImage.TextOrientation.ToString();
            Label_Orientation_Vertical.Text += this.Button_Vertical_NoImage.TextOrientation.ToString();

            //均等割り付け
            Label_TextJustify_H_None.Text += this.Button_TextJustify_H_None.TextJustify.ToString();
            Label_TextJustify_H_Justify.Text += this.Button_TextJustify_H_Justify.TextJustify.ToString();
            Label_TextJustify_H_WithSpace.Text += this.Button_TextJustify_H_WithSpace.TextJustify.ToString();
            Label_TextJustify_V_Justify.Text += this.Button_Justify_D_Justify.TextJustify.ToString();
            Label_TextJustify_V_WithSpace.Text += this.Button_Justift_D_WithSpace.TextJustify.ToString();
            Label_TextJustify_V_None.Text += this.Button_Justify_D_None.TextJustify.ToString();
            #endregion
        }

        private string GetColorCode(Color Color)
        {
            return $"#{Color.R:X2}{Color.G:X2}{Color.B:X2}";
        }

        private void Button_Test_Click(object sender, EventArgs e)
        {
            RdtButton? component = new RdtButton();

            component.ImageFilePath = "image\\TestImage.png";
            component.Location = this.Button_Test.Location;
            component.Location.Offset(0, this.Button_Test.Height * 2);

            this.Controls.Add(component);

            component.Dispose();
            component = null;

            mCounter++;
            this.Label_TestCount.Text = "回数 = " + mCounter.ToString();
        }
    }
}