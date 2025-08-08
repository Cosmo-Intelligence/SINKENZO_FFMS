//-----------------------------------------------------------------------
// <copyright file="RdtListBox.cs" company="FUJIFILM Medical Solutions Corporation">
// Copyright (C) 2025 FUJIFILM Medical Solutions Corporation.
// </copyright>
//-----------------------------------------------------------------------
using System.ComponentModel;
using System.Drawing.Drawing2D;

using FarPoint.Win;
using FarPoint.Win.Spread;
using FarPoint.Win.Spread.CellType;

namespace RADISTA.SPREAD.CustomControl
{
    /// <summary>
    /// RdtListBox クラス
    /// </summary>
    /// <remarks>
    /// 
    /// (Rev.)        (Date)      (ID / NAME)                     (Comment)
    /// V1.00.00    : 2025.08.08    : 株式会社コスモ・インテリジェンス / 上原尚也   : original
    ///
    /// </remarks>
    public partial class RdtListBox : UserControl
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
        /// <summary>
        /// カテゴリ名
        /// </summary>
        private const string COLOR = "カラー";
        /// <summary>
        /// カテゴリ名
        /// </summary>
        private const string STYLE = "スタイル";
        /// <summary>
        /// カテゴリ名
        /// </summary>
        private const string RADIUS = "コーナー";
        /// <summary>
        /// カテゴリ名
        /// </summary>
        private const string BORDER = "ボーダー";
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
        private const string LIST_DEFAULT_ALTERNATE_COLOR = "#123456";

        #endregion

        #region "メンバ変数"
        private FpSpread mFpSpread = new FpSpread();
        private SheetView mSheet = new SheetView();

        //前回ホバー時の行番号
        private int mBeforeHoveredRowIndex = -1;

        //フラグ
        private bool mUseAlternateColor = false;

        //カラー関連
        private string mForeColor = Constants.LIST_DEFAULT_STANDARD_FONT_COLOR;
        private string mCellBackColor = Constants.LIST_DEFAULT_STANDARD_BACK_COLOR;
        private string mAlternateColor = LIST_DEFAULT_ALTERNATE_COLOR;
        private string mHoverBackColor = Constants.LIST_HOVER_STANDARD_BACK_COLOR;
        private string mHoverBorderColor = Constants.LIST_HOVER_STANDARD_EDGE_COLOR;
        private string mDisableForeColor = Constants.LIST_DISABLE_STANDARD_FONT_COLOR;
        private string mDisableBackColor = Constants.LIST_DISABLE_STANDARD_BACK_COLOR;
        private string mFlatBackColor = Constants.LIST_DEFAULT_FLAT_BACK_COLOR;

        //ボーダー
        private int mBorderThick = 1;
        private string mBorderColor = Constants.LIST_DEFAULT_FLAT_EDGE_COLOR;
        private int mLeftTopCornerRadius = 8;
        private int mRightTopCornerRadius = 8;
        private int mLeftBottomCornerRadius = 8;
        private int mRightBottomCornerRadius = 8;

        //スタイル
        private DrawStyleT mDrawStyle = DrawStyleT.Standard;

        //セルボーダー
        private ComplexBorder? mCellBorder = null;
        private ComplexBorder? mAlternateCellBorder = null;
        private ComplexBorder? mHoveredCellBorder = null;
        #endregion

