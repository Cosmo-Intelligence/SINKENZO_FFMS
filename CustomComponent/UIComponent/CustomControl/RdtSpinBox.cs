//-----------------------------------------------------------------------
// <copyright file="RdtSpinBox.cs" company="FUJIFILM Medical Solutions Corporation">
// Copyright (C) 2025 FUJIFILM Medical Solutions Corporation.
// </copyright>
//-----------------------------------------------------------------------
using System.ComponentModel;

using log4net;

namespace RADISTA.UIComponent.CustomControl
{
    /// <summary>
    /// RdtSpinBoxクラス
    /// </summary>
    /// <remarks>
    /// 
    /// (Rev.)        (Date)      (ID / NAME)                     (Comment)
    /// V1.00.00    : 2025.05.01    : 株式会社コスモ・インテリジェンス / 笠間可奈子   : original
    ///
    /// </remarks>
    public partial class RdtSpinBox : NumericUpDown
    {
        #region "定数"
        private const string WRAP = "ループ有効範囲";
        #endregion

        #region "クラス変数"
        private static readonly ILog mLog = LogManager.GetLogger(typeof(RdtSpinBox));
        private bool mIsWrap = false;
        #endregion

        #region "プロパティ"
        /// <summary>
        /// ループ有効/無効
        /// </summary>
        [Category(WRAP)]
        public bool IsWrap
        {
            get => this.mIsWrap;
            set
            {
                this.mIsWrap = value;
            }
        }
        #endregion

        #region "パブリックメソッド"
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public RdtSpinBox()
        {
            this.InitializeComponent();
            this.InitializeCustomSetting();
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="container">コンテナ</param>
        public RdtSpinBox(IContainer container)
        {
            container.Add(this);

            this.InitializeComponent();
            this.InitializeCustomSetting();
        }
        #endregion

        #region "パブリックメソッド"
        /// <summary>
        /// 上ボタンをクリック
        /// </summary>
        public override void UpButton()
        {
            if (this.Value == this.Maximum && this.mIsWrap == true)
            {
                // 最大値、かつループ設定有効な場合、最小値を設定
                this.Value = this.Minimum;
            }
            else
            {
                // 通常の動作
                base.UpButton();
            }
        }

        /// <summary>
        /// 下ボタンをクリック
        /// </summary>
        public override void DownButton()
        {
            if (this.Value == this.Minimum && this.mIsWrap == true)
            {
                // 最小値、かつループ設定有効な場合、最大値を設定
                this.Value = this.Maximum;
            }
            else
            {
                // 通常の動作
                base.DownButton();
            }
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
        /// コンストラクタ共通処理
        /// </summary>
        private void InitializeCustomSetting()
        {
            // デフォルト設定
            this.Font = new Font(ComponentCommon.GetFontType(), ComponentCommon.GetFontSize());
            this.ForeColor = this.Enabled
                ? ColorTranslator.FromHtml(ComponentCommon.GetFontColor())
                : ColorTranslator.FromHtml(ComponentCommon.GetInactiveColor());
            this.BackColor = ColorTranslator.FromHtml(ComponentCommon.GetBackColor());
        }
        #endregion
    }
}
//---<<END OF FILE>>-----------------------------------------------------
