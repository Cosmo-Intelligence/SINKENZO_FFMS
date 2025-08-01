// -----------------------------------------------------------------------
// <copyright file="RdtThumbnailView.cs" company="FUJIFILM Medical Solutions Corporation">
// Copyright (C) 2025 FUJIFILM Medical Solutions Corporation.
// </copyright>
// -----------------------------------------------------------------------

using System.ComponentModel;
using log4net;

namespace RADISTA.UIComponent.CustomControl
{
    public partial class RdtThumbnailView : FlowLayoutPanel
    {
        #region "列挙型"
        /// <summary>
        /// オーバーレイのアイコン位置
        /// </summary>
        public enum IconPlacementT
        {
            /// <summary>
            /// 左上
            /// </summary>
            LEFT_TOP = 1,
            /// <summary>
            /// 右上
            /// </summary>
            RIGHT_TOP = 2,
            /// <summary>
            /// 左下
            /// </summary>
            LEFT_BOTTOM = 3,
            /// <summary>
            /// 右下
            /// </summary>
            RIGHT_BOTTOM = 4,
            /// <summary>
            /// 中央
            /// </summary>
            CENTER = 5,
        }
        #endregion

        #region "定数"
        private const string IMAGE = "イメージ";
        private const string IMAGE_SIZE = "イメージサイズ";
        private const string COLOR = "カラー";

        //パネル名
        private const string MAIN_PANEL = "mainPanel";
        private const string MAIN_PICTURE_BOX = "mainPic";
        private const string DELETE_OVERLAY = "deleteOverlay";
        private const string MULTI_FRAME_OVERLAY = "multiOverlay";
        #endregion

        #region "メンバ変数"
        private static readonly ILog mLog = LogManager.GetLogger(typeof(RdtButton));

        //ドラッグアンドドロップや複数選択用
        private Panel? mBeforeSelectedPanel = null;
        private bool mIsBeforeCtrl;
        private List<Panel> mSelectedPanels = new List<Panel>();
        private Point mDragStartPoint;

        //色関連
        private string mPanelBackColor = "#363636";
        private string mPanelHoverColor = "#FF00FF";
        private string mSelectedBackColor = "#00FFFF";

        //画像関連
        private Point mImageMargin = new Point(0, 0);
        private Image? mDeleteImage = null;
        private Image? mMultiFrameImage = null;
        private Image? mLargeDeleteImage = null;
        private Image? mLargeMultiFrameImage = null;
        private IconPlacementT mDeleteIconPlacement = IconPlacementT.LEFT_TOP;
        private IconPlacementT mMultiIconPlacement = IconPlacementT.LEFT_TOP;
        private bool mUseLargeIcon = false;

        //画像サイズ関係
        private bool mIsResize = false;
        private Size mBaseImageSize = new Size(0, 0);
        private bool mIsOverlayResize = false;
        private Size mOverlayImageSize = new Size(0, 0);

        //ファイルパス
        private List<string> mImageFilePathList = new List<string>();
        private string mMultiFrameFilePath = string.Empty;
        private string mDeleteImageFilePath = string.Empty;
        private string mLargeDeleteImageFilePath = string.Empty;
        private string mLargeMultiFrameFilePath = string.Empty;
        #endregion

        #region "プロパティ"
        /// <summary>
        /// オーバーレイアイコンの場所
        /// </summary>
        [Category(IMAGE)]
        public IconPlacementT DeleteIconPlacement
        {
            get => this.mDeleteIconPlacement;
            set
            {
                this.mDeleteIconPlacement = value;
                this.ChangeOverlayLocation();
            }
        }

        /// <summary>
        /// オーバーレイアイコンの場所
        /// </summary>
        [Category(IMAGE)]
        public IconPlacementT MultiIconPlacement
        {
            get => this.mMultiIconPlacement;
            set
            {
                this.mMultiIconPlacement = value;
                this.ChangeOverlayLocation();
            }
        }

        /// <summary>
        /// 削除時アイコンのファイルパス
        /// </summary>
        [Category(IMAGE)]
        public string DeleteImageFilePath
        {
            get => this.mDeleteImageFilePath;
            set => this.mDeleteImageFilePath = value;
        }

