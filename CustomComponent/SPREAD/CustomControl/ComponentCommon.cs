//-----------------------------------------------------------------------
// <copyright file="ComponentCommon.cs" company="FUJIFILM Medical Solutions Corporation">
//    Copyright (C) 2025 FUJIFILM Medical Solutions Corporation.
// </copyright>
//-----------------------------------------------------------------------
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Text.RegularExpressions;
using System.Xml;

using log4net;
using log4net.Config;

namespace RADISTA.SPREAD.CustomControl
{
    /// <summary>
    /// コンポーネント共通クラス
    /// </summary>
    /// <remarks>
    /// 
    /// (Rev.)        (Date)      (ID / NAME)                     (Comment)
    /// V1.00.00    : 2025.05.01    : 株式会社コスモ・インテリジェンス / 藤原崇文   : original
    ///
    /// </remarks>
    public static class ComponentCommon
    {
        #region "クラス変数"
        private static readonly ILog mLog = LogManager.GetLogger(typeof(ComponentCommon));
        #region "フォント"
        private static string mFontType = Constants.FONT_TYPE;
        private static int mFontSize = Constants.FONT_SIZE;
        private static string mFontColor = Constants.FONT_COLOR;
        private static string mFontDisableColor = Constants.FONT_DISABLE_COLOR;
        private static string mFontFocusColor = Constants.FONT_FOCUS_COLOR;
        private static string mFontReadOnlyColor = Constants.FONT_READ_ONLY_COLOR;
        #endregion
        #region "Form, Dialog"
        private static string mFormDefaultFontColor = Constants.FORM_DEFAULT_FONT_COLOR;
        private static string mFormDefaultBackColor = Constants.FORM_DEFAULT_BACK_COLOR;
        private static string mFormTitlebarFontColor = Constants.FORM_TITLEBAR_FONT_COLOR;
        private static string mFormTitlebarBackColor = Constants.FORM_TITLEBAR_BACK_COLOR;
        #endregion
        #region "Label"
        private static string mLabelDefaultFontColor = Constants.LABEL_DEFAULT_FONT_COLOR;
        private static string mLabelDefaultBackColor = Constants.LABEL_DEFAULT_BACK_COLOR;
        private static string mLabelDefaultEdgeColor = Constants.LABEL_DEFAULT_EDGE_COLOR;
        #endregion
        #region "TextBox, ComboBox"
        private static string mTextDefaultFontColor = Constants.TEXT_DEFAULT_FONT_COLOR;
        private static string mTextDefaultBackColor = Constants.TEXT_DEFAULT_BACK_COLOR;
        private static string mTextDefaultEdgeColor = Constants.TEXT_DEFAULT_EDGE_COLOR;
        private static string mTextDisableFontColor = Constants.TEXT_DISABLE_FONT_COLOR;
        private static string mTextDisableBackColor = Constants.TEXT_DISABLE_BACK_COLOR;
        private static string mTextDisableEdgeColor = Constants.TEXT_DISABLE_EDGE_COLOR;
        private static string mTextFocusFontColor = Constants.TEXT_FOCUS_FONT_COLOR;
        private static string mTextFocusBackColor = Constants.TEXT_FOCUS_BACK_COLOR;
        private static string mTextFocusEdgeColor = Constants.TEXT_FOCUS_EDGE_COLOR;
        private static string mTextReadOnlyFontColor = Constants.TEXT_READ_ONLY_FONT_COLOR;
        private static string mTextReadOnlyBackColor = Constants.TEXT_READ_ONLY_BACK_COLOR;
        private static string mTextReadOnlyEdgeColor = Constants.TEXT_READ_ONLY_EDGE_COLOR;
        private static string mTextWaterMarkFontColor = Constants.TEXT_WATER_MARK_FONT_COLOR;
        #endregion
        #region "ListView, ListBox"
        private static string mListDefaultStandardFontColor = Constants.LIST_DEFAULT_STANDARD_FONT_COLOR;
        private static string mListDefaultStandardBackColor = Constants.LIST_DEFAULT_STANDARD_BACK_COLOR;
        private static string mListDefaultStandardEdgeColor = Constants.LIST_DEFAULT_STANDARD_EDGE_COLOR;
        private static string mListDefaultFlatFontColor = Constants.LIST_DEFAULT_FLAT_FONT_COLOR;
        private static string mListDefaultFlatBackColor = Constants.LIST_DEFAULT_FLAT_BACK_COLOR;
        private static string mListDefaultFlatEdgeColor = Constants.LIST_DEFAULT_FLAT_EDGE_COLOR;
        private static string mListHoverStandardFontColor = Constants.LIST_HOVER_STANDARD_FONT_COLOR;
        private static string mListHoverStandardBackColor = Constants.LIST_HOVER_STANDARD_BACK_COLOR;
        private static string mListHoverStandardEdgeColor = Constants.LIST_HOVER_STANDARD_EDGE_COLOR;
        private static string mListHoverFlatFontColor = Constants.LIST_HOVER_FLAT_FONT_COLOR;
        private static string mListHoverFlatBackColor = Constants.LIST_HOVER_FLAT_BACK_COLOR;
        private static string mListHoverFlatEdgeColor = Constants.LIST_HOVER_FLAT_EDGE_COLOR;
        private static string mListDisableStandardFontColor = Constants.LIST_DISABLE_STANDARD_FONT_COLOR;
        private static string mListDisableStandardBackColor = Constants.LIST_DISABLE_STANDARD_BACK_COLOR;
        private static string mListDisableStandardEdgeColor = Constants.LIST_DISABLE_STANDARD_EDGE_COLOR;
        private static string mListDisableFlatFontColor = Constants.LIST_DISABLE_FLAT_FONT_COLOR;
        private static string mListDisableFlatBackColor = Constants.LIST_DISABLE_FLAT_BACK_COLOR;
        private static string mListDisableFlatEdgeColor = Constants.LIST_DISABLE_FLAT_EDGE_COLOR;
        #endregion
        #region "ContextMenuStrip"
        private static string mContextDefaultFontColor = Constants.CONTEXT_DEFAULT_FONT_COLOR;
        private static string mContextDefaultBackColor = Constants.CONTEXT_DEFAULT_BACK_COLOR;
        private static string mContextDefaultEdgeColor = Constants.CONTEXT_DEFAULT_EDGE_COLOR;
        private static string mContextHoverFontColor = Constants.CONTEXT_HOVER_FONT_COLOR;
        private static string mContextHoverBackColor = Constants.CONTEXT_HOVER_BACK_COLOR;
        private static string mContextHoverEdgeColor = Constants.CONTEXT_HOVER_EDGE_COLOR;
        private static string mContextSelectedFontColor = Constants.CONTEXT_SELECTED_FONT_COLOR;
        private static string mContextSelectedBackColor = Constants.CONTEXT_SELECTED_BACK_COLOR;
        private static string mContextSelectedEdgeColor = Constants.CONTEXT_SELECTED_EDGE_COLOR;
        private static string mContextSelectedHoverFontColor = Constants.CONTEXT_SELECTED_HOVER_FONT_COLOR;
        private static string mContextSelectedHoverBackColor = Constants.CONTEXT_SELECTED_HOVER_BACK_COLOR;
        private static string mContextSelectedHoverEdgeColor = Constants.CONTEXT_SELECTED_HOVER_EDGE_COLOR;
        private static string mContextDisableFontColor = Constants.CONTEXT_DISABLE_FONT_COLOR;
        private static string mContextDisableBackColor = Constants.CONTEXT_DISABLE_BACK_COLOR;
        private static string mContextDisableEdgeColor = Constants.CONTEXT_DISABLE_EDGE_COLOR;
        #endregion
        #region "MenuStrip"
        private static string mMenuDefaultFontColor = Constants.MENU_DEFAULT_FONT_COLOR;
        private static string mMenuDefaultBackColor = Constants.MENU_DEFAULT_BACK_COLOR;
        private static string mMenuHoverFontColor = Constants.MENU_HOVER_FONT_COLOR;
        private static string mMenuHoverBackColor = Constants.MENU_HOVER_BACK_COLOR;
        private static string mMenuDisableFontColor = Constants.MENU_DISABLE_FONT_COLOR;
        private static string mMenuDisableBackColor = Constants.MENU_DISABLE_BACK_COLOR;
        #endregion
        #region "Button"
        private static string mButtonDefaultPrimaryFontColor = Constants.BUTTON_DEFAULT_PRIMARY_FONT_COLOR;
        private static string mButtonDefaultPrimaryBackColor = Constants.BUTTON_DEFAULT_PRIMARY_BACK_COLOR;
        private static string mButtonDefaultPrimaryEdgeColor = Constants.BUTTON_DEFAULT_PRIMARY_EDGE_COLOR;
        private static string mButtonDefaultTonalFontColor = Constants.BUTTON_DEFAULT_TONAL_FONT_COLOR;
        private static string mButtonDefaultTonalBackColor = Constants.BUTTON_DEFAULT_TONAL_BACK_COLOR;
        private static string mButtonDefaultTonalEdgeColor = Constants.BUTTON_DEFAULT_TONAL_EDGE_COLOR;
        private static string mButtonDefaultOutlinedFontColor = Constants.BUTTON_DISABLE_OUTLINED_FONT_COLOR;
        private static string mButtonDefaultOutlinedBackColor = Constants.BUTTON_DISABLE_OUTLINED_BACK_COLOR;
        private static string mButtonDefaultOutlinedEdgeColor = Constants.BUTTON_DISABLE_OUTLINED_EDGE_COLOR;
        private static string mButtonDefaultTextFontColor = Constants.BUTTON_DEFAULT_TEXT_FONT_COLOR;
        private static string mButtonDefaultTextBackColor = Constants.BUTTON_DEFAULT_TEXT_BACK_COLOR;
        private static string mButtonDefaultTextEdgeColor = Constants.BUTTON_DEFAULT_TEXT_EDGE_COLOR;
        private static string mButtonHoverPrimaryFontColor = Constants.BUTTON_HOVER_PRIMARY_FONT_COLOR;
        private static string mButtonHoverPrimaryBackColor = Constants.BUTTON_HOVER_PRIMARY_BACK_COLOR;
        private static string mButtonHoverPrimaryEdgeColor = Constants.BUTTON_HOVER_PRIMARY_EDGE_COLOR;
        private static string mButtonHoverTonalFontColor = Constants.BUTTON_HOVER_TONAL_FONT_COLOR;
        private static string mButtonHoverTonalBackColor = Constants.BUTTON_HOVER_TONAL_BACK_COLOR;
        private static string mButtonHoverTonalEdgeColor = Constants.BUTTON_HOVER_TONAL_EDGE_COLOR;
        private static string mButtonHoverOutlinedFontColor = Constants.BUTTON_HOVER_OUTLINED_FONT_COLOR;
        private static string mButtonHoverOutlinedBackColor = Constants.BUTTON_HOVER_OUTLINED_BACK_COLOR;
        private static string mButtonHoverOutlinedEdgeColor = Constants.BUTTON_HOVER_OUTLINED_EDGE_COLOR;
        private static string mButtonHoverTextFontColor = Constants.BUTTON_HOVER_TEXT_FONT_COLOR;
        private static string mButtonHoverTextBackColor = Constants.BUTTON_HOVER_TEXT_BACK_COLOR;
        private static string mButtonHoverTextEdgeColor = Constants.BUTTON_HOVER_TEXT_EDGE_COLOR;
        private static string mButtonPressedPrimaryFontColor = Constants.BUTTON_PRESSED_PRIMARY_FONT_COLOR;
        private static string mButtonPressedPrimaryBackColor = Constants.BUTTON_PRESSED_PRIMARY_BACK_COLOR;
        private static string mButtonPressedPrimaryEdgeColor = Constants.BUTTON_PRESSED_PRIMARY_EDGE_COLOR;
        private static string mButtonPressedTonalFontColor = Constants.BUTTON_PRESSED_TONAL_FONT_COLOR;
        private static string mButtonPressedTonalBackColor = Constants.BUTTON_PRESSED_TONAL_BACK_COLOR;
        private static string mButtonPressedTonalEdgeColor = Constants.BUTTON_PRESSED_TONAL_EDGE_COLOR;
        private static string mButtonPressedOutlinedFontColor = Constants.BUTTON_PRESSED_OUTLINED_FONT_COLOR;
        private static string mButtonPressedOutlinedBackColor = Constants.BUTTON_PRESSED_OUTLINED_BACK_COLOR;
        private static string mButtonPressedOutlinedEdgeColor = Constants.BUTTON_PRESSED_OUTLINED_EDGE_COLOR;
        private static string mButtonPressedTextFontColor = Constants.BUTTON_PRESSED_TEXT_FONT_COLOR;
        private static string mButtonPressedTextBackColor = Constants.BUTTON_PRESSED_TEXT_BACK_COLOR;
        private static string mButtonPressedTextEdgeColor = Constants.BUTTON_PRESSED_TEXT_EDGE_COLOR;
        private static string mButtonDisablePrimaryFontColor = Constants.BUTTON_DISABLE_PRIMARY_FONT_COLOR;
        private static string mButtonDisablePrimaryBackColor = Constants.BUTTON_DISABLE_PRIMARY_BACK_COLOR;
        private static string mButtonDisablePrimaryEdgeColor = Constants.BUTTON_DISABLE_PRIMARY_EDGE_COLOR;
        private static string mButtonDisableTonalFontColor = Constants.BUTTON_DISABLE_TONAL_FONT_COLOR;
        private static string mButtonDisableTonalBackColor = Constants.BUTTON_DISABLE_TONAL_BACK_COLOR;
        private static string mButtonDisableTonalEdgeColor = Constants.BUTTON_DISABLE_TONAL_EDGE_COLOR;
        private static string mButtonDisableOutlinedFontColor = Constants.BUTTON_DISABLE_OUTLINED_FONT_COLOR;
        private static string mButtonDisableOutlinedBackColor = Constants.BUTTON_DISABLE_OUTLINED_BACK_COLOR;
        private static string mButtonDisableOutlinedEdgeColor = Constants.BUTTON_DISABLE_OUTLINED_EDGE_COLOR;
        private static string mButtonDisableTextFontColor = Constants.BUTTON_DISABLE_TEXT_FONT_COLOR;
        private static string mButtonDisableTextBackColor = Constants.BUTTON_DISABLE_TEXT_BACK_COLOR;
        private static string mButtonDisableTextEdgeColor = Constants.BUTTON_DISABLE_TEXT_EDGE_COLOR;
        #endregion
        #region "ToggleButton"
        private static string mToggleOnTonalFontColor = Constants.TOGGLE_ON_TONAL_FONT_COLOR;
        private static string mToggleOnTonalBackColor = Constants.TOGGLE_ON_TONAL_BACK_COLOR;
        private static string mToggleOnTonalEdgeColor = Constants.TOGGLE_ON_TONAL_EDGE_COLOR;
        private static string mToggleOnOutlinedFontColor = Constants.TOGGLE_ON_OUTLINED_FONT_COLOR;
        private static string mToggleOnOutlinedBackColor = Constants.TOGGLE_ON_OUTLINED_BACK_COLOR;
        private static string mToggleOnOutlinedEdgeColor = Constants.TOGGLE_ON_OUTLINED_EDGE_COLOR;
        private static string mToggleOnTextFontColor = Constants.TOGGLE_ON_TEXT_FONT_COLOR;
        private static string mToggleOnTextBackColor = Constants.TOGGLE_ON_TEXT_BACK_COLOR;
        private static string mToggleOnTextEdgeColor = Constants.TOGGLE_ON_TEXT_EDGE_COLOR;
        private static string mToggleOffTonalFontColor = Constants.TOGGLE_OFF_TONAL_FONT_COLOR;
        private static string mToggleOffTonalBackColor = Constants.TOGGLE_OFF_TONAL_BACK_COLOR;
        private static string mToggleOffTonalEdgeColor = Constants.TOGGLE_OFF_TONAL_EDGE_COLOR;
        private static string mToggleOffOutlinedFontColor = Constants.TOGGLE_OFF_OUTLINED_FONT_COLOR;
        private static string mToggleOffOutlinedBackColor = Constants.TOGGLE_OFF_OUTLINED_BACK_COLOR;
        private static string mToggleOffOutlinedEdgeColor = Constants.TOGGLE_OFF_OUTLINED_EDGE_COLOR;
        private static string mToggleOffTextFontColor = Constants.TOGGLE_OFF_TEXT_FONT_COLOR;
        private static string mToggleOffTextBackColor = Constants.TOGGLE_OFF_TEXT_BACK_COLOR;
        private static string mToggleOffTextEdgeColor = Constants.TOGGLE_OFF_TEXT_EDGE_COLOR;
        #endregion
        #region "Calendar"
        private static string mCalendarDefaultFontColor = Constants.CARENDAR_DEFAULT_FONT_COLOR;
        private static string mCalendarDefaultBackColor = Constants.CARENDAR_DEFAULT_BACK_COLOR;
        private static string mCalendarDefaultTitleFontColor = Constants.CARENDAR_DEFAULT_TITLE_FONT_COLOR;
        private static string mCalendarDefaultTitleBackColor = Constants.CARENDAR_DEFAULT_TITLE_BACK_COLOR;
        private static string mCalendarDefaultTrailingFontColor = Constants.CARENDAR_DEFAULT_TRAILING_FONT_COLOR;
        #endregion
        #region "ProgressBar"
        private static string mProgressDefaultFontColor = Constants.PROGRESS_DEFAULT_FONT_COLOR;
        private static string mProgressDefaultBackColor = Constants.PROGRESS_DEFAULT_BACK_COLOR;
        #endregion

