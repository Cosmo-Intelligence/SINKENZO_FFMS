//-----------------------------------------------------------------------
// <copyright file="RdtCalendar.cs" company="FUJIFILM Medical Solutions Corporation">
// Copyright (C) 2025 FUJIFILM Medical Solutions Corporation.
// </copyright>
//-----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        #region "クラス変数"
        private static readonly ILog mLog = LogManager.GetLogger(typeof(RdtCalendar));
        private Control? mParentControl;
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
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="container">コンテナ</param>
        public RdtCalendar(IContainer container)
        {
            container.Add(this);

            this.InitializeComponent();
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

            this.InitializeYearMonthPanel();

            this.mParentControl = this.Parent;

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
            const int WM_LBUTTONDOWN = 0x0201;

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
        }

        /// <summary>
        /// OnHandleCreated
        /// </summary>
        /// <param name="e">イベント</param>
        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);

            if (this.mParentControl != null)
            {
                this.mParentControl.MouseDown -= this.ParentControl_MouseDown;
                this.mParentControl.MouseDown += this.ParentControl_MouseDown;
            }
        }
        #endregion

        #region "プライベートメソッド"
        /// <summary>
        /// Dispose
        /// </summary>
        private void DisposeCustomSetting()
        {
            // イベント削除
            this.DateSelected -= this.DateSelectedHandler;
            // 親コントロールのイベントを削除する
            if (this.mParentControl != null)
            {
                this.mParentControl.MouseDown -= this.ParentControl_MouseDown;
            }
        }
        /// <summary>
        /// 年月パネルの初期化
        /// </summary>
        private void InitializeYearMonthPanel()
        {
            // パネルの初期設定
            this.mYearMonthPanel.Size = new Size(this.Width, this.Height - (this.Font.Height * 2));
            this.mYearMonthPanel.BackColor = Color.Black;
            this.mYearMonthPanel.BorderStyle = BorderStyle.FixedSingle;
            this.mYearMonthPanel.Visible = false;

            // 年月リストの初期設定
            this.mYearList.Dock = DockStyle.Fill;
            this.mMonthList.Dock = DockStyle.Fill;

            for (int y = this.SelectionStart.Year - 5; y <= this.SelectionStart.Year + 5; y++)
            {
                this.mYearList.Items.Add(y);
            }

            for (int m = 1; m <= 12; m++)
            {
                this.mMonthList.Items.Add(m);
            }

            this.mMonthList.SelectedIndexChanged += (s, e) =>
            {
                if (this.mYearList.SelectedItem is int year && this.mMonthList.SelectedItem is int month)
                {
                    var newDate = new DateTime(year, month, 1);
                    this.SetDate(newDate);
                    this.SelectionStart = newDate;
                    this.SelectionEnd = newDate;
                    this.mYearMonthPanel.Visible = false;
                }
            };

            TableLayoutPanel table = new TableLayoutPanel
            {
                RowCount = 1,
                ColumnCount = 2,
                Dock = DockStyle.Fill,
                Padding = new Padding(5),
                BackColor = Color.Gray,
            };

            table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            table.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));

            table.Controls.Add(this.mYearList, 0, 0);
            table.Controls.Add(this.mMonthList, 1, 0);

            this.mYearMonthPanel.Controls.Add(table);
            this.mParentControl?.Controls.Add(this.mYearMonthPanel);
        }

        /// <summary>
        /// 年月パネルの表示
        /// </summary>
        private void ShowYearMonthPanel()
        {
            if (this.mParentControl != null)
            {
                int year = this.SelectionStart.Year;
                int month = this.SelectionStart.Month;

                this.mYearList.SelectedItem = year;
                this.mMonthList.SelectedItem = month;

                Point screenLoc = this.PointToScreen(new Point(0, this.Font.Height * 2));
                Point parentLoc = this.mParentControl.PointToClient(screenLoc);
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
            if (this.mParentControl != null)
            {
                Point mousePos = this.mParentControl.PointToClient(Control.MousePosition);

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
