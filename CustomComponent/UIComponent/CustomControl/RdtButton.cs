// -----------------------------------------------------------------------
// <copyright file="RdtButton.cs" company="FUJIFILM Medical Solutions Corporation">
// Copyright (C) 2025 FUJIFILM Medical Solutions Corporation.
// </copyright>
// -----------------------------------------------------------------------
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;

using log4net;

namespace RADISTA.UIComponent.CustomControl
{
    /// <summary>
    /// RdButtonlクラス
    /// </summary>
    /// <remarks>
    /// 
    /// (Rev.)        (Date)      (ID / NAME)                     (Comment)
    /// V1.00.00    : 2025.06.05    : 株式会社コスモ・インテリジェンス / 上原尚也   : original
    ///
    /// </remarks>
    public partial class RdtButton : Button
    {
        #region "列挙型"
        /// <summary>
        /// 均等割り付けパターン
        /// </summary>
        public enum TextJustifyS
        {
            /// <summary>
            /// 均等割り付け無し
            /// </summary>
            NONE = 1,
            /// <summary>
            /// 均等割り付け
            /// </summary>
            JUSTIFY = 2,
            /// <summary>
            /// スペース付き均等割り付け
            /// </summary>
            JUSTIFY_WITH_SPACE = 3,
        }

        /// <summary>
        /// ボタン文字の描画方法
        /// </summary>
        public enum TextOrientationS
        {
            /// <summary>
            /// 横書き
            /// </summary>
            HORIZONTAL = 1,
            /// <summary>
            /// 上から下に
            /// </summary>
            DOWN_WORD = 2,
            /// <summary>
            /// 下から上に
            /// </summary>
            UP_WORD = 3,
            /// <summary>
            /// 縦書き
            /// </summary>
            VERTICAL = 4,
        }
        #endregion

        #region "定数"
        /// <summary>
        /// カテゴリ名
        /// </summary>
        private const string BORDER = "ボーダー";
        /// <summary>
        /// カテゴリ名
        /// </summary>
        private const string FOCUS_COLOR = "フォーカスカラー";
        /// <summary>
        /// カテゴリ名
        /// </summary>
        private const string DISPLAY = "表示(カスタム)";
        /// <summary>
        /// ボーダーの太さの最大値
        /// </summary>
        private const int BORDER_TICK_MAX = 30;
        /// <summary>
        /// ボーダーの太さの最小値
        /// </summary>
        private const int BORDER_TICK_MIN = 1;
        /// <summary>
        /// コーナーの角度の初期値
        /// </summary>
        private const int CORNER_RADIUS = 8;
        /// <summary>
        /// コーナーの角度の最大値
        /// </summary>
        private const int CORNER_RADIUS_MAX = 16;
        /// <summary>
        /// コーナーの角度の最小値
        /// </summary>
        private const int CORNER_RADIUS_MIN = 1;
        /// <summary>
        /// 画像とテキストのマージン
        /// </summary>
        private const int IMAGE_MARGIN = 4;

        #region Gitへの移行後Constantsへ移動する項目
        //Gitへの移行後Constantsへ移動
        /// <summary>
        /// 内側のボーダーカラー
        /// </summary>
        private const string INNER_BORDER_COLOR = "#808080";
        /// <summary>
        /// マウスホバー時の色
        /// </summary>
        private const string MOUSE_HOVER_COLOR = "#FF0000";
        /// <summary>
        /// マウスクリック時の色
        /// </summary>
        private const string MOUSE_CLICK_COLOR = "#00FF00";
        #endregion

        #endregion

        #region "クラス変数"
        private static readonly ILog mLog = LogManager.GetLogger(typeof(RdtButton));
        private string mOuterBorderColor = Constants.BORDER_COLOR;
        private string mImageFilePath = string.Empty;
        private int mBorderThick = 1;
        private TextJustifyS mTextJustify = TextJustifyS.NONE;
        private TextOrientationS mTextOrientation = TextOrientationS.HORIZONTAL;
        private string mBackColor = Constants.DEFAULT_BACK_COLOR;