        // TODO：以下は不要と思うので後で消す
        private static string mBackColor = Constants.DEFAULT_BACK_COLOR;
        private static string mInactiveColor = Constants.DEFAULT_INACTIVE_COLOR;
        private static string mInputBackColor = Constants.DEFAULT_INPUT_BACK_COLOR;
        private static string mInputEdgeColor = Constants.DEFAULT_INPUT_EDGE_COLOR;
        private static string mComponentEdgeColor = Constants.DEFAULT_COMPONENT_EDGE_COLOR;
        #endregion

        /// <summary>
        /// 初期処理
        /// </summary>
        static ComponentCommon()
        {
            Init();
        }

        #region "パブリックメソッド"
        /// <summary>
        /// 指定されたフォント名がシステムに存在するかを判定します。
        /// </summary>
        /// <param name="fontName">フォント名</param>
        /// <returns>存在する場合：true、存在しない場合：false</returns>
        public static bool IsFontInstalled(string fontName)
        {
            if (string.IsNullOrWhiteSpace(fontName))
            {
                return false;
            }

            InstalledFontCollection fonts = new InstalledFontCollection();
            return fonts.Families.Any(f => string.Equals(f.Name, fontName, StringComparison.OrdinalIgnoreCase));
        }

        /// <summary>
        /// 引数の文字列が16進カラーコードかを返す
        /// </summary>
        /// <param name="colorCode">16進カラーコードの文字列</param>
        /// <returns>カラーコードの場合：true、違う場合：false</returns>
        public static bool IsColorCode(string colorCode)
        {
            if (string.IsNullOrEmpty(colorCode))
            {
                return false;
            }

            string pattern = @"^#([A-Fa-f0-9]{6})$";
            return Regex.IsMatch(colorCode.Trim(), pattern);
        }

        /// <summary>
        /// パスからイメージを取得する
        /// 注意：呼び出し元は必ずtry-catchを使う
        /// </summary>
        /// <param name="path">パス</param>
        /// <returns>image</returns>
        public static Image? GetImageFromPath(string path)
        {
            if (!File.Exists(path))
            {
                // イメージファイルが存在しない
                throw new FileNotFoundException("Image file path not found.", path);
            }
            try
            {
                using (Image img = Image.FromFile(path))
                {
                    return new Bitmap(img);
                }
            }
            catch (OutOfMemoryException ex)
            {
                // イメージファイルを読み込めない
                throw new InvalidDataException("The file is not a valid image format.", ex);
            }
            catch (IOException ex)
            {
                throw new IOException("Image load failed due to an IO issue.", ex);
            }
        }

        /// <summary>
        /// コーナーカーブパターン描画パスの取得
        /// </summary>
        /// <param name="rect">矩形</param>
        /// <param name="radius">半径</param>
        /// <returns>パス</returns>
        public static GraphicsPath GetRoundRectanglePath(Rectangle rect, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            int d = radius * 2;
            path.AddArc(rect.X, rect.Y, d, d, 180, 90);
            path.AddArc(rect.Right - d, rect.Y, d, d, 270, 90);
            path.AddArc(rect.Right - d, rect.Bottom - d, d, d, 0, 90);
            path.AddArc(rect.X, rect.Bottom - d, d, d, 90, 90);
            path.CloseFigure();
            return path;
        }

        #region "フォント"
        /// <summary>
        /// FontTypeを返す
        /// </summary>
        /// <returns>FontTypeの16進カラーコード</returns>
        public static string GetFontType()
        {
            return mFontType;
        }

        /// <summary>
        /// FontSizeを返す
        /// </summary>
        /// <returns>FontSize</returns>
        public static int GetFontSize()
        {
            return mFontSize;
        }

        /// <summary>
        /// FontColorを返す
        /// </summary>
        /// <returns>FontColorの16進カラーコード</returns>
        public static string GetFontColor()
        {
            return mFontColor;
        }