        /// <summary>
        /// オーバーレイ画像のファイルパス
        /// </summary>
        [Category(IMAGE)]
        public string MultiFrameFilePath
        {
            get => this.mMultiFrameFilePath;
            set => this.mMultiFrameFilePath = value;
        }

        /// <summary>
        /// 削除時アイコンのファイルパス
        /// </summary>
        [Category(IMAGE)]
        public string LargeDeleteImageFilePath
        {
            get => this.mLargeDeleteImageFilePath;
            set => this.mLargeDeleteImageFilePath = value;
        }

        /// <summary>
        /// オーバーレイ画像のファイルパス
        /// </summary>
        [Category(IMAGE)]
        public string LargeMultiFrameFilePath
        {
            get => this.mLargeMultiFrameFilePath;
            set => this.mLargeMultiFrameFilePath = value;
        }

        /// <summary>
        /// ラージアイコンを使用するかどうか
        /// <para>
        /// trueで使用 falseで不使用 デフォルトはfalse
        /// </para>
        /// </summary>
        [Category(IMAGE)]
        public bool UseLargeIcon
        {
            get => this.mUseLargeIcon;
            set => this.mUseLargeIcon = value;
        }

        /// <summary>
        /// 画像毎の間隔
        /// </summary>
        [Category(IMAGE)]
        public Point ImageMargin
        {
            get => this.mImageMargin;
            set => this.mImageMargin = value;
        }

        /// <summary>
        /// サムネイル画像をリサイズするか設定する
        /// <para>
        /// tureでリサイズ falseで画像サイズ デフォルトはfalse
        /// </para>
        /// </summary>
        [Category(IMAGE_SIZE)]
        public bool IsResize
        {
            get => this.mIsResize;
            set => this.mIsResize = value;
        }

        /// <summary>
        /// 画像サイズの基準を設定する
        /// <para>
        /// IsResizeがtrueときのみ有効
        /// </para>
        /// </summary>
        [Category(IMAGE_SIZE)]
        public Size BaseImageSize
        {
            get => this.mBaseImageSize;
            set => this.mBaseImageSize = value;
        }

        /// <summary>
        /// オーバーレイ画像をリサイズするか設定する
        /// <para>
        /// tureでリサイズ falseで画像サイズ デフォルトはfalse
        /// </para>
        /// </summary>
        [Category(IMAGE_SIZE)]
        public bool IsOverlayResize
        {
            get => this.mIsOverlayResize;
            set => this.mIsOverlayResize = value;
        }

        /// <summary>
        /// オーバーレイ画像サイズの基準を設定する
        /// <para>
        /// IsResizeがtrueときのみ有効
        /// </para>
        /// </summary>
        [Category(IMAGE_SIZE)]
        public Size OverlayImageSize
        {
            get => this.mOverlayImageSize;
            set => this.mOverlayImageSize = value;
        }

        /// <summary>
        /// サムネイルのバックカラー
        /// </summary>
        [Category(COLOR)]
        public string PanelBackColor
        {
            get => this.mPanelBackColor;
            set
            {
                // デザイナのプロパティで入力ミスがあった場合は直接エラーメッセージを出す
                if (!ComponentCommon.IsColorCode(value))
                {
                    throw new ArgumentException(Constants.ERROR_COLOR_CODE);
                }
                this.mPanelBackColor = value;
            }
        }

        /// <summary>
        /// ホバーカラー
        /// </summary>
        [Category(COLOR)]
        public string PanelHoverColor
        {
            get => this.mPanelHoverColor;
            set
            {
                // デザイナのプロパティで入力ミスがあった場合は直接エラーメッセージを出す
                if (!ComponentCommon.IsColorCode(value))
                {
                    throw new ArgumentException(Constants.ERROR_COLOR_CODE);
                }
                this.mPanelHoverColor = value;
            }
        }

        /// <summary>
        /// 選択時背景色
        /// </summary>
        [Category(COLOR)]
        public string SelectedBackColor
        {
            get => this.mSelectedBackColor;
            set
            {
                // デザイナのプロパティで入力ミスがあった場合は直接エラーメッセージを出す
                if (!ComponentCommon.IsColorCode(value))
                {
                    throw new ArgumentException(Constants.ERROR_COLOR_CODE);
                }
                this.mSelectedBackColor = value;
            }
        }

        #endregion

