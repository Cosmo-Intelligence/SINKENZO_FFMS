//-----------------------------------------------------------------------
// <copyright file="Constants.cs" company="FUJIFILM Medical Solutions Corporation">
//    Copyright (C) 2025 FUJIFILM Medical Solutions Corporation.
// </copyright>
//-----------------------------------------------------------------------

namespace RADISTA.UIComponent.CustomControl
{
    /// <summary>
    /// 定数クラス
    /// </summary>
    /// <remarks>
    /// 
    /// (Rev.)        (Date)      (ID / NAME)                     (Comment)
    /// V1.00.00    : 2025.05.01    : 株式会社コスモ・インテリジェンス / 藤原崇文   : original
    ///
    /// </remarks>
    public static class Constants
    {
        #region "定数"
        #region "xmlデフォルト値"
        #region "フォント"
        /// <summary>
        /// フォントタイプ
        /// </summary>
        public const string FONT_TYPE = "Meiryo UI";
        /// <summary>
        /// フォントサイズ
        /// </summary>
        public const int FONT_SIZE = 12;
        /// <summary>
        /// フォント色
        /// </summary>
        public const string FONT_COLOR = "#C4C4C4";
        /// <summary>
        /// Disable時のフォント色
        /// </summary>
        public const string FONT_DISABLE_COLOR = "#555555";
        /// <summary>
        /// フォーカス時のフォント色
        /// </summary>
        public const string FONT_FOCUS_COLOR = "#C4C4C4";
        /// <summary>
        /// ReadOnly時のフォント色
        /// </summary>
        public const string FONT_READ_ONLY_COLOR = "#C4C4C4";
        #endregion

        #region "カラー定義"
        #region "Form, Dialog"
        /// <summary>
        /// Defaultのフォントカラー
        /// </summary>
        public const string FORM_DEFAULT_FONT_COLOR = "#C4C4C4";
        /// <summary>
        /// Defaultのバックカラー
        /// </summary>
        public const string FORM_DEFAULT_BACK_COLOR = "#000000";
        /// <summary>
        /// Titlebarのフォントカラー
        /// </summary>
        public const string FORM_TITLEBAR_FONT_COLOR = "#C4C4C4";
        /// <summary>
        /// Titlebarのバックカラー
        /// </summary>
        public const string FORM_TITLEBAR_BACK_COLOR = "#000000";
        #endregion

        #region "Label"
        /// <summary>
        /// Defaultのフォントカラー
        /// </summary>
        public const string LABEL_DEFAULT_FONT_COLOR = "#C4C4C4";
        /// <summary>
        /// Defaultのバックカラー
        /// </summary>
        public const string LABEL_DEFAULT_BACK_COLOR = "#262626";
        /// <summary>
        /// Defaultのエッジカラー
        /// </summary>
        public const string LABEL_DEFAULT_EDGE_COLOR = "#464646";
        #endregion

        #region "TextBox, ComboBox"
        /// <summary>
        /// Defaultのフォントカラー
        /// </summary>
        public const string TEXT_DEFAULT_FONT_COLOR = "#C4C4C4";
        /// <summary>
        /// Defaultのバックカラー
        /// </summary>
        public const string TEXT_DEFAULT_BACK_COLOR = "#191919";
        /// <summary>
        /// Defaultのエッジカラー
        /// </summary>
        public const string TEXT_DEFAULT_EDGE_COLOR = "#4F4F4F";
        /// <summary>
        /// Disableのフォントカラー
        /// </summary>
        public const string TEXT_DISABLE_FONT_COLOR = "#555555";
        /// <summary>
        /// Disableのバックカラー
        /// </summary>
        public const string TEXT_DISABLE_BACK_COLOR = "#222222";
        /// <summary>
        /// Disableのエッジカラー
        /// </summary>
        public const string TEXT_DISABLE_EDGE_COLOR = "#3E3E3E";
        /// <summary>
        /// Focusのフォントカラー
        /// </summary>
        public const string TEXT_FOCUS_FONT_COLOR = "#C4C4C4";
        /// <summary>
        /// Focusのバックカラー
        /// </summary>
        public const string TEXT_FOCUS_BACK_COLOR = "#191919";
        /// <summary>
        /// Focusのエッジカラー
        /// </summary>
        public const string TEXT_FOCUS_EDGE_COLOR = "#439977";
        /// <summary>
        /// ReadOnlyのフォントカラー
        /// </summary>
        public const string TEXT_READ_ONLY_FONT_COLOR = "#C4C4C4";
        /// <summary>
        /// ReadOnlyのバックカラー
        /// </summary>
        public const string TEXT_READ_ONLY_BACK_COLOR = "#232323";
        /// <summary>
        /// ReadOnlyのエッジカラー
        /// </summary>
        public const string TEXT_READ_ONLY_EDGE_COLOR = "#232323";
        /// <summary>
        /// WaterMarkのフォントカラー
        /// </summary>
        public const string TEXT_WATER_MARK_FONT_COLOR = "#5A5A5A";
        #endregion

