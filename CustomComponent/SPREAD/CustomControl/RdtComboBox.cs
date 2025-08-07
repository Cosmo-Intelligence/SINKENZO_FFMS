//-----------------------------------------------------------------------
// <copyright file="RdtComboBox.cs" company="FUJIFILM Medical Solutions Corporation">
// Copyright (C) 2025 FUJIFILM Medical Solutions Corporation.
// </copyright>
//-----------------------------------------------------------------------
using System.ComponentModel;
using System.Drawing.Drawing2D;

using SPREAD.CustomControl;

namespace RADISTA.SPREAD.CustomControl
{
    public partial class RdtComboBox : UserControl
    {
        #region "列挙型"
        /// <summary>
        /// 描画のスタイル
        /// <para>
        /// Standard:ボーダーあり
        /// Frat:ボーダー無し
        /// </para>
        /// </summary>
        public enum DrawStyleT
        {
            /// <summary>
            /// ボーダーあり
            /// </summary>
            Standard = 0,
            /// <summary>
            /// ボーダーなし
            /// </summary>
            Flat = 1,
        }
        #endregion

        #region "定数"

        private const string BORDER = "ボーダー";
        private const string COLOR = "カラー";
        private const string LIST = "リスト";
        private const string LIST_COLOR = "リスト_カラー";
        private const string LIST_BORDER = "リスト_ボーダー";
        private const string LIST_CORNER = "リスト_コーナー";
        private const string LIST_STYLE = "リスト_スタイル";
        /// <summary>
        /// ボーダーの太さの最大値
        /// </summary>
        private const int BORDER_TICK_MAX = 30;
        /// <summary>
        /// ボーダーの太さの最小値
        /// </summary>
        private const int BORDER_TICK_MIN = 1;
        /// <summary>
        /// コーナー角度の最大値
        /// </summary>
        private const int CORNER_RADIUS_MAX = 16;
        /// <summary>
        /// コーナー角度の最小値
        /// </summary>
        private const int CORNER_RADIUS_MIN = 0;

        private const int LABEL_ARROW_WIDTH = 30;
        #endregion

        #region "メンバ変数"

        //ComboBoxのパーツ
        private bool mIsDropped = false;
        private RdtListBox mDropDownList = new RdtListBox();
        private Panel mPanelTop = new Panel();
        private Label mLabelText = new Label();
        private Label mLabelArrow = new Label();

        //ボーダー関連
        private string mBorderColor = Constants.TEXT_DEFAULT_EDGE_COLOR;
        private int mBorderThick = 2;
        //コーナー角度
        private int mLeftTopCornerRadius = 8;
        private int mRightTopCornerRadius = 8;
        private int mLeftBottomCornerRadius = 8;
        private int mRightBottomCornerRadius = 8;

        //ドロップボタン(▼)関連
        private string mButtonBackColor = Constants.TEXT_DEFAULT_BACK_COLOR;

        //ドロップダウン関連
        private string mPanelBackColor = Constants.TEXT_DEFAULT_BACK_COLOR;
        private string mPanelForeColor = Constants.TEXT_DEFAULT_FONT_COLOR;
        private bool mIsUpperDrop = false;
        private int mDropdownHeight = 150;
        private string mFontColor = Constants.BUTTON_DEFAULT_TEXT_FONT_COLOR;

        private DrawStyleT mDrawStyle = DrawStyleT.Standard;

        private string mDisableForeColor = Constants.TEXT_DISABLE_FONT_COLOR;
        private string mDisableBackColor = Constants.TEXT_DISABLE_BACK_COLOR;

        //デフォルト位置を記憶しておく
        private Point mDefaultLocation = new Point(0, 0);

        #endregion

        #region "プロパティ"
        //ボーダー関連
        /// <summary>
        /// ボーダーカラー
        /// </summary>
        [Category(BORDER)]
        public string BorderColor
        {
            get
            {
                return this.mBorderColor;
            }

            set
            {
                // デザイナのプロパティで入力ミスがあった場合は直接エラーメッセージを出す
                if (!ComponentCommon.IsColorCode(value))
                {
                    throw new ArgumentException(Constants.ERROR_COLOR_CODE);
                }

                this.mBorderColor = value;

                this.Refresh();
            }
        }

