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
    public partial class Form_RdtPanel : Form
    {
        private static readonly ILog mLog = LogManager.GetLogger(typeof(Form_RdtPanel));
        private int mCounter = 0;

        public Form_RdtPanel()
        {
            InitializeComponent();
        }

        private void Form_RdtPanel_Load(object sender, EventArgs e)
        {
            label_BackColor.Text = $"#{rdtPanel1.BackColor.R:X2}{rdtPanel1.BackColor.G:X2}{rdtPanel1.BackColor.B:X2}";
        }

        private void button_New_Delete_Click(object sender, EventArgs e)
        {
            RdtPanel? component = new RdtPanel();
            this.Controls.Add(component);

            this.Controls.Remove(component);
            component.Dispose();
            component = null;

            mCounter++;
            label_Count.Text = mCounter.ToString();
        }
    }
}