        #region "ListView, ListBox"
        /// <summary>
        /// Default_Standardのフォントカラー
        /// </summary>
        public const string LIST_DEFAULT_STANDARD_FONT_COLOR = "#C4C4C4";
        /// <summary>
        /// Default_Standardのバックカラー
        /// </summary>
        public const string LIST_DEFAULT_STANDARD_BACK_COLOR = "#363636";
        /// <summary>
        /// Default_Standardのエッジカラー
        /// </summary>
        public const string LIST_DEFAULT_STANDARD_EDGE_COLOR = "#3E3E3E";
        /// <summary>
        /// Default_Flatのフォントカラー
        /// </summary>
        public const string LIST_DEFAULT_FLAT_FONT_COLOR = "#C4C4C4";
        /// <summary>
        /// Default_Flatのバックカラー
        /// </summary>
        public const string LIST_DEFAULT_FLAT_BACK_COLOR = "#262626";
        /// <summary>
        /// Default_Flatのエッジカラー
        /// </summary>
        public const string LIST_DEFAULT_FLAT_EDGE_COLOR = "#262626";

        /// <summary>
        /// Hover_Standardのフォントカラー
        /// </summary>
        public const string LIST_HOVER_STANDARD_FONT_COLOR = "#C4C4C4";
        /// <summary>
        /// Hover_Standardのバックカラー
        /// </summary>
        public const string LIST_HOVER_STANDARD_BACK_COLOR = "#464646";
        /// <summary>
        /// Hover_Standardのエッジカラー
        /// </summary>
        public const string LIST_HOVER_STANDARD_EDGE_COLOR = "#5A5A5A";
        /// <summary>
        /// Hover_Flatのフォントカラー
        /// </summary>
        public const string LIST_HOVER_FLAT_FONT_COLOR = "#C4C4C4";
        /// <summary>
        /// Hover_Flatのバックカラー
        /// </summary>
        public const string LIST_HOVER_FLAT_BACK_COLOR = "#464646";
        /// <summary>
        /// Hover_Flatのエッジカラー
        /// </summary>
        public const string LIST_HOVER_FLAT_EDGE_COLOR = "#464646";

        /// <summary>
        /// Disable_Standardのフォントカラー
        /// </summary>
        public const string LIST_DISABLE_STANDARD_FONT_COLOR = "#555555";
        /// <summary>
        /// Disable_Standardのバックカラー
        /// </summary>
        public const string LIST_DISABLE_STANDARD_BACK_COLOR = "#262626";
        /// <summary>
        /// Disable_Standardのエッジカラー
        /// </summary>
        public const string LIST_DISABLE_STANDARD_EDGE_COLOR = "#262626";
        /// <summary>
        /// Disable_Flatのフォントカラー
        /// </summary>
        public const string LIST_DISABLE_FLAT_FONT_COLOR = "#555555";
        /// <summary>
        /// Disable_Flatのバックカラー
        /// </summary>
        public const string LIST_DISABLE_FLAT_BACK_COLOR = "#262626";
        /// <summary>
        /// Disable_Flatのエッジカラー
        /// </summary>
        public const string LIST_DISABLE_FLAT_EDGE_COLOR = "#262626";
        #endregion

