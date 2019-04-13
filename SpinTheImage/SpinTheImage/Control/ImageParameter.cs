namespace SpinTheImage.Control
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Globalization;

    using MisaCommon.Utility;

    /// <summary>
    /// 画像を回転に関するパラメータを定義するクラス
    /// </summary>
    public class ImageParameter
    {
        #region コンストラクタ

        /// <summary>
        /// デフォルトコンストラクタ
        /// </summary>
        /// <param name="frameRate">
        /// フレームレート
        /// </param>
        /// <param name="rotateAmountList">
        /// 1フレームで移動する角度のリスト
        /// </param>
        /// <param name="centerPoint">
        /// 変更する中心位置
        /// （NULLを指定した場合、中心位置を変更しない）
        /// </param>
        /// <param name="isChangeCanvasSize">
        /// 画像のキャンパスサイズを変更するかのフラグ
        /// </param>
        /// <param name="canvasSize">
        /// 変更後のキャンパスサイズ
        /// （NULLを指定した場合、対角線の長さに拡大）
        /// </param>
        /// <param name="isRotateToEnd">
        /// 最後まで回転するかのフラグ（元の位置に戻るまで回転するか）
        /// </param>
        /// <param name="isRoop">
        /// 生成するGifがループするかのフラグ
        /// </param>
        /// <param name="roopCount">
        /// 生成するGifのループ回数（0を指定した場合は無限にループする）
        /// </param>
        /// <param name="isPreview">
        /// プレビューモードかのフラグ（ONにした場合はGifの生成処理は行わない）
        /// </param>
        /// <param name="isOutputPng">
        /// Gifを作成する過程で生成したPngファイルを保存するかのフラグ
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// 1フレームで移動する角度のリストがNULLの場合に発生
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// フレームレートが0以下の場合に発生
        /// </exception>
        public ImageParameter(
        int frameRate,
            IList<float> rotateAmountList,
            Point? centerPoint,
            bool isChangeCanvasSize,
            Size? canvasSize,
            bool isRotateToEnd,
            bool isRoop,
            short roopCount,
            bool isPreview,
            bool isOutputPng)
        {
            // 引数のチェック
            if (rotateAmountList == null)
            {
                throw new ArgumentNullException(nameof(rotateAmountList));
            }
            else if (frameRate <= 0)
            {
                throw new ArgumentOutOfRangeException(
                    paramName: nameof(frameRate),
                    actualValue: frameRate,
                    message: string.Format(
                        CultureInfo.InvariantCulture, CommonMessage.ArgumentOutOfRangeExceptionOrLess, 0));
            }

            FrameRate = frameRate;
            RotateAmountListPerFrame = rotateAmountList;
            CenterPoint = centerPoint;
            IsChangeCanvasSize = isChangeCanvasSize;
            CanvasSize = canvasSize;
            IsRotateToEnd = isRotateToEnd;
            IsRoop = isRoop;
            RoopCount = roopCount;
            IsPreview = isPreview;
            IsOutputPng = isOutputPng;
        }

        #endregion

        #region プロパティ

        /// <summary>
        /// フレームレート
        /// </summary>
        public int FrameRate { get; }

        /// <summary>
        /// 1フレームで移動する角度のリスト
        /// </summary>
        public IList<float> RotateAmountListPerFrame { get; }

        /// <summary>
        /// 変更する中心位置（NULLを指定した場合、中心位置を変更しない）
        /// </summary>
        public Point? CenterPoint { get; }

        /// <summary>
        /// 画像のキャンパスサイズを変更するかのフラグ
        /// </summary>
        public bool IsChangeCanvasSize { get; }

        /// <summary>
        /// 変更後のキャンパスサイズ（NULLを指定した場合、自動的に対角線の長さに拡大）
        /// </summary>
        public Size? CanvasSize { get; }

        /// <summary>
        /// 最後まで回転するかのフラグ（元の位置に戻るまで回転するか）
        /// </summary>
        public bool IsRotateToEnd { get; }

        /// <summary>
        /// 生成するGifがループするかのフラグ
        /// </summary>
        public bool IsRoop { get; }

        /// <summary>
        /// 生成するGifのループ回数（0を指定した場合は無限にループする）
        /// </summary>
        public short RoopCount { get; }

        /// <summary>
        /// プレビューモードかのフラグ（ONにした場合はGifの生成処理は行わない）
        /// </summary>
        public bool IsPreview { get; }

        /// <summary>
        /// Gifを作成する過程で生成したPngファイルを保存するかのフラグ
        /// </summary>
        public bool IsOutputPng { get; }

        #endregion

        #region メソッド

        /// <summary>
        /// 1フレームで移動する角度のリストを生成
        /// </summary>
        /// <param name="frameRate">フレームレート（0以下を指定した場合は例外発生）</param>
        /// <param name="second">秒数（0以下を指定した場合は例外発生）</param>
        /// <param name="initialSpeed">初期速度</param>
        /// <param name="accelerateRate">加速度</param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// フレームレート、または 秒数が0以下の場合に発生
        /// </exception>
        /// <returns>1フレームで移動する角度のリスト</returns>
        public static IList<float> GetRotateAmountList(
            int frameRate,
            float second,
            float initialSpeed,
            float accelerateRate)
        {
            // 引数のチェック
            if (frameRate <= 0)
            {
                throw new ArgumentOutOfRangeException(
                    paramName: nameof(frameRate),
                    actualValue: frameRate,
                    message: string.Format(
                        CultureInfo.InvariantCulture, CommonMessage.ArgumentOutOfRangeExceptionOrLess, 0));
            }
            else if (second <= 0)
            {
                throw new ArgumentOutOfRangeException(
                    paramName: nameof(second),
                    actualValue: second,
                    message: string.Format(
                        CultureInfo.InvariantCulture, CommonMessage.ArgumentOutOfRangeExceptionOrLess, 0));
            }

            // 生成するリストを生成
            IList<float> angleList = new List<float>();

            // 加速度の計算
            float secPerFrame = 1 / (float)frameRate;
            float beforeAngle = 0;
            for (int i = 0; i < Math.Truncate(frameRate * second); i++)
            {
                float time = secPerFrame * (i + 1);
                float rotateAmount = (initialSpeed * time) + (accelerateRate * time * time);
                angleList.Add(rotateAmount - beforeAngle);
                beforeAngle = rotateAmount;
            }

            // 生成するリストを返却
            return angleList;
        }

        #endregion
    }
}
