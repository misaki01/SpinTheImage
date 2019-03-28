namespace SpinTheImage.Forms
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Drawing;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Runtime.InteropServices;
    using System.Security;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;

    using MisaCommon.Exceptions;
    using MisaCommon.Utility.StaticMethod;

    using SpinTheImage.Control;
    using SpinTheImage.Properties;

    using MessageBox = MisaCommon.Utility.StaticMethod.MessageBox;

    /// <summary>
    /// メインフォーム
    /// </summary>
    public partial class MainForm : Form
    {
        #region クラス変数・定数

        /// <summary>
        /// テキストファイルのドラッグ＆ドロップにおいて許可する拡張子（カンマ区切り）
        /// </summary>
        private const string AllowExtensionText = ".txt";

        /// <summary>
        /// 回転パラメータファイルテキストボックスの初期値を保持する領域
        /// （「ファイル選択 又は ドラッグ＆ドロップ」という文言を保持）
        /// </summary>
        private readonly string _initializeRoteteParameterFileText;

        /// <summary>
        /// 入力した画像データ
        /// </summary>
        private Image _imageData = null;

        #endregion

        #region コンストラクタ

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public MainForm()
        {
            // デザイナで生成された設定を行う
            InitializeComponent();

            // ピクチャボックスにドロップを許可
            // （デザイナで設定できなかったためここで設定）
            PictureBoxPreview.AllowDrop = true;

            // 回転パラメータファイルテキストボックスの初期値を取得し保持
            // （値はInitializeComponent()で設定され、
            //   その後コンフィグに値に上書きされるためここで処理を行う必要あり）
            _initializeRoteteParameterFileText = TxtRoteteParameterFile.Text;

            // ユーザコンフィグから前回の設定値を取得し設定する
            InitializeControlByUserConfig(true);

            // コントロールの表示設定
            // （ユーザコンフィグの設定後に処理をする必要あり）
            SetControlDisplaySetting();

            // TODO:【未実装：言語】メインメニューの言語タブを非表示にする（未実装のため）
            MenuItemLanguage.Visible = false;
        }

        #endregion

        #region プロパティ

        /// <summary>
        /// 入力した画像データを取得・設定する
        /// </summary>
        private Image ImageData
        {
            get => _imageData?.Clone() as Image;
            set
            {
                if (_imageData != null)
                {
                    _imageData.Dispose();
                }

                _imageData = value;
            }
        }

        /// <summary>
        /// プレビューモードで表示をしているかどうかを示すフラグを取得・設定する
        /// </summary>
        private bool IsPreviewMode { get; set; } = false;

        /// <summary>
        /// 15度回転ボタンを押下した回数を取得・設定する
        /// </summary>
        private int RotateCount { get; set; } = 0;

        /// <summary>
        /// 実行中かどうかをしますフラグを取得・設定する
        /// </summary>
        private bool IsRuning { get; set; } = false;

        #endregion

        #region static メソッド

        #region ドラッグ＆ドロップ関連のメソッド

        /// <summary>
        /// ドラッグされたデータが単一のテキストファイルか判定する
        /// </summary>
        /// <param name="inputData">
        /// ドラッグされたデータオブジェクト
        /// </param>
        /// <param name="allowExtensionText">
        /// テキストファイルのドラッグ＆ドロップにおいて許可する拡張子（カンマ区切り）
        /// </param>
        /// <returns>判定結果</returns>
        private static bool IsSingleTextFile(IDataObject inputData, string allowExtensionText)
        {
            // 単一のファイルか判定
            if (!IsSingleFile(inputData, out string filePath))
            {
                return false;
            }

            // 拡張子チェック
            string extension = Path.GetExtension(filePath).ToUpperInvariant();
            Console.WriteLine(Directory.Exists(filePath));
            if (!allowExtensionText.Split(',').Any(allowExtension
                => allowExtension.ToUpperInvariant().Equals(extension)))
            {
                return false;
            }

            // 全てのチェックを通過したためTrueをかえす
            return true;
        }

        /// <summary>
        /// ドラッグされたデータが単一の画像ファイルか判定する
        /// </summary>
        /// <param name="inputData">
        /// ドラッグされたデータオブジェクト
        /// </param>
        /// <returns>判定結果</returns>
        private static bool IsSingleImageFile(IDataObject inputData)
        {
            // 単一のファイルか判定
            if (!IsSingleFile(inputData, out string filePath))
            {
                return false;
            }

            // 画像が読み込めるか判定
            if (!ImageTransform.CanImageLoad(filePath))
            {
                // 画像データでない場合は False を返す
                return false;
            }

            // 全てのチェックを通過したため True を返す
            return true;
        }

        /// <summary>
        /// ドラッグされたデータが単一のファイルか判定する
        /// </summary>
        /// <param name="inputData">ドラッグされたデータオブジェクト</param>
        /// <param name="filePath">OK：そのファイルパスを返却、NG：NULLを返却</param>
        /// <returns>判定結果</returns>
        private static bool IsSingleFile(IDataObject inputData, out string filePath)
        {
            // ドラッグされたファイルのパス取得（0の場合、複数の場合もある）
            string[] filePaths = GetDropFilePaths(inputData);

            // 単一のファイルか判定
            if (filePaths.Length != 1)
            {
                // 複数ファイルの場合、パスはNULL、結果はFalseを返す
                filePath = null;
                return false;
            }

            // 全てのチェックを通過したため、対象のファイルのパス、結果はTrueを返却
            filePath = filePaths[0];
            return true;
        }

        /// <summary>
        /// ドラッグされたデータからファイルパスのリストを取得する
        /// </summary>
        /// <param name="inputData">ドラッグされたデータオブジェクト</param>
        /// <returns>
        /// 取得したファイルパスのリスト
        /// ・取得できない場合（ファイルでない場合等）は大きさ0のリストで返す
        /// </returns>
        private static string[] GetDropFilePaths(IDataObject inputData)
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

        #region 指定したファイルをから回転量のリストを生成するメソッド

        /// <summary>
        /// 指定したファイルを読み取り、回転量のリストを生成する
        /// </summary>
        /// <param name="filePath">読み取るファイルのパス</param>
        /// <param name="errorMessage">不正なデータが存在しあ場合、その旨を示すメッセージ（エラーがない場合はNULL）</param>
        /// <returns>回転量のリスト（不正なデータが存在した場合はNULL）</returns>
        private static List<float> GetRotateAmountList(string filePath, out string errorMessage)
        {
            try
            {
                // 許容するエラー数
                // 全ての行数を処理せず、途中でやめるためのエラー数の閾値
                int allowableErrorNum = 10;

                // 戻り値を生成
                List<float> rotateAmountList = new List<float>();
                List<int> errorLineNumList = new List<int>();

                // ファイルを読み込む
                if (File.Exists(filePath))
                {
                    using (TextReader stream = new StreamReader(filePath, Encoding.ASCII))
                    {
                        // １行づつ読み込む
                        int lineCount = 0;
                        string line;
                        while ((line = stream.ReadLine()) != null)
                        {
                            // ライン数をインクリメント
                            lineCount++;

                            // floatに変換
                            if (float.TryParse(line, out float rotateAmount))
                            {
                                // floatに変換できた場合、データを戻り値のリストに追加
                                rotateAmountList.Add(rotateAmount);
                            }
                            else
                            {
                                // floatに変換できた場合、行番号を保持
                                errorLineNumList.Add(lineCount);

                                // エラー数が閾値以上になった場合、処理を抜ける
                                if (errorLineNumList.Count >= allowableErrorNum)
                                {
                                    break;
                                }
                            }
                        }
                    }
                }

                // エラーが発生した行が存在する場合、エラーとしてNULLを返却
                if (errorLineNumList.Count > 0)
                {
                    // 不正なデータの行番号のメッセージを生成
                    StringBuilder errorLineMessage = new StringBuilder();
                    foreach (int errorLineNum in errorLineNumList)
                    {
                        errorLineMessage.Append(string.Format(
                            CultureInfo.InvariantCulture,
                            Resources.RoteteParameterFileErrorNotFloatLineNum,
                            errorLineNum));
                    }

                    // エラーとしてNULLを返却
                    errorMessage = string.Format(
                        CultureInfo.InvariantCulture,
                        Resources.RoteteParameterFileErrorNotFloat,
                        errorLineMessage.ToString());
                    return null;
                }

                // データが存在しない場合はエラーとしてNULLを返却
                if (rotateAmountList.Count == 0)
                {
                    errorMessage = Resources.RoteteParameterFileErrorNoData;
                    return null;
                }

                // 回転量のリストを返却
                errorMessage = null;
                return rotateAmountList;
            }
            catch (IOException)
            {
                errorMessage = Resources.RoteteParameterFileErrorIOException;
                return null;
            }
        }

        #endregion

        #endregion

        #region イベント

        #region 画面ロード・閉じるイベント

        /// <summary>
        /// 画面ロードイベント
        /// </summary>
        /// <param name="sender">センダーオブジェクト</param>
        /// <param name="e">イベントデータ</param>
        private void MainForm_Load(object sender, EventArgs e)
        {
            // いまのところ必要な処理なし
        }

        /// <summary>
        /// 画面を閉じるイベント
        /// </summary>
        /// <param name="sender">センダーオブジェクト</param>
        /// <param name="e">イベントデータ</param>
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // 画面の入力値を設定情報に格納する
            SetUserConfigByControl();

            // 設定情報を保存する
            Settings.Default.Save();
        }

        #endregion

        #region メインメニューのイベント

        /// <summary>
        /// PNGファイル出力のメニューを押下
        /// </summary>
        /// <param name="sender">センダーオブジェクト</param>
        /// <param name="e">イベントデータ</param>
        private void MenuItemOutputPng_Click(object sender, EventArgs e)
        {
            if (sender is ToolStripMenuItem menuItem)
            {
                MenuItemOutputPng.CheckState = menuItem.Checked ? CheckState.Unchecked : CheckState.Checked;
            }
        }

        /// <summary>
        /// メインメニュー‗画像エリアの背景変更の色のメニューを押下
        /// </summary>
        /// <param name="sender">センダーオブジェクト</param>
        /// <param name="e">イベントデータ</param>
        private void MenuItemOptionChangeBackgroundOfImageAreaColor_Click(object sender, EventArgs e)
        {
            // 背景色変更の色のメニューアイテムをグループ化
            ToolStripMenuItem[] colorGroupMenuItems = new ToolStripMenuItem[]
            {
                    MenuItemOptionChangeBackgroundOfImageAreaWhite,
                    MenuItemOptionChangeBackgroundOfImageAreaBlack
            };

            // グループ化した色のメニュー分ループ
            foreach (ToolStripMenuItem colorMenuItem in colorGroupMenuItems)
            {
                if (ReferenceEquals(colorMenuItem, sender))
                {
                    // クリックしたメニューはチェック
                    colorMenuItem.CheckState = CheckState.Checked;
                }
                else
                {
                    // クリックしたメニュー以外はチェックを外す
                    colorMenuItem.CheckState = CheckState.Unchecked;
                }
            }

            // コントロールの表示設定
            SetControlDisplaySetting();
        }

        /// <summary>
        /// メインメニュー‗デフォルト設定に戻すのメニューを押下
        /// </summary>
        /// <param name="sender">センダーオブジェクト</param>
        /// <param name="e">イベントデータ</param>
        private void MenuItemRestoreDefaultSettings_Click(object sender, EventArgs e)
        {
            try
            {
                // 確認用のメッセージボックス表示
                DialogResult dialogResult = MessageBox.ShowConfirm(this, Resources.MenuItemRestoreDefaultSettingsMessage);
                if (dialogResult.HasFlag(DialogResult.Yes) || dialogResult.HasFlag(DialogResult.OK))
                {
                    // TODO:【未実装：言語】言語は切り替えると画面再起動なので切り替えたくないため、リセットから除外

                    // クライアントの位置・サイズはリセットから除外するため現在の値を保持する
                    // フォームが通常の場合（最大化も最小化もされていない状態）の時、現在の位置を保持
                    // フォームが最大化、又は 最小化がされている時、通常状態に戻った字の位置を保持
                    bool isWindowStateNomal = WindowState == FormWindowState.Normal;
                    Rectangle beforeClientRect = isWindowStateNomal ? Bounds : RestoreBounds;

                    // 設定項目をリセットし初期設定をリロードする
                    Settings.Default.Reset();
                    Settings.Default.Reload();

                    // 保持した位置・サイズの情報をユーザコンフィグに上書き
                    Settings.Default.ClientLocation = beforeClientRect.Location;
                    Settings.Default.ClientSize = beforeClientRect.Size;

                    // ユーザコンフィグから前回の設定値を取得し設定する
                    InitializeControlByUserConfig(false);

                    // 画像データをリセット
                    ImageData = null;

                    // プレビューモードを OFF にする
                    IsPreviewMode = false;

                    // 回転数をリセットする
                    RotateCount = 0;

                    // コントロールの有効無効を設定
                    // （ユーザコンフィグの設定後に処理をする必要あり）
                    SetControlDisplaySetting();
                }
            }
            catch (ConfigurationErrorsException ex)
            {
                // 設定項目をリセットに失敗した場合
                ExceptionHandling.Error(ex);
            }
        }

        #endregion

        #region 回転に関するパラメータエリアのイベント

        /// <summary>
        /// 回転に関するパラメータエリアのドラッグEnterイベント
        /// </summary>
        /// <param name="sender">センダーオブジェクト</param>
        /// <param name="e">イベントデータ</param>
        private void RoteteParameterFile_DragEnter(object sender, DragEventArgs e)
        {
            // ドラッグされているデータが単一のテキストファイルかチェック
            bool checkResult = IsSingleTextFile(e.Data, AllowExtensionText);

            // ドラッグされているテキストファイルが正常な回転量リストかチェック
            if (checkResult)
            {
                checkResult = GetRotateAmountList(GetDropFilePaths(e.Data)[0], out string tmp) != null;
            }

            // チェックが正常の場合ドロップを受け入れる
            e.Effect = checkResult ? DragDropEffects.Move : DragDropEffects.None;
        }

        /// <summary>
        /// 回転に関するパラメータエリアのドラッグ＆ドロップイベント
        /// </summary>
        /// <param name="sender">センダーオブジェクト</param>
        /// <param name="e">イベントデータ</param>
        private void RoteteParameterFile_DragDrop(object sender, DragEventArgs e)
        {
            // ドロップされたテキストファイルパスを設定
            TxtRoteteParameterFile.Text = GetDropFilePaths(e.Data)[0];

            // 画面の表示設定を行う
            SetControlDisplaySetting();
        }

        /// <summary>
        /// 回転パラメータファイル選択の選択ボタンを押下
        /// </summary>
        /// <param name="sender">センダーオブジェクト</param>
        /// <param name="e">イベントデータ</param>
        private void BtRoteteParameterFileSelect_Click(object sender, EventArgs e)
        {
            // ファイル選択ダイアログを開き、回転パラメータファイルを選択する
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                // ファイル選択ダイアログの表示設定
                dialog.Title = Resources.RoteteParameterFileSelectDialogTitle;
                dialog.Filter = Resources.RoteteParameterFileSelectDialogFilter;
                dialog.FilterIndex = 1;
                dialog.RestoreDirectory = true;

                // ダイアログを表示
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    // ファイル選択でOKが押された場合、選択したファイルパスを取得
                    string filePath = dialog.FileName;

                    // 選択したファイルのチェックを行う
                    if (GetRotateAmountList(filePath, out string errorMessage) != null)
                    {
                        // チェックOKの場合、選択したファイルのパスを設定する
                        TxtRoteteParameterFile.Text = filePath;
                    }
                    else
                    {
                        // チェックNGの場合、エラーメッセージを表示する
                        MessageBox.ShowAttention(this, errorMessage);
                    }
                }
            }

            // 画面の表示設定を行う
            SetControlDisplaySetting();
        }

        /// <summary>
        /// 回転パラメータファイル選択のクリアボタンを押下
        /// </summary>
        /// <param name="sender">センダーオブジェクト</param>
        /// <param name="e">イベントデータ</param>
        private void BtRoteteParameterFileClear_Click(object sender, EventArgs e)
        {
            // テキストボックスをデフォルトの値に戻す
            TxtRoteteParameterFile.Text = _initializeRoteteParameterFileText;

            // 画面の表示設定を行う
            SetControlDisplaySetting();
        }

        #endregion

        #region キャンパスの変更エリアのイベント

        /// <summary>
        /// キャンパスの中心位置変更のチェックボックスのチェックを変更
        /// </summary>
        /// <param name="sender">センダーオブジェクト</param>
        /// <param name="e">イベントデータ</param>
        private void ChkChangeCanvasCenter_CheckedChanged(object sender, EventArgs e)
        {
            // プレビューモードが ON の場合、プレビューモードをクリアする
            if (IsPreviewMode)
            {
                // プレビューモードを OFF にする
                IsPreviewMode = false;

                // 回転数をリセットする
                RotateCount = 0;

                // 画像エリアの画像を元に戻す
                RefreshImage(ImageData);
            }

            // 画面の表示設定を行う
            SetControlDisplaySetting();

            // 画像エリアの再描画を行う
            PictureBoxPreview.Refresh();
        }

        /// <summary>
        /// キャンパスの中心位置のテキストボックスの値を変更
        /// </summary>
        /// <param name="sender">センダーオブジェクト</param>
        /// <param name="e">イベントデータ</param>
        private void TxtChangeCanvasCenter_ValueChanged(object sender, EventArgs e)
        {
            // プレビューモードが ON の場合、プレビューモードをクリアする
            if (IsPreviewMode)
            {
                // プレビューモードを OFF にする
                IsPreviewMode = false;

                // 回転数をリセットする
                RotateCount = 0;

                // 画像エリアの画像を元に戻す
                RefreshImage(ImageData);
            }

            // 画像エリアの再描画を行う
            PictureBoxPreview.Refresh();
        }

        /// <summary>
        /// キャンパスの中心線の表示チェックボックスのチェックを変更
        /// </summary>
        /// <param name="sender">センダーオブジェクト</param>
        /// <param name="e">イベントデータ</param>
        private void ChkChangeCanvasPreviewCenterLine_CheckedChanged(object sender, EventArgs e)
        {
            // 画像エリアの再描画を行う
            PictureBoxPreview.Refresh();
        }

        /// <summary>
        /// キャンパスサイズの変更方法のラジオボタンのチェックを変更
        /// </summary>
        /// <param name="sender">センダーオブジェクト</param>
        /// <param name="e">イベントデータ</param>
        private void RdoChangeCanvasSize_CheckedChanged(object sender, EventArgs e)
        {
            // プレビューモードが ON の場合、プレビューモードをクリアする
            if (IsPreviewMode)
            {
                // プレビューモードを OFF にする
                IsPreviewMode = false;

                // 回転数をリセットする
                RotateCount = 0;

                // 画像エリアの画像を元に戻す
                RefreshImage(ImageData);
            }

            // 画面の表示設定を行う
            SetControlDisplaySetting();
        }

        /// <summary>
        /// キャンパスサイズ変更のプレビューボタンを押下
        /// </summary>
        /// <param name="sender">センダーオブジェクト</param>
        /// <param name="e">イベントデータ</param>
        private void BtChangeCanvasSizePreview_Click(object sender, EventArgs e)
        {
            // 画像が設定されていない場合はメッセージを表示し処理しない
            if (!CheckExistsImageData())
            {
                return;
            }

            // キャンパスサイズの設定方法に応じた画像を生成
            using (Image image = GetChangeCanvasImage())
            {
                // プレビューモードを ON にする
                IsPreviewMode = true;

                // 回転数をリセットする
                RotateCount = 0;

                // 変更した画像を適用
                RefreshImage(image);
            }
        }

        /// <summary>
        /// キャンパスサイズ変更の回転ボタンを押下
        /// </summary>
        /// <param name="sender">センダーオブジェクト</param>
        /// <param name="e">イベントデータ</param>
        private void BtChangeCanvasSizePreviewRotate15_Click(object sender, EventArgs e)
        {
            // 画像が設定されていない場合はメッセージを表示し処理しない
            if (!CheckExistsImageData())
            {
                return;
            }

            // キャンパスサイズの設定方法に応じた画像を生成し、
            // その画像を回転させる
            using (Image tmpImage = GetChangeCanvasImage())
            using (Image image = ImageTransform.RotateImage(tmpImage, 15 * (RotateCount + 1)))
            {
                // プレビューモードを ON にする
                IsPreviewMode = true;

                // 回転数をインクリメントする
                RotateCount++;

                // 回転させた画像を反映する
                RefreshImage(image);
            }
        }

        /// <summary>
        /// キャンパスサイズ変更のクリアを押下
        /// </summary>
        /// <param name="sender">センダーオブジェクト</param>
        /// <param name="e">イベントデータ</param>
        private void BtChangeCanvasSizePreviewClear_Click(object sender, EventArgs e)
        {
            // 画像が設定されていない場合はメッセージを表示し処理しない
            if (!CheckExistsImageData())
            {
                return;
            }

            // プレビューモードを OFF にする
            IsPreviewMode = false;

            // 回転数をリセットする
            RotateCount = 0;

            // 画像エリアの画像を元に戻す
            RefreshImage(ImageData);
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
        /// プレビュー、実行ボタン押下
        /// </summary>
        /// <param name="sender">センダーオブジェクト</param>
        /// <param name="e">イベントデータ</param>
        private void Run_Click(object sender, EventArgs e)
        {
            // プログレスバーをリセット
            ProgressBarCreateGif.Value = 0;

            // 画像が設定されていない場合はメッセージを表示し処理しない
            if (!CheckExistsImageData())
            {
                MessageBox.ShowAttention(this, Resources.RunProcessErrorNoRoteteImage);
                return;
            }

            // 回転パラメータファイルのチェックを行う
            IList<float> movingAngleList = null;
            string filePath = TxtRoteteParameterFile.Text;
            if (!string.IsNullOrEmpty(filePath)
                && !filePath.Equals(_initializeRoteteParameterFileText))
            {
                // 回転パラメータファイルが指定されている場合のみチェックを行う
                movingAngleList = GetRotateAmountList(filePath, out string errorMessage);
                if (movingAngleList == null)
                {
                    // チェックNGの場合、エラーメッセージを表示し、処理を抜ける
                    MessageBox.ShowAttention(this, errorMessage);
                    return;
                }
            }

            // プレビュー処理か本実行か判定
            // （センダーが実行ボタンでなければプレビューとして扱う）
            bool isPreview = !ReferenceEquals(BtRun, sender);

            // プレビューでない場合、ファイルの保存先を選択する
            string savePath = null;
            if (!isPreview)
            {
                // ファイル保存ダイアログを開き、保存先のパスを設定する
                using (SaveFileDialog dialog = new SaveFileDialog())
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
                        savePath = dialog.FileName;
                    }
                    else
                    {
                        // 保存先の選択がキャンセルされた場合、処理を終了する
                        return;
                    }
                }
            }

            // コントロールを無効にする
            SetEnableForInputControl(false);

            // プレビューモードを OFF にする
            IsPreviewMode = false;

            // 回転数をリセットする
            RotateCount = 0;

            // 実行中フラグを ON にする
            IsRuning = true;

            // 回転Gifの作成処理を実行（別タスクで実行）
            bool result = false;
            Task.Run(() =>
            {
                result = Run(movingAngleList, isPreview, savePath);
            })
            .ContinueWith((task) =>
            {
                // 処理結果を判定
                if (task.Exception != null)
                {
                    // 例外が発生している場合
                    ExceptionHandling.Error(task.Exception);
                }
                else if (result && !isPreview)
                {
                    // 正常終了かつプレビューでない場合、メッセージを表示する
                    MessageBox.ShowInfo(Resources.RunProcessEndMessage);
                }

                // 実行中フラグを OFF にする
                IsRuning = false;

                // 画像エリアの画像をもとに戻す
                Invoke((MethodInvoker)(() => RefreshImage(ImageData)));

                // コントロールを有効にする
                Invoke((MethodInvoker)(() => SetEnableForInputControl(true)));
            });
        }

        /// <summary>
        /// 停止ボタン押下
        /// </summary>
        /// <param name="sender">センダーオブジェクト</param>
        /// <param name="e">イベントデータ</param>
        private void BtStop_Click(object sender, EventArgs e)
        {
            // 停止を指示する
            SpinImage.Stop();
        }

        #endregion

        #region 画像エリアのイベント

        /// <summary>
        /// 画像エリアのドラッグEnterイベント
        /// </summary>
        /// <param name="sender">センダーオブジェクト</param>
        /// <param name="e">イベントデータ</param>
        private void PictureBoxPreview_DragEnter(object sender, DragEventArgs e)
        {
            // ドラッグされているデータが単一の画像ファイルか判定し、ドロップ効果の設定を行う
            e.Effect = IsSingleImageFile(e.Data)
                ? DragDropEffects.Move : DragDropEffects.None;
        }

        /// <summary>
        /// 画像エリアのドラッグ＆ドロップイベント
        /// </summary>
        /// <param name="sender">センダーオブジェクト</param>
        /// <param name="e">イベントデータ</param>
        private void PictureBoxPreview_DragDrop(object sender, DragEventArgs e)
        {
            Image image = null;
            try
            {
                // ドロップされた画像を読み込み
                if (!ImageTransform.TryImageLoad(GetDropFilePaths(e.Data)[0], out image))
                {
                    // 画像データが読み込めない場合はなにもしない
                    return;
                }

                // 読み込んだ画像をプロパティ、コントロールに設定する
                Size size = image.Size;
                ImageData = new Bitmap(image, image.Size);
                PictureBoxPreview.Image = ImageData;

                // プレビューモードを OFF にする
                IsPreviewMode = false;

                // 回転数をリセットする
                RotateCount = 0;

                // 画像サイズにより中心点の補正用のテキストボックスの上限下限を設定する
                decimal minX = new decimal(size.Width / 2 * -1);
                decimal maxX = new decimal(size.Width / 2);
                SetMinMax(TxtChangeCanvasCenterPointX, minX * 2, maxX * 2);
                decimal minY = new decimal(size.Height / 2 * -1);
                decimal maxY = new decimal(size.Height / 2);
                SetMinMax(TxtChangeCanvasCenterPointY, minY * 2, maxY * 2);

                // 上限下限を設定するためのローカル関数
                // 引数１：設定対象のコントロール
                // 引数２：設定する下限値
                // 引数３：設定する上限値
                void SetMinMax(NumericUpDown numericUpCountrol, decimal min, decimal max)
                {
                    numericUpCountrol.Minimum = min;
                    numericUpCountrol.Maximum = max;
                    if (numericUpCountrol.Value < numericUpCountrol.Minimum)
                    {
                        numericUpCountrol.Value = numericUpCountrol.Minimum;
                    }
                    else if (numericUpCountrol.Value > numericUpCountrol.Maximum)
                    {
                        numericUpCountrol.Value = numericUpCountrol.Maximum;
                    }
                }
            }
            finally
            {
                // 画像データを破棄
                image?.Dispose();
            }

            // 画面の表示設定を行う
            SetControlDisplaySetting();
        }

        /// <summary>
        /// 画像エリアの描画する時のイベント
        /// </summary>
        /// <param name="sender">センダーオブジェクト</param>
        /// <param name="e">描画に関するイベントデータ</param>
        private void PictureBoxPreview_Paint(object sender, PaintEventArgs e)
        {
            // 下記の条件に合致する場合のみ中心をします十字線を表示する
            // ・画像エリアに画像が設定されている
            // ・Gif作成の処理の実行中でない（プレビュー実行も含む）
            // ・中心線を表示する設定
            // ・画像エリアのサイズが0より大きい
            // ・画像エリアに表示している画像のサイズが0より大きい
            if (PictureBoxPreview.Image != null
                && !IsRuning
                && ChkChangeCanvasPreviewCenterLine.Checked
                && PictureBoxPreview.Size.Width > 0
                && PictureBoxPreview.Size.Height > 0
                && PictureBoxPreview.Image.Width > 0
                && PictureBoxPreview.Image.Height > 0)
            {
                // 画像エリアのサイズと、表示している画像の元のサイズを取得
                Size size = PictureBoxPreview.Size;
                Size imageSize = PictureBoxPreview.Image.Size;

                // 拡大縮小率を計算
                int diffWidth = size.Width - imageSize.Width;
                int diffHeight = size.Height - imageSize.Height;
                float scalingRate;
                if (diffWidth.CompareTo(diffHeight) < 0)
                {
                    // 幅で拡大縮小率を計算
                    scalingRate = size.Width / (float)imageSize.Width;
                }
                else
                {
                    // 高さで拡大縮小率を計算
                    scalingRate = size.Height / (float)imageSize.Height;
                }

                // 中心の補正値を設定
                float correctX = 0;
                float correctY = 0;
                if (ChkChangeCanvasCenter.Checked && !IsPreviewMode)
                {
                    // 中心位置の変更がチェックされているかつ、プレビューモードではない場合
                    // テキストボックスに設定されている補正値を使用する
                    // （プレビューモードの場合は変更した中心位置になるように
                    // 　画像をずらしているため補正の必要はない）
                    correctX = decimal.ToInt32(TxtChangeCanvasCenterPointX.Value) * scalingRate;
                    correctY = decimal.ToInt32(TxtChangeCanvasCenterPointY.Value) * scalingRate;
                }

                // 補正込みの中心点を算出
                float centerX = (size.Width / 2) + correctX;
                float centerY = (size.Height / 2) + correctY;

                // 中心線を描画
                Graphics graphics = e.Graphics;
                using (Pen pen = new Pen(Color.Red, 3))
                {
                    // 縦線
                    graphics.DrawLine(pen, centerX, 0, centerX, size.Height);

                    // 横線
                    graphics.DrawLine(pen, 0, centerY, size.Width, centerY);
                }
            }
        }

        #endregion

        #endregion

        #region メソッド

        #region ユーザコンフィグ関連のメソッド

        /// <summary>
        /// ユーザコンフィグで各コントロールの値を設定する
        /// </summary>
        /// <param name="isConstructor">コンストラクタからの呼び出しかどうか</param>
        private void InitializeControlByUserConfig(bool isConstructor)
        {
            // クライアントのサイズ（コンストラクタのみの処理）
            if (isConstructor)
            {
                // ロケーションについてはDataBindings機能を利用して設定
                Size = Settings.Default.ClientSize;
            }

            // メインメニュー
            MenuItemOutputPng.CheckState
                = Settings.Default.MainFormMenuItemOutputPng ? CheckState.Checked : CheckState.Unchecked;
            MenuItemOptionChangeBackgroundOfImageAreaWhite.CheckState
                = Settings.Default.MainFormMenuItemOptionChangeBackgroundOfImageAreaWhite ? CheckState.Checked : CheckState.Unchecked;
            MenuItemOptionChangeBackgroundOfImageAreaBlack.CheckState
                = Settings.Default.MainFormMenuItemOptionChangeBackgroundOfImageAreaBlack ? CheckState.Checked : CheckState.Unchecked;

            // 画面左のパネルの幅
            PlLeft.Width = Settings.Default.MainFormPlLeftWidth;

            // 回転パラメータエリア
            TxtFrameRate.Value = Settings.Default.MainFormTxtFrameRate;
            TxtSeconds.Value = Settings.Default.MainFormTxtSecound;
            TxtInitialSpeed.Value = Settings.Default.MainFormTxtInitialSpeed;
            TxtAcceleteRate.Value = Settings.Default.MainFormTxtAcceleteRate;

            // 回転パラメータファイルパス
            string filePath = Settings.Default.MainFormTxtRoteteParameterFile;
            if (!string.IsNullOrEmpty(filePath) && GetRotateAmountList(filePath, out string tmp) != null)
            {
                TxtRoteteParameterFile.Text = filePath;
            }

            // キャンパスサイズの変更エリア
            ChkChangeCanvasCenter.Checked = Settings.Default.MainFormRdoChangeCanvasChkCenter;
            TxtChangeCanvasCenterPointX.Value = Settings.Default.MainFormRdoChangeCanvasChkCenterX;
            TxtChangeCanvasCenterPointY.Value = Settings.Default.MainFormRdoChangeCanvasChkCenterY;
            ChkChangeCanvasPreviewCenterLine.Checked = false;
            RdoChangeCanvasSizeNoChange.Checked = Settings.Default.MainFormRdoChangeCanvasSizeNoChange;
            RdoChangeCanvasSizeDiagonalSize.Checked = Settings.Default.MainFormRdoChangeCanvasSizeDiagonalSize;
            RdoChangeCanvasSizeSelectSize.Checked = Settings.Default.MainFormRdoChangeCanvasSizeSelectSize;
            TxtChangeCanvasSizeSelectSizeWidth.Value = Settings.Default.MainFormTxtChangeCanvasSizeSelectSizeWidth;
            TxtChangeCanvasSizeSelectSizeHeight.Value = Settings.Default.MainFormTxtChangeCanvasSizeSelectSizeHeight;

            // ループの設定エリア
            ChkRoop.Checked = Settings.Default.MainFormChkRoop;
            TxtRoopCount.Value = Settings.Default.MainFormTxtRoopCount;
            ChkRoopInfinite.Checked = Settings.Default.MainFormChkRoopInfinite;

            // 最後は元の画像で終わるか
            ChkRotateToEnd.Checked = Settings.Default.MainFormChkRotateToEnd;

            // TODO:【未実装：言語】メインメニューの言語タブに関する処理が必要
        }

        /// <summary>
        /// ユーザコンフィグに各コントロールの値を設定する
        /// </summary>
        private void SetUserConfigByControl()
        {
            // クライアントの位置とサイズを取得
            Rectangle clientRectangle = WindowState == FormWindowState.Normal ? Bounds : RestoreBounds;
            Settings.Default.ClientLocation = clientRectangle.Location;
            Settings.Default.ClientSize = clientRectangle.Size;

            // メインメニュー
            Settings.Default.MainFormMenuItemOutputPng = MenuItemOutputPng.Checked;
            Settings.Default.MainFormMenuItemOptionChangeBackgroundOfImageAreaWhite
                = MenuItemOptionChangeBackgroundOfImageAreaWhite.Checked;
            Settings.Default.MainFormMenuItemOptionChangeBackgroundOfImageAreaBlack
                = MenuItemOptionChangeBackgroundOfImageAreaBlack.Checked;

            // 画面左のパネルの幅
            Settings.Default.MainFormPlLeftWidth = PlLeft.Width;

            // 回転パラメータエリア
            Settings.Default.MainFormTxtFrameRate = TxtFrameRate.Value;
            Settings.Default.MainFormTxtSecound = TxtSeconds.Value;
            Settings.Default.MainFormTxtInitialSpeed = TxtInitialSpeed.Value;
            Settings.Default.MainFormTxtAcceleteRate = TxtAcceleteRate.Value;

            // 回転パラメータファイルパス
            string filePath = TxtRoteteParameterFile.Text;
            bool checkFilePath = !string.IsNullOrEmpty(filePath) && GetRotateAmountList(filePath, out string tmp) != null;
            Settings.Default.MainFormTxtRoteteParameterFile = checkFilePath ? filePath : string.Empty;

            // キャンパスの変更エリア
            Settings.Default.MainFormRdoChangeCanvasChkCenter = ChkChangeCanvasCenter.Checked;
            Settings.Default.MainFormRdoChangeCanvasChkCenterX = TxtChangeCanvasCenterPointX.Value;
            Settings.Default.MainFormRdoChangeCanvasChkCenterY = TxtChangeCanvasCenterPointY.Value;
            Settings.Default.MainFormRdoChangeCanvasSizeNoChange = RdoChangeCanvasSizeNoChange.Checked;
            Settings.Default.MainFormRdoChangeCanvasSizeDiagonalSize = RdoChangeCanvasSizeDiagonalSize.Checked;
            Settings.Default.MainFormRdoChangeCanvasSizeSelectSize = RdoChangeCanvasSizeSelectSize.Checked;
            Settings.Default.MainFormTxtChangeCanvasSizeSelectSizeWidth = TxtChangeCanvasSizeSelectSizeWidth.Value;
            Settings.Default.MainFormTxtChangeCanvasSizeSelectSizeHeight = TxtChangeCanvasSizeSelectSizeHeight.Value;

            // ループの設定エリア
            Settings.Default.MainFormChkRoop = ChkRoop.Checked;
            Settings.Default.MainFormTxtRoopCount = TxtRoopCount.Value;
            Settings.Default.MainFormChkRoopInfinite = ChkRoopInfinite.Checked;

            // 最後は元の画像で終わるか
            Settings.Default.MainFormChkRotateToEnd = ChkRotateToEnd.Checked;

            // TODO:【未実装：言語】メインメニューの言語タブに関する処理が必要
        }

        #endregion

        #region コントロールの表示設定関連のメソッド

        /// <summary>
        /// コントロールの表示設定を行う
        /// </summary>
        private void SetControlDisplaySetting()
        {
            // 回転に関するパラメータエリアの表示設定
            PlRoteteParameterInput.Enabled = TxtRoteteParameterFile.Text == _initializeRoteteParameterFileText;

            // キャンパスの変更エリアの表示設定
            PlChangeCanvasCenter.Enabled = ImageData != null;
            PlChangeCanvasCenterPoint.Enabled = ChkChangeCanvasCenter.Checked;
            PlChangeCanvasSizeSelectSize.Enabled = RdoChangeCanvasSizeSelectSize.Checked;

            // ループの設定エリアの表示設定
            bool isRoop = ChkRoop.Checked;
            bool isRoopInfinite = ChkRoopInfinite.Checked;
            PlRoopSettings.Enabled = isRoop;
            PlRoopCount.Enabled = isRoop && !isRoopInfinite;

            // 実行ボタンエリアの表示設定
            PlRun.Enabled = ImageData != null;
            BtStop.Visible = !PlRun.Enabled || !BtRun.Enabled;

            // 画像エリアの表示設定
            // イメージが設定されていない場合のみ処理を行う
            if (MenuItemOptionChangeBackgroundOfImageAreaBlack.Checked)
            {
                PictureBoxPreview.BackColor = Color.Black;
                if (ImageData == null)
                {
                    RefreshImage(Resources.DragDrop_White);
                }
            }
            else
            {
                PictureBoxPreview.BackColor = Color.White;
                if (ImageData == null)
                {
                    RefreshImage(Resources.DragDrop_Black);
                }
            }

            // 進捗バーの表示設定
            ProgressBarCreateGif.Value = 0;

            // ボタンの有効無効で背景を変更
            // 回転パラメータエリア
            BtRoteteParameterFileSelect.BackgroundImage
                = BtRoteteParameterFileSelect.Enabled ? null : Resources.Enable_False;
            BtRoteteParameterFileClear.BackgroundImage
                = BtRoteteParameterFileClear.Enabled ? null : Resources.Enable_False;

            // キャンパスサイズ変更エリア
            BtChangeCanvasPreview.BackgroundImage
                = BtChangeCanvasPreview.Enabled ? null : Resources.Enable_False;
            BtChangeCanvasPreviewRotate15.BackgroundImage
                = BtChangeCanvasPreviewRotate15.Enabled ? null : Resources.Enable_False;
            BtChangeCanvasPreviewClear.BackgroundImage
                = BtChangeCanvasPreviewClear.Enabled ? null : Resources.Enable_False;

            // 実行ボタンエリア
            BtPreview.BackgroundImage
                = BtPreview.Enabled && PlRun.Enabled ? null : Resources.Enable_False;
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

            // メインメニュー
            MenuItemOutputPng.Enabled = isEnable;
            MenuItemRestoreDefaultSettings.Enabled = isEnable;
            MenuItemLanguage.Enabled = isEnable;

            // 回転パラメータエリア
            LbRoteteParameter.Enabled = isEnable;
            PlRoteteParameter.Enabled = isEnable;
            TxtFrameRate.Enabled = isEnable;
            TxtSeconds.Enabled = isEnable;
            TxtInitialSpeed.Enabled = isEnable;
            TxtAcceleteRate.Enabled = isEnable;
            TxtRoteteParameterFile.Enabled = isEnable;
            BtRoteteParameterFileSelect.Enabled = isEnable;
            BtRoteteParameterFileClear.Enabled = isEnable;

            // キャンパスサイズ変更エリア
            LbChangeCanvas.Enabled = isEnable;
            PlChangeCanvas.Enabled = isEnable;
            ChkChangeCanvasCenter.Enabled = isEnable;
            TxtChangeCanvasCenterPointX.Enabled = isEnable;
            TxtChangeCanvasCenterPointY.Enabled = isEnable;
            ChkChangeCanvasPreviewCenterLine.Enabled = isEnable;
            RdoChangeCanvasSizeNoChange.Enabled = isEnable;
            RdoChangeCanvasSizeDiagonalSize.Enabled = isEnable;
            RdoChangeCanvasSizeSelectSize.Enabled = isEnable;
            TxtChangeCanvasSizeSelectSizeWidth.Enabled = isEnable;
            TxtChangeCanvasSizeSelectSizeHeight.Enabled = isEnable;
            BtChangeCanvasPreview.Enabled = isEnable;
            BtChangeCanvasPreviewRotate15.Enabled = isEnable;
            BtChangeCanvasPreviewClear.Enabled = isEnable;

            // ループ設定エリア
            LbRoop.Enabled = isEnable;
            PlRoop.Enabled = isEnable;
            ChkRoop.Enabled = isEnable;
            TxtRoopCount.Enabled = isEnable;
            ChkRoopInfinite.Enabled = isEnable;

            // 最終は元の画像の角度で終わるかエリア
            ChkRotateToEnd.Enabled = isEnable;
            LbRotateToEndExplain.Enabled = isEnable;

            // 実行ボタンエリア
            BtPreview.Enabled = isEnable;
            BtRun.Enabled = isEnable;
            BtStop.Enabled = !BtRun.Enabled;

            // コントロールの表示設定を行う
            SetControlDisplaySetting();
        }

        #endregion

        #region 入力チェック関連のメソッド

        /// <summary>
        /// 画像データが存在するかチェック（エラーの場合、メッセージダイアログを表示する）
        /// </summary>
        /// <returns>判定結果</returns>
        private bool CheckExistsImageData()
        {
            // 画像が設定されていない場合はメッセージを表示しFalseを返却
            if (ImageData == null)
            {
                MessageBox.ShowAttention(this, Resources.PictureBoxPreviewNoDataErrorMessage);
                return false;
            }

            // 全てのチェックを通過したためTrueをかえす
            return true;
        }

        #endregion

        #region キャンパスの変更設定関連のメソッド

        /// <summary>
        /// キャンパスの変更設定を反映させた画像データを取得する
        /// </summary>
        /// <returns>キャンパスの変更設定を反映させた画像データ</returns>
        private Image GetChangeCanvasImage()
        {
            // 変更する中心点を取得
            Point? changeCenter = ChkChangeCanvasCenter.Checked ? (Point?)ConvertToCenterPoint() : null;

            // 変更するサイズを取得
            bool isChangeCanvasSize;
            Size? changeSize;
            if (RdoChangeCanvasSizeDiagonalSize.Checked)
            {
                // 対角線の長さに拡大を選択
                isChangeCanvasSize = true;
                changeSize = null;
            }
            else if (RdoChangeCanvasSizeSelectSize.Checked)
            {
                // 指定したサイズで拡大を選択
                isChangeCanvasSize = true;
                changeSize = new Size(
                    width: decimal.ToInt32(TxtChangeCanvasSizeSelectSizeWidth.Value),
                    height: decimal.ToInt32(TxtChangeCanvasSizeSelectSizeHeight.Value));
            }
            else
            {
                // 上記以外（変更しないを選択）
                isChangeCanvasSize = false;
                changeSize = null;
            }

            // キャンパスの変更設定を反映させた画像データを生成し返却
            return SpinImage.GetCreateBaceImageFunc(isChangeCanvasSize, changeSize, changeCenter)(ImageData);
        }

        /// <summary>
        /// キャンパス変更の中心位置を画像の座標系の <see cref="Point"/>型に変換する
        /// </summary>
        /// <returns>画像の座標系の <see cref="Point"/>型に変換した変更後の中心位置</returns>
        private Point ConvertToCenterPoint()
        {
            return new Point(
                x: (ImageData.Width / 2) + decimal.ToInt32(TxtChangeCanvasCenterPointX.Value),
                y: (ImageData.Height / 2) + decimal.ToInt32(TxtChangeCanvasCenterPointY.Value));
        }

        #endregion

        #region 回転するGifを作成する処理を実行のメソッド

        /// <summary>
        /// 回転するGifを作成する処理を実行する
        /// </summary>
        /// <param name="movingAngleList">
        /// 回転パラメータリスト
        /// （秒数、初速、加速度のテキストボックスを使用する場合はNULL、
        /// 　回転パラメータファイルが指定されている場合のみ値を設定する）
        /// </param>
        /// <param name="isPreview">
        /// プレビュー処理か本実行かのフラグ
        /// </param>
        /// <param name="savePath">
        /// 作成したGifファイルの保存先のパス
        /// （プレビューの場合は不要）
        /// </param>
        /// <returns>処理が正常終了した場合 True、異常終了した場合 False</returns>
        private bool Run(IList<float> movingAngleList, bool isPreview, string savePath)
        {
            try
            {
                // 回転パラメータリストを生成
                // 指定したファイルを使用する場合、取得した回転パラメータリストをそのまま使用
                if (movingAngleList == null)
                {
                    // 秒数、初速、加速度の入力値を使用する場合、入力値から回転パラメータリストを生成
                    movingAngleList = ImageParameter.GetRotateAmountList(
                        frameRate: decimal.ToInt32(TxtFrameRate.Value),
                        second: (float)decimal.ToDouble(TxtSeconds.Value),
                        initialSpeed: (float)decimal.ToDouble(TxtInitialSpeed.Value),
                        accelerateRate: (float)decimal.ToDouble(TxtAcceleteRate.Value));
                }

                // キャンパスの中心点を変更に関するパラメータ設定
                Point? changeCenter = ChkChangeCanvasCenter.Checked ? (Point?)ConvertToCenterPoint() : null;

                // キャンパスサイズの変更に関するパラメータを設定
                bool isChangeCanvasSize = !RdoChangeCanvasSizeNoChange.Checked;
                Size? changeCanvasSize = null;
                if (RdoChangeCanvasSizeSelectSize.Checked)
                {
                    changeCanvasSize = new Size(
                        width: decimal.ToInt32(TxtChangeCanvasSizeSelectSizeWidth.Value),
                        height: decimal.ToInt32(TxtChangeCanvasSizeSelectSizeHeight.Value));
                }

                // ループ回数のパラメータ設定
                short roopCount = ChkRoopInfinite.Checked ? (short)0 : decimal.ToInt16(TxtRoopCount.Value);

                // 実行に必要なパラメータオブジェクトを生成
                ImageParameter param = new ImageParameter(
                    frameRate: decimal.ToInt32(TxtFrameRate.Value),
                    rotateAmountList: movingAngleList,
                    centerPoint: changeCenter,
                    isChangeCanvasSize: isChangeCanvasSize,
                    canvasSize: changeCanvasSize,
                    isRotateToEnd: ChkRotateToEnd.Checked,
                    isRoop: ChkRoop.Checked,
                    roopCount: roopCount,
                    isPreview: isPreview,
                    isOutputPng: MenuItemOutputPng.Checked);

                // 実行
                bool result = SpinImage.CreateRotateGif(
                    image: ImageData,
                    parameter: param,
                    savePath: savePath,
                    previewAction: (image) => Invoke((MethodInvoker)(() => RefreshImage(image))),
                    progressAction: (progressValue) => Invoke((MethodInvoker)(() => StepProgressBar(progressValue))));

                // 実行結果を返す（正常：True、中断：False）
                return result;
            }
            catch (Exception ex)
            {
                // 下記の例外が発生する可能性がある
                // ExternalException
                // ・画像を回転させた画像データが正しくないイメージ形式の場合に発生
                // UnauthorizedAccessException
                // ・Gifの保存先のパスと同名の隠しファイル等のアクセスできないファイルが
                // 　既に存在している場合に発生
                // ・呼び出し元に、必要なアクセス許可がない場合に発生
                // SecurityException
                // ・呼び出し元に、必要なアクセス許可がない場合に発生
                // IOException
                // ・I/O エラーが発生した場合に発生
                // SpinTheImageException
                // ・Gifを作成する過程で生成したPngファイルを保存するディレクトリ名の生成において、
                // 　生成したディレクトリと同じパスのディレクトリが既に存在しており新しいディレクトリの作成が行えない場合に発生
                // 　（何度かディレクトリの生成を行うがその全てにおいて同じパスのディレクトリが既に存在している場合のみ発生）
                // GifEncoderException
                // ・Gifデータへのエンコードに失敗した場合に発生
                if (ex is ExternalException
                    || ex is UnauthorizedAccessException
                    || ex is SecurityException
                    || ex is IOException
                    || ex is SpinTheImageException
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
        /// 画像の表示を更新する
        /// </summary>
        /// <param name="image">更新する画像</param>
        private void RefreshImage(Image image)
        {
            Image beforeImage = PictureBoxPreview.Image;
            PictureBoxPreview.Image = new Bitmap(image);
            beforeImage?.Dispose();
            beforeImage = null;
            Refresh();
        }

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
