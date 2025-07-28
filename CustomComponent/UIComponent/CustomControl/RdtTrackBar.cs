//-----------------------------------------------------------------------
// <copyright file="RdtTrackBar.cs" company="FUJIFILM Medical Solutions Corporation">
// Copyright (C) 2025 FUJIFILM Medical Solutions Corporation.
// </copyright>
//-----------------------------------------------------------------------
using System.ComponentModel;
using System.Diagnostics;

using log4net;

namespace RADISTA.UIComponent.CustomControl
{
    /// <summary>
    /// RdtTrackBarクラス
    /// </summary>
    /// <remarks>
    /// 
    /// (Rev.)        (Date)      (ID / NAME)                     (Comment)
    /// V1.00.00    : 2025.05.01    : 株式会社コスモ・インテリジェンス / 笠間可奈子   : original
    ///
    /// </remarks>
    public partial class RdtTrackBar : TrackBar
    {
        #region "列挙型"
        /// <summary>
        /// 目盛りテキスト表示スタイルの列挙型
        /// </summary>
        public enum TicktextStyleT
        {
            /// <summary>
            /// 表示なし
            /// </summary>
            None,
            /// <summary>
            /// 上部左側
            /// </summary>
            TopLeft,
            /// <summary>
            /// 下部右側
            /// </summary>
            BottomRight,
            /// <summary>
            /// 両側
            /// </summary>
            Both,
        }
        #endregion

        #region "定数"
        private const string INCREMENT_BUTTON = "インクリメントボタン";
        private const string SLIDER = "スライダー";
        private const string TICK_TEXT_STYLE = "目盛りテキスト";
        private const int SCALE_MIN = 0; // 最小値
        // インクリメントボタンのサイズ
        private const int BUTTON_SIZE = 35;
        // スライダーの幅
        private const int SLIDER_WIDTH = 12;
        #endregion

        #region "クラス変数"
        private static readonly ILog mLog = LogManager.GetLogger(typeof(RdtTrackBar));
        private bool mIsIncrementButton = false;
        private TicktextStyleT mTicktextStyle = TicktextStyleT.None;
        private string mSliderImagePath = string.Empty;
        private string mPlusButtonImagePath = string.Empty;
        private string mMinusButtonImagePath = string.Empty;
        private Image? mSlider = null;
        private Image? mPlusImage = null;
        private Image? mMinusImage = null;
        // スライダー選択中フラグ  -1：未選択(初期値) 0：選択中
        private int mSelectedSlider = -1;
        // 目盛りテキスト表示間隔単位
        private int mTickStep = 1;
        // 現在のスライダーの値格納用
        private int mValue;
        #endregion

        #region "プロパティ"
        /// <summary>
        /// インクリメントボタン表示あり/なし
        /// </summary>
        [Category(INCREMENT_BUTTON)]
        public bool IsIncrementButton
        {
            get => this.mIsIncrementButton;
            set
            {
                this.mIsIncrementButton = value;
            }
        }

        /// <summary>
        /// インクリメントボタン（プラス）イメージ
        /// </summary>
        [Category(INCREMENT_BUTTON)]
        public string PlusButtonImagePath
        {
            get => this.mPlusButtonImagePath;
            set
            {
                this.mPlusButtonImagePath = value;
            }
        }

        /// <summary>
        /// インクリメントボタン（マイナス）イメージ
        /// </summary>
        [Category(INCREMENT_BUTTON)]
        public string MinusButtonImagePath
        {
            get => this.mMinusButtonImagePath;
            set
            {
                this.mMinusButtonImagePath = value;
            }
        }

        /// <summary>
        /// 目盛りテキスト表示スタイル
        /// </summary>
        [Category(TICK_TEXT_STYLE)]
        public TicktextStyleT TicktextStyle
        {
            get => this.mTicktextStyle;
            set
            {
                this.mTicktextStyle = value;
            }
        }

        /// <summary>
        /// 目盛りテキスト表示間隔単位
        /// </summary>
        [Category(TICK_TEXT_STYLE)]
        public int TickStep
        {
            get => this.mTickStep;
            set
            {
                if (value < 1)
                {
                    this.mTickStep = SCALE_MIN;
                }
                else
                {
                    this.mTickStep = value;
                }
            }
        }

