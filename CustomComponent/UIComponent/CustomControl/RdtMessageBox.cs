//-----------------------------------------------------------------------
// <copyright file="RdtMessageBox.cs" company="FUJIFILM Medical Solutions Corporation">
// Copyright (C) 2025 FUJIFILM Medical Solutions Corporation.
// </copyright>
//-----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RADISTA.UIComponent.CustomControl
{
    /// <summary>
    /// RdtMessageBoxクラス
    /// </summary>
    /// <remarks>
    /// 
    /// (Rev.)        (Date)      (ID / NAME)                     (Comment)
    /// V1.00.00    : 2025.07.09    : 株式会社コスモ・インテリジェンス / 笠間可奈子   : original
    ///
    /// </remarks>
    public partial class RdtMessageBox : RdtForm
    {
        #region "列挙型"
        /// <summary>
        /// メッセージスタイル
        /// </summary>
        public enum IconStyleT
        {
            /// <summary>
            /// 情報
            /// </summary>
            Information,
            /// <summary>
            /// 質問
            /// </summary>
            Warning,
            /// <summary>
            /// 注意
            /// </summary>
            Error,
            /// <summary>
            /// 警告
            /// </summary>
            Question,
        }

        /// <summary>
        /// ボタンタイプ
        /// </summary>
        public enum ButtonTypeT
        {
            /// <summary>
            /// 表示しない
            /// </summary>
            None,
            /// <summary>
            /// OK
            /// </summary>
            OK,
            /// <summary>
            /// OKCancel
            /// </summary>
            OKCancel,
            /// <summary>
            /// YesNoCancel
            /// </summary>
            YesNoCancel,
            /// <summary>
            /// YesNo
            /// </summary>
            YesNo,
        }

        /// <summary>
        /// Position指定タイプ
        /// </summary>
        public enum PositionModeT
        {
            /// <summary>
            /// 組み合わせ
            /// </summary>
            Combination,
            /// <summary>
            /// 絶対座標
            /// </summary>
            Absolute,
            /// <summary>
            /// 相対座標
            /// </summary>
            Relative,
        }

        /// <summary>
        /// 表示位置（X軸）
        /// </summary>
        public enum HorizontalAlign
        {
            /// <summary>
            /// 左
            /// </summary>
            Left,
            /// <summary>
            /// 中央
            /// </summary>
            Center,
            /// <summary>
            /// 右
            /// </summary>
            Right,
        }

        /// <summary>
        /// 表示位置（Y軸）
        /// </summary>
        public enum VerticalAlign
        {
            /// <summary>
            /// 上
            /// </summary>
            Top,
            /// <summary>
            /// 中央
            /// </summary>
            Center,
            /// <summary>
            /// 下
            /// </summary>
            Bottom,
        }
        #endregion

        #region "定数"
        private const string ICON_STYLE = "アイコンスタイル";
        private const string BUTTON_TYPE = "ボタンタイプ";
        private const string MESSAGE = "メッセージ内容";
        private const string POSITION = "表示位置";
        private const string AUTO_CLOSE = "自動クローズ";
        private const int MS_MIN = 0;
        private const int ICON_SIZE = 48;                  // アイコンのサイズ
        private const int RIGHT_MARGIN = 20;                // 右側マージン
        private const int LABEL_TOP_MARGIN = 30;            // ラベルの上マージン
        private const int BOTTOM_PANEL_HEIGHT = 60;         // 下部ボタンパネルの高さ
        private const int BOTTOM_MARGIN = 10;               // 下マージン
        private const int LABEL_PADDING = 10;               // ラベル内パディング 左右下
        private const int BUTTON_HEIGHT = 30;               // ボタン高さ
        private const int BUTTON_MARGIN = 10;               // ボタンマージン
        #endregion

        #region"クラス変数"
        private IconStyleT mIconStyle = IconStyleT.Information;
        private ButtonTypeT mButtonType = ButtonTypeT.None;
        private string mMessage = string.Empty;
        private System.Windows.Forms.Timer? mCloseTimer;
        private int mAutoCloseMs = 0;
        private PictureBox? mIconBox;
        private FlowLayoutPanel? mButtonPanel;
        private Label? mMessageLabel;
        private PositionModeT mPositionMode = PositionModeT.Combination;
        private HorizontalAlign mHorizontalAlign = HorizontalAlign.Left;
        private VerticalAlign mVerticalAlign = VerticalAlign.Top;
        #endregion

        #region "プロパティ"
        /// <summary>
        /// 表示メッセージ
        /// </summary>
        [Category(MESSAGE)]
        public string Message
        {
            get => this.mMessage;
            set
            {
                this.mMessage = value;
            }
        }

        /// <summary>
        /// 表示アイコン
        /// </summary>
        [Category(ICON_STYLE)]
        public IconStyleT IconStyle
        {
            get => this.mIconStyle;
            set
            {
                this.mIconStyle = value;
                if (this.mIconBox != null)
                {
                    this.mIconBox.Image = this.GetSystemIcon(this.mIconStyle);
                }
            }
        }

        /// <summary>
        /// 表示ボタン種類
        /// </summary>
        [Category(BUTTON_TYPE)]
        public ButtonTypeT ButtonType
        {
            get => this.mButtonType;
            set
            {
                this.mButtonType = value;
                if (this.mButtonPanel != null)
                {
                    this.SetDialogButtons(); //単体テスト用
                }
            }
        }

        /// <summary>
        /// Position指定タイプ
        /// </summary>
        [Category(POSITION)]
        public PositionModeT PositionMode
        {
            get => this.mPositionMode;
            set
            {
                this.mPositionMode = value;
            }
        }

        /// <summary>
        /// 表示位置：X座標
        /// </summary>
        [Category(POSITION)]
        public HorizontalAlign MessagePosition_HorizontalAlign
        {
            get => this.mHorizontalAlign;
            set
            {
                this.mHorizontalAlign = value;
                if (!this.IsInDesignMode())
                {
                    this.UpdateMessageBoxLocation(); // 単体テスト用
                }
            }
        }

        /// <summary>
        /// 表示位置：Y座標
        /// </summary>
        [Category(POSITION)]
        public VerticalAlign MessagePosition_VerticalAlign
        {
            get => this.mVerticalAlign;
            set
            {
                this.mVerticalAlign = value;
                if (!this.IsInDesignMode())
                {
                    this.UpdateMessageBoxLocation(); // 単体テスト用
                }
            }
        }

        /// <summary>
        /// 絶対座標
        /// </summary>
        [Category(POSITION)]
        public Point MessagePosition_Absolute { get; set; } = new Point(0, 0);

        /// <summary>
        /// 相対座標
        /// </summary>
        [Category(POSITION)]
        public Point MessagePosition_Relative { get; set; } = new Point(0, 0);

        /// <summary>
        /// 絶対座標(X,Y)
        /// </summary>
        public Point MessageOffset { get; set; } = Point.Empty;

        /// <summary>
        /// メッセージ表示時間(ミリ秒)
        /// </summary>
        [Category(AUTO_CLOSE)]
        public int AutoCloseMs
        {
            get => this.mAutoCloseMs;
            set
            {
                int newValue = Math.Max(MS_MIN, value);
                if (this.mAutoCloseMs != newValue)
                {
                    this.mAutoCloseMs = newValue;
                }
            }
        }
        #endregion

        #region "パブリックメソッド"
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public RdtMessageBox()
        {
            this.InitializeComponent();
            this.InitializeCustomSetting();
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="container">コンテナ</param>
        public RdtMessageBox(IContainer container)
        {
            container?.Add(this);
            this.InitializeComponent();
            this.InitializeCustomSetting();
        }

        /// <summary>
        /// 押下ボタンの戻り値
        /// </summary>
        public DialogResult Result { get; private set; }
        #endregion

        #region "プロテクティッドメソッド"
        /// <summary>
        /// コンストラクタ
        /// </summary>
        protected override void OnCreateControl()
        {
            base.OnCreateControl();

            this.CustomMessageBox();
        }

        /// <summary>
        /// OnLoad
        /// </summary>
        /// <param name="e">e</param>
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            // StartPosition を強制的に Manual に設定
            this.StartPosition = FormStartPosition.Manual;

            // Owner が未設定なら、ActiveForm を使って自動的に設定
            if (this.Owner == null && Form.ActiveForm != this)
            {
                this.Owner = Form.ActiveForm;
            }
        }

        /// <summary>
        /// 画面表示位置を設定
        /// </summary>
        private void UpdateMessageBoxLocation()
        {
            if (!this.IsInDesignMode())
            {
                if (this.Owner != null)
                {
                    var ownerRect = this.Owner.Bounds;

                    switch (this.mPositionMode)
                    {
                        // 組み合わせで指定の場合
                        case PositionModeT.Combination:
                            {
                                int x = ownerRect.Left;
                                int y = ownerRect.Top;

                                // 横位置
                                switch (this.mHorizontalAlign)
                                {
                                    case HorizontalAlign.Left:
                                        x += this.MessageOffset.X;
                                        break;
                                    case HorizontalAlign.Center:
                                        x += ((ownerRect.Width - this.Width) / 2) + this.MessageOffset.X;
                                        break;
                                    case HorizontalAlign.Right:
                                        x += ownerRect.Width - this.Width + this.MessageOffset.X;
                                        break;
                                }

                                // 縦位置
                                switch (this.mVerticalAlign)
                                {
                                    case VerticalAlign.Top:
                                        y += this.MessageOffset.Y;
                                        break;
                                    case VerticalAlign.Center:
                                        y += ((ownerRect.Height - this.Height) / 2) + this.MessageOffset.Y;
                                        break;
                                    case VerticalAlign.Bottom:
                                        y += ownerRect.Height - this.Height + this.MessageOffset.Y;
                                        break;
                                }
                                // 座標確定
                                this.Location = new Point(x, y);
                                break;
                            }

                        // 絶対座標で指定の場合
                        case PositionModeT.Absolute:
                            this.Location = this.MessagePosition_Absolute;
                            break;

                        // 相対座標で指定の場合
                        case PositionModeT.Relative:
                            this.Location = new Point(
                                ownerRect.Left + this.MessagePosition_Relative.X,
                                ownerRect.Top + this.MessagePosition_Relative.Y);
                            break;
                    }
                }
                // 自動クローズ処理
                this.StartAutoCloseTimer();
            }
        }

        /// <summary>
        /// OnShown
        /// </summary>
        /// <param name="e">e</param>
        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            if (!this.IsInDesignMode())
            {
                this.UpdateMessageBoxLocation();
            }
        }
        #endregion

        #region "プライベートメソッド"
        /// <summary>
        /// コンストラクタ共通処理
        /// </summary>
        private void InitializeCustomSetting()
        {
            if (this.IsInDesignMode())
            {
                return;
            }
            // デフォルト設定
            this.Font = new Font(ComponentCommon.GetFontType(), ComponentCommon.GetFontSize());
            this.ForeColor = this.Enabled
                ? ColorTranslator.FromHtml(ComponentCommon.GetFontColor())
                : ColorTranslator.FromHtml(ComponentCommon.GetInactiveColor());
            this.BackColor = ColorTranslator.FromHtml(ComponentCommon.GetBackColor());
        }

        /// <summary>
        /// メッセージボックスのカスタマイズ
        /// </summary>
        private void CustomMessageBox()
        {
            if (this.IsInDesignMode())
            {
                return;
            }
            // アイコン画像の表示用PictureBoxを作成
            this.mIconBox = new PictureBox
            {
                Size = new Size(ICON_SIZE, ICON_SIZE),
                Location = new Point(RIGHT_MARGIN, 40),
                SizeMode = PictureBoxSizeMode.StretchImage,
            };

            // アイコンスタイルに応じてシステムアイコンを設定
            this.mIconBox.Image = this.GetSystemIcon(this.mIconStyle);

            // メッセージ表示用のLabelを作成
            int labelLeft = RIGHT_MARGIN + ICON_SIZE + LABEL_PADDING;

            this.mMessageLabel = new Label()
            {
                // 改行コードを置き換え
                Text = this.GetDisplayMessage(),
                UseCompatibleTextRendering = true,
                Location = new Point(labelLeft, LABEL_TOP_MARGIN),
                AutoSize = false,
                TextAlign = ContentAlignment.TopLeft,
                ForeColor = this.ForeColor,
                Font = this.Font,
                Padding = new Padding(LABEL_PADDING, LABEL_PADDING + 5, LABEL_PADDING, LABEL_PADDING),
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom,
            };

            // 初期サイズ（ClientSize 使用）
            this.mMessageLabel.Width = this.ClientSize.Width - labelLeft - RIGHT_MARGIN;
            this.mMessageLabel.Height = this.ClientSize.Height - LABEL_TOP_MARGIN - BOTTOM_PANEL_HEIGHT - BOTTOM_MARGIN;

            // ボタン配置用のPanelを作成（下部に配置）
            this.mButtonPanel = new FlowLayoutPanel()
            {
                Dock = DockStyle.Bottom,
                FlowDirection = FlowDirection.RightToLeft,
                Padding = new Padding(BUTTON_MARGIN),
                Height = BOTTOM_PANEL_HEIGHT,
                ForeColor = this.ForeColor,
                Font = this.Font,
            };

            // ボタン種別に応じてボタンを追加
            if (this.mButtonPanel != null)
            {
                this.SetDialogButtons();
            }

            // 各コントロールをフォームに追加
            this.Controls.Add(this.mIconBox);
            this.Controls.Add(this.mMessageLabel);
            this.Controls.Add(this.mButtonPanel);

            // フォームのサイズに応じてメッセージ表示ラベルのサイズを調節
            this.Resize += (s, e) =>
            {
                if (this.mMessageLabel != null)
                {
                    this.mMessageLabel.Width = this.ClientSize.Width - this.mMessageLabel.Left - RIGHT_MARGIN;
                    this.mMessageLabel.Height = this.ClientSize.Height - this.mMessageLabel.Top - BOTTOM_PANEL_HEIGHT - LABEL_PADDING;
                }
            };
        }

        /// <summary>
        /// 指定されたテキストとDialogResultを持つボタンを生成
        /// </summary>
        private Button CreateDialogButton(string text, DialogResult dialogResult)
        {
            var btn = new Button()
            {
                Text = text,
                DialogResult = dialogResult,
                Width = 80,
                Height = BUTTON_HEIGHT,
                Margin = new Padding(BUTTON_MARGIN),
            };
            btn.Click += (s, e) =>
            {
                this.Result = dialogResult;
                this.Close();
            };
            return btn;
        }

        /// <summary>
        /// 指定されたアイコンスタイルに対応するシステムアイコンを取得
        /// </summary>
        private Image? GetSystemIcon(IconStyleT style)
        {
            return style switch
            {
                IconStyleT.Information => SystemIcons.Information.ToBitmap(),
                IconStyleT.Warning => SystemIcons.Warning.ToBitmap(),
                IconStyleT.Error => SystemIcons.Error.ToBitmap(),
                IconStyleT.Question => SystemIcons.Question.ToBitmap(),
                _ => null
            };
        }

        /// <summary>
        /// デザイナー判定
        /// （デザイナー上で自動クローズの処理が実行されることを防ぐ）
        /// </summary>
        /// <returns>判定結果</returns>
        private bool IsInDesignMode()
        {
            return (this.Site?.DesignMode ?? false)
                || LicenseManager.UsageMode == LicenseUsageMode.Designtime
                || System.Diagnostics.Process.GetCurrentProcess().ProcessName.ToLower().Contains("devenv");
        }

        /// <summary>
        /// ダイアログボタンの生成
        /// </summary>
        private void SetDialogButtons()
        {
            this.mButtonPanel?.Controls.Clear();

            switch (this.mButtonType)
            {
                case ButtonTypeT.OK:
                    this.mButtonPanel!.Controls.Add(this.CreateDialogButton("OK", DialogResult.OK));
                    this.AcceptButton = this.mButtonPanel.Controls[0] as Button;
                    break;
                case ButtonTypeT.OKCancel:
                    this.mButtonPanel!.Controls.Add(this.CreateDialogButton("Cancel", DialogResult.Cancel));
                    this.mButtonPanel.Controls.Add(this.CreateDialogButton("OK", DialogResult.OK));
                    this.AcceptButton = this.mButtonPanel.Controls[1] as Button;
                    this.CancelButton = this.mButtonPanel.Controls[0] as Button;
                    break;
                case ButtonTypeT.YesNo:
                    this.mButtonPanel!.Controls.Add(this.CreateDialogButton("No", DialogResult.No));
                    this.mButtonPanel.Controls.Add(this.CreateDialogButton("Yes", DialogResult.Yes));
                    this.AcceptButton = this.mButtonPanel.Controls[1] as Button;
                    this.CancelButton = this.mButtonPanel.Controls[0] as Button;
                    break;
                case ButtonTypeT.YesNoCancel:
                    this.mButtonPanel!.Controls.Add(this.CreateDialogButton("Cancel", DialogResult.Cancel));
                    this.mButtonPanel.Controls.Add(this.CreateDialogButton("No", DialogResult.No));
                    this.mButtonPanel.Controls.Add(this.CreateDialogButton("Yes", DialogResult.Yes));
                    this.AcceptButton = this.mButtonPanel.Controls[2] as Button;
                    this.CancelButton = this.mButtonPanel.Controls[0] as Button;
                    break;
                case ButtonTypeT.None:
                default:
                    break;
            }
        }

        /// <summary>
        /// 自動クローズタイマー開始
        /// </summary>
        private void StartAutoCloseTimer()
        {
            this.StopAutoCloseTimer();

            // 自動クローズ場合
            if (this.mAutoCloseMs > 0)
            {
                // 自動クローズのためのタイマー設定
                this.mCloseTimer = new System.Windows.Forms.Timer
                {
                    Interval = this.mAutoCloseMs,
                };
                this.mCloseTimer.Tick += (s, e) =>
                {
                    this.StopAutoCloseTimer();
                    this.DialogResult = DialogResult.None;
                    this.Close();
                };
                this.mCloseTimer.Start();
            }
        }

        /// <summary>
        /// 自動クローズ停止
        /// </summary>
        private void StopAutoCloseTimer()
        {
            if (this.mCloseTimer != null)
            {
                this.mCloseTimer.Stop();
                this.mCloseTimer.Dispose();
                this.mCloseTimer = null;
            }
        }

        /// <summary>
        /// メッセージの改行コードを変換
        /// </summary>
        /// <returns>改行メッセージ</returns>
        private string GetDisplayMessage() => this.mMessage?.Replace("\\n", Environment.NewLine) ?? string.Empty;

        #endregion
    }
}
//---<<END OF FILE>>-----------------------------------------------------