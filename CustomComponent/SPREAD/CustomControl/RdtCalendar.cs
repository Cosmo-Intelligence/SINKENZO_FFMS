//-----------------------------------------------------------------------
// <copyright file="RdtCalendar.cs" company="FUJIFILM Medical Solutions Corporation">
// Copyright (C) 2025 FUJIFILM Medical Solutions Corporation.
// </copyright>
//-----------------------------------------------------------------------
using System.ComponentModel;

using log4net;

namespace RADISTA.SPREAD.CustomControl
{
    /// <summary>
    /// RdtCalendarクラス
    /// </summary>
    /// <remarks>
    /// 
    /// (Rev.)        (Date)      (ID / NAME)                     (Comment)
    /// V1.00.00    : 2025.05.01    : 株式会社コスモ・インテリジェンス / 藤原崇文   : original
    ///
    /// </remarks>
    public partial class RdtCalendar : MonthCalendar
    {
        #region "定数"
        private const int WM_PAINT = 0x000F;
        private const int WM_LBUTTONDOWN = 0x0201;
        #endregion

        #region "クラス変数"
        private static readonly ILog mLog = LogManager.GetLogger(typeof(RdtCalendar));
        private Panel mYearMonthPanel = new Panel();
        private ListBox mYearList = new ListBox();
        private ListBox mMonthList = new ListBox();
        #endregion

        #region "パブリックメソッド"
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public RdtCalendar()
        {
            this.InitializeComponent();

            this.InitializeCustomSetting();
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="container">コンテナ</param>
        public RdtCalendar(IContainer container)
        {
            container.Add(this);

            this.InitializeComponent();

            this.InitializeCustomSetting();
        }
        #endregion

        #region "プロテクティッドメソッド"
        /// <summary>
        /// OnCreateControl
        /// </summary>
        protected override void OnCreateControl()
        {
            base.OnCreateControl();

            if (this.DesignMode)
            {
                return;
            }

            this.DateSelected -= this.DateSelectedHandler;
            this.DateSelected += this.DateSelectedHandler;
        }

        /// <summary>
        /// WndProc
        /// </summary>
        /// <param name="m">メッセージ</param>
        protected override void WndProc(ref Message m)
        {
            // 左クリック
            if (m.Msg == WM_LBUTTONDOWN)
            {
                int y = (short)((m.LParam.ToInt32() >> 16) & 0xFFFF);

                if (y < this.Font.Height * 2)
                {
                    if (!this.mYearMonthPanel.Visible)
                    {
                        this.ShowYearMonthPanel();
                    }
                    else
                    {
                        this.mYearMonthPanel.Visible = false;
                    }
                    return;
                }
            }

            base.WndProc(ref m);

            // 描画
            if (m.Msg == WM_PAINT)
            {
                IntPtr hdc = NativeMethods.GetWindowDC(this.Handle);
                using (Graphics g = Graphics.FromHdc(hdc))
                {
                    // 左矢印を隠す
                    g.FillRectangle(new SolidBrush(ColorTranslator.FromHtml(ComponentCommon.GetCalendarDefaultTitleBackColor())), new Rectangle(5, 10, 35, 25));

                    // 右矢印を隠す（適切なサイズ調整が必要）
                    g.FillRectangle(new SolidBrush(ColorTranslator.FromHtml(ComponentCommon.GetCalendarDefaultTitleBackColor())), new Rectangle(this.Width - 40, 10, 35, 25));
                }
                NativeMethods.ReleaseDC(this.Handle, hdc);
            }
        }

        /// <summary>
        /// OnParentChanged
        /// </summary>
        /// <param name="e">イベント</param>
        protected override void OnParentChanged(EventArgs e)
        {
            base.OnParentChanged(e);

            if (this.Parent != null)
            {
                this.Parent.MouseDown -= this.ParentControl_MouseDown;
                this.Parent.MouseDown += this.ParentControl_MouseDown;

                if (!this.Parent.Controls.Contains(this.mYearMonthPanel))
                {
                    this.InitializeYearMonthPanel();
                }
            }
        }
        #endregion

        #region "プライベートメソッド"
        /// <summary>
        /// 初期化処理
        /// </summary>
        private void InitializeCustomSetting()
        {
            // クラシックスタイルを使用
            NativeMethods.SetWindowTheme(this.Handle, string.Empty, string.Empty);

            // デフォルト設定
            this.Size = new Size(250, 200);
            this.ForeColor = ColorTranslator.FromHtml(ComponentCommon.GetCalendarDefaultFontColor());
            this.BackColor = ColorTranslator.FromHtml(ComponentCommon.GetCalendarDefaultBackColor());
            this.TitleForeColor = ColorTranslator.FromHtml(ComponentCommon.GetCalendarDefaultTitleFontColor());
            this.TitleBackColor = ColorTranslator.FromHtml(ComponentCommon.GetCalendarDefaultTitleBackColor());
            this.TrailingForeColor = ColorTranslator.FromHtml(ComponentCommon.GetCalendarDefaultTrailingFontColor());
        }

        /// <summary>
        /// Dispose
        /// </summary>
        private void DisposeCustomSetting()
        {
            // イベント削除
            this.DateSelected -= this.DateSelectedHandler;
            this.mMonthList.SelectedIndexChanged -= this.MonthSelectionChanged;
            // 親コントロールのイベントを削除する
            if (this.Parent != null)
            {
                this.Parent.MouseDown -= this.ParentControl_MouseDown;
            }
        }

        /// <summary>
        /// 年月パネルの初期化
        /// </summary>
        private void InitializeYearMonthPanel()
        {
            // パネルの初期設定
            this.mYearMonthPanel.Size = new Size(this.Width, this.Height - (this.Font.Height * 2));
            this.mYearMonthPanel.BackColor = ColorTranslator.FromHtml(ComponentCommon.GetListDefaultStandardBackColor());
            this.mYearMonthPanel.BorderStyle = BorderStyle.FixedSingle;
            this.mYearMonthPanel.Visible = false;

            // 年月リストの初期設定
            this.mYearList.Dock = DockStyle.Fill;
            this.mMonthList.Dock = DockStyle.Fill;

            for (int year = this.SelectionStart.Year - 5; year <= this.SelectionStart.Year + 5; year++)
            {
                this.mYearList.Items.Add(year);
            }

            for (int month = 1; month <= 12; month++)
            {
                this.mMonthList.Items.Add(month);
            }

            this.mMonthList.SelectedIndexChanged -= this.MonthSelectionChanged;
            this.mMonthList.SelectedIndexChanged += this.MonthSelectionChanged;

            TableLayoutPanel table = new TableLayoutPanel
            {
                RowCount = 1,
                ColumnCount = 2,
                Dock = DockStyle.Fill,
                Padding = new Padding(5),
                BackColor = ColorTranslator.FromHtml(ComponentCommon.GetBackColor()),
            };

            table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            table.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));

