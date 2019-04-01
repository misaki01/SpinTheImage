namespace SpinTheImage.Forms
{
    partial class CombineImagesControl
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
            this.PlContent = new System.Windows.Forms.Panel();
            this.ProgressBarCreateGif = new System.Windows.Forms.ProgressBar();
            this.PlRun = new System.Windows.Forms.TableLayoutPanel();
            this.BtRun = new System.Windows.Forms.Button();
            this.BtStop = new System.Windows.Forms.Button();
            this.PlParameter = new System.Windows.Forms.Panel();
            this.PlRoop = new System.Windows.Forms.Panel();
            this.PlRoopSettings = new System.Windows.Forms.Panel();
            this.ChkRoopInfinite = new System.Windows.Forms.CheckBox();
            this.PlRoopCount = new System.Windows.Forms.Panel();
            this.TxtRoopCount = new System.Windows.Forms.NumericUpDown();
            this.LbRoopCount = new System.Windows.Forms.Label();
            this.ChkRoop = new System.Windows.Forms.CheckBox();
            this.LbRoop = new System.Windows.Forms.Label();
            this.PlAppendGif = new System.Windows.Forms.Panel();
            this.LbAppendGifExplain = new System.Windows.Forms.Label();
            this.BtAppendGifClear = new System.Windows.Forms.Button();
            this.BtAppendGifFileSelect = new System.Windows.Forms.Button();
            this.TxtAppendGif = new System.Windows.Forms.TextBox();
            this.LbAppendGif = new System.Windows.Forms.Label();
            this.PlImageDirectory = new System.Windows.Forms.Panel();
            this.BtImageDirectoryClear = new System.Windows.Forms.Button();
            this.BtImageDirectorySelect = new System.Windows.Forms.Button();
            this.TxtImageDirectory = new System.Windows.Forms.TextBox();
            this.LbImageDirectory = new System.Windows.Forms.Label();
            this.LbFrameRateExplain = new System.Windows.Forms.Label();
            this.TxtFrameRate = new System.Windows.Forms.NumericUpDown();
            this.LbFrameRate = new System.Windows.Forms.Label();
            this.LbTitle = new System.Windows.Forms.Label();
            this.PlContent.SuspendLayout();
            this.PlRun.SuspendLayout();
            this.PlParameter.SuspendLayout();
            this.PlRoop.SuspendLayout();
            this.PlRoopSettings.SuspendLayout();
            this.PlRoopCount.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TxtRoopCount)).BeginInit();
            this.PlAppendGif.SuspendLayout();
            this.PlImageDirectory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TxtFrameRate)).BeginInit();
            this.SuspendLayout();
            // 
            // PlContent
            // 
            this.PlContent.AutoSize = true;
            this.PlContent.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.PlContent.Controls.Add(this.ProgressBarCreateGif);
            this.PlContent.Controls.Add(this.PlRun);
            this.PlContent.Controls.Add(this.PlParameter);
            this.PlContent.Controls.Add(this.LbTitle);
            this.PlContent.Location = new System.Drawing.Point(0, 0);
            this.PlContent.Margin = new System.Windows.Forms.Padding(0, 0, 21, 0);
            this.PlContent.Name = "PlContent";
            this.PlContent.Size = new System.Drawing.Size(540, 522);
            this.PlContent.TabIndex = 0;
            // 
            // ProgressBarCreateGif
            // 
            this.ProgressBarCreateGif.Location = new System.Drawing.Point(10, 499);
            this.ProgressBarCreateGif.Margin = new System.Windows.Forms.Padding(0);
            this.ProgressBarCreateGif.Name = "ProgressBarCreateGif";
            this.ProgressBarCreateGif.Size = new System.Drawing.Size(530, 23);
            this.ProgressBarCreateGif.TabIndex = 3;
            // 
            // PlRun
            // 
            this.PlRun.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.PlRun.ColumnCount = 2;
            this.PlRun.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.PlRun.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.PlRun.Controls.Add(this.BtRun, 0, 0);
            this.PlRun.Controls.Add(this.BtStop, 1, 0);
            this.PlRun.Location = new System.Drawing.Point(10, 408);
            this.PlRun.Margin = new System.Windows.Forms.Padding(0);
            this.PlRun.Name = "PlRun";
            this.PlRun.RowCount = 1;
            this.PlRun.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.PlRun.Size = new System.Drawing.Size(530, 92);
            this.PlRun.TabIndex = 2;
            // 
            // BtRun
            // 
            this.BtRun.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.BtRun.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtRun.Dock = System.Windows.Forms.DockStyle.Left;
            this.BtRun.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.BtRun.FlatAppearance.BorderSize = 3;
            this.BtRun.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.BtRun.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Maroon;
            this.BtRun.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtRun.Font = new System.Drawing.Font("MS UI Gothic", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.BtRun.ForeColor = System.Drawing.Color.White;
            this.BtRun.Location = new System.Drawing.Point(11, 11);
            this.BtRun.Margin = new System.Windows.Forms.Padding(10);
            this.BtRun.Name = "BtRun";
            this.BtRun.Size = new System.Drawing.Size(120, 70);
            this.BtRun.TabIndex = 0;
            this.BtRun.Text = "実行";
            this.BtRun.UseVisualStyleBackColor = false;
            this.BtRun.Click += new System.EventHandler(this.BtRun_Click);
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
            this.BtStop.Location = new System.Drawing.Point(399, 11);
            this.BtStop.Margin = new System.Windows.Forms.Padding(10);
            this.BtStop.Name = "BtStop";
            this.BtStop.Size = new System.Drawing.Size(120, 70);
            this.BtStop.TabIndex = 1;
            this.BtStop.Text = "停止";
            this.BtStop.UseVisualStyleBackColor = false;
            this.BtStop.Click += new System.EventHandler(this.BtStop_Click);
            // 
            // PlParameter
            // 
            this.PlParameter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PlParameter.Controls.Add(this.PlRoop);
            this.PlParameter.Controls.Add(this.PlAppendGif);
            this.PlParameter.Controls.Add(this.PlImageDirectory);
            this.PlParameter.Controls.Add(this.LbFrameRateExplain);
            this.PlParameter.Controls.Add(this.TxtFrameRate);
            this.PlParameter.Controls.Add(this.LbFrameRate);
            this.PlParameter.Location = new System.Drawing.Point(10, 33);
            this.PlParameter.Margin = new System.Windows.Forms.Padding(0);
            this.PlParameter.Name = "PlParameter";
            this.PlParameter.Size = new System.Drawing.Size(530, 376);
            this.PlParameter.TabIndex = 1;
            // 
            // PlRoop
            // 
            this.PlRoop.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PlRoop.Controls.Add(this.PlRoopSettings);
            this.PlRoop.Controls.Add(this.ChkRoop);
            this.PlRoop.Controls.Add(this.LbRoop);
            this.PlRoop.Location = new System.Drawing.Point(10, 286);
            this.PlRoop.Name = "PlRoop";
            this.PlRoop.Size = new System.Drawing.Size(508, 77);
            this.PlRoop.TabIndex = 5;
            // 
            // PlRoopSettings
            // 
            this.PlRoopSettings.AutoSize = true;
            this.PlRoopSettings.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.PlRoopSettings.Controls.Add(this.ChkRoopInfinite);
            this.PlRoopSettings.Controls.Add(this.PlRoopCount);
            this.PlRoopSettings.Location = new System.Drawing.Point(163, 34);
            this.PlRoopSettings.Name = "PlRoopSettings";
            this.PlRoopSettings.Size = new System.Drawing.Size(283, 33);
            this.PlRoopSettings.TabIndex = 2;
            // 
            // ChkRoopInfinite
            // 
            this.ChkRoopInfinite.AutoSize = true;
            this.ChkRoopInfinite.Checked = true;
            this.ChkRoopInfinite.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ChkRoopInfinite.Location = new System.Drawing.Point(210, 6);
            this.ChkRoopInfinite.Name = "ChkRoopInfinite";
            this.ChkRoopInfinite.Size = new System.Drawing.Size(70, 24);
            this.ChkRoopInfinite.TabIndex = 1;
            this.ChkRoopInfinite.Text = "無限";
            this.ChkRoopInfinite.UseVisualStyleBackColor = true;
            this.ChkRoopInfinite.CheckedChanged += new System.EventHandler(this.ChkRoopInfinite_CheckedChanged);
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
            1,
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
            this.ChkRoop.Checked = true;
            this.ChkRoop.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ChkRoop.Location = new System.Drawing.Point(10, 40);
            this.ChkRoop.Name = "ChkRoop";
            this.ChkRoop.Size = new System.Drawing.Size(150, 24);
            this.ChkRoop.TabIndex = 1;
            this.ChkRoop.Text = "ループするか？";
            this.ChkRoop.UseVisualStyleBackColor = true;
            this.ChkRoop.CheckedChanged += new System.EventHandler(this.ChkRoop_CheckedChanged);
            // 
            // LbRoop
            // 
            this.LbRoop.AutoSize = true;
            this.LbRoop.Location = new System.Drawing.Point(10, 10);
            this.LbRoop.Name = "LbRoop";
            this.LbRoop.Size = new System.Drawing.Size(118, 20);
            this.LbRoop.TabIndex = 0;
            this.LbRoop.Text = "ループの設定";
            // 
            // PlAppendGif
            // 
            this.PlAppendGif.AllowDrop = true;
            this.PlAppendGif.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PlAppendGif.Controls.Add(this.LbAppendGifExplain);
            this.PlAppendGif.Controls.Add(this.BtAppendGifClear);
            this.PlAppendGif.Controls.Add(this.BtAppendGifFileSelect);
            this.PlAppendGif.Controls.Add(this.TxtAppendGif);
            this.PlAppendGif.Controls.Add(this.LbAppendGif);
            this.PlAppendGif.Location = new System.Drawing.Point(10, 155);
            this.PlAppendGif.Name = "PlAppendGif";
            this.PlAppendGif.Size = new System.Drawing.Size(508, 119);
            this.PlAppendGif.TabIndex = 4;
            this.PlAppendGif.DragDrop += new System.Windows.Forms.DragEventHandler(this.AppendGif_DragDrop);
            this.PlAppendGif.DragEnter += new System.Windows.Forms.DragEventHandler(this.AppendGif_DragEnter);
            // 
            // LbAppendGifExplain
            // 
            this.LbAppendGifExplain.AutoSize = true;
            this.LbAppendGifExplain.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.LbAppendGifExplain.Location = new System.Drawing.Point(2, 73);
            this.LbAppendGifExplain.Name = "LbAppendGifExplain";
            this.LbAppendGifExplain.Size = new System.Drawing.Size(503, 36);
            this.LbAppendGifExplain.TabIndex = 4;
            this.LbAppendGifExplain.Text = "上記はフォルダ内の画像データを指定したGifに追加する場合に指定する。\r\n指定した場合は、指定したGifファイルの最後のフレームにフォルダ内の画像データがフレーム" +
    "として追加する。\r\n指定しない場合は新規にGifファイルを生成する。";
            // 
            // BtAppendGifClear
            // 
            this.BtAppendGifClear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.BtAppendGifClear.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtAppendGifClear.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.BtAppendGifClear.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.BtAppendGifClear.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Maroon;
            this.BtAppendGifClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtAppendGifClear.ForeColor = System.Drawing.Color.White;
            this.BtAppendGifClear.Location = new System.Drawing.Point(423, 36);
            this.BtAppendGifClear.Name = "BtAppendGifClear";
            this.BtAppendGifClear.Size = new System.Drawing.Size(75, 29);
            this.BtAppendGifClear.TabIndex = 3;
            this.BtAppendGifClear.Text = "クリア";
            this.BtAppendGifClear.UseVisualStyleBackColor = false;
            this.BtAppendGifClear.Click += new System.EventHandler(this.BtAppendGifClear_Click);
            // 
            // BtAppendGifFileSelect
            // 
            this.BtAppendGifFileSelect.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.BtAppendGifFileSelect.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtAppendGifFileSelect.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.BtAppendGifFileSelect.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.BtAppendGifFileSelect.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Maroon;
            this.BtAppendGifFileSelect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtAppendGifFileSelect.ForeColor = System.Drawing.Color.White;
            this.BtAppendGifFileSelect.Location = new System.Drawing.Point(342, 36);
            this.BtAppendGifFileSelect.Name = "BtAppendGifFileSelect";
            this.BtAppendGifFileSelect.Size = new System.Drawing.Size(75, 29);
            this.BtAppendGifFileSelect.TabIndex = 2;
            this.BtAppendGifFileSelect.Text = "選択";
            this.BtAppendGifFileSelect.UseVisualStyleBackColor = false;
            this.BtAppendGifFileSelect.Click += new System.EventHandler(this.BtAppendGifFileSelect_Click);
            // 
            // TxtAppendGif
            // 
            this.TxtAppendGif.AllowDrop = true;
            this.TxtAppendGif.Location = new System.Drawing.Point(10, 37);
            this.TxtAppendGif.Name = "TxtAppendGif";
            this.TxtAppendGif.ReadOnly = true;
            this.TxtAppendGif.Size = new System.Drawing.Size(325, 27);
            this.TxtAppendGif.TabIndex = 1;
            this.TxtAppendGif.Text = "ファイル選択 又は ドラッグ&ドロップ";
            this.TxtAppendGif.DragDrop += new System.Windows.Forms.DragEventHandler(this.AppendGif_DragDrop);
            this.TxtAppendGif.DragEnter += new System.Windows.Forms.DragEventHandler(this.AppendGif_DragEnter);
            // 
            // LbAppendGif
            // 
            this.LbAppendGif.AutoSize = true;
            this.LbAppendGif.Location = new System.Drawing.Point(10, 11);
            this.LbAppendGif.Name = "LbAppendGif";
            this.LbAppendGif.Size = new System.Drawing.Size(462, 20);
            this.LbAppendGif.TabIndex = 0;
            this.LbAppendGif.Text = "Gifファイルに追記する場合の元となるGifファイルを選択";
            // 
            // PlImageDirectory
            // 
            this.PlImageDirectory.AllowDrop = true;
            this.PlImageDirectory.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PlImageDirectory.Controls.Add(this.BtImageDirectoryClear);
            this.PlImageDirectory.Controls.Add(this.BtImageDirectorySelect);
            this.PlImageDirectory.Controls.Add(this.TxtImageDirectory);
            this.PlImageDirectory.Controls.Add(this.LbImageDirectory);
            this.PlImageDirectory.Location = new System.Drawing.Point(10, 65);
            this.PlImageDirectory.Name = "PlImageDirectory";
            this.PlImageDirectory.Size = new System.Drawing.Size(508, 78);
            this.PlImageDirectory.TabIndex = 3;
            this.PlImageDirectory.DragDrop += new System.Windows.Forms.DragEventHandler(this.ImageDirectory_DragDrop);
            this.PlImageDirectory.DragEnter += new System.Windows.Forms.DragEventHandler(this.ImageDirectory_DragEnter);
            // 
            // BtImageDirectoryClear
            // 
            this.BtImageDirectoryClear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.BtImageDirectoryClear.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtImageDirectoryClear.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.BtImageDirectoryClear.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.BtImageDirectoryClear.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Maroon;
            this.BtImageDirectoryClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtImageDirectoryClear.ForeColor = System.Drawing.Color.White;
            this.BtImageDirectoryClear.Location = new System.Drawing.Point(423, 36);
            this.BtImageDirectoryClear.Name = "BtImageDirectoryClear";
            this.BtImageDirectoryClear.Size = new System.Drawing.Size(75, 29);
            this.BtImageDirectoryClear.TabIndex = 3;
            this.BtImageDirectoryClear.Text = "クリア";
            this.BtImageDirectoryClear.UseVisualStyleBackColor = false;
            this.BtImageDirectoryClear.Click += new System.EventHandler(this.BtImageDirectoryClear_Click);
            // 
            // BtImageDirectorySelect
            // 
            this.BtImageDirectorySelect.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.BtImageDirectorySelect.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtImageDirectorySelect.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.BtImageDirectorySelect.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.BtImageDirectorySelect.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Maroon;
            this.BtImageDirectorySelect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtImageDirectorySelect.ForeColor = System.Drawing.Color.White;
            this.BtImageDirectorySelect.Location = new System.Drawing.Point(342, 36);
            this.BtImageDirectorySelect.Name = "BtImageDirectorySelect";
            this.BtImageDirectorySelect.Size = new System.Drawing.Size(75, 29);
            this.BtImageDirectorySelect.TabIndex = 2;
            this.BtImageDirectorySelect.Text = "選択";
            this.BtImageDirectorySelect.UseVisualStyleBackColor = false;
            this.BtImageDirectorySelect.Click += new System.EventHandler(this.BtImageDirectorySelect_Click);
            // 
            // TxtImageDirectory
            // 
            this.TxtImageDirectory.AllowDrop = true;
            this.TxtImageDirectory.Location = new System.Drawing.Point(10, 37);
            this.TxtImageDirectory.Name = "TxtImageDirectory";
            this.TxtImageDirectory.ReadOnly = true;
            this.TxtImageDirectory.Size = new System.Drawing.Size(326, 27);
            this.TxtImageDirectory.TabIndex = 1;
            this.TxtImageDirectory.Text = "フォルダ選択 又は ドラッグ&ドロップ";
            this.TxtImageDirectory.DragDrop += new System.Windows.Forms.DragEventHandler(this.ImageDirectory_DragDrop);
            this.TxtImageDirectory.DragEnter += new System.Windows.Forms.DragEventHandler(this.ImageDirectory_DragEnter);
            // 
            // LbImageDirectory
            // 
            this.LbImageDirectory.AutoSize = true;
            this.LbImageDirectory.Location = new System.Drawing.Point(10, 10);
            this.LbImageDirectory.Name = "LbImageDirectory";
            this.LbImageDirectory.Size = new System.Drawing.Size(236, 20);
            this.LbImageDirectory.TabIndex = 0;
            this.LbImageDirectory.Text = "画像データのフォルダを選択";
            // 
            // LbFrameRateExplain
            // 
            this.LbFrameRateExplain.AutoSize = true;
            this.LbFrameRateExplain.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.LbFrameRateExplain.Location = new System.Drawing.Point(12, 40);
            this.LbFrameRateExplain.Name = "LbFrameRateExplain";
            this.LbFrameRateExplain.Size = new System.Drawing.Size(360, 12);
            this.LbFrameRateExplain.TabIndex = 2;
            this.LbFrameRateExplain.Text = "フレームレートに設定した値で１秒間に使用する画像データの数を設定する。";
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
            this.LbFrameRate.Location = new System.Drawing.Point(10, 10);
            this.LbFrameRate.Name = "LbFrameRate";
            this.LbFrameRate.Size = new System.Drawing.Size(122, 20);
            this.LbFrameRate.TabIndex = 0;
            this.LbFrameRate.Text = "フレームレート";
            // 
            // LbTitle
            // 
            this.LbTitle.AutoSize = true;
            this.LbTitle.Location = new System.Drawing.Point(10, 10);
            this.LbTitle.Name = "LbTitle";
            this.LbTitle.Size = new System.Drawing.Size(431, 20);
            this.LbTitle.TabIndex = 0;
            this.LbTitle.Text = "フォルダ内の画像データを１つのGifファイルにまとめる";
            // 
            // CombineImagesControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Controls.Add(this.PlContent);
            this.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Name = "CombineImagesControl";
            this.Size = new System.Drawing.Size(561, 526);
            this.PlContent.ResumeLayout(false);
            this.PlContent.PerformLayout();
            this.PlRun.ResumeLayout(false);
            this.PlParameter.ResumeLayout(false);
            this.PlParameter.PerformLayout();
            this.PlRoop.ResumeLayout(false);
            this.PlRoop.PerformLayout();
            this.PlRoopSettings.ResumeLayout(false);
            this.PlRoopSettings.PerformLayout();
            this.PlRoopCount.ResumeLayout(false);
            this.PlRoopCount.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TxtRoopCount)).EndInit();
            this.PlAppendGif.ResumeLayout(false);
            this.PlAppendGif.PerformLayout();
            this.PlImageDirectory.ResumeLayout(false);
            this.PlImageDirectory.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TxtFrameRate)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel PlContent;
        private System.Windows.Forms.Label LbTitle;
        private System.Windows.Forms.Panel PlParameter;
        private System.Windows.Forms.Label LbFrameRate;
        private System.Windows.Forms.NumericUpDown TxtFrameRate;
        private System.Windows.Forms.Label LbFrameRateExplain;
        private System.Windows.Forms.Panel PlImageDirectory;
        private System.Windows.Forms.Label LbImageDirectory;
        private System.Windows.Forms.TextBox TxtImageDirectory;
        private System.Windows.Forms.Button BtImageDirectorySelect;
        private System.Windows.Forms.Button BtImageDirectoryClear;
        private System.Windows.Forms.Panel PlAppendGif;
        private System.Windows.Forms.Label LbAppendGif;
        private System.Windows.Forms.TextBox TxtAppendGif;
        private System.Windows.Forms.Button BtAppendGifFileSelect;
        private System.Windows.Forms.Button BtAppendGifClear;
        private System.Windows.Forms.Label LbAppendGifExplain;
        private System.Windows.Forms.Panel PlRoop;
        private System.Windows.Forms.Label LbRoop;
        private System.Windows.Forms.CheckBox ChkRoop;
        private System.Windows.Forms.Panel PlRoopSettings;
        private System.Windows.Forms.Panel PlRoopCount;
        private System.Windows.Forms.Label LbRoopCount;
        private System.Windows.Forms.NumericUpDown TxtRoopCount;
        private System.Windows.Forms.CheckBox ChkRoopInfinite;
        private System.Windows.Forms.TableLayoutPanel PlRun;
        private System.Windows.Forms.Button BtRun;
        private System.Windows.Forms.Button BtStop;
        private System.Windows.Forms.ProgressBar ProgressBarCreateGif;
    }
}
