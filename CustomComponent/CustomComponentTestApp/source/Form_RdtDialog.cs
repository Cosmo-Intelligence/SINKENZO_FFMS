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

namespace RADISTA.CustomComponentTestApp.source
{
    public partial class Form_RdtDialog : RdtDialog
    {
        private static int mCounter = 0;
        public Form_RdtDialog()
        {
            InitializeComponent();
            label_Count.Text = mCounter.ToString();
        }

        private void button_New_Delete_Click(object sender, EventArgs e)
        {
            Form_RdtDialog newForm = new Form_RdtDialog();
            // 位置を固定（生成破棄の度にズレ防止）
            newForm.StartPosition = FormStartPosition.Manual;
            newForm.Location = this.Location;
            newForm.Show();
            this.Close();
            mCounter++;
        }
    }
}