        #region "パブリックメソッド"
        /// <summary>
        /// Initialize
        /// </summary>
        public RdtThumbnailView()
        {
            this.InitializeComponent();
            this.InitializeCustomSetting();
        }

        /// <summary>
        /// Initialize
        /// </summary>
        /// <param name="container">container</param>
        public RdtThumbnailView(IContainer container)
        {
            container.Add(this);

            this.InitializeComponent();
            this.InitializeCustomSetting();
        }

        /// <summary>
        /// 画像をまとめて追加する
        /// </summary>
        /// <param name="imagePaths">画像のファイルパス</param>
        /// <param name="isValidate">
        /// 再描画を行うかどうか
        /// <para>
        /// デフォルトはtrue(再描画)、falseを指定で再描画はなし
        /// </para>
        /// </param>
        public void AddImagePaths(List<string> imagePaths, bool isValidate = true)
        {
            if (imagePaths == null)
            {
                return;
            }

            //パネルの名前を決める用
            int panelCount = this.Controls.Count + 1;

            foreach (var imagePath in imagePaths)
            {
                if (!string.IsNullOrEmpty(imagePath))
                {
                    this.mImageFilePathList.Add(imagePath);
                }
            }

            foreach (string path in this.mImageFilePathList)
            {
                Panel? imagePanel = this.CreateImagePanel(path, this.mImageMargin.X, this.mImageMargin.Y, panelCount);
                if (imagePanel == null)
                {
                    continue;
                }
                imagePanel.Name = panelCount.ToString();
                imagePanel.BackColor = ColorTranslator.FromHtml(this.mPanelBackColor);
                this.Controls.Add(imagePanel);
                panelCount++;
            }

            if (isValidate)
            {
                this.Invalidate();
            }
        }

        /// <summary>
        /// 画像を追加する
        /// </summary>
        /// <param name="imagePath">画像のファイルパス</param>
        /// <param name="isValidate"> 再描画を行うかどうか
        /// <para>
        /// デフォルトはtrue(再描画)、falseを指定で再描画はなし
        /// </para>
        /// </param>
        public void AddImagePath(string imagePath, bool isValidate = true)
        {
            if (string.IsNullOrEmpty(imagePath))
            {
                return;
            }
            this.mImageFilePathList.Add(imagePath);

            //パネルの名前を決める用
            int panelCount = this.Controls.Count + 1;

            Panel? imagePanel = this.CreateImagePanel(imagePath, this.mImageMargin.X, this.mImageMargin.Y, panelCount);
            if (imagePanel == null)
            {
                return;
            }

            imagePanel.Name = panelCount.ToString();

            this.Controls.Add(imagePanel);

            if (isValidate)
            {
                this.Invalidate();
            }
        }

        /// <summary>
        /// 選択している画像に削除マークを表示する
        /// </summary>
        public void ShowDeleteOverlay()
        {
            Image? image = this.mUseLargeIcon ? this.mLargeDeleteImage : this.mDeleteImage;
            if (image == null)
            {
                mLog.Debug(this.mUseLargeIcon ? "mLargeDeleteImage is null" : "mDeleteImage is null");
                return;
            }

            foreach (var mainPanel in this.mSelectedPanels)
            {
                var mainPic = mainPanel.Controls.Find(MAIN_PICTURE_BOX, false).FirstOrDefault();
                if (mainPic == null)
                {
                    continue;
                }

                //すでに存在していた場合は削除
                var existing = mainPic.Controls.Find(DELETE_OVERLAY, false).FirstOrDefault();
                if (existing != null)
                {
                    mainPic.Controls.Remove(existing);
                    //イベントハンドラの解除
                    this.DetachEvents(existing);

                    existing.Dispose();
                }

                var overlay = new PictureBox
                {
                    Name = DELETE_OVERLAY,
                    Size = image.Size,
                    Location = this.GetOverlayLocation(mainPic, image.Size, this.mDeleteIconPlacement),
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    BackColor = Color.Transparent,
                    Image = image,
                    AllowDrop = true,
                };

                this.AttachEvents(overlay);

                mainPic.Controls.Add(overlay);

                // MultiOverlay と同位置なら非表示にする
                var multi = mainPic.Controls.Find(MULTI_FRAME_OVERLAY, false).FirstOrDefault();
                if (multi != null && this.mMultiIconPlacement == this.mDeleteIconPlacement)
                {
                    multi.Visible = false;
                }
            }
        }

