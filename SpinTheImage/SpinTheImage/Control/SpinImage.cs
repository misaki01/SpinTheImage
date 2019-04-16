namespace SpinTheImage.Control
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.Globalization;
    using System.IO;
    using System.Threading;

    using MisaCommon.Modules;
    using MisaCommon.Utility;
    using MisaCommon.Utility.StaticMethod;

    /// <summary>
    /// 画像を回転させる、Gifを作成する処理クラス
    /// </summary>
    public static class SpinImage
    {
        #region クラス変数・定数

        /// <summary>
        /// Pngファイルを保存するフォルダの名称
        /// {0}：年月日時分秒、
        /// {1}：通番（年月日時分秒が重複した場合に付与する通番）
        /// </summary>
        /// <remarks>
        /// Pngファイルを保存するフォルダの名称の定義
        /// {0}：年月日時分秒を設定（yyyyMMddHHmmss）
        /// {1}：通番（年月日時分秒が重複した場合に付与する通番：‗XXX）
        /// </remarks>
        private const string PngOutputFolderNameFormat = "OutputPng_{0}{1}";

        #endregion

        #region プロパティ

        /// <summary>
        /// 中断フラグを取得・設定する
        /// 処理を途中で中断する場合は：True、中断しない場合は：False
        /// </summary>
        private static bool IsStop { get; set; } = true;

        #endregion

        #region メソッド

        #region 回転するGifを生成

        /// <summary>
        /// 回転するGifを生成する
        /// </summary>
        /// <param name="image">生成の元となる画像</param>
        /// <param name="parameter">生成に使用する各種パラメータ</param>
        /// <param name="savePath">生成したGifの保存先のパス</param>
        /// <exception cref="ArgumentNullException">
        /// 引数が以下の場合に発生する
        /// ・生成の元となる画像（<paramref name="image"/>）がNULLの場合
        /// ・生成に使用する各種パラメータ（<paramref name="parameter"/>）がNULLの場合
        /// ・生成に使用する各種パラメータ（<paramref name="parameter"/>）において、
        /// 　1フレームで移動する角度のリスト（<see cref="ImageParameter.RotateAmountListPerFrame"/>）が
        /// 　NULLの場合
        /// ・Gifファイルを保存する場合（※1）で、引数の生成したGifの保存先のパス
        ///  （<paramref name="savePath"/>）がNULLの場合
        /// ※1：生成に使用する各種パラメータ（<paramref name="parameter"/>）において、
        /// 　 　プレビューモードかのフラグ（<see cref="ImageParameter.IsPreview"/>）が True の場合
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// 引数の生成に使用する各種パラメータ（<paramref name="parameter"/>）において、
        /// フレームレート（<see cref="ImageParameter.FrameRate"/>）が0以下の場合に発生
        /// </exception>
        /// <exception cref="ArgumentException">
        /// 引数の生成したGifの保存先のパス（<paramref name="savePath"/>）が空文字
        /// または、<see cref="Path.GetInvalidPathChars"/> で定義される無効な文字が含まれている場合に発生
        /// </exception>
        /// <exception cref="NotSupportedException">
        /// 引数の生成したGifの保存先のパス（<paramref name="savePath"/>）に、
        /// ドライブラベル（C:\）の一部ではないコロン文字（:）が含まれている場合に発生
        /// </exception>
        /// <exception cref="IOException">
        /// 下記の場合に発生
        /// 1. 引数のGifの保存先のパス（<paramref name="savePath"/>）が示すディレクトリが正しくない場合
        /// 　（マップされていないドライブ名が指定されている場合等）
        /// 　[<see cref="DirectoryNotFoundException"/>]
        /// 2. 引数のGifの保存先のパス（<paramref name="savePath"/>）がシステム定義の最大長を超えている場合
        /// 　（Windowsでは、パスは248文字以下、ファイル名は260文字以下にする必要がある）
        /// 　[<see cref="PathTooLongException"/>]
        /// 3. I/O エラーが発生した場合
        /// 　[<see cref="IOException"/>]
        /// </exception>
        /// <exception cref="UnauthorizedAccessException">
        /// 以下の場合に発生する
        /// ・引数の生成したGifの保存先のパス（<paramref name="savePath"/>）において、
        /// 　隠しファイル等のアクセスできないファイルが既に存在している場合に発生
        /// ・呼び出し元に、必要なアクセス許可がない場合に発生
        /// </exception>
        /// <exception cref="System.Security.SecurityException">
        /// 呼び出し元に、必要なアクセス許可がない場合に発生
        /// </exception>
        /// <exception cref="System.Runtime.InteropServices.ExternalException">
        /// 引数の生成の元となる画像（<paramref name="image"/>）を、
        /// 回転させた画像データが正しくないイメージ形式の場合に発生
        /// </exception>
        /// <exception cref="Exception">
        /// 引数の生成の元となる画像（<paramref name="image"/>）から <see cref="Bitmap"/> オブジェクトが
        /// 生成できない場合に発生
        /// （インデックス付きピクセル形式かの形式が定義されていない場合等）
        /// </exception>
        /// <exception cref="SpinTheImageException">
        /// Gifを作成する過程で生成したPngファイルを保存するディレクトリ名の生成において、
        /// 生成したディレクトリと同じパスのディレクトリが既に存在しており
        /// 新しいディレクトリの作成が行えない場合に発生
        /// （何度かディレクトリの生成を行うがその全てにおいて同じパスのディレクトリが、
        /// 　既に存在している場合のみ発生）
        /// </exception>
        /// <exception cref="MisaCommon.Exceptions.GifEncoderException">
        /// Gifデータへのエンコードに失敗した場合に発生
        /// </exception>
        /// <returns>処理が成功した場合：True、中断した場合：False</returns>
        public static bool CreateRotateGif(
            Image image,
            ImageParameter parameter,
            string savePath)
        {
            return CreateRotateGif(image, parameter, savePath, null, null);
        }

        /// <summary>
        /// 回転するGifを生成する
        /// </summary>
        /// <param name="image">
        /// 生成の元となる画像
        /// </param>
        /// <param name="parameter">
        /// 生成に使用する各種パラメータ
        /// </param>
        /// <param name="savePath">
        /// 生成したGifの保存先のパス
        /// </param>
        /// <param name="previewAction">
        /// プレビュー表示処理を行うメソッド
        /// </param>
        /// <param name="progressAction">
        /// 進捗率の表示を行うメソッド（当メソッドでは0～100%の値を設定する）
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// 引数が以下の場合に発生する
        /// ・生成の元となる画像（<paramref name="image"/>）がNULLの場合
        /// ・生成に使用する各種パラメータ（<paramref name="parameter"/>）がNULLの場合
        /// ・生成に使用する各種パラメータ（<paramref name="parameter"/>）において、
        /// 　1フレームで移動する角度のリスト（<see cref="ImageParameter.RotateAmountListPerFrame"/>）が
        /// 　NULLの場合
        /// ・Gifファイルを保存する場合（※1）で、引数の生成したGifの保存先のパス
        ///  （<paramref name="savePath"/>）がNULLの場合
        /// ※1：生成に使用する各種パラメータ（<paramref name="parameter"/>）において、
        /// 　 　プレビューモードかのフラグ（<see cref="ImageParameter.IsPreview"/>）が True の場合
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// 引数の生成に使用する各種パラメータ（<paramref name="parameter"/>）において、
        /// フレームレート（<see cref="ImageParameter.FrameRate"/>）が0以下の場合に発生
        /// </exception>
        /// <exception cref="ArgumentException">
        /// 引数の生成したGifの保存先のパス（<paramref name="savePath"/>）が空文字
        /// または、<see cref="Path.GetInvalidPathChars"/> で定義される無効な文字が含まれている場合に発生
        /// </exception>
        /// <exception cref="NotSupportedException">
        /// 引数の生成したGifの保存先のパス（<paramref name="savePath"/>）に、
        /// ドライブラベル（C:\）の一部ではないコロン文字（:）が含まれている場合に発生
        /// </exception>
        /// <exception cref="IOException">
        /// 下記の場合に発生
        /// 1. 引数のGifの保存先のパス（<paramref name="savePath"/>）が示すディレクトリが正しくない場合
        /// 　（マップされていないドライブ名が指定されている場合等）
        /// 　[<see cref="DirectoryNotFoundException"/>]
        /// 2. 引数のGifの保存先のパス（<paramref name="savePath"/>）がシステム定義の最大長を超えている場合
        /// 　（Windowsでは、パスは248文字以下、ファイル名は260文字以下にする必要がある）
        /// 　[<see cref="PathTooLongException"/>]
        /// 3. I/O エラーが発生した場合
        /// 　[<see cref="IOException"/>]
        /// </exception>
        /// <exception cref="UnauthorizedAccessException">
        /// 以下の場合に発生する
        /// ・引数の生成したGifの保存先のパス（<paramref name="savePath"/>）において、
        /// 　隠しファイル等のアクセスできないファイルが既に存在している場合に発生
        /// ・呼び出し元に、必要なアクセス許可がない場合に発生
        /// </exception>
        /// <exception cref="System.Security.SecurityException">
        /// 呼び出し元に、必要なアクセス許可がない場合に発生
        /// </exception>
        /// <exception cref="System.Runtime.InteropServices.ExternalException">
        /// 引数の生成の元となる画像（<paramref name="image"/>）を、
        /// 回転させた画像データが正しくないイメージ形式の場合に発生
        /// </exception>
        /// <exception cref="Exception">
        /// 引数の生成の元となる画像（<paramref name="image"/>）から <see cref="Bitmap"/> オブジェクトが
        /// 生成できない場合に発生
        /// （インデックス付きピクセル形式かの形式が定義されていない場合等）
        /// </exception>
        /// <exception cref="SpinTheImageException">
        /// Gifを作成する過程で生成したPngファイルを保存するディレクトリ名の生成において、
        /// 生成したディレクトリと同じパスのディレクトリが既に存在しており
        /// 新しいディレクトリの作成が行えない場合に発生
        /// （何度かディレクトリの生成を行うがその全てにおいて同じパスのディレクトリが、
        /// 　既に存在している場合のみ発生）
        /// </exception>
        /// <exception cref="MisaCommon.Exceptions.GifEncoderException">
        /// Gifデータへのエンコードに失敗した場合に発生
        /// </exception>
        /// <returns>処理が成功した場合：True、中断した場合：False</returns>
        public static bool CreateRotateGif(
            Image image,
            ImageParameter parameter,
            string savePath,
            Action<Image> previewAction,
            Action<int> progressAction)
        {
            // NULLチェック
            if (image == null)
            {
                throw new ArgumentNullException(nameof(image));
            }
            else if (parameter == null)
            {
                throw new ArgumentNullException(nameof(parameter));
            }
            else if (!parameter.IsPreview && savePath == null)
            {
                throw new ArgumentNullException(nameof(savePath));
            }

            // 中断フラグを OFF にする
            IsStop = false;

            // Gifを作成する過程で生成したPngファイルを保存するディレクトリパスを取得
            // （Pngファイルを出力する場合のみ取得する）
            string pngDirectoryPath = null;
            if (parameter.IsOutputPng && !parameter.IsPreview)
            {
                pngDirectoryPath = GetPngOutputDirectoryPath(savePath);
            }

            // 回転情報リストを生成
            IList<RotateInfo> rotateInfos = CreateRotateInfoList(
                frameRate: parameter.FrameRate,
                movingAngleList: parameter.RotateAmountListPerFrame,
                isRotateToEnd: parameter.IsRotateToEnd);

            // 回転させる画像の元データを生成
            Func<Image, Image> createBaceImage = GetCreateBaceImageFunc(
                    isChangeCanvasSize: parameter.IsChangeCanvasSize,
                    changeSize: parameter.CanvasSize,
                    changeCenterPoint: parameter.CenterPoint);
            using (Image baceImage = createBaceImage(image))
            {
                // 画像を表示
                previewAction?.Invoke(baceImage);

                // 進捗を10％
                progressAction?.Invoke(10);

                // 回転させた画像データのGifファイルを作成する
                CreateRotateGifFile(
                    baceImage: baceImage,
                    rotateInfos: rotateInfos,
                    isRoop: parameter.IsRoop,
                    roopCount: parameter.RoopCount,
                    isPreview: parameter.IsPreview,
                    isOutputPng: parameter.IsOutputPng,
                    savePath: savePath,
                    pngDirectoryPath: pngDirectoryPath,
                    previewAction: previewAction,
                    progressAction: progressAction);

                // 中断しているか判定
                if (IsStop)
                {
                    // 中断なので False を返却する
                    return false;
                }
            }

            // 進捗を100％
            progressAction?.Invoke(100);

            // 正常終了 True を返す
            return true;
        }

        #endregion

        #region Gif生成処理を中断

        /// <summary>
        /// Gif生成処理を中断する
        /// </summary>
        public static void Stop()
        {
            IsStop = true;
        }

        #endregion

        #region キャンパスの変更設定を適用させた回転処理の元となる画像データを生成する機能を取得

        /// <summary>
        /// キャンパスの変更設定を適用させた回転処理の元となる画像データを生成する機能を取得する
        /// </summary>
        /// <param name="isChangeCanvasSize">
        /// キャンパスサイズを変更するかのフラグ
        /// </param>
        /// <param name="changeSize">
        /// 変更するキャンパスサイズ（NULLを指定した場合は対角線の長さに拡大）
        /// </param>
        /// <param name="changeCenterPoint">
        /// 変更する中心位置（NULLを指定した場合は中心位置の変更はしない）
        /// </param>
        /// <returns>
        /// キャンパスの変更設定を適用させた回転処理の元となる画像データを生成する機能
        /// </returns>
        public static Func<Image, Image> GetCreateBaceImageFunc(
            bool isChangeCanvasSize, Size? changeSize, Point? changeCenterPoint)
        {
            // 回転させる画像の元データを生成するためのファンクションを生成
            Func<Image, Image> createBaceImage;
            if (isChangeCanvasSize && changeCenterPoint.HasValue)
            {
                // サイズ変更：有、中心位置変更：有の場合
                // ⇒キャンパスサイズ、中心位置を変更した画像データを使用
                if (changeSize.HasValue)
                {
                    createBaceImage = (image)
                        => ImageTransform.ChangeCanvas(image, changeSize.Value, changeCenterPoint.Value);
                }
                else
                {
                    // 変更するサイズに指定がない場合は、中心点を考慮した対角線の長さに拡大する
                    createBaceImage = (image)
                        => ImageTransform.ChangeCanvasToDiagonalSize(image, changeCenterPoint.Value);
                }
            }
            else if (isChangeCanvasSize && !changeCenterPoint.HasValue)
            {
                // サイズ変更：有、中心位置変更：無の場合
                // ⇒キャンパスサイズのみを変更した画像データを使用
                if (changeSize.HasValue)
                {
                    createBaceImage = (image) => ImageTransform.ChangeCanvas(image, changeSize.Value);
                }
                else
                {
                    // 変更するサイズに指定がない場合は対角線の長さに拡大する
                    createBaceImage = (image) => ImageTransform.ChangeCanvasToDiagonalSize(image);
                }
            }
            else if (!isChangeCanvasSize && changeCenterPoint.HasValue)
            {
                // サイズ変更：無、中心位置変更：有の場合
                // ⇒中心位置のみを変更した画像データを使用
                createBaceImage = (image) => ImageTransform.ChangeCanvas(image, changeCenterPoint.Value);
            }
            else
            {
                // サイズ変更：無、中心位置変更：無の場合
                // ⇒引数の画像データをそのまま使用
                createBaceImage = (image) => new Bitmap(image, image.Size);
            }

            // 生成したファンクションを返す
            return createBaceImage;
        }

        #endregion

        #endregion

        #region プライベートメソッド

        #region Gifを作成する過程で生成したPngファイルを保存するディレクトリを取得

        /// <summary>
        /// Gifを作成する過程で生成したPngファイルを保存するディレクトリを取得する
        /// </summary>
        /// <param name="savePath">Gifの保存先のパス</param>
        /// <exception cref="ArgumentNullException">
        /// 引数のGifの保存先のパス（<paramref name="savePath"/>）がNULLの場合に発生
        /// </exception>
        /// <exception cref="ArgumentException">
        /// 引数のGifの保存先のパス（<paramref name="savePath"/>）が空文字
        /// または、<see cref="Path.GetInvalidPathChars"/> で定義される無効な文字が含まれている場合に発生
        /// </exception>
        /// <exception cref="PathTooLongException">
        /// 引数のGifの保存先のパス（<paramref name="savePath"/>）がシステム定義の
        /// 最大長を超えている場合に発生
        /// （Windowsでは、パスは 248 文字未満、ファイル名は 260 文字未満にする必要がある）
        /// </exception>
        /// <exception cref="SpinTheImageException">
        /// 生成したディレクトリと同じパスのディレクトリが既に存在しており、
        /// 新しいディレクトリの作成が行えない場合に発生
        /// （何度かディレクトリの生成を行うが、
        /// 　その全てにおいて同じパスのディレクトリが既に存在している場合のみ発生）
        /// </exception>
        /// <returns>保存先のディレクトリパス</returns>
        private static string GetPngOutputDirectoryPath(string savePath)
        {
            // NULLチェック
            if (savePath == null)
            {
                throw new ArgumentNullException(nameof(savePath));
            }

            // 引数から保存先のディレクトリを取得
            string saveDirectory = Path.GetDirectoryName(savePath);

            // 作成するディレクトリ名に設定する年月日時分秒を取得
            string dateTime = DateTime.Now.ToString("yyyyMMddHHmmss", CultureInfo.InvariantCulture);

            // 既にフォルダがある場合を考慮し重複しない名称になるまでループ
            int count = 0;
            string directoryPath;
            while (true)
            {
                // カウントが10より大きくなったら諦めて例外を発生させる
                if (count > 10)
                {
                    throw new SpinTheImageException(
                        Properties.Resources.CreateGifErrorNotGenerateDirectoryName);
                }

                // 通番名を取得
                string serialNum = count > 0
                    ? count.ToString("_000", CultureInfo.InvariantCulture) : string.Empty;

                // 作成するフォルダ名を生成
                string folderName = string.Format(
                    CultureInfo.InvariantCulture, PngOutputFolderNameFormat, dateTime, serialNum);

                // 作成するフォルダパスを生成
                string path = Path.Combine(saveDirectory, folderName);

                // フォルダが存在しない場合、処理をぬける
                if (!Directory.Exists(path))
                {
                    directoryPath = path;
                    break;
                }

                // カウントをインクリメント
                count++;
            }

            // 保存先のディレクトリを返却
            return directoryPath;
        }

        #endregion

        #region 回転情報リストを作成

        /// <summary>
        /// 回転情報リストを作成する
        /// </summary>
        /// <param name="frameRate">フレームレート</param>
        /// <param name="movingAngleList">移動量リスト</param>
        /// <param name="isRotateToEnd">最後まで回転するかのフラグ（元の位置に戻るまで回転するか）</param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// 引数のフレームレート（<paramref name="frameRate"/>）が0以下の場合に発生
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// 引数の移動量リスト（<paramref name="movingAngleList"/>）がNULLの場合に発生
        /// </exception>
        /// <returns>回転情報リスト</returns>
        private static IList<RotateInfo> CreateRotateInfoList(
            int frameRate, IList<float> movingAngleList, bool isRotateToEnd)
        {
            // 引数のチェック
            if (frameRate <= 0)
            {
                throw new ArgumentOutOfRangeException(
                    paramName: nameof(frameRate),
                    actualValue: frameRate,
                    message: string.Format(
                        CultureInfo.InvariantCulture,
                        CommonMessage.ArgumentOutOfRangeExceptionMessageFormatOrLess,
                        0));
            }
            else if (movingAngleList == null)
            {
                throw new ArgumentNullException(nameof(movingAngleList));
            }

            // 戻り値のリストを生成
            IList<RotateInfo> rotateInfoList = new List<RotateInfo>();

            // 始めの画像に対する情報を追加
            // 始めの画像なので回転量は0
            float angle = 0;

            // フレームレートからディレイを計算
            int delay = GifEncoder.GifDelayUnit / frameRate;

            // 計算したディレイの余りを次の計算に使用するため保持
            int remainder = GifEncoder.GifDelayUnit % frameRate;

            // 始めの画像に対する情報を追加
            rotateInfoList.Add(new RotateInfo(angle, (short)delay));

            // 移動量リストに応じた移動量とディレイを回転情報リストに追加する
            foreach (float movingAngle in movingAngleList)
            {
                // 回転量、ディレイを計算し追加する
                angle = (angle + movingAngle) % 360;
                delay = (GifEncoder.GifDelayUnit + remainder) / frameRate;
                remainder = (GifEncoder.GifDelayUnit + remainder) % frameRate;
                rotateInfoList.Add(new RotateInfo(angle, (short)delay));
            }

            // 最後まで回転するか
            // （元の位置に戻るまで回転するか）のフラグが立っている場合、移動量0のデータを追加する
            if (isRotateToEnd)
            {
                delay = (GifEncoder.GifDelayUnit + remainder) / frameRate;
                rotateInfoList.Add(new RotateInfo(0, (short)delay));
            }

            // 生成した回転情報リストを返却
            return rotateInfoList;
        }

        #endregion

        #region 回転させた画像データのGifファイルを作成

        /// <summary>
        /// 回転させた画像データのGifファイルを作成する
        /// </summary>
        /// <param name="baceImage">
        /// 回転させる元となる画像データ
        /// </param>
        /// <param name="rotateInfos">
        /// 回転情報リスト
        /// </param>
        /// <param name="isRoop">
        /// ループするかのフラグ
        /// </param>
        /// <param name="roopCount">
        /// ループする場合のループ回数（0以下場合は無限にループする）
        /// </param>
        /// <param name="isPreview">
        /// プレビューモードかのフラグ
        /// </param>
        /// <param name="isOutputPng">
        /// Gifを作成する過程で生成したPngファイルを保存するかのフラグ
        /// </param>
        /// <param name="savePath">
        /// 生成したGifの保存先のパス
        /// </param>
        /// <param name="pngDirectoryPath">
        /// Gifを作成する過程で生成したPngファイルを保存するディレクトリパス
        /// </param>
        /// <param name="previewAction">
        /// プレビュー表示処理を行うメソッド
        /// </param>
        /// <param name="progressAction">
        /// 進捗率の表示を行うメソッド（当メソッドでは0～100%の値を設定する）
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// 引数が以下の場合に発生する
        /// ・引数の回転させる元となる画像データ（<paramref name="baceImage"/>）がNULLの場合
        /// ・引数の回転情報リスト（<paramref name="rotateInfos"/>）がNULLの場合
        /// ・Gifファイルを保存する場合（※1）で、引数の生成したGifの保存先のパス
        /// 　（<paramref name="savePath"/>）がNULLの場合
        /// ・Gifを作成する過程で生成したPngファイルを保存する場合（※2）で、
        /// 　引数のGifを作成する過程で生成したPngファイルを保存するディレクトリパス
        /// 　（<paramref name="pngDirectoryPath"/>）がNULLの場合
        /// ※1：引数のプレビューモードかのフラグ（<paramref name="isPreview"/>）が False の場合
        /// ※2：引数のプレビューモードかのフラグ（<paramref name="isPreview"/>）が False の場合
        /// 　 　かつ、引数のGifを作成する過程で生成したPngファイルを保存するかのフラグ
        /// 　 　（<paramref name="isOutputPng"/>）が True の場合
        /// </exception>
        /// <exception cref="ArgumentException">
        /// 以下の引数が空文字 または、<see cref="Path.GetInvalidPathChars"/> で定義される
        /// 無効な文字が含まれている場合に発生
        /// ・生成したGifの保存先のパス（<paramref name="savePath"/>）
        /// ・Gifを作成する過程で生成したPngファイルを保存するディレクトリパス
        /// 　（<paramref name="pngDirectoryPath"/>）
        /// </exception>
        /// <exception cref="NotSupportedException">
        /// 以下の引数にドライブラベル（C:\）の一部ではないコロン文字（:）が含まれている場合
        /// ・生成したGifの保存先のパス（<paramref name="savePath"/>）
        /// ・Gifを作成する過程で生成したPngファイルを保存するディレクトリパス
        /// 　（<paramref name="pngDirectoryPath"/>）
        /// </exception>
        /// <exception cref="IOException">
        /// 下記の場合に発生
        /// 1. 以下の引数が示すディレクトリが正しくない場合
        /// 　（マップされていないドライブ名が指定されている場合等）
        /// 　・生成したGifの保存先のパス（<paramref name="savePath"/>）
        /// 　・Gifを作成する過程で生成したPngファイルを保存するディレクトリパス
        /// 　　（<paramref name="pngDirectoryPath"/>）
        /// 　[<see cref="DirectoryNotFoundException"/>]
        /// 2. 以下の引数がシステム定義の最大長を超えている場合
        /// 　（Windowsでは、パスは248文字以下、ファイル名は260文字以下にする必要がある）
        /// 　・生成したGifの保存先のパス（<paramref name="savePath"/>）
        /// 　・Gifを作成する過程で生成したPngファイルを保存するディレクトリパス
        /// 　　（<paramref name="pngDirectoryPath"/>）
        /// 　[<see cref="PathTooLongException"/>]
        /// 3. 以下の場合に発生する
        /// 　・Gifを作成する過程で生成したPngファイルを保存するディレクトリパス
        /// 　　（<paramref name="pngDirectoryPath"/>）がファイル名となっている または、
        /// 　　　指定されているネットワーク名が不明の場合
        /// 　・I/O エラーが発生した場合
        /// 　[<see cref="IOException"/>]
        /// </exception>
        /// <exception cref="UnauthorizedAccessException">
        /// 以下の場合に発生する
        /// ・生成したGifの保存先のパス（<paramref name="savePath"/>）において、
        /// 　隠しファイル等のアクセスできないファイルが既に存在している場合に発生
        /// ・呼び出し元に、必要なアクセス許可がない場合に発生
        /// </exception>
        /// <exception cref="System.Security.SecurityException">
        /// 呼び出し元に、必要なアクセス許可がない場合に発生
        /// </exception>
        /// <exception cref="System.Runtime.InteropServices.ExternalException">
        /// 引数の回転させる元となる画像データ（<paramref name="baceImage"/>）を回転させた画像データが、
        /// 正しくないイメージ形式の場合に発生
        /// </exception>
        /// <exception cref="Exception">
        /// 引数の回転させる元となる画像データ（<paramref name="baceImage"/>）から
        /// <see cref="Bitmap"/> オブジェクトが生成できない場合に発生
        /// （インデックス付きピクセル形式かの形式が定義されていない場合等）
        /// </exception>
        /// <exception cref="MisaCommon.Exceptions.GifEncoderException">
        /// Gifデータへのエンコードに失敗した場合に発生
        /// </exception>
        private static void CreateRotateGifFile(
            Image baceImage,
            IList<RotateInfo> rotateInfos,
            bool isRoop,
            short roopCount,
            bool isPreview,
            bool isOutputPng,
            string savePath,
            string pngDirectoryPath,
            Action<Image> previewAction,
            Action<int> progressAction)
        {
            // NULLチェック
            if (baceImage == null)
            {
                throw new ArgumentNullException(nameof(baceImage));
            }
            else if (rotateInfos == null)
            {
                throw new ArgumentNullException(nameof(rotateInfos));
            }
            else if (!isPreview && savePath == null)
            {
                throw new ArgumentNullException(nameof(savePath));
            }
            else if (!isPreview && isOutputPng && pngDirectoryPath == null)
            {
                throw new ArgumentNullException(nameof(pngDirectoryPath));
            }

            // Gifファイルの保存先のファイルパスを設定する
            string saveGifFilePath = savePath;

            // プレビューモードでない場合
            // 拡張子が gif か判定し、gif でなければ .gif を追加する
            if (!isPreview)
            {
                string extension = Path.GetExtension(savePath);
                if (!extension.ToUpperInvariant().Equals(".gif".ToUpperInvariant(), StringComparison.Ordinal))
                {
                    // 拡張子がGifの形式でない場合、
                    // Gifの保存先のパスに「.gif」の拡張子を追加する
                    saveGifFilePath = savePath + ".gif";
                }
            }

            // Gifエンコーダーを宣言
            GifEncoder gifEncoder = null;
            try
            {
                // プレビューモードでない場合、Gifエンコーダーを生成する
                if (!isPreview)
                {
                    gifEncoder = new GifEncoder(saveGifFilePath, isRoop, roopCount)
                    {
                        // メモリ節約のため都度保存モードを ON にする
                        IsEachTimeSave = true
                    };
                }

                // ループ処理で使用するストップウォッチオブジェクトを生成
                Stopwatch stopwatch = new Stopwatch();

                // 回転情報リストでループを行い回転させた画像を作成し、
                // Gif形式にエンコードしていく
                int count = 1;
                foreach (RotateInfo rotateInfo in rotateInfos)
                {
                    // 中断しているか判定
                    if (IsStop)
                    {
                        // 処理を中断する
                        return;
                    }

                    // ストップウオッチをスタート
                    stopwatch.Start();

                    // 回転した画像データを生成
                    using (Image rotateImage = ImageTransform.RotateImage(baceImage, rotateInfo.Angle))
                    {
                        // 画像を表示
                        previewAction?.Invoke(rotateImage);

                        // プレビュー処理でない場合、ファイルの生成に関する処理を行う
                        if (!isPreview)
                        {
                            // Gifエンコーダにデータを追加する
                            short delay = rotateInfo.Delay < 0 ? (short)0 : rotateInfo.Delay;
                            gifEncoder.AddImage(rotateImage, delay);

                            // Gifを作成する過程で生成したPngファイルを保存する場合、保存処理を行う
                            if (isOutputPng)
                            {
                                SavePng(rotateImage, pngDirectoryPath, savePath, count);
                            }
                        }
                    }

                    // ストップウオッチをストップ
                    stopwatch.Stop();

                    // 経過時間がディレイ（10ミリ秒単位）に満たない場合はその分待つ
                    int sleepTime = (rotateInfo.Delay * 10) - (int)stopwatch.ElapsedMilliseconds;
                    if (sleepTime > 0)
                    {
                        Thread.Sleep(sleepTime);
                    }

                    // ストップウオッチをリセット
                    stopwatch.Reset();

                    // 進捗を進める
                    // （ループ前後の処理で20％とっているため、ループ処理では残りの80％に対する進捗率を出す）
                    int progressRate = (int)Math.Truncate(count / (decimal)rotateInfos.Count * 80);

                    // 進捗を表示
                    progressAction?.Invoke(progressRate + 10);

                    // カウントをインクリメント
                    count++;
                }

                // 進捗を90％
                progressAction?.Invoke(90);

                // 生成したGifデータの保存を行う
                gifEncoder?.Save();
            }
            finally
            {
                // Gifエンコーダを破棄する
                gifEncoder?.Dispose();
            }
        }

        #endregion

        #region Gifを作成する過程で生成したPngファイルを保存

        /// <summary>
        /// Gifを作成する過程で生成したPngファイルを保存する
        /// </summary>
        /// <param name="image">保存する画像データ</param>
        /// <param name="saveDirectory">保存先のディレクトリ</param>
        /// <param name="saveGifFilePath">Gifの保存先パス</param>
        /// <param name="serialNum">通番</param>
        /// <exception cref="ArgumentNullException">
        /// 以下の引数がNULLの場合に発生
        /// ・保存する画像データ（<paramref name="image"/>）
        /// ・保存先のディレクトリ（<paramref name="saveDirectory"/>）
        /// ・Gifの保存先パス（<paramref name="saveGifFilePath"/>）
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// 通番が0以下の場合に発生
        /// </exception>
        /// <exception cref="ArgumentException">
        /// 以下の引数が空文字 または、<see cref="Path.GetInvalidPathChars"/> で定義される
        /// 無効な文字が含まれている場合に発生
        /// ・保存先のディレクトリ（<paramref name="saveDirectory"/>）
        /// ・Gifの保存先パス（<paramref name="saveGifFilePath"/>）
        /// </exception>
        /// <exception cref="NotSupportedException">
        /// 引数の保存先のディレクトリ（<paramref name="saveDirectory"/>）に
        /// ドライブラベル（C:\）の一部ではないコロン文字（:）が含まれている場合に発生
        /// </exception>
        /// <exception cref="IOException">
        /// 下記の場合に発生
        /// ・引数の保存先のディレクトリ（<paramref name="saveDirectory"/>）が正しくない場合
        /// 　[<see cref="DirectoryNotFoundException"/>]
        ///  （マップされていないドライブ等）
        /// ・保存先のディレクトリ（<paramref name="saveDirectory"/>）、
        /// 　Gifの保存先パス（<paramref name="saveGifFilePath"/>）コンフィグの保存パスが、
        /// 　システム定義の最大長を超えている場合
        /// 　[<see cref="PathTooLongException"/>]
        /// 　（Windowsでは、パスは248文字以下、ファイル名は260文字以下にする必要がある）
        /// ・引数の保存先のディレクトリ（<paramref name="saveDirectory"/>）がファイル名となっている
        /// 　または、指定されているネットワーク名が不明の場合
        /// 　[<see cref="IOException"/>]
        /// </exception>
        /// <exception cref="UnauthorizedAccessException">
        /// 呼び出し元に、必要なアクセス許可がない場合に発生
        /// </exception>
        /// <exception cref="System.Runtime.InteropServices.ExternalException">
        /// 引数のイメージが、誤ったイメージ形式で保存された場合
        /// または、イメージから作成された同じファイルに保存された場合に発生
        /// </exception>
        private static void SavePng(
            Image image, string saveDirectory, string saveGifFilePath, int serialNum)
        {
            // 引数のチェック
            if (image == null)
            {
                throw new ArgumentNullException(nameof(image));
            }
            else if (saveDirectory == null)
            {
                throw new ArgumentNullException(nameof(saveDirectory));
            }
            else if (saveGifFilePath == null)
            {
                throw new ArgumentNullException(nameof(saveGifFilePath));
            }
            else if (serialNum <= 0)
            {
                throw new ArgumentOutOfRangeException(
                    paramName: nameof(serialNum),
                    actualValue: serialNum,
                    message: string.Format(
                        CultureInfo.InvariantCulture,
                        CommonMessage.ArgumentOutOfRangeExceptionMessageFormatOrLess,
                        0));
            }

            // ファイル名生成
            string serialNumText = serialNum.ToString("_00000", CultureInfo.InvariantCulture);
            string fileName = Path.GetFileNameWithoutExtension(saveGifFilePath) + serialNumText + ".png";

            // 保存パスを生成
            string filePath = Path.Combine(saveDirectory, fileName);

            // 保存先のディレクトリが存在しない場合はディレクトリを作成
            if (!Directory.Exists(saveDirectory))
            {
                Directory.CreateDirectory(saveDirectory);
            }

            // ファイルを保存
            image.Save(filePath, ImageFormat.Png);
        }

        #endregion

        #endregion

        #region 回転量情報を扱う内部クラス

        /// <summary>
        /// 回転量情報を扱うクラス
        /// </summary>
        private class RotateInfo
        {
            #region コンストラクタ

            /// <summary>
            /// コンストラクタ
            /// </summary>
            /// <param name="angle">回転させる角度</param>
            /// <param name="delay">1フレームあたりのディレイ（1/100秒単位）</param>
            public RotateInfo(float angle, short delay)
            {
                Angle = angle;
                Delay = delay;
            }

            #endregion

            #region プロパティ

            /// <summary>
            /// 回転させる角度
            /// </summary>
            public float Angle { get; }

            /// <summary>
            /// 1フレームあたりのディレイ（1/100秒単位）
            /// </summary>
            public short Delay { get; }

            #endregion
        }

        #endregion
    }
}
