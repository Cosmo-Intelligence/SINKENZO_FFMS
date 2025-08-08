//-----------------------------------------------------------------------
// <copyright file="RdtListButton.cs" company="FUJIFILM Medical Solutions Corporation">
// Copyright (C) 2025 FUJIFILM Medical Solutions Corporation.
// </copyright>
//-----------------------------------------------------------------------
using System.ComponentModel;
using System.Drawing.Drawing2D;

using RADISTA.UIComponent.CustomControl;

namespace RADISTA.SPREAD.CustomControl
{
    /// <summary>
    /// RdtListButton クラス
    /// </summary>
    /// <remarks>
    /// 
    /// (Rev.)        (Date)      (ID / NAME)                     (Comment)
    /// V1.00.00    : 2025.08.08    : 株式会社コスモ・インテリジェンス / 上原尚也   : original
    ///
    /// </remarks>
    public partial class RdtListButton : UserControl
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
        private const string LIST = "リスト";
        private const string LIST_COLOR = "リスト_カラー";
        private const string LIST_BORDER = "リスト_ボーダー";
        private const string LIST_CORNER = "リスト_コーナー";
        private const string LIST_STYLE = "リスト_スタイル";
        /// <summary>
        /// カテゴリ名
        /// </summary>
        private const string BUTTON_BORDER = "ボタン_ボーダー";
        /// <summary>
        /// カテゴリ名
        /// </summary>
        private const string BUTTON_FOCUS_COLOR = "ボタン_フォーカスカラー";
        /// <summary>
        /// カテゴリ名
        /// </summary>
        private const string BUTTON_DISPLAY = "ボタン_表示(カスタム)";
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

        //ListButtonのパーツ
        private bool mIsDropped = false;
        private RdtListBox mDropDownList = new RdtListBox();
        private RdtButton mButton = new RdtButton();

        //ボタン
        private string mButtonText = string.Empty;

        //ドロップダウン関連
        private bool mIsUpperDrop = false;
        private int mDropdownHeight = 150;

        private DrawStyleT mDrawStyle = DrawStyleT.Standard;

        //デフォルト位置を記憶しておく
        private Point mDefaultLocation = new Point(0, 0);

        #endregion

