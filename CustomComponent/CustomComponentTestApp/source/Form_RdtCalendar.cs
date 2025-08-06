using log4net;
using RADISTA.SPREAD.CustomControl;
using RADISTA.UIComponent.CustomControl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RADISTA.CustomComponentTestApp
{
    public partial class Form_RdtCalendar : Form
    {
        private static readonly ILog mLog = LogManager.GetLogger(typeof(Form_RdtCalendar));
        private int mCounter = 0;
        private int mCounterMashing = 0;
        public Form_RdtCalendar()
        {
            InitializeComponent();

            rdtCalendar1.DateSelected += Calendar_DateSelected;
            rdtCalendar1.Visible = false;
        }

        private void Form_RdtCalendar_Load(object sender, EventArgs e)
        {
            // ボタンに現在日付を設定（YYYY/MM/DD）
            button_Date.Text = DateTime.Now.ToString("yyyy/MM/dd");
        }

        private void button_Date_Click(object sender, EventArgs e)
        {
            // ボタンに表示されている日付をDateTimeに変換
            if (DateTime.TryParse(button_Date.Text, out DateTime selectedDate))
            {
                // カレンダーにその日付を反映
                rdtCalendar1.SetDate(selectedDate);
            }

            // カレンダーを表示
            rdtCalendar1.Visible = true;
        }

        private void Calendar_DateSelected(object sender, DateRangeEventArgs e)
        {
            // 選択された日付をボタンに設定（YYYY/MM/DD）
            button_Date.Text = e.Start.ToString("yyyy/MM/dd");

            mCounterMashing++;
            label_CountMashing.Text = mCounterMashing.ToString();
        }

        private void button_New_Delete_Click(object sender, EventArgs e)
        {
            RdtCalendar? component = new RdtCalendar();

            component.Dispose();
            component = null;

            mCounter++;
            label_Count.Text = mCounter.ToString();
        }
    }
}
