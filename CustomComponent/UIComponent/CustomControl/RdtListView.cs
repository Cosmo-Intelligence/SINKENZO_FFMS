//-----------------------------------------------------------------------
// <copyright file="RdtListView.cs" company="FUJIFILM Medical Solutions Corporation">
// Copyright (C) 2025 FUJIFILM Medical Solutions Corporation.
// </copyright>
//-----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using log4net;

namespace RADISTA.UIComponent.CustomControl
{
    /// <summary>
    /// RdtListViewクラス
    /// </summary>
    /// <remarks>
    /// 
    /// (Rev.)        (Date)      (ID / NAME)                     (Comment)
    /// V1.00.00    : 2025.07.09    : 株式会社コスモ・インテリジェンス / 笠間可奈子   : original
    ///
    /// </remarks>
    public partial class RdtListView : ListView
    {
        #region "定数"
        private const string BACKGROUND = "行の背景";
        private const string IMAGE = "アイコン";
        private const string CHECKBOX = "チェックボックス";
        private const int CHECKBOX_MARGIN = 4;
        private const int CHECKBOX_SIZE = 16;
        private const int CHECKBOX_AND_ICON_SPACING = CHECKBOX_MARGIN + CHECKBOX_SIZE;
        #endregion

        #region "クラス変数"
        private static readonly ILog mLog = LogManager.GetLogger(typeof(RdtListView));
        private bool mIsBackgroundColor = false;
        private string mBackgroundRowColor = Constants.BACKGROUND_ROW_COLOR;
        private bool mIsShowIcon = false;
        private string[]? mIconPath = null;
        private bool mIsShowCheckBox = false;
        private string mCheckBoxDesignPath = string.Empty;
        private string mUncheckBoxDesignPath = string.Empty;
        private Image? mCheckedImage;
        private Image? mUncheckedImage;
        private Image[]? mIconImages;
        #endregion

        #region "プロパティ"
        /// <summary>
        /// 行の交互背景色表示指定する/しない
        /// </summary>
        [Category(BACKGROUND)]
        public bool IsBackgroundColor
        {
            get => this.mIsBackgroundColor;
            set
            {
                this.mIsBackgroundColor = value;
            }
        }

        /// <summary>
        /// 行の背景色
        /// </summary>
        [Category(BACKGROUND)]
        public string BackgroundRowColor
        {
            get => this.mBackgroundRowColor;
            set
            {
                if (!ComponentCommon.IsColorCode(value))
                {
                    throw new ArgumentException(Constants.ERROR_COLOR_CODE);
                }
                this.mBackgroundRowColor = value;
            }
        }

        /// <summary>
        /// アイコン画像表示/非表示
        /// </summary>
        [Category(IMAGE)]
        public bool IsShowIcon
        {
            get => this.mIsShowIcon;
            set
            {
                this.mIsShowIcon = value;
            }
        }

        /// <summary>
        /// アイコン画像パス
        /// </summary>
        [Category(IMAGE)]
        [Description("ListView に表示する画像ファイルのパスの配列")]
        public string[]? IconPathList
        {
            get => this.mIconPath;
            set
            {
                this.mIconPath = value;
            }
        }

        /// <summary>
        /// チェックボックス表示/非表示
        /// </summary>
        [Category(CHECKBOX)]
        public bool IsShowCheckBox
        {
            get => this.mIsShowCheckBox;
            set
            {
                this.mIsShowCheckBox = value;
            }
        }

        /// <summary>
        /// チェックボックスデザインの画像パス
        /// </summary>
        [Category(CHECKBOX)]
        public string CheckBoxDesignPath
        {
            get => this.mCheckBoxDesignPath;
            set
            {
                this.mCheckBoxDesignPath = value;
            }
        }

        /// <summary>
        /// アンチェックボックスデザインの画像パス
        /// </summary>
        [Category(CHECKBOX)]
        public string UncheckBoxDesignPath
        {
            get => this.mUncheckBoxDesignPath;
            set
            {
                this.mUncheckBoxDesignPath = value;
            }
        }
        #endregion

