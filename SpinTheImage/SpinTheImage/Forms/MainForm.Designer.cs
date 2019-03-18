namespace SpinTheImage.Forms
{
    partial class MainForm
    {
        /// <summary> 
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region コンポーネント デザイナーで生成されたコード

        /// <summary> 
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を 
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.MenuMain = new System.Windows.Forms.MenuStrip();
            this.MenuItemOption = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemOutputPng = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemOptionHyphen1 = new System.Windows.Forms.ToolStripSeparator();
            this.MenuItemOptionChangeBackgroundOfImageArea = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemOptionChangeBackgroundOfImageAreaWhite = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemOptionChangeBackgroundOfImageAreaBlack = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemOptionHyphen2 = new System.Windows.Forms.ToolStripSeparator();
            this.MenuItemRestoreDefaultSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemLanguage = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemLanguageJapanese = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemLanguageEnglish = new System.Windows.Forms.ToolStripMenuItem();
            this.TabControl = new System.Windows.Forms.TabControl();
            this.TabPageRotate = new System.Windows.Forms.TabPage();
            this.PlFill = new System.Windows.Forms.Panel();
            this.PictureBoxPreview = new System.Windows.Forms.PictureBox();
            this.ProgressBarCreateGif = new System.Windows.Forms.ProgressBar();
            this.PlRun = new System.Windows.Forms.TableLayoutPanel();
            this.BtStop = new System.Windows.Forms.Button();
            this.BtRun = new System.Windows.Forms.Button();
            this.BtPreview = new System.Windows.Forms.Button();
            this.Splitter = new System.Windows.Forms.Splitter();
            this.PlLeft = new System.Windows.Forms.Panel();
            this.PlParameter = new System.Windows.Forms.Panel();
            this.LbRotateToEndExplain = new System.Windows.Forms.Label();
            this.ChkRotateToEnd = new System.Windows.Forms.CheckBox();
            this.PlRoop = new System.Windows.Forms.Panel();
            this.PlRoopSettings = new System.Windows.Forms.Panel();
            this.ChkRoopInfinite = new System.Windows.Forms.CheckBox();
            this.PlRoopCount = new System.Windows.Forms.Panel();
            this.TxtRoopCount = new System.Windows.Forms.NumericUpDown();
            this.LbRoopCount = new System.Windows.Forms.Label();
            this.ChkRoop = new System.Windows.Forms.CheckBox();
            this.LbRoop = new System.Windows.Forms.Label();
            this.PlChangeCanvas = new System.Windows.Forms.Panel();
            this.PlChangeCanvasSize = new System.Windows.Forms.Panel();
            this.BtChangeCanvasPreviewClear = new System.Windows.Forms.Button();
            this.BtChangeCanvasPreviewRotate15 = new System.Windows.Forms.Button();
            this.BtChangeCanvasPreview = new System.Windows.Forms.Button();
            this.LbChangeCanvasSizeExplain = new System.Windows.Forms.Label();
            this.PlChangeCanvasSizeSelectSize = new System.Windows.Forms.Panel();
            this.TxtChangeCanvasSizeSelectSizeHeight = new System.Windows.Forms.NumericUpDown();
            this.LbChangeCanvasSizeSelectSizeHeight = new System.Windows.Forms.Label();
            this.TxtChangeCanvasSizeSelectSizeWidth = new System.Windows.Forms.NumericUpDown();
            this.LbChangeCanvasSizeSelectSizeWidth = new System.Windows.Forms.Label();
            this.RdoChangeCanvasSizeSelectSize = new System.Windows.Forms.RadioButton();
            this.RdoChangeCanvasSizeDiagonalSize = new System.Windows.Forms.RadioButton();
            this.RdoChangeCanvasSizeNoChange = new System.Windows.Forms.RadioButton();
            this.LbChangeCanvasSize = new System.Windows.Forms.Label();
            this.PlChangeCanvasCenter = new System.Windows.Forms.Panel();
            this.ChkChangeCanvasPreviewCenterLine = new System.Windows.Forms.CheckBox();
            this.PlChangeCanvasCenterPoint = new System.Windows.Forms.Panel();
            this.TxtChangeCanvasCenterPointY = new System.Windows.Forms.NumericUpDown();
            this.LbChangeCanvasCenterPointY = new System.Windows.Forms.Label();
            this.TxtChangeCanvasCenterPointX = new System.Windows.Forms.NumericUpDown();
            this.LbChangeCanvasCenterPointX = new System.Windows.Forms.Label();
            this.ChkChangeCanvasCenter = new System.Windows.Forms.CheckBox();
            this.LbChangeCanvas = new System.Windows.Forms.Label();
            this.PlRoteteParameter = new System.Windows.Forms.Panel();
            this.PlRoteteParameterFile = new System.Windows.Forms.Panel();
            this.BtRoteteParameterFileClear = new System.Windows.Forms.Button();
            this.BtRoteteParameterFileSelect = new System.Windows.Forms.Button();
            this.TxtRoteteParameterFile = new System.Windows.Forms.TextBox();
            this.LbRoteteParameterFile = new System.Windows.Forms.Label();
            this.LbRoteteParameterExplain = new System.Windows.Forms.Label();
            this.LbRoteteParameterOR = new System.Windows.Forms.Label();
            this.PlRoteteParameterInput = new System.Windows.Forms.Panel();
            this.TxtAcceleteRate = new System.Windows.Forms.NumericUpDown();
            this.LbAcceleteRate = new System.Windows.Forms.Label();
            this.TxtInitialSpeed = new System.Windows.Forms.NumericUpDown();
            this.LbInitialSpeed = new System.Windows.Forms.Label();
            this.TxtSeconds = new System.Windows.Forms.NumericUpDown();
            this.LbSeconds = new System.Windows.Forms.Label();
            this.TxtFrameRate = new System.Windows.Forms.NumericUpDown();
            this.LbFrameRate = new System.Windows.Forms.Label();
            this.LbRoteteParameter = new System.Windows.Forms.Label();
            this.TabPageCombineImages = new System.Windows.Forms.TabPage();
            this.CombineImagesControl = new SpinTheImage.Forms.CombineImagesControl();
            this.MenuMain.SuspendLayout();
            this.TabControl.SuspendLayout();
            this.TabPageRotate.SuspendLayout();
            this.PlFill.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxPreview)).BeginInit();
            this.PlRun.SuspendLayout();
            this.PlLeft.SuspendLayout();
            this.PlParameter.SuspendLayout();
            this.PlRoop.SuspendLayout();
            this.PlRoopSettings.SuspendLayout();
            this.PlRoopCount.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TxtRoopCount)).BeginInit();
            this.PlChangeCanvas.SuspendLayout();
            this.PlChangeCanvasSize.SuspendLayout();
            this.PlChangeCanvasSizeSelectSize.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TxtChangeCanvasSizeSelectSizeHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtChangeCanvasSizeSelectSizeWidth)).BeginInit();
            this.PlChangeCanvasCenter.SuspendLayout();
            this.PlChangeCanvasCenterPoint.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TxtChangeCanvasCenterPointY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtChangeCanvasCenterPointX)).BeginInit();
            this.PlRoteteParameter.SuspendLayout();
            this.PlRoteteParameterFile.SuspendLayout();
            this.PlRoteteParameterInput.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TxtAcceleteRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtInitialSpeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtSeconds)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtFrameRate)).BeginInit();
            this.TabPageCombineImages.SuspendLayout();
            this.SuspendLayout();
            // 
            // MenuMain
            // 
            this.MenuMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.MenuMain.Font = new System.Drawing.Font("Yu Gothic UI", 15F, System.Drawing.FontStyle.Bold);
            this.MenuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItemOption,
            this.MenuItemLanguage});
            this.MenuMain.Location = new System.Drawing.Point(0, 0);
            this.MenuMain.Name = "MenuMain";
            this.MenuMain.Size = new System.Drawing.Size(980, 36);
            this.MenuMain.TabIndex = 0;
            this.MenuMain.Text = "メインメニュー";
            // 
            // MenuItemOption
            // 
            this.MenuItemOption.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItemOutputPng,
            this.MenuItemOptionHyphen1,
            this.MenuItemOptionChangeBackgroundOfImageArea,
            this.MenuItemOptionHyphen2,
            this.MenuItemRestoreDefaultSettings});
            this.MenuItemOption.Name = "MenuItemOption";
            this.MenuItemOption.Size = new System.Drawing.Size(129, 32);
            this.MenuItemOption.Text = "オプション(&O)";
            // 
            // MenuItemOutputPng
            // 
            this.MenuItemOutputPng.Name = "MenuItemOutputPng";
            this.MenuItemOutputPng.Size = new System.Drawing.Size(266, 32);
            this.MenuItemOutputPng.Text = "PNGファイル出力";
            this.MenuItemOutputPng.Click += new System.EventHandler(this.MenuItemOutputPng_Click);
            // 
            // MenuItemOptionHyphen1
            // 
            this.MenuItemOptionHyphen1.Name = "MenuItemOptionHyphen1";
            this.MenuItemOptionHyphen1.Size = new System.Drawing.Size(263, 6);
            // 
            // MenuItemOptionChangeBackgroundOfImageArea
            // 
            this.MenuItemOptionChangeBackgroundOfImageArea.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItemOptionChangeBackgroundOfImageAreaWhite,
            this.MenuItemOptionChangeBackgroundOfImageAreaBlack});
            this.MenuItemOptionChangeBackgroundOfImageArea.Name = "MenuItemOptionChangeBackgroundOfImageArea";
            this.MenuItemOptionChangeBackgroundOfImageArea.Size = new System.Drawing.Size(266, 32);
            this.MenuItemOptionChangeBackgroundOfImageArea.Text = "画像エリアの背景変更";
            // 
            // MenuItemOptionChangeBackgroundOfImageAreaWhite
            // 
            this.MenuItemOptionChangeBackgroundOfImageAreaWhite.Checked = true;
            this.MenuItemOptionChangeBackgroundOfImageAreaWhite.CheckState = System.Windows.Forms.CheckState.Checked;
            this.MenuItemOptionChangeBackgroundOfImageAreaWhite.Name = "MenuItemOptionChangeBackgroundOfImageAreaWhite";
            this.MenuItemOptionChangeBackgroundOfImageAreaWhite.Size = new System.Drawing.Size(104, 32);
            this.MenuItemOptionChangeBackgroundOfImageAreaWhite.Text = "白";
            this.MenuItemOptionChangeBackgroundOfImageAreaWhite.Click += new System.EventHandler(this.MenuItemOptionChangeBackgroundOfImageAreaColor_Click);
            // 
            // MenuItemOptionChangeBackgroundOfImageAreaBlack
            // 
            this.MenuItemOptionChangeBackgroundOfImageAreaBlack.Name = "MenuItemOptionChangeBackgroundOfImageAreaBlack";
            this.MenuItemOptionChangeBackgroundOfImageAreaBlack.Size = new System.Drawing.Size(104, 32);
            this.MenuItemOptionChangeBackgroundOfImageAreaBlack.Text = "黒";
            this.MenuItemOptionChangeBackgroundOfImageAreaBlack.Click += new System.EventHandler(this.MenuItemOptionChangeBackgroundOfImageAreaColor_Click);
            // 
            // MenuItemOptionHyphen2
            // 
            this.MenuItemOptionHyphen2.Name = "MenuItemOptionHyphen2";
            this.MenuItemOptionHyphen2.Size = new System.Drawing.Size(263, 6);
            // 
            // MenuItemRestoreDefaultSettings
            // 
            this.MenuItemRestoreDefaultSettings.Name = "MenuItemRestoreDefaultSettings";
            this.MenuItemRestoreDefaultSettings.Size = new System.Drawing.Size(266, 32);
            this.MenuItemRestoreDefaultSettings.Text = "デフォルト設定に戻す";
            this.MenuItemRestoreDefaultSettings.Click += new System.EventHandler(this.MenuItemRestoreDefaultSettings_Click);
            // 
            // MenuItemLanguage
            // 
            this.MenuItemLanguage.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItemLanguageJapanese,
            this.MenuItemLanguageEnglish});
            this.MenuItemLanguage.Name = "MenuItemLanguage";
            this.MenuItemLanguage.Size = new System.Drawing.Size(88, 32);
            this.MenuItemLanguage.Text = "言語(&L)";
            // 
            // MenuItemLanguageJapanese
            // 
            this.MenuItemLanguageJapanese.Checked = true;
            this.MenuItemLanguageJapanese.CheckState = System.Windows.Forms.CheckState.Checked;
            this.MenuItemLanguageJapanese.Name = "MenuItemLanguageJapanese";
            this.MenuItemLanguageJapanese.Size = new System.Drawing.Size(144, 32);
            this.MenuItemLanguageJapanese.Text = "日本語";
            // 
            // MenuItemLanguageEnglish
            // 
            this.MenuItemLanguageEnglish.Name = "MenuItemLanguageEnglish";
            this.MenuItemLanguageEnglish.Size = new System.Drawing.Size(144, 32);
            this.MenuItemLanguageEnglish.Text = "英語";
            // 
            // TabControl
            // 
            this.TabControl.Controls.Add(this.TabPageRotate);
            this.TabControl.Controls.Add(this.TabPageCombineImages);
            this.TabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TabControl.Location = new System.Drawing.Point(0, 36);
            this.TabControl.Name = "TabControl";
            this.TabControl.SelectedIndex = 0;
            this.TabControl.Size = new System.Drawing.Size(980, 702);
            this.TabControl.TabIndex = 4;
            // 
            // TabPageRotate
            // 
            this.TabPageRotate.Controls.Add(this.PlFill);
            this.TabPageRotate.Controls.Add(this.Splitter);
            this.TabPageRotate.Controls.Add(this.PlLeft);
            this.TabPageRotate.Location = new System.Drawing.Point(4, 30);
            this.TabPageRotate.Name = "TabPageRotate";
            this.TabPageRotate.Size = new System.Drawing.Size(972, 668);
            this.TabPageRotate.TabIndex = 0;
            this.TabPageRotate.Text = " 回転GIF作成 ";
            // 
            // PlFill
            // 
            this.PlFill.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.PlFill.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.PlFill.Controls.Add(this.PictureBoxPreview);
            this.PlFill.Controls.Add(this.ProgressBarCreateGif);
            this.PlFill.Controls.Add(this.PlRun);
            this.PlFill.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PlFill.Location = new System.Drawing.Point(566, 0);
            this.PlFill.Name = "PlFill";
            this.PlFill.Size = new System.Drawing.Size(406, 668);
            this.PlFill.TabIndex = 1;
            // 
            // PictureBoxPreview
            // 
            this.PictureBoxPreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PictureBoxPreview.Location = new System.Drawing.Point(0, 92);
            this.PictureBoxPreview.Name = "PictureBoxPreview";
            this.PictureBoxPreview.Size = new System.Drawing.Size(402, 549);
            this.PictureBoxPreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PictureBoxPreview.TabIndex = 3;
            this.PictureBoxPreview.TabStop = false;
            this.PictureBoxPreview.DragDrop += new System.Windows.Forms.DragEventHandler(this.PictureBoxPreview_DragDrop);
            this.PictureBoxPreview.DragEnter += new System.Windows.Forms.DragEventHandler(this.PictureBoxPreview_DragEnter);
            this.PictureBoxPreview.Paint += new System.Windows.Forms.PaintEventHandler(this.PictureBoxPreview_Paint);
            // 
            // ProgressBarCreateGif
            // 
            this.ProgressBarCreateGif.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ProgressBarCreateGif.Location = new System.Drawing.Point(0, 641);
            this.ProgressBarCreateGif.Name = "ProgressBarCreateGif";
            this.ProgressBarCreateGif.Size = new System.Drawing.Size(402, 23);
            this.ProgressBarCreateGif.TabIndex = 2;
            // 
            // PlRun
            // 
            this.PlRun.AutoSize = true;
            this.PlRun.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.PlRun.ColumnCount = 3;
            this.PlRun.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.PlRun.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.PlRun.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.PlRun.Controls.Add(this.BtStop, 2, 0);
            this.PlRun.Controls.Add(this.BtRun, 1, 0);
            this.PlRun.Controls.Add(this.BtPreview, 0, 0);
            this.PlRun.Dock = System.Windows.Forms.DockStyle.Top;
            this.PlRun.Location = new System.Drawing.Point(0, 0);
            this.PlRun.Name = "PlRun";
            this.PlRun.RowCount = 1;
            this.PlRun.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.PlRun.Size = new System.Drawing.Size(402, 92);
            this.PlRun.TabIndex = 0;
            // 
            // BtStop
            // 
            this.BtStop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.BtStop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtStop.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtStop.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.BtStop.FlatAppearance.BorderSize = 3;
            this.BtStop.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.BtStop.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Maroon;
            this.BtStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtStop.Font = new System.Drawing.Font("MS UI Gothic", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.BtStop.ForeColor = System.Drawing.Color.White;
            this.BtStop.Location = new System.Drawing.Point(291, 11);
            this.BtStop.Margin = new System.Windows.Forms.Padding(10);
            this.BtStop.Name = "BtStop";
            this.BtStop.Size = new System.Drawing.Size(100, 70);
            this.BtStop.TabIndex = 3;
            this.BtStop.Text = "停止";
            this.BtStop.UseVisualStyleBackColor = false;
            this.BtStop.Click += new System.EventHandler(this.BtStop_Click);
            // 
            // BtRun
            // 
            this.BtRun.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.BtRun.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtRun.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtRun.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.BtRun.FlatAppearance.BorderSize = 3;
            this.BtRun.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.BtRun.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Maroon;
            this.BtRun.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtRun.Font = new System.Drawing.Font("MS UI Gothic", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.BtRun.ForeColor = System.Drawing.Color.White;
            this.BtRun.Location = new System.Drawing.Point(151, 11);
            this.BtRun.Margin = new System.Windows.Forms.Padding(10);
            this.BtRun.Name = "BtRun";
            this.BtRun.Size = new System.Drawing.Size(119, 70);
            this.BtRun.TabIndex = 2;
            this.BtRun.Text = "実行";
            this.BtRun.UseVisualStyleBackColor = false;
            this.BtRun.Click += new System.EventHandler(this.Run_Click);
            // 
            // BtPreview
            // 
            this.BtPreview.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.BtPreview.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtPreview.Dock = System.Windows.Forms.DockStyle.Left;
            this.BtPreview.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.BtPreview.FlatAppearance.BorderSize = 3;
            this.BtPreview.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.BtPreview.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Maroon;
            this.BtPreview.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtPreview.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.BtPreview.ForeColor = System.Drawing.Color.White;
            this.BtPreview.Location = new System.Drawing.Point(11, 11);
            this.BtPreview.Margin = new System.Windows.Forms.Padding(10);
            this.BtPreview.Name = "BtPreview";
            this.BtPreview.Size = new System.Drawing.Size(119, 70);
            this.BtPreview.TabIndex = 1;
            this.BtPreview.Text = "プレビュー\r\n実行";
            this.BtPreview.UseVisualStyleBackColor = false;
            this.BtPreview.Click += new System.EventHandler(this.Run_Click);
            // 
            // Splitter
            // 
            this.Splitter.Location = new System.Drawing.Point(561, 0);
            this.Splitter.Name = "Splitter";
            this.Splitter.Size = new System.Drawing.Size(5, 668);
            this.Splitter.TabIndex = 1;
            this.Splitter.TabStop = false;
            // 
            // PlLeft
            // 
            this.PlLeft.AutoScroll = true;
            this.PlLeft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.PlLeft.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.PlLeft.Controls.Add(this.PlParameter);
            this.PlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.PlLeft.Location = new System.Drawing.Point(0, 0);
            this.PlLeft.Name = "PlLeft";
            this.PlLeft.Size = new System.Drawing.Size(561, 668);
            this.PlLeft.TabIndex = 0;
            // 
            // PlParameter
            // 
            this.PlParameter.Controls.Add(this.LbRotateToEndExplain);
            this.PlParameter.Controls.Add(this.ChkRotateToEnd);
            this.PlParameter.Controls.Add(this.PlRoop);
            this.PlParameter.Controls.Add(this.LbRoop);
            this.PlParameter.Controls.Add(this.PlChangeCanvas);
            this.PlParameter.Controls.Add(this.LbChangeCanvas);
            this.PlParameter.Controls.Add(this.PlRoteteParameter);
            this.PlParameter.Controls.Add(this.LbRoteteParameter);
            this.PlParameter.Location = new System.Drawing.Point(0, 0);
            this.PlParameter.Margin = new System.Windows.Forms.Padding(0);
            this.PlParameter.Name = "PlParameter";
            this.PlParameter.Size = new System.Drawing.Size(540, 643);
            this.PlParameter.TabIndex = 0;
            // 
            // LbRotateToEndExplain
            // 
            this.LbRotateToEndExplain.AutoSize = true;
            this.LbRotateToEndExplain.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.LbRotateToEndExplain.Location = new System.Drawing.Point(45, 609);
            this.LbRotateToEndExplain.Name = "LbRotateToEndExplain";
            this.LbRotateToEndExplain.Size = new System.Drawing.Size(360, 24);
            this.LbRotateToEndExplain.TabIndex = 10;
            this.LbRotateToEndExplain.Text = "チェックを入れた場合、最初の画像と同じ角度を最後のフレームに追加する。\r\nチェックを入れない場合、最後が中途半場な角度となる。";
            // 
            // ChkRotateToEnd
            // 
            this.ChkRotateToEnd.AutoSize = true;
            this.ChkRotateToEnd.Checked = true;
            this.ChkRotateToEnd.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ChkRotateToEnd.Location = new System.Drawing.Point(21, 585);
            this.ChkRotateToEnd.Name = "ChkRotateToEnd";
            this.ChkRotateToEnd.Size = new System.Drawing.Size(337, 24);
            this.ChkRotateToEnd.TabIndex = 9;
            this.ChkRotateToEnd.Text = "最後は元の画像の角度で終わるか？";
            this.ChkRotateToEnd.UseVisualStyleBackColor = true;
            // 
            // PlRoop
            // 
            this.PlRoop.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PlRoop.Controls.Add(this.PlRoopSettings);
            this.PlRoop.Controls.Add(this.ChkRoop);
            this.PlRoop.Location = new System.Drawing.Point(10, 528);
            this.PlRoop.Name = "PlRoop";
            this.PlRoop.Size = new System.Drawing.Size(530, 44);
            this.PlRoop.TabIndex = 7;
            // 
            // PlRoopSettings
            // 
            this.PlRoopSettings.AutoSize = true;
            this.PlRoopSettings.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.PlRoopSettings.Controls.Add(this.ChkRoopInfinite);
            this.PlRoopSettings.Controls.Add(this.PlRoopCount);
            this.PlRoopSettings.Location = new System.Drawing.Point(163, 4);
            this.PlRoopSettings.Name = "PlRoopSettings";
            this.PlRoopSettings.Size = new System.Drawing.Size(283, 33);
            this.PlRoopSettings.TabIndex = 1;
            // 
            // ChkRoopInfinite
            // 
            this.ChkRoopInfinite.AutoSize = true;
            this.ChkRoopInfinite.Location = new System.Drawing.Point(210, 6);
            this.ChkRoopInfinite.Name = "ChkRoopInfinite";
            this.ChkRoopInfinite.Size = new System.Drawing.Size(70, 24);
            this.ChkRoopInfinite.TabIndex = 1;
            this.ChkRoopInfinite.Text = "無限";
            this.ChkRoopInfinite.UseVisualStyleBackColor = true;
            this.ChkRoopInfinite.Click += new System.EventHandler(this.ChkRoopInfinite_CheckedChanged);
            // 
            // PlRoopCount
            // 
            this.PlRoopCount.AutoSize = true;
            this.PlRoopCount.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.PlRoopCount.Controls.Add(this.TxtRoopCount);
            this.PlRoopCount.Controls.Add(this.LbRoopCount);
            this.PlRoopCount.Location = new System.Drawing.Point(0, 0);
            this.PlRoopCount.Margin = new System.Windows.Forms.Padding(0);
            this.PlRoopCount.Name = "PlRoopCount";
            this.PlRoopCount.Size = new System.Drawing.Size(193, 33);
            this.PlRoopCount.TabIndex = 0;
            // 
            // TxtRoopCount
            // 
            this.TxtRoopCount.Location = new System.Drawing.Point(110, 3);
            this.TxtRoopCount.Maximum = new decimal(new int[] {
            32767,
            0,
            0,
            0});
            this.TxtRoopCount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.TxtRoopCount.Name = "TxtRoopCount";
            this.TxtRoopCount.Size = new System.Drawing.Size(80, 27);
            this.TxtRoopCount.TabIndex = 1;
            this.TxtRoopCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.TxtRoopCount.Value = new decimal(new int[] {
            32767,
            0,
            0,
            0});
            // 
            // LbRoopCount
            // 
            this.LbRoopCount.AutoSize = true;
            this.LbRoopCount.Location = new System.Drawing.Point(3, 6);
            this.LbRoopCount.Name = "LbRoopCount";
            this.LbRoopCount.Size = new System.Drawing.Size(101, 20);
            this.LbRoopCount.TabIndex = 0;
            this.LbRoopCount.Text = "ループ回数";
            // 
            // ChkRoop
            // 
            this.ChkRoop.AutoSize = true;
            this.ChkRoop.Location = new System.Drawing.Point(10, 10);
            this.ChkRoop.Name = "ChkRoop";
            this.ChkRoop.Size = new System.Drawing.Size(150, 24);
            this.ChkRoop.TabIndex = 0;
            this.ChkRoop.Text = "ループするか？";
            this.ChkRoop.UseVisualStyleBackColor = true;
            this.ChkRoop.Click += new System.EventHandler(this.ChkRoop_CheckedChanged);
            // 
            // LbRoop
            // 
            this.LbRoop.AutoSize = true;
            this.LbRoop.Location = new System.Drawing.Point(10, 505);
            this.LbRoop.Name = "LbRoop";
            this.LbRoop.Size = new System.Drawing.Size(118, 20);
            this.LbRoop.TabIndex = 6;
            this.LbRoop.Text = "ループの設定";
            // 
            // PlChangeCanvas
            // 
            this.PlChangeCanvas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PlChangeCanvas.Controls.Add(this.PlChangeCanvasSize);
            this.PlChangeCanvas.Controls.Add(this.PlChangeCanvasCenter);
            this.PlChangeCanvas.Location = new System.Drawing.Point(10, 269);
            this.PlChangeCanvas.Name = "PlChangeCanvas";
            this.PlChangeCanvas.Size = new System.Drawing.Size(530, 223);
            this.PlChangeCanvas.TabIndex = 4;
            // 
            // PlChangeCanvasSize
            // 
            this.PlChangeCanvasSize.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PlChangeCanvasSize.Controls.Add(this.BtChangeCanvasPreviewClear);
            this.PlChangeCanvasSize.Controls.Add(this.BtChangeCanvasPreviewRotate15);
            this.PlChangeCanvasSize.Controls.Add(this.BtChangeCanvasPreview);
            this.PlChangeCanvasSize.Controls.Add(this.LbChangeCanvasSizeExplain);
            this.PlChangeCanvasSize.Controls.Add(this.PlChangeCanvasSizeSelectSize);
            this.PlChangeCanvasSize.Controls.Add(this.RdoChangeCanvasSizeSelectSize);
            this.PlChangeCanvasSize.Controls.Add(this.RdoChangeCanvasSizeDiagonalSize);
            this.PlChangeCanvasSize.Controls.Add(this.RdoChangeCanvasSizeNoChange);
            this.PlChangeCanvasSize.Controls.Add(this.LbChangeCanvasSize);
            this.PlChangeCanvasSize.Location = new System.Drawing.Point(10, 59);
            this.PlChangeCanvasSize.Name = "PlChangeCanvasSize";
            this.PlChangeCanvasSize.Size = new System.Drawing.Size(508, 154);
            this.PlChangeCanvasSize.TabIndex = 1;
            // 
            // BtChangeCanvasPreviewClear
            // 
            this.BtChangeCanvasPreviewClear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.BtChangeCanvasPreviewClear.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtChangeCanvasPreviewClear.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.BtChangeCanvasPreviewClear.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.BtChangeCanvasPreviewClear.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Maroon;
            this.BtChangeCanvasPreviewClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtChangeCanvasPreviewClear.ForeColor = System.Drawing.Color.White;
            this.BtChangeCanvasPreviewClear.Location = new System.Drawing.Point(380, 88);
            this.BtChangeCanvasPreviewClear.Name = "BtChangeCanvasPreviewClear";
            this.BtChangeCanvasPreviewClear.Size = new System.Drawing.Size(117, 29);
            this.BtChangeCanvasPreviewClear.TabIndex = 8;
            this.BtChangeCanvasPreviewClear.Text = "クリア";
            this.BtChangeCanvasPreviewClear.UseVisualStyleBackColor = false;
            this.BtChangeCanvasPreviewClear.Click += new System.EventHandler(this.BtChangeCanvasSizePreviewClear_Click);
            // 
            // BtChangeCanvasPreviewRotate15
            // 
            this.BtChangeCanvasPreviewRotate15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.BtChangeCanvasPreviewRotate15.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtChangeCanvasPreviewRotate15.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.BtChangeCanvasPreviewRotate15.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.BtChangeCanvasPreviewRotate15.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Maroon;
            this.BtChangeCanvasPreviewRotate15.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtChangeCanvasPreviewRotate15.ForeColor = System.Drawing.Color.White;
            this.BtChangeCanvasPreviewRotate15.Location = new System.Drawing.Point(380, 47);
            this.BtChangeCanvasPreviewRotate15.Name = "BtChangeCanvasPreviewRotate15";
            this.BtChangeCanvasPreviewRotate15.Size = new System.Drawing.Size(117, 29);
            this.BtChangeCanvasPreviewRotate15.TabIndex = 7;
            this.BtChangeCanvasPreviewRotate15.Text = "15度回転";
            this.BtChangeCanvasPreviewRotate15.UseVisualStyleBackColor = false;
            this.BtChangeCanvasPreviewRotate15.Click += new System.EventHandler(this.BtChangeCanvasSizePreviewRotate15_Click);
            // 
            // BtChangeCanvasPreview
            // 
            this.BtChangeCanvasPreview.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.BtChangeCanvasPreview.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtChangeCanvasPreview.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.BtChangeCanvasPreview.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.BtChangeCanvasPreview.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Maroon;
            this.BtChangeCanvasPreview.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtChangeCanvasPreview.ForeColor = System.Drawing.Color.White;
            this.BtChangeCanvasPreview.Location = new System.Drawing.Point(380, 7);
            this.BtChangeCanvasPreview.Name = "BtChangeCanvasPreview";
            this.BtChangeCanvasPreview.Size = new System.Drawing.Size(117, 29);
            this.BtChangeCanvasPreview.TabIndex = 6;
            this.BtChangeCanvasPreview.Text = "プレビュー";
            this.BtChangeCanvasPreview.UseVisualStyleBackColor = false;
            this.BtChangeCanvasPreview.Click += new System.EventHandler(this.BtChangeCanvasSizePreview_Click);
            // 
            // LbChangeCanvasSizeExplain
            // 
            this.LbChangeCanvasSizeExplain.AutoSize = true;
            this.LbChangeCanvasSizeExplain.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.LbChangeCanvasSizeExplain.Location = new System.Drawing.Point(9, 123);
            this.LbChangeCanvasSizeExplain.Name = "LbChangeCanvasSizeExplain";
            this.LbChangeCanvasSizeExplain.Size = new System.Drawing.Size(360, 24);
            this.LbChangeCanvasSizeExplain.TabIndex = 5;
            this.LbChangeCanvasSizeExplain.Text = "対角線の長さが横幅より大きいため回転させると、角の部分が切れてしまう。\r\nそれを解消するためキャンパスサイズ拡大する設定を行う。（縮小も可）";
            // 
            // PlChangeCanvasSizeSelectSize
            // 
            this.PlChangeCanvasSizeSelectSize.AutoSize = true;
            this.PlChangeCanvasSizeSelectSize.Controls.Add(this.TxtChangeCanvasSizeSelectSizeHeight);
            this.PlChangeCanvasSizeSelectSize.Controls.Add(this.LbChangeCanvasSizeSelectSizeHeight);
            this.PlChangeCanvasSizeSelectSize.Controls.Add(this.TxtChangeCanvasSizeSelectSizeWidth);
            this.PlChangeCanvasSizeSelectSize.Controls.Add(this.LbChangeCanvasSizeSelectSizeWidth);
            this.PlChangeCanvasSizeSelectSize.Location = new System.Drawing.Point(39, 86);
            this.PlChangeCanvasSizeSelectSize.Name = "PlChangeCanvasSizeSelectSize";
            this.PlChangeCanvasSizeSelectSize.Size = new System.Drawing.Size(243, 33);
            this.PlChangeCanvasSizeSelectSize.TabIndex = 4;
            // 
            // TxtChangeCanvasSizeSelectSizeHeight
            // 
            this.TxtChangeCanvasSizeSelectSizeHeight.Location = new System.Drawing.Point(173, 3);
            this.TxtChangeCanvasSizeSelectSizeHeight.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.TxtChangeCanvasSizeSelectSizeHeight.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.TxtChangeCanvasSizeSelectSizeHeight.Name = "TxtChangeCanvasSizeSelectSizeHeight";
            this.TxtChangeCanvasSizeSelectSizeHeight.Size = new System.Drawing.Size(67, 27);
            this.TxtChangeCanvasSizeSelectSizeHeight.TabIndex = 3;
            this.TxtChangeCanvasSizeSelectSizeHeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.TxtChangeCanvasSizeSelectSizeHeight.Value = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            // 
            // LbChangeCanvasSizeSelectSizeHeight
            // 
            this.LbChangeCanvasSizeSelectSizeHeight.AutoSize = true;
            this.LbChangeCanvasSizeSelectSizeHeight.Location = new System.Drawing.Point(122, 6);
            this.LbChangeCanvasSizeSelectSizeHeight.Name = "LbChangeCanvasSizeSelectSizeHeight";
            this.LbChangeCanvasSizeSelectSizeHeight.Size = new System.Drawing.Size(45, 20);
            this.LbChangeCanvasSizeSelectSizeHeight.TabIndex = 2;
            this.LbChangeCanvasSizeSelectSizeHeight.Text = "高さ";
            // 
            // TxtChangeCanvasSizeSelectSizeWidth
            // 
            this.TxtChangeCanvasSizeSelectSizeWidth.Location = new System.Drawing.Point(39, 3);
            this.TxtChangeCanvasSizeSelectSizeWidth.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.TxtChangeCanvasSizeSelectSizeWidth.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.TxtChangeCanvasSizeSelectSizeWidth.Name = "TxtChangeCanvasSizeSelectSizeWidth";
            this.TxtChangeCanvasSizeSelectSizeWidth.Size = new System.Drawing.Size(67, 27);
            this.TxtChangeCanvasSizeSelectSizeWidth.TabIndex = 1;
            this.TxtChangeCanvasSizeSelectSizeWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.TxtChangeCanvasSizeSelectSizeWidth.Value = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            // 
            // LbChangeCanvasSizeSelectSizeWidth
            // 
            this.LbChangeCanvasSizeSelectSizeWidth.AutoSize = true;
            this.LbChangeCanvasSizeSelectSizeWidth.Location = new System.Drawing.Point(3, 6);
            this.LbChangeCanvasSizeSelectSizeWidth.Name = "LbChangeCanvasSizeSelectSizeWidth";
            this.LbChangeCanvasSizeSelectSizeWidth.Size = new System.Drawing.Size(30, 20);
            this.LbChangeCanvasSizeSelectSizeWidth.TabIndex = 0;
            this.LbChangeCanvasSizeSelectSizeWidth.Text = "幅";
            // 
            // RdoChangeCanvasSizeSelectSize
            // 
            this.RdoChangeCanvasSizeSelectSize.AutoSize = true;
            this.RdoChangeCanvasSizeSelectSize.Location = new System.Drawing.Point(14, 64);
            this.RdoChangeCanvasSizeSelectSize.Name = "RdoChangeCanvasSizeSelectSize";
            this.RdoChangeCanvasSizeSelectSize.Size = new System.Drawing.Size(193, 24);
            this.RdoChangeCanvasSizeSelectSize.TabIndex = 3;
            this.RdoChangeCanvasSizeSelectSize.Text = "指定のサイズを使用";
            this.RdoChangeCanvasSizeSelectSize.UseVisualStyleBackColor = true;
            this.RdoChangeCanvasSizeSelectSize.CheckedChanged += new System.EventHandler(this.RdoChangeCanvasSize_CheckedChanged);
            // 
            // RdoChangeCanvasSizeDiagonalSize
            // 
            this.RdoChangeCanvasSizeDiagonalSize.AutoSize = true;
            this.RdoChangeCanvasSizeDiagonalSize.Location = new System.Drawing.Point(154, 34);
            this.RdoChangeCanvasSizeDiagonalSize.Name = "RdoChangeCanvasSizeDiagonalSize";
            this.RdoChangeCanvasSizeDiagonalSize.Size = new System.Drawing.Size(215, 24);
            this.RdoChangeCanvasSizeDiagonalSize.TabIndex = 2;
            this.RdoChangeCanvasSizeDiagonalSize.Text = "対角線のサイズに拡大";
            this.RdoChangeCanvasSizeDiagonalSize.UseVisualStyleBackColor = true;
            this.RdoChangeCanvasSizeDiagonalSize.CheckedChanged += new System.EventHandler(this.RdoChangeCanvasSize_CheckedChanged);
            // 
            // RdoChangeCanvasSizeNoChange
            // 
            this.RdoChangeCanvasSizeNoChange.AutoSize = true;
            this.RdoChangeCanvasSizeNoChange.Checked = true;
            this.RdoChangeCanvasSizeNoChange.Location = new System.Drawing.Point(14, 34);
            this.RdoChangeCanvasSizeNoChange.Name = "RdoChangeCanvasSizeNoChange";
            this.RdoChangeCanvasSizeNoChange.Size = new System.Drawing.Size(119, 24);
            this.RdoChangeCanvasSizeNoChange.TabIndex = 1;
            this.RdoChangeCanvasSizeNoChange.TabStop = true;
            this.RdoChangeCanvasSizeNoChange.Text = "変更しない";
            this.RdoChangeCanvasSizeNoChange.UseVisualStyleBackColor = true;
            this.RdoChangeCanvasSizeNoChange.CheckedChanged += new System.EventHandler(this.RdoChangeCanvasSize_CheckedChanged);
            // 
            // LbChangeCanvasSize
            // 
            this.LbChangeCanvasSize.AutoSize = true;
            this.LbChangeCanvasSize.Location = new System.Drawing.Point(10, 11);
            this.LbChangeCanvasSize.Name = "LbChangeCanvasSize";
            this.LbChangeCanvasSize.Size = new System.Drawing.Size(198, 20);
            this.LbChangeCanvasSize.TabIndex = 0;
            this.LbChangeCanvasSize.Text = "キャンパスサイズの変更";
            // 
            // PlChangeCanvasCenter
            // 
            this.PlChangeCanvasCenter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PlChangeCanvasCenter.Controls.Add(this.ChkChangeCanvasPreviewCenterLine);
            this.PlChangeCanvasCenter.Controls.Add(this.PlChangeCanvasCenterPoint);
            this.PlChangeCanvasCenter.Controls.Add(this.ChkChangeCanvasCenter);
            this.PlChangeCanvasCenter.Location = new System.Drawing.Point(10, 11);
            this.PlChangeCanvasCenter.Name = "PlChangeCanvasCenter";
            this.PlChangeCanvasCenter.Size = new System.Drawing.Size(508, 43);
            this.PlChangeCanvasCenter.TabIndex = 0;
            // 
            // ChkChangeCanvasPreviewCenterLine
            // 
            this.ChkChangeCanvasPreviewCenterLine.AutoSize = true;
            this.ChkChangeCanvasPreviewCenterLine.Location = new System.Drawing.Point(385, 9);
            this.ChkChangeCanvasPreviewCenterLine.Name = "ChkChangeCanvasPreviewCenterLine";
            this.ChkChangeCanvasPreviewCenterLine.Size = new System.Drawing.Size(112, 24);
            this.ChkChangeCanvasPreviewCenterLine.TabIndex = 2;
            this.ChkChangeCanvasPreviewCenterLine.Text = "中心表示";
            this.ChkChangeCanvasPreviewCenterLine.UseVisualStyleBackColor = true;
            this.ChkChangeCanvasPreviewCenterLine.CheckedChanged += new System.EventHandler(this.ChkChangeCanvasPreviewCenterLine_CheckedChanged);
            // 
            // PlChangeCanvasCenterPoint
            // 
            this.PlChangeCanvasCenterPoint.AutoSize = true;
            this.PlChangeCanvasCenterPoint.Controls.Add(this.TxtChangeCanvasCenterPointY);
            this.PlChangeCanvasCenterPoint.Controls.Add(this.LbChangeCanvasCenterPointY);
            this.PlChangeCanvasCenterPoint.Controls.Add(this.TxtChangeCanvasCenterPointX);
            this.PlChangeCanvasCenterPoint.Controls.Add(this.LbChangeCanvasCenterPointX);
            this.PlChangeCanvasCenterPoint.Location = new System.Drawing.Point(159, 4);
            this.PlChangeCanvasCenterPoint.Name = "PlChangeCanvasCenterPoint";
            this.PlChangeCanvasCenterPoint.Size = new System.Drawing.Size(220, 33);
            this.PlChangeCanvasCenterPoint.TabIndex = 1;
            // 
            // TxtChangeCanvasCenterPointY
            // 
            this.TxtChangeCanvasCenterPointY.Location = new System.Drawing.Point(137, 3);
            this.TxtChangeCanvasCenterPointY.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.TxtChangeCanvasCenterPointY.Minimum = new decimal(new int[] {
            9999,
            0,
            0,
            -2147483648});
            this.TxtChangeCanvasCenterPointY.Name = "TxtChangeCanvasCenterPointY";
            this.TxtChangeCanvasCenterPointY.Size = new System.Drawing.Size(80, 27);
            this.TxtChangeCanvasCenterPointY.TabIndex = 3;
            this.TxtChangeCanvasCenterPointY.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.TxtChangeCanvasCenterPointY.Value = new decimal(new int[] {
            9999,
            0,
            0,
            -2147483648});
            this.TxtChangeCanvasCenterPointY.ValueChanged += new System.EventHandler(this.TxtChangeCanvasCenter_ValueChanged);
            // 
            // LbChangeCanvasCenterPointY
            // 
            this.LbChangeCanvasCenterPointY.AutoSize = true;
            this.LbChangeCanvasCenterPointY.Location = new System.Drawing.Point(113, 6);
            this.LbChangeCanvasCenterPointY.Name = "LbChangeCanvasCenterPointY";
            this.LbChangeCanvasCenterPointY.Size = new System.Drawing.Size(22, 20);
            this.LbChangeCanvasCenterPointY.TabIndex = 2;
            this.LbChangeCanvasCenterPointY.Text = "Y";
            // 
            // TxtChangeCanvasCenterPointX
            // 
            this.TxtChangeCanvasCenterPointX.Location = new System.Drawing.Point(27, 3);
            this.TxtChangeCanvasCenterPointX.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.TxtChangeCanvasCenterPointX.Minimum = new decimal(new int[] {
            9999,
            0,
            0,
            -2147483648});
            this.TxtChangeCanvasCenterPointX.Name = "TxtChangeCanvasCenterPointX";
            this.TxtChangeCanvasCenterPointX.Size = new System.Drawing.Size(80, 27);
            this.TxtChangeCanvasCenterPointX.TabIndex = 1;
            this.TxtChangeCanvasCenterPointX.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.TxtChangeCanvasCenterPointX.Value = new decimal(new int[] {
            9999,
            0,
            0,
            -2147483648});
            this.TxtChangeCanvasCenterPointX.ValueChanged += new System.EventHandler(this.TxtChangeCanvasCenter_ValueChanged);
            // 
            // LbChangeCanvasCenterPointX
            // 
            this.LbChangeCanvasCenterPointX.AutoSize = true;
            this.LbChangeCanvasCenterPointX.Location = new System.Drawing.Point(3, 6);
            this.LbChangeCanvasCenterPointX.Name = "LbChangeCanvasCenterPointX";
            this.LbChangeCanvasCenterPointX.Size = new System.Drawing.Size(22, 20);
            this.LbChangeCanvasCenterPointX.TabIndex = 0;
            this.LbChangeCanvasCenterPointX.Text = "X";
            // 
            // ChkChangeCanvasCenter
            // 
            this.ChkChangeCanvasCenter.AutoSize = true;
            this.ChkChangeCanvasCenter.Location = new System.Drawing.Point(10, 10);
            this.ChkChangeCanvasCenter.Name = "ChkChangeCanvasCenter";
            this.ChkChangeCanvasCenter.Size = new System.Drawing.Size(149, 24);
            this.ChkChangeCanvasCenter.TabIndex = 0;
            this.ChkChangeCanvasCenter.Text = "中心を変更？";
            this.ChkChangeCanvasCenter.UseVisualStyleBackColor = true;
            this.ChkChangeCanvasCenter.CheckedChanged += new System.EventHandler(this.ChkChangeCanvasCenter_CheckedChanged);
            // 
            // LbChangeCanvas
            // 
            this.LbChangeCanvas.AutoSize = true;
            this.LbChangeCanvas.Location = new System.Drawing.Point(10, 246);
            this.LbChangeCanvas.Name = "LbChangeCanvas";
            this.LbChangeCanvas.Size = new System.Drawing.Size(204, 20);
            this.LbChangeCanvas.TabIndex = 2;
            this.LbChangeCanvas.Text = "キャンパスに関する変更";
            // 
            // PlRoteteParameter
            // 
            this.PlRoteteParameter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PlRoteteParameter.Controls.Add(this.PlRoteteParameterFile);
            this.PlRoteteParameter.Controls.Add(this.LbRoteteParameterExplain);
            this.PlRoteteParameter.Controls.Add(this.LbRoteteParameterOR);
            this.PlRoteteParameter.Controls.Add(this.PlRoteteParameterInput);
            this.PlRoteteParameter.Controls.Add(this.TxtFrameRate);
            this.PlRoteteParameter.Controls.Add(this.LbFrameRate);
            this.PlRoteteParameter.Location = new System.Drawing.Point(10, 33);
            this.PlRoteteParameter.Name = "PlRoteteParameter";
            this.PlRoteteParameter.Size = new System.Drawing.Size(530, 200);
            this.PlRoteteParameter.TabIndex = 1;
            // 
            // PlRoteteParameterFile
            // 
            this.PlRoteteParameterFile.AllowDrop = true;
            this.PlRoteteParameterFile.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PlRoteteParameterFile.Controls.Add(this.BtRoteteParameterFileClear);
            this.PlRoteteParameterFile.Controls.Add(this.BtRoteteParameterFileSelect);
            this.PlRoteteParameterFile.Controls.Add(this.TxtRoteteParameterFile);
            this.PlRoteteParameterFile.Controls.Add(this.LbRoteteParameterFile);
            this.PlRoteteParameterFile.Location = new System.Drawing.Point(10, 110);
            this.PlRoteteParameterFile.Name = "PlRoteteParameterFile";
            this.PlRoteteParameterFile.Size = new System.Drawing.Size(508, 78);
            this.PlRoteteParameterFile.TabIndex = 5;
            this.PlRoteteParameterFile.DragDrop += new System.Windows.Forms.DragEventHandler(this.RoteteParameterFile_DragDrop);
            this.PlRoteteParameterFile.DragEnter += new System.Windows.Forms.DragEventHandler(this.RoteteParameterFile_DragEnter);
            // 
            // BtRoteteParameterFileClear
            // 
            this.BtRoteteParameterFileClear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.BtRoteteParameterFileClear.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtRoteteParameterFileClear.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.BtRoteteParameterFileClear.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.BtRoteteParameterFileClear.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Maroon;
            this.BtRoteteParameterFileClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtRoteteParameterFileClear.ForeColor = System.Drawing.Color.White;
            this.BtRoteteParameterFileClear.Location = new System.Drawing.Point(423, 36);
            this.BtRoteteParameterFileClear.Name = "BtRoteteParameterFileClear";
            this.BtRoteteParameterFileClear.Size = new System.Drawing.Size(75, 29);
            this.BtRoteteParameterFileClear.TabIndex = 3;
            this.BtRoteteParameterFileClear.Text = "クリア";
            this.BtRoteteParameterFileClear.UseVisualStyleBackColor = false;
            this.BtRoteteParameterFileClear.Click += new System.EventHandler(this.BtRoteteParameterFileClear_Click);
            // 
            // BtRoteteParameterFileSelect
            // 
            this.BtRoteteParameterFileSelect.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.BtRoteteParameterFileSelect.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtRoteteParameterFileSelect.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.BtRoteteParameterFileSelect.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.BtRoteteParameterFileSelect.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Maroon;
            this.BtRoteteParameterFileSelect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtRoteteParameterFileSelect.ForeColor = System.Drawing.Color.White;
            this.BtRoteteParameterFileSelect.Location = new System.Drawing.Point(342, 36);
            this.BtRoteteParameterFileSelect.Name = "BtRoteteParameterFileSelect";
            this.BtRoteteParameterFileSelect.Size = new System.Drawing.Size(75, 29);
            this.BtRoteteParameterFileSelect.TabIndex = 2;
            this.BtRoteteParameterFileSelect.Text = "選択";
            this.BtRoteteParameterFileSelect.UseVisualStyleBackColor = false;
            this.BtRoteteParameterFileSelect.Click += new System.EventHandler(this.BtRoteteParameterFileSelect_Click);
            // 
            // TxtRoteteParameterFile
            // 
            this.TxtRoteteParameterFile.AllowDrop = true;
            this.TxtRoteteParameterFile.Location = new System.Drawing.Point(10, 37);
            this.TxtRoteteParameterFile.Name = "TxtRoteteParameterFile";
            this.TxtRoteteParameterFile.ReadOnly = true;
            this.TxtRoteteParameterFile.Size = new System.Drawing.Size(326, 27);
            this.TxtRoteteParameterFile.TabIndex = 1;
            this.TxtRoteteParameterFile.Text = "ファイル選択 又は ドラッグ&ドロップ";
            this.TxtRoteteParameterFile.DragDrop += new System.Windows.Forms.DragEventHandler(this.RoteteParameterFile_DragDrop);
            this.TxtRoteteParameterFile.DragEnter += new System.Windows.Forms.DragEventHandler(this.RoteteParameterFile_DragEnter);
            // 
            // LbRoteteParameterFile
            // 
            this.LbRoteteParameterFile.AutoSize = true;
            this.LbRoteteParameterFile.Location = new System.Drawing.Point(10, 11);
            this.LbRoteteParameterFile.Name = "LbRoteteParameterFile";
            this.LbRoteteParameterFile.Size = new System.Drawing.Size(492, 20);
            this.LbRoteteParameterFile.TabIndex = 0;
            this.LbRoteteParameterFile.Text = "1フレーム毎の回転角度のリスト（改行区切）ファイルを使用";
            // 
            // LbRoteteParameterExplain
            // 
            this.LbRoteteParameterExplain.AutoSize = true;
            this.LbRoteteParameterExplain.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.LbRoteteParameterExplain.Location = new System.Drawing.Point(48, 91);
            this.LbRoteteParameterExplain.Name = "LbRoteteParameterExplain";
            this.LbRoteteParameterExplain.Size = new System.Drawing.Size(354, 12);
            this.LbRoteteParameterExplain.TabIndex = 4;
            this.LbRoteteParameterExplain.Text = "初速、加速度、回転角度リストにおいてマイナスは左回転、プラスは右回転";
            // 
            // LbRoteteParameterOR
            // 
            this.LbRoteteParameterOR.AutoSize = true;
            this.LbRoteteParameterOR.Location = new System.Drawing.Point(10, 87);
            this.LbRoteteParameterOR.Name = "LbRoteteParameterOR";
            this.LbRoteteParameterOR.Size = new System.Drawing.Size(38, 20);
            this.LbRoteteParameterOR.TabIndex = 3;
            this.LbRoteteParameterOR.Text = "OR";
            // 
            // PlRoteteParameterInput
            // 
            this.PlRoteteParameterInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PlRoteteParameterInput.Controls.Add(this.TxtAcceleteRate);
            this.PlRoteteParameterInput.Controls.Add(this.LbAcceleteRate);
            this.PlRoteteParameterInput.Controls.Add(this.TxtInitialSpeed);
            this.PlRoteteParameterInput.Controls.Add(this.LbInitialSpeed);
            this.PlRoteteParameterInput.Controls.Add(this.TxtSeconds);
            this.PlRoteteParameterInput.Controls.Add(this.LbSeconds);
            this.PlRoteteParameterInput.Location = new System.Drawing.Point(10, 41);
            this.PlRoteteParameterInput.Name = "PlRoteteParameterInput";
            this.PlRoteteParameterInput.Size = new System.Drawing.Size(508, 43);
            this.PlRoteteParameterInput.TabIndex = 2;
            // 
            // TxtAcceleteRate
            // 
            this.TxtAcceleteRate.DecimalPlaces = 3;
            this.TxtAcceleteRate.Location = new System.Drawing.Point(379, 8);
            this.TxtAcceleteRate.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            196608});
            this.TxtAcceleteRate.Minimum = new decimal(new int[] {
            9999999,
            0,
            0,
            -2147287040});
            this.TxtAcceleteRate.Name = "TxtAcceleteRate";
            this.TxtAcceleteRate.Size = new System.Drawing.Size(119, 27);
            this.TxtAcceleteRate.TabIndex = 5;
            this.TxtAcceleteRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.TxtAcceleteRate.Value = new decimal(new int[] {
            3600,
            0,
            0,
            -2147483648});
            // 
            // LbAcceleteRate
            // 
            this.LbAcceleteRate.AutoSize = true;
            this.LbAcceleteRate.Location = new System.Drawing.Point(308, 11);
            this.LbAcceleteRate.Name = "LbAcceleteRate";
            this.LbAcceleteRate.Size = new System.Drawing.Size(72, 20);
            this.LbAcceleteRate.TabIndex = 4;
            this.LbAcceleteRate.Text = "加速度";
            // 
            // TxtInitialSpeed
            // 
            this.TxtInitialSpeed.DecimalPlaces = 2;
            this.TxtInitialSpeed.Location = new System.Drawing.Point(194, 8);
            this.TxtInitialSpeed.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.TxtInitialSpeed.Minimum = new decimal(new int[] {
            9999,
            0,
            0,
            -2147483648});
            this.TxtInitialSpeed.Name = "TxtInitialSpeed";
            this.TxtInitialSpeed.Size = new System.Drawing.Size(107, 27);
            this.TxtInitialSpeed.TabIndex = 3;
            this.TxtInitialSpeed.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.TxtInitialSpeed.Value = new decimal(new int[] {
            3600,
            0,
            0,
            -2147483648});
            // 
            // LbInitialSpeed
            // 
            this.LbInitialSpeed.AutoSize = true;
            this.LbInitialSpeed.Location = new System.Drawing.Point(144, 11);
            this.LbInitialSpeed.Name = "LbInitialSpeed";
            this.LbInitialSpeed.Size = new System.Drawing.Size(51, 20);
            this.LbInitialSpeed.TabIndex = 2;
            this.LbInitialSpeed.Text = "初速";
            // 
            // TxtSeconds
            // 
            this.TxtSeconds.DecimalPlaces = 1;
            this.TxtSeconds.Location = new System.Drawing.Point(61, 8);
            this.TxtSeconds.Maximum = new decimal(new int[] {
            900,
            0,
            0,
            0});
            this.TxtSeconds.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.TxtSeconds.Name = "TxtSeconds";
            this.TxtSeconds.Size = new System.Drawing.Size(78, 27);
            this.TxtSeconds.TabIndex = 1;
            this.TxtSeconds.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.TxtSeconds.Value = new decimal(new int[] {
            900,
            0,
            0,
            0});
            // 
            // LbSeconds
            // 
            this.LbSeconds.AutoSize = true;
            this.LbSeconds.Location = new System.Drawing.Point(10, 11);
            this.LbSeconds.Name = "LbSeconds";
            this.LbSeconds.Size = new System.Drawing.Size(51, 20);
            this.LbSeconds.TabIndex = 0;
            this.LbSeconds.Text = "秒数";
            // 
            // TxtFrameRate
            // 
            this.TxtFrameRate.Location = new System.Drawing.Point(138, 8);
            this.TxtFrameRate.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.TxtFrameRate.Name = "TxtFrameRate";
            this.TxtFrameRate.Size = new System.Drawing.Size(52, 27);
            this.TxtFrameRate.TabIndex = 1;
            this.TxtFrameRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.TxtFrameRate.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // LbFrameRate
            // 
            this.LbFrameRate.AutoSize = true;
            this.LbFrameRate.Location = new System.Drawing.Point(10, 11);
            this.LbFrameRate.Name = "LbFrameRate";
            this.LbFrameRate.Size = new System.Drawing.Size(122, 20);
            this.LbFrameRate.TabIndex = 0;
            this.LbFrameRate.Text = "フレームレート";
            // 
            // LbRoteteParameter
            // 
            this.LbRoteteParameter.AutoSize = true;
            this.LbRoteteParameter.Location = new System.Drawing.Point(10, 10);
            this.LbRoteteParameter.Name = "LbRoteteParameter";
            this.LbRoteteParameter.Size = new System.Drawing.Size(203, 20);
            this.LbRoteteParameter.TabIndex = 0;
            this.LbRoteteParameter.Text = "回転に関するパラメータ";
            // 
            // TabPageCombineImages
            // 
            this.TabPageCombineImages.Controls.Add(this.CombineImagesControl);
            this.TabPageCombineImages.Location = new System.Drawing.Point(4, 30);
            this.TabPageCombineImages.Name = "TabPageCombineImages";
            this.TabPageCombineImages.Size = new System.Drawing.Size(972, 668);
            this.TabPageCombineImages.TabIndex = 1;
            this.TabPageCombineImages.Text = "画像データ連結";
            // 
            // CombineImagesControl
            // 
            this.CombineImagesControl.AutoScroll = true;
            this.CombineImagesControl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.CombineImagesControl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.CombineImagesControl.Dock = System.Windows.Forms.DockStyle.Left;
            this.CombineImagesControl.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.CombineImagesControl.IsRuning = false;
            this.CombineImagesControl.Location = new System.Drawing.Point(0, 0);
            this.CombineImagesControl.Name = "CombineImagesControl";
            this.CombineImagesControl.Size = new System.Drawing.Size(561, 668);
            this.CombineImagesControl.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(980, 738);
            this.Controls.Add(this.TabControl);
            this.Controls.Add(this.MenuMain);
            this.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(100, 100);
            this.MainMenuStrip = this.MenuMain;
            this.Margin = new System.Windows.Forms.Padding(7, 5, 7, 5);
            this.Name = "MainForm";
            this.Text = "回転GIF画像";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.MenuMain.ResumeLayout(false);
            this.MenuMain.PerformLayout();
            this.TabControl.ResumeLayout(false);
            this.TabPageRotate.ResumeLayout(false);
            this.PlFill.ResumeLayout(false);
            this.PlFill.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxPreview)).EndInit();
            this.PlRun.ResumeLayout(false);
            this.PlLeft.ResumeLayout(false);
            this.PlParameter.ResumeLayout(false);
            this.PlParameter.PerformLayout();
            this.PlRoop.ResumeLayout(false);
            this.PlRoop.PerformLayout();
            this.PlRoopSettings.ResumeLayout(false);
            this.PlRoopSettings.PerformLayout();
            this.PlRoopCount.ResumeLayout(false);
            this.PlRoopCount.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TxtRoopCount)).EndInit();
            this.PlChangeCanvas.ResumeLayout(false);
            this.PlChangeCanvasSize.ResumeLayout(false);
            this.PlChangeCanvasSize.PerformLayout();
            this.PlChangeCanvasSizeSelectSize.ResumeLayout(false);
            this.PlChangeCanvasSizeSelectSize.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TxtChangeCanvasSizeSelectSizeHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtChangeCanvasSizeSelectSizeWidth)).EndInit();
            this.PlChangeCanvasCenter.ResumeLayout(false);
            this.PlChangeCanvasCenter.PerformLayout();
            this.PlChangeCanvasCenterPoint.ResumeLayout(false);
            this.PlChangeCanvasCenterPoint.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TxtChangeCanvasCenterPointY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtChangeCanvasCenterPointX)).EndInit();
            this.PlRoteteParameter.ResumeLayout(false);
            this.PlRoteteParameter.PerformLayout();
            this.PlRoteteParameterFile.ResumeLayout(false);
            this.PlRoteteParameterFile.PerformLayout();
            this.PlRoteteParameterInput.ResumeLayout(false);
            this.PlRoteteParameterInput.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TxtAcceleteRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtInitialSpeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtSeconds)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtFrameRate)).EndInit();
            this.TabPageCombineImages.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip MenuMain;
        private System.Windows.Forms.ToolStripMenuItem MenuItemOption;
        private System.Windows.Forms.ToolStripMenuItem MenuItemOutputPng;
        private System.Windows.Forms.ToolStripSeparator MenuItemOptionHyphen1;
        private System.Windows.Forms.ToolStripMenuItem MenuItemOptionChangeBackgroundOfImageArea;
        private System.Windows.Forms.ToolStripMenuItem MenuItemOptionChangeBackgroundOfImageAreaWhite;
        private System.Windows.Forms.ToolStripMenuItem MenuItemOptionChangeBackgroundOfImageAreaBlack;
        private System.Windows.Forms.ToolStripSeparator MenuItemOptionHyphen2;
        private System.Windows.Forms.ToolStripMenuItem MenuItemRestoreDefaultSettings;
        private System.Windows.Forms.ToolStripMenuItem MenuItemLanguage;
        private System.Windows.Forms.ToolStripMenuItem MenuItemLanguageJapanese;
        private System.Windows.Forms.ToolStripMenuItem MenuItemLanguageEnglish;
        private System.Windows.Forms.TabControl TabControl;
        private System.Windows.Forms.TabPage TabPageRotate;
        private System.Windows.Forms.Panel PlFill;
        private System.Windows.Forms.PictureBox PictureBoxPreview;
        private System.Windows.Forms.ProgressBar ProgressBarCreateGif;
        private System.Windows.Forms.TableLayoutPanel PlRun;
        private System.Windows.Forms.Button BtStop;
        private System.Windows.Forms.Button BtRun;
        private System.Windows.Forms.Button BtPreview;
        private System.Windows.Forms.Splitter Splitter;
        private System.Windows.Forms.Panel PlLeft;
        private System.Windows.Forms.Panel PlParameter;
        private System.Windows.Forms.Label LbRotateToEndExplain;
        private System.Windows.Forms.CheckBox ChkRotateToEnd;
        private System.Windows.Forms.Panel PlRoop;
        private System.Windows.Forms.Panel PlRoopSettings;
        private System.Windows.Forms.CheckBox ChkRoopInfinite;
        private System.Windows.Forms.Panel PlRoopCount;
        private System.Windows.Forms.NumericUpDown TxtRoopCount;
        private System.Windows.Forms.Label LbRoopCount;
        private System.Windows.Forms.CheckBox ChkRoop;
        private System.Windows.Forms.Label LbRoop;
        private System.Windows.Forms.Panel PlChangeCanvas;
        private System.Windows.Forms.Panel PlChangeCanvasSize;
        private System.Windows.Forms.Button BtChangeCanvasPreviewClear;
        private System.Windows.Forms.Button BtChangeCanvasPreviewRotate15;
        private System.Windows.Forms.Button BtChangeCanvasPreview;
        private System.Windows.Forms.Label LbChangeCanvasSizeExplain;
        private System.Windows.Forms.Panel PlChangeCanvasSizeSelectSize;
        private System.Windows.Forms.NumericUpDown TxtChangeCanvasSizeSelectSizeWidth;
        private System.Windows.Forms.Label LbChangeCanvasSizeSelectSizeWidth;
        private System.Windows.Forms.NumericUpDown TxtChangeCanvasSizeSelectSizeHeight;
        private System.Windows.Forms.Label LbChangeCanvasSizeSelectSizeHeight;
        private System.Windows.Forms.RadioButton RdoChangeCanvasSizeSelectSize;
        private System.Windows.Forms.RadioButton RdoChangeCanvasSizeDiagonalSize;
        private System.Windows.Forms.RadioButton RdoChangeCanvasSizeNoChange;
        private System.Windows.Forms.Label LbChangeCanvasSize;
        private System.Windows.Forms.Panel PlChangeCanvasCenter;
        private System.Windows.Forms.CheckBox ChkChangeCanvasPreviewCenterLine;
        private System.Windows.Forms.Panel PlChangeCanvasCenterPoint;
        private System.Windows.Forms.NumericUpDown TxtChangeCanvasCenterPointY;
        private System.Windows.Forms.Label LbChangeCanvasCenterPointY;
        private System.Windows.Forms.NumericUpDown TxtChangeCanvasCenterPointX;
        private System.Windows.Forms.Label LbChangeCanvasCenterPointX;
        private System.Windows.Forms.CheckBox ChkChangeCanvasCenter;
        private System.Windows.Forms.Label LbChangeCanvas;
        private System.Windows.Forms.Panel PlRoteteParameter;
        private System.Windows.Forms.Panel PlRoteteParameterFile;
        private System.Windows.Forms.Button BtRoteteParameterFileClear;
        private System.Windows.Forms.Button BtRoteteParameterFileSelect;
        private System.Windows.Forms.TextBox TxtRoteteParameterFile;
        private System.Windows.Forms.Label LbRoteteParameterFile;
        private System.Windows.Forms.Label LbRoteteParameterExplain;
        private System.Windows.Forms.Label LbRoteteParameterOR;
        private System.Windows.Forms.Panel PlRoteteParameterInput;
        private System.Windows.Forms.NumericUpDown TxtAcceleteRate;
        private System.Windows.Forms.Label LbAcceleteRate;
        private System.Windows.Forms.NumericUpDown TxtInitialSpeed;
        private System.Windows.Forms.Label LbInitialSpeed;
        private System.Windows.Forms.NumericUpDown TxtSeconds;
        private System.Windows.Forms.Label LbSeconds;
        private System.Windows.Forms.NumericUpDown TxtFrameRate;
        private System.Windows.Forms.Label LbFrameRate;
        private System.Windows.Forms.Label LbRoteteParameter;
        private System.Windows.Forms.TabPage TabPageCombineImages;
        private CombineImagesControl CombineImagesControl;
    }
}