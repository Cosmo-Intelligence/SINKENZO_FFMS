//-----------------------------------------------------------------------
// <copyright file="ContextMenuCustomRender.cs" company="FUJIFILM Medical Solutions Corporation">
// Copyright (C) 2025 FUJIFILM Medical Solutions Corporation.
// </copyright>
//-----------------------------------------------------------------------

namespace RADISTA.UIComponent.CustomControl
{
    /// <summary>
    /// ContextMenuCustomRenderクラス
    /// RdtContextMenuStrip用のカスタムRender
    /// </summary>
    /// <remarks>
    /// 
    /// (Rev.)        (Date)      (ID / NAME)                     (Comment)
    /// V1.00.00    : 2025.05.01    : 株式会社コスモ・インテリジェンス / 藤原崇文   : original
    ///
    /// </remarks>
    internal class ContextMenuCustomRender : ToolStripProfessionalRenderer
    {
        #region "クラス変数"
        private readonly IContextMenuStyleProvider mOwner;
        #endregion

        #region "パブリックメソッド"
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="owner">オーナークラス</param>
        public ContextMenuCustomRender(IContextMenuStyleProvider owner)
        {
            this.mOwner = owner;
        }
        #endregion

        #region "プロテクティッドメソッド"
        /// <summary>
        /// OnRenderItemText
        /// 前景色を変更
        /// </summary>
        /// <param name="e">イベント</param>
        protected override void OnRenderItemText(ToolStripItemTextRenderEventArgs e)
        {
            // 非アクティブ
            if (!e.Item.Enabled)
            {
                e.TextColor = ColorTranslator.FromHtml(this.mOwner.MenuDisableForeColor);
            }
            // チェック時かつホバー時
            else if (e.Item is ToolStripMenuItem menuItem && menuItem.Checked && e.Item.Selected)
            {
                e.TextColor = ColorTranslator.FromHtml(this.mOwner.MenuCheckedHoverForeColor);
            }
            // チェック時
            else if (e.Item is ToolStripMenuItem menuItem2 && menuItem2.Checked)
            {
                e.TextColor = ColorTranslator.FromHtml(this.mOwner.MenuCheckedForeColor);
            }
            // ホバー時
            else if (e.Item.Selected)
            {
                e.TextColor = ColorTranslator.FromHtml(this.mOwner.MenuHoverForeColor);
            }
            // 通常
            else
            {
                e.TextColor = ColorTranslator.FromHtml(this.mOwner.MenuForeColor);
            }

            base.OnRenderItemText(e);
        }

        /// <summary>
        /// OnRenderArrow
        /// 矢印の色を変更
        /// </summary>
        /// <param name="e">イベント</param>
        protected override void OnRenderArrow(ToolStripArrowRenderEventArgs e)
        {
            if (e.Item != null)
            {
                // 非アクティブ
                if (!e.Item.Enabled)
                {
                    e.ArrowColor = ColorTranslator.FromHtml(this.mOwner.MenuDisableForeColor);
                }
                // チェック時かつホバー時
                else if (e.Item is ToolStripMenuItem menuItem && menuItem.Checked && e.Item.Selected)
                {
                    e.ArrowColor = ColorTranslator.FromHtml(this.mOwner.MenuCheckedHoverForeColor);
                }
                // チェック時
                else if (e.Item is ToolStripMenuItem menuItem2 && menuItem2.Checked)
                {
                    e.ArrowColor = ColorTranslator.FromHtml(this.mOwner.MenuCheckedForeColor);
                }
                // ホバー時
                else if (e.Item.Selected)
                {
                    e.ArrowColor = ColorTranslator.FromHtml(this.mOwner.MenuHoverForeColor);
                }
                // 通常
                else
                {
                    e.ArrowColor = ColorTranslator.FromHtml(this.mOwner.MenuForeColor);
                }
            }

            // ベースの処理
            base.OnRenderArrow(e);
        }

        /// <summary>
        /// OnRenderMenuItemBackground
        /// 背景色を変更
        /// </summary>
        /// <param name="e">イベント</param>
        protected override void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs e)
        {
            Color color;

            // 非アクティブ
            if (!e.Item.Enabled)
            {
                color = ColorTranslator.FromHtml(this.mOwner.MenuDisableBackColor);
            }
            // チェック時かつホバー時
            else if (e.Item is ToolStripMenuItem menuItem && menuItem.Checked && e.Item.Selected)
            {
                color = ColorTranslator.FromHtml(this.mOwner.MenuCheckedHoverBackColor);
            }
            // チェック時
            else if (e.Item is ToolStripMenuItem menuItem2 && menuItem2.Checked)
            {
                color = ColorTranslator.FromHtml(this.mOwner.MenuCheckedBackColor);
            }
            // ホバー時
            else if (e.Item.Selected)
            {
                color = ColorTranslator.FromHtml(this.mOwner.MenuHoverBackColor);
            }
            // 通常
            else
            {
                color = ColorTranslator.FromHtml(this.mOwner.MenuBackColor);
            }

            using (SolidBrush brush = new SolidBrush(color))
            {
                e.Graphics.FillRectangle(brush, e.Item.ContentRectangle);
            }
        }

        /// <summary>
        /// OnRenderToolStripBorder
        /// メニュー全体のボーダー色を変更
        /// </summary>
        /// <param name="e">イベント</param>
        protected override void OnRenderToolStripBorder(ToolStripRenderEventArgs e)
        {
            using (Pen borderPen = new Pen(ColorTranslator.FromHtml(this.mOwner.MenuBackColor)))
            {
                Rectangle rect = new Rectangle(Point.Empty, e.ToolStrip.Size);
                rect.Width -= 1;
                rect.Height -= 1;
                e.Graphics.DrawRectangle(borderPen, rect);
            }
        }

        /// <summary>
        /// OnRenderToolStripBackground
        /// メニュー単位のボーダー色を変更
        /// </summary>
        /// <param name="e">イベント</param>
        protected override void OnRenderToolStripBackground(ToolStripRenderEventArgs e)
        {
            using (SolidBrush brush = new SolidBrush(ColorTranslator.FromHtml(this.mOwner.MenuBackColor)))
            {
                e.Graphics.FillRectangle(brush, e.AffectedBounds);
            }
        }

        /// <summary>
        /// OnRenderImageMargin
        /// 画像表示部の背景色を変更
        /// </summary>
        /// <param name="e">イベント</param>
        protected override void OnRenderImageMargin(ToolStripRenderEventArgs e)
        {
            Rectangle rect = e.AffectedBounds;
            using (Brush b = new SolidBrush(ColorTranslator.FromHtml(this.mOwner.MenuBackColor)))
            {
                e.Graphics.FillRectangle(b, rect);
            }
        }
        #endregion
    }
}
//---<<END OF FILE>>-----------------------------------------------------