        /// <summary>
        /// スライダーイメージ
        /// </summary>
        [Category(SLIDER)]
        public string SliderImagePath
        {
            get => this.mSliderImagePath;
            set
            {
                this.mSliderImagePath = value;
            }
        }
        #endregion

        #region "パブリックメソッド"
        /// <summary>
        /// 値の更新を制御
        /// </summary>
        public new int Value
        {
            get => this.mValue;
            set
            {
                int newValue = Math.Max(this.Minimum, Math.Min(this.Maximum, value));
                // 既存の値と新しい値が異なる場合のみ処理を行う
                if (this.mValue != newValue)
                {
                    // 値を更新
                    this.mValue = newValue;
                    this.OnValueChanged(EventArgs.Empty);
                    this.Invalidate();
                }
            }
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public RdtTrackBar()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="container">コンテナ</param>
        public RdtTrackBar(IContainer container)
        {
            container.Add(this);
            this.InitializeComponent();
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

            // インクリメントボタン画像の取得
            // プラスボタン
            try
            {
                this.mPlusImage = ComponentCommon.GetImageFromPath(this.mPlusButtonImagePath);
            }
            catch (Exception ex)
            {
                mLog.Error("PlusButtonImage load is failed.");
                mLog.Error(ex);
            }
            // マイナスボタン
            try
            {
                this.mMinusImage = ComponentCommon.GetImageFromPath(this.mMinusButtonImagePath);
            }
            catch (Exception ex)
            {
                mLog.Error("MinusButtonImage load is failed.");
                mLog.Error(ex);
            }
            // スライダー画像の取得
            try
            {
                this.mSlider = ComponentCommon.GetImageFromPath(this.mSliderImagePath);
            }
            catch (Exception ex)
            {
                mLog.Error("SliderImage load is failed.");
                mLog.Error(ex);
            }

            this.InitializeCustomSetting();
            this.Value = (this.Maximum + this.Minimum) / 2;
        }

        /// <summary>
        /// トラックバー描画イベント
        /// </summary>
        /// <param name="e">e</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            // インクリメントボタン描画
            if (this.mIsIncrementButton)
            {
                this.DrawIncrementButtons(e.Graphics);
            }
            // トラック描画
            this.DrawTrack(e.Graphics);
            // 目盛（線とテキスト）描画
            this.DrawTicks(e.Graphics);
            // スライダー描画
            this.DrawSlider(e.Graphics);
        }

        /// <summary>
        /// マウスダウンイベント
        /// </summary>
        /// <param name="e">e</param>
        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (this.mSelectedSlider >= 0)
            {
                return;
            }
            // 左矢印ボタンの位置を計算
            Rectangle leftArrow = new Rectangle(0, (this.Height - BUTTON_SIZE) / 2, BUTTON_SIZE, BUTTON_SIZE);
            // 右矢印ボタンの位置を計算
            Rectangle rightArrow = new Rectangle(this.Width - BUTTON_SIZE, (this.Height - BUTTON_SIZE) / 2, BUTTON_SIZE, BUTTON_SIZE);
            // マウスクリックが左矢印ボタン内かチェック
            if (leftArrow.Contains(e.Location))
            {
                // スライダーの値を1つ減らし、最小値を超えないように制限
                int newVal = Math.Max(this.Minimum, this.Value - 1);
                if (this.Value != newVal)
                {
                    this.Value = newVal;
                    this.Invalidate();
                }
                return;
            }
            // マウスクリックが右矢印ボタン内かチェック
            if (rightArrow.Contains(e.Location))
            {
                // スライダーの値を1つ増やし、最大値を超えないように制限
                this.Value = Math.Min(this.Maximum, this.Value + 1);
                this.Invalidate();
                return;
            }

            // スライダーの位置を計算
            int x = this.ConvertPositionValue(this.Value);
            Rectangle thumbRect = new Rectangle(x - (SLIDER_WIDTH / 2), (this.Height / 2) - (BUTTON_SIZE / 2), SLIDER_WIDTH, BUTTON_SIZE);
            // マウスクリックがスライダー内かチェック
            if (thumbRect.Contains(e.Location))
            {
                // スライダーを選択し、ドラッグ操作を開始する
                this.mSelectedSlider = 0;
                // マウスキャプチャを有効化し、ドラッグを検知可能にする
                this.Capture = true;
                return;
            }
            base.OnMouseDown(e);
        }