        /// <summary>
        /// 選択している画像にマルチフレームマークを表示する
        /// </summary>
        public void ShowMultiFrameOverlay()
        {
            Image? image = this.mUseLargeIcon ? this.mLargeMultiFrameImage : this.mMultiFrameImage;
            if (image == null)
            {
                mLog.Debug(this.mUseLargeIcon ? "mLargeMultiFrameImage is null" : "mMultiFrameImage is null");
                return;
            }

            foreach (var mainPanel in this.mSelectedPanels)
            {
                var mainPic = mainPanel.Controls.Find(MAIN_PICTURE_BOX, false).FirstOrDefault();
                if (mainPic == null)
                {
                    continue;
                }

                // 既存オーバーレイ削除
                var existingOverlay = mainPic.Controls.Find(MULTI_FRAME_OVERLAY, false).FirstOrDefault();
                if (existingOverlay != null)
                {
                    mainPic.Controls.Remove(existingOverlay);
                    existingOverlay.Dispose();
                }

                // 表示する画像とサイズ
                var boxSize = image.Size;

                // オーバーレイ作成
                var overlay = new PictureBox
                {
                    Name = MULTI_FRAME_OVERLAY,
                    Size = boxSize,
                    Location = this.GetOverlayLocation(mainPic, boxSize, this.mMultiIconPlacement),
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    BackColor = Color.Transparent,
                    Image = image,
                    AllowDrop = true,
                };

                // イベント登録
                this.DetachEvents(overlay);
                this.AttachEvents(overlay);

                mainPic.Controls.Add(overlay);

                // DeleteOverlay と位置が重複していたら非表示
                bool hasDelete = mainPic.Controls.Find(DELETE_OVERLAY, false).Any();
                if (hasDelete && this.mDeleteIconPlacement == this.mMultiIconPlacement)
                {
                    overlay.Visible = false;
                }
            }
        }

        /// <summary>
        /// マルチフレームアイコンのオーバーレイ画像を削除する
        /// </summary>
        public void RemoveMultiFrameOverlay()
        {
            this.RemoveOverlay(MULTI_FRAME_OVERLAY);
            return;
        }

        /// <summary>
        /// 削除アイコンのオーバーレイ画像を削除する
        /// </summary>
        public void RemoveDeleteOverlay()
        {
            this.RemoveOverlay(DELETE_OVERLAY);
            return;
        }

        #endregion

        #region "プロテクテッドメソッド"
        /// <summary>
        /// OnCreateControl
        /// </summary>
        protected override void OnCreateControl()
        {
            base.OnCreateControl();

            try
            {
                if (string.IsNullOrEmpty(this.mDeleteImageFilePath) == false)
                {
                    this.mDeleteImage = ComponentCommon.GetImageFromPath(this.mDeleteImageFilePath);
                }
            }
            catch (Exception ex)
            {
                mLog.Error("mDeleteImageFilePath load is failed");
                mLog.Error(ex);
            }

            try
            {
                if (string.IsNullOrEmpty(this.mLargeDeleteImageFilePath) == false)
                {
                    this.mLargeDeleteImage = ComponentCommon.GetImageFromPath(this.mLargeDeleteImageFilePath);
                }
            }
            catch (Exception ex)
            {
                mLog.Error("mLargeDeleteImageFilePath load is failed");
                mLog.Error(ex);
            }

            try
            {
                if (string.IsNullOrEmpty(this.mMultiFrameFilePath) == false)
                {
                    this.mMultiFrameImage = ComponentCommon.GetImageFromPath(this.mMultiFrameFilePath);
                }
            }
            catch (Exception ex)
            {
                mLog.Error("mMultiFrameFilePath load is failed");
                mLog.Error(ex);
            }

            try
            {
                if (string.IsNullOrEmpty(this.mLargeMultiFrameFilePath) == false)
                {
                    this.mLargeMultiFrameImage = ComponentCommon.GetImageFromPath(this.mLargeMultiFrameFilePath);
                }
            }
            catch (Exception ex)
            {
                mLog.Error("mLargeMultiFrameFilePath load is failed");
                mLog.Error(ex);
            }
        }
        #endregion

        #region "プライベートメソッド"