        private int mCornerRadius = CORNER_RADIUS;
        private string mInnerBorderColor = INNER_BORDER_COLOR;
        private string mMouseHoverColor = MOUSE_HOVER_COLOR;
        private string mMouseClickColor = MOUSE_CLICK_COLOR;
        #endregion

        #region "プロパティ"
        /// <summary>
        /// 枠線の色
        /// </summary>
        [Category(BORDER)]
        public string OuterBorderColor
        {
            get => this.mOuterBorderColor;
            set
            {
                if (!ComponentCommon.IsColorCode(value))
                {
                    throw new ArgumentException(Constants.ERROR_COLOR_CODE);
                }
                this.mOuterBorderColor = value;
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

        /// <summary>
        /// 二重ボーダーの内側の色
        /// </summary>
        [Category(BORDER)]
        public string InnerBorderColor
        {
            get => this.mInnerBorderColor;
            set
            {
                if (!ComponentCommon.IsColorCode(value))
                {
                    throw new ArgumentException(Constants.ERROR_COLOR_CODE);
                }
                this.mInnerBorderColor = value;
            }
        }

        /// <summary>
        /// コーナーの角度
        /// </summary>
        [Category(BORDER)]
        public int CornerRadius
        {
            get => this.mCornerRadius;
            set
            {
                int newValue = Math.Max(CORNER_RADIUS_MIN, Math.Min(CORNER_RADIUS_MAX, value));
                this.mCornerRadius = newValue;
            }
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
                if (!ComponentCommon.IsColorCode(value))
                {
                    throw new ArgumentException(Constants.ERROR_COLOR_CODE);
                }
                this.mMouseClickColor = value;
            }
        }

        /// <summary>
        /// テキストの均等割り付け
        /// </summary>
        [Category(DISPLAY)]
        public TextJustifyS TextJustify
        {
            get => this.mTextJustify;
            set => this.mTextJustify = value;
        }

        /// <summary>
        /// ボタンテキストの向き
        /// </summary>
        [Category(DISPLAY)]
        public TextOrientationS TextOrientation
        {
            get => this.mTextOrientation;
            set => this.mTextOrientation = value;
        }

        /// <summary>
        /// 画像のファイルパス
        /// <para>
        /// 初期化時のみ変更が有効
        /// </para>
        /// </summary>
        [Category(DISPLAY)]
        public string ImageFilePath
        {
            get => this.mImageFilePath;
            set => this.mImageFilePath = value;
        }
        #endregion

        #region "パブリックメソッド"
        /// <summary>
        /// Initializes a new instance of the <see cref="RdtButton"/> class.
        /// </summary>
        public RdtButton()
        {
            this.InitializeComponent();

            this.InitializeCustomSetting();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RdtButton"/> class.
        /// </summary>
        /// <param name="container"> container. </param>
        public RdtButton(IContainer container)
        {
            this.InitializeComponent();

            this.InitializeCustomSetting();
        }
        #endregion

        #region "プロテクテッドメソッド"

        /// <summary>
        /// OnPaint
        /// </summary>
        /// <param name="pevent">イベント</param>
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
                    this.ForeColor = ColorTranslator.FromHtml(Constants.DEFAULT_INACTIVE_COLOR);
                }

                //最初に背景を塗りつぶす
                using (SolidBrush brush = new SolidBrush(this.BackColor))
                {
                    pevent.Graphics.FillRectangle(brush, this.ClientRectangle);
                }

                //塗りつぶし
                using (SolidBrush brush = new SolidBrush(ColorTranslator.FromHtml(this.mBackColor)))
                {
                    Rectangle fillRect = this.ClientRectangle;
                    fillRect.X += int.Max((this.mBorderThick / 2) - 1, 0);
                    fillRect.Y += int.Max((this.mBorderThick / 2) - 1, 0);
                    fillRect.Width -= int.Max(this.mBorderThick - 1, 1);
                    fillRect.Height -= int.Max(this.mBorderThick - 1, 1);

                    // ボーダーの内側を背景色で塗りつぶす
                    using (GraphicsPath path = ComponentCommon.GetRoundRectanglePath(fillRect, this.mCornerRadius))
                    {
                        pevent.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                        pevent.Graphics.FillPath(brush, path);
                    }
                }

                // イメージを描画
                if (this.Image != null)
                {
                    Point imagePos = this.GetImageLocation(this.ImageAlign, this.Image.Size, this.ClientRectangle);
                    pevent.Graphics.DrawImage(this.Image, imagePos.X, imagePos.Y, this.Image.Width, this.Image.Height);
                }

                //ボタンテキストの描画
                switch (this.mTextOrientation)
                {
                    case TextOrientationS.HORIZONTAL:
                        {
                            this.ButtonTextHorizontalDraw(pevent);
                            break;
                        }
                    case TextOrientationS.DOWN_WORD:
                        {
                            this.ButtonTextRotationDraw(90, pevent);
                            break;
                        }
                    case TextOrientationS.UP_WORD:
                        {
                            this.ButtonTextRotationDraw(-90, pevent);
                            break;
                        }
                    case TextOrientationS.VERTICAL:
                        {
                            this.ButtonTextVertiaclDraw(pevent);
                            break;
                        }
                    default:
                        {
                            this.ButtonTextHorizontalDraw(pevent);
                            break;
                        }
                }

                //ボーダーを描画
                this.DrawBorder(pevent);
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
                if (!string.IsNullOrEmpty(this.mImageFilePath))
                {
                    this.Image = ComponentCommon.GetImageFromPath(this.mImageFilePath);
                }
            }
            catch (Exception ex)
            {
                mLog.Error($"{this.Name}.Image load is failed.");
                mLog.Error(ex);
            }
        }