        #region "プロパティ"
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
        /// ボタンのテキスト
        /// </summary>
        [Category(LIST)]
        public string ButtonText
        {
            get => this.mButton.Text;
            set
            {
                this.mButtonText = value;
                this.mButton.Text = value;
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
                // エラー判定はコンポーネント側のプロパティで実施
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
                // エラー判定はコンポーネント側のプロパティで実施
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
                // エラー判定はコンポーネント側のプロパティで実施
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
                // エラー判定はコンポーネント側のプロパティで実施
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
                // エラー判定はコンポーネント側のプロパティで実施
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
                // エラー判定はコンポーネント側のプロパティで実施
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
                // エラー判定はコンポーネント側のプロパティで実施
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
                // エラー判定はコンポーネント側のプロパティで実施
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
                // エラー判定はコンポーネント側のプロパティで実施
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

        #region ボタンのプロパティ
        /// <summary>
        /// 枠線の色
        /// </summary>
        [Category(BUTTON_BORDER)]
        public string OuterBorderColor
        {
            get => this.mButton.OuterBorderColor;
            set
            {
                // エラー判定はコンポーネント側のプロパティで実施
                this.mButton.OuterBorderColor = value;
            }
        }

        /// <summary>
        /// ボーダーの太さ（pixel）
        /// </summary>
        [Category(BUTTON_BORDER)]
        public int BorderThick
        {
            get => this.mButton.BorderThick;
            set
            {
                int newValue = Math.Max(BORDER_TICK_MIN, Math.Min(BORDER_TICK_MAX, value));
                this.mButton.BorderThick = newValue;
            }
        }

        /// <summary>
        /// 二重ボーダーの内側の色
        /// </summary>
        [Category(BUTTON_BORDER)]
        public string InnerBorderColor
        {
            get => this.mButton.InnerBorderColor;
            set
            {
                // エラー判定はコンポーネント側のプロパティで実施
                this.mButton.InnerBorderColor = value;
            }
        }

        /// <summary>
        /// コーナーの角度
        /// </summary>
        [Category(BUTTON_BORDER)]
        public int CornerRadius
        {
            get => this.mButton.CornerRadius;
            set
            {
                int newValue = Math.Max(CORNER_RADIUS_MIN, Math.Min(CORNER_RADIUS_MAX, value));
                this.mButton.CornerRadius = newValue;
            }
        }

        /// <summary>
        /// マウスホバー時の背景色
        /// </summary>
        [Category(BUTTON_FOCUS_COLOR)]
        public string MouseHoverColor
        {
            get => this.mButton.MouseHoverColor;
            set
            {
                // エラー判定はコンポーネント側のプロパティで実施
                this.mButton.MouseHoverColor = value;
            }
        }

        /// <summary>
        /// マウスクリック時の色
        /// </summary>
        [Category(BUTTON_FOCUS_COLOR)]
        public string MouseClickColor
        {
            get => this.mButton.MouseClickColor;
            set
            {
                // エラー判定はコンポーネント側のプロパティで実施
                this.mButton.MouseClickColor = value;
            }
        }

        /// <summary>
        /// テキストの均等割り付け
        /// </summary>
        [Category(BUTTON_DISPLAY)]
        public RdtButton.TextJustifyT TextJustify
        {
            get => this.mButton.TextJustify;
            set => this.mButton.TextJustify = value;
        }

        /// <summary>
        /// ボタンテキストの向き
        /// </summary>
        [Category(BUTTON_DISPLAY)]
        public RdtButton.TextOrientationT TextOrientation
        {
            get => this.mButton.TextOrientation;
            set => this.mButton.TextOrientation = value;
        }

        /// <summary>
        /// 画像のファイルパス
        /// <para>
        /// 初期化時のみ変更が有効
        /// </para>
        /// </summary>
        [Category(BUTTON_DISPLAY)]
        public string ImageFilePath
        {
            get => this.mButton.ImageFilePath;
            set => this.mButton.ImageFilePath = value;
        }
        #endregion

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
                    this.mButton.Text = this.mButtonText;
                }
                else
                {
                    this.mButton.Text = this.mDropDownList.SelectedItem;
                }
            }
        }

        #endregion

        #region "パブリックメソッド"

        /// <summary>
        /// 初期化処理
        /// </summary>
        public RdtListButton()
        {
            this.InitializeComponent();
            this.InitializeCustomSetting();
        }

        /// <summary>
        /// 初期化処理
        /// </summary>
        /// <param name="container">container</param>
        public RdtListButton(IContainer container)
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

        #region"プライベートメソッド"

        /// <summary>
        /// Initialize処理
        /// </summary>
        private void InitializeCustomSetting()
        {
            // トップパネル（ラベル＋矢印）
            this.mButton = new RdtButton
            {
                Height = 30,
                Width = this.Width,
                Dock = DockStyle.None,
                BackColor = Color.FromArgb(45, 45, 48),
            };
            this.Controls.Add(this.mButton);

            // ドロップダウン（SpreadListBox）
            this.mDropDownList = new RdtListBox
            {
                Visible = false,
                Height = this.mDropdownHeight,
                Width = this.Width,
                Location = new Point(0, this.mButton.Bottom), // ← ラベル下に配置
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right,
            };
            this.Controls.Add(this.mDropDownList);

            this.Height = this.mButton.Height;
            this.Width = this.mButton.Width;

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
            this.mButton.Dispose();
        }

        /// <summary>
        /// トグルの表示非表示の処理
        /// </summary>
        private void ToggleDropDown(object? sender, EventArgs e)
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
                    this.Height = this.mDropDownList.Height + this.mButton.Height;

                    this.mButton.Location = new Point(this.mButton.Location.X, this.Height - this.mButton.Height);

                    this.mDropDownList.Width = this.Width;
                    this.mDropDownList.Visible = true;

                    // 自分自身を上にずらす（リストが上に飛び出すように）
                    this.Location = new Point(this.Location.X, this.Location.Y - this.mDropDownList.Height);
                }
                else
                {
                    this.mButton.Location = new Point(this.mButton.Location.X, 0);

                    this.mDropDownList.Location = new Point(0, this.mButton.Height + this.mButton.BorderThick); // ラベル下に表示
                    this.mDropDownList.Width = this.Width;
                    this.mDropDownList.Visible = true;

                    // 高さは固定にして、UserControl全体を伸ばす
                    this.Height = this.mButton.Height + this.mDropDownList.Height;
                }
            }
            else
            {
                this.mDropDownList.Visible = false;
                this.Height = this.mButton.Height;
                this.mButton.Location = new Point(this.mButton.Location.X, 0);
                this.Location = this.mDefaultLocation;
            }

            this.Refresh();
        }

        /// <summary>
        /// イベントのデタッチ処理
        /// </summary>
        private void DetachEvent()
        {
            this.SizeChanged -= this.RdtListButton_SizeChanged;
            this.mButton.Click -= this.ToggleDropDown;
            this.mDropDownList.SelectionChanged -= this.DropDownList_SelectionChanged;
        }

        /// <summary>
        /// イベントのアタッチ処理
        /// </summary>
        private void AttachEvent()
        {
            this.DetachEvent();
            this.SizeChanged += this.RdtListButton_SizeChanged;
            this.mButton.Click += this.ToggleDropDown;
            this.mDropDownList.SelectionChanged += this.DropDownList_SelectionChanged;
        }

        private void RdtListButton_SizeChanged(object? sender, EventArgs e)
        {
            this.mButton.Width = this.Width;
        }

        /// <summary>
        /// ドロップダウンの選択行変更イベント
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">event</param>
        private void DropDownList_SelectionChanged(object sender, FarPoint.Win.Spread.SelectionChangedEventArgs e)
        {
            this.mDropDownList.Visible = false;
            this.mIsDropped = false;
            this.Height = this.mButton.Height;
        }

        #endregion
    }
}
//---<<END OF FILE>>-----------------------------------------------------