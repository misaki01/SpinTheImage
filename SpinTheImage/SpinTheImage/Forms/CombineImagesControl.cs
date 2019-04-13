namespace SpinTheImage.Forms
{
    using System;
    using System.Drawing;
    using System.IO;
    using System.Linq;
    using System.Security;
    using System.Threading.Tasks;
    using System.Windows.Forms;

    using MisaCommon.Exceptions;
    using MisaCommon.Modules;
    using MisaCommon.Utility.StaticMethod;

    using SpinTheImage.Properties;

    using MessageBox = MisaCommon.Utility.StaticMethod.MessageBox;

    /// <summary>
    /// 画像データをGif形式に連結するためのユーザコントロール
    /// </summary>
    public partial class CombineImagesControl : UserControl
    {
        #region クラス変数・定数

        /// <summary>
        /// 追記元のGifを選択するテキストファイルのドラッグ＆ドロップにおいて許可する拡張子
        /// （カンマ区切り）
        /// </summary>
        private const string AllowExtensionGif = ".gif";

        /// <summary>
        /// 画像データ格納フォルダを選択するテキストボックスの初期値を保持する領域
        /// （「フォルダ選択 又は ドラッグ＆ドロップ」という文言を保持）
        /// </summary>
        private readonly string initializeImageDirectoryText;

        /// <summary>
        /// 追記元のGifを選択するテキストボックスの初期値を保持する領域
        /// （「ファイル選択 又は ドラッグ＆ドロップ」という文言を保持）
        /// </summary>
        private readonly string initializeAppendGifText;

        #endregion

        #region コンストラクタ

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public CombineImagesControl()
        {
            // デザイナで生成された設定を行う
            InitializeComponent();

            // 追記元のGifを選択するテキストボックス 及び、
            // 画像データ格納フォルダを選択するテキストボックスの初期値を取得し保持
            // （値はInitializeComponent()で設定され、
            //   その後コンフィグに値に上書きされるためここで処理を行う必要あり）
            initializeImageDirectoryText = TxtImageDirectory.Text;
            initializeAppendGifText = TxtAppendGif.Text;

            // 初期状態では実行エリアは使用不可とする
            PlRun.Enabled = false;

            // コントロールの表示設定
            SetControlDisplaySetting();
        }

        #endregion

        #region プロパティ

        /// <summary>
        /// 実行中かどうかをしますフラグを取得・設定する
        /// </summary>
        public bool IsRuning { get; set; } = false;

        /// <summary>
        /// 中断フラグ
        /// 処理を途中で中断する場合は：True、中断しない場合は：False
        /// </summary>
        private static bool IsStop { get; set; } = true;

        #endregion

        #region static メソッド

        #region ドラッグ＆ドロップ関連のメソッド

        /// <summary>
        /// ドラッグされたデータが単一のフォルダか判定する
        /// </summary>
        /// <param name="inputData">
        /// ドラッグされたデータオブジェクト
        /// </param>
        /// <param name="path">
        /// チェックOKの場合：ドラッグされたデータのパスを返却、
        /// チェックNGの場合：NULLを返却
        /// </param>
        /// <returns>判定結果</returns>
        private static bool IsSingleFolder(IDataObject inputData, out string path)
        {
            // 単一か判定
            if (!IsSingle(inputData, out string tmpPath))
            {
                path = null;
                return false;
            }

            // フォルダかチェック
            if (!Directory.Exists(tmpPath))
            {
                path = null;
                return false;
            }

            // 全てのチェックを通過したためTrueをかえす
            path = tmpPath;
            return true;
        }

        /// <summary>
        /// ドラッグされたデータが単一のGifファイルか判定する
        /// </summary>
        /// <param name="inputData">
        /// ドラッグされたデータオブジェクト
        /// </param>
        /// <param name="allowExtensionGif">
        /// Gifファイルのドラッグ＆ドロップにおいて許可する拡張子（カンマ区切り）
        /// </param>
        /// <returns>判定結果</returns>
        private static bool IsSingleGifFile(IDataObject inputData, string allowExtensionGif)
        {
            // 単一か判定
            if (!IsSingle(inputData, out string path))
            {
                return false;
            }

            // 拡張子チェック
            string extension = Path.GetExtension(path).ToUpperInvariant();
            if (!allowExtensionGif.Split(',').Any(allowExtension
                => allowExtension.ToUpperInvariant().Equals(extension, StringComparison.Ordinal)))
            {
                return false;
            }

            // 全てのチェックを通過したためTrueをかえす
            return true;
        }

        /// <summary>
        /// ドラッグされたデータが単一か判定する
        /// </summary>
        /// <param name="inputData">ドラッグされたデータオブジェクト</param>
        /// <param name="path">OK：ドラッグされたデータのパスを返却、NG：NULLを返却</param>
        /// <returns>判定結果</returns>
        private static bool IsSingle(IDataObject inputData, out string path)
        {
            // ドラッグされたデータのパス取得（0の場合、複数の場合もある）
            string[] filePaths = GetDropPaths(inputData);

            // 単一か判定
            if (filePaths.Length != 1)
            {
                // 複数の場合、パスはNULL、結果はFalseを返す
                path = null;
                return false;
            }

            // 全てのチェックを通過したため、対象のファイルのパス、結果はTrueを返却
            path = filePaths[0];
            return true;
        }

        /// <summary>
        /// ドラッグされたデータのパスのリストを取得する
        /// </summary>
        /// <param name="inputData">ドラッグされたデータオブジェクト</param>
        /// <returns>
        /// 取得したパスのリスト
        /// ・取得できない場合（ファイル／ディレクトリでない場合等）は大きさ0のリストで返す
        /// </returns>
        private static string[] GetDropPaths(IDataObject inputData)
        {
            // ファイル形式のデータか判定
            if (!inputData.GetDataPresent(DataFormats.FileDrop))
            {
                // ファイルで無い場合は大きさ0のリストで返す
                return new string[0];
            }

            // 入力データからファイルパスを取得し返す
            return (string[])inputData.GetData(DataFormats.FileDrop);
        }

        #endregion

        #endregion

        #region イベント

        #region  画像データ格納フォルダ選択エリアのイベント

        /// <summary>
        /// 画像データ格納フォルダ選択エリアのドラッグEnterイベント
        /// </summary>
        /// <param name="sender">センダーオブジェクト</param>
        /// <param name="e">イベントデータ</param>
        private void ImageDirectory_DragEnter(object sender, DragEventArgs e)
        {
            // ドラッグされているデータが単一のフォルダかチェック
            bool checkResult = IsSingleFolder(e.Data, out string path);

            // ドラッグされているフォルダに画像データが存在するかチェック
            if (checkResult)
            {
                try
                {
                    checkResult = Directory.GetFiles(path).Any(filePath
                        => ImageTransform.CanImageLoad(filePath));
                }
                catch (Exception ex)
                    when (ex is UnauthorizedAccessException
                        || ex is IOException)
                {
                    // 下記の例外が発生した場合はチェック：NGにする
                    // UnauthorizedAccessException
                    // ・呼び出し元に、必要なアクセス許可がない場合
                    // IOException
                    // ・IOエラーが発生した場合
                    checkResult = false;
                }
            }

            // チェックが正常の場合ドロップを受け入れる
            e.Effect = checkResult ? DragDropEffects.Move : DragDropEffects.None;
        }

        /// <summary>
        /// 画像データ格納フォルダ選択エリアのドラッグ＆ドロップイベント
        /// </summary>
        /// <param name="sender">センダーオブジェクト</param>
        /// <param name="e">イベントデータ</param>
        private void ImageDirectory_DragDrop(object sender, DragEventArgs e)
        {
            // ドロップされたフォルダパスを設定
            TxtImageDirectory.Text = GetDropPaths(e.Data)[0];

            // 実行エリアを使用可能とする
            PlRun.Enabled = true;

            // 画面の表示設定を行う
            SetControlDisplaySetting();
        }

        /// <summary>
        /// 画像データ格納フォルダ選択の選択ボタンを押下
        /// </summary>
        /// <param name="sender">センダーオブジェクト</param>
        /// <param name="e">イベントデータ</param>
        private void BtImageDirectorySelect_Click(object sender, EventArgs e)
        {
            // フォルダ選択ダイアログを開き、画像データが格納してあるフォルダを選択する
            FolderBrowserDialog dialog;
            using (dialog = new FolderBrowserDialog())
            {
                dialog.Description = Resources.CombineImagesDirectorySelectDialogTitle;
                dialog.ShowNewFolderButton = false;
                if (Directory.Exists(TxtImageDirectory.Text))
                {
                    dialog.SelectedPath = TxtImageDirectory.Text;
                }

                // ダイアログを表示
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    // フォルダ選択でOKが押された場合、選択したファイルパスを取得
                    string folderPath = dialog.SelectedPath;

                    // 選択されたフォルダに画像データが存在するかチェック
                    try
                    {
                        if (Directory.GetFiles(folderPath).Any(filePath
                            => ImageTransform.CanImageLoad(filePath)))
                        {
                            // チェックOKの場合、選択したフォルダのパスを設定する
                            TxtImageDirectory.Text = folderPath;

                            // 実行エリアを使用可能とする
                            PlRun.Enabled = true;
                        }
                        else
                        {
                            // チェックNGの場合、エラーメッセージを表示する
                            MessageBox.ShowAttention(this, Resources.CombineImagesDirectoryErrorNotImage);
                        }
                    }
                    catch (Exception ex)
                        when (ex is UnauthorizedAccessException
                            || ex is IOException)
                    {
                        // 下記の例外が発生した場合はメッセージを表示する
                        // UnauthorizedAccessException
                        // ・呼び出し元に、必要なアクセス許可がない場合
                        // IOException
                        // ・IOエラーが発生した場合
                        string message = Resources.CombineImagesDirectoryErrorNotAccess
                            + "\r\n" + ex.Message;
                        MessageBox.ShowAttention(this, message);
                    }
                }
            }

            // 画面の表示設定を行う
            SetControlDisplaySetting();
        }

        /// <summary>
        /// 画像データ格納フォルダ選択のクリアボタンを押下
        /// </summary>
        /// <param name="sender">センダーオブジェクト</param>
        /// <param name="e">イベントデータ</param>
        private void BtImageDirectoryClear_Click(object sender, EventArgs e)
        {
            // テキストボックスをデフォルトの値に戻す
            PlImageDirectory.Text = initializeImageDirectoryText;

            // 実行エリアを使用不可とする
            PlRun.Enabled = false;

            // 画面の表示設定を行う
            SetControlDisplaySetting();
        }

        #endregion

        #region 追記元Gifの選択エリアのイベント

        /// <summary>
        /// 追記元Gifの選択エリアのドラッグEnterイベント
        /// </summary>
        /// <param name="sender">センダーオブジェクト</param>
        /// <param name="e">イベントデータ</param>
        private void AppendGif_DragEnter(object sender, DragEventArgs e)
        {
            // ドラッグされているデータが単一のGifファイルかチェック
            bool checkResult = IsSingleGifFile(e.Data, AllowExtensionGif);

            // チェックが正常の場合ドロップを受け入れる
            e.Effect = checkResult ? DragDropEffects.Move : DragDropEffects.None;
        }

        /// <summary>
        /// 追記元Gifの選択エリアのドラッグ＆ドロップイベント
        /// </summary>
        /// <param name="sender">センダーオブジェクト</param>
        /// <param name="e">イベントデータ</param>
        private void AppendGif_DragDrop(object sender, DragEventArgs e)
        {
            // ドロップされたGifファイルのパスを設定
            TxtAppendGif.Text = GetDropPaths(e.Data)[0];

            // 画面の表示設定を行う
            SetControlDisplaySetting();
        }

        /// <summary>
        /// 追記元Gifの選択の選択ボタンを押下
        /// </summary>
        /// <param name="sender">センダーオブジェクト</param>
        /// <param name="e">イベントデータ</param>
        private void BtAppendGifFileSelect_Click(object sender, EventArgs e)
        {
            // ファイル選択ダイアログを開き、回転パラメータファイルを選択する
            OpenFileDialog dialog;
            using (dialog = new OpenFileDialog())
            {
                // ファイル選択ダイアログの表示設定
                dialog.Title = Resources.CombineImagesGifFileSelectDialogTitle;
                dialog.Filter = Resources.CombineImagesGifFileSelectDialogFilter;
                dialog.FilterIndex = 1;
                dialog.RestoreDirectory = true;

                // ダイアログを表示
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    // ファイル選択でOKが押された場合、選択したファイルパスを取得
                    string filePath = dialog.FileName;

                    // 選択されたのがGifファイルかチェック
                    string extension = Path.GetExtension(filePath).ToUpperInvariant();
                    if (!AllowExtensionGif.Split(',').Any(allowExtension
                        => allowExtension.ToUpperInvariant().Equals(extension, StringComparison.Ordinal)))
                    {
                        // チェックOKの場合、選択したファイルのパスを設定する
                        TxtAppendGif.Text = filePath;
                    }
                    else
                    {
                        // チェックNGの場合、エラーメッセージを表示する
                        MessageBox.ShowAttention(this, Resources.CombineImagesGifFileErrorNotGif);
                    }
                }
            }

            // 画面の表示設定を行う
            SetControlDisplaySetting();
        }

        /// <summary>
        /// 追記元Gifの選択のクリアボタンを押下
        /// </summary>
        /// <param name="sender">センダーオブジェクト</param>
        /// <param name="e">イベントデータ</param>
        private void BtAppendGifClear_Click(object sender, EventArgs e)
        {
            // テキストボックスをデフォルトの値に戻す
            TxtAppendGif.Text = initializeAppendGifText;

            // 画面の表示設定を行う
            SetControlDisplaySetting();
        }

        #endregion

        #region ループの設定エリアのイベント

        /// <summary>
        /// ループするかのチェックボックスのチェックを変更
        /// </summary>
        /// <param name="sender">センダーオブジェクト</param>
        /// <param name="e">イベントデータ</param>
        private void ChkRoop_CheckedChanged(object sender, EventArgs e)
        {
            // 画面の表示設定を行う
            SetControlDisplaySetting();
        }

        /// <summary>
        /// 無限回ループするかのチェックボックスのチェックを変更
        /// </summary>
        /// <param name="sender">センダーオブジェクト</param>
        /// <param name="e">イベントデータ</param>
        private void ChkRoopInfinite_CheckedChanged(object sender, EventArgs e)
        {
            // 画面の表示設定を行う
            SetControlDisplaySetting();
        }

        #endregion

        #region 実行エリアのイベント

        /// <summary>
        /// 実行ボタン押下
        /// </summary>
        /// <param name="sender">センダーオブジェクト</param>
        /// <param name="e">イベントデータ</param>
        private async void BtRun_Click(object sender, EventArgs e)
        {
            // プログレスバーをリセット
            ProgressBarCreateGif.Value = 0;

            // 画像データ格納フォルダが選択されているかチェック
            string imageDirectory = TxtImageDirectory.Text;
            if (string.IsNullOrWhiteSpace(imageDirectory)
                || imageDirectory.Equals(initializeImageDirectoryText, StringComparison.Ordinal))
            {
                // フォルダが選択されていない場合は、メッセージを表示し処理をしない
                MessageBox.ShowAttention(this, Resources.CombineImagesDirectoryNotSelect);
                return;
            }

            // 画像データ格納フォルダに格納されている画像データのパスリストを取得する
            string[] filePaths = Directory.GetFiles(TxtImageDirectory.Text);

            // 選択されたフォルダに画像データが存在するかチェック
            if (!RunCheckImageFileExists(filePaths))
            {
                // チェック結果がNGの場合は処理をしない
                // （メッセージの表示はチェックメソッドにて実施）
                return;
            }

            // 追記を行うか判定する
            string gifFilePath = TxtAppendGif.Text;
            bool isAppendGif
                = !string.IsNullOrWhiteSpace(gifFilePath)
                && !gifFilePath.Equals(initializeAppendGifText, StringComparison.Ordinal);

            // 追記を行う場合は、追記元のGifファイルが存在するかチェックを行う
            if (isAppendGif && !File.Exists(gifFilePath))
            {
                // ファイルが存在しない場合は、メッセージを表示し処理をしない
                MessageBox.ShowAttention(this, Resources.CombineImagesGifFileErrorNoGif);
                return;
            }

            // 追記を行わない場合は、ファイル保存ダイアログを開き、保存先のパスを設定する
            if (!isAppendGif)
            {
                SaveFileDialog dialog;
                using (dialog = new SaveFileDialog())
                {
                    // ファイル保存ダイアログ
                    dialog.Title = Resources.RunSaveFileDialogTitle;
                    dialog.Filter = Resources.RunSaveFileDialogFilter;
                    dialog.FilterIndex = 2;
                    dialog.RestoreDirectory = true;

                    // ファイル保存ダイアログを表示
                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        // 保存先が選択された場合、そのパスを保持する
                        gifFilePath = dialog.FileName;
                    }
                    else
                    {
                        // 保存先の選択がキャンセルされた場合、処理を終了する
                        return;
                    }
                }

                // 保存先パスから拡張子情報を取得し、拡張子情報がgifの拡張子か判定する
                string extension = Path.GetExtension(gifFilePath);
                if (!extension.ToUpperInvariant().Equals(
                    ".gif".ToUpperInvariant(), StringComparison.Ordinal))
                {
                    // 拡張子がGifの形式でない場合、
                    // 生成したGifの保存先のパスに「.gif」の拡張子を追加する
                    gifFilePath += ".gif";
                }
            }

            // コントロールを無効にする
            SetEnableForInputControl(false);

            // 実行中フラグを ON にする
            IsRuning = true;

            // ファイル名を名前順にソートする
            string[] sortFilePaths = filePaths.OrderBy(file => file).ToArray();

            // 画像データ連結処理を実行（別タスクで実行）
            bool result = false;
            await Task.Run(() =>
            {
                result = Run(sortFilePaths, gifFilePath, isAppendGif);
            }).ConfigureAwait(true);

            // 正常終了の場合、メッセージを表示する
            if (result)
            {
                MessageBox.ShowInfo(Resources.RunProcessEndMessage);
            }

            // 実行中フラグを OFF にする
            IsRuning = false;

            // コントロールを有効にする
            SetEnableForInputControl(true);
        }

        /// <summary>
        /// 停止ボタン押下
        /// </summary>
        /// <param name="sender">センダーオブジェクト</param>
        /// <param name="e">イベントデータ</param>
        private void BtStop_Click(object sender, EventArgs e)
        {
            // 中断フラグを ON にする
            IsStop = true;
        }

        #endregion

        #endregion

        #region メソッド

        #region コントロールの表示設定関連のメソッド

        /// <summary>
        /// コントロールの表示設定を行う
        /// </summary>
        private void SetControlDisplaySetting()
        {
            // ループエリアの表示設定
            bool isAppendGif = !string.IsNullOrWhiteSpace(TxtAppendGif.Text)
                && !TxtAppendGif.Text.Equals(initializeAppendGifText, StringComparison.Ordinal);
            bool isRoop = ChkRoop.Checked;
            PlRoop.Enabled = !isAppendGif;
            ChkRoop.Enabled = !isAppendGif;
            PlRoopSettings.Enabled = isRoop;
            PlRoopCount.Enabled = isRoop && !ChkRoopInfinite.Checked;

            // 実行ボタンエリアの表示設定
            BtStop.Enabled = !BtRun.Enabled;

            // 進捗バーの表示設定
            ProgressBarCreateGif.Value = 0;

            // ボタンの有効無効で背景を変更
            // 実行ボタンエリア
            BtRun.BackgroundImage
                = BtRun.Enabled && PlRun.Enabled ? null : Resources.Enable_False;
            BtStop.BackgroundImage
                = BtStop.Enabled && PlRun.Enabled ? null : Resources.Enable_False;
        }

        /// <summary>
        /// 入力コントロールの有効無効フラグの制御
        /// </summary>
        /// <param name="isEnable">設定する有効無効フラグの値</param>
        private void SetEnableForInputControl(bool isEnable)
        {
            // 各入力コントロールの有効無効を設定する
            LbTitle.Enabled = isEnable;
            PlParameter.Enabled = isEnable;

            // フレームレート
            TxtFrameRate.Enabled = isEnable;

            // 画像データのフォルダを選択エリア
            PlImageDirectory.Enabled = isEnable;
            TxtImageDirectory.Enabled = isEnable;
            BtImageDirectorySelect.Enabled = isEnable;
            BtImageDirectoryClear.Enabled = isEnable;

            // 追記元のGifの選択エリア
            PlAppendGif.Enabled = isEnable;
            TxtAppendGif.Enabled = isEnable;
            BtAppendGifFileSelect.Enabled = isEnable;
            BtAppendGifClear.Enabled = isEnable;

            // ループ設定エリア
            PlRoop.Enabled = isEnable;
            ChkRoop.Enabled = isEnable;
            TxtRoopCount.Enabled = isEnable;
            ChkRoopInfinite.Enabled = isEnable;

            // 実行ボタンエリア
            BtRun.Enabled = isEnable;
            BtStop.Enabled = !BtRun.Enabled;

            // コントロールの表示設定を行う
            SetControlDisplaySetting();
        }

        #endregion

        #region 画像データ連結処理を実行のメソッド

        /// <summary>
        /// 実行時に行う、画像データ格納フォルダに画像データが存在するかチェックする
        /// </summary>
        /// <param name="filePaths">画像データ格納フォルダのファイルリスト</param>
        /// <returns>チェック結果、チェックOK：True、NG：False</returns>
        private bool RunCheckImageFileExists(string[] filePaths)
        {
            // 画像データ格納フォルダに画像データが存在するかチェックする
            try
            {
                if (!filePaths.Any(imageFilePath
                    => ImageTransform.CanImageLoad(imageFilePath)))
                {
                    // チェックNGの場合、エラーメッセージを表示し処理をしない
                    MessageBox.ShowAttention(this, Resources.CombineImagesDirectoryErrorNotImage);
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                // 下記のエラーの場合はメッセージを表示して処理をしない
                if (ex is ArgumentException
                    || ex is PathTooLongException)
                {
                    // 下記のパスが不正の場合の例外の場合は、その旨のメッセージを表示し処理しない
                    // ArgumentException
                    // ・パスとして正しくない文字を含んで入る場合
                    // PathTooLongException
                    // ・指定したパスがシステム定義の最大長を超えている場合
                    string message = Resources.CombineImagesDirectoryErrorIncorrectPath
                        + "\r\n" + ex.Message;
                    MessageBox.ShowAttention(this, message);
                    return false;
                }
                else if (ex is DirectoryNotFoundException
                    || ex is UnauthorizedAccessException
                    || ex is IOException)
                {
                    // 下記のアクセスに関する例外の場合は、その旨のメッセージを表示し処理しない
                    // DirectoryNotFoundException:
                    // ・指定したディレクトリが見つからない場合
                    // UnauthorizedAccessException
                    // ・呼び出し元に、必要なアクセス許可がない場合
                    // IOException
                    // ・IOエラーが発生した場合
                    string message = Resources.CombineImagesDirectoryErrorNotAccess
                        + "\r\n" + ex.Message;
                    MessageBox.ShowAttention(this, message);
                    return false;
                }

                // 上記以外の例外の場合はそのままスローする
                throw;
            }
        }

        /// <summary>
        /// 画像データ連結する処理を実行する
        /// </summary>
        /// <param name="imageFilePaths">
        /// 画面から指定された画像データが格納されているフォルダ内のファイルパスの配列
        /// （少なくとも１つ以上は画像データを含んでいるが、画像データ以外も含まれている可能性がある
        ///  画像データの読み込み処理を重複的に行うのは無駄であるため、連結処理にてファイルの判定を行う）
        /// </param>
        /// <param name="gifFilePath">
        /// 作成するGifファイルの保存先パス
        /// （追記をする場合（引数の <paramref name="isAppendGif"/> が True の場合）は
        /// 既に存在するGifファイルのパスであり、そのファイルに追記する）
        /// </param>
        /// <param name="isAppendGif">
        /// 追記フラグ
        /// 追記する場合：True、追記しない場合：False
        /// </param>
        /// <returns>処理が正常終了した場合 True、中断した場合 False</returns>
        private bool Run(string[] imageFilePaths, string gifFilePath, bool isAppendGif)
        {
            try
            {
                // 中断フラグを OFF にする
                IsStop = false;

                // ループ回数のパラメータ設定
                bool isRoop = false;
                short roopCount = 1;
                if (!isAppendGif)
                {
                    // Gifに追記しない場合のみループ設定を使用する
                    isRoop = ChkRoop.Checked;
                    roopCount = ChkRoopInfinite.Checked ? (short)0 : decimal.ToInt16(TxtRoopCount.Value);
                }

                // Gifエンコーダー生成
                GifEncoder gifEncoder;
                using (gifEncoder = new GifEncoder(gifFilePath, isAppendGif, isRoop, roopCount))
                {
                    // 都度都度保存する
                    gifEncoder.IsEachTimeSave = true;

                    // 設定するディレイ用のパラメータの初期値を設定
                    int frameRate = decimal.ToInt32(TxtFrameRate.Value);
                    int remainder = 0;
                    int delay;

                    // イメージデータを読み込みGifエンコーダに追加していく
                    int count = 1;
                    foreach (string imagePath in imageFilePaths)
                    {
                        // 中断しているか判定
                        if (IsStop)
                        {
                            // 処理を中断する
                            return false;
                        }

                        // 読み込み可能な画像データのみ追加していく
                        Image image = null;
                        try
                        {
                            if (ImageTransform.TryImageLoad(imagePath, out image))
                            {
                                // 設定するディレイを計算
                                delay = (GifEncoder.GifDelayUnit + remainder) / frameRate;
                                remainder = (GifEncoder.GifDelayUnit + remainder) % frameRate;

                                // 画像データをGifに追加
                                gifEncoder.AddImage(image, (short)delay);
                            }
                        }
                        finally
                        {
                            image?.Dispose();
                        }

                        // 進捗を進める
                        int progressRate = count * 100 / imageFilePaths.Length;
                        Invoke((MethodInvoker)(() => StepProgressBar(progressRate)));
                        count++;
                    }

                    // 生成したGifを保存する
                    gifEncoder.Save();
                }

                // 正常終了：True を返す）
                return true;
            }
            catch (Exception ex)
            {
                // 下記の例外が発生する可能性がある
                // UnauthorizedAccessException
                // ・Gifの保存先のパスと同名の隠しファイル等のアクセスできないファイルが
                // 　既に存在している場合に発生
                // ・呼び出し元に、必要なアクセス許可がない場合に発生
                // SecurityException
                // ・呼び出し元に、必要なアクセス許可がない場合に発生
                // IOException
                // ・I/O エラーが発生した場合に発生
                // GifEncoderException
                // ・Gifデータへのエンコードに失敗した場合に発生
                if (ex is UnauthorizedAccessException
                    || ex is SecurityException
                    || ex is IOException
                    || ex is GifEncoderException)
                {
                    // 共通のエラー処理を行う
                    ExceptionHandling.Error(ex);

                    // 異常終了した場合 False を返却
                    return false;
                }

                // 上記以外の例外の場合はそのままスローする（バグの場合）
                throw;
            }
        }

        #endregion

        #region タスク処理で呼び出されるメソッド

        /// <summary>
        /// 進捗バーを進める
        /// </summary>
        /// <param name="progressValue">進捗率</param>
        private void StepProgressBar(int progressValue)
        {
            ProgressBarCreateGif.Value = progressValue;
        }

        #endregion

        #endregion
    }
}