        #endregion

        #region "プライベートメソッド"
        /// <summary>
        /// 横書きボタンの描画処理
        /// </summary>
        /// <param name="e">Event</param>
        private void ButtonTextHorizontalDraw(PaintEventArgs e)
        {
            if (string.IsNullOrEmpty(this.Text))
            {
                return;
            }

            if (this.mTextJustify != TextJustifyS.NONE)
            {
                using (Brush brush = new SolidBrush(this.ForeColor))
                {
                    string drawText = string.Empty;
                    if (this.mTextJustify == TextJustifyS.JUSTIFY_WITH_SPACE)
                    {
                        drawText = " " + this.Text + " ";
                    }
                    else
                    {
                        drawText = this.Text ?? string.Empty;
                    }

                    int charCount = drawText.Length;

                    int borderMargin = this.mBorderThick * 2;  // 縮小分

                    int textOffsetX = borderMargin;
                    int textOffsetY = borderMargin;

                    int textWidth = this.ClientSize.Width - (borderMargin * 2);
                    int textHeight = this.ClientSize.Height - (borderMargin * 2);

                    if (this.Image != null)
                    {
                        int imageWidth = this.Image.Width;
                        int imageHeight = this.Image.Height;

                        switch (this.ImageAlign)
                        {
                            case ContentAlignment.MiddleLeft:
                                textOffsetX += imageWidth + IMAGE_MARGIN;
                                textWidth -= imageWidth + IMAGE_MARGIN;
                                break;

                            case ContentAlignment.MiddleRight:
                                textWidth -= imageWidth + IMAGE_MARGIN;
                                break;

                            case ContentAlignment.TopCenter:
                                textOffsetY += imageHeight + IMAGE_MARGIN;
                                textHeight -= imageHeight + IMAGE_MARGIN;
                                break;

                            case ContentAlignment.BottomCenter:
                                textHeight -= imageHeight + IMAGE_MARGIN;
                                break;

                            default:
                                break;
                        }
                    }
                    // 均等割付の間隔を計算
                    float spacing = (float)textWidth / charCount;

                    // 開始X座標を中央寄せで調整
                    float totalWidth = spacing * charCount;
                    float offsetX = textOffsetX + ((textWidth - totalWidth) / 2);

                    // 文字描画
                    for (int drawCount = 0; drawCount < charCount; drawCount++)
                    {
                        string ch = drawText[drawCount].ToString();
                        SizeF charSize = e.Graphics.MeasureString(ch, this.Font);

                        // 文字を枠の中央に寄せて描画
                        float x = offsetX + (spacing * drawCount) + ((spacing - charSize.Width) / 2);
                        float y = textOffsetY + ((textHeight - charSize.Height) / 2);

                        e.Graphics.DrawString(ch, this.Font, brush, x, y);
                    }
                }
            }
            else
            {
                using (Brush brush = new SolidBrush(this.ForeColor))
                {
                    string drawText = this.Text ?? string.Empty;

                    //文字列のサイズを取得
                    SizeF textSize = e.Graphics.MeasureString(drawText, this.Font);

                    //描画不可範囲
                    int nonPortableRange = this.BorderThick * 4;

                    //描画開始位置調整
                    int offsetX = this.BorderThick * 2;

                    if (this.Image != null)
                    {
                        if (this.ImageAlign == ContentAlignment.MiddleLeft)
                        {
                            offsetX += this.Image.Width + IMAGE_MARGIN;
                        }

                        //画像があった場合、描画不可の範囲に画像領域を加算する
                        nonPortableRange += this.Image.Width + IMAGE_MARGIN;
                    }

                    //描画可能範囲
                    int drawRangeX = this.ClientSize.Width - nonPortableRange;
                    int drawRangeY = this.ClientSize.Height;

                    float x = ((drawRangeX - textSize.Width) / 2f) + offsetX;
                    float y = (drawRangeY - textSize.Height) / 2f;

                    e.Graphics.DrawString(drawText, this.Font, brush, x, y);
                }
            }
        }