        #region"コンストラクタ"
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public RdtListView()
        {
            this.InitializeComponent();
            this.InitializeCustomSetting();
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="container">コンテナ</param>
        public RdtListView(IContainer container)
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

            this.OwnerDraw = true;

            // View.Listのみを想定
            this.View = View.List;
            // チェックボックスは画像とイベントで実装するため、
            // 既存プロパティのチェックボックスは使用しない
            this.CheckBoxes = false;

            // イベントの追加
            this.DrawItem -= this.ListView_DrawItem;
            this.DrawItem += this.ListView_DrawItem;
            this.MouseClick -= this.RdtListView_MouseClick;
            this.MouseClick += this.RdtListView_MouseClick;
            // カラム幅の調節
            this.AdjustColumnWidths();

            try
            {
                // チェック画像の読み込み
                if (this.mIsShowCheckBox)
                {
                    this.mCheckedImage = ComponentCommon.GetImageFromPath(this.mCheckBoxDesignPath);
                    this.mUncheckedImage = ComponentCommon.GetImageFromPath(this.mUncheckBoxDesignPath);
                }
            }
            catch (Exception ex)
            {
                mLog.Error($"CheckBoxImage load failed:", ex);
                this.IsShowCheckBox = false;
            }

            try
            {
                // アイコン画像リストの読み込み
                if (this.mIsShowIcon)
                {
                    if (this.mIconPath != null && this.mIconPath.Length > 0)
                    {
                        this.mIconImages = new Image[this.mIconPath.Length];

                        // リストの件数分、画像を取得
                        for (int i = 0; i < this.mIconPath.Length; i++)
                        {
                            var image = ComponentCommon.GetImageFromPath(this.mIconPath[i]);
                            if (image != null)
                            {
                                this.mIconImages[i] = image;
                            }
                        }

                        // アイコンとアイテムが一致しない場合はアイコンを表示しない
                        if (this.Items.Count != this.mIconPath.Length)
                        {
                            this.mIsShowIcon = false;
                            this.mIconImages = null;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                mLog.Error($"IconImage load failed:", ex);
                this.mIsShowIcon = false;
                this.mIconImages = null;
            }
        }
        #endregion

        #region"プライベートメソッド"
        /// <summary>
        /// リストビューの描画
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        private void ListView_DrawItem(object? sender, DrawListViewItemEventArgs e)
        {
            // 偶数行の場合
            if (this.mIsBackgroundColor && e.ItemIndex % 2 != 0)
            {
                // 背景色を変更
                Color evenColor = ColorTranslator.FromHtml(this.mBackgroundRowColor);
                using Brush bgBrush = new SolidBrush(evenColor);
                Rectangle fullRowBounds = new Rectangle(0, e.Bounds.Y, this.ClientRectangle.Width, e.Bounds.Height);
                e.Graphics.FillRectangle(bgBrush, fullRowBounds);
            }

            int xOffset = e.Bounds.X + CHECKBOX_MARGIN;

            // チェックボックス描画
            if (this.mIsShowCheckBox)
            {
                var checkboxImage = e.Item.Checked ? this.mCheckedImage : this.mUncheckedImage;
                if (checkboxImage != null)
                {
                    Rectangle checkboxBounds = new Rectangle(xOffset, e.Bounds.Y + CHECKBOX_MARGIN, CHECKBOX_SIZE, CHECKBOX_SIZE);
                    e.Graphics.DrawImage(checkboxImage, checkboxBounds);
                    xOffset += CHECKBOX_AND_ICON_SPACING;
                }
            }

            // アイコン描画
            if (this.mIsShowIcon && this.mIconImages != null && e.ItemIndex < this.mIconImages.Length)
            {
                Image icon = this.mIconImages[e.ItemIndex];
                if (icon != null)
                {
                    Rectangle iconBounds = new Rectangle(
                        xOffset,
                        e.Bounds.Y + CHECKBOX_MARGIN,
                        CHECKBOX_SIZE,
                        CHECKBOX_SIZE);
                    e.Graphics.DrawImage(icon, iconBounds);
                    xOffset += CHECKBOX_SIZE + CHECKBOX_MARGIN;
                }
            }

            // テキスト描画
            Rectangle textBounds = new Rectangle(xOffset, e.Bounds.Y, e.Bounds.Right - xOffset, e.Bounds.Height);

            TextRenderer.DrawText(
                e.Graphics,
                e.Item.Text,
                e.Item.Font,
                textBounds,
                e.Item.ForeColor,
                TextFormatFlags.Left | TextFormatFlags.VerticalCenter);
        }

        /// <summary>
        /// チェックボックス画像切り替えクリックイベント
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        private void RdtListView_MouseClick(object? sender, MouseEventArgs e)
        {
            // チェックボックスが非表示の場合は処理しない
            if (!this.mIsShowCheckBox)
            {
                return;
            }

            var hitItem = this.GetItemAt(e.X, e.Y);
            if (hitItem == null)
            {
                return;
            }

            Rectangle checkboxBounds = new Rectangle(hitItem.Bounds.X + CHECKBOX_MARGIN, hitItem.Bounds.Y + CHECKBOX_MARGIN, CHECKBOX_SIZE, CHECKBOX_SIZE);
            // クリック位置がチェックボックス領域内
            if (checkboxBounds.Contains(e.Location))
            {
                // チェック状態を反転
                hitItem.Checked = !hitItem.Checked;
                this.Invalidate(hitItem.Bounds);
            }
        }

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
        }

        /// <summary>
        /// ImageのDispose
        /// </summary>
        private void DisposeCustomSetting()
        {
            this.DrawItem -= this.ListView_DrawItem;
            this.MouseClick -= this.RdtListView_MouseClick;

            // アイコン
            if (this.mIconImages != null)
            {
                foreach (var img in this.mIconImages)
                {
                    img?.Dispose();
                }
                this.mIconImages = null;
            }

            // チェックボックス
            if (this.mCheckedImage != null)
            {
                this.mCheckedImage.Dispose();
            }
            if (this.mUncheckedImage != null)
            {
                this.mUncheckedImage.Dispose();
            }
        }

        /// <summary>
        /// チェックボックスとアイコン配置を考慮してカラム幅を調節
        /// </summary>
        private void AdjustColumnWidths()
        {
            // 内容に合わせて自動調整
            this.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);

            // 追加で必要な幅を加算
            int extraWidth = 0;
            if (this.mIsShowCheckBox)
            {
                extraWidth += CHECKBOX_SIZE + CHECKBOX_MARGIN;
            }

            if (this.mIsShowIcon)
            {
                extraWidth += CHECKBOX_SIZE + CHECKBOX_MARGIN;
            }

            if (this.Columns.Count > 0)
            {
                this.Columns[0].Width += extraWidth;
            }
        }
        #endregion
    }
}
//---<<END OF FILE>>-----------------------------------------------------