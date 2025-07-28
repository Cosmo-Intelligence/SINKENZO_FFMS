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

namespace RADISTA.UIComponent.CustomControl
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
        private static string mFontType = Constants.DEFAULT_FONT_TYPE;
        private static int mFontSize = Constants.DEFAULT_FONT_SIZE;
        private static string mFontColor = Constants.DEFAULT_FONT_COLOR;
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
                    { "FontType", value => SetFontType(value, v => mFontType = v, "FontType setting is wrong") },
                    { "FontSize", value => SetIntValue(value, v => mFontSize = v, "FontSize setting is wrong") },
                    { "FontColor", value => SetColorValue(value, v => mFontColor = v, "FontColor setting is wrong") },
                    { "BackColor", value => SetColorValue(value, v => mBackColor = v, "BackColor setting is wrong") },
                    { "InactiveColor", value => SetColorValue(value, v => mInactiveColor = v, "InactiveColor setting is wrong") },
                    { "InputBackColor", value => SetColorValue(value, v => mInputBackColor = v, "InputBackColor setting is wrong") },
                    { "InputEdgeColor", value => SetColorValue(value, v => mInputEdgeColor = v, "InputEdgeColor setting is wrong") },
                    { "ComponentEdgeColor", value => SetColorValue(value, v => mComponentEdgeColor = v, "ComponentEdgeColor setting is wrong") },
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