        /// <summary>
        /// FontDisableColorを返す
        /// </summary>
        /// <returns>FontColorの16進カラーコード</returns>
        public static string GetFontDisableColor()
        {
            return mFontDisableColor;
        }

        /// <summary>
        /// FontFocusColorを返す
        /// </summary>
        /// <returns>FontColorの16進カラーコード</returns>
        public static string GetFontFocusColor()
        {
            return mFontFocusColor;
        }

        /// <summary>
        /// FontReadOnlyColorを返す
        /// </summary>
        /// <returns>FontColorの16進カラーコード</returns>
        public static string GetFontReadOnlyColor()
        {
            return mFontReadOnlyColor;
        }
        #endregion

        #region "Form, Dialog"
        /// <summary>
        /// FormDefaultFontColorを返す
        /// </summary>
        /// <returns>FontColorの16進カラーコード</returns>
        public static string GetFormDefaultFontColor()
        {
            return mFormDefaultFontColor;
        }

        /// <summary>
        /// FormDefaultBackColorを返す
        /// </summary>
        /// <returns>FontColorの16進カラーコード</returns>
        public static string GetFormDefaultBackColor()
        {
            return mFormDefaultBackColor;
        }

        /// <summary>
        /// FormTitlebarFontColorを返す
        /// </summary>
        /// <returns>FontColorの16進カラーコード</returns>
        public static string GetFormTitlebarFontColor()
        {
            return mFormTitlebarFontColor;
        }

        /// <summary>
        /// FormTitlebarBackColorを返す
        /// </summary>
        /// <returns>FontColorの16進カラーコード</returns>
        public static string GetFormTitlebarBackColor()
        {
            return mFormTitlebarBackColor;
        }
        #endregion

        #region"Label"
        /// <summary>
        /// LabelDefaultFontColorを返す
        /// </summary>
        /// <returns>FontColorの16進カラーコード</returns>
        public static string GetLabelDefaultFontColor()
        {
            return mLabelDefaultFontColor;
        }

        /// <summary>
        /// LabelDefaultBackColorを返す
        /// </summary>
        /// <returns>FontColorの16進カラーコード</returns>
        public static string GetLabelDefaultBackColor()
        {
            return mLabelDefaultBackColor;
        }

        /// <summary>
        /// LabelDefaultEdgeColorを返す
        /// </summary>
        /// <returns>FontColorの16進カラーコード</returns>
        public static string GetLabelDefaultEdgeColor()
        {
            return mLabelDefaultEdgeColor;
        }
        #endregion

        #region"TextBox, ComboBox"
        /// <summary>
        /// TextDefaultFontColorを返す
        /// </summary>
        /// <returns>FontColorの16進カラーコード</returns>
        public static string GetTextDefaultFontColor()
        {
            return mTextDefaultFontColor;
        }

        /// <summary>
        /// TextDefaultBackColorを返す
        /// </summary>
        /// <returns>FontColorの16進カラーコード</returns>
        public static string GetTextDefaultBackColor()
        {
            return mTextDefaultBackColor;
        }

        /// <summary>
        /// TextDefaultEdgeColorを返す
        /// </summary>
        /// <returns>FontColorの16進カラーコード</returns>
        public static string GetTextDefaultEdgeColor()
        {
            return mTextDefaultEdgeColor;
        }

        /// <summary>
        /// TextDisableFontColorを返す
        /// </summary>
        /// <returns>FontColorの16進カラーコード</returns>
        public static string GetTextDisableFontColor()
        {
            return mTextDisableFontColor;
        }

        /// <summary>
        /// TextDisableBackColorを返す
        /// </summary>
        /// <returns>FontColorの16進カラーコード</returns>
        public static string GetTextDisableBackColor()
        {
            return mTextDisableBackColor;
        }

        /// <summary>
        /// TextDisableEdgeColorを返す
        /// </summary>
        /// <returns>FontColorの16進カラーコード</returns>
        public static string GetTextDisableEdgeColor()
        {
            return mTextDisableEdgeColor;
        }

        /// <summary>
        /// TextFocusFontColorを返す
        /// </summary>
        /// <returns>FontColorの16進カラーコード</returns>
        public static string GetTextFocusFontColor()
        {
            return mTextFocusFontColor;
        }

        /// <summary>
        /// TextFocusBackColorを返す
        /// </summary>
        /// <returns>FontColorの16進カラーコード</returns>
        public static string GetTextFocusBackColor()
        {
            return mTextFocusBackColor;
        }

        /// <summary>
        /// TextFocusEdgeColorを返す
        /// </summary>
        /// <returns>FontColorの16進カラーコード</returns>
        public static string GetTextFocusEdgeColor()
        {
            return mTextFocusEdgeColor;
        }

        /// <summary>
        /// TextReadOnlyFontColorを返す
        /// </summary>
        /// <returns>FontColorの16進カラーコード</returns>
        public static string GetTextReadOnlyFontColor()
        {
            return mTextReadOnlyFontColor;
        }

        /// <summary>
        /// TextReadOnlyBackColorを返す
        /// </summary>
        /// <returns>FontColorの16進カラーコード</returns>
        public static string GetTextReadOnlyBackColor()
        {
            return mTextReadOnlyBackColor;
        }

        /// <summary>
        /// TextReadOnlyEdgeColorを返す
        /// </summary>
        /// <returns>FontColorの16進カラーコード</returns>
        public static string GetTextReadOnlyEdgeColor()
        {
            return mTextReadOnlyEdgeColor;
        }

        /// <summary>
        /// TextWaterMarkFontColorを返す
        /// </summary>
        /// <returns>FontColorの16進カラーコード</returns>
        public static string GetTextWaterMarkFontColor()
        {
            return mTextWaterMarkFontColor;
        }
        #endregion

        #region"ListView, ListBox"
        /// <summary>
        /// ListDefaultStandardFontColorを返す
        /// </summary>
        /// <returns>FontColorの16進カラーコード</returns>
        public static string GetListDefaultStandardFontColor()
        {
            return mListDefaultStandardFontColor;
        }

        /// <summary>
        /// ListDefaultStandardBackColorを返す
        /// </summary>
        /// <returns>FontColorの16進カラーコード</returns>
        public static string GetListDefaultStandardBackColor()
        {
            return mListDefaultStandardBackColor;
        }

        /// <summary>
        /// ListDefaultStandardEdgeColorを返す
        /// </summary>
        /// <returns>FontColorの16進カラーコード</returns>
        public static string GetListDefaultStandardEdgeColor()
        {
            return mListDefaultStandardEdgeColor;
        }

        /// <summary>
        /// ListDefaultFlatFontColorを返す
        /// </summary>
        /// <returns>FontColorの16進カラーコード</returns>
        public static string GetListDefaultFlatFontColor()
        {
            return mListDefaultFlatFontColor;
        }

        /// <summary>
        /// ListDefaultFlatBackColorを返す
        /// </summary>
        /// <returns>FontColorの16進カラーコード</returns>
        public static string GetListDefaultFlatBackColor()
        {
            return mListDefaultFlatBackColor;
        }

        /// <summary>
        /// ListDefaultFlatEdgeColorを返す
        /// </summary>
        /// <returns>FontColorの16進カラーコード</returns>
        public static string GetListDefaultFlatEdgeColor()
        {
            return mListDefaultFlatEdgeColor;
        }

        /// <summary>
        /// ListHoverStandardFontColorを返す
        /// </summary>
        /// <returns>FontColorの16進カラーコード</returns>
        public static string GetListHoverStandardFontColor()
        {
            return mListHoverStandardFontColor;
        }

        /// <summary>
        /// ListHoverStandardBackColorを返す
        /// </summary>
        /// <returns>FontColorの16進カラーコード</returns>
        public static string GetListHoverStandardBackColor()
        {
            return mListHoverStandardBackColor;
        }

        /// <summary>
        /// ListHoverStandardEdgeColorを返す
        /// </summary>
        /// <returns>FontColorの16進カラーコード</returns>
        public static string GetListHoverStandardEdgeColor()
        {
            return mListHoverStandardEdgeColor;
        }

        /// <summary>
        /// ListHoverFlatFontColorを返す
        /// </summary>
        /// <returns>FontColorの16進カラーコード</returns>
        public static string GetListHoverFlatFontColor()
        {
            return mListHoverFlatFontColor;
        }

        /// <summary>
        /// ListHoverFlatBackColorを返す
        /// </summary>
        /// <returns>FontColorの16進カラーコード</returns>
        public static string GetListHoverFlatBackColor()
        {
            return mListHoverFlatBackColor;
        }

        /// <summary>
        /// ListHoverFlatEdgeColorを返す
        /// </summary>
        /// <returns>FontColorの16進カラーコード</returns>
        public static string GetListHoverFlatEdgeColor()
        {
            return mListHoverFlatEdgeColor;
        }

        /// <summary>
        /// ListDisableStandardFontColorを返す
        /// </summary>
        /// <returns>FontColorの16進カラーコード</returns>
        public static string GetListDisableStandardFontColor()
        {
            return mListDisableStandardFontColor;
        }

        /// <summary>
        /// ListDisableStandardBackColorを返す
        /// </summary>
        /// <returns>FontColorの16進カラーコード</returns>
        public static string GetListDisableStandardBackColor()
        {
            return mListDisableStandardBackColor;
        }

        /// <summary>
        /// ListDisableStandardEdgeColorを返す
        /// </summary>
        /// <returns>FontColorの16進カラーコード</returns>
        public static string GetListDisableStandardEdgeColor()
        {
            return mListDisableStandardEdgeColor;
        }

        /// <summary>
        /// ListDisableFlatFontColorを返す
        /// </summary>
        /// <returns>FontColorの16進カラーコード</returns>
        public static string GetListDisableFlatFontColor()
        {
            return mListDisableFlatFontColor;
        }

        /// <summary>
        /// ListDisableFlatBackColorを返す
        /// </summary>
        /// <returns>FontColorの16進カラーコード</returns>
        public static string GetListDisableFlatBackColor()
        {
            return mListDisableFlatBackColor;
        }

        /// <summary>
        /// ListDisableFlatEdgeColorを返す
        /// </summary>
        /// <returns>FontColorの16進カラーコード</returns>
        public static string GetListDisableFlatEdgeColor()
        {
            return mListDisableFlatEdgeColor;
        }
        #endregion

        #region"ContextMenuStrip"
        /// <summary>
        /// ContextDefaultFontColorを返す
        /// </summary>
        /// <returns>FontColorの16進カラーコード</returns>
        public static string GetContextDefaultFontColor()
        {
            return mContextDefaultFontColor;
        }

        /// <summary>
        /// ContextDefaultBackColorを返す
        /// </summary>
        /// <returns>FontColorの16進カラーコード</returns>
        public static string GetContextDefaultBackColor()
        {
            return mContextDefaultBackColor;
        }