        /// <summary>
        /// Initialize
        /// </summary>
        private void InitializeCustomSetting()
        {
            //this.Dock = DockStyle.Fill;
            this.AutoScroll = true;
            this.Padding = new Padding(10);
            this.WrapContents = true;
            this.FlowDirection = FlowDirection.LeftToRight;
            this.AllowDrop = true;

            this.mBeforeSelectedPanel = null;
            this.mIsBeforeCtrl = false;
        }

        /// <summary>
        /// Dispose
        /// </summary>
        /// <summary>
        /// オーバーレイ・画像・イベントなどのリソースを解放する
        /// </summary>
        private void DisposeCustomSetting()
        {
            // 使用画像のDispose
            this.mDeleteImage?.Dispose();
            this.mDeleteImage = null;

            this.mMultiFrameImage?.Dispose();
            this.mMultiFrameImage = null;

            this.mLargeDeleteImage?.Dispose();
            this.mLargeDeleteImage = null;

            this.mLargeMultiFrameImage?.Dispose();
            this.mLargeMultiFrameImage = null;

            // パネル内部のコントロールを解放
            foreach (Panel mainPanel in this.Controls.OfType<Panel>().ToList())
            {
                foreach (Control child in mainPanel.Controls.OfType<Control>().ToList())
                {
                    // 数字ラベルの処理
                    if (child is Label lblNumber)
                    {
                        this.DetachEvents(lblNumber);
                        mainPanel.Controls.Remove(lblNumber);
                        lblNumber.Dispose();
                    }

                    // メイン画像とそのオーバーレイの処理
                    else if (child is PictureBox mainPic)
                    {
                        // オーバーレイを解放
                        foreach (var overlay in mainPic.Controls.OfType<PictureBox>().ToList())
                        {
                            this.DetachEvents(overlay);
                            overlay.Image?.Dispose();
                            overlay.Image = null;
                            mainPic.Controls.Remove(overlay);
                            overlay.Dispose();
                        }

                        // mainPic自体の解放
                        this.DetachEvents(mainPic);
                        mainPic.Image?.Dispose();
                        mainPic.Image = null;
                        mainPanel.Controls.Remove(mainPic);
                        mainPic.Dispose();
                    }
                }

                // パネル自体の解放
                this.DetachEvents(mainPanel);
                this.Controls.Remove(mainPanel);
                mainPanel.Dispose();
            }
        }

        /// <summary>
        /// イベントを削除する
        /// </summary>
        private void DetachEvents(Control control)
        {
            control.Click -= this.Control_Click;
            control.MouseDown -= this.Contorl_MouseDown;
            control.MouseMove -= this.Control_MouseMove;
            control.MouseHover -= this.Control_MouseHover;
            control.MouseLeave -= this.Control_MouseLeave;
            control.DragEnter -= this.Control_DragEnter;
            control.DragDrop -= this.Control_DragDrop;
        }

        /// <summary>
        /// イベントを追加する
        /// </summary>
        private void AttachEvents(Control control)
        {
            this.DetachEvents(control);

            control.Click += this.Control_Click;
            control.MouseDown += this.Contorl_MouseDown;
            control.MouseMove += this.Control_MouseMove;
            control.MouseHover += this.Control_MouseHover;
            control.MouseLeave += this.Control_MouseLeave;
            control.DragEnter += this.Control_DragEnter;
            control.DragDrop += this.Control_DragDrop;
        }

        private void Control_MouseLeave(object? sender, EventArgs e)
        {
            if (sender == null)
            {
                return;
            }

            Control clicked = (Control)sender;

            Panel? clickedPanel = clicked as Panel ?? clicked?.Parent as Panel;
            if (clickedPanel == null)
            {
                return;
            }

            if (this.mSelectedPanels.Find(r => r.Name == clickedPanel.Name) != null)
            {
                return;
            }

            clickedPanel.BackColor = ColorTranslator.FromHtml(this.mPanelBackColor);
        }

        private void Control_MouseHover(object? sender, EventArgs e)
        {
            if (sender == null)
            {
                return;
            }

            Control clicked = (Control)sender;

            Panel? clickedPanel = clicked as Panel ?? clicked?.Parent as Panel;
            if (clickedPanel == null)
            {
                return;
            }

            if (this.mSelectedPanels.Find(r => r.Name == clickedPanel.Name) != null)
            {
                return;
            }

            clickedPanel.BackColor = ColorTranslator.FromHtml(this.mPanelHoverColor);
        }

