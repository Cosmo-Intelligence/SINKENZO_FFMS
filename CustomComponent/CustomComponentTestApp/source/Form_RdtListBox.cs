using RADISTA.SPREAD.CustomControl;
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

namespace CustomComponentTestApp.source
{
    public partial class Form_RdtListBox : Form
    {
        private int mCounter = 0;

        public Form_RdtListBox()
        {
            InitializeComponent();
            this.AddListItem();
            this.AddLabelText();
        }

        private void AddListItem()
        {
            // リストボックス、コンボボックスにアイテムを100個追加
            for (int i = 0; i < 100; i++)
            {
                List_Border_2.AddItem($"アイテム{i + 1}");
                List_Border_1.AddItem($"アイテム{i + 1}");
                List_Alternate_False.AddItem($"アイテム{i + 1}");
                List_Alternate_True.AddItem($"アイテム{i + 1}");
                List_CellBackColor_1.AddItem($"アイテム{i + 1}");
                List_CellBackColor_2.AddItem($"アイテム{i + 1}");
                List_Default.AddItem($"アイテム{i + 1}");
                List_Disabled.AddItem($"アイテム{i + 1}");
                List_DrawStyle_F.AddItem($"アイテム{i + 1}");
                List_DrawStyle_S.AddItem($"アイテム{i + 1}");
                List_Hover_1.AddItem($"アイテム{i + 1}");
                List_Hover_2.AddItem($"アイテム{i + 1}");
                List_Radius_16.AddItem($"アイテム{i + 1}");
                List_Radius_8800.AddItem($"アイテム{i + 1}");
                List_SelectedRowData.AddItem($"アイテム{i + 1}");
                List_ForeColor_1.AddItem($"アイテム{i + 1}");
                List_ForeColor_2.AddItem($"アイテム{i + 1}");
            }
            return;
        }
        private void AddLabelText()
        {
            #region デフォルト
            Label_FontType.Text += this.List_Default.GetSheetFont().Name;
            Label_FontSize.Text += this.List_Default.GetSheetFont().Size.ToString();
            Label_FontColor.Text += List_Default.FontColor;
            Label_BackColor.Text += List_Default.CellBackColor;
            Label_InactiveBackColor.Text += List_Disabled.DisableBackColor;
            Label_InactiveForeColor.Text += List_Disabled.DisableForeColor;
            #endregion

            #region 拡張プロパティ

            //ボーダー
            Label_BorderThick_4.Text += this.List_Border_1.BorderThick;
            Label_BorderThick_8.Text += this.List_Border_2.BorderThick;
            Label_BorderColor_FF0000.Text += this.List_Border_1.BorderColor;
            Label_BorderColor_FF00FF.Text += this.List_Border_2.BorderColor;

            //Alternate
            Label_AlternateColor_True.Text = this.List_Alternate_True.AlternateColor;
            Label_UseAlternate_True.Text += this.List_Alternate_True.UseAlternateColor.ToString();
            Label_AlternateColor_False.Text += this.List_Alternate_False.AlternateColor;
            Label_UseAlternate_false.Text += this.List_Alternate_False.UseAlternateColor.ToString();

            //CornerRadius
            Label_LTRadius_8.Text += this.List_Radius_8800.LeftTopCornerRadius.ToString();
            Label_RTRadius_0.Text += this.List_Radius_8800.RightTopCornerRadius.ToString();
            Label_LBRadius_8.Text += this.List_Radius_8800.LeftBottomCornerRadius.ToString();
            Label_RBRadius_0.Text += this.List_Radius_8800.RightBottomCornerRadius.ToString();
            Label_LTRadius_16.Text += this.List_Radius_16.LeftTopCornerRadius.ToString();
            Label_RTRadius_16.Text += this.List_Radius_16.RightTopCornerRadius.ToString();
            Label_LBRadius_16.Text += this.List_Radius_16.LeftBottomCornerRadius.ToString();
            Label_RBRadius_16.Text += this.List_Radius_16.RightBottomCornerRadius.ToString();

            //Hover
            Label_Hover_1.Text += this.List_Hover_1.HoverBackColor;
            Label_Hover_2.Text += this.List_Hover_2.HoverBackColor;

            //Style
            Label_DrawStyle_S.Text += this.List_DrawStyle_S.DrawStyle.ToString();
            Label_DrawStyle_F.Text += this.List_DrawStyle_F.DrawStyle.ToString();

            //CellBackColor
            Label_CellBackColor_1.Text += this.List_CellBackColor_1.CellBackColor;
            Label_CellBackColor_2.Text += this.List_CellBackColor_2.CellBackColor;

            //FontColor
            Label_ForeColor_1.Text += this.List_ForeColor_1.FontColor;
            Label_ForeColor_2.Text += this.List_ForeColor_2.FontColor;

            //SelectedRowData
            Label_SelectedItem.Text += this.List_SelectedRowData.SelectedItem;
            Label_SelectedIndex.Text += this.List_SelectedRowData.SelectedIndex.ToString();
            #endregion
        }

        private void List_SelectedRowData_SelectionChanged(object sender, FarPoint.Win.Spread.SelectionChangedEventArgs e)
        {
            Label_SelectedItem.Text = $"SelectedItem = {this.List_SelectedRowData.SelectedItem}";
            Label_SelectedIndex.Text = $"SelectedIndex = {this.List_SelectedRowData.SelectedIndex.ToString()}";
        }

        private string GetColorCode(Color Color)
        {
            return $"#{Color.R:X2}{Color.G:X2}{Color.B:X2}";
        }

        private void Button_Test_Click(object sender, EventArgs e)
        {
            RdtListBox? component = new RdtListBox();

            this.Controls.Add(component);

            component.Dispose();
            component = null;

            mCounter++;
            this.Label_TestCount.Text = "回数 = " + mCounter.ToString();
        }
    }
}