        /// <summary>
        /// マウス動作イベント
        /// </summary>
        /// <param name="e">e</param>
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            // スライダーが選択されている場合
            if (this.mSelectedSlider >= 0)
            {
                // マウスの X 座標をスライダーの値に変換
                int value = this.ConvertSliderValue(e.X);
                // 範囲内に制限
                value = Math.Max(this.Minimum, Math.Min(this.Maximum, value));
                // スライダーの値を更新
                this.Value = value;
                this.Invalidate(); // 再描画
            }
        }

        /// <summary>
        /// マウスアップイベント
        /// </summary>
        /// <param name="e">e</param>
        protected override void OnMouseUp(MouseEventArgs e)
        {
            // 選択されていたスライダーを解除（ドラッグ操作終了）
            this.mSelectedSlider = -1;
            // マウスキャプチャを解除（これ以上のドラッグを検知しない）
            this.Capture = false;
            base.OnMouseUp(e);
        }
        #endregion

        #region "プライベートメソッド"
        /// <summary>
        /// コンストラクタ共通処理
        /// </summary>
        private void InitializeCustomSetting()
        {
            // デフォルト設定
            this.BackColor = ColorTranslator.FromHtml(ComponentCommon.GetBackColor());
            this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.UserPaint, true);
        }

        /// <summary>
        /// ImageのDispose
        /// </summary>
        private void DisposeCustomSetting()
        {
            // スライダー画像
            if (this.mSlider != null)
            {
                this.mSlider.Dispose();
                this.mSlider = null;
            }
            // インクリメントボタン
            if (this.mPlusImage != null)
            {
                this.mPlusImage.Dispose();
                this.mPlusImage = null;
            }
            if (this.mMinusImage != null)
            {
                this.mMinusImage.Dispose();
                this.mMinusImage = null;
            }
        }

        /// <summary>
        /// スライダーの幅を基準として、マウスの X 座標をスライダーの値に変換
        /// </summary>
        /// <param name="x">X座標値</param>
        /// <returns>スライダーの値</returns>
        private int ConvertSliderValue(int x)
        {
            float percent = (float)(x - BUTTON_SIZE - (SLIDER_WIDTH / 2)) / (this.Width - (2 * BUTTON_SIZE) - SLIDER_WIDTH);
            return this.Minimum + (int)(percent * (this.Maximum - this.Minimum));
        }

        /// <summary>
        /// スライダーの値を X 座標に変換
        /// </summary>
        /// <param name="sliderValue">スライダーの値</param>
        /// <returns>X座標値</returns>
        private int ConvertPositionValue(int sliderValue)
        {
            float percent = (float)(sliderValue - this.Minimum) / (this.Maximum - this.Minimum);
            return BUTTON_SIZE + (SLIDER_WIDTH / 2) + (int)(percent * (this.Width - (2 * BUTTON_SIZE) - SLIDER_WIDTH));
        }

        /// <summary>
        /// インクリメントボタン描画メソッド
        /// </summary>
        /// <param name="g">g</param>
        private void DrawIncrementButtons(Graphics g)
        {
            if (this.mPlusImage != null && this.mMinusImage != null)
            {
                // デクリメントボタン
                Rectangle leftArrow = new Rectangle(0, (this.Height - BUTTON_SIZE) / 2, BUTTON_SIZE, BUTTON_SIZE + 2);
                g.DrawImage(this.mMinusImage, leftArrow);
                // インクリメントボタン
                Rectangle rightArrow = new Rectangle(this.Width - BUTTON_SIZE - 2, (this.Height - BUTTON_SIZE) / 2, BUTTON_SIZE, BUTTON_SIZE + 2);
                g.DrawImage(this.mPlusImage, rightArrow);
            }
        }

        /// <summary>
        /// トラック描画メソッド
        /// </summary>
        /// <param name="g">g</param>
        private void DrawTrack(Graphics g)
        {
            int trackY = (this.Height / 2) - 2;
            Rectangle trackRect = new Rectangle(BUTTON_SIZE + (SLIDER_WIDTH / 2), trackY, this.Width - (2 * BUTTON_SIZE) - SLIDER_WIDTH, 4);
            g.FillRectangle(Brushes.LightGray, trackRect);
        }

        /// <summary>
        /// 目盛（線とテキスト）描画メソッド
        /// </summary>
        /// <param name="g">g</param>
        private void DrawTicks(Graphics g)
        {
            // スライダーの最小値から最大値までの目盛りの数を計算
            int iStepIdx = (this.Maximum - this.Minimum) / this.mTickStep;
            // 目盛りが無い場合は描画しない
            if (iStepIdx <= 0)
            {
                return;
            }

            for (int i = 0; i <= iStepIdx; i++)
            {
                // スライダー全体の幅に対する現在の目盛り位置の割合を求める
                float percent = (float)i / iStepIdx;
                // 目盛りのX座標を計算
                int x = this.GetTickXPosition(percent);
                // 目盛りの上端と下端のY座標を設定
                int tickTop = this.Height - 18;
                int tickBottom = this.Height - 12;
                // 目盛りの値を計算
                int tickValue = this.Minimum + (i * this.mTickStep);
                string scaleText = tickValue.ToString();
                // 目盛りラベルのテキストサイズを取得
                SizeF textSize = g.MeasureString(scaleText, this.Font);
                // ラベルのY座標を計算
                float topY = tickTop - textSize.Height - 31;
                float bottomY = tickBottom - 10;

                // 目盛り線を描画
                //g.DrawLine(Pens.Gray, x, tickTop, x, tickBottom);

                // 目盛りのラベルを描画
                switch (this.mTicktextStyle)
                {
                    // 上部
                    case TicktextStyleT.TopLeft:
                        this.DrawTickText(g, scaleText, x, topY);
                        break;
                    // 下部
                    case TicktextStyleT.BottomRight:
                        this.DrawTickText(g, scaleText, x, bottomY);
                        break;
                    // 両側
                    case TicktextStyleT.Both:
                        this.DrawTickText(g, scaleText, x, topY);
                        this.DrawTickText(g, scaleText, x, bottomY);
                        break;
                }
            }
        }

        /// <summary>
        /// スライダー描画メソッド
        /// </summary>
        /// <param name="g">g</param>
        private void DrawSlider(Graphics g)
        {
            if (this.mSlider == null)
            {
                return;
            }
            // X座標：ConvertPositionValue を使ってスライダーの位置を取得
            int x = this.ConvertPositionValue(this.Value);
            // トラック中心Yに画像を合わせる
            int centerY = this.Height / 2;
            int y = centerY - (this.mSlider.Height / 2);
            // スライダー画像の描画（中央揃え）
            g.DrawImage(this.mSlider, x - (this.mSlider.Width / 2), y);
        }

        /// <summary>
        /// 目盛りX座標の計算
        /// </summary>
        /// <param name="percent">トラックの幅に対する割合（0.0～1.0）</param>
        /// <returns>X座標の値</returns>
        private int GetTickXPosition(float percent)
        {
            return (int)(BUTTON_SIZE + (SLIDER_WIDTH / 2) + (percent * (this.Width - (2 * BUTTON_SIZE) - SLIDER_WIDTH)));
        }

        /// <summary>
        /// 目盛りテキストの描画処理
        /// </summary>
        /// <param name="g">Graphics</param>
        /// <param name="text">目盛りテキスト文字列</param>
        /// <param name="x">X座標</param>
        /// <param name="y">Y座標</param>
        private void DrawTickText(Graphics g, string text, float x, float y)
        {
            using Font tickTextFont = new Font(ComponentCommon.GetFontType(), 9);
            SizeF textSize = g.MeasureString(text, tickTextFont);
            using Brush textBrush = new SolidBrush(ColorTranslator.FromHtml(ComponentCommon.GetFontColor()));
            g.DrawString(text, tickTextFont, textBrush, x - (textSize.Width / 2), y);
        }
        #endregion
    }
}