        /// <summary>
        /// メインのサムネイルパネルを作成する
        /// </summary>
        /// <param name="imagePath">画像のファイルパス</param>
        /// <param name="marginX">パネル間の間隔(X)</param>
        /// <param name="marginY">パネル間の間隔(Y)</param>
        /// <param name="number">パネルの下に表示する番号</param>
        /// <returns>サムネイルをまとめたパネル</returns>
        private Panel? CreateImagePanel(string imagePath, int marginX, int marginY, int number)
        {
            Image? image = null;

            try
            {
                if (string.IsNullOrEmpty(imagePath) == false)
                {
                    image = ComponentCommon.GetImageFromPath(imagePath);
                }
            }
            catch (Exception ex)
            {
                mLog.Error("mDeleteImageFilePath load is failed");
                mLog.Error(ex);
            }

            if (image == null)
            {
                return null;
            }
            if (this.mIsResize == true)
            {
                image = new Bitmap(image, this.mBaseImageSize);
            }

            PictureBox mainPic = new PictureBox
            {
                Name = MAIN_PICTURE_BOX,
                Size = new Size(image.Width, image.Height),
                Location = new Point(2, 2),
                Image = image,
                SizeMode = PictureBoxSizeMode.StretchImage,
                BackColor = Color.Transparent,
            };

            Label lblNumber = new Label
            {
                Text = number.ToString(),
                TextAlign = ContentAlignment.MiddleCenter,
                Size = new Size(image.Width, 16),
                Location = new Point(0, mainPic.Height),
                Font = new Font("Arial", 10, FontStyle.Bold),
            };

            Panel mainPanel = new Panel
            {
                Name = MAIN_PANEL,
                Size = new Size(mainPic.Size.Width + 4, mainPic.Size.Height + lblNumber.Size.Height + 2),
                Margin = new Padding(2, 2, marginX, marginY),
                BackColor = Color.Transparent,
                Tag = number,
            };

            mainPanel.AllowDrop = true;
            lblNumber.AllowDrop = true;

            // クリック選択イベント
            this.DetachEvents(mainPanel);
            this.AttachEvents(mainPanel);

            this.DetachEvents(mainPic);
            this.AttachEvents(mainPic);

            this.DetachEvents(lblNumber);
            this.AttachEvents(lblNumber);

            mainPanel.Controls.Add(mainPic);
            mainPanel.Controls.Add(lblNumber);

            return mainPanel;
        }

        /// <summary>
        /// オーバーレイアイコンの場所を取得する
        /// </summary>
        /// <param name="mainPic">サムネイル画像のImageBox</param>
        /// <param name="imageSize">画像サイズ</param>
        /// <param name="placement">アイコンの場所</param>
        /// <returns>アイコンの座標</returns>
        private Point GetOverlayLocation(Control mainPic, Size imageSize, IconPlacementT placement)
        {
            Point location = new Point(0, 0);

            switch (placement)
            {
                case IconPlacementT.LEFT_TOP:
                    {
                        location.X = 2;
                        location.Y = 2;
                        break;
                    }
                case IconPlacementT.RIGHT_TOP:
                    {
                        location.X = mainPic.Width - imageSize.Width - 2;
                        location.Y = 2;
                        break;
                    }
                case IconPlacementT.LEFT_BOTTOM:
                    {
                        location.X = 2;
                        location.Y = mainPic.Height - imageSize.Height - 2;
                        break;
                    }
                case IconPlacementT.RIGHT_BOTTOM:
                    {
                        location.X = mainPic.Width - imageSize.Width - 2;
                        location.Y = mainPic.Height - imageSize.Height - 2;
                        break;
                    }
                case IconPlacementT.CENTER:
                    {
                        location.X = (mainPic.Width - imageSize.Width) / 2;
                        location.Y = (mainPic.Height - imageSize.Height) / 2;
                        break;
                    }
                default:
                    {
                        location.X = 2;
                        location.Y = 2;
                        break;
                    }
            }

            return location;
        }

