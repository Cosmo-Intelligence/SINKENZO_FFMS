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
using static System.Net.Mime.MediaTypeNames;

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

            rdtCalendar_Default.DateSelected += Calendar_Default_DateSelected;
            rdtCalendar_Default.Visible = false;
            rdtCalendar_IsDisplayYearMonthList_true.DateSelected += Calendar_IsDisplayYearMonthList_true_DateSelected;
            rdtCalendar_IsDisplayYearMonthList_true.Visible = false;
            rdtCalendar_IsDisplayYearMonthList_false.DateSelected += Calendar_IsDisplayYearMonthList_false_DateSelected;
            rdtCalendar_IsDisplayYearMonthList_false.Visible = false;
            rdtCalendar_IsStartMonday_true.DateSelected += Calendar_IsIsStartMonday_true_DateSelected;
            rdtCalendar_IsStartMonday_true.Visible = false;
            rdtCalendar_IsStartMonday_false.DateSelected += Calendar_IsIsStartMonday_false_DateSelected;
            rdtCalendar_IsStartMonday_false.Visible = false;
        }

        private void DisposeCustomSetting()
        {
            rdtCalendar_Default.DateSelected -= Calendar_Default_DateSelected;
            rdtCalendar_IsDisplayYearMonthList_true.DateSelected -= Calendar_IsDisplayYearMonthList_true_DateSelected;
            rdtCalendar_IsDisplayYearMonthList_false.DateSelected -= Calendar_IsDisplayYearMonthList_false_DateSelected;
            rdtCalendar_IsStartMonday_true.DateSelected -= Calendar_IsIsStartMonday_true_DateSelected;
            rdtCalendar_IsStartMonday_false.DateSelected -= Calendar_IsIsStartMonday_false_DateSelected;
        }

        private void Form_RdtCalendar_Load(object sender, EventArgs e)
        {
            label_FontColor.Text = $"#{rdtCalendar_Default.ForeColor.R:X2}{rdtCalendar_Default.ForeColor.G:X2}{rdtCalendar_Default.ForeColor.B:X2}";
            label_BackColor.Text = $"#{rdtCalendar_Default.BackColor.R:X2}{rdtCalendar_Default.BackColor.G:X2}{rdtCalendar_Default.BackColor.B:X2}";
            label_TitleForeColor.Text = $"#{rdtCalendar_Default.TitleForeColor.R:X2}{rdtCalendar_Default.TitleForeColor.G:X2}{rdtCalendar_Default.TitleForeColor.B:X2}";
            label_TitleBackColor.Text = $"#{rdtCalendar_Default.TitleBackColor.R:X2}{rdtCalendar_Default.TitleBackColor.G:X2}{rdtCalendar_Default.TitleBackColor.B:X2}";
            label_TrailingForeColor.Text = $"#{rdtCalendar_Default.TrailingForeColor.R:X2}{rdtCalendar_Default.TrailingForeColor.G:X2}{rdtCalendar_Default.TrailingForeColor.B:X2}";

            // ボタンに現在日付を設定（YYYY/MM/DD）
            button_Date_Default.Text = DateTime.Now.ToString("yyyy/MM/dd");
            button_IsDisplayYearMonthList_true.Text = DateTime.Now.ToString("yyyy/MM/dd");
            button_IsDisplayYearMonthList_false.Text = DateTime.Now.ToString("yyyy/MM/dd");
            button_IsStartMonday_true.Text = DateTime.Now.ToString("yyyy/MM/dd");
            button_IsStartMonday_false.Text = DateTime.Now.ToString("yyyy/MM/dd");
        }

        private void button_Date_DefaultClick(object sender, EventArgs e)
        {
            // ボタンに表示されている日付をDateTimeに変換
            if (DateTime.TryParse(button_Date_Default.Text, out DateTime selectedDate))
            {
                // カレンダーにその日付を反映
                rdtCalendar_Default.SetDate(selectedDate);
            }
            // カレンダーを表示
            rdtCalendar_Default.Visible = true;
        }

        private void button_IsDisplayYearMonthList_true_Click(object sender, EventArgs e)
        {
            if (DateTime.TryParse(button_IsDisplayYearMonthList_true.Text, out DateTime selectedDate))
            {
                rdtCalendar_IsDisplayYearMonthList_true.SetDate(selectedDate);
            }
            rdtCalendar_IsDisplayYearMonthList_true.Visible = true;
        }

        private void button_IsDisplayYearMonthList_false_Click(object sender, EventArgs e)
        {
            if (DateTime.TryParse(button_IsDisplayYearMonthList_false.Text, out DateTime selectedDate))
            {
                rdtCalendar_IsDisplayYearMonthList_false.SetDate(selectedDate);
            }
            rdtCalendar_IsDisplayYearMonthList_false.Visible = true;
        }

        private void button_IsStartMonday_true_Click(object sender, EventArgs e)
        {
            if (DateTime.TryParse(button_IsStartMonday_true.Text, out DateTime selectedDate))
            {
                rdtCalendar_IsStartMonday_true.SetDate(selectedDate);
            }
            rdtCalendar_IsStartMonday_true.Visible = true;
        }

        private void button_IsStartMonday_false_Click(object sender, EventArgs e)
        {
            if (DateTime.TryParse(button_IsStartMonday_false.Text, out DateTime selectedDate))
            {
                rdtCalendar_IsStartMonday_false.SetDate(selectedDate);
            }
            rdtCalendar_IsStartMonday_false.Visible = true;
        }

        private void Calendar_Default_DateSelected(object sender, DateRangeEventArgs e)
        {
            // 選択された日付をボタンに設定（YYYY/MM/DD）
            button_Date_Default.Text = e.Start.ToString("yyyy/MM/dd");

            mCounterMashing++;
            label_CountMashing.Text = mCounterMashing.ToString();
        }

        private void Calendar_IsDisplayYearMonthList_true_DateSelected(object sender, DateRangeEventArgs e)
        {
            button_IsDisplayYearMonthList_true.Text = e.Start.ToString("yyyy/MM/dd");
        }

        private void Calendar_IsDisplayYearMonthList_false_DateSelected(object sender, DateRangeEventArgs e)
        {
            button_IsDisplayYearMonthList_false.Text = e.Start.ToString("yyyy/MM/dd");
        }

        private void Calendar_IsIsStartMonday_true_DateSelected(object sender, DateRangeEventArgs e)
        {
            button_IsStartMonday_true.Text = e.Start.ToString("yyyy/MM/dd");
        }

        private void Calendar_IsIsStartMonday_false_DateSelected(object sender, DateRangeEventArgs e)
        {
            button_IsStartMonday_false.Text = e.Start.ToString("yyyy/MM/dd");
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
