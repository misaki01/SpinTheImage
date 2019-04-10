# SpinTheImage の概要
任意の画像ファイルを回転アニメーションを行うGifに変換するツールです。

## ↓↓↓ から、  
![元の画像](https://github.com/misaki01/SpinTheImage/blob/image/%E9%A3%9F%E3%81%B9%E7%89%A9_%E3%81%99%E3%81%97.jpg)  
  
## ↓↓↓ を生成します。  
![変換後のGIF](https://github.com/misaki01/SpinTheImage/blob/image/%E9%A3%9F%E3%81%B9%E7%89%A9_%E3%81%99%E3%81%97.gif)  
  
（寿司を回したかったから作ったんや・・・）  
  
# 機能説明  
このツールは下記の機能を持っています。

1. 変換元の画像ファイル  
元となる画像ファイルは下記のフォーマットに対応しています。  
　BMP, JPEG, PNG, GIF  
　（テストしていないが動くと思われるもの：WMF, TIFF, ICO）
  
1. 回転に関するパラメータの設定機能
    1. GIFアニメーションのフレームレートの設定機能
    1. GIFアニメーションの秒数、回転の初速／加速度の設定機能
    1. フレーム単位の任意の回転角度設定機能
    1. 回転の中心の変更機能
    1. 画像のキャンパスサイズの設定機能
    1. GIFアニメーションのループ設定機能
    1. 作成したGIFアニメーションのフレーム単位の画像データを出力する機能

1. 画像データ連結機能  
（フォルダ内に存在する画像データを順番に結合してGifアニメーションに変換する機能）  
  
具体的な説明は下記のURLの動画を参照してください。  
[ニコニコ動画：画像を回転するGifアニメーションにするツールを作ってみた。](https://www.nicovideo.jp/watch/sm34930969)  

# ダウンロード
EXEは以下のURLで公開しております。  
[EXEのダウンロード](https://drive.google.com/file/d/1YuYKYObnPTVpQislpdmf920jSIyNhJ2w)  
  
# 動作環境
動作させるには下記が必要です。  
* .NET Framework 4.5 以上  
  
# 対応言語
日本語のみ  
  
# 開発環境
<table>
<tr><th align="left">言語</th><td>C#</td></tr>
<tr><th align="left">開発ツール</th><td>Visual Studio 2017 Community版</td></tr>
<tr><th align="left">フレームワーク</th><td>.NET Framework 4.5</td></tr>
<tr><th align="left">NuGet等の外部ライブラリ</th><td>使用していない</td></tr>
</table>
  
# ライセンス
MITライセンスです。  
詳細は「LICENSE」ファイルを見てください。  
    
# 著作者
みさきさん（自分です）