        /// <summary>
        /// オーバーレイの場所を変更する
        /// </summary>
        private void ChangeOverlayLocation()
        {
            foreach (Panel mainPanel in this.Controls)
            {
                var mainPic = mainPanel.Controls.Find(MAIN_PICTURE_BOX, false).FirstOrDefault();
                if (mainPic == null)
                {
                    continue;
                }

                var deleteOverlay = mainPic.Controls.Find(DELETE_OVERLAY, false).FirstOrDefault() as PictureBox;
                var multiOverlay = mainPic.Controls.Find(MULTI_FRAME_OVERLAY, false).FirstOrDefault() as PictureBox;

                if (deleteOverlay != null)
                {
                    deleteOverlay.Location = this.GetOverlayLocation(mainPic, deleteOverlay.Image.Size, this.mDeleteIconPlacement);
                }

                if (multiOverlay != null)
                {
                    multiOverlay.Location = this.GetOverlayLocation(mainPic, multiOverlay.Image.Size, this.mMultiIconPlacement);

                    multiOverlay.Visible = !(deleteOverlay != null && this.mMultiIconPlacement == this.mDeleteIconPlacement);
                }
            }
        }

        /// <summary>
        /// 指定された名前のオーバーレイを削除する
        /// </summary>
        private void RemoveOverlay(string overlayName)
        {
            foreach (var mainPanel in this.mSelectedPanels)
            {
                if (mainPanel == null)
                {
                    continue;
                }

                var mainPic = mainPanel.Controls.Find(MAIN_PICTURE_BOX, false).FirstOrDefault();
                if (mainPic == null)
                {
                    continue;
                }

                var overlay = mainPic.Controls.Find(overlayName, false).FirstOrDefault();
                if (overlay == null)
                {
                    continue;
                }

                mainPic.Controls.Remove(overlay);

                // イベントハンドラの解除
                this.DetachEvents(overlay);

                overlay.Dispose();
            }
        }

        /// <summary>
        /// パネルのクリックイベント
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">Event</param>
        private void Control_Click(object? sender, EventArgs e)
        {
            if (sender is not Control clicked)
            {
                return;
            }

            Panel? clickedPanel = clicked as Panel ?? clicked.Parent as Panel;
            if (clickedPanel == null)
            {
                return;
            }

            bool isCtrl = (ModifierKeys & Keys.Control) == Keys.Control;
            bool isShift = (ModifierKeys & Keys.Shift) == Keys.Shift;

            // Ctrlのみ押下
            if (isCtrl && !isShift)
            {
                bool isSelected = this.mSelectedPanels.Contains(clickedPanel);
                clickedPanel.BackColor = ColorTranslator.FromHtml(isSelected ? this.mPanelBackColor : this.mSelectedBackColor);

                if (isSelected)
                {
                    this.mSelectedPanels.Remove(clickedPanel);
                }
                else
                {
                    this.mSelectedPanels.Add(clickedPanel);
                }

                this.mBeforeSelectedPanel = clickedPanel;
                this.mIsBeforeCtrl = true;
                return;
            }

            // Shiftのみ押下
            if (isShift && !isCtrl)
            {
                //前回選択したパネルが無ければreturn
                if (this.mBeforeSelectedPanel == null)
                {
                    return;
                }

                //パネルのインデックス取得
                int clickedIndex = this.Controls.GetChildIndex(clickedPanel);
                int beforeClickedIndex = this.Controls.GetChildIndex(this.mBeforeSelectedPanel);

                int start = Math.Min(clickedIndex, beforeClickedIndex);
                int end = Math.Max(clickedIndex, beforeClickedIndex);

                //前回がCtrlで選択していない場合一度全ての選択を解除
                if (!this.mIsBeforeCtrl)
                {
                    foreach (var p in this.mSelectedPanels)
                    {
                        p.BackColor = ColorTranslator.FromHtml(this.mPanelBackColor);
                    }
                    this.mSelectedPanels.Clear();
                }

                //選択範囲にあるパネルを全て選択状態にする
                for (int panelIndex = start; panelIndex <= end; panelIndex++)
                {
                    if (this.Controls[panelIndex].GetType() == typeof(Panel))
                    {
                        Panel panel = (Panel)this.Controls[panelIndex];
                        this.Controls[panelIndex].BackColor = ColorTranslator.FromHtml(this.mSelectedBackColor);
                        this.mSelectedPanels.Add(panel);
                    }
                }

                this.mIsBeforeCtrl = false;
                return;
            }

            // Ctrl/Shiftどちらも押していない場合
            foreach (var panel in this.mSelectedPanels)
            {
                panel.BackColor = ColorTranslator.FromHtml(this.mPanelBackColor);
            }

            this.mSelectedPanels.Clear();

            clickedPanel.BackColor = ColorTranslator.FromHtml(this.mSelectedBackColor);
            this.mSelectedPanels.Add(clickedPanel);
            this.mBeforeSelectedPanel = clickedPanel;
            this.mIsBeforeCtrl = false;
        }