        #region "ContextMenuStrip"
        /// <summary>
        /// Defaultのフォントカラー
        /// </summary>
        public const string CONTEXT_DEFAULT_FONT_COLOR = "#C4C4C4";
        /// <summary>
        /// Defaultのバックカラー
        /// </summary>
        public const string CONTEXT_DEFAULT_BACK_COLOR = "#363636";
        /// <summary>
        /// Defaultのエッジカラー
        /// </summary>
        public const string CONTEXT_DEFAULT_EDGE_COLOR = "#4F4F4F";
        /// <summary>
        /// Hoverのフォントカラー
        /// </summary>
        public const string CONTEXT_HOVER_FONT_COLOR = "#C4C4C4";
        /// <summary>
        /// Hoverのバックカラー
        /// </summary>
        public const string CONTEXT_HOVER_BACK_COLOR = "#464646";
        /// <summary>
        /// Hoverのエッジカラー
        /// </summary>
        public const string CONTEXT_HOVER_EDGE_COLOR = "#4F4F4F";
        /// <summary>
        /// Selectedのフォントカラー
        /// </summary>
        public const string CONTEXT_SELECTED_FONT_COLOR = "#C4C4C4";
        /// <summary>
        /// Selectedのバックカラー
        /// </summary>
        public const string CONTEXT_SELECTED_BACK_COLOR = "#363636";
        /// <summary>
        /// Selectedのエッジカラー
        /// </summary>
        public const string CONTEXT_SELECTED_EDGE_COLOR = "#4F4F4F";
        /// <summary>
        /// SelectedHoverのフォントカラー
        /// </summary>
        public const string CONTEXT_SELECTED_HOVER_FONT_COLOR = "#C4C4C4";
        /// <summary>
        /// SelectedHoverのバックカラー
        /// </summary>
        public const string CONTEXT_SELECTED_HOVER_BACK_COLOR = "#464646";
        /// <summary>
        /// SelectedHoverのエッジカラー
        /// </summary>
        public const string CONTEXT_SELECTED_HOVER_EDGE_COLOR = "#4F4F4F";
        /// <summary>
        /// Disableのフォントカラー
        /// </summary>
        public const string CONTEXT_DISABLE_FONT_COLOR = "#5A5A5A";
        /// <summary>
        /// Disableのバックカラー
        /// </summary>
        public const string CONTEXT_DISABLE_BACK_COLOR = "#363636";
        /// <summary>
        /// Disableのエッジカラー
        /// </summary>
        public const string CONTEXT_DISABLE_EDGE_COLOR = "#4F4F4F";
        #endregion

        #region "MenuStrip"
        /// <summary>
        /// Defaultのフォントカラー
        /// </summary>
        public const string MENU_DEFAULT_FONT_COLOR = "#C4C4C4";
        /// <summary>
        /// Defaultのバックカラー
        /// </summary>
        public const string MENU_DEFAULT_BACK_COLOR = "#363636";
        /// <summary>
        /// Hoverのフォントカラー
        /// </summary>
        public const string MENU_HOVER_FONT_COLOR = "#C4C4C4";
        /// <summary>
        /// Hoverのバックカラー
        /// </summary>
        public const string MENU_HOVER_BACK_COLOR = "#464646";
        /// <summary>
        /// Disableのフォントカラー
        /// </summary>
        public const string MENU_DISABLE_FONT_COLOR = "#5A5A5A";
        /// <summary>
        /// Disableのバックカラー
        /// </summary>
        public const string MENU_DISABLE_BACK_COLOR = "#363636";
        #endregion

