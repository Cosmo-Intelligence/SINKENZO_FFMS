//-----------------------------------------------------------------------
// <copyright file="RdtLabel.cs" company="FUJIFILM Medical Solutions Corporation">
// Copyright (C) 2025 FUJIFILM Medical Solutions Corporation.
// </copyright>
//-----------------------------------------------------------------------
using System.ComponentModel;
using System.Drawing.Drawing2D;
using log4net;

namespace RADISTA.UIComponent.CustomControl
{
    /// <summary>
    /// RdtLabelクラス
    /// </summary>
    /// <remarks>
    /// 
    /// (Rev.)        (Date)      (ID / NAME)                     (Comment)
    /// V1.00.00    : 2025.05.01    : 株式会社コスモ・インテリジェンス / 藤原崇文   : original
    ///
    /// </remarks>
    public partial class RdtLabel : Label
    {
        #region "列挙型"
        /// <summary>
        /// コーナーカーブパターンの列挙型
        /// </summary>
        public enum CornerCurvePatternT
        {
            /// <summary>
            /// 角が四角
            /// </summary>
            Square,
            /// <summary>
            /// 角丸
            /// </summary>
            RoundCorner,
            /// <summary>
            /// 角が円
            /// </summary>
            Circle,
        }
        #endregion

        #region "定数"
        private const string BLINK = "点滅間隔";
        private const string CORNER_CURVE_PATTERN = "コーナーカーブパターン";
        private const string BORDER = "ボーダー";
        private const int BLINK_INTERVAL_MAX = 5;
        private const int BLINK_INTERVAL_MIN = 1;
        private const int BORDER_TICK_MAX = 30;
        private const int BORDER_TICK_MIN = 0;
        #endregion

        #region "クラス変数"
        private static readonly ILog mLog = LogManager.GetLogger(typeof(RdtLabel));
        private bool mIsBlink = false;
        private System.Windows.Forms.Timer mBlinkTimer = new System.Windows.Forms.Timer();
        private int mBlinkInterval = 1;
        private bool mIsBlinkColor = false;
        private string mBlinkFontColor = Constants.BLINK_FONT_COLOR;
        private string mBlinkBackColor = Constants.BLINK_BACK_COLOR;
        private CornerCurvePatternT mCornerCurvePattern = CornerCurvePatternT.Square;
        private string mBorderColor = Constants.BORDER_COLOR;
        private int mBorderThick = 0;
        #endregion

        #region "プロパティ"
        /// <summary>
        /// 点滅表示/非表示
        /// </summary>
        [Category(BLINK)]
        public bool IsBlink
        {
            get => this.mIsBlink;
            set
            {
                this.mIsBlink = value;
            }
        }

        /// <summary>
        /// 点滅間隔指定（秒）
        /// </summary>
        [Category(BLINK)]
        public int BlinkInterval
        {
            get => this.mBlinkInterval;
            set
            {
                int newValue = Math.Max(BLINK_INTERVAL_MIN, Math.Min(BLINK_INTERVAL_MAX, value));
                this.mBlinkInterval = newValue;
            }
        }

        /// <summary>
        /// 点滅時のフォント色
        /// </summary>
        [Category(BLINK)]
        public string BlinkFontColor
        {
            get => this.mBlinkFontColor;
            set
            {
                // デザイナのプロパティで入力ミスがあった場合は直接エラーメッセージを出す
                if (!ComponentCommon.IsColorCode(value))
                {
                    throw new ArgumentException(Constants.ERROR_COLOR_CODE);
                }
                this.mBlinkFontColor = value;
            }
        }

        /// <summary>
        /// 点滅時の背景色
        /// </summary>
        [Category(BLINK)]
        public string BlinkBackColor
        {
            get => this.mBlinkBackColor;
            set
            {
                // デザイナのプロパティで入力ミスがあった場合は直接エラーメッセージを出す
                if (!ComponentCommon.IsColorCode(value))
                {
                    throw new ArgumentException(Constants.ERROR_COLOR_CODE);
                }
                this.mBlinkBackColor = value;
            }
        }

        /// <summary>
        /// コーナーカーブパターン
        /// </summary>
        [Category(CORNER_CURVE_PATTERN)]
        public CornerCurvePatternT CornerCurvePattern
        {
            get => this.mCornerCurvePattern;
            set
            {
                this.mCornerCurvePattern = value;
            }
        }

