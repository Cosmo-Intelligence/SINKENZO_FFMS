//-----------------------------------------------------------------------
// <copyright file="RdtGadgetTheme.cs" company="FUJIFILM Medical Solutions Corporation">
// Copyright (C) 2025 FUJIFILM Medical Solutions Corporation.
// </copyright>
//-----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WeifenLuo.WinFormsUI.Docking;

namespace RADISTA.UIComponent.CustomControl
{
    /// <summary>
    /// RdtGadgetViewクラス
    /// </summary>
    /// <remarks>
    /// 
    /// (Rev.)        (Date)      (ID / NAME)                     (Comment)
    /// V1.00.00    : 2025.05.01    : 株式会社コスモ・インテリジェンス / 藤原崇文   : original
    ///
    /// </remarks>
    internal class RdtGadgetTheme : VS2015DarkTheme
    {
        /// <summary>
        /// コンストラクタ
        /// DockPanel Suite のスキン要素の色プロパティを上書きします。
        /// </summary>
        public RdtGadgetTheme()
        {
            // --- ツールウィンドウのキャプション（タイトルバー）の色設定 ---
            // これらの設定は、主にツールウィンドウのキャプション（タイトルバー）に影響を与えます。
            // また、もしカスタムのDockPaneStripレンダラーがタブの色を個別に処理しない場合、
            // これらの設定がタブの色にも影響を与える可能性があります。

            // アクティブなツールウィンドウのキャプション（タブが選択されているパネルのタイトルバー）のグラデーション開始色
            this.Skin.DockPaneStripSkin.ToolWindowGradient.ActiveCaptionGradient.StartColor = ColorTranslator.FromHtml("#03787C");
            // アクティブなツールウィンドウのキャプションのグラデーション終了色
            this.Skin.DockPaneStripSkin.ToolWindowGradient.ActiveCaptionGradient.EndColor = ColorTranslator.FromHtml("#03787C");
            // アクティブなツールウィンドウのキャプションテキストの色
            this.Skin.DockPaneStripSkin.ToolWindowGradient.ActiveCaptionGradient.TextColor = ColorTranslator.FromHtml("#C3C3C3");

            // --- 非アクティブなツールウィンドウのキャプションの色設定 ---
            // 非アクティブなツールウィンドウ（タブが選択されていないパネルのタイトルバー）のグラデーション開始色
            this.Skin.DockPaneStripSkin.ToolWindowGradient.InactiveCaptionGradient.StartColor = ColorTranslator.FromHtml("#2D2D30");
            // 非アクティブなツールウィンドウのキャプションのグラデーション終了色
            this.Skin.DockPaneStripSkin.ToolWindowGradient.InactiveCaptionGradient.EndColor = ColorTranslator.FromHtml("#2D2D30");
            // 非アクティブなツールウィンドウのキャプションテキストの色
            this.Skin.DockPaneStripSkin.ToolWindowGradient.InactiveCaptionGradient.TextColor = ColorTranslator.FromHtml("#A0A0A0");

            // --- AutoHideストリップの色設定 ---
            // これらは、AutoHide（自動的に隠れる）状態のパネルが表示される際に使われるストリップの背景色やタブの色に適用されます。
            // AutoHideタブのグラデーション開始色
            this.Skin.AutoHideStripSkin.TabGradient.StartColor = ColorTranslator.FromHtml("#000000");
            // AutoHideタブのグラデーション終了色
            this.Skin.AutoHideStripSkin.TabGradient.EndColor = ColorTranslator.FromHtml("#000000");
            // AutoHideタブのテキスト色
            this.Skin.AutoHideStripSkin.TabGradient.TextColor = ColorTranslator.FromHtml("#A0A0A0");
            // AutoHideドックストリップ（AutoHideされたウィンドウが表示される際のバー）のグラデーション開始色
            this.Skin.AutoHideStripSkin.DockStripGradient.StartColor = ColorTranslator.FromHtml("#000000");
            // AutoHideドックストリップのグラデーション終了色
            this.Skin.AutoHideStripSkin.DockStripGradient.EndColor = ColorTranslator.FromHtml("#000000");

            // --- ドックストリップ（ドッキング可能な領域）の色設定 ---
            // これらの色は、ドッキングされたペインが配置されるDockPanelの周辺のストリップに適用されます。
            // 例えば、ドキュメントタブ領域とツールウィンドウ領域の間の分割線や背景色に影響を与える可能性があります。
            this.Skin.DockPaneStripSkin.ToolWindowGradient.DockStripGradient.StartColor = Color.Green; // ドックストリップのグラデーション開始色を緑に設定
            this.Skin.DockPaneStripSkin.ToolWindowGradient.DockStripGradient.EndColor = Color.Red;   // ドックストリップのグラデーション終了色を赤に設定
            // これらの色はDockPanelの特定の部分の背景に影響を与える可能性がありますが、
            // 全体の視覚的な影響は他のスキン要素やレンダラーの実装によって変わります。
        }
    }
}
//---<<END OF FILE>>-----------------------------------------------------
