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
    public partial class Form_RdtListButton : Form
    {
        int mCounter = 0;
        public Form_RdtListButton()
        {
            InitializeComponent();
            this.AddListItem();
        }

        private void AddListItem()
        {
            // リストボックス、コンボボックスにアイテムを100個追加
            for (int i = 0; i < 100; i++)
            {
                this.List_Under.AddItem($"アイテム{i + 1}");
                this.List_Upper.AddItem($"アイテム{i + 1}");
            }
            return;
        }

        private void Button_Test_Click(object sender, EventArgs e)
        {
            RdtListButton? component = new RdtListButton();

            this.Controls.Add(component);

            this.Controls.Remove(component);
            component.Dispose();
            component = null;

            mCounter++;
            this.Label_TestCount.Text = "回数 = " + mCounter.ToString();
        }
    }
}