        #region "Button"
        /// <summary>
        /// Default_Primaryのフォントカラー
        /// </summary>
        public const string BUTTON_DEFAULT_PRIMARY_FONT_COLOR = "#D7D7D7";
        /// <summary>
        /// Default_Primaryのバックカラー
        /// </summary>
        public const string BUTTON_DEFAULT_PRIMARY_BACK_COLOR = "#397B61";
        /// <summary>
        /// Default_Primaryのエッジカラー
        /// </summary>
        public const string BUTTON_DEFAULT_PRIMARY_EDGE_COLOR = "#464646";
        /// <summary>
        /// Default_Tonalのフォントカラー
        /// </summary>
        public const string BUTTON_DEFAULT_TONAL_FONT_COLOR = "#C4C4C4";
        /// <summary>
        /// Default_Tonalのバックカラー
        /// </summary>
        public const string BUTTON_DEFAULT_TONAL_BACK_COLOR = "#363636";
        /// <summary>
        /// Default_Tonalのエッジカラー
        /// </summary>
        public const string BUTTON_DEFAULT_TONAL_EDGE_COLOR = "#464646";
        /// <summary>
        /// Default_Outlinedのフォントカラー
        /// </summary>
        public const string BUTTON_DEFAULT_OUTLINED_FONT_COLOR = "#C4C4C4";
        /// <summary>
        /// Default_Outlinedのバックカラー
        /// </summary>
        public const string BUTTON_DEFAULT_OUTLINED_BACK_COLOR = "#252525";
        /// <summary>
        /// Default_Outlinedのエッジカラー
        /// </summary>
        public const string BUTTON_DEFAULT_OUTLINED_EDGE_COLOR = "#464646";
        /// <summary>
        /// Default_Textのフォントカラー
        /// </summary>
        public const string BUTTON_DEFAULT_TEXT_FONT_COLOR = "#C4C4C4";
        /// <summary>
        /// Default_Textのバックカラー
        /// </summary>
        public const string BUTTON_DEFAULT_TEXT_BACK_COLOR = "#252525";
        /// <summary>
        /// Default_Textのエッジカラー
        /// </summary>
        public const string BUTTON_DEFAULT_TEXT_EDGE_COLOR = "#252525";

        /// <summary>
        /// Hover_Primaryのフォントカラー
        /// </summary>
        public const string BUTTON_HOVER_PRIMARY_FONT_COLOR = "#D7D7D7";
        /// <summary>
        /// Hover_Primaryのバックカラー
        /// </summary>
        public const string BUTTON_HOVER_PRIMARY_BACK_COLOR = "#439977";
        /// <summary>
        /// Hover_Primaryのエッジカラー
        /// </summary>
        public const string BUTTON_HOVER_PRIMARY_EDGE_COLOR = "#464646";
        /// <summary>
        /// Hover_Tonalのフォントカラー
        /// </summary>
        public const string BUTTON_HOVER_TONAL_FONT_COLOR = "#C4C4C4";
        /// <summary>
        /// Hover_Tonalのバックカラー
        /// </summary>
        public const string BUTTON_HOVER_TONAL_BACK_COLOR = "#3A3A3A";
        /// <summary>
        /// Hover_Tonalのエッジカラー
        /// </summary>
        public const string BUTTON_HOVER_TONAL_EDGE_COLOR = "#464646";
        /// <summary>
        /// Hover_Outlinedのフォントカラー
        /// </summary>
        public const string BUTTON_HOVER_OUTLINED_FONT_COLOR = "#C4C4C4";
        /// <summary>
        /// Hover_Outlinedのバックカラー
        /// </summary>
        public const string BUTTON_HOVER_OUTLINED_BACK_COLOR = "#3A3A3A";
        /// <summary>
        /// Hover_Outlinedのエッジカラー
        /// </summary>
        public const string BUTTON_HOVER_OUTLINED_EDGE_COLOR = "#464646";
        /// <summary>
        /// Hover_Textのフォントカラー
        /// </summary>
        public const string BUTTON_HOVER_TEXT_FONT_COLOR = "#C4C4C4";
        /// <summary>
        /// Hover_Textのバックカラー
        /// </summary>
        public const string BUTTON_HOVER_TEXT_BACK_COLOR = "#3A3A3A";
        /// <summary>
        /// Hover_Textのエッジカラー
        /// </summary>
        public const string BUTTON_HOVER_TEXT_EDGE_COLOR = "#3A3A3A";

