//-----------------------------------------------------------------------
// <copyright file="RdtProgressBar.cs" company="FUJIFILM Medical Solutions Corporation">
// Copyright (C) 2025 FUJIFILM Medical Solutions Corporation.
// </copyright>
//-----------------------------------------------------------------------
using System.ComponentModel;

using log4net;

namespace RADISTA.UIComponent.CustomControl
{
    /// <summary>
    /// RdtProgressBarクラス
    /// </summary>
    /// <remarks>
    /// 
    /// (Rev.)        (Date)      (ID / NAME)                     (Comment)
    /// V1.00.00    : 2025.05.01    : 株式会社コスモ・インテリジェンス / 笠間可奈子   : original
    ///
    /// </remarks>
    public partial class RdtProgressBar : ProgressBar
    {
        #region "定数"
        private const string TEXT = "進捗テキスト";
        private const string BAR_COLOR = "進捗状況バー色";
        #endregion

        #region "クラス変数"
        private static readonly ILog mLog = LogManager.GetLogger(typeof(RdtProgressBar));
        private bool mShowText = true;
        private string mProgressColor = Constants.PROGRESS_COLOR;
        private string mBackgroundColor = Constants.PROGRESS_BACK_COLOR;
        #endregion

        #region "プロパティ"
        /// <summary>
        /// 進捗テキスト表示/非表示
        /// </summary>
        [Category(TEXT)]
        public bool ShowText
        {
            get => this.mShowText;
            set
            {
                this.mShowText = value;
            }
        }

        /// <summary>
        /// 進捗状況バー色
        /// </summary>
        [Category(BAR_COLOR)]
        public string ProgressColor
        {
            get => this.mProgressColor;
            set
            {
                // デザイナのプロパティで入力ミスがあった場合は直接エラーメッセージを出す
                if (!ComponentCommon.IsColorCode(value))
                {
                    throw new ArgumentException(Constants.ERROR_COLOR_CODE);
                }
                this.mProgressColor = value;
            }
        }

        /// <summary>
        /// 進捗状況バー背景色
        /// </summary>
        [Category(BAR_COLOR)]
        public string BackgroundColor
        {
            get => this.mBackgroundColor;
            set
            {
                // デザイナのプロパティで入力ミスがあった場合は直接エラーメッセージを出す
                if (!ComponentCommon.IsColorCode(value))
                {
                    throw new ArgumentException(Constants.ERROR_COLOR_CODE);
                }
                this.mBackgroundColor = value;
            }
        }
        #endregion

        #region "パブリックメソッド"
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public RdtProgressBar()
        {
            this.InitializeComponent();
            this.InitializeCustomSetting();
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="container">コンテナ</param>
        public RdtProgressBar(IContainer container)
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
        }

        /// <summary>
        /// 描画処理
        /// </summary>
        /// <param name="e">e</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            try
            {
                Rectangle rect = this.ClientRectangle;

                // 背景の描画
                using (SolidBrush backBrush = new SolidBrush(ColorTranslator.FromHtml(this.mBackgroundColor)))
                {
                    e.Graphics.FillRectangle(backBrush, rect);
                }

                // プログレスの割合を計算
                // ゼロ除算対策
                float percentage = (this.Maximum == this.Minimum) ? 0f : (float)(this.Value - this.Minimum) / (this.Maximum - this.Minimum);
                int width = (int)(rect.Width * percentage);
                Rectangle progressRect = new Rectangle(0, 0, width, rect.Height);

                // プログレス部分を指定色で塗りつぶす
                using (SolidBrush progressBrush = new SolidBrush(ColorTranslator.FromHtml(this.mProgressColor)))
                {
                    e.Graphics.FillRectangle(progressBrush, progressRect);
                }

                // 枠線を描画
                e.Graphics.DrawRectangle(Pens.Gray, 0, 0, rect.Width - 1, rect.Height - 1);

                // テキスト表示の場合
                if (this.mShowText)
                {
                    string displayText = $"{(int)(percentage * 100)}%";
                    TextRenderer.DrawText(e.Graphics, displayText, this.Font, this.ClientRectangle, SystemColors.ControlText, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter | TextFormatFlags.SingleLine);
                }
            }
            catch (Exception ex)
            {
                mLog.Error("Failed to draw progressbar", ex);
            }
            #endregion
        }

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

            this.SetStyle(
                ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
            this.UpdateStyles();
        }
        #endregion
    }
}
//---<<END OF FILE>>-----------------------------------------------------