        /// <summary>
        /// ContextDefaultEdgeColorを返す
        /// </summary>
        /// <returns>FontColorの16進カラーコード</returns>
        public static string GetContextDefaultEdgeColor()
        {
            return mContextDefaultEdgeColor;
        }

        /// <summary>
        /// ContextHoverFontColorを返す
        /// </summary>
        /// <returns>FontColorの16進カラーコード</returns>
        public static string GetContextHoverFontColor()
        {
            return mContextHoverFontColor;
        }

        /// <summary>
        /// ContextHoverBackColorを返す
        /// </summary>
        /// <returns>FontColorの16進カラーコード</returns>
        public static string GetContextHoverBackColor()
        {
            return mContextHoverBackColor;
        }

        /// <summary>
        /// ContextHoverEdgeColorを返す
        /// </summary>
        /// <returns>FontColorの16進カラーコード</returns>
        public static string GetContextHoverEdgeColor()
        {
            return mContextHoverEdgeColor;
        }

        /// <summary>
        /// ContextSelectedFontColorを返す
        /// </summary>
        /// <returns>FontColorの16進カラーコード</returns>
        public static string GetContextSelectedFontColor()
        {
            return mContextSelectedFontColor;
        }

        /// <summary>
        /// ContextSelectedBackColorを返す
        /// </summary>
        /// <returns>FontColorの16進カラーコード</returns>
        public static string GetContextSelectedBackColor()
        {
            return mContextSelectedBackColor;
        }

        /// <summary>
        /// ContextSelectedEdgeColorを返す
        /// </summary>
        /// <returns>FontColorの16進カラーコード</returns>
        public static string GetContextSelectedEdgeColor()
        {
            return mContextSelectedEdgeColor;
        }

        /// <summary>
        /// ContextSelectedHoverFontColorを返す
        /// </summary>
        /// <returns>FontColorの16進カラーコード</returns>
        public static string GetContextSelectedHoverFontColor()
        {
            return mContextSelectedHoverFontColor;
        }

        /// <summary>
        /// ContextSelectedHoverBackColorを返す
        /// </summary>
        /// <returns>FontColorの16進カラーコード</returns>
        public static string GetContextSelectedHoverBackColor()
        {
            return mContextSelectedHoverBackColor;
        }

        /// <summary>
        /// ContextSelectedHoverEdgeColorを返す
        /// </summary>
        /// <returns>FontColorの16進カラーコード</returns>
        public static string GetContextSelectedHoverEdgeColor()
        {
            return mContextSelectedHoverEdgeColor;
        }

        /// <summary>
        /// ContextDisableFontColorを返す
        /// </summary>
        /// <returns>FontColorの16進カラーコード</returns>
        public static string GetContextDisableFontColor()
        {
            return mContextDisableFontColor;
        }

        /// <summary>
        /// ContextDisableBackColorを返す
        /// </summary>
        /// <returns>FontColorの16進カラーコード</returns>
        public static string GetContextDisableBackColor()
        {
            return mContextDisableBackColor;
        }

        /// <summary>
        /// ContextDisableEdgeColorを返す
        /// </summary>
        /// <returns>FontColorの16進カラーコード</returns>
        public static string GetContextDisableEdgeColor()
        {
            return mContextDisableEdgeColor;
        }
        #endregion

        #region"MenuStrip"
        /// <summary>
        /// MenuDefaultFontColorを返す
        /// </summary>
        /// <returns>FontColorの16進カラーコード</returns>
        public static string GetMenuDefaultFontColor()
        {
            return mMenuDefaultFontColor;
        }

        /// <summary>
        /// MenuDefaultBackColorを返す
        /// </summary>
        /// <returns>FontColorの16進カラーコード</returns>
        public static string GetMenuDefaultBackColor()
        {
            return mMenuDefaultBackColor;
        }

        /// <summary>
        /// MenuHoverFontColorを返す
        /// </summary>
        /// <returns>FontColorの16進カラーコード</returns>
        public static string GetMenuHoverFontColor()
        {
            return mMenuHoverFontColor;
        }

        /// <summary>
        /// MenuHoverBackColorを返す
        /// </summary>
        /// <returns>FontColorの16進カラーコード</returns>
        public static string GetMenuHoverBackColor()
        {
            return mMenuHoverBackColor;
        }

        /// <summary>
        /// MenuDisableFontColorを返す
        /// </summary>
        /// <returns>FontColorの16進カラーコード</returns>
        public static string GetMenuDisableFontColor()
        {
            return mMenuDisableFontColor;
        }

        /// <summary>
        /// MenuDisableBackColorを返す
        /// </summary>
        /// <returns>FontColorの16進カラーコード</returns>
        public static string GetMenuDisableBackColor()
        {
            return mMenuDisableBackColor;
        }
        #endregion

        #region"Button"
        /// <summary>
        /// ButtonDefaultPrimaryFontColorを返す
        /// </summary>
        /// <returns>FontColorの16進カラーコード</returns>
        public static string GetButtonDefaultPrimaryFontColor()
        {
            return mButtonDefaultPrimaryFontColor;
        }

        /// <summary>
        /// ButtonDefaultPrimaryBackColorを返す
        /// </summary>
        /// <returns>FontColorの16進カラーコード</returns>
        public static string GetButtonDefaultPrimaryBackColor()
        {
            return mButtonDefaultPrimaryBackColor;
        }

        /// <summary>
        /// ButtonDefaultPrimaryEdgeColorを返す
        /// </summary>
        /// <returns>FontColorの16進カラーコード</returns>
        public static string GetButtonDefaultPrimaryEdgeColor()
        {
            return mButtonDefaultPrimaryEdgeColor;
        }

        /// <summary>
        /// ButtonDefaultTonalFontColorを返す
        /// </summary>
        /// <returns>FontColorの16進カラーコード</returns>
        public static string GetButtonDefaultTonalFontColor()
        {
            return mButtonDefaultTonalFontColor;
        }

        /// <summary>
        /// ButtonDefaultTonalBackColorを返す
        /// </summary>
        /// <returns>FontColorの16進カラーコード</returns>
        public static string GetButtonDefaultTonalBackColor()
        {
            return mButtonDefaultTonalBackColor;
        }

        /// <summary>
        /// ButtonDefaultTonalEdgeColorを返す
        /// </summary>
        /// <returns>FontColorの16進カラーコード</returns>
        public static string GetButtonDefaultTonalEdgeColor()
        {
            return mButtonDefaultTonalEdgeColor;
        }

        /// <summary>
        /// ButtonDefaultOutlinedFontColorを返す
        /// </summary>
        /// <returns>FontColorの16進カラーコード</returns>
        public static string GetButtonDefaultOutlinedFontColor()
        {
            return mButtonDefaultOutlinedFontColor;
        }

        /// <summary>
        /// ButtonDefaultOutlinedBackColorを返す
        /// </summary>
        /// <returns>FontColorの16進カラーコード</returns>
        public static string GetButtonDefaultOutlinedBackColor()
        {
            return mButtonDefaultOutlinedBackColor;
        }

        /// <summary>
        /// ButtonDefaultOutlinedEdgeColorを返す
        /// </summary>
        /// <returns>FontColorの16進カラーコード</returns>
        public static string GetButtonDefaultOutlinedEdgeColor()
        {
            return mButtonDefaultOutlinedEdgeColor;
        }

        /// <summary>
        /// ButtonDefaultTextFontColorを返す
        /// </summary>
        /// <returns>FontColorの16進カラーコード</returns>
        public static string GetButtonDefaultTextFontColor()
        {
            return mButtonDefaultTextFontColor;
        }

        /// <summary>
        /// ButtonDefaultTextBackColorを返す
        /// </summary>
        /// <returns>FontColorの16進カラーコード</returns>
        public static string GetButtonDefaultTextBackColor()
        {
            return mButtonDefaultTextBackColor;
        }

        /// <summary>
        /// ButtonDefaultTextEdgeColorを返す
        /// </summary>
        /// <returns>FontColorの16進カラーコード</returns>
        public static string GetButtonDefaultTextEdgeColor()
        {
            return mButtonDefaultTextEdgeColor;
        }

        /// <summary>
        /// ButtonHoverPrimaryFontColorを返す
        /// </summary>
        /// <returns>FontColorの16進カラーコード</returns>
        public static string GetButtonHoverPrimaryFontColor()
        {
            return mButtonHoverPrimaryFontColor;
        }

        /// <summary>
        /// ButtonHoverPrimaryBackColorを返す
        /// </summary>
        /// <returns>FontColorの16進カラーコード</returns>
        public static string GetButtonHoverPrimaryBackColor()
        {
            return mButtonHoverPrimaryBackColor;
        }

        /// <summary>
        /// ButtonHoverPrimaryEdgeColorを返す
        /// </summary>
        /// <returns>FontColorの16進カラーコード</returns>
        public static string GetButtonHoverPrimaryEdgeColor()
        {
            return mButtonHoverPrimaryEdgeColor;
        }

        /// <summary>
        /// ButtonHoverTonalFontColorを返す
        /// </summary>
        /// <returns>FontColorの16進カラーコード</returns>
        public static string GetButtonHoverTonalFontColor()
        {
            return mButtonHoverTonalFontColor;
        }

        /// <summary>
        /// ButtonHoverTonalBackColorを返す
        /// </summary>
        /// <returns>FontColorの16進カラーコード</returns>
        public static string GetButtonHoverTonalBackColor()
        {
            return mButtonHoverTonalBackColor;
        }

        /// <summary>
        /// ButtonHoverTonalEdgeColorを返す
        /// </summary>
        /// <returns>FontColorの16進カラーコード</returns>
        public static string GetButtonHoverTonalEdgeColor()
        {
            return mButtonHoverTonalEdgeColor;
        }

        /// <summary>
        /// ButtonHoverOutlinedFontColorを返す
        /// </summary>
        /// <returns>FontColorの16進カラーコード</returns>
        public static string GetButtonHoverOutlinedFontColor()
        {
            return mButtonHoverOutlinedFontColor;
        }

        /// <summary>
        /// ButtonHoverOutlinedBackColorを返す
        /// </summary>
        /// <returns>FontColorの16進カラーコード</returns>
        public static string GetButtonHoverOutlinedBackColor()
        {
            return mButtonHoverOutlinedBackColor;
        }

        /// <summary>
        /// ButtonHoverOutlinedEdgeColorを返す
        /// </summary>
        /// <returns>FontColorの16進カラーコード</returns>
        public static string GetButtonHoverOutlinedEdgeColor()
        {
            return mButtonHoverOutlinedEdgeColor;
        }

        /// <summary>
        /// ButtonHoverTextFontColorを返す
        /// </summary>
        /// <returns>FontColorの16進カラーコード</returns>
        public static string GetButtonHoverTextFontColor()
        {
            return mButtonHoverTextFontColor;
        }