        /// <summary>
        /// Pressed_Primaryのフォントカラー
        /// </summary>
        public const string BUTTON_PRESSED_PRIMARY_FONT_COLOR = "#D7D7D7";
        /// <summary>
        /// Pressed_Primaryのバックカラー
        /// </summary>
        public const string BUTTON_PRESSED_PRIMARY_BACK_COLOR = "#325447";
        /// <summary>
        /// Pressed_Primaryのエッジカラー
        /// </summary>
        public const string BUTTON_PRESSED_PRIMARY_EDGE_COLOR = "#464646";
        /// <summary>
        /// Pressed_Tonalのフォントカラー
        /// </summary>
        public const string BUTTON_PRESSED_TONAL_FONT_COLOR = "#C4C4C4";
        /// <summary>
        /// Pressed_Tonalのバックカラー
        /// </summary>
        public const string BUTTON_PRESSED_TONAL_BACK_COLOR = "#191919";
        /// <summary>
        /// Pressed_Tonalのエッジカラー
        /// </summary>
        public const string BUTTON_PRESSED_TONAL_EDGE_COLOR = "#191919";
        /// <summary>
        /// Pressed_Outlinedのフォントカラー
        /// </summary>
        public const string BUTTON_PRESSED_OUTLINED_FONT_COLOR = "#C4C4C4";
        /// <summary>
        /// Pressed_Outlinedのバックカラー
        /// </summary>
        public const string BUTTON_PRESSED_OUTLINED_BACK_COLOR = "#191919";
        /// <summary>
        /// Pressed_Outlinedのエッジカラー
        /// </summary>
        public const string BUTTON_PRESSED_OUTLINED_EDGE_COLOR = "#191919";
        /// <summary>
        /// Pressed_Textのフォントカラー
        /// </summary>
        public const string BUTTON_PRESSED_TEXT_FONT_COLOR = "#C4C4C4";
        /// <summary>
        /// Pressed_Textのバックカラー
        /// </summary>
        public const string BUTTON_PRESSED_TEXT_BACK_COLOR = "#191919";
        /// <summary>
        /// Pressed_Textのエッジカラー
        /// </summary>
        public const string BUTTON_PRESSED_TEXT_EDGE_COLOR = "#191919";

        /// <summary>
        /// Disable_Primaryのフォントカラー
        /// </summary>
        public const string BUTTON_DISABLE_PRIMARY_FONT_COLOR = "#5A5A5A";
        /// <summary>
        /// Disable_Primaryのバックカラー
        /// </summary>
        public const string BUTTON_DISABLE_PRIMARY_BACK_COLOR = "#2B3F37";
        /// <summary>
        /// Disable_Primaryのエッジカラー
        /// </summary>
        public const string BUTTON_DISABLE_PRIMARY_EDGE_COLOR = "#2F2F2F";
        /// <summary>
        /// Disable_Tonalのフォントカラー
        /// </summary>
        public const string BUTTON_DISABLE_TONAL_FONT_COLOR = "#545454";
        /// <summary>
        /// Disable_Tonalのバックカラー
        /// </summary>
        public const string BUTTON_DISABLE_TONAL_BACK_COLOR = "#2A2A2A";
        /// <summary>
        /// Disable_Tonalのエッジカラー
        /// </summary>
        public const string BUTTON_DISABLE_TONAL_EDGE_COLOR = "#2F2F2F";
        /// <summary>
        /// Disable_Outlinedのフォントカラー
        /// </summary>
        public const string BUTTON_DISABLE_OUTLINED_FONT_COLOR = "#2F2F2F";
        /// <summary>
        /// Disable_Outlinedのバックカラー
        /// </summary>
        public const string BUTTON_DISABLE_OUTLINED_BACK_COLOR = "#252525";
        /// <summary>
        /// Disable_Outlinedのエッジカラー
        /// </summary>
        public const string BUTTON_DISABLE_OUTLINED_EDGE_COLOR = "#545454";
        /// <summary>
        /// Disable_Textのフォントカラー
        /// </summary>
        public const string BUTTON_DISABLE_TEXT_FONT_COLOR = "#555555";
        /// <summary>
        /// Disable_Textのバックカラー
        /// </summary>
        public const string BUTTON_DISABLE_TEXT_BACK_COLOR = "#252525";
        /// <summary>
        /// Disable_Textのエッジカラー
        /// </summary>
        public const string BUTTON_DISABLE_TEXT_EDGE_COLOR = "#252525";
        #endregion