        /// <summary>
        /// ボーダー色
        /// </summary>
        [Category(BORDER)]
        public string BorderColor
        {
            get => this.mBorderColor;
            set
            {
                // デザイナのプロパティで入力ミスがあった場合は直接エラーメッセージを出す
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
                this.mBorderThick = newValue;
            }
        }
        #endregion

        #region "パブリックメソッド"
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public RdtLabel()
        {
            this.InitializeComponent();

            this.InitializeCustomSetting();
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="container">コンテナ</param>
        public RdtLabel(IContainer container)
        {
            container.Add(this);

            this.InitializeComponent();

            this.InitializeCustomSetting();
        }

        /// <summary>
        /// 点滅の開始
        /// </summary>
        public void StartBlink()
        {
            if (this.mIsBlink)
            {
                this.mBlinkTimer.Start();
                this.Invalidate();
            }
        }

        /// <summary>
        /// 点滅の停止
        /// </summary>
        public void StopBlink()
        {
            if (this.mIsBlink)
            {
                this.mBlinkTimer.Stop();
                this.Invalidate();
            }
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

            // プロパティ設定
            if (this.mIsBlink)
            {
                this.mBlinkTimer.Interval = this.mBlinkInterval * 1000;
                this.mBlinkTimer.Tick -= this.BlinkTimer_Tick;
                this.mBlinkTimer.Tick += this.BlinkTimer_Tick;
            }
        }

        /// <summary>
        /// OnPaint
        /// </summary>
        /// <param name="e">イベント</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            try
            {
                // アクティブ切替で文字色変更
                if (this.Enabled)
                {
                    // 点滅状態で色を変更する
                    if (this.mIsBlinkColor)
                    {
                        this.ForeColor = ColorTranslator.FromHtml(this.mBlinkFontColor);
                        this.BackColor = ColorTranslator.FromHtml(this.mBlinkBackColor);
                    }
                    else
                    {
                        this.ForeColor = ColorTranslator.FromHtml(ComponentCommon.GetFontColor());
                        this.BackColor = ColorTranslator.FromHtml(ComponentCommon.GetBackColor());
                    }
                }
                else
                {
                    this.ForeColor = ColorTranslator.FromHtml(ComponentCommon.GetInactiveColor());
                }

                // コーナーカーブパターン描画
                if (this.mBorderThick == 0)
                {
                    return;
                }
                Rectangle rect = this.ClientRectangle;
                rect.Width -= 1;
                rect.Height -= 1;
                using (Pen pen = new Pen(ColorTranslator.FromHtml(this.mBorderColor), this.mBorderThick))
                {
                    if (this.mCornerCurvePattern == CornerCurvePatternT.Square)
                    {
                        e.Graphics.DrawRectangle(pen, rect);
                    }
                    else 
                    {
                        int radius = 1;
                        if (this.mCornerCurvePattern == CornerCurvePatternT.RoundCorner)
                        {
                            radius = 8;
                        }
                        else if (this.mCornerCurvePattern == CornerCurvePatternT.Circle)
                        {
                            radius = this.Height / 2;
                        }
                        using (GraphicsPath path = ComponentCommon.GetRoundRectanglePath(rect, radius))
                        {
                            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                            e.Graphics.DrawPath(pen, path);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                mLog.Debug("OnPaint_Exception");
                mLog.Error(ex.ToString());
            }
        }
        #endregion

        #region "プライベートメソッド"
        /// <summary>
        /// 拡張コンポーネントの初期設定
        /// </summary>
        private void InitializeCustomSetting()
        {
            // デフォルト設定
            string fontType = ComponentCommon.GetFontType();
            int fontSize = ComponentCommon.GetFontSize();
            this.Font = new Font(fontType, fontSize);
            this.ForeColor = ColorTranslator.FromHtml(ComponentCommon.GetFontColor());
            this.BackColor = ColorTranslator.FromHtml(ComponentCommon.GetBackColor());
        }

        /// <summary>
        /// Dispose
        /// </summary>
        private void DisposeCustomSetting()
        {
            if (this.mIsBlink)
            {
                this.mBlinkTimer.Tick -= this.BlinkTimer_Tick;
            }
        }

        /// <summary>
        /// 点滅イベント
        /// </summary>
        /// <param name="sender">senderオブジェクト</param>
        /// <param name="e">イベント</param>
        private void BlinkTimer_Tick(object? sender, EventArgs e)
        {
            this.mIsBlinkColor = !this.mIsBlinkColor;
            this.Invalidate();
        }
        #endregion
    }
}
//---<<END OF FILE>>-----------------------------------------------------