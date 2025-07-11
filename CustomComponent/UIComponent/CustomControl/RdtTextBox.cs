//-----------------------------------------------------------------------
// <copyright file="RdtTextBox.cs" company="FUJIFILM Medical Solutions Corporation">
// Copyright (C) 2025 FUJIFILM Medical Solutions Corporation.
// </copyright>
//-----------------------------------------------------------------------
using System.ComponentModel;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;

using log4net;

namespace RADISTA.UIComponent.CustomControl
{
    /// <summary>
    /// RdtTextBoxクラス
    /// </summary>
    /// <remarks>
    /// 
    /// (Rev.)        (Date)      (ID / NAME)                     (Comment)
    /// V1.00.00    : 2025.05.01    : 株式会社コスモ・インテリジェンス / 笠間可奈子   : original
    ///
    /// </remarks>
    public partial class RdtTextBox : TextBox
    {
        #region "定数"
        private const string BORDER = "ボーダー";
        private const int BORDER_TICK_MAX = 30;
        private const int BORDER_TICK_MIN = 1;
        private const string WATER_MARK = "ウォーターマーク";
        #endregion

        #region "クラス変数"
        private static readonly ILog mLog = LogManager.GetLogger(typeof(RdtTextBox));
        private string mBorderColor = Constants.BORDER_COLOR;
        private int mBorderThick = 1;
        private bool mShowWaterMark = false;
        private string mWaterMarkText = "ここに入力してください。";
        private string mWaterMarkFontColor = Constants.WATERMARK_FONT_COLOR;
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

        /// <summary>
        /// ウォーターマーク表示あり/なし
        /// </summary>
        [Category(WATER_MARK)]
        public bool ShowWaterMark
        {
            get => this.mShowWaterMark;
            set
            {
                this.mShowWaterMark = value;
            }
        }

        /// <summary>
        /// ウォーターマーク表示テキスト内容
        /// </summary>
        [Category(WATER_MARK)]
        public string WaterMarkText
        {
            get => this.mWaterMarkText;
            set
            {
                this.mWaterMarkText = value;
            }
        }

        /// <summary>
        /// ウォーターマーク文字色
        /// </summary>
        [Category(WATER_MARK)]
        public string WaterMarkFontColor
        {
            get => this.mWaterMarkFontColor;
            set
            {
                if (!ComponentCommon.IsColorCode(value))
                {
                    throw new ArgumentException(Constants.ERROR_COLOR_CODE);
                }
                this.mWaterMarkFontColor = value;
            }
        }
        #endregion

        #region "パブリックメソッド"
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public RdtTextBox()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="container">コンテナ</param>
        public RdtTextBox(IContainer container)
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
                // テキストのマージンを調整（ボーダーとの重なりを防ぐ）
                this.AdjustTextMargin();
                this.InitializeCustomSetting();
            }
            catch (Exception ex)
            {
                mLog.Error("OnCreateControl error", ex);
            }
        }

        /// <summary>
        /// テキスト内容変更イベント
        /// </summary>
        /// <param name="e">e</param>
        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
            // コントロールの再描画を要求
            this.Invalidate();
        }

        /// <summary>
        /// WndProcイベント
        /// </summary>
        /// <param name="m">m</param>
        protected override void WndProc(ref Message m)
        {
            const int WM_PAINT = 0x000F;

            if (m.Msg == WM_PAINT)
            {
                try
                {
                    base.WndProc(ref m);
                    using (Graphics g = Graphics.FromHwnd(this.Handle))
                    {
                        // 背景塗りつぶし
                        g.Clear(this.BackColor);

                        // ウォーターマーク描画（必要な場合のみ）
                        this.DrawWaterMark(g);

                        // ボーダー描画
                        if (this.mBorderThick > 0)
                        {
                            using Pen pen = new Pen(ColorTranslator.FromHtml(this.mBorderColor), this.mBorderThick);
                            Rectangle borderRect = new Rectangle(
                                this.mBorderThick / 2,
                                this.mBorderThick / 2,
                                this.Width - this.mBorderThick,
                                this.Height - this.mBorderThick);
                            g.DrawRectangle(pen, borderRect);
                        }
                        // テキスト描画
                        if (!string.IsNullOrEmpty(this.Text))
                        {
                            Rectangle textRect = this.ClientRectangle;
                            if (this.Multiline)
                            {
                                // ボーダーと重ならないように調整
                                textRect.Inflate(-this.mBorderThick, -this.mBorderThick);
                            }

                            Color textColor = this.Enabled
                                ? this.ForeColor
                                : ColorTranslator.FromHtml(ComponentCommon.GetInactiveColor());

                            TextFormatFlags flags = TextFormatFlags.Left | TextFormatFlags.Top | TextFormatFlags.EndEllipsis;
                            // Multiline の場合は、折り返しや TextBox スタイルを追加
                            if (this.Multiline)
                            {
                                flags |= TextFormatFlags.WordBreak | TextFormatFlags.TextBoxControl;
                            }
                            // テキストを描画
                            TextRenderer.DrawText(g, this.Text, this.Font, textRect, textColor, flags);
                        }
                    }
                    // メッセージ処理完了を明示（base呼び出し不要）
                    m.Result = IntPtr.Zero;
                    return;
                }
                catch (Exception ex)
                {
                    mLog.Error("Failed to draw in WM_PAINT", ex);
                }
            }
            base.WndProc(ref m);
        }
        #endregion

        #region "プライベートメソッド"
        /// <summary>
        /// コンストラクタ共通処理
        /// </summary>
        private void InitializeCustomSetting()
        {
            // デフォルト設定
            this.Font = new Font(ComponentCommon.GetFontType(), ComponentCommon.GetFontSize());
            this.ForeColor = this.Enabled
                ? ColorTranslator.FromHtml(ComponentCommon.GetFontColor())
                : ColorTranslator.FromHtml(ComponentCommon.GetInactiveColor());
            this.BackColor = ColorTranslator.FromHtml(ComponentCommon.GetBackColor());

            this.BorderStyle = BorderStyle.None;
            this.SetStyle(
                          ControlStyles.OptimizedDoubleBuffer |
                          ControlStyles.AllPaintingInWmPaint, true);
        }

        /// <summary>
        /// 文字入力のカーソルとボーダーが重ならないように調整
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

        /// <summary>
        /// ウォーターマークの描画処理
        /// </summary>
        private void DrawWaterMark(Graphics g)
        {
            // ウォーターマークの表示条件をチェック
            // ・ShowWaterMark が true である
            // ・コントロールが有効 (Enabled == true)
            // ・テキストが入力されていない (Text が空)
            // ・ウォーターマークのテキストが設定されている
            if (!this.ShowWaterMark || !this.Enabled || !string.IsNullOrEmpty(this.Text) || string.IsNullOrEmpty(this.mWaterMarkText))
            {
                return;
            }

            // ウォーターマークのテキストを描画
            Rectangle wmRect = this.ClientRectangle;
            if (this.Multiline)
            {
                // ボーダーと重ならないように調整
                wmRect.Inflate(-this.mBorderThick, -this.mBorderThick);
            }
            TextRenderer.DrawText(
                g,
                this.mWaterMarkText,
                this.Font,
                wmRect,
                ColorTranslator.FromHtml(this.mWaterMarkFontColor),
                TextFormatFlags.Top | TextFormatFlags.Left | TextFormatFlags.WordBreak);
        }
        #endregion
    }

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
//---<<END OF FILE>>-----------------------------------------------------