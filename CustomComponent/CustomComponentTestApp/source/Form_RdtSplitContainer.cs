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
    public partial class Form_RdtSplitContainer : Form
    {
        private static readonly ILog mLog = LogManager.GetLogger(typeof(Form_RdtSplitContainer));
        private int mCounter = 0;
        public Form_RdtSplitContainer()
        {
            InitializeComponent();
        }

        private void Form_RdtSplitContainer_Load(object sender, EventArgs e)
        {
            label_BackColor.Text = $"#{rdtSplitContainer1.BackColor.R:X2}{rdtSplitContainer1.BackColor.G:X2}{rdtSplitContainer1.BackColor.B:X2}";
            // 取得する術が無いため直接取得
            label_ComponentEdgeColor.Text = ComponentCommon.GetComponentEdgeColor();
        }

        private void button_New_Delete_Click(object sender, EventArgs e)
        {
            RdtSplitContainer? component = new RdtSplitContainer();
            this.Controls.Add(component);

            this.Controls.Remove(component);
            component.Dispose();
            component = null;

            mCounter++;
            label_Count.Text = mCounter.ToString();
        }

    }
}