        /// <summary>
        /// 縦書き(文字列回転)の描画処理
        /// </summary>
        /// <param name="rotate">回転角度</param>
        /// <param name="e">Event</param>
        private void ButtonTextRotationDraw(int rotate, PaintEventArgs e)
        {
            if (string.IsNullOrEmpty(this.Text))
            {
                return;
            }

            string drawText = string.Empty;
            if (this.mTextJustify == TextJustifyS.JUSTIFY_WITH_SPACE)
            {
                drawText = " " + this.Text + " ";
            }
            else
            {
                drawText = this.Text ?? string.Empty;
            }

            int charCount = drawText.Length;

            if (this.mTextJustify != TextJustifyS.NONE)
            {
                // 描画領域初期値
                int borderMargin = this.mBorderThick * 2;

                int offsetY = borderMargin * 2;
                int availableHeight = this.ClientSize.Height - offsetY;

                if (this.Image != null)
                {
                    switch (this.ImageAlign)
                    {
                        case ContentAlignment.TopCenter:
                            offsetY = this.Image.Height + IMAGE_MARGIN + borderMargin;
                            availableHeight -= this.Image.Height + IMAGE_MARGIN;
                            break;
                        case ContentAlignment.BottomCenter:
                            availableHeight -= this.Image.Height + IMAGE_MARGIN;
                            break;
                        default:
                            break;
                    }
                }

                //文字のサイズを図る
                SizeF charSize = e.Graphics.MeasureString(drawText[0].ToString(), this.Font);

                // 2. 均等割り付けスペースの計算
                float spacing = availableHeight / (float)charCount;
                int totalWidth = (int)(spacing * charCount);
                int totalHeight = availableHeight;

                using (Bitmap textBmp = new Bitmap(totalWidth, totalHeight))
                using (Graphics textG = Graphics.FromImage(textBmp))
                {
                    textG.Clear(Color.Transparent);
                    textG.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;

                    using (Brush brush = new SolidBrush(this.ForeColor))
                    {
                        for (int drawCount = 0; drawCount < charCount; drawCount++)
                        {
                            string ch = drawText[drawCount].ToString();
                            SizeF sz = textG.MeasureString(ch, this.Font);

                            float x = (spacing * drawCount) + ((spacing - sz.Width) / 2f);
                            float y = (textBmp.Height - sz.Height) / 2f;

                            textG.DrawString(ch, this.Font, brush, x, y);
                        }
                    }

                    // 3. 回転処理
                    RotateFlipType rotateFlip = rotate switch
                    {
                        90 => RotateFlipType.Rotate90FlipNone,
                        -90 or 270 => RotateFlipType.Rotate270FlipNone,
                        180 => RotateFlipType.Rotate180FlipNone,
                        _ => RotateFlipType.RotateNoneFlipNone,
                    };
                    textBmp.RotateFlip(rotateFlip);

                    // 4. 回転後、Y軸のみ画像との重なりを回避して描画
                    int drawX = (this.ClientSize.Width - textBmp.Width) / 2;
                    int drawY = ((this.ClientSize.Height - textBmp.Height) / 2) + IMAGE_MARGIN;

                    if (this.Image != null)
                    {
                        switch (this.ImageAlign)
                        {
                            case ContentAlignment.TopCenter:
                                drawY = Math.Max(drawY, this.Image.Height + IMAGE_MARGIN);
                                break;

                            case ContentAlignment.BottomCenter:
                                drawY = Math.Min(drawY, this.ClientSize.Height - textBmp.Height - this.Image.Height - IMAGE_MARGIN);
                                break;
                        }
                    }

                    e.Graphics.DrawImage(textBmp, drawX, drawY);
                }
            }
            else
            {
                // 仮の Graphics で文字サイズを取得
                using (Bitmap dummyBmp = new Bitmap(1, 1))
                using (Graphics dummyG = Graphics.FromImage(dummyBmp))
                {
                    SizeF sampleSize = dummyG.MeasureString(drawText, this.Font);
                    int bmpWidth = (int)Math.Ceiling(sampleSize.Width);
                    int bmpHeight = (int)Math.Ceiling(sampleSize.Height);

                    using (Bitmap textBmp = new Bitmap(bmpWidth, bmpHeight))
                    using (Graphics textG = Graphics.FromImage(textBmp))
                    {
                        textG.Clear(Color.Transparent);
                        textG.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;

                        float spacing = (float)bmpWidth / charCount;
                        float totalTextWidth = spacing * charCount;
                        float offsetX = (bmpWidth - totalTextWidth) / 2f;

                        using (Brush brush = new SolidBrush(this.ForeColor))
                        {
                            for (int drawCount = 0; drawCount < charCount; drawCount++)
                            {
                                string ch = drawText[drawCount].ToString();
                                SizeF charSize = textG.MeasureString(ch, this.Font);
                                float x = offsetX + (spacing * drawCount) + ((spacing - charSize.Width) / 2f);
                                float y = (bmpHeight - charSize.Height) / 2f;

                                textG.DrawString(ch, this.Font, brush, x, y);
                            }
                        }

                        // 回転処理
                        RotateFlipType rotateFlip = rotate switch
                        {
                            90 => RotateFlipType.Rotate90FlipNone,
                            180 => RotateFlipType.Rotate180FlipNone,
                            270 or -90 => RotateFlipType.Rotate270FlipNone,
                            _ => RotateFlipType.RotateNoneFlipNone
                        };
                        textBmp.RotateFlip(rotateFlip);

                        // 回転後中央に描画（Y軸のみ画像を考慮）
                        int drawX = (this.ClientSize.Width - textBmp.Width) / 2;
                        int drawY = (this.ClientSize.Height - textBmp.Height) / 2;

                        if (this.Image != null)
                        {
                            switch (this.ImageAlign)
                            {
                                case ContentAlignment.TopCenter:
                                    drawY = Math.Max(drawY, this.Image.Height + IMAGE_MARGIN);
                                    break;

                                case ContentAlignment.BottomCenter:
                                    drawY = Math.Min(drawY, this.ClientSize.Height - textBmp.Height - this.Image.Height - IMAGE_MARGIN);
                                    break;
                            }
                        }

                        e.Graphics.DrawImage(textBmp, drawX, drawY);
                    }
                }
            }
        }

