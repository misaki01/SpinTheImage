namespace SpinTheImage.Control
{
    using System;
    using System.Runtime.Serialization;

    /// <summary>
    /// 画像回転に関する例外を扱う <see cref="Exception"/> の派生クラス
    /// </summary>
    [Serializable]
    public class SpinTheImageException : Exception
    {
        #region コンストラクタ

        /// <summary>
        /// デフォルトコンストラクタ
        /// 初期化を行う
        /// </summary>
        public SpinTheImageException()
            : base()
        {
        }

        /// <summary>
        /// コンストラクタ
        /// 引数を用いて初期化を行う
        /// </summary>
        /// <param name="message">例外メッセージ</param>
        public SpinTheImageException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// コンストラクタ
        /// 引数を用いて初期化を行う
        /// </summary>
        /// <param name="message">例外メッセージ</param>
        /// <param name="innerException">内包する例外</param>
        public SpinTheImageException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        /// <summary>
        /// コンストラクタ
        /// 引数のシリアル化したデータを用いて初期化を行う
        /// </summary>
        /// <param name="info">
        /// スローされている例外に関するシリアル化済みオブジェクトのデータを保持している
        /// <see cref="SerializationInfo"/> オブジェクト
        /// </param>
        /// <param name="context">
        /// 転送元または転送先についてのコンテキスト情報を含む <see cref="StreamingContext"/> オブジェクト
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// 引数の <paramref name="info"/> がNULLの場合に発生
        /// </exception>
        /// <exception cref="SerializationException">
        /// クラス名がNULL又は、<see cref="Exception.HResult"/> が 0 の場合に発生
        /// </exception>
        protected SpinTheImageException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        #endregion
    }
}
