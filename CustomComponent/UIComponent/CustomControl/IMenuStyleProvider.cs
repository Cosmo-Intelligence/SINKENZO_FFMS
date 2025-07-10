//-----------------------------------------------------------------------
// <copyright file="IMenuStyleProvider.cs" company="FUJIFILM Medical Solutions Corporation">
// Copyright (C) 2025 FUJIFILM Medical Solutions Corporation.
// </copyright>
//-----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RADISTA.UIComponent.CustomControl
{
    /// <summary>
    /// IMenuStyleProviderインタフェース
    /// RdtContextMenuStrip、RdtMenuStrip用のインタフェース
    /// </summary>
    /// <remarks>
    /// 
    /// (Rev.)        (Date)      (ID / NAME)                     (Comment)
    /// V1.00.00    : 2025.05.01    : 株式会社コスモ・インテリジェンス / 藤原崇文   : original
    ///
    /// </remarks>
    public interface IMenuStyleProvider
    {
        #region "プロパティ"
        /// <summary>
        /// 前景色
        /// </summary>
        public string MenuForeColor { get; }

        /// <summary>
        /// 背景色
        /// </summary>
        public string MenuBackColor { get; }

        /// <summary>
        /// 選択行の前景色
        /// </summary>
        public string MenuSelectedForeColor { get; }

        /// <summary>
        /// 選択行の閉経色
        /// </summary>
        public string MenuSelectedBackColor { get; }
        #endregion
    }
}
//---<<END OF FILE>>-----------------------------------------------------