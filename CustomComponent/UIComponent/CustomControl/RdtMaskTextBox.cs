//-----------------------------------------------------------------------
// <copyright file="RdtMaskTextBox.cs" company="FUJIFILM Medical Solutions Corporation">
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
    /// RdtMaskTextBoxクラス
    /// </summary>
    /// <remarks>
    /// 
    /// (Rev.)        (Date)      (ID / NAME)                     (Comment)
    /// V1.00.00    : 2025.05.01    : 株式会社コスモ・インテリジェンス / 笠間可奈子   : original
    ///
    /// </remarks>
    public partial class RdtMaskTextBox : TextBox
    {
        #region "定数"
        private const string BORDER = "ボーダー";
        private const int BORDER_TICK_MAX = 30;
        private const int BORDER_TICK_MIN = 1;
        private const string IMAGE = "画像";
        #endregion

        #region "クラス変数"
        private static readonly ILog mLog = LogManager.GetLogger(typeof(RdtMaskTextBox));
        private string mBorderColor = Constants.BORDER_COLOR;
        private int mBorderThick = 1;
        private string mHideImagePath = string.Empty;
        private string mShowImagePath = string.Empty;
        private Button mToggleButton = new Button();
        private bool mShowPassword = true;
        private Image? mHideImage = null;
        private Image? mShowImage = null;
        private Image? thisImage = null;
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
        /// アイコン画像_パスワード非表示
        /// </summary>
        [Category(IMAGE)]
        public string HideImagePath
        {
            get => this.mHideImagePath;
            set
            {
                this.mHideImagePath = value;
            }
        }

        /// <summary>
        /// アイコン画像_パスワード表示
        /// </summary>
        [Category(IMAGE)]
        public string ShowImagePath
        {
            get => this.mShowImagePath;
            set
            {
                this.mShowImagePath = value;
            }
        }
        #endregion

        #region "パブリックメソッド"
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public RdtMaskTextBox()
        {
            this.InitializeComponent();
            this.InitializeCustomSetting();
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="container">コンテナ</param>
        public RdtMaskTextBox(IContainer container)
        {
            container.Add(this);
            this.InitializeComponent();
            this.InitializeCustomSetting();
        }

        /// <summary>
        /// 【単体テスト用】Toggleクリック呼び出し
        /// </summary>
        public void TogglePassword()
        {
            this.ToggleButton_Click(this.mToggleButton, EventArgs.Empty);
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

            // 非表示用トグル画像の取得
            try
            {
                this.mHideImage = ComponentCommon.GetImageFromPath(this.mHideImagePath);
            }
            catch (Exception ex)
            {
                mLog.Error("HideImage load is failed.");
                mLog.Error(ex);
            }
            // 表示用トグル画像の取得
            try
            {
                this.mShowImage = ComponentCommon.GetImageFromPath(this.mShowImagePath);
            }
            catch (Exception ex)
            {
                mLog.Error("ShowImage load is failed.");
                mLog.Error(ex);
            }

            try
            {
                // トグル画像の設定
                this.thisImage = this.mShowPassword ? this.mHideImage : this.mShowImage;
                this.mToggleButton.Image = this.thisImage;
            }
            catch (Exception ex)
            {
                mLog.Error("Failed to load toggle button image on create control", ex);
            }
            this.InitializeCustomSetting_ForeColor();
            this.mToggleButton.Height = this.ClientSize.Height;
        }

        /// <summary>
        /// フォント調整
        /// </summary>
        /// <param name="e">e</param>
        protected override void OnFontChanged(EventArgs e)
        {
            base.OnFontChanged(e);
            this.AdjustTextMargin();
        }

        /// <summary>
        /// 描画処理
        /// </summary>
        /// <param name="m">m</param>
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);

            const int WM_PAINT = 0x000F;
            if (m.Msg == WM_PAINT && this.mBorderThick > 0)
            {
                try
                {
                    using Graphics g = Graphics.FromHwnd(this.Handle);

                    using Pen pen = new Pen(ColorTranslator.FromHtml(this.mBorderColor), this.mBorderThick);
                    pen.Alignment = System.Drawing.Drawing2D.PenAlignment.Inset;

                    if (this.mBorderThick == 1)
                    {
                        // 1px の場合は整数座標で正確に描画
                        g.DrawLine(pen, 0, 0, 0, this.Height - 1);                 // 左線
                        g.DrawLine(pen, 0, 0, this.Width - 1, 0);                  // 上線
                        g.DrawLine(pen, 0, this.Height - 1, this.Width - 1, this.Height - 1); // 下線
                    }
                    else
                    {
                        int half = this.mBorderThick / 2;
                        g.DrawLine(pen, half, half, half, this.Height - half);                   // 左線
                        g.DrawLine(pen, half, half, this.Width - half, half);                   // 上線
                        g.DrawLine(pen, half, this.Height - half, this.Width - half, this.Height - half); // 下線
                    }
                }
                catch (Exception ex)
                {
                    mLog.Error("Failed to draw border", ex);
                }
            }
        }
        #endregion

        #region "プライベートメソッド"
        /// <summary>
        /// コンストラクタ共通処理
        /// </summary>
        private void InitializeCustomSetting()
        {
            this.InitializeToggleButton();
            // デフォルト設定
            string fontType = ComponentCommon.GetFontType();
            int fontSize = ComponentCommon.GetFontSize();
            this.Font = new Font(fontType, fontSize);
            this.BackColor = ColorTranslator.FromHtml(ComponentCommon.GetBackColor());

            this.BorderStyle = BorderStyle.None;
            // テキストがボタンと被らないように
            this.Padding = new Padding(0, 0, this.mToggleButton.Width, 0);
        }

        /// <summary>
        /// 文字色の指定（上書き防止）
        /// </summary>
        private void InitializeCustomSetting_ForeColor()
        {
            // 文字色
            if (this.Enabled)
            {
                this.ForeColor = ColorTranslator.FromHtml(ComponentCommon.GetFontColor());
            }
            else
            {
                this.ForeColor = ColorTranslator.FromHtml(ComponentCommon.GetInactiveColor());
            }
        }

        /// <summary>
        /// ImageのDispose
        /// </summary>
        private void DisposeCustomSetting()
        {
            if (this.mShowImage != null)
            {
                this.mShowImage.Dispose();
            }
            if (this.mHideImage != null)
            {
                this.mHideImage.Dispose();
            }
            if (this.thisImage != null)
            {
                this.thisImage.Dispose();
            }
        }

        /// <summary>
        /// 表示/非表示ボタン
        /// </summary>
        private void InitializeToggleButton()
        {
            // ボタン設定
            this.mToggleButton = new Button
            {
                Size = new Size(20, this.ClientSize.Height),
                Dock = DockStyle.Right,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand,
                TabStop = false,
            };

            this.mToggleButton.FlatAppearance.BorderSize = 0;

            this.mToggleButton.Click -= this.ToggleButton_Click;
            this.mToggleButton.Click += this.ToggleButton_Click;

            try
            {
                // トグルアイコン設定
                this.mToggleButton.Image = this.mShowImage;
            }
            catch (Exception ex)
            {
                mLog.Error($"Image load failed:", ex);
            }

            // TextBoxにボタンを組み込むため、親コントロールとしてPanelを推奨
            this.Controls.Add(this.mToggleButton);
            this.Controls.SetChildIndex(this.mToggleButton, 0);
            this.mToggleButton.Paint -= this.ToggleButton_Paint;
            this.mToggleButton.Paint += this.ToggleButton_Paint;
        }

        /// <summary>
        /// 表示/非表示ボタンクリック
        /// </summary>
        /// <param name="sender">s</param>
        /// <param name="e">e</param>
        private void ToggleButton_Click(object? sender, EventArgs e)
        {
            // パスワード表示状態をトグル（true ⇔ false を切り替える）
            this.mShowPassword = !this.mShowPassword;

            // 表示状態に応じてアイコン画像を取得
            this.thisImage = this.mShowPassword ? this.mHideImage : this.mShowImage;

            try
            {
                // 新しい画像をセット
                this.mToggleButton.Image = this.thisImage;
            }
            catch (Exception ex)
            {
                mLog.Error($"Toggle image load failed: ", ex);
            }
            this.UseSystemPasswordChar = this.mShowPassword;
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

        /// <summary>
        /// ボタンエリアの枠線を描画
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        private void ToggleButton_Paint(object? sender, PaintEventArgs e)
        {
            int width = this.mToggleButton.Width;
            int height = this.mToggleButton.Height;

            using Pen pen = new Pen(ColorTranslator.FromHtml(this.mBorderColor), this.mBorderThick);
            // ピクセルずれを防ぐ
            pen.Alignment = PenAlignment.Inset;
            // 高さ・幅
            int b = this.mBorderThick;
            // 上線
            e.Graphics.DrawLine(pen, 0, 0, width - 1, 0);
            // 右線
            e.Graphics.DrawLine(pen, width - 1, 0, width - 1, height - 1);
            // 下線
            e.Graphics.DrawLine(pen, 0, height - 1, width - 1, height - 1);
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