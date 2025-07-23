//-----------------------------------------------------------------------
// <copyright file="RdtDialog.cs" company="FUJIFILM Medical Solutions Corporation">
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

namespace RADISTA.UIComponent.CustomControl
{
    /// <summary>
    /// RdtDialogクラス
    /// </summary>
    /// <remarks>
    /// 
    /// (Rev.)        (Date)      (ID / NAME)                     (Comment)
    /// V1.00.00    : 2025.07.09    : 株式会社コスモ・インテリジェンス / 笠間可奈子   : original
    ///
    /// </remarks>
    public partial class RdtDialog : RdtForm
    {
        #region "パブリックメソッド"
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public RdtDialog()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="container">コンテナ</param>
        public RdtDialog(IContainer container)
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
            // ダイアログ領域以外の範囲をクリックした場合、ダイアログを閉じる
            this.Deactivate += (s, e) =>
            {
                // 非表示の場合にフォーカスを失って閉じてしまうことを防止
                if (this.WindowState != FormWindowState.Minimized)
                {
                    this.Close();
                }
            };
        }
        #endregion
    }
}
//---<<END OF FILE>>-----------------------------------------------------
