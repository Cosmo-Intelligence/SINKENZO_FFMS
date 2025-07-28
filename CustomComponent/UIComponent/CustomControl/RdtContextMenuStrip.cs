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
    public partial class RdtContextMenuStrip : ContextMenuStrip, IMenuStyleProvider
    {
        #region "定数"
        private const string MENU = "メニュー";
        #endregion

        #region "クラス変数"
        private static readonly ILog mLog = LogManager.GetLogger(typeof(RdtContextMenuStrip));
        private string mMenuForeColor = Constants.DEFAULT_FONT_COLOR;
        private string mMenuBackColor = Constants.DEFAULT_BACK_COLOR;
        private string mMenuSelectedForeColor = Constants.DEFAULT_BACK_COLOR; // 暫定
        private string mMenuSelectedBackColor = Constants.DEFAULT_FONT_COLOR; // 暫定
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
        public string MenuSelectedForeColor => this.mMenuSelectedForeColor;

        /// <summary>
        /// 選択行の背景色
        /// </summary>
        public string MenuSelectedBackColor => this.mMenuSelectedBackColor;
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
            this.mMenuForeColor = ComponentCommon.GetFontColor();
            this.mMenuBackColor = ComponentCommon.GetBackColor();
            //this.mMenuSelectedForeColor = "#FFFFFF"; //暫定
            //this.mMenuSelectedBackColor = "#FFFFFF"; //暫定

            // renderの更新
            this.Renderer = new MenuCustomRender(this);
        }
        #endregion
    }
}
//---<<END OF FILE>>-----------------------------------------------------