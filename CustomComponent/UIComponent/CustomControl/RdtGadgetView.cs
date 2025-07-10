//-----------------------------------------------------------------------
// <copyright file="RdtGadgetView.cs" company="FUJIFILM Medical Solutions Corporation">
// Copyright (C) 2025 FUJIFILM Medical Solutions Corporation.
// </copyright>
//-----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using log4net;

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
    public partial class RdtGadgetView : DockContent
    {
        #region "定数"
        private const string GADGET = "ガジェット";
        private const string VIEW_NAME = "RdtGadgetView";
        #endregion

        #region "クラス変数"
        private static readonly ILog mLog = LogManager.GetLogger(typeof(RdtGadgetView));
        private string mViewName = VIEW_NAME;
        private DockState mDockPosition = DockState.Document;
        #endregion

        #region "プロパティ"
        /// <summary>
        /// コントロールの名称
        /// </summary>
        [Category(GADGET)]
        public string ViewName
        {
            get => this.mViewName;
            set
            {
                this.mViewName = value;
            }
        }

        /// <summary>
        /// ドッキングする位置
        /// </summary>
        [Category(GADGET)]
        public DockState DockPosition
        {
            get => this.mDockPosition;
            set
            {
                this.mDockPosition = value;
            }
        }
        #endregion

        #region "パブリックメソッド"
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public RdtGadgetView()
        {
            this.InitializeComponent();

            this.DockStateChanged -= this.ViewDockStateChanged;
            this.DockStateChanged += this.ViewDockStateChanged;
        }
        #endregion

        #region "プライベートメソッド"
        /// <summary>
        /// Viewのドッキング状態が変更されたときに呼び出されるイベントハンドラ
        /// AllowEndUserDocking プロパティのバグに対するワークアラウンドを提供
        /// </summary>
        private void ViewDockStateChanged(object? sender, EventArgs e)
        {
            // デバッグ出力: ドッキング状態の変更とAllowEndUserDockingの現在の値をログに記録します。
            System.Diagnostics.Debug.WriteLine($"--- Window1 DockStateChanged (Minimal Test) ---");
            System.Diagnostics.Debug.WriteLine($"New DockState: {this.DockState}");
            System.Diagnostics.Debug.WriteLine($"AllowEndUserDocking (at change): {this.AllowEndUserDocking}");
            System.Diagnostics.Debug.WriteLine($"IsFloat: {this.DockState == DockState.Float}");
            System.Diagnostics.Debug.WriteLine($"-----------------------------------------------");

            // ドッキング状態がFloat（フローティング状態）であり、かつAllowEndUserDockingがfalseに設定されている場合
            // （本来はフローティングを許可しないはずなのに、バグでフローティングしてしまった場合）
            if (this.DockState == DockState.Float && !this.AllowEndUserDocking)
            {
                // UIスレッドで操作を非同期的に実行するためにBeginInvokeを使用します。
                // DockStateChangedイベント内で直接DockStateを変更すると、デッドロックや意図しない動作を引き起こす可能性があります。
                this.BeginInvoke(new MethodInvoker(() =>
                {
                    // DockPanelが有効な場合にのみ処理を実行します。
                    if (this.DockPanel != null)
                    {
                        // ウィンドウを強制的に左側にドッキングされた状態に戻します。
                        // これが、ユーザーがアンチドックしようとしたときに、ウィンドウが元の位置に「スナップバック」する挙動を生み出します。
                        this.DockState = DockState.DockLeft;
                    }
                }));
            }
        }
        #endregion
    }
}
//---<<END OF FILE>>-----------------------------------------------------