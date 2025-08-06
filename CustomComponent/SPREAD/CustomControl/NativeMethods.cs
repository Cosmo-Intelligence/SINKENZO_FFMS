//-----------------------------------------------------------------------
// <copyright file="NativeMethods.cs" company="FUJIFILM Medical Solutions Corporation">
// Copyright (C) 2025 FUJIFILM Medical Solutions Corporation.
// </copyright>
//-----------------------------------------------------------------------
using System.Runtime.InteropServices;

namespace RADISTA.SPREAD.CustomControl
{
    /// <summary>
    /// NativeMethodsクラス
    /// </summary>
    /// <remarks>
    /// 
    /// (Rev.)        (Date)      (ID / NAME)                     (Comment)
    /// V1.00.00    : 2025.05.01    : 株式会社コスモ・インテリジェンス / 藤原崇文   : original
    ///
    /// </remarks>
    internal static class NativeMethods
    {
        /// <summary>
        /// GetWindowDC
        /// </summary>
        /// <param name="hWnd">hWnd</param>
        /// <returns>IntPtr</returns>
        [DllImport("user32.dll")]
        [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
        public static extern IntPtr GetWindowDC(IntPtr hWnd);

        /// <summary>
        /// ReleaseDC
        /// </summary>
        /// <param name="hWnd">hWnd</param>
        /// <param name="hDC">hDC</param>
        /// <returns>int</returns>
        [DllImport("user32.dll")]
        [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
        public static extern int ReleaseDC(IntPtr hWnd, IntPtr hDC);

        /// <summary>
        /// ReleaseDC
        /// </summary>
        /// <param name="hWnd">hWnd</param>
        /// <param name="appname">appname</param>
        /// <param name="idlist">idlist</param>
        /// <returns>int</returns>
        [DllImport("uxtheme.dll", CharSet = CharSet.Unicode)]
        [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
        public static extern int SetWindowTheme(IntPtr hWnd, string appname, string idlist);
    }
}
//---<<END OF FILE>>-----------------------------------------------------