        /// <summary>
        /// パネルのマウスクリックイベント
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">Event</param>
        private void Contorl_MouseDown(object? sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.mDragStartPoint = e.Location;
            }
        }

        /// <summary>
        /// パネルのマウス移動イベント
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">Event</param>
        private void Control_MouseMove(object? sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left &&
                (Math.Abs(e.X - this.mDragStartPoint.X) >= SystemInformation.DragSize.Width ||
                 Math.Abs(e.Y - this.mDragStartPoint.Y) >= SystemInformation.DragSize.Height))
            {
                if (this.mSelectedPanels.Count > 0)
                {
                    this.DoDragDrop(this.mSelectedPanels, DragDropEffects.Move);
                }
            }
        }

        /// <summary>
        /// パネルのドラッグイベント
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">Event</param>
        private void Control_DragEnter(object? sender, DragEventArgs e)
        {
            if (e == null || e.Data == null)
            {
                return;
            }
            if (e.Data.GetDataPresent(typeof(List<Panel>)))
            {
                e.Effect = DragDropEffects.Move;
            }
        }

        /// <summary>
        /// パネルのドラッグドロップイベント
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">Event</param>
        private void Control_DragDrop(object? sender, DragEventArgs e)
        {
            if (e == null || e.Data == null)
            {
                return;
            }

            if (!e.Data.GetDataPresent(typeof(List<Panel>)))
            {
                return;
            }

            Panel? dropTarget = sender as Panel;
            if (dropTarget == null)
            {
                return;
            }

            var draggedPanels = e.Data.GetData(typeof(List<Panel>)) as List<Panel>;
            if (draggedPanels == null || draggedPanels.Count == 0)
            {
                return;
            }

            // ドロップ先がドラッグ対象に含まれていたら中止
            if (draggedPanels.Contains(dropTarget))
            {
                return;
            }

            var controls = this.Controls;

            int dropIndex = controls.GetChildIndex(dropTarget);
            int minDragIndex = this.Controls.Count;

            //一番左にあるコントロールのインデックスを取得
            foreach (Panel panel in draggedPanels)
            {
                minDragIndex = Math.Min(controls.GetChildIndex(panel), minDragIndex);
            }

            if (dropIndex > minDragIndex)
            {
                draggedPanels = draggedPanels
                .OrderByDescending(p => this.Controls.GetChildIndex(p)).ToList();
            }

            // 入れ替え処理
            foreach (Panel panel in draggedPanels)
            {
                int dragIndex = controls.GetChildIndex(panel);

                int relativeIndex = dragIndex - minDragIndex;

                int targetIndex = dropIndex + relativeIndex;

                Control tempDrag = controls[dragIndex];

                //もし入れ替え先が配列範囲外だった場合、最後尾へ移動する
                if (targetIndex >= controls.Count)
                {
                    controls.RemoveAt(dragIndex);
                    controls.Add(tempDrag);

                    continue;
                }

                Control tempDrop = this.Controls[targetIndex];

                // 順序のズレを避けるため一旦削除（高い順から）
                if (targetIndex > dragIndex)
                {
                    controls.RemoveAt(targetIndex);
                    controls.RemoveAt(dragIndex);
                    controls.Add(tempDrop);
                    controls.SetChildIndex(tempDrop, dragIndex);
                    controls.Add(tempDrag);
                    controls.SetChildIndex(tempDrag, targetIndex);
                }
                else
                {
                    controls.RemoveAt(dragIndex);
                    controls.RemoveAt(targetIndex);
                    controls.Add(tempDrag);
                    controls.SetChildIndex(tempDrag, targetIndex);
                    controls.Add(tempDrop);
                    controls.SetChildIndex(tempDrop, dragIndex);
                }
            }
        }
        #endregion
    }
}