        /// <summary>
        /// ボーダーの太さ
        /// </summary>
        [Category(BORDER)]
        public int BorderThick
        {
            get => this.mBorderThick;
            set
            {
                int newValue = Math.Max(BORDER_TICK_MIN, Math.Min(BORDER_TICK_MAX, value));
                this.mBorderThick = newValue;

                this.ChangePanelSize();
            }
        }

        /// <summary>
        /// ▼ボタン背景色
        /// </summary>
        [Category(COLOR)]
        public string ButtonBackColor
        {
            get => this.mButtonBackColor;
            set
            {
                // デザイナのプロパティで入力ミスがあった場合は直接エラーメッセージを出す
                if (!ComponentCommon.IsColorCode(value))
                {
                    throw new ArgumentException(Constants.ERROR_COLOR_CODE);
                }

                this.mButtonBackColor = value;

                this.Invalidate();
            }
        }

        /// <summary>
        /// パネル背景色
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

                this.Invalidate();
            }
        }

        /// <summary>
        /// パネルのフォントカラー
        /// </summary>
        [Category(COLOR)]
        public string PanelForeColor
        {
            get => this.mPanelForeColor;
            set
            {
                // デザイナのプロパティで入力ミスがあった場合は直接エラーメッセージを出す
                if (!ComponentCommon.IsColorCode(value))
                {
                    throw new ArgumentException(Constants.ERROR_COLOR_CODE);
                }

                this.mPanelForeColor = value;

                this.Invalidate();
            }
        }

        /// <summary>
        /// 上にドロップするかどうか
        /// </summary>
        [Category(LIST)]
        public bool IsUpperDrop
        {
            get => this.mIsUpperDrop;
            set => this.mIsUpperDrop = value;
        }

        /// <summary>
        /// リスト部分の高さ
        /// </summary>
        [Category(LIST)]
        public int DropdownHeight
        {
            get => this.mDropdownHeight;
            set => this.mDropdownHeight = value;
        }

        /// <summary>
        /// 描画のスタイル
        /// </summary>
        [Category(LIST)]
        public DrawStyleT DrawStyle
        {
            get => this.mDrawStyle;
            set => this.mDrawStyle = value;
        }

        /// <summary>
        /// 選択中のアイテムテキスト
        /// </summary>
        [Browsable(false)]
        public string SelectedItem => this.mDropDownList.SelectedItem;

        /// <summary>
        /// 選択中のインデックス
        /// </summary>
        [Browsable(false)]
        public int SelectedIndex
        {
            get => this.mDropDownList.SelectedIndex;
            set
            {
                this.mDropDownList.SelectedIndex = value;
                if (this.mDropDownList.SelectedItem == null || value < 0)
                {
                    this.mLabelText.Text = "選択してください";
                }
                else
                {
                    this.mLabelText.Text = this.mDropDownList.SelectedItem;
                }
            }
        }

        #region リストのプロパティ
        /// <summary>
        /// リストのボーダー
        /// </summary>
        [Category(LIST_BORDER)]
        public string ListBorderColor
        {
            get => this.mDropDownList.BorderColor;
            set
            {
                if (!ComponentCommon.IsColorCode(value))
                {
                    throw new ArgumentException(Constants.ERROR_COLOR_CODE);
                }

                this.mDropDownList.BorderColor = value;
            }
        }

        /// <summary>
        /// リストのボーダーの太さ
        /// </summary>
        [Category(LIST_BORDER)]
        public int ListBorderThick
        {
            get => this.mDropDownList.BorderThick;
            set
            {
                int newValue = Math.Max(BORDER_TICK_MIN, Math.Min(BORDER_TICK_MAX, value));
                this.mDropDownList.BorderThick = newValue;
            }
        }

        /// <summary>
        /// リストのホバーカラー
        /// </summary>
        [Category(LIST_COLOR)]
        public string ListHoverBorderColor
        {
            get => this.mDropDownList.HoverBorderColor;
            set
            {
                if (!ComponentCommon.IsColorCode(value))
                {
                    throw new ArgumentException(Constants.ERROR_COLOR_CODE);
                }

                this.mDropDownList.HoverBorderColor = value;
            }
        }

        /// <summary>
        /// リストのフォントカラー
        /// </summary>
        [Category(LIST_COLOR)]
        public string ListFontColor
        {
            get => this.mDropDownList.FontColor;
            set
            {
                if (!ComponentCommon.IsColorCode(value))
                {
                    throw new ArgumentException(Constants.ERROR_COLOR_CODE);
                }

                this.mDropDownList.FontColor = value;
            }
        }

        /// <summary>
        /// リストの非活性時の文字色
        /// </summary>
        [Category(LIST_COLOR)]
        public string ListDisableForeColor
        {
            get => this.mDropDownList.DisableForeColor;
            set
            {
                if (!ComponentCommon.IsColorCode(value))
                {
                    throw new ArgumentException(Constants.ERROR_COLOR_CODE);
                }

                this.mDropDownList.DisableForeColor = value;
            }
        }

        /// <summary>
        /// リストの非活性時の背景色
        /// </summary>
        [Category(LIST_COLOR)]
        public string ListDisableBackColor
        {
            get => this.mDropDownList.DisableBackColor;
            set
            {
                if (!ComponentCommon.IsColorCode(value))
                {
                    throw new ArgumentException(Constants.ERROR_COLOR_CODE);
                }

                this.mDropDownList.DisableBackColor = value;
            }
        }

        /// <summary>
        /// FlatStyleのリスト背景色
        /// </summary>
        [Category(LIST_COLOR)]
        public string ListFlatBackColor
        {
            get => this.mDropDownList.FlatBackColor;
            set
            {
                if (!ComponentCommon.IsColorCode(value))
                {
                    throw new ArgumentException(Constants.ERROR_COLOR_CODE);
                }

                this.mDropDownList.FlatBackColor = value;
            }
        }

        /// <summary>
        /// リストの交互色を使用するかどうか
        /// </summary>
        [Category(LIST_COLOR)]
        public bool ListUseAlternateColor
        {
            get => this.mDropDownList.UseAlternateColor;
            set => this.mDropDownList.UseAlternateColor = value;
        }

        /// <summary>
        /// リストのセル背景色
        /// </summary>
        [Category(LIST_COLOR)]
        public string ListCellBackColor
        {
            get => this.mDropDownList.CellBackColor;
            set
            {
                if (!ComponentCommon.IsColorCode(value))
                {
                    throw new ArgumentException(Constants.ERROR_COLOR_CODE);
                }

                this.mDropDownList.CellBackColor = value;
            }
        }

        /// <summary>
        /// リストの背景交互色
        /// </summary>
        [Category(LIST_COLOR)]
        public string ListAlternateColor
        {
            get => this.mDropDownList.AlternateColor;
            set
            {
                if (!ComponentCommon.IsColorCode(value))
                {
                    throw new ArgumentException(Constants.ERROR_COLOR_CODE);
                }

                this.mDropDownList.AlternateColor = value;
            }
        }

        /// <summary>
        /// リストのホバーカラー
        /// </summary>
        [Category(LIST_COLOR)]
        public string ListHoverBackColor
        {
            get => this.mDropDownList.HoverBackColor;
            set
            {
                if (!ComponentCommon.IsColorCode(value))
                {
                    throw new ArgumentException(Constants.ERROR_COLOR_CODE);
                }

                this.mDropDownList.HoverBackColor = value;
            }
        }

        /// <summary>
        /// リストの左上のコーナー角度
        /// </summary>
        [Category(LIST_CORNER)]
        public int ListLeftTopCornerRadius
        {
            get => this.mDropDownList.LeftTopCornerRadius;
            set => this.mDropDownList.LeftTopCornerRadius = Math.Max(CORNER_RADIUS_MIN, Math.Min(CORNER_RADIUS_MAX, value));
        }

        /// <summary>
        /// リストの右上のコーナー角度
        /// </summary>
        [Category(LIST_CORNER)]
        public int ListRightTopCornerRadius
        {
            get => this.mDropDownList.RightTopCornerRadius;
            set => this.mDropDownList.RightTopCornerRadius = Math.Max(CORNER_RADIUS_MIN, Math.Min(CORNER_RADIUS_MAX, value));
        }

        /// <summary>
        /// リストの左下のコーナー角度
        /// </summary>
        [Category(LIST_CORNER)]
        public int ListLeftBottomCornerRadius
        {
            get => this.mDropDownList.LeftBottomCornerRadius;
            set => this.mDropDownList.LeftBottomCornerRadius = Math.Max(CORNER_RADIUS_MIN, Math.Min(CORNER_RADIUS_MAX, value));
        }

        /// <summary>
        /// リストの右下のコーナー角度
        /// </summary>
        [Category(LIST_CORNER)]
        public int ListRightBottomCornerRadius
        {
            get => this.mDropDownList.RightBottomCornerRadius;
            set => this.mDropDownList.RightBottomCornerRadius = Math.Max(CORNER_RADIUS_MIN, Math.Min(CORNER_RADIUS_MAX, value));
        }

        /// <summary>
        /// リストの描画スタイル
        /// </summary>
        [Category(LIST_STYLE)]
        public DrawStyleT ListDrawStyle
        {
            get => (DrawStyleT)this.mDropDownList.DrawStyle;
            set
            {
                this.mDropDownList.DrawStyle = (RdtListBox.DrawStyleT)value;
            }
        }

        #endregion

        #endregion

        #region "パブリックメソッド"

        /// <summary>
        /// 初期化処理
        /// </summary>
        public RdtComboBox()
        {
            this.InitializeComponent();
            this.InitializeCustomSetting();
        }

        /// <summary>
        /// 初期化処理
        /// </summary>
        /// <param name="container">container</param>
        public RdtComboBox(IContainer container)
        {
            container.Add(this);

            this.InitializeComponent();
            this.InitializeCustomSetting();
        }

        /// <summary>
        /// アイテムを追加
        /// </summary>
        /// <param name="text">アイテム名</param>
        public void AddItem(string text) => this.mDropDownList.AddItem(text);

        /// <summary>
        /// 複数追加
        /// </summary>
        /// <param name="items">アイテムの配列</param>
        public void AddItems(string[] items) => this.mDropDownList.AddItems(items);

        #endregion

        #region "プロテクテッドメソッド"
        /// <summary>
        /// OnPaint
        /// </summary>
        /// <param name="e">Event</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e); // ここで通常の描画（子コントロール含む）

            this.mLabelArrow.BackColor = ColorTranslator.FromHtml(this.mButtonBackColor);
            this.mLabelText.BackColor = ColorTranslator.FromHtml(this.mPanelBackColor);
            this.mLabelText.ForeColor = ColorTranslator.FromHtml(this.mPanelForeColor);
        }
        #endregion

        #region"プライベートメソッド"

        /// <summary>
        /// Initialize処理
        /// </summary>
        private void InitializeCustomSetting()
        {
            // トップパネル（ラベル＋矢印）
            this.mPanelTop = new Panel
            {
                Height = 30,
                Dock = DockStyle.None,
                BackColor = Color.FromArgb(45, 45, 48),
                BorderStyle = BorderStyle.None,
            };
            this.Controls.Add(this.mPanelTop);

            Font font = new Font(ComponentCommon.GetFontType(), ComponentCommon.GetFontSize());
            // 左側の選択テキスト
            this.mLabelText = new Label
            {
                Dock = DockStyle.None,
                Width = this.mPanelTop.Width - LABEL_ARROW_WIDTH - this.mBorderThick,
                Text = "選択してください",
                TextAlign = ContentAlignment.MiddleLeft,
                ForeColor = ColorTranslator.FromHtml(this.mPanelForeColor),
                Font = font,
                BackColor = Color.FromArgb(255, 50, 255),
            };
            this.mLabelText.Click += (s, e) => this.ToggleDropDown();
            this.mPanelTop.Controls.Add(this.mLabelText);

            // 右端の矢印
            this.mLabelArrow = new Label
            {
                Dock = DockStyle.None,
                Width = LABEL_ARROW_WIDTH - this.mBorderThick,
                Location = new Point(this.mLabelText.Right, this.mLabelText.Top),
                Text = "▼",
                TextAlign = ContentAlignment.MiddleCenter,
                ForeColor = Color.Black,
                Font = font,
                BackColor = Color.FromArgb(45, 45, 255),
            };
            this.mLabelArrow.Click += (s, e) => this.ToggleDropDown();
            this.mPanelTop.Controls.Add(this.mLabelArrow);
            // ドロップダウン（SpreadListBox）
            this.mDropDownList = new RdtListBox
            {
                Visible = false,
                Height = 150,
                Width = this.Width,
                Location = new Point(0, this.mPanelTop.Bottom), // ← ラベル下に配置
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right,
            };
            this.Controls.Add(this.mDropDownList);

            this.Height = this.mPanelTop.Height;

            this.AttachEvent();
        }

        /// <summary>
        /// Dispose処理
        /// </summary>
        private void DisposeCustomSetting()
        {
            this.DetachEvent();

            //null非許容なので=nullは無し
            this.mDropDownList.Dispose();
            this.mLabelArrow.Dispose();
            this.mLabelText.Dispose();
            this.mPanelTop.Dispose();
        }

        /// <summary>
        /// トグルの表示非表示の処理
        /// </summary>
        private void ToggleDropDown()
        {
            this.mIsDropped = !this.mIsDropped;

            bool isUpperDrop = this.mIsUpperDrop;

            if (this.ParentForm != null)
            {
                //もし画面外へ出てしまう場合はmIsUpperをひっくり返す
                if (isUpperDrop)
                {
                    if (this.Location.Y - this.mDropdownHeight < 0)
                    {
                        isUpperDrop = false;
                    }
                }
                else if (this.Location.Y + this.mDropdownHeight > this.ParentForm.Height)
                {
                    isUpperDrop = true;
                }
            }

            if (this.mIsDropped)
            {
                //デフォルト位置を記憶する
                this.mDefaultLocation = this.Location;

                if (isUpperDrop)
                {
                    this.Height = this.mDropDownList.Height + this.mPanelTop.Height;

                    this.mPanelTop.Location = new Point(this.mPanelTop.Location.X, this.Height - this.mPanelTop.Height);

                    this.mDropDownList.Width = this.Width;
                    this.mDropDownList.Visible = true;

                    // 自分自身を上にずらす（リストが上に飛び出すように）
                    this.Location = new Point(this.Location.X, this.Location.Y - this.mDropDownList.Height);
                }
                else
                {
                    this.mPanelTop.Location = new Point(this.mPanelTop.Location.X, 0);

                    this.mDropDownList.Location = new Point(0, this.mPanelTop.Height + this.mBorderThick); // ラベル下に表示
                    this.mDropDownList.Width = this.Width;
                    this.mDropDownList.Visible = true;

                    // 高さは固定にして、UserControl全体を伸ばす
                    this.Height = this.mPanelTop.Height + this.mDropDownList.Height;
                }
            }
            else
            {
                this.mDropDownList.Visible = false;
                this.Height = this.mPanelTop.Height;
                this.mPanelTop.Location = new Point(this.mPanelTop.Location.X, 0);
                this.Location = this.mDefaultLocation;
            }

            this.mLabelArrow.Text = this.mIsDropped ? "▲" : "▼";

            this.Refresh();
        }

        /// <summary>
        /// パネル範囲が変更されたときの処理
        /// </summary>
        private void ChangePanelSize()
        {
            int borderMargin = this.mBorderThick * 2;

            this.mLabelText.Width = this.mPanelTop.Width - LABEL_ARROW_WIDTH - borderMargin;
            this.mLabelText.Height = this.mPanelTop.Height - borderMargin;
            this.mLabelText.Location = new Point(this.mBorderThick, this.mBorderThick);

            this.mLabelArrow.Width = LABEL_ARROW_WIDTH - this.mBorderThick;
            this.mLabelArrow.Height = this.mPanelTop.Height - borderMargin;
            this.mLabelArrow.Location = new Point(this.mPanelTop.Right - LABEL_ARROW_WIDTH - this.mBorderThick, this.mBorderThick);

            this.Invalidate();
        }

        /// <summary>
        /// イベントのデタッチ処理
        /// </summary>
        private void DetachEvent()
        {
            this.SizeChanged -= this.RdtComboBox_SizeChanged;
            this.EnabledChanged -= this.RdtComboBox_EnabledChanged;
            this.mPanelTop.Paint -= this.Panel_Paint;
            this.mLabelText.Paint -= this.Label_Paint;
            this.mLabelArrow.Paint -= this.Label_Paint;
            this.mDropDownList.SelectionChanged -= this.DropDownList_SelectionChanged;
        }

        /// <summary>
        /// イベントのアタッチ処理
        /// </summary>
        private void AttachEvent()
        {
            this.DetachEvent();

            this.SizeChanged += this.RdtComboBox_SizeChanged;
            this.EnabledChanged += this.RdtComboBox_EnabledChanged;
            this.mPanelTop.Paint += this.Panel_Paint;
            this.mLabelText.Paint += this.Label_Paint;
            this.mLabelArrow.Paint += this.Label_Paint;
            this.mDropDownList.SelectionChanged += this.DropDownList_SelectionChanged;
        }

        /// <summary>
        /// ドロップダウンの選択行変更イベント
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">event</param>
        private void DropDownList_SelectionChanged(object sender, FarPoint.Win.Spread.SelectionChangedEventArgs e)
        {
            this.mLabelText.Text = this.mDropDownList.SelectedItem;
            this.mDropDownList.Visible = false;
            this.mIsDropped = false;
            this.mLabelArrow.Text = "▼";
            this.Height = this.mPanelTop.Height;
        }

        /// <summary>
        /// コンボボックスの活性非活性切り替えイベント
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">event</param>
        private void RdtComboBox_EnabledChanged(object? sender, EventArgs e)
        {
            this.mLabelText.ForeColor = ColorTranslator.FromHtml(this.Enabled ? this.mFontColor : this.mDisableForeColor);
        }

        /// <summary>
        /// ラベルの描画イベント
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">event</param>
        private void Label_Paint(object? sender, PaintEventArgs e)
        {
            //return;
            if (this.mDrawStyle != DrawStyleT.Standard)
            {
                return;
            }

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            Label? label = sender as Label;
            if (label == null)
            {
                return;
            }

            Point labelLocation = this.PointToScreen(label.Location);
            Point panelLocation = this.PointToScreen(this.mPanelTop.Location);

            Point baseLocation = new Point(panelLocation.X - labelLocation.X, panelLocation.Y - labelLocation.Y);

            Rectangle borderRect = new Rectangle(
                baseLocation.X + (this.mBorderThick / 2) - 1,
                baseLocation.Y + (this.mBorderThick / 2) - 1,
                this.mLabelText.Width + this.mLabelArrow.Width - this.mBorderThick,
                this.mLabelText.Height + this.mLabelArrow.Height - this.mBorderThick);

            Color borderColor = this.Enabled
                ? ColorTranslator.FromHtml(this.mBorderColor)
                : ColorTranslator.FromHtml(this.mDisableBackColor);

            using (Pen pen = new Pen(borderColor, this.mBorderThick))
            using (GraphicsPath borderPath = this.GetRoundRectanglePath(borderRect, this.mLeftTopCornerRadius, this.mRightTopCornerRadius, this.mLeftBottomCornerRadius, this.mRightBottomCornerRadius))
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

                // 塗りつぶしたい色
                Color outsideFillColor = this.BackColor;

                // コントロール全体の矩形
                Rectangle controlRect = borderRect;

                // 外側の塗りつぶしパスを作成
                using (Region outsideRegion = new Region(controlRect))
                {
                    // 内側の角丸パスを除外
                    outsideRegion.Exclude(borderPath);

                    // 外側を塗りつぶす
                    using (Brush fillBrush = new SolidBrush(outsideFillColor))
                    {
                        // e.Graphics.FillRegion(fillBrush, outsideRegion);
                    }
                }

                // 枠線を描画
                e.Graphics.DrawPath(pen, borderPath);
            }
        }

        /// <summary>
        /// パネルの描画イベント
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">event</param>
        private void Panel_Paint(object? sender, PaintEventArgs e)
        {
            if (this.mDrawStyle != DrawStyleT.Standard)
            {
                return;
            }

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            Rectangle borderRect = new Rectangle(
                (this.mBorderThick / 2) - 1,
                (this.mBorderThick / 2) - 1,
                this.mPanelTop.Width - this.mBorderThick,
                this.mPanelTop.Height - this.mBorderThick);

            Color borderColor = this.Enabled ? ColorTranslator.FromHtml(this.mBorderColor) : ColorTranslator.FromHtml(this.mDisableBackColor);

            using (Pen pen = new Pen(borderColor, this.mBorderThick))
            using (GraphicsPath borderPath = this.GetRoundRectanglePath(borderRect, this.mLeftTopCornerRadius, this.mRightTopCornerRadius, this.mLeftBottomCornerRadius, this.mRightBottomCornerRadius))
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

                // 塗りつぶしたい色
                Color outsideFillColor = this.BackColor;

                // コントロール全体の矩形
                Rectangle controlRect = this.ClientRectangle;

                // 外側の塗りつぶしパスを作成
                using (Region outsideRegion = new Region(controlRect))
                {
                    // 内側の角丸パスを除外
                    outsideRegion.Exclude(borderPath);

                    // 外側を塗りつぶす
                    using (Brush fillBrush = new SolidBrush(outsideFillColor))
                    {
                        e.Graphics.FillRegion(fillBrush, outsideRegion);
                    }
                }

                // 枠線を描画
                e.Graphics.DrawPath(pen, borderPath);
            }
        }

        /// <summary>
        /// コンボボックスのサイズ変更イベント
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">event</param>
        private void RdtComboBox_SizeChanged(object? sender, EventArgs e)
        {
            this.ChangePanelSize();
        }

        /// <summary>
        /// ボーダーの描画範囲を取得する
        /// </summary>
        /// <param name="rect">コントロールのRectangle</param>
        /// <param name="ltRadius">LeftTopRadius</param>
        /// <param name="rtRadius">RightTopRadius</param>
        /// <param name="lbRadius">LeftBottomRadius</param>
        /// <param name="rbRadius">RightBottomRadius</param>
        /// <returns>描画範囲</returns>
        private GraphicsPath GetRoundRectanglePath(Rectangle rect, int ltRadius, int rtRadius, int lbRadius, int rbRadius)
        {
            GraphicsPath path = new GraphicsPath();

            // スタート位置
            if (ltRadius > 0)
            {
                path.AddArc(rect.X, rect.Y, ltRadius * 2, ltRadius * 2, 180, 90);
            }
            else
            {
                path.AddLine(new Point(rect.X, rect.Y), new Point(rect.X + 1, rect.Y)); // 1px直線
            }

            if (rtRadius > 0)
            {
                path.AddLine(new Point(rect.X + ltRadius, rect.Y), new Point(rect.Right - rtRadius, rect.Y));
                path.AddArc(rect.Right - (rtRadius * 2), rect.Y, rtRadius * 2, rtRadius * 2, 270, 90);
            }
            else
            {
                path.AddLine(new Point(rect.X + ltRadius, rect.Y), new Point(rect.Right, rect.Y));
            }

            if (rbRadius > 0)
            {
                path.AddLine(new Point(rect.Right, rect.Y + rtRadius), new Point(rect.Right, rect.Bottom - rbRadius));
                path.AddArc(rect.Right - (rbRadius * 2), rect.Bottom - (rbRadius * 2), rbRadius * 2, rbRadius * 2, 0, 90);
            }
            else
            {
                path.AddLine(new Point(rect.Right, rect.Y), new Point(rect.Right, rect.Bottom));
            }

            if (lbRadius > 0)
            {
                path.AddLine(new Point(rect.Right - rbRadius, rect.Bottom), new Point(rect.X + lbRadius, rect.Bottom));
                path.AddArc(rect.X, rect.Bottom - (lbRadius * 2), lbRadius * 2, lbRadius * 2, 90, 90);
            }
            else
            {
                path.AddLine(new Point(rect.Right, rect.Bottom), new Point(rect.X, rect.Bottom));
            }

            if (ltRadius > 0)
            {
                path.AddLine(new Point(rect.X, rect.Bottom - lbRadius), new Point(rect.X, rect.Y + ltRadius));
            }
            else
            {
                path.AddLine(new Point(rect.X, rect.Bottom), new Point(rect.X, rect.Y));
            }

            path.CloseFigure();
            return path;
        }

        #endregion
    }
}