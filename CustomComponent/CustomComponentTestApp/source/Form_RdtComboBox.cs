using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CustomComponentTestApp.source
{
    public partial class Form_RdtComboBox : Form
    {
        public Form_RdtComboBox()
        {
            InitializeComponent();
            this.AddLabelText();
            this.AddListItem();
        }

        private void AddListItem()
        {
            // リストボックス、コンボボックスにアイテムを100個追加
            for (int i = 0; i < 100; i++)
            {
                Combo_Default.AddItem($"アイテム{i + 1}");
                Combo_Disable.AddItem($"アイテム{i + 1}");
                Combo_BorderColor.AddItem($"アイテム{i + 1}");
                Combo_BorderColor2.AddItem($"アイテム{i + 1}");
                Combo_BorderThick.AddItem($"アイテム{i + 1}");
                Combo_BorderThick_2.AddItem($"アイテム{i + 1}");
                Combo_PanelBackColor.AddItem($"アイテム{i + 1}");
                Combo_PanelBackColor_2.AddItem($"アイテム{i + 1}");
                Combo_PanelForeColor.AddItem($"アイテム{i + 1}");
                Combo_PanelForeColor_2.AddItem($"アイテム{i + 1}");
                Combo_ButtonBackColor.AddItem($"アイテム{i + 1}");
                Combo_ButtonBackColor_2.AddItem($"アイテム{i + 1}");
                Combo_DrawStyle.AddItem($"アイテム{i + 1}");
                Combo_DrawStyle_2.AddItem($"アイテム{i + 1}");
                Combo_DropDownHeight.AddItem($"アイテム{i + 1}");
                Combo_DropDownHeight_2.AddItem($"アイテム{i + 1}");
            }
            return;
        }

        private void AddLabelText()
        {
            #region デフォルト
            Label_FontType.Text += this.Combo_Default.Font.Name;
            Label_FontSize.Text += this.Combo_Default.Font.Size.ToString();
            Label_FontColor.Text += GetColorCode(this.Combo_Default.ForeColor);
            Label_BackColor.Text += GetColorCode(this.Combo_Default.BackColor);
            Label_InactiveBackColor.Text += this.GetColorCode(this.Combo_Disable.BackColor);
            Label_InactiveForeColor.Text += this.GetColorCode(this.Combo_Disable.ForeColor);
            #endregion

            #region 拡張プロパティ
            //ボーダーカラー
            this.Label_BorderColor.Text += this.Combo_BorderColor.BorderColor;
            this.Label_BorderColor_2.Text += this.Combo_BorderColor2.BorderColor;
            //ボーダー太さ
            this.Label_BorderThick.Text += this.Combo_BorderThick.BorderThick;
            this.Label_BorderThick_2.Text += this.Combo_BorderThick_2.BorderThick;
            //パネル背景色
            this.Label_PanelBackColor.Text += this.Combo_PanelBackColor.PanelBackColor;
            this.Label_PanelBackColor_2.Text += this.Combo_PanelBackColor_2.PanelBackColor;
            //パネル文字色
            this.Label_PanelForeColor.Text += this.Combo_PanelForeColor.PanelForeColor;
            this.Label_PanelForeColor_2.Text += this.Combo_PanelForeColor_2.PanelForeColor;
            //ボタン背景色
            this.Label_ButtonBackColor.Text += this.Combo_ButtonBackColor.ButtonBackColor;
            this.Label_ButtonBackColor_2.Text += this.Combo_ButtonBackColor_2.ButtonBackColor;
            //スタイル
            this.Label_DrawStyle.Text += this.Combo_DrawStyle.DrawStyle.ToString();
            this.Label_DrawStyle_2.Text += this.Combo_DrawStyle.DrawStyle.ToString();
            //ドロップダウンの高さ
            this.Label_DropDownHeight.Text += this.Combo_DropDownHeight.DropdownHeight.ToString();
            this.Label_DropDownHeight_2.Text += this.Combo_DropDownHeight_2.DropdownHeight.ToString();
            #endregion
        }

        private string GetColorCode(Color Color)
        {
            return $"#{Color.R:X2}{Color.G:X2}{Color.B:X2}";
        }
    }
}