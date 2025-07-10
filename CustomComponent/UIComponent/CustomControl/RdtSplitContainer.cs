//-----------------------------------------------------------------------
// <copyright file="RdtSplitContainer.cs" company="FUJIFILM Medical Solutions Corporation">
// Copyright (C) 2025 FUJIFILM Medical Solutions Corporation.
// </copyright>
//-----------------------------------------------------------------------
using System.ComponentModel;
using log4net;

namespace RADISTA.UIComponent.CustomControl
{
    /// <summary>
    /// RdtSplitContainerクラス
    /// </summary>
    /// <remarks>
    /// 
    /// (Rev.)        (Date)      (ID / NAME)                     (Comment)
    /// V1.00.00    : 2025.05.01    : 株式会社コスモ・インテリジェンス / 藤原崇文   : original
    ///
    /// </remarks>
    public partial class RdtSplitContainer : SplitContainer
    {
        #region "クラス変数"
        private static readonly ILog mLog = LogManager.GetLogger(typeof(RdtSplitContainer));
        #endregion

        #region "パブリックメソッド"
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public RdtSplitContainer()
        {
            this.InitializeComponent();

            this.InitializeCustomSetting();
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="container">コンテナ</param>
        public RdtSplitContainer(IContainer container)
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
        }

        /// <summary>
        /// OnPaint
        /// </summary>
        /// <param name="e">イベント</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            try
            {
                // スプリッターの描画
                Rectangle rect;
                if (this.Orientation == Orientation.Horizontal)
                {
                    // 横分割
                    rect = new Rectangle(0, this.SplitterDistance, this.Width, this.SplitterWidth);
                }
                else
                {
                    // 縦分割
                    rect = new Rectangle(this.SplitterDistance, 0, this.SplitterWidth, this.Height);
                }

                using (Brush brush = new SolidBrush(ColorTranslator.FromHtml(ComponentCommon.GetComponentEdgeColor())))
                {
                    e.Graphics.FillRectangle(brush, rect);
                }
            }
            catch (Exception ex)
            {
                mLog.Debug("OnPaint_Exception");
                mLog.Error(ex.ToString());
            }
        }
        #endregion

        #region "プライベートメソッド"
        /// <summary>
        /// 拡張コンポーネントの初期設定
        /// </summary>
        private void InitializeCustomSetting()
        {
            // デフォルト設定
            this.BackColor = ColorTranslator.FromHtml(ComponentCommon.GetBackColor());
        }
        #endregion
    }
}
//---<<END OF FILE>>-----------------------------------------------------
