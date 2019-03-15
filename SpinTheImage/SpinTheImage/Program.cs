namespace SpinTheImage
{
    using System;
    using System.Globalization;
    using System.Threading;
    using System.Windows.Forms;

    using MisaCommon.Modules;

    /// <summary>
    /// アプリケーションのメイン エントリ ポイント
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// アプリケーションのメイン エントリ ポイント
        /// </summary>
        [STAThread]
        public static void Main()
        {
            // アプリケーションの初期設定
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // アプリケーション起動
            CultureInfo culture = Thread.CurrentThread.CurrentUICulture;
            EntryPoint.ApplicationStart(() => new Forms.MainForm(), culture);
        }
    }
}
