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
        #region 構造体
        /// <summary>
        /// オーバーレイのアイコン位置
        /// </summary>
        public enum IconPlacementS
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

        #region 定数
        private const string IMAGE = "イメージ";
        private const string IMAGE_SIZE = "イメージサイズ";
        #endregion

        #region メンバ変数
        private static readonly ILog mLog = LogManager.GetLogger(typeof(RdtThumbnailView));

        //ドラッグアンドドロップや複数選択用
        private string mBeforeSelectedPanel = string.Empty;
        private bool mIsBeforeCtrl;
        private List<Panel> mSelectedPanels = new List<Panel>();
        private Point mDragStartPoint;

        //画像関連
        private Point mImageMargin = new Point(0, 0);
        private Image? mDeleteImage = null;
        private Image? mMultiFrameImage = null;
        private Image? mLargeDeleteImage = null;
        private Image? mLargeMultiFrameImage = null;
        private IconPlacementS mDeleteIconPlacement = IconPlacementS.LEFT_TOP;
        private IconPlacementS mMultiIconPlacement = IconPlacementS.LEFT_TOP;
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

        #region プロパティ
        /// <summary>
        /// オーバーレイアイコンの場所
        /// </summary>
        [Category(IMAGE)]
        public IconPlacementS DeleteIconPlacement
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
        public IconPlacementS MultiIconPlacement
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

        #endregion

        #region パブリックメソッド
        /// <summary>
        /// Initialize
        /// </summary>
        public RdtThumbnailView()
        {
            this.InitializeComponent();
            this.InitializeCustomUI();
        }

        /// <summary>
        /// Initialize
        /// </summary>
        /// <param name="container">container</param>
        public RdtThumbnailView(IContainer container)
        {
            container.Add(this);

            this.InitializeComponent();
            this.InitializeCustomUI();
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
            if (this.UseLargeIcon == true)
            {
                if (this.mLargeDeleteImage == null)
                {
                    mLog.Debug("mLargeDeleteImage is null");
                    return;
                }
            }
            else
            {
                if (this.mDeleteImage == null)
                {
                    mLog.Debug("mDeleteImage is null");
                    return;
                }
            }

            //オーバーレイパネルを追加
            foreach (var mainPanel in this.mSelectedPanels)
            {
                if (mainPanel.Controls.Count == 0)
                {
                    continue;
                }

                Control? mainPic = null;

                if (mainPanel.Controls.Find("mainPic", false).Length > 0)
                {
                    mainPic = mainPanel.Controls.Find("mainPic", false).First();
                }
                else
                {
                    continue;
                }

                if (mainPic.Controls.Find("DeleteOverlay", false).Length > 0)
                {
                    //コントロールを削除する
                    mainPic.Controls.Remove(mainPic.Controls.Find("DeleteOverlay", false).First());
                }

                Size boxSize = new Size();

                boxSize.Width = this.mUseLargeIcon == true ? this.mLargeDeleteImage!.Width : this.mDeleteImage!.Width;
                boxSize.Height = this.mUseLargeIcon == true ? this.mLargeDeleteImage!.Height : this.mDeleteImage!.Height;

                PictureBox overlay = new PictureBox
                {
                    Name = "DeleteOverlay",
                    Size = boxSize,
                    Location = this.GetOverlayLocation(mainPic, boxSize, this.mDeleteIconPlacement),
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    BackColor = Color.Transparent,
                    Image = this.mUseLargeIcon == true ? this.mLargeDeleteImage : this.mDeleteImage,
                };

                mainPic.Controls.Add(overlay);

                var multi = mainPic.Controls.Find("MultiOverlay", false);
                if (multi.Length > 0)
                {
                    if (this.mMultiIconPlacement == this.mDeleteIconPlacement)
                    {
                        multi.First().Visible = false;
                    }
                }
            }
            return;
        }

        /// <summary>
        /// 選択している画像にマルチフレームマークを表示する
        /// </summary>
        public void ShowMultiFrameOverlay()
        {
            if (this.UseLargeIcon == true)
            {
                if (this.mLargeMultiFrameImage == null)
                {
                    mLog.Debug("mLargeMultiFrameImage is null");
                    return;
                }
            }
            else
            {
                if (this.mMultiFrameImage == null)
                {
                    mLog.Debug("mMultiFrameImage is null");
                    return;
                }
            }

            //オーバーレイパネルを追加
            foreach (var mainPanel in this.mSelectedPanels)
            {
                if (mainPanel.Controls.Count == 0)
                {
                    continue;
                }

                Control? mainPic = null;

                if (mainPanel.Controls.Find("mainPic", false).Length > 0)
                {
                    mainPic = mainPanel.Controls.Find("mainPic", false).First();
                }
                else
                {
                    continue;
                }

                if (mainPic.Controls.Find("MultiOverlay", false).Length > 0)
                {
                    //コントロールを削除する
                    mainPic.Controls.Remove(mainPic.Controls.Find("MultiOverlay", false).First());
                }

                Size boxSize = new Size();

                boxSize.Width = this.mUseLargeIcon == true ? this.mLargeMultiFrameImage!.Width : this.mMultiFrameImage!.Width;
                boxSize.Height = this.mUseLargeIcon == true ? this.mLargeMultiFrameImage!.Height : this.mMultiFrameImage!.Height;

                PictureBox overlay = new PictureBox
                {
                    Name = "MultiOverlay",
                    Size = boxSize,
                    Location = this.GetOverlayLocation(mainPic, boxSize, this.mMultiIconPlacement),
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    BackColor = Color.Transparent,
                    Image = this.mUseLargeIcon == true ? this.mLargeMultiFrameImage : this.mMultiFrameImage,
                };

                mainPic.Controls.Add(overlay);

                //同じポジションにDeleteのオーバーレイがあったら表示しない
                if (mainPic.Controls.Find("DeleteOverlay", false).Length > 0 && this.mDeleteIconPlacement == this.mMultiIconPlacement)
                {
                    overlay.Visible = false;
                }
            }
            return;
        }

        /// <summary>
        /// オーバーレイ画像を削除する
        /// </summary>
        public void RemoveMultiOverlay()
        {
            foreach (var mainPanel in this.mSelectedPanels)
            {
                if (mainPanel == null)
                {
                    continue;
                }

                var mainPic = mainPanel.Controls.Find("mainPic", false).First();

                if (mainPic == null)
                {
                    continue;
                }

                bool isAdded = mainPic.Controls.Find("MultiOverlay", false).Length > 0;
                if (isAdded)
                {
                    mainPic.Controls.Remove(mainPic.Controls.Find("MultiOverlay", false).First());
                }
            }
            return;
        }

        /// <summary>
        /// オーバーレイ画像を削除する
        /// </summary>
        public void RemoveDeleteOverlay()
        {
            foreach (var mainPanel in this.mSelectedPanels)
            {
                if (mainPanel == null)
                {
                    continue;
                }

                var mainPic = mainPanel.Controls.Find("mainPic", false).First();

                if (mainPic == null)
                {
                    continue;
                }

                bool isAdded = mainPic.Controls.Find("DeleteOverlay", false).Length > 0;
                if (isAdded)
                {
                    mainPic.Controls.Remove(mainPic.Controls.Find("DeleteOverlay", false).First());
                }
            }
            return;
        }

        #endregion

        #region プロテクテッドメソッド
        /// <summary>
        /// OnCreateControl
        /// </summary>
        protected override void OnCreateControl()
        {
            base.OnCreateControl();

            if (string.IsNullOrEmpty(this.mDeleteImageFilePath) == false)
            {
                if (File.Exists(this.mDeleteImageFilePath))
                {
                    Image image = Image.FromFile(this.mDeleteImageFilePath);
                    if (this.mIsOverlayResize == true)
                    {
                        image = new Bitmap(image, this.mOverlayImageSize);
                    }

                    this.mDeleteImage = image;
                }
                else
                {
                    mLog.Debug("mDeleteImageFilePath load is failed.");
                    return;
                }
            }

            if (string.IsNullOrEmpty(this.mLargeDeleteImageFilePath) == false)
            {
                if (File.Exists(this.mLargeDeleteImageFilePath))
                {
                    Image image = Image.FromFile(this.mLargeDeleteImageFilePath);

                    this.mLargeDeleteImage = image;
                }
                else
                {
                    mLog.Debug("mLargeDeleteImageFilePath load is failed.");
                    return;
                }
            }

            if (string.IsNullOrEmpty(this.mMultiFrameFilePath) == false)
            {
                if (File.Exists(this.mMultiFrameFilePath))
                {
                    Image image = Image.FromFile(this.mMultiFrameFilePath);
                    if (this.mIsOverlayResize == true)
                    {
                        image = new Bitmap(image, this.mOverlayImageSize);
                    }

                    this.mMultiFrameImage = image;
                }
                else
                {
                    mLog.Debug("mMultiFrameFilePath load is failed.");
                    return;
                }
            }

            if (string.IsNullOrEmpty(this.mLargeMultiFrameFilePath) == false)
            {
                if (File.Exists(this.mLargeMultiFrameFilePath))
                {
                    Image image = Image.FromFile(this.mLargeMultiFrameFilePath);

                    this.mLargeMultiFrameImage = image;
                }
                else
                {
                    mLog.Debug("mLargeMultiFrameFilePath load is failed.");
                    return;
                }
            }
        }
        #endregion

        #region プライベートメソッド

        /// <summary>
        /// Initialize
        /// </summary>
        private void InitializeCustomUI()
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
        private void DisposeCustomUI()
        {
            this.mDeleteImage?.Dispose();
            this.mMultiFrameImage?.Dispose();
            this.mLargeDeleteImage?.Dispose();
            this.mLargeMultiFrameImage?.Dispose();
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
            if (!File.Exists(imagePath))
            {
                return null;
            }

            Image image = Image.FromFile(imagePath);
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
            mainPanel.Click += this.Panel_Click;
            mainPic.Click += this.Panel_Click;
            lblNumber.Click += this.Panel_Click;

            mainPic.MouseDown += this.Panel_MouseDown;
            lblNumber.MouseDown += this.Panel_MouseDown;
            mainPanel.MouseDown += this.Panel_MouseDown;

            mainPic.MouseMove += this.Panel_MouseMove;
            lblNumber.MouseMove += this.Panel_MouseMove;
            mainPanel.MouseMove += this.Panel_MouseMove;

            mainPic.DragDrop += this.Panel_DragDrop;
            lblNumber.DragDrop += this.Panel_DragDrop;
            mainPanel.AllowDrop = true;

            mainPic.DragEnter += this.Panel_DragEnter;
            lblNumber.DragEnter += this.Panel_DragEnter;
            mainPanel.DragEnter += this.Panel_DragEnter;

            mainPic.DragDrop += this.Panel_DragDrop;
            lblNumber.DragDrop += this.Panel_DragDrop;
            mainPanel.DragDrop += this.Panel_DragDrop;

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
        private Point GetOverlayLocation(Control mainPic, Size imageSize, IconPlacementS placement)
        {
            Point location = new Point(0, 0);

            switch (placement)
            {
                case IconPlacementS.LEFT_TOP:
                    {
                        location.X = 2;
                        location.Y = 2;
                        break;
                    }
                case IconPlacementS.RIGHT_TOP:
                    {
                        location.X = mainPic.Width - imageSize.Width - 2;
                        location.Y = 2;
                        break;
                    }
                case IconPlacementS.LEFT_BOTTOM:
                    {
                        location.X = 2;
                        location.Y = mainPic.Height - imageSize.Height - 2;
                        break;
                    }
                case IconPlacementS.RIGHT_BOTTOM:
                    {
                        location.X = mainPic.Width - imageSize.Width - 2;
                        location.Y = mainPic.Height - imageSize.Height - 2;
                        break;
                    }
                case IconPlacementS.CENTER:
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
                var mainPic = mainPanel.Controls.Find("mainPic", false);
                if (mainPic != null)
                {
                    var delete = mainPic.First().Controls.Find("DeleteOverlay", false);
                    if (delete.Length > 0)
                    {
                        PictureBox overlay = (PictureBox)delete.First();
                        Point location = this.GetOverlayLocation(mainPic.First(), overlay.Image.Size, this.mDeleteIconPlacement);

                        overlay.Location = location;
                    }
                    var multi = mainPic.First().Controls.Find("MultiOverlay", false);
                    if (multi.Length > 0)
                    {
                        PictureBox overlay = (PictureBox)multi.First();
                        Point location = this.GetOverlayLocation(mainPic.First(), overlay.Image.Size, this.mMultiIconPlacement);

                        overlay.Location = location;
                        if (delete.Length > 0 && this.mMultiIconPlacement == this.mDeleteIconPlacement)
                        {
                            overlay.Visible = false;
                        }
                        else
                        {
                            overlay.Visible = true;
                        }
                    }
                }
            }
            return;
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
                    clickedPanel.BackColor = Color.Transparent;
                    this.mSelectedPanels.Remove(clickedPanel);
                }
                else
                {
                    clickedPanel.BackColor = Color.Cyan;
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
                            p.BackColor = Color.Transparent;
                        }

                        this.mSelectedPanels.Clear();
                    }

                    foreach (Control ctrl in this.Controls)
                    {
                        if (ctrl is Panel panel && int.TryParse(panel.Name, out int num))
                        {
                            if (num >= start && num <= end)
                            {
                                panel.BackColor = Color.Cyan;
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
                    panel.BackColor = Color.Transparent;
                }

                this.mSelectedPanels.Clear();

                clickedPanel.BackColor = Color.Cyan;
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
