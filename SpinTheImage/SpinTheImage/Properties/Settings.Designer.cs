﻿//------------------------------------------------------------------------------
// <auto-generated>
//     このコードはツールによって生成されました。
//     ランタイム バージョン:4.0.30319.42000
//
//     このファイルへの変更は、以下の状況下で不正な動作の原因になったり、
//     コードが再生成されるときに損失したりします。
// </auto-generated>
//------------------------------------------------------------------------------

namespace SpinTheImage.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "15.8.0.0")]
    internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase {
        
        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));
        
        public static Settings Default {
            get {
                return defaultInstance;
            }
        }
        
        /// <summary>
        /// クライアントの初期位置
        /// </summary>
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Configuration.SettingsProviderAttribute(typeof(MisaCommon.Configurations.CustomUserConfig.UserSettingsProvider))]
        [global::System.Configuration.SettingsDescriptionAttribute("クライアントの初期位置")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("0, 17")]
        public global::System.Drawing.Point ClientLocation {
            get {
                return ((global::System.Drawing.Point)(this["ClientLocation"]));
            }
            set {
                this["ClientLocation"] = value;
            }
        }
        
        /// <summary>
        /// クライアントの初期サイズ
        /// </summary>
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Configuration.SettingsProviderAttribute(typeof(MisaCommon.Configurations.CustomUserConfig.UserSettingsProvider))]
        [global::System.Configuration.SettingsDescriptionAttribute("クライアントの初期サイズ")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("996, 777")]
        public global::System.Drawing.Size ClientSize {
            get {
                return ((global::System.Drawing.Size)(this["ClientSize"]));
            }
            set {
                this["ClientSize"] = value;
            }
        }
        
        /// <summary>
        /// メインメニューのPNGファイル出力有無のチェック有無
        /// </summary>
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Configuration.SettingsProviderAttribute(typeof(MisaCommon.Configurations.CustomUserConfig.UserSettingsProvider))]
        [global::System.Configuration.SettingsDescriptionAttribute("メインメニューのPNGファイル出力有無のチェック有無")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool MainFormMenuItemOutputPng {
            get {
                return ((bool)(this["MainFormMenuItemOutputPng"]));
            }
            set {
                this["MainFormMenuItemOutputPng"] = value;
            }
        }
        
        /// <summary>
        /// メインメニューの画像エリア背景‗白（黒とトリグ）のチェック有無
        /// </summary>
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Configuration.SettingsProviderAttribute(typeof(MisaCommon.Configurations.CustomUserConfig.UserSettingsProvider))]
        [global::System.Configuration.SettingsDescriptionAttribute("メインメニューの画像エリア背景‗白（黒とトリグ）のチェック有無")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("True")]
        public bool MainFormMenuItemOptionChangeBackgroundOfImageAreaWhite {
            get {
                return ((bool)(this["MainFormMenuItemOptionChangeBackgroundOfImageAreaWhite"]));
            }
            set {
                this["MainFormMenuItemOptionChangeBackgroundOfImageAreaWhite"] = value;
            }
        }
        
        /// <summary>
        /// メインメニューの画像エリア背景‗黒（白とトリグ）のチェック有無
        /// </summary>
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Configuration.SettingsProviderAttribute(typeof(MisaCommon.Configurations.CustomUserConfig.UserSettingsProvider))]
        [global::System.Configuration.SettingsDescriptionAttribute("メインメニューの画像エリア背景‗黒（白とトリグ）のチェック有無")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool MainFormMenuItemOptionChangeBackgroundOfImageAreaBlack {
            get {
                return ((bool)(this["MainFormMenuItemOptionChangeBackgroundOfImageAreaBlack"]));
            }
            set {
                this["MainFormMenuItemOptionChangeBackgroundOfImageAreaBlack"] = value;
            }
        }
        
        /// <summary>
        /// 左右を分けるスプリットの位置
        /// </summary>
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Configuration.SettingsProviderAttribute(typeof(MisaCommon.Configurations.CustomUserConfig.UserSettingsProvider))]
        [global::System.Configuration.SettingsDescriptionAttribute("左右を分けるスプリットの位置")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("561")]
        public int MainFormPlLeftWidth {
            get {
                return ((int)(this["MainFormPlLeftWidth"]));
            }
            set {
                this["MainFormPlLeftWidth"] = value;
            }
        }
        
        /// <summary>
        /// フレームレートの値
        /// </summary>
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Configuration.SettingsProviderAttribute(typeof(MisaCommon.Configurations.CustomUserConfig.UserSettingsProvider))]
        [global::System.Configuration.SettingsDescriptionAttribute("フレームレートの値")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("30")]
        public decimal MainFormTxtFrameRate {
            get {
                return ((decimal)(this["MainFormTxtFrameRate"]));
            }
            set {
                this["MainFormTxtFrameRate"] = value;
            }
        }
        
        /// <summary>
        /// 秒数の値
        /// </summary>
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Configuration.SettingsProviderAttribute(typeof(MisaCommon.Configurations.CustomUserConfig.UserSettingsProvider))]
        [global::System.Configuration.SettingsDescriptionAttribute("秒数の値")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("8")]
        public decimal MainFormTxtSecound {
            get {
                return ((decimal)(this["MainFormTxtSecound"]));
            }
            set {
                this["MainFormTxtSecound"] = value;
            }
        }
        
        /// <summary>
        /// 初速の値
        /// </summary>
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Configuration.SettingsProviderAttribute(typeof(MisaCommon.Configurations.CustomUserConfig.UserSettingsProvider))]
        [global::System.Configuration.SettingsDescriptionAttribute("初速の値")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("79")]
        public decimal MainFormTxtInitialSpeed {
            get {
                return ((decimal)(this["MainFormTxtInitialSpeed"]));
            }
            set {
                this["MainFormTxtInitialSpeed"] = value;
            }
        }
        
        /// <summary>
        /// 加速度の値
        /// </summary>
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Configuration.SettingsProviderAttribute(typeof(MisaCommon.Configurations.CustomUserConfig.UserSettingsProvider))]
        [global::System.Configuration.SettingsDescriptionAttribute("加速度の値")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("257")]
        public decimal MainFormTxtAcceleteRate {
            get {
                return ((decimal)(this["MainFormTxtAcceleteRate"]));
            }
            set {
                this["MainFormTxtAcceleteRate"] = value;
            }
        }
        
        /// <summary>
        /// 回転角度のリストパスの入力値
        /// </summary>
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Configuration.SettingsProviderAttribute(typeof(MisaCommon.Configurations.CustomUserConfig.UserSettingsProvider))]
        [global::System.Configuration.SettingsDescriptionAttribute("回転角度のリストパスの入力値")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string MainFormTxtRoteteParameterFile {
            get {
                return ((string)(this["MainFormTxtRoteteParameterFile"]));
            }
            set {
                this["MainFormTxtRoteteParameterFile"] = value;
            }
        }
        
        /// <summary>
        /// キャンパスの中心位置変更のチェック有無
        /// </summary>
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Configuration.SettingsProviderAttribute(typeof(MisaCommon.Configurations.CustomUserConfig.UserSettingsProvider))]
        [global::System.Configuration.SettingsDescriptionAttribute("キャンパスの中心位置変更のチェック有無")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool MainFormRdoChangeCanvasChkCenter {
            get {
                return ((bool)(this["MainFormRdoChangeCanvasChkCenter"]));
            }
            set {
                this["MainFormRdoChangeCanvasChkCenter"] = value;
            }
        }
        
        /// <summary>
        /// キャンパスの中心位置の変更位置_X
        /// </summary>
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Configuration.SettingsProviderAttribute(typeof(MisaCommon.Configurations.CustomUserConfig.UserSettingsProvider))]
        [global::System.Configuration.SettingsDescriptionAttribute("キャンパスの中心位置の変更位置_X")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("0")]
        public decimal MainFormRdoChangeCanvasChkCenterX {
            get {
                return ((decimal)(this["MainFormRdoChangeCanvasChkCenterX"]));
            }
            set {
                this["MainFormRdoChangeCanvasChkCenterX"] = value;
            }
        }
        
        /// <summary>
        /// キャンパスの中心位置の変更位置_Y
        /// </summary>
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Configuration.SettingsProviderAttribute(typeof(MisaCommon.Configurations.CustomUserConfig.UserSettingsProvider))]
        [global::System.Configuration.SettingsDescriptionAttribute("キャンパスの中心位置の変更位置_Y")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("0")]
        public decimal MainFormRdoChangeCanvasChkCenterY {
            get {
                return ((decimal)(this["MainFormRdoChangeCanvasChkCenterY"]));
            }
            set {
                this["MainFormRdoChangeCanvasChkCenterY"] = value;
            }
        }
        
        /// <summary>
        /// キャンパスサイズ拡大しないのチェック有無
        /// </summary>
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Configuration.SettingsProviderAttribute(typeof(MisaCommon.Configurations.CustomUserConfig.UserSettingsProvider))]
        [global::System.Configuration.SettingsDescriptionAttribute("キャンパスサイズ拡大しないのチェック有無")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("True")]
        public bool MainFormRdoChangeCanvasSizeNoChange {
            get {
                return ((bool)(this["MainFormRdoChangeCanvasSizeNoChange"]));
            }
            set {
                this["MainFormRdoChangeCanvasSizeNoChange"] = value;
            }
        }
        
        /// <summary>
        /// キャンパスサイズを対角線で拡大のチェック有無
        /// </summary>
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Configuration.SettingsProviderAttribute(typeof(MisaCommon.Configurations.CustomUserConfig.UserSettingsProvider))]
        [global::System.Configuration.SettingsDescriptionAttribute("キャンパスサイズを対角線で拡大のチェック有無")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool MainFormRdoChangeCanvasSizeDiagonalSize {
            get {
                return ((bool)(this["MainFormRdoChangeCanvasSizeDiagonalSize"]));
            }
            set {
                this["MainFormRdoChangeCanvasSizeDiagonalSize"] = value;
            }
        }
        
        /// <summary>
        /// キャンパスサイズを指定のサイズにするのチェック有無
        /// </summary>
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Configuration.SettingsProviderAttribute(typeof(MisaCommon.Configurations.CustomUserConfig.UserSettingsProvider))]
        [global::System.Configuration.SettingsDescriptionAttribute("キャンパスサイズを指定のサイズにするのチェック有無")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool MainFormRdoChangeCanvasSizeSelectSize {
            get {
                return ((bool)(this["MainFormRdoChangeCanvasSizeSelectSize"]));
            }
            set {
                this["MainFormRdoChangeCanvasSizeSelectSize"] = value;
            }
        }
        
        /// <summary>
        /// キャンパスサイズを指定のサイズにするの幅の値
        /// </summary>
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Configuration.SettingsProviderAttribute(typeof(MisaCommon.Configurations.CustomUserConfig.UserSettingsProvider))]
        [global::System.Configuration.SettingsDescriptionAttribute("キャンパスサイズを指定のサイズにするの幅の値")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("256")]
        public decimal MainFormTxtChangeCanvasSizeSelectSizeWidth {
            get {
                return ((decimal)(this["MainFormTxtChangeCanvasSizeSelectSizeWidth"]));
            }
            set {
                this["MainFormTxtChangeCanvasSizeSelectSizeWidth"] = value;
            }
        }
        
        /// <summary>
        /// キャンパスサイズを指定のサイズにするの高さの値
        /// </summary>
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Configuration.SettingsProviderAttribute(typeof(MisaCommon.Configurations.CustomUserConfig.UserSettingsProvider))]
        [global::System.Configuration.SettingsDescriptionAttribute("キャンパスサイズを指定のサイズにするの高さの値")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("256")]
        public decimal MainFormTxtChangeCanvasSizeSelectSizeHeight {
            get {
                return ((decimal)(this["MainFormTxtChangeCanvasSizeSelectSizeHeight"]));
            }
            set {
                this["MainFormTxtChangeCanvasSizeSelectSizeHeight"] = value;
            }
        }
        
        /// <summary>
        /// ループするかのチェック有無
        /// </summary>
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Configuration.SettingsProviderAttribute(typeof(MisaCommon.Configurations.CustomUserConfig.UserSettingsProvider))]
        [global::System.Configuration.SettingsDescriptionAttribute("ループするかのチェック有無")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool MainFormChkRoop {
            get {
                return ((bool)(this["MainFormChkRoop"]));
            }
            set {
                this["MainFormChkRoop"] = value;
            }
        }
        
        /// <summary>
        /// ループ回数の値
        /// </summary>
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Configuration.SettingsProviderAttribute(typeof(MisaCommon.Configurations.CustomUserConfig.UserSettingsProvider))]
        [global::System.Configuration.SettingsDescriptionAttribute("ループ回数の値")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("1")]
        public decimal MainFormTxtRoopCount {
            get {
                return ((decimal)(this["MainFormTxtRoopCount"]));
            }
            set {
                this["MainFormTxtRoopCount"] = value;
            }
        }
        
        /// <summary>
        /// ループを無限にするのチェック有無
        /// </summary>
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Configuration.SettingsProviderAttribute(typeof(MisaCommon.Configurations.CustomUserConfig.UserSettingsProvider))]
        [global::System.Configuration.SettingsDescriptionAttribute("ループを無限にするのチェック有無")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool MainFormChkRoopInfinite {
            get {
                return ((bool)(this["MainFormChkRoopInfinite"]));
            }
            set {
                this["MainFormChkRoopInfinite"] = value;
            }
        }
        
        /// <summary>
        /// 最後は元の画像の角度でおわるかのチェック有無
        /// </summary>
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Configuration.SettingsProviderAttribute(typeof(MisaCommon.Configurations.CustomUserConfig.UserSettingsProvider))]
        [global::System.Configuration.SettingsDescriptionAttribute("最後は元の画像の角度でおわるかのチェック有無")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("True")]
        public bool MainFormChkRotateToEnd {
            get {
                return ((bool)(this["MainFormChkRotateToEnd"]));
            }
            set {
                this["MainFormChkRotateToEnd"] = value;
            }
        }
    }
}