        /// <summary>
        /// ButtonHoverTextBackColorを返す
        /// </summary>
        /// <returns>FontColorの16進カラーコード</returns>
        public static string GetButtonHoverTextBackColor()
        {
            return mButtonHoverTextBackColor;
        }

        /// <summary>
        /// ButtonHoverTextEdgeColorを返す
        /// </summary>
        /// <returns>FontColorの16進カラーコード</returns>
        public static string GetButtonHoverTextEdgeColor()
        {
            return mButtonHoverTextEdgeColor;
        }

        /// <summary>
        /// ButtonPressedPrimaryFontColorを返す
        /// </summary>
        /// <returns>FontColorの16進カラーコード</returns>
        public static string GetButtonPressedPrimaryFontColor()
        {
            return mButtonPressedPrimaryFontColor;
        }

        /// <summary>
        /// ButtonPressedPrimaryBackColorを返す
        /// </summary>
        /// <returns>FontColorの16進カラーコード</returns>
        public static string GetButtonPressedPrimaryBackColor()
        {
            return mButtonPressedPrimaryBackColor;
        }

        /// <summary>
        /// ButtonPressedPrimaryEdgeColorを返す
        /// </summary>
        /// <returns>FontColorの16進カラーコード</returns>
        public static string GetButtonPressedPrimaryEdgeColor()
        {
            return mButtonPressedPrimaryEdgeColor;
        }

        /// <summary>
        /// ButtonPressedTonalFontColorを返す
        /// </summary>
        /// <returns>FontColorの16進カラーコード</returns>
        public static string GetButtonPressedTonalFontColor()
        {
            return mButtonPressedTonalFontColor;
        }

        /// <summary>
        /// ButtonPressedTonalBackColorを返す
        /// </summary>
        /// <returns>FontColorの16進カラーコード</returns>
        public static string GetButtonPressedTonalBackColor()
        {
            return mButtonPressedTonalBackColor;
        }

        /// <summary>
        /// ButtonPressedTonalEdgeColorを返す
        /// </summary>
        /// <returns>FontColorの16進カラーコード</returns>
        public static string GetButtonPressedTonalEdgeColor()
        {
            return mButtonPressedTonalEdgeColor;
        }

        /// <summary>
        /// ButtonPressedOutlinedFontColorを返す
        /// </summary>
        /// <returns>FontColorの16進カラーコード</returns>
        public static string GetButtonPressedOutlinedFontColor()
        {
            return mButtonPressedOutlinedFontColor;
        }

        /// <summary>
        /// ButtonPressedOutlinedBackColorを返す
        /// </summary>
        /// <returns>FontColorの16進カラーコード</returns>
        public static string GetButtonPressedOutlinedBackColor()
        {
            return mButtonPressedOutlinedBackColor;
        }

        /// <summary>
        /// ButtonPressedOutlinedEdgeColorを返す
        /// </summary>
        /// <returns>FontColorの16進カラーコード</returns>
        public static string GetButtonPressedOutlinedEdgeColor()
        {
            return mButtonPressedOutlinedEdgeColor;
        }

        /// <summary>
        /// ButtonPressedTextFontColorを返す
        /// </summary>
        /// <returns>FontColorの16進カラーコード</returns>
        public static string GetButtonPressedTextFontColor()
        {
            return mButtonPressedTextFontColor;
        }

        /// <summary>
        /// ButtonPressedTextBackColorを返す
        /// </summary>
        /// <returns>FontColorの16進カラーコード</returns>
        public static string GetButtonPressedTextBackColor()
        {
            return mButtonPressedTextBackColor;
        }

        /// <summary>
        /// ButtonPressedTextEdgeColorを返す
        /// </summary>
        /// <returns>FontColorの16進カラーコード</returns>
        public static string GetButtonPressedTextEdgeColor()
        {
            return mButtonPressedTextEdgeColor;
        }

        /// <summary>
        /// ButtonDisablePrimaryFontColorを返す
        /// </summary>
        /// <returns>FontColorの16進カラーコード</returns>
        public static string GetButtonDisablePrimaryFontColor()
        {
            return mButtonDisablePrimaryFontColor;
        }

        /// <summary>
        /// ButtonDisablePrimaryBackColorを返す
        /// </summary>
        /// <returns>FontColorの16進カラーコード</returns>
        public static string GetButtonDisablePrimaryBackColor()
        {
            return mButtonDisablePrimaryBackColor;
        }

        /// <summary>
        /// ButtonDisablePrimaryEdgeColorを返す
        /// </summary>
        /// <returns>FontColorの16進カラーコード</returns>
        public static string GetButtonDisablePrimaryEdgeColor()
        {
            return mButtonDisablePrimaryEdgeColor;
        }

        /// <summary>
        /// ButtonDisableTonalFontColorを返す
        /// </summary>
        /// <returns>FontColorの16進カラーコード</returns>
        public static string GetButtonDisableTonalFontColor()
        {
            return mButtonDisableTonalFontColor;
        }

        /// <summary>
        /// ButtonDisableTonalBackColorを返す
        /// </summary>
        /// <returns>FontColorの16進カラーコード</returns>
        public static string GetButtonDisableTonalBackColor()
        {
            return mButtonDisableTonalBackColor;
        }

        /// <summary>
        /// ButtonDisableTonalEdgeColorを返す
        /// </summary>
        /// <returns>FontColorの16進カラーコード</returns>
        public static string GetButtonDisableTonalEdgeColor()
        {
            return mButtonDisableTonalEdgeColor;
        }

        /// <summary>
        /// ButtonDisableOutlinedFontColorを返す
        /// </summary>
        /// <returns>FontColorの16進カラーコード</returns>
        public static string GetButtonDisableOutlinedFontColor()
        {
            return mButtonDisableOutlinedFontColor;
        }

        /// <summary>
        /// ButtonDisableOutlinedBackColorを返す
        /// </summary>
        /// <returns>FontColorの16進カラーコード</returns>
        public static string GetButtonDisableOutlinedBackColor()
        {
            return mButtonDisableOutlinedBackColor;
        }

        /// <summary>
        /// ButtonDisableOutlinedEdgeColorを返す
        /// </summary>
        /// <returns>FontColorの16進カラーコード</returns>
        public static string GetButtonDisableOutlinedEdgeColor()
        {
            return mButtonDisableOutlinedEdgeColor;
        }

        /// <summary>
        /// ButtonDisableTextFontColorを返す
        /// </summary>
        /// <returns>FontColorの16進カラーコード</returns>
        public static string GetButtonDisableTextFontColor()
        {
            return mButtonDisableTextFontColor;
        }

        /// <summary>
        /// ButtonDisableTextBackColorを返す
        /// </summary>
        /// <returns>FontColorの16進カラーコード</returns>
        public static string GetButtonDisableTextBackColor()
        {
            return mButtonDisableTextBackColor;
        }

        /// <summary>
        /// ButtonDisableTextEdgeColorを返す
        /// </summary>
        /// <returns>FontColorの16進カラーコード</returns>
        public static string GetButtonDisableTextEdgeColor()
        {
            return mButtonDisableTextEdgeColor;
        }
        #endregion

        #region"ToggleButton"
        /// <summary>
        /// ToggleOnTonalFontColorを返す
        /// </summary>
        /// <returns>FontColorの16進カラーコード</returns>
        public static string GetToggleOnTonalFontColor()
        {
            return mToggleOnTonalFontColor;
        }

        /// <summary>
        /// ToggleOnTonalBackColorを返す
        /// </summary>
        /// <returns>FontColorの16進カラーコード</returns>
        public static string GetToggleOnTonalBackColor()
        {
            return mToggleOnTonalBackColor;
        }

        /// <summary>
        /// ToggleOnTonalEdgeColorを返す
        /// </summary>
        /// <returns>FontColorの16進カラーコード</returns>
        public static string GetToggleOnTonalEdgeColor()
        {
            return mToggleOnTonalEdgeColor;
        }

        /// <summary>
        /// ToggleOnOutlinedFontColorを返す
        /// </summary>
        /// <returns>FontColorの16進カラーコード</returns>
        public static string GetToggleOnOutlinedFontColor()
        {
            return mToggleOnOutlinedFontColor;
        }

        /// <summary>
        /// ToggleOnOutlinedBackColorを返す
        /// </summary>
        /// <returns>FontColorの16進カラーコード</returns>
        public static string GetToggleOnOutlinedBackColor()
        {
            return mToggleOnOutlinedBackColor;
        }

        /// <summary>
        /// ToggleOnOutlinedEdgeColorを返す
        /// </summary>
        /// <returns>FontColorの16進カラーコード</returns>
        public static string GetToggleOnOutlinedEdgeColor()
        {
            return mToggleOnOutlinedEdgeColor;
        }

        /// <summary>
        /// ToggleOnTextFontColorを返す
        /// </summary>
        /// <returns>FontColorの16進カラーコード</returns>
        public static string GetToggleOnTextFontColor()
        {
            return mToggleOnTextFontColor;
        }

        /// <summary>
        /// ToggleOnTextBackColorを返す
        /// </summary>
        /// <returns>FontColorの16進カラーコード</returns>
        public static string GetToggleOnTextBackColor()
        {
            return mToggleOnTextBackColor;
        }

        /// <summary>
        /// ToggleOnTextEdgeColorを返す
        /// </summary>
        /// <returns>FontColorの16進カラーコード</returns>
        public static string GetToggleOnTextEdgeColor()
        {
            return mToggleOnTextEdgeColor;
        }

        /// <summary>
        /// ToggleOffTonalFontColorを返す
        /// </summary>
        /// <returns>FontColorの16進カラーコード</returns>
        public static string GetToggleOffTonalFontColor()
        {
            return mToggleOffTonalFontColor;
        }

        /// <summary>
        /// ToggleOffTonalBackColorを返す
        /// </summary>
        /// <returns>FontColorの16進カラーコード</returns>
        public static string GetToggleOffTonalBackColor()
        {
            return mToggleOffTonalBackColor;
        }

        /// <summary>
        /// ToggleOffTonalEdgeColorを返す
        /// </summary>
        /// <returns>FontColorの16進カラーコード</returns>
        public static string GetToggleOffTonalEdgeColor()
        {
            return mToggleOffTonalEdgeColor;
        }

        /// <summary>
        /// ToggleOffOutlinedFontColorを返す
        /// </summary>
        /// <returns>FontColorの16進カラーコード</returns>
        public static string GetToggleOffOutlinedFontColor()
        {
            return mToggleOffOutlinedFontColor;
        }

        /// <summary>
        /// ToggleOffOutlinedBackColorを返す
        /// </summary>
        /// <returns>FontColorの16進カラーコード</returns>
        public static string GetToggleOffOutlinedBackColor()
        {
            return mToggleOffOutlinedBackColor;
        }

