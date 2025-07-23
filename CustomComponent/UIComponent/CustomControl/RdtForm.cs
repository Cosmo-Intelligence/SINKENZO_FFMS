//-----------------------------------------------------------------------
// <copyright file="RdtForm.cs" company="FUJIFILM Medical Solutions Corporation">
// Copyright (C) 2025 FUJIFILM Medical Solutions Corporation.
// </copyright>
//-----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

using log4net;

namespace RADISTA.UIComponent.CustomControl
{
    /// <summary>
    /// RdtFormクラス
    /// </summary>
    /// <remarks>
    /// 
    /// (Rev.)        (Date)      (ID / NAME)                     (Comment)
    /// V1.00.00    : 2025.07.09    : 株式会社コスモ・インテリジェンス / 笠間可奈子   : original
    ///
    /// </remarks>
    public partial class RdtForm : Form
    {
        #region "列挙型"
        /// <summary>
        /// フォームタイトル配置位置
        /// </summary>
        public enum TitlePositionT
        {
            /// <summary>
            /// 左揃え
            /// </summary>
            Left,
            /// <summary>
            /// 中央揃え
            /// </summary>
            Center,
            /// <summary>
            /// 右揃え
            /// </summary>
            Right,
        }
        #endregion

        #region "定数"
        private const string FORMTITLE = "フォームタイトル";
        private const string BUTTON_FONT_STYLE = "Segoe UI";
        private const int TITLEBAR_HEIGHT = 30;
        private const int BUTTON_SIZE = 30;
        private const int BUTTON_FONT_SIZE = 14;
        #endregion

        #region "クラス変数"
        private static readonly ILog mLog = LogManager.GetLogger(typeof(RdtForm));
        private string mTitleBackColor = Constants.FORM_TITLE_BACK_COLOR;
        private string mTitleFontColor = Constants.FORM_TITLE_FONT_COLOR;
        private TitlePositionT mTitlePosition = TitlePositionT.Left;
        private Panel? mTitleBar;
        private Label? mTitleLabel;
        private Button? mCloseButton;
        private Button? mMinimizeButton;
        private Button? mMaximizeButton;
        #endregion

        #region "プロパティ"
        /// <summary>
        /// タイトル背景色
        /// </summary>
        [Category(FORMTITLE)]
        public string TitleBackColor
        {
            get => this.mTitleBackColor;
            set
            {
                if (!ComponentCommon.IsColorCode(value))
                {
                    throw new ArgumentException(Constants.ERROR_COLOR_CODE);
                }
                this.mTitleBackColor = value;
            }
        }

        /// <summary>
        /// タイトル前景色
        /// </summary>
        [Category(FORMTITLE)]
        public string TitleFontColor
        {
            get => this.mTitleFontColor;
            set
            {
                if (!ComponentCommon.IsColorCode(value))
                {
                    throw new ArgumentException(Constants.ERROR_COLOR_CODE);
                }
                this.mTitleFontColor = value;
            }
        }

        /// <summary>
        /// タイトル配置位置
        /// </summary>
        [Category(FORMTITLE)]
        public TitlePositionT TitlePosition
        {
            get => this.mTitlePosition;
            set
            {
                this.mTitlePosition = value;
            }
        }
        #endregion

        #region "パブリックメソッド"
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public RdtForm()
        {
            this.InitializeComponent();
            this.InitializeCustomSetting();
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="container">コンテナ</param>
        public RdtForm(IContainer container)
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
        }

        /// <summary>
        /// タイトルバー描画
        /// </summary>
        /// <param name="e">e</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if (this.mTitleLabel != null)
            {
                this.mTitleLabel.Text = this.Text;
                this.mTitleLabel.BackColor = ColorTranslator.FromHtml(this.mTitleBackColor);
                this.mTitleLabel.ForeColor = ColorTranslator.FromHtml(this.mTitleFontColor);
                if (this.mMinimizeButton != null && this.mMaximizeButton != null && this.mCloseButton != null)
                {
                    this.mMinimizeButton.BackColor = ColorTranslator.FromHtml(this.mTitleBackColor);
                    this.mMaximizeButton.BackColor = ColorTranslator.FromHtml(this.mTitleBackColor);
                    this.mCloseButton.BackColor = ColorTranslator.FromHtml(this.mTitleBackColor);
                }
                this.mTitleLabel.TextAlign = this.GetContentAlignment(this.mTitlePosition);
                // タイトルバーの作成後にイベント追加
                this.mTitleLabel.MouseDown += this.TitleBar_MouseDown;
            }
        }
        #endregion

