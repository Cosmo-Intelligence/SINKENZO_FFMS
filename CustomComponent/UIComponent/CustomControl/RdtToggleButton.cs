// -----------------------------------------------------------------------
// <copyright file="RdtToggleButton.cs" company="FUJIFILM Medical Solutions Corporation">
// Copyright (C) 2025 FUJIFILM Medical Solutions Corporation.
// </copyright>
// -----------------------------------------------------------------------
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
    /// RdtToggleButtonクラス
    /// </summary>
    /// <remarks>
    /// 
    /// (Rev.)        (Date)      (ID / NAME)                     (Comment)
    /// V1.00.00    : 2025.06.09    : 株式会社コスモ・インテリジェンス / 上原尚也   : original
    ///
    /// </remarks>
    public partial class RdtToggleButton : CheckBox
    {
        #region 定数
        /// <summary>
        /// カテゴリ名
        /// </summary>
        private const string BORDER = "ボーダー";
        /// <summary>
        /// 枠線の太さの最大
        /// </summary>
        private const int BORDER_TICK_MAX = 30;
        /// <summary>
        /// 枠線の太さの最小
        /// </summary>
        private const int BORDER_TICK_MIN = 1;
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
        private static readonly ILog mLog = LogManager.GetLogger(typeof(RdtToggleButton));
        private int mBorderThick = 1;
        private string mBorderColor = Constants.BORDER_COLOR;

        private string mMouseHoverColor = MOUSE_HOVER_COLOR;
        private string mMouseClickColor = MOUSE_CLICK_COLOR;
        private string mBackColor = Constants.DEFAULT_BACK_COLOR;

        #endregion

        #region プロパティ
        /// <summary>
        /// 枠線の色
        /// </summary>
        [Category(BORDER)]
        public string BorderColor
        {
            get => this.mBorderColor;
            set
            {
                this.mBorderColor = value;
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
        /// マウスホバー時の背景色
        /// </summary>
        [Category(FOCUS_COLOR)]
        public string MouseHoverColor
        {
            get => this.mMouseHoverColor;
            set
            {
                if (ComponentCommon.IsColorCode(value))
                {
                    this.mMouseHoverColor = value;
                }
                else
                {
                    this.mMouseHoverColor = MOUSE_HOVER_COLOR;
                    mLog.Debug("ComponentCommon.IsColorCode(value) is false");
                    mLog.Debug($"(this.mMouseHoverColor = {value})");
                }
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
                if (ComponentCommon.IsColorCode(value))
                {
                    this.mMouseClickColor = value;
                }
                else
                {
                    this.mMouseHoverColor = MOUSE_CLICK_COLOR;
                    mLog.Debug("ComponentCommon.IsColorCode(value) is false");
                    mLog.Debug($"(this.mMouseClickColor = {value})");
                }
            }
        }
        #endregion

        #region パブリックメソッド
        /// <summary>
        /// Initialize
        /// </summary>
        public RdtToggleButton()
        {
            this.InitializeComponent();
            this.InitializeCustomSetting();
        }

        /// <summary>
        /// Initialize
        /// </summary>
        /// <param name="container">container</param>
        public RdtToggleButton(IContainer container)
        {
            container.Add(this);

            this.InitializeComponent();
            this.InitializeCustomSetting();
        }
        #endregion

        #region プロテクテッドメソッド
        /// <summary>
        /// OnPaint
        /// </summary>
        /// <param name="pevent">event</param>
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

                pevent.Graphics.Clear(ColorTranslator.FromHtml(this.mBackColor));

                //最初に背景を塗りつぶす
                using (SolidBrush brush = new SolidBrush(this.BackColor))
                {
                    pevent.Graphics.FillRectangle(brush, this.ClientRectangle);
                }

                //ボーダーの描画
                Rectangle outerRect = this.ClientRectangle;
                outerRect.X += int.Max((this.mBorderThick / 2) - 1, 0);
                outerRect.Y += int.Max((this.mBorderThick / 2) - 1, 0);
                outerRect.Width -= int.Max(this.mBorderThick - 1, 1);
                outerRect.Height -= int.Max(this.mBorderThick - 1, 1);

                using (Pen pen = new Pen(ColorTranslator.FromHtml(this.mBorderColor), this.mBorderThick))
                {
                    pevent.Graphics.DrawRectangle(pen, outerRect);
                }

                using (Brush brush = new SolidBrush(this.ForeColor))
                {
                    string drawText = this.Text ?? string.Empty;

                    //文字列のサイズを取得
                    SizeF textSize = pevent.Graphics.MeasureString(drawText, this.Font);

                    //描画不可範囲
                    int nonPortableRange = this.BorderThick * 4;

                    //描画開始位置調整
                    int offsetX = this.BorderThick * 2;

                    //描画可能範囲
                    int drawRangeX = this.ClientSize.Width - nonPortableRange;
                    int drawRangeY = this.ClientSize.Height;

                    float x = ((drawRangeX - textSize.Width) / 2f) + offsetX;
                    float y = (drawRangeY - textSize.Height) / 2f;

                    pevent.Graphics.DrawString(drawText, this.Font, brush, x, y);
                }
            }
            catch (Exception ex)
            {
                mLog.Debug("OnPaint_Exception");
                mLog.Error(ex.ToString());
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

            this.Appearance = Appearance.Button;

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