        /// <summary>
        /// ToggleOffOutlinedEdgeColorを返す
        /// </summary>
        /// <returns>FontColorの16進カラーコード</returns>
        public static string GetToggleOffOutlinedEdgeColor()
        {
            return mToggleOffOutlinedEdgeColor;
        }

        /// <summary>
        /// ToggleOffTextFontColorを返す
        /// </summary>
        /// <returns>FontColorの16進カラーコード</returns>
        public static string GetToggleOffTextFontColor()
        {
            return mToggleOffTextFontColor;
        }

        /// <summary>
        /// ToggleOffTextBackColorを返す
        /// </summary>
        /// <returns>FontColorの16進カラーコード</returns>
        public static string GetToggleOffTextBackColor()
        {
            return mToggleOffTextBackColor;
        }

        /// <summary>
        /// ToggleOffTextEdgeColorを返す
        /// </summary>
        /// <returns>FontColorの16進カラーコード</returns>
        public static string GetToggleOffTextEdgeColor()
        {
            return mToggleOffTextEdgeColor;
        }
        #endregion

        #region"Calendar"
        /// <summary>
        /// CalendarDefaultFontColorを返す
        /// </summary>
        /// <returns>FontColorの16進カラーコード</returns>
        public static string GetCalendarDefaultFontColor()
        {
            return mCalendarDefaultFontColor;
        }

        /// <summary>
        /// CalendarDefaultBackColorを返す
        /// </summary>
        /// <returns>FontColorの16進カラーコード</returns>
        public static string GetCalendarDefaultBackColor()
        {
            return mCalendarDefaultBackColor;
        }

        /// <summary>
        /// CalendarDefaultTitleFontColorを返す
        /// </summary>
        /// <returns>FontColorの16進カラーコード</returns>
        public static string GetCalendarDefaultTitleFontColor()
        {
            return mCalendarDefaultTitleFontColor;
        }

        /// <summary>
        /// CalendarDefaultTitleBackColorを返す
        /// </summary>
        /// <returns>FontColorの16進カラーコード</returns>
        public static string GetCalendarDefaultTitleBackColor()
        {
            return mCalendarDefaultTitleBackColor;
        }

        /// <summary>
        /// CalendarDefaultTrailingFontColorを返す
        /// </summary>
        /// <returns>FontColorの16進カラーコード</returns>
        public static string GetCalendarDefaultTrailingFontColor()
        {
            return mCalendarDefaultTrailingFontColor;
        }
        #endregion

        #region"ProgressBar"
        /// <summary>
        /// ProgressDefaultFontColorを返す
        /// </summary>
        /// <returns>FontColorの16進カラーコード</returns>
        public static string GetProgressDefaultFontColor()
        {
            return mProgressDefaultFontColor;
        }

        /// <summary>
        /// ProgressDefaultBackColorを返す
        /// </summary>
        /// <returns>FontColorの16進カラーコード</returns>
        public static string GetProgressDefaultBackColor()
        {
            return mProgressDefaultBackColor;
        }
        #endregion

        #region TODO：後で消す
        /// <summary>
        /// BackColorを返す
        /// </summary>
        /// <returns>BackColorの16進カラーコード</returns>
        public static string GetBackColor()
        {
            return mBackColor;
        }

        /// <summary>
        /// InactiveColorを返す
        /// </summary>
        /// <returns>InactiveColorの16進カラーコード</returns>
        public static string GetInactiveColor()
        {
            return mInactiveColor;
        }

        /// <summary>
        /// InputBackColorを返す
        /// </summary>
        /// <returns>InputBackColorの16進カラーコード</returns>
        public static string GetInputBackColor()
        {
            return mInputBackColor;
        }

        /// <summary>
        /// InputEdgeColorを返す
        /// </summary>
        /// <returns>InputEdgeColorの16進カラーコード</returns>
        public static string GetInputEdgeColor()
        {
            return mInputEdgeColor;
        }

        /// <summary>
        /// ComponentEdgeColorを返す
        /// </summary>
        /// <returns>ComponentEdgeColorの16進カラーコード</returns>
        public static string GetComponentEdgeColor()
        {
            return mComponentEdgeColor;
        }
        #endregion
        #endregion

        #region "プライベートメソッド"
        /// <summary>
        /// 初期化処理
        /// </summary>
        private static void Init()
        {
            XmlConfigurator.Configure(new FileInfo("log4net.config"));

            string xmlPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "CustomControlSettings.xml");

            if (!File.Exists(xmlPath))
            {
                mLog.Debug("XML is not found");
                return;
            }

            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(xmlPath);

                XmlNodeList? settingNodes = doc.SelectNodes("//setting");
                if (settingNodes == null)
                {
                    mLog.Debug("settingNodes is null");
                    return;
                }