        #region "ToggleButton"
        /// <summary>
        /// On_Tonalのフォントカラー
        /// </summary>
        public const string TOGGLE_ON_TONAL_FONT_COLOR = "#12C296";
        /// <summary>
        /// On_Tonalのバックカラー
        /// </summary>
        public const string TOGGLE_ON_TONAL_BACK_COLOR = "#1E4038";
        /// <summary>
        /// On_Tonalのエッジカラー
        /// </summary>
        public const string TOGGLE_ON_TONAL_EDGE_COLOR = "#464646";
        /// <summary>
        /// On_Outlinedのフォントカラー
        /// </summary>
        public const string TOGGLE_ON_OUTLINED_FONT_COLOR = "#12C296";
        /// <summary>
        /// On_Outlinedのバックカラー
        /// </summary>
        public const string TOGGLE_ON_OUTLINED_BACK_COLOR = "#1E4038";
        /// <summary>
        /// On_Outlinedのエッジカラー
        /// </summary>
        public const string TOGGLE_ON_OUTLINED_EDGE_COLOR = "#464646";
        /// <summary>
        /// On_Textのフォントカラー
        /// </summary>
        public const string TOGGLE_ON_TEXT_FONT_COLOR = "#12C296";
        /// <summary>
        /// On_Textのバックカラー
        /// </summary>
        public const string TOGGLE_ON_TEXT_BACK_COLOR = "#1E4038";
        /// <summary>
        /// On_Textのエッジカラー
        /// </summary>
        public const string TOGGLE_ON_TEXT_EDGE_COLOR = "#1E4038";

        /// <summary>
        /// Off_Tonalのフォントカラー
        /// </summary>
        public const string TOGGLE_OFF_TONAL_FONT_COLOR = "#454545";
        /// <summary>
        /// Off_Tonalのバックカラー
        /// </summary>
        public const string TOGGLE_OFF_TONAL_BACK_COLOR = "#454545";
        /// <summary>
        /// Off_Tonalのエッジカラー
        /// </summary>
        public const string TOGGLE_OFF_TONAL_EDGE_COLOR = "#C4C4C4";
        /// <summary>
        /// Off_Outlinedのフォントカラー
        /// </summary>
        public const string TOGGLE_OFF_OUTLINED_FONT_COLOR = "#454545";
        /// <summary>
        /// Off_Outlinedのバックカラー
        /// </summary>
        public const string TOGGLE_OFF_OUTLINED_BACK_COLOR = "#454545";
        /// <summary>
        /// Off_Outlinedのエッジカラー
        /// </summary>
        public const string TOGGLE_OFF_OUTLINED_EDGE_COLOR = "#C4C4C4";
        /// <summary>
        /// Off_Textのフォントカラー
        /// </summary>
        public const string TOGGLE_OFF_TEXT_FONT_COLOR = "#C4C4C4";
        /// <summary>
        /// Off_Textのバックカラー
        /// </summary>
        public const string TOGGLE_OFF_TEXT_BACK_COLOR = "#454545";
        /// <summary>
        /// Off_Textのエッジカラー
        /// </summary>
        public const string TOGGLE_OFF_TEXT_EDGE_COLOR = "#454545";
        #endregion

