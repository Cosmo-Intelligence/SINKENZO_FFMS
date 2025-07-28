//-----------------------------------------------------------------------
// <copyright file="RdtSplitter.cs" company="FUJIFILM Medical Solutions Corporation">
// Copyright (C) 2025 FUJIFILM Medical Solutions Corporation.
// </copyright>
//-----------------------------------------------------------------------
using System.ComponentModel;

using log4net;

namespace RADISTA.UIComponent.CustomControl
{
    /// <summary>
    /// RdtSplitterクラス
    /// </summary>
    /// <remarks>
    /// 
    /// (Rev.)        (Date)      (ID / NAME)                     (Comment)
    /// V1.00.00    : 2025.05.01    : 株式会社コスモ・インテリジェンス / 藤原崇文   : original
    ///
    /// </remarks>
    public partial class RdtSplitter : Splitter
    {
        #region "クラス変数"
        private static readonly ILog mLog = LogManager.GetLogger(typeof(RdtSplitter));
        #endregion

        #region "パブリックメソッド"
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public RdtSplitter()
        {
            this.InitializeComponent();

            this.InitializeCustomSetting();
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="container">コンテナ</param>
        public RdtSplitter(IContainer container)
        {
            container.Add(this);

            this.InitializeComponent();

            this.InitializeCustomSetting();
        }
        #endregion

        #region "プライベートメソッド"
        /// <summary>
        /// 拡張コンポーネントの初期設定
        /// </summary>
        private void InitializeCustomSetting()
        {
            // デフォルト設定
            this.BackColor = ColorTranslator.FromHtml(ComponentCommon.GetComponentEdgeColor());
        }
        #endregion
    }
}
//---<<END OF FILE>>-----------------------------------------------------