        /// <summary>
        /// 縦書きボタンの描画処理
        /// </summary>
        /// <param name="e">Event</param>
        private void ButtonTextVertiaclDraw(PaintEventArgs e)
        {
            if (string.IsNullOrEmpty(this.Text))
            {
                return;
            }
            using (Brush brush = new SolidBrush(this.ForeColor))
            {
                string drawText = string.Empty;
                if (this.mTextJustify == TextJustifyS.JUSTIFY_WITH_SPACE)
                {
                    drawText = " " + this.Text + " ";
                }
                else
                {
                    drawText = this.Text ?? string.Empty;
                }

                int imageHeight = 0;
                int borderMargin = this.mBorderThick * 2;
                int offsetY = borderMargin;

                //描画不可範囲(ボーダーと画像)
                int nonPortableRange = borderMargin * 2;

                if (this.Image != null)
                {
                    imageHeight = this.Image.Height;
                    if (this.ImageAlign == ContentAlignment.TopCenter)
                    {
                        offsetY = this.Image.Height + borderMargin + IMAGE_MARGIN;
                    }

                    //描画不可範囲に画像領域を追加
                    nonPortableRange += this.Image.Height + IMAGE_MARGIN;
                }

                int textWidth = this.ClientSize.Width;
                int textHeight = this.ClientSize.Height - nonPortableRange;

                // フォントの1行あたりの高さ
                float lineHeight = this.Font.GetHeight(e.Graphics);

                float spacing = lineHeight; // 初期値

                int charCount = drawText.Length;

                //1文字だった場合中央に描画する
                if (this.mTextJustify != TextJustifyS.NONE && charCount > 1)
                {
                    float charHeight = this.Font.GetHeight(e.Graphics);
                    spacing = (textHeight - charHeight) / (charCount - 1);

                    for (int drawCount = 0; drawCount < charCount; drawCount++)
                    {
                        string ch = drawText[drawCount].ToString();
                        SizeF size = e.Graphics.MeasureString(ch, this.Font);
                        float x = (textWidth - size.Width) / 2f;
                        float y = offsetY + (drawCount * spacing);

                        e.Graphics.DrawString(ch, this.Font, brush, x, y);
                    }
                }
                else
                {
                    for (int drawCount = 0; drawCount < charCount; drawCount++)
                    {
                        string ch = drawText[drawCount].ToString();
                        SizeF size = e.Graphics.MeasureString(ch, this.Font);

                        float startY = float.Max((textHeight / 2) - (charCount / 2 * spacing), borderMargin);

                        float x = (textWidth - size.Width) / 2f;
                        float y = startY + offsetY + (drawCount * spacing);

                        //画像領域に文字が重なる場合は描画を終わる
                        if (this.ImageAlign == ContentAlignment.BottomCenter && this.Image != null)
                        {
                            Point imagePos = this.GetImageLocation(this.ImageAlign, this.Image.Size, this.ClientRectangle);
                            if (y + size.Height > imagePos.Y)
                            {
                                break;
                            }
                        }

                        e.Graphics.DrawString(ch, this.Font, brush, x, y);
                    }
                }
            }
        }

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