        #region "Calendar"
        /// <summary>
        /// Defaultのフォントカラー
        /// </summary>
        public const string CARENDAR_DEFAULT_FONT_COLOR = "#C4C4C4";
        /// <summary>
        /// Defaultのバックカラー
        /// </summary>
        public const string CARENDAR_DEFAULT_BACK_COLOR = "#191919";
        /// <summary>
        /// Defaultのタイトルフォントバックカラー
        /// </summary>
        public const string CARENDAR_DEFAULT_TITLE_FONT_COLOR = "#C4C4C4";
        /// <summary>
        /// Defaultのタイトルバックカラー
        /// </summary>
        public const string CARENDAR_DEFAULT_TITLE_BACK_COLOR = "#3A3A3A";
        /// <summary>
        /// DefaultのTrailingのフォントカラー
        /// </summary>
        public const string CARENDAR_DEFAULT_TRAILING_FONT_COLOR = "#555555";
        #endregion

        #region "ProgressBar"
        /// <summary>
        /// Defaultのフォントカラー
        /// </summary>
        public const string PROGRESS_DEFAULT_FONT_COLOR = "#397B61";
        /// <summary>
        /// Defaultのバックカラー
        /// </summary>
        public const string PROGRESS_DEFAULT_BACK_COLOR = "#1B1B1B";
        #endregion

        #endregion "カラー定義"
        #endregion "xmlデフォルト値"

        #region "その他のデフォルト値"
        #endregion

        #region "エラーメッセージ"
        /// <summary>
        /// カラーコード入力判定エラー
        /// </summary>
        public const string ERROR_COLOR_CODE = "無効なカラーコードです。";
        #endregion

        // TODO:上記の設定値に置き換える、下記の定数はその他に移動するか削除する
        /// <summary>
        /// デフォルト_フォントタイプ
        /// </summary>
        public const string DEFAULT_FONT_TYPE = "Meiryo UI";
        /// <summary>
        /// デフォルト_フォントサイズ
        /// </summary>
        public const int DEFAULT_FONT_SIZE = 12;
        /// <summary>
        /// デフォルト_フォント色
        /// </summary>
        public const string DEFAULT_FONT_COLOR = "#C3C3C3";
        /// <summary>
        /// デフォルト_背景色
        /// </summary>
        public const string DEFAULT_BACK_COLOR = "#393939";
        /// <summary>
        /// デフォルト_非アクティブ時のフォント色
        /// </summary>
        public const string DEFAULT_INACTIVE_COLOR = "#323232";
        /// <summary>
        /// デフォルト_入力系の背景色
        /// </summary>
        public const string DEFAULT_INPUT_BACK_COLOR = "#000000";
        /// <summary>
        /// デフォルト_入力系のエッジ色
        /// </summary>
        public const string DEFAULT_INPUT_EDGE_COLOR = "#C3C3C3";
        /// <summary>
        /// デフォルト_コンポーネントのエッジ色
        /// </summary>
        public const string DEFAULT_COMPONENT_EDGE_COLOR = "#010101";
        /// <summary>
        /// 点滅中のフォント色
        /// </summary>
        public const string BLINK_FONT_COLOR = "#000000";
        /// <summary>
        /// 点滅中の背景色
        /// </summary>
        public const string BLINK_BACK_COLOR = "#000000";
        /// <summary>
        /// ボーダー色
        /// </summary>
        public const string BORDER_COLOR = "#C3C3C3";
        /// <summary>
        /// ウォーターマークのフォント色
        /// </summary>
        public const string WATERMARK_FONT_COLOR = "#c0c0c0";
        /// <summary>
        /// プログレスバー（進捗バー色）
        /// </summary>
        public const string PROGRESS_COLOR = "#00c400";
        /// <summary>
        /// プログレスバー（進捗バー背景色）
        /// </summary>
        public const string PROGRESS_BACK_COLOR = "#dcdcdc";
        /// <summary>
        /// リストビュー_交互背景色
        /// </summary>
        public const string BACKGROUND_ROW_COLOR = "#dcdcdc";
        /// <summary>
        /// フォームタイトル_背景色
        /// </summary>
        public const string FORM_TITLE_BACK_COLOR = "#008000";
        /// <summary>
        /// フォームタイトル_前景色
        /// </summary>
        public const string FORM_TITLE_FONT_COLOR = "#f5f5f5";
        #endregion
    }
}
//---<<END OF FILE>>-----------------------------------------------------