                // 処理マッピング（Dictionary）
                var keyValueProcessors = new Dictionary<string, Action<string>>()
                {
                    #region "フォント"
                    { "FontType", value => SetFontType(value, v => mFontType = v, "FontType setting is wrong") },
                    { "FontSize", value => SetIntValue(value, v => mFontSize = v, "FontSize setting is wrong") },
                    { "FontColor", value => SetColorValue(value, v => mFontColor = v, "FontColor setting is wrong") },
                    { "FontDisableColor", value => SetColorValue(value, v => mFontDisableColor = v, "FontDisableColor setting is wrong") },
                    { "FontFocusColor", value => SetColorValue(value, v => mFontFocusColor = v, "FontFocusColor setting is wrong") },
                    { "FontReadOnlyColor", value => SetColorValue(value, v => mFontReadOnlyColor = v, "FontReadOnlyColor setting is wrong") },
                    #endregion
                    #region "Form, Dialog"
                    { "FormDefaultFontColor", value => SetColorValue(value, v => mFormDefaultFontColor = v, "FormDefaultFontColor setting is wrong") },
                    { "FormDefaultBackColor", value => SetColorValue(value, v => mFormDefaultBackColor = v, "FormDefaultBackColor setting is wrong") },
                    { "FormTitlebarFontColor", value => SetColorValue(value, v => mFormTitlebarFontColor = v, "FormTitlebarFontColor setting is wrong") },
                    { "FormTitlebarBackColor", value => SetColorValue(value, v => mFormTitlebarBackColor = v, "FormTitlebarBackColor setting is wrong") },
                    #endregion
                    #region "Label"
                    { "LabelDefaultFontColor", value => SetColorValue(value, v => mLabelDefaultFontColor = v, "LabelDefaultFontColor setting is wrong") },
                    { "LabelDefaultBackColor", value => SetColorValue(value, v => mLabelDefaultBackColor = v, "LabelDefaultBackColor setting is wrong") },
                    { "LabelDefaultEdgeColor", value => SetColorValue(value, v => mLabelDefaultEdgeColor = v, "LabelDefaultEdgeColor setting is wrong") },
                    #endregion
                    #region "TextBox, ComboBox"
                    { "TextDefaultFontColor", value => SetColorValue(value, v => mTextDefaultFontColor = v, "TextDefaultFontColor setting is wrong") },
                    { "TextDefaultBackColor", value => SetColorValue(value, v => mTextDefaultBackColor = v, "TextDefaultBackColor setting is wrong") },
                    { "TextDefaultEdgeColor", value => SetColorValue(value, v => mTextDefaultEdgeColor = v, "TextDefaultEdgeColor setting is wrong") },
                    { "TextDisableFontColor", value => SetColorValue(value, v => mTextDisableFontColor = v, "TextDisableFontColor setting is wrong") },
                    { "TextDisableBackColor", value => SetColorValue(value, v => mTextDisableBackColor = v, "TextDisableBackColor setting is wrong") },
                    { "TextDisableEdgeColor", value => SetColorValue(value, v => mTextDisableEdgeColor = v, "TextDisableEdgeColor setting is wrong") },
                    { "TextFocusFontColor", value => SetColorValue(value, v => mTextFocusFontColor = v, "TextFocusFontColor setting is wrong") },
                    { "TextFocusBackColor", value => SetColorValue(value, v => mTextFocusBackColor = v, "TextFocusBackColor setting is wrong") },
                    { "TextFocusEdgeColor", value => SetColorValue(value, v => mTextFocusEdgeColor = v, "TextFocusEdgeColor setting is wrong") },
                    { "TextReadOnlyFontColor", value => SetColorValue(value, v => mTextReadOnlyFontColor = v, "TextReadOnlyFontColor setting is wrong") },
                    { "TextReadOnlyBackColor", value => SetColorValue(value, v => mTextReadOnlyBackColor = v, "LabelDTextReadOnlyBackColorefaultFontColor setting is wrong") },
                    { "TextReadOnlyEdgeColor", value => SetColorValue(value, v => mTextReadOnlyEdgeColor = v, "TextReadOnlyEdgeColor setting is wrong") },
                    { "TextWaterMarkFontColor", value => SetColorValue(value, v => mTextWaterMarkFontColor = v, "TextWaterMarkFontColor setting is wrong") },
                    #endregion
                    #region "ListView, ListBox"
                    { "ListDefaultStandardFontColor", value => SetColorValue(value, v => mListDefaultStandardFontColor = v, "ListDefaultStandardFontColor setting is wrong") },
                    { "ListDefaultStandardBackColor", value => SetColorValue(value, v => mListDefaultStandardBackColor = v, "ListDefaultStandardBackColor setting is wrong") },
                    { "ListDefaultStandardEdgeColor", value => SetColorValue(value, v => mListDefaultStandardEdgeColor = v, "ListDefaultStandardEdgeColor setting is wrong") },
                    { "ListDefaultFlatFontColor", value => SetColorValue(value, v => mListDefaultFlatFontColor = v, "ListDefaultFlatFontColor setting is wrong") },
                    { "ListDefaultFlatBackColor", value => SetColorValue(value, v => mListDefaultFlatBackColor = v, "ListDefaultFlatBackColor setting is wrong") },
                    { "ListDefaultFlatEdgeColor", value => SetColorValue(value, v => mListDefaultFlatEdgeColor = v, "ListDefaultFlatEdgeColor setting is wrong") },
                    { "ListHoverStandardFontColor", value => SetColorValue(value, v => mListHoverStandardFontColor = v, "ListHoverStandardFontColor setting is wrong") },
                    { "ListHoverStandardBackColor", value => SetColorValue(value, v => mListHoverStandardBackColor = v, "ListHoverStandardBackColor setting is wrong") },
                    { "ListHoverStandardEdgeColor", value => SetColorValue(value, v => mListHoverStandardEdgeColor = v, "ListHoverStandardEdgeColor setting is wrong") },
                    { "ListHoverFlatFontColor", value => SetColorValue(value, v => mListHoverFlatFontColor = v, "ListHoverFlatFontColor setting is wrong") },
                    { "ListHoverFlatBackColor", value => SetColorValue(value, v => mListHoverFlatBackColor = v, "ListHoverFlatBackColor setting is wrong") },
                    { "ListHoverFlatEdgeColor", value => SetColorValue(value, v => mListHoverFlatEdgeColor = v, "ListHoverFlatEdgeColor setting is wrong") },
                    { "ListDisableStandardFontColor", value => SetColorValue(value, v => mListDisableStandardFontColor = v, "ListDisableStandardFontColor setting is wrong") },
                    { "ListDisableStandardBackColor", value => SetColorValue(value, v => mListDisableStandardBackColor = v, "ListDisableStandardBackColor setting is wrong") },
                    { "ListDisableStandardEdgeColor", value => SetColorValue(value, v => mListDisableStandardEdgeColor = v, "ListDisableStandardEdgeColor setting is wrong") },
                    { "ListDisableFlatFontColor", value => SetColorValue(value, v => mListDisableFlatFontColor = v, "ListDisableFlatFontColor setting is wrong") },
                    { "ListDisableFlatBackColor", value => SetColorValue(value, v => mListDisableFlatBackColor = v, "ListDisableFlatBackColor setting is wrong") },
                    { "ListDisableFlatEdgeColor", value => SetColorValue(value, v => mListDisableFlatEdgeColor = v, "ListDisableFlatEdgeColor setting is wrong") },
                    #endregion
                    #region "ContextMenuStrip"
                    { "ContextDefaultFontColor", value => SetColorValue(value, v => mContextDefaultFontColor = v, "ContextDefaultFontColor setting is wrong") },
                    { "ContextDefaultBackColor", value => SetColorValue(value, v => mContextDefaultBackColor = v, "ContextDefaultBackColor setting is wrong") },
                    { "ContextDefaultEdgeColor", value => SetColorValue(value, v => mContextDefaultEdgeColor = v, "ContextDefaultEdgeColor setting is wrong") },
                    { "ContextHoverFontColor", value => SetColorValue(value, v => mContextHoverFontColor = v, "ContextHoverFontColor setting is wrong") },
                    { "ContextHoverBackColor", value => SetColorValue(value, v => mContextHoverBackColor = v, "ContextHoverBackColor setting is wrong") },
                    { "ContextHoverEdgeColor", value => SetColorValue(value, v => mContextHoverEdgeColor = v, "ContextHoverEdgeColor setting is wrong") },
                    { "ContextSelectedFontColor", value => SetColorValue(value, v => mContextSelectedFontColor = v, "ContextSelectedFontColor setting is wrong") },
                    { "ContextSelectedBackColor", value => SetColorValue(value, v => mContextSelectedBackColor = v, "ContextSelectedBackColor setting is wrong") },
                    { "ContextSelectedEdgeColor", value => SetColorValue(value, v => mContextSelectedEdgeColor = v, "ContextSelectedEdgeColor setting is wrong") },
                    { "ContextSelectedHoverFontColor", value => SetColorValue(value, v => mContextSelectedHoverFontColor = v, "ContextSelectedHoverFontColor setting is wrong") },
                    { "ContextSelectedHoverBackColor", value => SetColorValue(value, v => mContextSelectedHoverBackColor = v, "ContextSelectedHoverBackColor setting is wrong") },
                    { "ContextSelectedHoverEdgeColor", value => SetColorValue(value, v => mContextSelectedHoverEdgeColor = v, "ContextSelectedHoverEdgeColor setting is wrong") },
                    { "ContextDisableFontColor", value => SetColorValue(value, v => mContextDisableFontColor = v, "ContextDisableFontColor setting is wrong") },
                    { "ContextDisableBackColor", value => SetColorValue(value, v => mContextDisableBackColor = v, "ContextDisableBackColor setting is wrong") },
                    { "ContextDisableEdgeColor", value => SetColorValue(value, v => mContextDisableEdgeColor = v, "ContextDisableEdgeColor setting is wrong") },
                    #endregion
                    #region "MenuStrip"
                    { "MenuDefaultFontColor", value => SetColorValue(value, v => mMenuDefaultFontColor = v, "MenuDefaultFontColor setting is wrong") },
                    { "MenuDefaultBackColor", value => SetColorValue(value, v => mMenuDefaultBackColor = v, "MenuDefaultBackColor setting is wrong") },
                    { "MenuHoverFontColor", value => SetColorValue(value, v => mMenuHoverFontColor = v, "MenuHoverFontColor setting is wrong") },
                    { "MenuHoverBackColor", value => SetColorValue(value, v => mMenuHoverBackColor = v, "MenuHoverBackColor setting is wrong") },
                    { "MenuDisableFontColor", value => SetColorValue(value, v => mMenuDisableFontColor = v, "MenuDisableFontColor setting is wrong") },
                    { "MenuDisableBackColor", value => SetColorValue(value, v => mMenuDisableBackColor = v, "MenuDisableBackColor setting is wrong") },
                    #endregion
                    #region "Button"
                    { "ButtonDefaultPrimaryFontColor", value => SetColorValue(value, v => mButtonDefaultPrimaryFontColor = v, "ButtonDefaultPrimaryFontColor setting is wrong") },
                    { "ButtonDefaultPrimaryBackColor", value => SetColorValue(value, v => mButtonDefaultPrimaryBackColor = v, "ButtonDefaultPrimaryBackColor setting is wrong") },
                    { "ButtonDefaultPrimaryEdgeColor", value => SetColorValue(value, v => mButtonDefaultPrimaryEdgeColor = v, "ButtonDefaultPrimaryEdgeColor setting is wrong") },
                    { "ButtonDefaultTonalFontColor", value => SetColorValue(value, v => mButtonDefaultTonalFontColor = v, "ButtonDefaultTonalFontColor setting is wrong") },
                    { "ButtonDefaultTonalBackColor", value => SetColorValue(value, v => mButtonDefaultTonalBackColor = v, "ButtonDefaultTonalBackColor setting is wrong") },
                    { "ButtonDefaultTonalEdgeColor", value => SetColorValue(value, v => mButtonDefaultTonalEdgeColor = v, "ButtonDefaultTonalEdgeColor setting is wrong") },
                    { "ButtonDefaultOutlinedFontColor", value => SetColorValue(value, v => mButtonDefaultOutlinedFontColor = v, "ButtonDefaultOutlinedFontColor setting is wrong") },
                    { "ButtonDefaultOutlinedBackColor", value => SetColorValue(value, v => mButtonDefaultOutlinedBackColor = v, "ButtonDefaultOutlinedBackColor setting is wrong") },
                    { "ButtonDefaultOutlinedEdgeColor", value => SetColorValue(value, v => mButtonDefaultOutlinedEdgeColor = v, "ButtonDefaultOutlinedEdgeColor setting is wrong") },
                    { "ButtonDefaultTextFontColor", value => SetColorValue(value, v => mButtonDefaultTextFontColor = v, "ButtonDefaultTextFontColor setting is wrong") },
                    { "ButtonDefaultTextBackColor", value => SetColorValue(value, v => mButtonDefaultTextBackColor = v, "ButtonDefaultTextBackColor setting is wrong") },
                    { "ButtonDefaultTextEdgeColor", value => SetColorValue(value, v => mButtonDefaultTextEdgeColor = v, "ButtonDefaultTextEdgeColor setting is wrong") },
                    { "ButtonHoverPrimaryFontColor", value => SetColorValue(value, v => mButtonHoverPrimaryFontColor = v, "ButtonHoverPrimaryFontColor setting is wrong") },
                    { "ButtonHoverPrimaryBackColor", value => SetColorValue(value, v => mButtonHoverPrimaryBackColor = v, "ButtonHoverPrimaryBackColor setting is wrong") },
                    { "ButtonHoverPrimaryEdgeColor", value => SetColorValue(value, v => mButtonHoverPrimaryEdgeColor = v, "ButtonHoverPrimaryEdgeColor setting is wrong") },
                    { "ButtonHoverTonalFontColor", value => SetColorValue(value, v => mButtonHoverTonalFontColor = v, "ButtonHoverTonalFontColor setting is wrong") },
                    { "ButtonHoverTonalBackColor", value => SetColorValue(value, v => mButtonHoverTonalBackColor = v, "ButtonHoverTonalBackColor setting is wrong") },
                    { "ButtonHoverTonalEdgeColor", value => SetColorValue(value, v => mButtonHoverTonalEdgeColor = v, "ButtonHoverTonalEdgeColor setting is wrong") },
                    { "ButtonHoverOutlinedFontColor", value => SetColorValue(value, v => mButtonHoverOutlinedFontColor = v, "ButtonHoverOutlinedFontColor setting is wrong") },
                    { "ButtonHoverOutlinedBackColor", value => SetColorValue(value, v => mButtonHoverOutlinedBackColor = v, "ButtonHoverOutlinedBackColor setting is wrong") },
                    { "ButtonHoverOutlinedEdgeColor", value => SetColorValue(value, v => mButtonHoverOutlinedEdgeColor = v, "ButtonHoverOutlinedEdgeColor setting is wrong") },
                    { "ButtonHoverTextFontColor", value => SetColorValue(value, v => mButtonHoverTextFontColor = v, "ButtonHoverTextFontColor setting is wrong") },
                    { "ButtonHoverTextBackColor", value => SetColorValue(value, v => mButtonHoverTextBackColor = v, "ButtonHoverTextBackColor setting is wrong") },
                    { "ButtonHoverTextEdgeColor", value => SetColorValue(value, v => mButtonHoverTextEdgeColor = v, "ButtonHoverTextEdgeColor setting is wrong") },
                    { "ButtonPressedPrimaryFontColor", value => SetColorValue(value, v => mButtonPressedPrimaryFontColor = v, "ButtonPressedPrimaryFontColor setting is wrong") },
                    { "ButtonPressedPrimaryBackColor", value => SetColorValue(value, v => mButtonPressedPrimaryBackColor = v, "ButtonPressedPrimaryBackColor setting is wrong") },
                    { "ButtonPressedPrimaryEdgeColor", value => SetColorValue(value, v => mButtonPressedPrimaryEdgeColor = v, "ButtonPressedPrimaryEdgeColor setting is wrong") },
                    { "ButtonPressedTonalFontColor", value => SetColorValue(value, v => mButtonPressedTonalFontColor = v, "ButtonPressedTonalFontColor setting is wrong") },
                    { "ButtonPressedTonalBackColor", value => SetColorValue(value, v => mButtonPressedTonalBackColor = v, "ButtonPressedTonalBackColor setting is wrong") },
                    { "ButtonPressedTonalEdgeColor", value => SetColorValue(value, v => mButtonPressedTonalEdgeColor = v, "ButtonPressedTonalEdgeColor setting is wrong") },
                    { "ButtonPressedOutlinedFontColor", value => SetColorValue(value, v => mButtonPressedOutlinedFontColor = v, "ButtonPressedOutlinedFontColor setting is wrong") },
                    { "ButtonPressedOutlinedBackColor", value => SetColorValue(value, v => mButtonPressedOutlinedBackColor = v, "ButtonPressedOutlinedBackColor setting is wrong") },
                    { "ButtonPressedOutlinedEdgeColor", value => SetColorValue(value, v => mButtonPressedOutlinedEdgeColor = v, "ButtonPressedOutlinedEdgeColor setting is wrong") },
                    { "ButtonPressedTextFontColor", value => SetColorValue(value, v => mButtonPressedTextFontColor = v, "ButtonPressedTextFontColor setting is wrong") },
                    { "ButtonPressedTextBackColor", value => SetColorValue(value, v => mButtonPressedTextBackColor = v, "ButtonPressedTextBackColor setting is wrong") },
                    { "ButtonPressedTextEdgeColor", value => SetColorValue(value, v => mButtonPressedTextEdgeColor = v, "ButtonPressedTextEdgeColor setting is wrong") },
                    { "ButtonDisablePrimaryFontColor", value => SetColorValue(value, v => mButtonDisablePrimaryFontColor = v, "ButtonDisablePrimaryFontColor setting is wrong") },
                    { "ButtonDisablePrimaryBackColor", value => SetColorValue(value, v => mButtonDisablePrimaryBackColor = v, "ButtonDisablePrimaryBackColor setting is wrong") },
                    { "ButtonDisablePrimaryEdgeColor", value => SetColorValue(value, v => mButtonDisablePrimaryEdgeColor = v, "ButtonDisablePrimaryEdgeColor setting is wrong") },
                    { "ButtonDisableTonalFontColor", value => SetColorValue(value, v => mButtonDisableTonalFontColor = v, "ButtonDisableTonalFontColor setting is wrong") },
                    { "ButtonDisableTonalBackColor", value => SetColorValue(value, v => mButtonDisableTonalBackColor = v, "ButtonDisableTonalBackColor setting is wrong") },
                    { "ButtonDisableTonalEdgeColor", value => SetColorValue(value, v => mButtonDisableTonalEdgeColor = v, "ButtonDisableTonalEdgeColor setting is wrong") },
                    { "ButtonDisableOutlinedFontColor", value => SetColorValue(value, v => mButtonDisableOutlinedFontColor = v, "ButtonDisableOutlinedFontColor setting is wrong") },
                    { "ButtonDisableOutlinedBackColor", value => SetColorValue(value, v => mButtonDisableOutlinedBackColor = v, "ButtonDisableOutlinedBackColor setting is wrong") },
                    { "ButtonDisableOutlinedEdgeColor", value => SetColorValue(value, v => mButtonDisableOutlinedEdgeColor = v, "ButtonDisableOutlinedEdgeColor setting is wrong") },
                    { "ButtonDisableTextFontColor", value => SetColorValue(value, v => mButtonDisableTextFontColor = v, "ButtonDisableTextFontColor setting is wrong") },
                    { "ButtonDisableTextBackColor", value => SetColorValue(value, v => mButtonDisableTextBackColor = v, "ButtonDisableTextBackColor setting is wrong") },
                    { "ButtonDisableTextEdgeColor", value => SetColorValue(value, v => mButtonDisableTextEdgeColor = v, "ButtonDisableTextEdgeColor setting is wrong") },
                    #endregion
                    #region "ToggleButton"
                    { "ToggleOnTonalFontColor", value => SetColorValue(value, v => mToggleOnTonalFontColor = v, "ToggleOnTonalFontColor setting is wrong") },
                    { "ToggleOnTonalBackColor", value => SetColorValue(value, v => mToggleOnTonalBackColor = v, "ToggleOnTonalBackColor setting is wrong") },
                    { "ToggleOnTonalEdgeColor", value => SetColorValue(value, v => mToggleOnTonalEdgeColor = v, "ToggleOnTonalEdgeColor setting is wrong") },
                    { "ToggleOnOutlinedFontColor", value => SetColorValue(value, v => mToggleOnOutlinedFontColor = v, "ToggleOnOutlinedFontColor setting is wrong") },
                    { "ToggleOnOutlinedBackColor", value => SetColorValue(value, v => mToggleOnOutlinedBackColor = v, "ToggleOnOutlinedBackColor setting is wrong") },
                    { "ToggleOnOutlinedEdgeColor", value => SetColorValue(value, v => mToggleOnOutlinedEdgeColor = v, "ToggleOnOutlinedEdgeColor setting is wrong") },
                    { "ToggleOnTextFontColor", value => SetColorValue(value, v => mToggleOnTextFontColor = v, "ToggleOnTextFontColor setting is wrong") },
                    { "ToggleOnTextBackColor", value => SetColorValue(value, v => mToggleOnTextBackColor = v, "ToggleOnTextBackColor setting is wrong") },
                    { "ToggleOnTextEdgeColor", value => SetColorValue(value, v => mToggleOnTextEdgeColor = v, "ToggleOnTextEdgeColor setting is wrong") },
                    { "ToggleOffTonalFontColor", value => SetColorValue(value, v => mToggleOffTonalFontColor = v, "ToggleOffTonalFontColor setting is wrong") },
                    { "ToggleOffTonalBackColor", value => SetColorValue(value, v => mToggleOffTonalBackColor = v, "ToggleOffTonalBackColor setting is wrong") },
                    { "ToggleOffTonalEdgeColor", value => SetColorValue(value, v => mToggleOffTonalEdgeColor = v, "ToggleOffTonalEdgeColor setting is wrong") },
                    { "ToggleOffOutlinedFontColor", value => SetColorValue(value, v => mToggleOffOutlinedFontColor = v, "ToggleOffOutlinedFontColor setting is wrong") },
                    { "ToggleOffOutlinedBackColor", value => SetColorValue(value, v => mToggleOffOutlinedBackColor = v, "ToggleOffOutlinedBackColor setting is wrong") },
                    { "ToggleOffOutlinedEdgeColor", value => SetColorValue(value, v => mToggleOffOutlinedEdgeColor = v, "ToggleOffOutlinedEdgeColor setting is wrong") },
                    { "ToggleOffTextFontColor", value => SetColorValue(value, v => mToggleOffTextFontColor = v, "ToggleOffTextFontColor setting is wrong") },
                    { "ToggleOffTextBackColor", value => SetColorValue(value, v => mToggleOffTextBackColor = v, "ToggleOffTextBackColor setting is wrong") },
                    { "ToggleOffTextEdgeColor", value => SetColorValue(value, v => mToggleOffTextEdgeColor = v, "ToggleOffTextEdgeColor setting is wrong") },
                    #endregion
                    #region "Calendar"
                    { "CalendarDefaultFontColor", value => SetColorValue(value, v => mCalendarDefaultFontColor = v, "CalendarDefaultFontColor setting is wrong") },
                    { "CalendarDefaultBackColor", value => SetColorValue(value, v => mCalendarDefaultBackColor = v, "CalendarDefaultBackColor setting is wrong") },
                    { "CalendarDefaultTitleFontColor", value => SetColorValue(value, v => mCalendarDefaultTitleFontColor = v, "CalendarDefaultTitleFontColor setting is wrong") },
                    { "CalendarDefaultTitleBackColor", value => SetColorValue(value, v => mCalendarDefaultTitleBackColor = v, "CalendarDefaultTitleBackColor setting is wrong") },
                    { "CalendarDefaultTrailingFontColor", value => SetColorValue(value, v => mCalendarDefaultTrailingFontColor = v, "CalendarDefaultTrailingFontColor setting is wrong") },
                    #endregion
                    #region "ProgressBar"
                    { "ProgressDefaultFontColor", value => SetColorValue(value, v => mProgressDefaultFontColor = v, "ProgressDefaultFontColor setting is wrong") },
                    { "ProgressDefaultBackColor", value => SetColorValue(value, v => mProgressDefaultBackColor = v, "ProgressDefaultBackColor setting is wrong") },
                    #endregion
                    #region 後で消す
                    { "BackColor", value => SetColorValue(value, v => mBackColor = v, "BackColor setting is wrong") },
                    { "InactiveColor", value => SetColorValue(value, v => mInactiveColor = v, "InactiveColor setting is wrong") },
                    { "InputBackColor", value => SetColorValue(value, v => mInputBackColor = v, "InputBackColor setting is wrong") },
                    { "InputEdgeColor", value => SetColorValue(value, v => mInputEdgeColor = v, "InputEdgeColor setting is wrong") },
                    { "ComponentEdgeColor", value => SetColorValue(value, v => mComponentEdgeColor = v, "ComponentEdgeColor setting is wrong") },
                    #endregion
                };

