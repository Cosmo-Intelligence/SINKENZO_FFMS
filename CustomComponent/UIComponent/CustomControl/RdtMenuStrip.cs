//-----------------------------------------------------------------------
// <copyright file="RdtMenuStrip.cs" company="FUJIFILM Medical Solutions Corporation">
// Copyright (C) 2025 FUJIFILM Medical Solutions Corporation.
// </copyright>
//-----------------------------------------------------------------------
using System.ComponentModel;

using log4net;

namespace RADISTA.UIComponent.CustomControl
{
    /// <summary>
    /// RdtMenuStripクラス
    /// </summary>
    /// <remarks>
    /// 
    /// (Rev.)        (Date)      (ID / NAME)                     (Comment)
    /// V1.00.00    : 2025.05.01    : 株式会社コスモ・インテリジェンス / 藤原崇文   : original
    ///
    /// </remarks>
    public partial class RdtMenuStrip : MenuStrip, IMenuStyleProvider
    {
        #region "定数"
        private const string MENU = "メニュー";
        #endregion

        #region "クラス変数"
        private static readonly ILog mLog = LogManager.GetLogger(typeof(RdtMenuStrip));
        private string mMenuForeColor = Constants.MENU_DEFAULT_FONT_COLOR;
        private string mMenuBackColor = Constants.MENU_DEFAULT_BACK_COLOR;
        private string mMenuHoverForeColor = Constants.MENU_HOVER_FONT_COLOR;
        private string mMenuHoverBackColor = Constants.MENU_HOVER_BACK_COLOR;
        private string mMenuDisableForeColor = Constants.MENU_DISABLE_FONT_COLOR;
        private string mMenuDisableBackColor = Constants.MENU_DISABLE_BACK_COLOR;
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
        /// ホバー時の前景色
        /// </summary>
        public string MenuHoverForeColor => this.mMenuHoverForeColor;

        /// <summary>
        /// ホバー時の背景色
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
        #endregion

        #region "パブリックメソッド"
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public RdtMenuStrip()
        {
            this.InitializeComponent();

            this.InitializeCustomSetting();
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="container">コンテナ</param>
        public RdtMenuStrip(IContainer container)
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
            this.mMenuForeColor = ComponentCommon.GetMenuDefaultFontColor();
            this.mMenuBackColor = ComponentCommon.GetMenuDefaultBackColor();
            this.mMenuHoverForeColor = ComponentCommon.GetMenuHoverFontColor();
            this.mMenuHoverBackColor = ComponentCommon.GetMenuHoverBackColor();
            this.mMenuDisableForeColor = ComponentCommon.GetMenuDisableFontColor();
            this.mMenuDisableBackColor = ComponentCommon.GetMenuDisableBackColor();

            // renderの更新
            this.Renderer = new MenuCustomRender(this);
        }
        #endregion
    }
}
//---<<END OF FILE>>-----------------------------------------------------