        #region "プロパティ"
        /// <summary>
        /// ボーダーの色
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
            }
        }

        /// <summary>
        /// ホバー時のボーダーカラー
        /// </summary>
        [Category(BORDER)]
        public string HoverBorderColor
        {
            get => this.mHoverBorderColor;
            set
            {
                // デザイナのプロパティで入力ミスがあった場合は直接エラーメッセージを出す
                if (!ComponentCommon.IsColorCode(value))
                {
                    throw new ArgumentException(Constants.ERROR_COLOR_CODE);
                }

                this.mHoverBorderColor = value;
            }
        }

        /// <summary>
        /// 文字の色を設定する
        /// </summary>
        [Category(COLOR)]
        public string FontColor
        {
            get => this.mForeColor;
            set
            {
                // デザイナのプロパティで入力ミスがあった場合は直接エラーメッセージを出す
                if (!ComponentCommon.IsColorCode(value))
                {
                    throw new ArgumentException(Constants.ERROR_COLOR_CODE);
                }

                this.mForeColor = value;
            }
        }

        /// <summary>
        /// 無効化時のフォントカラー
        /// </summary>
        [Category(COLOR)]
        public string DisableForeColor
        {
            get => this.mDisableForeColor;
            set
            {
                // デザイナのプロパティで入力ミスがあった場合は直接エラーメッセージを出す
                if (!ComponentCommon.IsColorCode(value))
                {
                    throw new ArgumentException(Constants.ERROR_COLOR_CODE);
                }

                this.mDisableForeColor = value;
            }
        }

        /// <summary>
        /// 無効化時の背景色
        /// </summary>
        [Category(COLOR)]
        public string DisableBackColor
        {
            get => this.mDisableBackColor;
            set
            {
                // デザイナのプロパティで入力ミスがあった場合は直接エラーメッセージを出す
                if (!ComponentCommon.IsColorCode(value))
                {
                    throw new ArgumentException(Constants.ERROR_COLOR_CODE);
                }

                this.mDisableBackColor = value;

                var cellBorderSide = new ComplexBorderSide(ColorTranslator.FromHtml(this.mDisableBackColor), 1);
                this.mCellBorder = new ComplexBorder(
                    cellBorderSide,       // Left
                    cellBorderSide,       // Top
                    cellBorderSide,       // Right
                    cellBorderSide);      // Bottom
            }
        }

        /// <summary>
        /// スタイルが「フラット」時の背景色
        /// </summary>
        [Category(COLOR)]
        public string FlatBackColor
        {
            get => this.mFlatBackColor;
            set
            {
                // デザイナのプロパティで入力ミスがあった場合は直接エラーメッセージを出す
                if (!ComponentCommon.IsColorCode(value))
                {
                    throw new ArgumentException(Constants.ERROR_COLOR_CODE);
                }

                this.mFlatBackColor = value;
            }
        }

        /// <summary>
        /// セルの背景交互色を使用するかどうか指定する
        /// </summary>
        [Category(COLOR)]
        public bool UseAlternateColor
        {
            get => this.mUseAlternateColor;
            set => this.mUseAlternateColor = value;
        }

        /// <summary>
        /// セルの背景色
        /// </summary>
        [Category(COLOR)]
        public string CellBackColor
        {
            get => this.mCellBackColor;
            set
            {
                // デザイナのプロパティで入力ミスがあった場合は直接エラーメッセージを出す
                if (!ComponentCommon.IsColorCode(value))
                {
                    throw new ArgumentException(Constants.ERROR_COLOR_CODE);
                }

                this.mCellBackColor = value;

                string backColor = this.Enabled == true ? this.mCellBackColor : this.mDisableBackColor;
                var cellBorderSide = new ComplexBorderSide(ColorTranslator.FromHtml(this.mCellBackColor), 1);
                this.mCellBorder = new ComplexBorder(
                    cellBorderSide,       // Left
                    cellBorderSide,       // Top
                    cellBorderSide,       // Right
                    cellBorderSide);      // Bottom
            }
        }

        /// <summary>
        /// セルの背景交互色の色を指定する
        /// </summary>
        [Category(COLOR)]
        public string AlternateColor
        {
            get => this.mAlternateColor;
            set
            {
                // デザイナのプロパティで入力ミスがあった場合は直接エラーメッセージを出す
                if (!ComponentCommon.IsColorCode(value))
                {
                    throw new ArgumentException(Constants.ERROR_COLOR_CODE);
                }

                this.mAlternateColor = value;
                var cellBorderSide = new ComplexBorderSide(ColorTranslator.FromHtml(this.mAlternateColor), 1);
                this.mAlternateCellBorder = new ComplexBorder(
                    cellBorderSide,       // Left
                    cellBorderSide,       // Top
                    cellBorderSide,       // Right
                    cellBorderSide);      // Bottom
            }
        }

        /// <summary>
        /// ホバー時の背景色
        /// </summary>
        [Category(COLOR)]
        public string HoverBackColor
        {
            get => this.mHoverBackColor;
            set
            {
                // デザイナのプロパティで入力ミスがあった場合は直接エラーメッセージを出す
                if (!ComponentCommon.IsColorCode(value))
                {
                    throw new ArgumentException(Constants.ERROR_COLOR_CODE);
                }

                this.mHoverBackColor = value;

                var cellBorderSide = new ComplexBorderSide(ColorTranslator.FromHtml(this.mHoverBackColor), 1);
                this.mHoveredCellBorder = new ComplexBorder(
                    cellBorderSide,       // Left
                    cellBorderSide,       // Top
                    cellBorderSide,       // Right
                    cellBorderSide);      // Bottom
            }
        }

        /// <summary>
        /// 左上のコーナー角度を指定する
        /// </summary>
        [Category(RADIUS)]
        public int LeftTopCornerRadius
        {
            get => this.mLeftTopCornerRadius;
            set
            {
                int newValue = Math.Max(CORNER_RADIUS_MIN, Math.Min(CORNER_RADIUS_MAX, value));
                this.mLeftTopCornerRadius = newValue;
            }
        }

        /// <summary>
        /// 右上のコーナー角度を指定する
        /// </summary>
        [Category(RADIUS)]
        public int RightTopCornerRadius
        {
            get => this.mRightTopCornerRadius;
            set
            {
                int newValue = Math.Max(CORNER_RADIUS_MIN, Math.Min(CORNER_RADIUS_MAX, value));
                this.mRightTopCornerRadius = newValue;
            }
        }

        /// <summary>
        /// 左下のコーナー角度を指定する
        /// </summary>
        [Category(RADIUS)]
        public int LeftBottomCornerRadius
        {
            get => this.mLeftBottomCornerRadius;
            set
            {
                int newValue = Math.Max(CORNER_RADIUS_MIN, Math.Min(CORNER_RADIUS_MAX, value));
                this.mLeftBottomCornerRadius = newValue;
            }
        }

        /// <summary>
        /// 右下のコーナー角度を指定する
        /// </summary>
        [Category(RADIUS)]
        public int RightBottomCornerRadius
        {
            get => this.mRightBottomCornerRadius;
            set
            {
                int newValue = Math.Max(CORNER_RADIUS_MIN, Math.Min(CORNER_RADIUS_MAX, value));
                this.mRightBottomCornerRadius = newValue;
            }
        }

        /// <summary>
        /// 描画スタイルを指定する
        /// </summary>
        [Category(STYLE)]
        public DrawStyleT DrawStyle
        {
            get => this.mDrawStyle;
            set
            {
                this.mDrawStyle = value;
                string borderColor = value == DrawStyleT.Standard ? this.mCellBackColor : this.mFlatBackColor;

                var cellBorderSide = new ComplexBorderSide(ColorTranslator.FromHtml(borderColor), 1);

                this.mCellBorder = new ComplexBorder(
                    cellBorderSide,       // Left
                    cellBorderSide,       // Top
                    cellBorderSide,       // Right
                    cellBorderSide);      // Bottom
            }
        }

        /// <summary>
        /// 選択中のアイテムテキスト
        /// </summary>
        [Browsable(false)]
        public string SelectedItem
        {
            get
            {
                int idx = this.mSheet.ActiveRowIndex;
                if (idx >= 0 && idx < this.mSheet.RowCount)
                {
                    return this.mSheet.Cells[idx, 0].Text;
                }
                return string.Empty;
            }
        }

        /// <summary>
        /// 選択中の行番号（0-based）
        /// </summary>
        [Browsable(false)]
        public int SelectedIndex
        {
            get => this.mSheet.ActiveRowIndex;
            set
            {
                if (value >= 0 && value < this.mSheet.RowCount)
                {
                    this.mSheet.SetActiveCell(value, 0);
                }
            }
        }

        /// <summary>
        /// SelectionChangedイベントを追加する
        /// </summary>
        [Browsable(false)]
        public event FarPoint.Win.Spread.SelectionChangedEventHandler SelectionChanged
        {
            add { this.mFpSpread.SelectionChanged += value; }
            remove { this.mFpSpread.SelectionChanged -= value; }
        }
        #endregion

        #region "パブリックメソッド"
        /// <summary>
        /// 初期化処理
        /// </summary>
        public RdtListBox()
        {
            this.InitializeComponent();

            this.InitializeCustomComponent();
        }

        /// <summary>
        /// 初期化処理
        /// </summary>
        /// <param name="container">container</param>
        public RdtListBox(IContainer container)
        {
            container.Add(this);

            this.InitializeComponent();

            this.InitializeCustomComponent();
        }

        /// <summary>
        /// アイテムを追加する
        /// </summary>
        /// <param name="itemText">アイテムのテキスト</param>
        public void AddItem(string itemText)
        {
            int rowIndex = this.mSheet.RowCount;
            this.mSheet.Rows.Add(rowIndex, 1);
            this.mSheet.Cells[rowIndex, 0].Text = itemText;
            this.mSheet.Rows[rowIndex].Height = 30;

            //色指定
            if (this.Enabled == true)
            {
                if (this.mUseAlternateColor == true)
                {
                    if (this.mSheet.RowCount % 2 == 1)
                    {
                        string backColor = this.DrawStyle == DrawStyleT.Standard ? this.mCellBackColor : this.mFlatBackColor;
                        this.mSheet.Cells[rowIndex, 0].BackColor = ColorTranslator.FromHtml(backColor);
                    }
                    else
                    {
                        this.mSheet.Cells[rowIndex, 0].BackColor = ColorTranslator.FromHtml(this.mAlternateColor);
                    }

                    this.mSheet.Cells[rowIndex, 0].Border = rowIndex % 2 == 0 ? this.mCellBorder : this.mAlternateCellBorder;
                }
                else
                {
                    string backColor = this.DrawStyle == DrawStyleT.Standard ? this.mCellBackColor : this.mFlatBackColor;
                    this.mSheet.Cells[rowIndex, 0].BackColor = ColorTranslator.FromHtml(backColor);
                    this.mSheet.Cells[rowIndex, 0].Border = this.mCellBorder;
                }
            }
            else
            {
                this.mSheet.Cells[rowIndex, 0].BackColor = ColorTranslator.FromHtml(this.mDisableBackColor);
                this.mSheet.Cells[rowIndex, 0].Border = this.mCellBorder;
            }

            this.mSheet.Columns[0].ForeColor = ColorTranslator.FromHtml(this.Enabled ? this.mForeColor : this.mDisableForeColor);

            // 再描画を強制
            this.Refresh();
        }

        /// <summary>
        /// アイテムをまとめて追加する
        /// </summary>
        /// <param name="items">アイテム名の配列</param>
        public void AddItems(string[] items)
        {
            foreach (var item in items)
            {
                this.AddItem(item);
            }
        }

        /// <summary>
        /// フォントを取得する
        /// </summary>
        /// <returns>シートのフォント</returns>
        public Font GetSheetFont()
        {
            return this.mFpSpread.Font;
        }

        /// <summary>
        /// アイテムからインデックスを取得する
        /// </summary>
        /// <param name="value">アイテム</param>
        /// <returns>インデックス</returns>
        public int GetIndexFromItem(string value)
        {
            int ret = -1;
            for (int i = 0; i < this.mSheet.RowCount; i++)
            {
                if (this.mSheet.Cells[i, 0].Text.Equals(value))
                {
                    return i;
                }
            }
            return ret;
        }

        /// <summary>
        /// シートモデルを取得する
        /// </summary>
        /// <returns>インデックス</returns>
        public FarPoint.Win.Spread.Model.DefaultSheetSelectionModel? GetSheetSelectionMode()
        {
            return this.mSheet.Models.Selection as FarPoint.Win.Spread.Model.DefaultSheetSelectionModel;
        }

        /// <summary>
        /// 垂直スクロールバーポリシーを設定する
        /// </summary>
        /// <param name="policy">ポリシー</param>
        public void SetVerticalScrollBarShow(ScrollBarPolicy policy)
        {
            this.mFpSpread.VerticalScrollBarPolicy = policy;
        }

        /// <summary>
        /// 列幅を設定する
        /// </summary>
        /// <param name="colummn">列</param>
        /// <param name="width">幅</param>
        public void SetColumnsWidth(int colummn, int width)
        {
            this.mSheet.Columns[colummn].Width = width;
        }

        /// <summary>
        /// テキスト位置を設定する
        /// </summary>
        /// <param name="colummn">列</param>
        /// <param name="horizontal">水平位置</param>
        /// <param name="vertical">垂直位置</param>
        public void SetColumnsTextPosition(int colummn, CellHorizontalAlignment horizontal, CellVerticalAlignment vertical)
        {
            this.mSheet.Columns[colummn].HorizontalAlignment = horizontal;
            this.mSheet.Columns[colummn].VerticalAlignment = vertical;
        }

        /// <summary>
        /// セルタイプを設定する
        /// </summary>
        /// <param name="colummn">列</param>
        /// <param name="cellType">セルタイプ</param>
        public void SetColumnsCellType(int colummn, TextCellType cellType)
        {
            this.mSheet.Columns[colummn].CellType = cellType;
        }
        #endregion

        #region "プロテクテッドメソッド"

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

        #endregion

        #region "プライベートメソッド"
        /// <summary>
        /// 初期化処理
        /// </summary>
        private void InitializeCustomComponent()
        {
            // 水平スクロールバーを非表示
            this.mFpSpread.HorizontalScrollBarPolicy = ScrollBarPolicy.Never;
            // 垂直スクロールバー
            this.mFpSpread.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.mFpSpread.VerticalScrollBarMode = VerticalScrollMode.PixelEnhanced;

            // FpSpreadをUserControlいっぱいに広げる
            this.mFpSpread.Dock = DockStyle.Fill;
            this.mFpSpread.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.mFpSpread.BorderStyle = BorderStyle.None;

            this.Controls.Add(this.mFpSpread);

            this.mFpSpread.Sheets.Add(this.mSheet);
            this.mSheet.OperationMode = FarPoint.Win.Spread.OperationMode.ReadOnly;

            // 基本設定
            this.mSheet.ColumnCount = 1;
            this.mSheet.RowCount = 0; // 初期は空
            this.mSheet.RowHeader.Visible = false;
            this.mSheet.ColumnHeader.Visible = false;

            this.mSheet.SelectionUnit = FarPoint.Win.Spread.Model.SelectionUnit.Row;
            this.mSheet.SelectionPolicy = FarPoint.Win.Spread.Model.SelectionPolicy.Single;

            this.mSheet.Columns[0].Width = 200;

            this.mFpSpread.ScrollBarMaxAlign = true;

            //スタイル設定
            this.mSheet.Columns[0].ForeColor = ColorTranslator.FromHtml(this.Enabled ? this.mForeColor : this.mDisableForeColor);
            this.mSheet.Columns[0].BackColor = ColorTranslator.FromHtml(this.Enabled ? this.mCellBackColor : this.DisableBackColor);

            //フォント設定
            string fontType = ComponentCommon.GetFontType();
            int fontSize = ComponentCommon.GetFontSize();
            this.mSheet.DefaultStyle.Font = new Font(fontType, fontSize);

            // 全領域のポインタを矢印に変更する
            foreach (CursorType type in Enum.GetValues(typeof(CursorType)))
            {
                this.mFpSpread.SetCursor(type, Cursors.Default);
            }

            //イベントを追加する
            this.AttachEvents();

            //ボーダーを設定する
            string borderColor = this.Enabled ? this.mCellBackColor : this.mDisableBackColor;

            var cellBorderSide = new ComplexBorderSide(ColorTranslator.FromHtml(borderColor), 1);
            this.mCellBorder = new ComplexBorder(
                cellBorderSide,       // Left
                cellBorderSide,       // Top
                cellBorderSide,       // Right
                cellBorderSide);      // Bottom

            var alternateBorderSide = new ComplexBorderSide(ColorTranslator.FromHtml(this.mAlternateColor), 1);

            // 上下左右を必要に応じて設定
            this.mAlternateCellBorder = new ComplexBorder(
                alternateBorderSide,  // Left
                alternateBorderSide,  // Top
                alternateBorderSide,  // Right
                alternateBorderSide); // Bottom

            var hoveredBorderSide = new ComplexBorderSide(ColorTranslator.FromHtml(this.mHoverBackColor), 1);
            this.mHoveredCellBorder = new ComplexBorder(
                hoveredBorderSide,    // Left
                hoveredBorderSide,    // Top
                hoveredBorderSide,    // Right
                hoveredBorderSide);   // Bottom
        }

        /// <summary>
        /// Dispose処理
        /// </summary>
        private void DisposeCustomComponent()
        {
            this.DetachEvents();
        }

        /// <summary>
        /// 描画イベント
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">Event</param>
        private void FpSpread_Paint(object? sender, PaintEventArgs e)
        {
            // 内枠用（角丸ボーダー描画）
            Rectangle borderRect = this.mFpSpread.ClientRectangle;
            borderRect.X += Math.Max((this.mBorderThick / 2) - 1, 0);
            borderRect.Y += Math.Max((this.mBorderThick / 2) - 1, 0);
            borderRect.Width -= Math.Max(this.mBorderThick * 2, 1);
            borderRect.Height -= Math.Max(this.mBorderThick * 2, 1);

            if (this.mDrawStyle == DrawStyleT.Standard)
            {
                string borderColor = this.Enabled ? this.mBorderColor : this.mDisableBackColor;
                using (Pen pen = new Pen(ColorTranslator.FromHtml(borderColor), this.mBorderThick))
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
        }

        /// <summary>
        /// イベントの削除処理
        /// </summary>
        private void DetachEvents()
        {
            if (this.mFpSpread != null)
            {
                this.mFpSpread.SelectionChanged -= this.FpSpread_SelectionChanged;
                this.mFpSpread.Paint -= this.FpSpread_Paint;
                this.mFpSpread.MouseMove -= this.FpSpread_MouseMove;
                this.mFpSpread.MouseLeave -= this.FpSpread_MouseLeave;
                this.mFpSpread.MouseWheel -= this.FpSpread_MouseWheel;
                this.mFpSpread.HorizontalScrollBar.Scroll -= this.ScrollBar_Scroll;
                this.mFpSpread.VerticalScrollBar.Scroll -= this.ScrollBar_Scroll;
                this.EnabledChanged -= this.RdtListBox_EnabledChanged;
            }
        }

        /// <summary>
        /// イベントの追加処理
        /// </summary>
        private void AttachEvents()
        {
            this.DetachEvents();

            this.mFpSpread.SelectionChanged += this.FpSpread_SelectionChanged;
            this.mFpSpread.Paint += this.FpSpread_Paint;
            this.mFpSpread.MouseMove += this.FpSpread_MouseMove;
            this.mFpSpread.MouseLeave += this.FpSpread_MouseLeave;
            this.mFpSpread.MouseWheel += this.FpSpread_MouseWheel;
            this.mFpSpread.HorizontalScrollBar.Scroll += this.ScrollBar_Scroll;
            this.mFpSpread.VerticalScrollBar.Scroll += this.ScrollBar_Scroll;
            this.EnabledChanged += this.RdtListBox_EnabledChanged;
        }

        private void FpSpread_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int selectedRow = this.mSheet.ActiveRowIndex;
            if (selectedRow >= 0 && selectedRow < this.mSheet.RowCount)
            {
                string selectedItem = this.mSheet.Cells[selectedRow, 0].Text;
            }
        }

        /// <summary>
        /// EnabledChanged
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">Event</param>
        private void RdtListBox_EnabledChanged(object? sender, EventArgs e)
        {
            //ボーダーを設定する
            string borderColor = this.Enabled ? this.mCellBackColor : this.mDisableBackColor;

            var cellBorderSide = new ComplexBorderSide(ColorTranslator.FromHtml(borderColor), 1);
            this.mCellBorder = new ComplexBorder(
                cellBorderSide,       // Left
                cellBorderSide,       // Top
                cellBorderSide,       // Right
                cellBorderSide);      // Bottom
        }

        /// <summary>
        /// ホイールイベント
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">event</param>
        private void FpSpread_MouseWheel(object? sender, MouseEventArgs e)
        {
            this.mFpSpread.Invalidate();
        }

        /// <summary>
        /// スクロールイベント
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">event</param>
        private void ScrollBar_Scroll(object? sender, ScrollEventArgs e)
        {
            this.mFpSpread.Invalidate();
        }

        /// <summary>
        /// マウスホバー解除イベント
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">event</param>
        private void FpSpread_MouseLeave(object? sender, EventArgs e)
        {
            // セル外 → 背景色を戻す
            if (this.mBeforeHoveredRowIndex >= 0 && this.mBeforeHoveredRowIndex < this.mSheet.RowCount)
            {
                string backColor = (this.mBeforeHoveredRowIndex % 2 == 0 || !this.mUseAlternateColor)
                    ? this.DrawStyle == DrawStyleT.Standard ? this.mCellBackColor : this.mFlatBackColor
                    : this.mAlternateColor;

                this.mSheet.Cells[this.mBeforeHoveredRowIndex, 0].BackColor = ColorTranslator.FromHtml(backColor);

                var border = (this.mBeforeHoveredRowIndex % 2 == 0 || !this.mUseAlternateColor)
                    ? this.mCellBorder
                    : this.mAlternateCellBorder;
                this.mSheet.Cells[this.mBeforeHoveredRowIndex, 0].Border = border;

                this.mBeforeHoveredRowIndex = -1;
            }
        }

        /// <summary>
        /// マウス移動のイベント
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">Event</param>
        private void FpSpread_MouseMove(object? sender, MouseEventArgs e)
        {
            if (this.mFpSpread.ActiveSheet == null)
            {
                return;
            }

            HitTestInformation hitInfo = this.mFpSpread.HitTest(e.X, e.Y);

            if (hitInfo == null)
            {
                return;
            }

            // セル上にマウスがあるかチェック
            if (hitInfo.Type == HitTestType.Viewport && hitInfo.ViewportInfo.Row >= 0 && hitInfo.ViewportInfo.Column >= 0)
            {
                int newRow = hitInfo.ViewportInfo.Row;

                if (newRow != this.mBeforeHoveredRowIndex)
                {
                    // 前の行の色を戻す
                    if (this.mBeforeHoveredRowIndex >= 0 && newRow != this.mBeforeHoveredRowIndex)
                    {
                        Color backColor = (this.mBeforeHoveredRowIndex % 2 == 0 || !this.mUseAlternateColor)
                            ? ColorTranslator.FromHtml(this.mCellBackColor)
                            : ColorTranslator.FromHtml(this.mAlternateColor);

                        this.mSheet.Cells[this.mBeforeHoveredRowIndex, 0].BackColor = backColor;

                        var border = (this.mBeforeHoveredRowIndex % 2 == 0 || !this.mUseAlternateColor)
                            ? this.mCellBorder
                            : this.mAlternateCellBorder;

                        this.mSheet.Cells[this.mBeforeHoveredRowIndex, 0].Border = border;
                    }

                    // 新しい行の色を変更
                    if (newRow >= 0 && newRow < this.mSheet.RowCount)
                    {
                        this.mSheet.Cells[newRow, 0].BackColor = ColorTranslator.FromHtml(this.mHoverBackColor);
                        this.mSheet.Cells[newRow, 0].Border = this.mHoveredCellBorder;
                    }

                    this.mBeforeHoveredRowIndex = newRow;
                }
            }
            else
            {
                // セル外 → 背景色を戻す
                if (this.mBeforeHoveredRowIndex >= 0 && this.mBeforeHoveredRowIndex < this.mSheet.RowCount)
                {
                    Color backColor = (this.mBeforeHoveredRowIndex % 2 == 0 || !this.mUseAlternateColor)
                        ? ColorTranslator.FromHtml(this.mCellBackColor)
                        : ColorTranslator.FromHtml(this.mAlternateColor);

                    this.mSheet.Cells[this.mBeforeHoveredRowIndex, 0].BackColor = backColor;

                    var border = (this.mBeforeHoveredRowIndex % 2 == 0 || !this.mUseAlternateColor)
                        ? this.mCellBorder
                        : this.mAlternateCellBorder;

                    this.mSheet.Cells[this.mBeforeHoveredRowIndex, 0].Border = border;

                    this.mBeforeHoveredRowIndex = -1;
                }
            }
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
//---<<END OF FILE>>-----------------------------------------------------