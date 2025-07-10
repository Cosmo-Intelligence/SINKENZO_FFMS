//-----------------------------------------------------------------------
// <copyright file="RdtGadget.cs" company="FUJIFILM Medical Solutions Corporation">
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

using WeifenLuo.WinFormsUI.Docking;

using static RADISTA.UIComponent.CustomControl.RdtLabel;

namespace RADISTA.UIComponent.CustomControl
{
    /// <summary>
    /// RdtGadgetクラス
    /// </summary>
    /// <remarks>
    /// 
    /// (Rev.)        (Date)      (ID / NAME)                     (Comment)
    /// V1.00.00    : 2025.05.01    : 株式会社コスモ・インテリジェンス / 藤原崇文   : original
    ///
    /// </remarks>
    public partial class RdtGadget : DockPanel
    {
        #region "定数"
        private const string GADGET = "ガジェット";
        #endregion

        #region "クラス変数"
        private static readonly ILog mLog = LogManager.GetLogger(typeof(RdtGadget));
        private bool mIsVisible = true;
        #endregion

        #region "プロパティ"
        /// <summary>
        /// ガジェットの表示/非表示
        /// </summary>
        [Category(GADGET)]
        public bool IsVisible
        {
            get => this.mIsVisible;
            set
            {
                this.mIsVisible = value;
            }
        }
        #endregion

        #region "パブリックメソッド"
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public RdtGadget()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="container">コンテナ</param>
        public RdtGadget(IContainer container)
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

            this.Theme = new VS2015DarkTheme();
            this.Dock = DockStyle.None;

            this.Visible = this.mIsVisible;

            // サイズ指定はフォームでないと出来ない？
            //this.Location = new Point(0, 10); // タイトルバーの下に配置
            //this.Size = new Size(this.ClientSize.Width, this.ClientSize.Height - 10); // フォームの残りのスペースを埋める
        }
        #endregion
    }
}
//---<<END OF FILE>>-----------------------------------------------------