                foreach (XmlNode node in settingNodes)
                {
                    if (node.Attributes == null)
                    {
                        continue;
                    }

                    string? key = node.Attributes["key"]?.Value;
                    string? value = node.Attributes["value"]?.Value;

                    if (string.IsNullOrWhiteSpace(key) || string.IsNullOrWhiteSpace(value))
                    {
                        mLog.Debug($"Empty key: {key}, value: {value}");
                        continue;
                    }

                    // keyに対応する処理を実行
                    if (keyValueProcessors.TryGetValue(key, out var processor))
                    {
                        processor(value);
                    }
                    else
                    {
                        mLog.Debug($"Unknown key: {key}");
                    }
                }
            }
            catch (Exception ex)
            {
                mLog.Debug("Init_Exception");
                mLog.Error(ex.ToString());
            }
        }

        /// <summary>
        /// フォントの設定
        /// </summary>
        /// <param name="value">XML設定値</param>
        /// <param name="setAction">アクション</param>
        /// <param name="errorMessage">エラーメッセージ</param>
        private static void SetFontType(string value, Action<string> setAction, string errorMessage)
        {
            if (IsFontInstalled(value))
            {
                setAction(value);
            }
            else
            {
                mLog.Debug(errorMessage);
            }
        }

        /// <summary>
        /// Int型数値の設定
        /// </summary>
        /// <param name="value">XML設定値</param>
        /// <param name="setAction">アクション</param>
        /// <param name="errorMessage">エラーメッセージ</param>
        private static void SetIntValue(string value, Action<int> setAction, string errorMessage)
        {
            if (int.TryParse(value, out int outValue))
            {
                setAction(outValue);
            }
            else
            {
                mLog.Debug(errorMessage);
            }
        }

        /// <summary>
        /// カラーコードの設定
        /// </summary>
        /// <param name="value">XML設定値</param>
        /// <param name="setAction">アクション</param>
        /// <param name="errorMessage">エラーメッセージ</param>
        private static void SetColorValue(string value, Action<string> setAction, string errorMessage)
        {
            if (IsColorCode(value))
            {
                setAction(value);
            }
            else
            {
                mLog.Debug(errorMessage);
            }
        }
        #endregion
    }
}
//---<<END OF FILE>>-----------------------------------------------------