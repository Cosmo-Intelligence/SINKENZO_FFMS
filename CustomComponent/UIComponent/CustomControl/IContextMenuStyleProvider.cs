//-----------------------------------------------------------------------
// <copyright file="IContextMenuStyleProvider.cs" company="FUJIFILM Medical Solutions Corporation">
// Copyright (C) 2025 FUJIFILM Medical Solutions Corporation.
// </copyright>
//-----------------------------------------------------------------------

namespace RADISTA.UIComponent.CustomControl
{
    /// <summary>
    /// IContextMenuStyleProviderインタフェース
    /// RdtContextMenuStrip用のインタフェース
    /// </summary>
    /// <remarks>
    /// 
    /// (Rev.)        (Date)      (ID / NAME)                     (Comment)
    /// V1.00.00    : 2025.05.01    : 株式会社コスモ・インテリジェンス / 藤原崇文   : original
    ///
    /// </remarks>
    public interface IContextMenuStyleProvider
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
        /// ホバー時の前景色
        /// </summary>
        public string MenuHoverForeColor { get; }

        /// <summary>
        /// ホバー時の背景色
        /// </summary>
        public string MenuHoverBackColor { get; }

        /// <summary>
        /// 無効時の前景色
        /// </summary>
        public string MenuDisableForeColor { get; }

        /// <summary>
        /// 無効時の背景色
        /// </summary>
        public string MenuDisableBackColor { get; }

        /// <summary>
        /// チェック時の前景色
        /// </summary>
        string MenuCheckedForeColor { get; }

        /// <summary>
        /// チェック時の背景色
        /// </summary>
        string MenuCheckedBackColor { get; }

        /// <summary>
        /// チェック時かつ選択時の前景色
        /// </summary>
        string MenuCheckedHoverForeColor { get; }

        /// <summary>
        /// チェック時かつ選択時の背景色
        /// </summary>
        string MenuCheckedHoverBackColor { get; }
        #endregion
    }
}
//---<<END OF FILE>>-----------------------------------------------------