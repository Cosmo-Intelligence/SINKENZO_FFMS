//-----------------------------------------------------------------------
// <copyright file="RdtContextMenuStrip.cs" company="FUJIFILM Medical Solutions Corporation">
// Copyright (C) 2025 FUJIFILM Medical Solutions Corporation.
// </copyright>
//-----------------------------------------------------------------------
using System.ComponentModel;

using log4net;

namespace RADISTA.UIComponent.CustomControl
{
    /// <summary>
    /// RdtContextMenuStripクラス
    /// </summary>
    /// <remarks>
    /// 
    /// (Rev.)        (Date)      (ID / NAME)                     (Comment)
    /// V1.00.00    : 2025.05.01    : 株式会社コスモ・インテリジェンス / 藤原崇文   : original
    ///
    /// </remarks>
    public partial class RdtContextMenuStrip : ContextMenuStrip, IContextMenuStyleProvider
    {
        #region "定数"
        private const string MENU = "メニュー";
        #endregion

        #region "クラス変数"
        private static readonly ILog mLog = LogManager.GetLogger(typeof(RdtContextMenuStrip));
        private string mMenuForeColor = Constants.CONTEXT_DEFAULT_FONT_COLOR;
        private string mMenuBackColor = Constants.CONTEXT_DEFAULT_BACK_COLOR;
        private string mMenuHoverForeColor = Constants.CONTEXT_HOVER_FONT_COLOR;
        private string mMenuHoverBackColor = Constants.CONTEXT_HOVER_BACK_COLOR;
        private string mMenuDisableForeColor = Constants.CONTEXT_DISABLE_FONT_COLOR;
        private string mMenuDisableBackColor = Constants.CONTEXT_DISABLE_BACK_COLOR;
        private string mMenuCheckedForeColor = Constants.CONTEXT_DISABLE_FONT_COLOR;
        private string mMenuCheckedBackColor = Constants.CONTEXT_DISABLE_BACK_COLOR;
        private string mMenuCheckedHoverForeColor = Constants.CONTEXT_DISABLE_FONT_COLOR;
        private string mMenuCheckedHoverBackColor = Constants.CONTEXT_DISABLE_BACK_COLOR;
        #endregion

        #region "プロパティ"
        /// <summary>
        /// 前景色
        /// </summary>
        public string MenuForeColor => this.mMenuForeColor;

        /// <summary>
        /// 背景色
        /// </summary>
        public string MenuBackColor => this.mMenuBackColor;

        /// <summary>
        /// 選択行の前景色
        /// </summary>
        public string MenuHoverForeColor => this.mMenuHoverForeColor;

        /// <summary>
        /// 選択行の背景色
        /// </summary>
        public string MenuHoverBackColor => this.mMenuHoverBackColor;

        /// <summary>
        /// 無効時の前景色
        /// </summary>
        public string MenuDisableForeColor => this.mMenuDisableForeColor;

        /// <summary>
        /// 無効時の背景色
        /// </summary>
        public string MenuDisableBackColor => this.mMenuDisableBackColor;

        /// <summary>
        /// チェック時の前景色
        /// </summary>
        public string MenuCheckedForeColor => this.mMenuCheckedForeColor;

        /// <summary>
        /// チェック時の背景色
        /// </summary>
        public string MenuCheckedBackColor => this.mMenuCheckedBackColor;

        /// <summary>
        /// チェック時かつホバー時の前景色
        /// </summary>
        public string MenuCheckedHoverForeColor => this.mMenuCheckedHoverForeColor;

        /// <summary>
        /// チェック時かつホバー時の背景色
        /// </summary>
        public string MenuCheckedHoverBackColor => this.mMenuCheckedHoverBackColor;
        #endregion

        #region "パブリックメソッド"
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public RdtContextMenuStrip()
        {
            this.InitializeComponent();

            this.InitializeCustomSetting();
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="container">コンテナ</param>
        public RdtContextMenuStrip(IContainer container)
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
        #endregion

        #region "プライベートメソッド"
        /// <summary>
        /// 拡張コンポーネントの初期設定
        /// </summary>
        private void InitializeCustomSetting()
        {
            // デフォルト設定
            string fontType = ComponentCommon.GetFontType();
            int fontSize = ComponentCommon.GetFontSize();
            this.Font = new Font(fontType, fontSize);
            this.mMenuForeColor = ComponentCommon.GetContextDefaultFontColor();
            this.mMenuBackColor = ComponentCommon.GetContextDefaultBackColor();
            this.mMenuHoverForeColor = ComponentCommon.GetContextHoverFontColor();
            this.mMenuHoverBackColor = ComponentCommon.GetContextHoverBackColor();
            this.mMenuDisableForeColor = ComponentCommon.GetContextDisableFontColor();
            this.mMenuDisableBackColor = ComponentCommon.GetContextDisableBackColor();
            this.mMenuCheckedForeColor = ComponentCommon.GetContextSelectedFontColor();
            this.mMenuCheckedBackColor = ComponentCommon.GetContextSelectedBackColor();
            this.mMenuCheckedHoverForeColor = ComponentCommon.GetContextSelectedHoverFontColor();
            this.mMenuCheckedHoverBackColor = ComponentCommon.GetContextSelectedHoverBackColor();

            // renderの更新
            this.Renderer = new ContextMenuCustomRender(this);
        }
        #endregion
    }
}
//---<<END OF FILE>>-----------------------------------------------------