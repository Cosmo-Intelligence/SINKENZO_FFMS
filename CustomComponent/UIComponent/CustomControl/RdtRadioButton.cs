// -----------------------------------------------------------------------
// <copyright file="RdtRadioButton.cs" company="FUJIFILM Medical Solutions Corporation">
// Copyright (C) 2025 FUJIFILM Medical Solutions Corporation.
// </copyright>
// -----------------------------------------------------------------------
using System.ComponentModel;

using log4net;

namespace RADISTA.UIComponent.CustomControl
{
    /// <summary>
    /// RdtRadioButtonlクラス
    /// </summary>
    /// <remarks>
    /// 
    /// (Rev.)        (Date)      (ID / NAME)                     (Comment)
    /// V1.00.00    : 2025.06.09    : 株式会社コスモ・インテリジェンス / 上原尚也   : original
    ///
    /// </remarks>
    public partial class RdtRadioButton : RadioButton
    {
        #region 定数
        private const string IMAGE = "イメージ";
        /// <summary>
        /// カテゴリ名
        /// </summary>
        private const string FOCUS_COLOR = "フォーカスカラー";
        /// <summary>
        /// マウスホバー時の色
        /// </summary>
        private const string MOUSE_HOVER_COLOR = "#FF0000";
        /// <summary>
        /// マウスクリック時の色
        /// </summary>
        private const string MOUSE_CLICK_COLOR = "#00FF00";
        #endregion

        #region クラス変数
        private static readonly ILog mLog = LogManager.GetLogger(typeof(RdtRadioButton));
        private bool mUseCustomImage = false;
        private string mCheckedImagePath = string.Empty;
        private Image? mCheckedImage = null;

        private string mUncheckedImagePath = string.Empty;
        private Image? mUncheckedImage = null;

        private string mMouseHoverColor = MOUSE_HOVER_COLOR;
        private string mMouseClickColor = MOUSE_CLICK_COLOR;
        private string mBackColor = Constants.DEFAULT_BACK_COLOR;
        #endregion

        #region プロパティ
        /// <summary>
        /// ボタンデザイン画像の使用/不使用を切り替える
        /// <para>
        /// true:使用する  false:使用しない
        /// </para>
        /// </summary>
        [Category(IMAGE)]
        public bool UseCustomImage
        {
            get => this.mUseCustomImage;
            set => this.mUseCustomImage = value;
        }

        /// <summary>
        /// チェックされた時の画像パス
        /// <para>
        /// 初期化時のみ変更が有効
        /// </para>
        /// </summary>
        [Category(IMAGE)]
        public string CheckedImagePath
        {
            get => this.mCheckedImagePath;
            set => this.mCheckedImagePath = value;
        }

        /// <summary>
        /// チェックされていない時の画像パス
        /// <para>
        /// 初期化時のみ変更が有効
        /// </para>
        /// </summary>
        [Category(IMAGE)]
        public string UncheckedImagePath
        {
            get => this.mUncheckedImagePath;
            set => this.mUncheckedImagePath = value;
        }

        /// <summary>
        /// マウスホバー時の背景色
        /// </summary>
        [Category(FOCUS_COLOR)]
        public string MouseHoverColor
        {
            get => this.mMouseHoverColor;
            set
            {
                // デザイナのプロパティで入力ミスがあった場合は直接エラーメッセージを出す
                if (!ComponentCommon.IsColorCode(value))
                {
                    throw new ArgumentException(Constants.ERROR_COLOR_CODE);
                }
                this.mMouseHoverColor = value;
            }
        }

        /// <summary>
        /// マウスクリック時の色
        /// </summary>
        [Category(FOCUS_COLOR)]
        public string MouseClickColor
        {
            get => this.mMouseClickColor;
            set
            {
                // デザイナのプロパティで入力ミスがあった場合は直接エラーメッセージを出す
                if (!ComponentCommon.IsColorCode(value))
                {
                    throw new ArgumentException(Constants.ERROR_COLOR_CODE);
                }
                this.mMouseClickColor = value;
            }
        }
        #endregion

        #region パブリックメソッド
        /// <summary>
        /// 初期化処理
        /// </summary>
        public RdtRadioButton()
        {
            this.InitializeComponent();
            this.InitializeCustomSetting();
        }

        /// <summary>
        /// Initialize Method.
        /// </summary>
        /// <param name="container">container</param>
        public RdtRadioButton(IContainer container)
        {
            container.Add(this);

            this.InitializeComponent();
            this.InitializeCustomSetting();
        }
        #endregion

