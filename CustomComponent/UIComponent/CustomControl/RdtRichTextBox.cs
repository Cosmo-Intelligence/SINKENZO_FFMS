//-----------------------------------------------------------------------
// <copyright file="RdtRichTextBox.cs" company="FUJIFILM Medical Solutions Corporation">
// Copyright (C) 2025 FUJIFILM Medical Solutions Corporation.
// </copyright>
//-----------------------------------------------------------------------
using System.ComponentModel;
using System.Runtime.InteropServices;

using log4net;

namespace RADISTA.UIComponent.CustomControl
{
    /// <summary>
    /// RdtRichTextBoxクラス
    /// </summary>
    /// <remarks>
    /// 
    /// (Rev.)        (Date)      (ID / NAME)                     (Comment)
    /// V1.00.00    : 2025.05.01    : 株式会社コスモ・インテリジェンス / 笠間可奈子   : original
    ///
    /// </remarks>
    public partial class RdtRichTextBox : RichTextBox
    {
        #region "定数"
        private const string BORDER = "ボーダー";
        private const int BORDER_TICK_MAX = 30;
        private const int BORDER_TICK_MIN = 1;
        #endregion

        #region "クラス変数"
        private static readonly ILog mLog = LogManager.GetLogger(typeof(RdtRichTextBox));
        private string mBorderColor = Constants.BORDER_COLOR;
        private int mBorderThick = 1;
        #endregion

        #region "プロパティ"
        /// <summary>
        /// ボーダー色
        /// </summary>
        [Category(BORDER)]
        public string BorderColor
        {
            get => this.mBorderColor;
            set
            {
                if (!ComponentCommon.IsColorCode(value))
                {
                    throw new ArgumentException(Constants.ERROR_COLOR_CODE);
                }
                this.mBorderColor = value;
            }
        }

        /// <summary>
        /// ボーダーの太さ（pixel）
        /// </summary>
        [Category(BORDER)]
        public int BorderThick
        {
            get => this.mBorderThick;
            set
            {
                int newValue = Math.Max(BORDER_TICK_MIN, Math.Min(BORDER_TICK_MAX, value));
                if (this.mBorderThick != newValue)
                {
                    this.mBorderThick = newValue;
                }
            }
        }
        #endregion

        #region "コンストラクタ"
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public RdtRichTextBox()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="container">コンテナ</param>
        public RdtRichTextBox(IContainer container)
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
            try
            {
                this.AdjustTextMargin();
                this.InitializeCustomSetting();
            }
            catch (Exception ex)
            {
                mLog.Error("OnCreateControl error", ex);
            }
        }

        /// <summary>
        /// 描画処理
        /// </summary>
        /// <param name="m">m</param>
        protected override void WndProc(ref Message m)
        {
            const int WM_PAINT = 0x000F;
            const int WM_LBUTTONDOWN = 0x0201;
            const int WM_KEYDOWN = 0x0100;
            // ユーザ入力をブロック
            if (this.ReadOnly && (m.Msg == WM_LBUTTONDOWN || m.Msg == WM_KEYDOWN))
            {
                return; // 入力を無視
            }

            base.WndProc(ref m);

            if (m.Msg == WM_PAINT && this.mBorderThick > 0)
            {
                try
                {
                    using Graphics g = Graphics.FromHwnd(this.Handle);
                    using Pen pen = new Pen(ColorTranslator.FromHtml(this.mBorderColor), this.mBorderThick);
                    Rectangle rect = new Rectangle(
                        this.mBorderThick / 2,
                        this.mBorderThick / 2,
                        this.Width - this.mBorderThick,
                        this.Height - this.mBorderThick);
                    g.DrawRectangle(pen, rect);
                }
                catch (Exception ex)
                {
                    mLog.Error("Failed to draw border", ex);
                }
            }
        }
        #endregion

        #region "プライベートメソッド
        /// <summary>
        /// コンストラクタ共通処理
        /// </summary>
        private void InitializeCustomSetting()
        {
            // デフォルト設定
            // アクティブ
            if (this.Enabled)
            {
                this.ForeColor = ColorTranslator.FromHtml(ComponentCommon.GetFontColor());
            }
            // 非アクティブ
            else
            {
                // Enabled = falseの場合は色の変更ができないため、ReadOnlyとし、非アクティブに見せる
                this.Enabled = true;
                this.ReadOnly = true;
                this.ForeColor = ColorTranslator.FromHtml(ComponentCommon.GetInactiveColor());
            }
            this.Font = new Font(ComponentCommon.GetFontType(), ComponentCommon.GetFontSize());
            this.BackColor = ColorTranslator.FromHtml(ComponentCommon.GetBackColor());

            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.BorderStyle = BorderStyle.None;
        }

        /// <summary>
        /// 入力文字とボーダーが重ならないように調整
        /// </summary>
        private void AdjustTextMargin()
        {
            int eM_SETRECT = 0xB3;
            if (!this.IsHandleCreated)
            {
                return;
            }
            NativeMethods.RECT rect = new NativeMethods.RECT
            {
                Left = this.mBorderThick,
                Top = this.mBorderThick,
                Right = this.ClientSize.Width - this.mBorderThick,
                Bottom = this.ClientSize.Height - this.mBorderThick,
            };

            NativeMethods.SendMessage(this.Handle, eM_SETRECT, 0, ref rect);
        }
        #endregion

        #region
        /// <summary>
        /// Windows API を使用用 P/Invoke メソッドおよび構造体を定義
        /// </summary>
        internal static class NativeMethods
        {
            /// <summary>
            /// テキストのマージンを設定するための領域を定義
            /// </summary>
            [StructLayout(LayoutKind.Sequential)]
            internal struct RECT
            {
                /// <summary>
                /// 左端の座標（ピクセル）
                /// </summary>
                public int Left;
                /// <summary>
                /// 上端の座標（ピクセル）
                /// </summary>
                public int Top;
                /// <summary>
                /// 右端の座標（ピクセル）
                /// </summary>
                public int Right;
                /// <summary>
                /// 下端の座標（ピクセル）
                /// </summary>
                public int Bottom;
            }

            /// <summary>
            /// 指定ウィンドウにメッセージを送る
            /// </summary>
            /// <param name="hWnd">対象のウィンドウのハンドル</param>
            /// <param name="msg">送信するメッセージの識別子</param>
            /// <param name="wParam">追加情報</param>
            /// <param name="lParam">メッセージの詳細情報</param>
            /// <returns>処理結果</returns>
            /// Windows のネイティブ API使用
            [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
            [DllImport("user32.dll", SetLastError = true)]
            internal static extern IntPtr SendMessage(IntPtr hWnd, int msg, int wParam, ref RECT lParam);
        }
        #endregion
    }
}
//---<<END OF FILE>>-----------------------------------------------------