            //ボタンのスタイルを設定
            this.FlatStyle = FlatStyle.Flat;             // 枠無し
            this.FlatAppearance.BorderSize = 0;          // デフォルトのボーダー幅をゼロに
            this.SetStyle(
                          ControlStyles.AllPaintingInWmPaint |
                          ControlStyles.OptimizedDoubleBuffer |
                          ControlStyles.ResizeRedraw |
                           ControlStyles.SupportsTransparentBackColor |
                          ControlStyles.UserPaint, true);
            this.UpdateStyles();

            //イベントの設定
            this.MouseEnter -= this.RdtButton_MouseEnter;
            this.MouseEnter += this.RdtButton_MouseEnter;

            this.MouseUp -= this.RdtButton_MouseUp;
            this.MouseUp += this.RdtButton_MouseUp;

            this.MouseDown -= this.RdtButton_MouseDown;
            this.MouseDown += this.RdtButton_MouseDown;

            this.MouseLeave -= this.RdtButton_MouseLeave;
            this.MouseLeave += this.RdtButton_MouseLeave;

            this.BackColorChanged -= this.RdtButton_BackColorChanged;
            this.BackColorChanged += this.RdtButton_BackColorChanged;
        }

        private void DisposeCustomSetting()
        {
            if (this.Image != null)
            {
                this.Image.Dispose();
            }
        }

        #region 現在調査中
        private void DrawBorder(PaintEventArgs e)
        {
            //外枠用
            Rectangle outerRect = this.ClientRectangle;
            outerRect.X += int.Max((this.mBorderThick / 2) - 1, 0);
            outerRect.Y += int.Max((this.mBorderThick / 2) - 1, 0);
            outerRect.Width -= int.Max(this.mBorderThick - 1, 1);
            outerRect.Height -= int.Max(this.mBorderThick - 1, 1);

            //内枠用
            Rectangle innerRect = this.ClientRectangle;
            innerRect = outerRect;
            innerRect.X = this.mBorderThick - 1;
            innerRect.Y = this.mBorderThick - 1;
            innerRect.Width -= this.mBorderThick;
            innerRect.Height -= this.mBorderThick;

            //内枠から描画する
            using (Pen pen = new Pen(ColorTranslator.FromHtml(this.mInnerBorderColor), this.mBorderThick * 2))
            {
                using (GraphicsPath path = ComponentCommon.GetRoundRectanglePath(innerRect, this.mCornerRadius))
                {
                    e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                    e.Graphics.DrawPath(pen, path);
                }
            }

            using (Pen pen = new Pen(ColorTranslator.FromHtml(this.mOuterBorderColor), this.mBorderThick))
            {
                using (GraphicsPath path = ComponentCommon.GetRoundRectanglePath(outerRect, this.CornerRadius))
                {
                    e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                    e.Graphics.DrawPath(pen, path);
                }
            }
        }

        /// <summary>
        /// MouseHover
        /// </summary>
        /// <param name="e">event</param>
        private void RdtButton_MouseEnter(object? sender, EventArgs e)
        {
            this.mBackColor = this.mMouseHoverColor;
            this.Invalidate();
        }

        /// <summary>
        /// マウスボタン押下時イベント
        /// </summary>
        /// <param name="e">event</param>
        private void RdtButton_MouseDown(object? sender, EventArgs e)
        {
            this.mBackColor = this.mMouseClickColor;
            this.Invalidate();
        }

        /// <summary>
        /// マウスボタン押下解除時イベント
        /// </summary>
        /// <param name="e">event</param>
        private void RdtButton_MouseUp(object? sender, EventArgs e)
        {
            this.mBackColor = this.mMouseHoverColor;
            this.Invalidate();
        }

        /// <summary>
        /// マウスホバー解除時イベント
        /// </summary>
        /// <param name="e">event</param>
        private void RdtButton_MouseLeave(object? sender, EventArgs e)
        {
            Color backColor = this.BackColor;
            string colorCode = $"#{backColor.R:X2}{backColor.G:X2}{backColor.B:X2}";
            this.mBackColor = colorCode;
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

        /// <summary>
        /// 画像の描画位置を設定する
        /// </summary>
        /// <param name="align">場所</param>
        /// <param name="imageSize">画像サイズ</param>
        /// <param name="clientRect">ボタンのサイズ</param>
        /// <returns>座標</returns>
        private Point GetImageLocation(ContentAlignment align, Size imageSize, Rectangle clientRect)
        {
            int x = align switch
            {
                ContentAlignment.TopLeft or ContentAlignment.MiddleLeft or ContentAlignment.BottomLeft
                    => clientRect.Left + 4 + (this.mBorderThick * 2),
                ContentAlignment.TopCenter or ContentAlignment.MiddleCenter or ContentAlignment.BottomCenter
                    => clientRect.Left + ((clientRect.Width - imageSize.Width) / 2),
                ContentAlignment.TopRight or ContentAlignment.MiddleRight or ContentAlignment.BottomRight
                    => clientRect.Right - imageSize.Width - 4 - (this.mBorderThick * 2),
                _ => clientRect.Left
            };

            int y = align switch
            {
                ContentAlignment.TopLeft or ContentAlignment.TopCenter or ContentAlignment.TopRight
                    => clientRect.Top + 4 + (this.mBorderThick * 2),
                ContentAlignment.MiddleLeft or ContentAlignment.MiddleCenter or ContentAlignment.MiddleRight
                    => clientRect.Top + ((clientRect.Height - imageSize.Height) / 2),
                ContentAlignment.BottomLeft or ContentAlignment.BottomCenter or ContentAlignment.BottomRight
                    => clientRect.Bottom - imageSize.Height - 4 - (this.mBorderThick * 2),
                _ => clientRect.Top
            };

            return new Point(x, y);
        }

        #endregion
    }
}