            table.Controls.Add(this.mYearList, 0, 0);
            table.Controls.Add(this.mMonthList, 1, 0);

            this.mYearMonthPanel.Controls.Add(table);
            this.Parent?.Controls.Add(this.mYearMonthPanel);
        }

        /// <summary>
        /// 年月パネルの表示
        /// </summary>
        private void ShowYearMonthPanel()
        {
            if (this.Parent != null)
            {
                int year = this.SelectionStart.Year;
                int month = this.SelectionStart.Month;

                this.mYearList.SelectedItem = year;
                this.mMonthList.SelectedItem = month;

                Point screenLoc = this.PointToScreen(new Point(0, this.Font.Height * 2));
                Point parentLoc = this.Parent.PointToClient(screenLoc);
                this.mYearMonthPanel.Location = parentLoc;
                this.mYearMonthPanel.Visible = true;
                this.mYearMonthPanel.BringToFront();
            }
        }

        /// <summary>
        /// 親コントロールがクリックされた際のイベント
        /// </summary>
        /// <param name="sender">オブジェクト</param>
        /// <param name="e">イベント</param>
        private void ParentControl_MouseDown(object? sender, MouseEventArgs e)
        {
            if (this.Parent != null)
            {
                Point mousePos = this.Parent.PointToClient(Control.MousePosition);

                // カレンダー以外のクリック時はカレンダーを非表示
                if (!this.Bounds.Contains(mousePos))
                {
                    this.Visible = false;

                    // 年月パネルが表示している場合は同時に非表示
                    if (this.mYearMonthPanel.Visible && !this.mYearMonthPanel.Bounds.Contains(mousePos))
                    {
                        this.mYearMonthPanel.Visible = false;
                    }
                }
            }
        }

        /// <summary>
        /// 月リストの選択変更時のイベント
        /// </summary>
        /// <param name="sender">オブジェクト</param>
        /// <param name="e">イベント</param>
        private void MonthSelectionChanged(object? sender, EventArgs e)
        {
            if (this.mYearList.SelectedItem is int year && this.mMonthList.SelectedItem is int month)
            {
                var newDate = new DateTime(year, month, 1);
                this.SetDate(newDate);
                this.SelectionStart = newDate;
                this.SelectionEnd = newDate;
                this.mYearMonthPanel.Visible = false;
            }
        }

        /// <summary>
        /// 日付が選択された際のイベント
        /// </summary>
        /// <param name="sender">オブジェクト</param>
        /// <param name="e">イベント</param>
        private void DateSelectedHandler(object? sender, DateRangeEventArgs e)
        {
            this.Visible = false;
        }
        #endregion
    }
}
//---<<END OF FILE>>-----------------------------------------------------