        #region "プライベートメソッド"
        /// <summary>
        /// コンストラクタ共通処理
        /// </summary>
        private void InitializeCustomSetting()
        {
            // デフォルト設定
            string fontType = ComponentCommon.GetFontType();
            int fontSize = ComponentCommon.GetFontSize();
            this.Font = new Font(fontType, fontSize);
            this.ForeColor = ColorTranslator.FromHtml(ComponentCommon.GetFontColor());
            this.BackColor = ColorTranslator.FromHtml(ComponentCommon.GetBackColor());

            // フォーム設定
            this.FormBorderStyle = FormBorderStyle.None;

            // タイトルバーの作成
            this.mTitleBar = new Panel
            {
                BackColor = ColorTranslator.FromHtml(this.mTitleBackColor),
                Dock = DockStyle.Top,
                Height = TITLEBAR_HEIGHT,
            };
            this.Controls.Add(this.mTitleBar);

            // タイトルラベル
            this.mTitleLabel = new Label
            {
                ForeColor = ColorTranslator.FromHtml(this.mTitleFontColor),
                AutoSize = false,
                Location = new Point(0, 0),
                Height = this.mTitleBar.Height,
                // 右端90pxはボタン用スペース
                Width = this.Width - (BUTTON_SIZE * 3),
                Font = new Font(fontType, fontSize, FontStyle.Bold),
            };
            this.mTitleBar.Controls.Add(this.mTitleLabel);

            // 最小化ボタン
            this.mMinimizeButton = new Button
            {
                ForeColor = ColorTranslator.FromHtml(this.mTitleFontColor),
                Text = "─",
                Location = new Point(this.Width - (BUTTON_SIZE * 3), 0),
                Size = new Size(BUTTON_SIZE, BUTTON_SIZE),
                FlatStyle = FlatStyle.Flat,
                Font = new Font(BUTTON_FONT_STYLE, BUTTON_FONT_SIZE, FontStyle.Bold),
            };
            this.mMinimizeButton.FlatAppearance.BorderSize = 0;
            this.mMinimizeButton.Click += (s, e) => this.WindowState = FormWindowState.Minimized;
            this.mTitleBar.Controls.Add(this.mMinimizeButton);

            // 最大化ボタン
            this.mMaximizeButton = new Button
            {
                ForeColor = ColorTranslator.FromHtml(this.mTitleFontColor),
                Text = "□",
                Location = new Point(this.Width - (BUTTON_SIZE * 2), 0),
                Size = new Size(BUTTON_SIZE, BUTTON_SIZE),
                FlatStyle = FlatStyle.Flat,
                Font = new Font(BUTTON_FONT_STYLE, BUTTON_FONT_SIZE, FontStyle.Bold),
            };
            this.mMaximizeButton.FlatAppearance.BorderSize = 0;
            this.mMaximizeButton.Click += (s, e) =>
            {
                if (this.WindowState == FormWindowState.Normal)
                {
                    this.WindowState = FormWindowState.Maximized;
                }
                else
                {
                    this.WindowState = FormWindowState.Normal;
                }
            };
            this.mTitleBar.Controls.Add(this.mMaximizeButton);

            // 閉じるボタン
            this.mCloseButton = new Button
            {
                ForeColor = ColorTranslator.FromHtml(this.mTitleFontColor),
                Text = "×",
                Location = new Point(this.Width - BUTTON_SIZE, 0),
                Size = new Size(BUTTON_SIZE, BUTTON_SIZE),
                FlatStyle = FlatStyle.Flat,
                Font = new Font(BUTTON_FONT_STYLE, BUTTON_FONT_SIZE, FontStyle.Bold),
            };
            this.mCloseButton.FlatAppearance.BorderSize = 0;
            this.mCloseButton.Click += (s, e) => this.Close();
            this.mTitleBar.Controls.Add(this.mCloseButton);

            // サイズ変更イベントでボタンの位置を調整
            this.Resize += (s, e) =>
            {
                this.mMinimizeButton.Left = this.Width - (BUTTON_SIZE * 3);
                this.mMaximizeButton.Left = this.Width - (BUTTON_SIZE * 2);
                this.mCloseButton.Left = this.Width - BUTTON_SIZE;
                // ラベルの幅も再調整
                this.mTitleLabel.Width = this.Width - (BUTTON_SIZE * 3);
            };
        }

        /// <summary>
        /// タイトルバーでドラッグ移動
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        private void TitleBar_MouseDown(object? sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                NativeMethods.ReleaseCapture();
                NativeMethods.SendMessage(this.Handle, 0xA1, 0x2, 0);
            }
        }

        /// <summary>
        /// タイトル配置位置をContentAlignmentに変換
        /// </summary>
        private ContentAlignment GetContentAlignment(TitlePositionT position)
        {
            return position switch
            {
                // 左
                TitlePositionT.Left => ContentAlignment.MiddleLeft,
                // 中央
                TitlePositionT.Center => ContentAlignment.MiddleCenter,
                // 右
                TitlePositionT.Right => ContentAlignment.MiddleRight,
                _ => ContentAlignment.MiddleLeft,
            };
        }

        /// <summary>
        /// Win32 API関数の呼び出し
        /// </summary>
        private static class NativeMethods
        {
            // タイトルバーのドラッグ操作
            [System.Runtime.InteropServices.DllImport("user32.dll")]
            [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
            public static extern bool ReleaseCapture();

            // 指定したウィンドウにメッセージを送信
            [System.Runtime.InteropServices.DllImport("user32.dll")]
            [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
            public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        }
        #endregion
    }
}