        #region プロテクテッドメソッド
        /// <summary>
        /// ボタンの描画処理
        /// </summary>
        /// <param name="pevent">Event</param>
        protected override void OnPaint(PaintEventArgs pevent)
        {
            try
            {
                if (this.Enabled)
                {
                    this.ForeColor = ColorTranslator.FromHtml(ComponentCommon.GetFontColor());
                }
                else
                {
                    this.ForeColor = ColorTranslator.FromHtml(ComponentCommon.GetInactiveColor());
                }

                base.OnPaint(pevent);

                if (this.mUseCustomImage == true)
                {
                    Rectangle imgRect = new Rectangle();

                    bool textDrawFlag = false;

                    // チェック状態に応じて画像を描画
                    if (this.Checked && this.mCheckedImage != null)
                    {
                        //画像がなかった場合、デフォルトの□が表示されるようにif文の中でClear
                        pevent.Graphics.Clear(this.BackColor);

                        // 画像を描画する領域（縦中央、幅は画像幅、左端に配置）
                        int imgWidth = this.mCheckedImage.Width;
                        int imgHeight = this.mCheckedImage.Height;

                        imgRect = new Rectangle(0, (this.Height - imgHeight) / 2, imgWidth, imgHeight);

                        pevent.Graphics.DrawImage(this.mCheckedImage, imgRect);

                        textDrawFlag = true;
                    }
                    else if (this.Checked == false && this.mUncheckedImage != null)
                    {
                        //画像がなかった場合、デフォルトの□が表示されるようにif文の中でClear
                        pevent.Graphics.Clear(this.BackColor);

                        // 画像を描画する領域（縦中央、幅は画像幅、左端に配置）
                        int imgWidth = this.mUncheckedImage.Width;
                        int imgHeight = this.mUncheckedImage.Height;

                        imgRect = new Rectangle(0, (this.Height - imgHeight) / 2, imgWidth, imgHeight);

                        pevent.Graphics.DrawImage(this.mUncheckedImage, imgRect);

                        textDrawFlag = true;
                    }

                    //2重に文字の描画をしないようにする
                    if (textDrawFlag == true)
                    {
                        // テキスト描画位置（画像の右側に余白をとる）
                        Point textPos = new Point(imgRect.Right + 5, (this.Height - this.Font.Height) / 2);

                        TextRenderer.DrawText(pevent.Graphics, this.Text, this.Font, textPos, this.ForeColor);
                    }
                }
            }
            catch (Exception ex)
            {
                mLog.Debug("OnPaint_Exception");
                mLog.Error(ex.ToString());
            }
        }

        /// <summary>
        /// OnCreateControl
        /// </summary>
        protected override void OnCreateControl()
        {
            base.OnCreateControl();

            try
            {
                if (string.IsNullOrEmpty(this.mCheckedImagePath))
                {
                    this.mCheckedImage = ComponentCommon.GetImageFromPath(this.mCheckedImagePath);
                }
            }
            catch (Exception ex)
            {
                mLog.Error($"{this.Name}.mCheckedImage load is failed.");
                mLog.Error(ex);
            }

            try
            {
                if (string.IsNullOrEmpty(this.mUncheckedImagePath))
                {
                    this.mUncheckedImage = ComponentCommon.GetImageFromPath(this.mUncheckedImagePath);
                }
            }
            catch (Exception ex)
            {
                mLog.Error($"{this.Name}.mUncheckedImage load is failed.");
                mLog.Error(ex);
            }
        }
        #endregion

        #region プライベートメソッド

        /// <summary>
        /// 初期化処理
        /// </summary>
        private void InitializeCustomSetting()
        {
            // デフォルト設定
            string fontType = ComponentCommon.GetFontType();
            int fontSize = ComponentCommon.GetFontSize();
            this.Font = new Font(fontType, fontSize);
            this.BackColor = ColorTranslator.FromHtml(ComponentCommon.GetBackColor());

            this.SetStyle(ControlStyles.UserPaint, true);
            this.AutoSize = true;

            //イベントの設定
            this.AttachEvents();
        }

        /// <summary>
        /// Dispose処理
        /// </summary>
        private void DisposeCustomSetting()
        {
            if (this.mCheckedImage != null)
            {
                this.mCheckedImage.Dispose();
                this.mCheckedImage = null;
            }

            if (this.mUncheckedImage != null)
            {
                this.mUncheckedImage.Dispose();
                this.mUncheckedImage = null;
            }

            this.DetachEvents();
        }

        /// <summary>
        /// イベントを削除する
        /// </summary>
        private void DetachEvents()
        {
            this.MouseDown -= this.RdtButton_MouseDown;
            this.MouseUp -= this.RdtButton_MouseUp;
            this.MouseEnter -= this.RdtButton_MouseEnter;
            this.MouseLeave -= this.RdtButton_MouseLeave;
        }

        /// <summary>
        /// イベントを追加する
        /// </summary>
        private void AttachEvents()
        {
            this.DetachEvents();

            this.MouseDown += this.RdtButton_MouseDown;
            this.MouseUp += this.RdtButton_MouseUp;
            this.MouseEnter += this.RdtButton_MouseEnter;
            this.MouseLeave += this.RdtButton_MouseLeave;
        }

        /// <summary>
        /// MouseHover
        /// </summary>
        /// <param name="e">event</param>
        private void RdtButton_MouseEnter(object? sender, EventArgs e)
        {
            this.BackColor = ColorTranslator.FromHtml(this.mMouseHoverColor);
            this.Invalidate();
        }

        /// <summary>
        /// マウスボタン押下時イベント
        /// </summary>
        /// <param name="e">event</param>
        private void RdtButton_MouseDown(object? sender, EventArgs e)
        {
            this.BackColor = ColorTranslator.FromHtml(this.mMouseClickColor);
            this.Invalidate();
        }

        /// <summary>
        /// マウスボタン押下解除時イベント
        /// </summary>
        /// <param name="e">event</param>
        private void RdtButton_MouseUp(object? sender, EventArgs e)
        {
            this.BackColor = ColorTranslator.FromHtml(this.mMouseHoverColor);
            this.Invalidate();
        }

        /// <summary>
        /// マウスホバー解除時イベント
        /// </summary>
        /// <param name="e">event</param>
        private void RdtButton_MouseLeave(object? sender, EventArgs e)
        {
            this.BackColor = ColorTranslator.FromHtml(this.mBackColor);
            this.Invalidate();
        }

        /// <summary>
        /// 背景色変更イベント
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        private void RdtButton_BackColorChanged(object? sender, EventArgs e)
        {
            Color backColor = this.BackColor;
            string colorCode = $"#{backColor.R:X2}{backColor.G:X2}{backColor.B:X2}";
            this.mBackColor = colorCode;
        }

        #endregion
    }
}
