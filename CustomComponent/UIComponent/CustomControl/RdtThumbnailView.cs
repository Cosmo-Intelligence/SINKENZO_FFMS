// -----------------------------------------------------------------------
// <copyright file="RdtThumbnailView.cs" company="FUJIFILM Medical Solutions Corporation">
// Copyright (C) 2025 FUJIFILM Medical Solutions Corporation.
// </copyright>
// -----------------------------------------------------------------------
// using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        #endregion

        #region "メンバ変数"
        private static readonly ILog mLog = LogManager.GetLogger(typeof(RdtButton));

        //ドラッグアンドドロップや複数選択用
        private string mBeforeSelectedPanel = string.Empty;
        private bool mIsBeforeCtrl;
        private List<Panel> mSelectedPanels = new List<Panel>();
        private Point mDragStartPoint;

        //色関連
        private string mPanelBackColor = Constants.DEFAULT_BACK_COLOR;
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
            set => this.mPanelBackColor = value;
        }

        /// <summary>
        /// 選択時背景色
        /// </summary>
        [Category(COLOR)]
        public string SelectedBackColor
        {
            get => this.mSelectedBackColor;
            set => this.mSelectedBackColor = value;
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
                var mainPic = mainPanel.Controls.Find("mainPic", false).FirstOrDefault();
                if (mainPic == null)
                {
                    continue;
                }

                //すでに存在していた場合は削除
                var existing = mainPic.Controls.Find("DeleteOverlay", false).FirstOrDefault();
                if (existing != null)
                {
                    mainPic.Controls.Remove(existing);
                    //イベントハンドラの解除
                    this.DetachEvents(existing);

                    existing.Dispose();
                }

                var overlay = new PictureBox
                {
                    Name = "DeleteOverlay",
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
                var multi = mainPic.Controls.Find("MultiOverlay", false).FirstOrDefault();
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
                var mainPic = mainPanel.Controls.Find("mainPic", false).FirstOrDefault();
                if (mainPic == null)
                {
                    continue;
                }

                // 既存オーバーレイ削除
                var existingOverlay = mainPic.Controls.Find("MultiOverlay", false).FirstOrDefault();
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
                    Name = "MultiOverlay",
                    Size = boxSize,
                    Location = this.GetOverlayLocation(mainPic, boxSize, this.mMultiIconPlacement),
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    BackColor = Color.Transparent,
                    Image = image,
                    AllowDrop = true,
                };

                // イベント登録
                this.AttachEvents(overlay);

                mainPic.Controls.Add(overlay);

                // DeleteOverlay と位置が重複していたら非表示
                bool hasDelete = mainPic.Controls.Find("DeleteOverlay", false).Any();
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
            this.RemoveOverlay("MultiOverlay");
            return;
        }

        /// <summary>
        /// 削除アイコンのオーバーレイ画像を削除する
        /// </summary>
        public void RemoveDeleteOverlay()
        {
            this.RemoveOverlay("DeleteOverlay");
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

            if (string.IsNullOrEmpty(this.mDeleteImageFilePath) == false)
            {
                this.mDeleteImage = ComponentCommon.GetImageFromPath(this.mDeleteImageFilePath);
            }

            if (string.IsNullOrEmpty(this.mLargeDeleteImageFilePath) == false)
            {
                this.mLargeDeleteImage = ComponentCommon.GetImageFromPath(this.mLargeDeleteImageFilePath);
            }

            if (string.IsNullOrEmpty(this.mMultiFrameFilePath) == false)
            {
                this.mMultiFrameImage = ComponentCommon.GetImageFromPath(this.mMultiFrameFilePath);
            }

            if (string.IsNullOrEmpty(this.mLargeMultiFrameFilePath) == false)
            {
                this.mLargeMultiFrameImage = ComponentCommon.GetImageFromPath(this.mLargeMultiFrameFilePath);
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

            this.mBeforeSelectedPanel = "-1";
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
        /// イベントを追加する
        /// </summary>
        private void AttachEvents(Control control)
        {
            control.Click += this.Panel_Click;
            control.MouseDown += this.Panel_MouseDown;
            control.MouseMove += this.Panel_MouseMove;
            control.DragEnter += this.Panel_DragEnter;
            control.DragDrop += this.Panel_DragDrop;
        }

        /// <summary>
        /// イベントを削除する
        /// </summary>
        private void DetachEvents(Control control)
        {
            control.Click -= this.Panel_Click;
            control.MouseDown -= this.Panel_MouseDown;
            control.MouseMove -= this.Panel_MouseMove;
            control.DragEnter -= this.Panel_DragEnter;
            control.DragDrop -= this.Panel_DragDrop;
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
            Image? image = ComponentCommon.GetImageFromPath(imagePath);
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
                Name = "mainPic",
                Size = new Size(image.Width, image.Height),
                Location = new Point(2, 2),
                Image = image,
                SizeMode = PictureBoxSizeMode.StretchImage,
                BackColor = Color.White,
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
                Name = "mainPanel",
                Size = new Size(mainPic.Size.Width + 4, mainPic.Size.Height + lblNumber.Size.Height + 2),
                Margin = new Padding(2, 2, marginX, marginY),
                BackColor = Color.Transparent,
                Tag = number,
            };

            // クリック選択イベント
            this.AttachEvents(mainPanel);
            this.AttachEvents(mainPic);
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
                var mainPic = mainPanel.Controls.Find("mainPic", false).FirstOrDefault();
                if (mainPic == null)
                {
                    continue;
                }

                var deleteOverlay = mainPic.Controls.Find("DeleteOverlay", false).FirstOrDefault() as PictureBox;
                var multiOverlay = mainPic.Controls.Find("MultiOverlay", false).FirstOrDefault() as PictureBox;

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

                var mainPic = mainPanel.Controls.Find("mainPic", false).FirstOrDefault();
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
        private void Panel_Click(object? sender, EventArgs e)
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

            bool isCtrlPressed = (ModifierKeys & Keys.Control) == Keys.Control;
            bool isShiftPressed = (ModifierKeys & Keys.Shift) == Keys.Shift;

            if (isCtrlPressed && !isShiftPressed)
            {
                if (this.mSelectedPanels.Contains(clickedPanel))
                {
                    clickedPanel.BackColor = ColorTranslator.FromHtml(this.mPanelBackColor);
                    this.mSelectedPanels.Remove(clickedPanel);
                }
                else
                {
                    clickedPanel.BackColor = ColorTranslator.FromHtml(this.mSelectedBackColor);
                    this.mSelectedPanels.Add(clickedPanel);
                }

                this.mBeforeSelectedPanel = clickedPanel.Name;
                this.mIsBeforeCtrl = true;
            }
            else if (isShiftPressed && !isCtrlPressed)
            {
                if (!int.TryParse(clickedPanel.Name, out int selectedNum))
                {
                    return;
                }

                if (!int.TryParse(this.mBeforeSelectedPanel, out int beforeSelectedNum))
                {
                    return;
                }

                if (beforeSelectedNum != -1)
                {
                    int start = Math.Min(selectedNum, beforeSelectedNum);
                    int end = Math.Max(selectedNum, beforeSelectedNum);

                    if (!this.mIsBeforeCtrl)
                    {
                        foreach (Panel p in this.mSelectedPanels)
                        {
                            p.BackColor = ColorTranslator.FromHtml(this.mPanelBackColor);
                        }

                        this.mSelectedPanels.Clear();
                    }

                    foreach (Control ctrl in this.Controls)
                    {
                        if (ctrl is Panel panel && int.TryParse(panel.Name, out int num))
                        {
                            if (num >= start && num <= end)
                            {
                                panel.BackColor = ColorTranslator.FromHtml(this.mSelectedBackColor);
                                if (!this.mSelectedPanels.Contains(panel))
                                {
                                    this.mSelectedPanels.Add(panel);
                                }
                            }
                        }
                    }

                    this.mIsBeforeCtrl = false;
                }
            }
            else
            {
                foreach (var panel in this.mSelectedPanels)
                {
                    panel.BackColor = ColorTranslator.FromHtml(this.mPanelBackColor);
                }

                this.mSelectedPanels.Clear();

                clickedPanel.BackColor = ColorTranslator.FromHtml(this.mSelectedBackColor);
                this.mSelectedPanels.Add(clickedPanel);

                this.mBeforeSelectedPanel = clickedPanel.Name;
                this.mIsBeforeCtrl = false;
            }
        }

        /// <summary>
        /// パネルのマウスクリックイベント
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">Event</param>
        private void Panel_MouseDown(object? sender, MouseEventArgs e)
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
        private void Panel_MouseMove(object? sender, MouseEventArgs e)
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
        private void Panel_DragEnter(object? sender, DragEventArgs e)
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
        private void Panel_DragDrop(object? sender, DragEventArgs e)
        {
            if (e == null || e.Data == null)
            {
                return;
            }

            if (!e.Data.GetDataPresent(typeof(List<Panel>)))
            {
                return;
            }

            Panel? targetPanel = sender as Panel;
            if (targetPanel == null)
            {
                return;
            }

            var draggedPanels = e.Data.GetData(typeof(List<Panel>)) as List<Panel>;
            if (draggedPanels == null || draggedPanels.Count == 0)
            {
                return;
            }

            int targetIndex = this.Controls.GetChildIndex(targetPanel);

            foreach (Panel panel in draggedPanels)
            {
                this.Controls.Remove(panel);
            }

            draggedPanels.Reverse();
            foreach (Panel panel in draggedPanels)
            {
                this.Controls.Add(panel);
                this.Controls.SetChildIndex(panel, targetIndex);
            }
        }
        #endregion
    }
}
