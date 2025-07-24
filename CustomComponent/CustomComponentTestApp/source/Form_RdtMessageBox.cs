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
using static RADISTA.UIComponent.CustomControl.RdtMessageBox;

namespace RADISTA.CustomComponentTestApp.source
{
    public partial class Form_RdtMessageBox : RdtMessageBox
    {
        private static int mCounter = 0;
        public Form_RdtMessageBox()
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.IconStyle = IconStyleT.Information;
        }

        private void button_Question_Click(object sender, EventArgs e)
        {
            this.IconStyle = IconStyleT.Question;
        }

        private void button_Warn_Click(object sender, EventArgs e)
        {
            this.IconStyle = IconStyleT.Warning;
        }

        private void button_Error_Click(object sender, EventArgs e)
        {
            this.IconStyle = IconStyleT.Error;
        }

        private void button_None_Click(object sender, EventArgs e)
        {
            this.ButtonType = ButtonTypeT.None;
        }

        private void button_Ok_Click(object sender, EventArgs e)
        {
            this.ButtonType = ButtonTypeT.OK;
        }

        private void button_OC_Click(object sender, EventArgs e)
        {
            this.ButtonType = ButtonTypeT.OKCancel;
        }

        private void button_YNC_Click(object sender, EventArgs e)
        {
            this.ButtonType = ButtonTypeT.YesNoCancel;
        }

        private void Form_RdtMessageBox_Load(object sender, EventArgs e)
        {
            label_AutoCloseMs.Text = this.AutoCloseMs.ToString();

            if (AutoCloseMs == 0) label_closetime.Text = "自動クローズOFFです。";
            else label_closetime.Text = (AutoCloseMs / 1000).ToString() + "秒後にクローズします。";
            label_Count.Text = mCounter.ToString();
            label_PositionMode.Text = this.PositionMode.ToString();

            if (PositionMode == PositionModeT.Combination)
            {
                label_Location.Text = "{x=" + MessagePosition_HorizontalAlign.ToString() + ",y=" + MessagePosition_VerticalAlign.ToString() + "}";
            }
            else if (PositionMode == PositionModeT.Absolute)
            {
                label_Location.Text = this.MessagePosition_Absolute.ToString();
            }
            else
            {
                label_Location.Text = this.MessagePosition_Relative.ToString();
            }
        }

        private void button_left_x_Click(object sender, EventArgs e)
        {
            this.MessagePosition_HorizontalAlign = HorizontalAlign.Left;
        }

        private void button_center_x_Click(object sender, EventArgs e)
        {
            this.MessagePosition_HorizontalAlign = HorizontalAlign.Center;
        }

        private void button_right_x_Click(object sender, EventArgs e)
        {
            this.MessagePosition_HorizontalAlign = HorizontalAlign.Right;
        }

        private void button_top_y_Click(object sender, EventArgs e)
        {
            this.MessagePosition_VerticalAlign = VerticalAlign.Top;
        }

        private void button_center_y_Click(object sender, EventArgs e)
        {
            this.MessagePosition_VerticalAlign = VerticalAlign.Center;
        }

        private void button_buttom_y_Click(object sender, EventArgs e)
        {
            this.MessagePosition_VerticalAlign = VerticalAlign.Bottom;
        }

        private void button_New_Delete_Click(object sender, EventArgs e)
        {
            Form_RdtMessageBox newForm = new Form_RdtMessageBox();
            // 位置を固定（生成破棄の度にズレ防止）
            this.Hide(); // Dispose()防止
            newForm.Show();
            this.Close();
            mCounter++;
        }
    }
}
