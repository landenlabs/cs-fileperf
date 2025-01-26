namespace FilePerf
{
    partial class mainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mainForm));
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("C:");
            this.mainTab = new System.Windows.Forms.TabControl();
            this.ReadWriteTab = new System.Windows.Forms.TabPage();
            this.rwTab = new System.Windows.Forms.TabControl();
            this.rwTabGraph = new System.Windows.Forms.TabPage();
            this.graphPanel = new System.Windows.Forms.Panel();
            this.rwGraph = new FilePerf.BarGraph();
            this.rwTabDetail = new System.Windows.Forms.TabPage();
            this.rwListView = new System.Windows.Forms.ListView();
            this.colDrive = new System.Windows.Forms.ColumnHeader();
            this.colRecSize = new System.Windows.Forms.ColumnHeader();
            this.colReadSpd = new System.Windows.Forms.ColumnHeader();
            this.colWrtSpd = new System.Windows.Forms.ColumnHeader();
            this.settingTab = new System.Windows.Forms.TabPage();
            this.graphPropertyGrid = new System.Windows.Forms.PropertyGrid();
            this.label7 = new System.Windows.Forms.Label();
            this.rwStatus = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.rwSubTestProgressBar = new System.Windows.Forms.ProgressBar();
            this.rwTestProgressBar = new System.Windows.Forms.ProgressBar();
            this.rwDriveGrp = new System.Windows.Forms.GroupBox();
            this.addBtn = new System.Windows.Forms.Button();
            this.rwDriveList = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.rwStopBtn = new System.Windows.Forms.Button();
            this.rwPauseBtn = new System.Windows.Forms.Button();
            this.rwStartBtn = new System.Windows.Forms.Button();
            this.sizeGrp = new System.Windows.Forms.GroupBox();
            this.rwFSizeScroll = new System.Windows.Forms.HScrollBar();
            this.label4 = new System.Windows.Forms.Label();
            this.rwFSizeBox = new System.Windows.Forms.TextBox();
            this.maxGrp = new System.Windows.Forms.GroupBox();
            this.rwMaxScroller = new System.Windows.Forms.HScrollBar();
            this.label2 = new System.Windows.Forms.Label();
            this.rwMaxBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.rwTitle = new System.Windows.Forms.Label();
            this.minGrp = new System.Windows.Forms.GroupBox();
            this.rwMinScroller = new System.Windows.Forms.HScrollBar();
            this.label1 = new System.Windows.Forms.Label();
            this.rwMinBox = new System.Windows.Forms.TextBox();
            this.DirScanTab = new System.Windows.Forms.TabPage();
            this.label8 = new System.Windows.Forms.Label();
            this.dsTab = new System.Windows.Forms.TabControl();
            this.dsGraphTab = new System.Windows.Forms.TabPage();
            this.dsGraph = new FilePerf.BarGraph();
            this.dsDetailTab = new System.Windows.Forms.TabPage();
            this.dirScanTitle = new System.Windows.Forms.Label();
            this.closeBtn = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.logoPicture = new System.Windows.Forms.PictureBox();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.SaveBtn = new System.Windows.Forms.Button();
            this.printBtn = new System.Windows.Forms.Button();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.rwTableBtns = new System.Windows.Forms.TableLayoutPanel();
            this.saveRwDialog = new System.Windows.Forms.SaveFileDialog();
            this.logoTimer = new System.Windows.Forms.Timer(this.components);
            this.mainTab.SuspendLayout();
            this.ReadWriteTab.SuspendLayout();
            this.rwTab.SuspendLayout();
            this.rwTabGraph.SuspendLayout();
            this.graphPanel.SuspendLayout();
            this.rwTabDetail.SuspendLayout();
            this.settingTab.SuspendLayout();
            this.rwDriveGrp.SuspendLayout();
            this.sizeGrp.SuspendLayout();
            this.maxGrp.SuspendLayout();
            this.minGrp.SuspendLayout();
            this.DirScanTab.SuspendLayout();
            this.dsTab.SuspendLayout();
            this.dsGraphTab.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logoPicture)).BeginInit();
            this.rwTableBtns.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainTab
            // 
            this.mainTab.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.mainTab.Controls.Add(this.ReadWriteTab);
            this.mainTab.Controls.Add(this.DirScanTab);
            this.mainTab.Location = new System.Drawing.Point(26, 78);
            this.mainTab.Name = "mainTab";
            this.mainTab.SelectedIndex = 0;
            this.mainTab.Size = new System.Drawing.Size(688, 674);
            this.mainTab.TabIndex = 0;
            // 
            // ReadWriteTab
            // 
            this.ReadWriteTab.BackColor = System.Drawing.Color.Gray;
            this.ReadWriteTab.Controls.Add(this.rwTab);
            this.ReadWriteTab.Controls.Add(this.label7);
            this.ReadWriteTab.Controls.Add(this.rwStatus);
            this.ReadWriteTab.Controls.Add(this.label6);
            this.ReadWriteTab.Controls.Add(this.label5);
            this.ReadWriteTab.Controls.Add(this.rwSubTestProgressBar);
            this.ReadWriteTab.Controls.Add(this.rwTestProgressBar);
            this.ReadWriteTab.Controls.Add(this.rwDriveGrp);
            this.ReadWriteTab.Controls.Add(this.rwStopBtn);
            this.ReadWriteTab.Controls.Add(this.rwPauseBtn);
            this.ReadWriteTab.Controls.Add(this.rwStartBtn);
            this.ReadWriteTab.Controls.Add(this.sizeGrp);
            this.ReadWriteTab.Controls.Add(this.maxGrp);
            this.ReadWriteTab.Controls.Add(this.label3);
            this.ReadWriteTab.Controls.Add(this.rwTitle);
            this.ReadWriteTab.Controls.Add(this.minGrp);
            this.ReadWriteTab.Location = new System.Drawing.Point(4, 22);
            this.ReadWriteTab.Name = "ReadWriteTab";
            this.ReadWriteTab.Padding = new System.Windows.Forms.Padding(3);
            this.ReadWriteTab.Size = new System.Drawing.Size(680, 648);
            this.ReadWriteTab.TabIndex = 0;
            this.ReadWriteTab.Text = "Read/Write";
            // 
            // rwTab
            // 
            this.rwTab.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.rwTab.Controls.Add(this.rwTabGraph);
            this.rwTab.Controls.Add(this.rwTabDetail);
            this.rwTab.Controls.Add(this.settingTab);
            this.rwTab.Location = new System.Drawing.Point(153, 302);
            this.rwTab.Name = "rwTab";
            this.rwTab.SelectedIndex = 0;
            this.rwTab.Size = new System.Drawing.Size(510, 338);
            this.rwTab.TabIndex = 16;
            // 
            // rwTabGraph
            // 
            this.rwTabGraph.Controls.Add(this.graphPanel);
            this.rwTabGraph.Location = new System.Drawing.Point(4, 22);
            this.rwTabGraph.Name = "rwTabGraph";
            this.rwTabGraph.Padding = new System.Windows.Forms.Padding(3);
            this.rwTabGraph.Size = new System.Drawing.Size(502, 312);
            this.rwTabGraph.TabIndex = 0;
            this.rwTabGraph.Text = "Graph";
            this.rwTabGraph.UseVisualStyleBackColor = true;
            // 
            // graphPanel
            // 
            this.graphPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.graphPanel.BackColor = System.Drawing.Color.Black;
            this.graphPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.graphPanel.Controls.Add(this.rwGraph);
            this.graphPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.graphPanel.Location = new System.Drawing.Point(3, 3);
            this.graphPanel.Name = "graphPanel";
            this.graphPanel.Size = new System.Drawing.Size(496, 306);
            this.graphPanel.TabIndex = 5;
            // 
            // rwGraph
            // 
            this.rwGraph.AutoSize = true;
            this.rwGraph.BackColor = System.Drawing.Color.Transparent;
            this.rwGraph.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rwGraph.Location = new System.Drawing.Point(0, 0);
            this.rwGraph.Name = "rwGraph";
            this.rwGraph.Settings = ((object)(resources.GetObject("rwGraph.Settings")));
            this.rwGraph.Size = new System.Drawing.Size(494, 304);
            this.rwGraph.TabIndex = 0;
            // 
            // rwTabDetail
            // 
            this.rwTabDetail.Controls.Add(this.rwListView);
            this.rwTabDetail.Location = new System.Drawing.Point(4, 22);
            this.rwTabDetail.Name = "rwTabDetail";
            this.rwTabDetail.Padding = new System.Windows.Forms.Padding(3);
            this.rwTabDetail.Size = new System.Drawing.Size(502, 312);
            this.rwTabDetail.TabIndex = 1;
            this.rwTabDetail.Text = "Detail";
            this.rwTabDetail.UseVisualStyleBackColor = true;
            // 
            // rwListView
            // 
            this.rwListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colDrive,
            this.colRecSize,
            this.colReadSpd,
            this.colWrtSpd});
            this.rwListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rwListView.GridLines = true;
            this.rwListView.HideSelection = false;
            this.rwListView.Location = new System.Drawing.Point(3, 3);
            this.rwListView.Name = "rwListView";
            this.rwListView.Size = new System.Drawing.Size(496, 306);
            this.rwListView.TabIndex = 0;
            this.rwListView.UseCompatibleStateImageBehavior = false;
            this.rwListView.View = System.Windows.Forms.View.Details;
            this.rwListView.DoubleClick += new System.EventHandler(this.ListViewDbl_Click);
            // 
            // colDrive
            // 
            this.colDrive.Text = "Drive";
            // 
            // colRecSize
            // 
            this.colRecSize.Text = "Record Size";
            this.colRecSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colRecSize.Width = 100;
            // 
            // colReadSpd
            // 
            this.colReadSpd.Text = "Read KB/s";
            this.colReadSpd.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colReadSpd.Width = 100;
            // 
            // colWrtSpd
            // 
            this.colWrtSpd.Text = "Write KB/s";
            this.colWrtSpd.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colWrtSpd.Width = 100;
            // 
            // settingTab
            // 
            this.settingTab.Controls.Add(this.graphPropertyGrid);
            this.settingTab.Location = new System.Drawing.Point(4, 22);
            this.settingTab.Name = "settingTab";
            this.settingTab.Size = new System.Drawing.Size(502, 312);
            this.settingTab.TabIndex = 2;
            this.settingTab.Text = "Settings";
            this.settingTab.UseVisualStyleBackColor = true;
            // 
            // graphPropertyGrid
            // 
            this.graphPropertyGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.graphPropertyGrid.Location = new System.Drawing.Point(0, 0);
            this.graphPropertyGrid.Name = "graphPropertyGrid";
            this.graphPropertyGrid.Size = new System.Drawing.Size(502, 312);
            this.graphPropertyGrid.TabIndex = 0;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(32, 265);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(47, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "Status:";
            // 
            // rwStatus
            // 
            this.rwStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.rwStatus.BackColor = System.Drawing.Color.LightGray;
            this.rwStatus.Location = new System.Drawing.Point(114, 262);
            this.rwStatus.Name = "rwStatus";
            this.rwStatus.ReadOnly = true;
            this.rwStatus.Size = new System.Drawing.Size(537, 20);
            this.rwStatus.TabIndex = 14;
            this.toolTip.SetToolTip(this.rwStatus, "Status Info");
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(32, 238);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "SubTest:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(32, 219);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "OverAll:";
            // 
            // rwSubTestProgressBar
            // 
            this.rwSubTestProgressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.rwSubTestProgressBar.Location = new System.Drawing.Point(114, 238);
            this.rwSubTestProgressBar.Name = "rwSubTestProgressBar";
            this.rwSubTestProgressBar.Size = new System.Drawing.Size(538, 18);
            this.rwSubTestProgressBar.Step = 1;
            this.rwSubTestProgressBar.TabIndex = 11;
            this.toolTip.SetToolTip(this.rwSubTestProgressBar, "Subtest progress, such as reading record size 512");
            // 
            // rwTestProgressBar
            // 
            this.rwTestProgressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.rwTestProgressBar.Location = new System.Drawing.Point(114, 214);
            this.rwTestProgressBar.Name = "rwTestProgressBar";
            this.rwTestProgressBar.Size = new System.Drawing.Size(538, 18);
            this.rwTestProgressBar.Step = 1;
            this.rwTestProgressBar.TabIndex = 10;
            this.toolTip.SetToolTip(this.rwTestProgressBar, "OverAll test progress");
            // 
            // rwDriveGrp
            // 
            this.rwDriveGrp.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.rwDriveGrp.Controls.Add(this.addBtn);
            this.rwDriveGrp.Controls.Add(this.rwDriveList);
            this.rwDriveGrp.ForeColor = System.Drawing.Color.White;
            this.rwDriveGrp.Location = new System.Drawing.Point(26, 442);
            this.rwDriveGrp.Name = "rwDriveGrp";
            this.rwDriveGrp.Size = new System.Drawing.Size(96, 190);
            this.rwDriveGrp.TabIndex = 9;
            this.rwDriveGrp.TabStop = false;
            this.rwDriveGrp.Text = "Drive:";
            // 
            // addBtn
            // 
            this.addBtn.BackColor = System.Drawing.Color.White;
            this.addBtn.ForeColor = System.Drawing.Color.Black;
            this.addBtn.Location = new System.Drawing.Point(5, 14);
            this.addBtn.Margin = new System.Windows.Forms.Padding(0);
            this.addBtn.Name = "addBtn";
            this.addBtn.Size = new System.Drawing.Size(78, 25);
            this.addBtn.TabIndex = 18;
            this.addBtn.Text = "Add...";
            this.toolTip.SetToolTip(this.addBtn, "Add a custom drive/folder  such as a remote path");
            this.addBtn.UseVisualStyleBackColor = false;
            this.addBtn.Click += new System.EventHandler(this.AddDriveBtn_Click);
            // 
            // rwDriveList
            // 
            this.rwDriveList.AllowDrop = true;
            this.rwDriveList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.rwDriveList.CheckBoxes = true;
            this.rwDriveList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.rwDriveList.FullRowSelect = true;
            this.rwDriveList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.rwDriveList.HideSelection = false;
            listViewItem1.StateImageIndex = 0;
            this.rwDriveList.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1});
            this.rwDriveList.Location = new System.Drawing.Point(6, 40);
            this.rwDriveList.Name = "rwDriveList";
            this.rwDriveList.Size = new System.Drawing.Size(77, 139);
            this.rwDriveList.TabIndex = 17;
            this.rwDriveList.UseCompatibleStateImageBehavior = false;
            this.rwDriveList.View = System.Windows.Forms.View.Details;
            this.rwDriveList.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.rwDriveList_ItemChecked);
            this.rwDriveList.DoubleClick += new System.EventHandler(this.ListViewDbl_Click);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Drives";
            this.columnHeader1.Width = 200;
            // 
            // rwStopBtn
            // 
            this.rwStopBtn.Location = new System.Drawing.Point(35, 400);
            this.rwStopBtn.Name = "rwStopBtn";
            this.rwStopBtn.Size = new System.Drawing.Size(77, 25);
            this.rwStopBtn.TabIndex = 8;
            this.rwStopBtn.Text = "Stop";
            this.toolTip.SetToolTip(this.rwStopBtn, "Stop Read/Write Test");
            this.rwStopBtn.UseVisualStyleBackColor = true;
            this.rwStopBtn.Click += new System.EventHandler(this.rwStopBtn_Click);
            // 
            // rwPauseBtn
            // 
            this.rwPauseBtn.Location = new System.Drawing.Point(35, 369);
            this.rwPauseBtn.Name = "rwPauseBtn";
            this.rwPauseBtn.Size = new System.Drawing.Size(77, 25);
            this.rwPauseBtn.TabIndex = 7;
            this.rwPauseBtn.Text = "Pause";
            this.toolTip.SetToolTip(this.rwPauseBtn, "Pause Read/Write Test");
            this.rwPauseBtn.UseVisualStyleBackColor = true;
            this.rwPauseBtn.Click += new System.EventHandler(this.rwPauseBtn_Click);
            // 
            // rwStartBtn
            // 
            this.rwStartBtn.BackColor = System.Drawing.Color.White;
            this.rwStartBtn.Location = new System.Drawing.Point(33, 338);
            this.rwStartBtn.Name = "rwStartBtn";
            this.rwStartBtn.Size = new System.Drawing.Size(77, 25);
            this.rwStartBtn.TabIndex = 6;
            this.rwStartBtn.Text = "Start";
            this.toolTip.SetToolTip(this.rwStartBtn, "Start Read/Write Test");
            this.rwStartBtn.UseVisualStyleBackColor = false;
            this.rwStartBtn.Click += new System.EventHandler(this.rwStartBtn_Click);
            // 
            // sizeGrp
            // 
            this.sizeGrp.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.sizeGrp.Controls.Add(this.rwFSizeScroll);
            this.sizeGrp.Controls.Add(this.label4);
            this.sizeGrp.Controls.Add(this.rwFSizeBox);
            this.sizeGrp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.sizeGrp.ForeColor = System.Drawing.Color.White;
            this.sizeGrp.Location = new System.Drawing.Point(26, 91);
            this.sizeGrp.Name = "sizeGrp";
            this.sizeGrp.Size = new System.Drawing.Size(626, 36);
            this.sizeGrp.TabIndex = 4;
            this.sizeGrp.TabStop = false;
            this.sizeGrp.Text = "Test File Size";
            // 
            // rwFSizeScroll
            // 
            this.rwFSizeScroll.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.rwFSizeScroll.LargeChange = 1;
            this.rwFSizeScroll.Location = new System.Drawing.Point(173, 13);
            this.rwFSizeScroll.Name = "rwFSizeScroll";
            this.rwFSizeScroll.Size = new System.Drawing.Size(450, 20);
            this.rwFSizeScroll.TabIndex = 2;
            this.rwFSizeScroll.Value = 50;
            this.rwFSizeScroll.ValueChanged += new System.EventHandler(this.rwFSizeScroll_ValueChanged);
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(6, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 20);
            this.label4.TabIndex = 1;
            this.label4.Text = "Size:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rwFSizeBox
            // 
            this.rwFSizeBox.Location = new System.Drawing.Point(73, 13);
            this.rwFSizeBox.Name = "rwFSizeBox";
            this.rwFSizeBox.Size = new System.Drawing.Size(97, 20);
            this.rwFSizeBox.TabIndex = 0;
            // 
            // maxGrp
            // 
            this.maxGrp.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.maxGrp.Controls.Add(this.rwMaxScroller);
            this.maxGrp.Controls.Add(this.label2);
            this.maxGrp.Controls.Add(this.rwMaxBox);
            this.maxGrp.ForeColor = System.Drawing.Color.White;
            this.maxGrp.Location = new System.Drawing.Point(26, 172);
            this.maxGrp.Name = "maxGrp";
            this.maxGrp.Size = new System.Drawing.Size(626, 36);
            this.maxGrp.TabIndex = 3;
            this.maxGrp.TabStop = false;
            this.maxGrp.Text = "Maximum Record Size";
            // 
            // rwMaxScroller
            // 
            this.rwMaxScroller.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.rwMaxScroller.LargeChange = 1;
            this.rwMaxScroller.Location = new System.Drawing.Point(173, 13);
            this.rwMaxScroller.Name = "rwMaxScroller";
            this.rwMaxScroller.Size = new System.Drawing.Size(450, 20);
            this.rwMaxScroller.TabIndex = 2;
            this.toolTip.SetToolTip(this.rwMaxScroller, "Maximum Record Size used during Read and Write Performance timing.");
            this.rwMaxScroller.ValueChanged += new System.EventHandler(this.rwMaxScroller_ValueChanged);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(6, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Max:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rwMaxBox
            // 
            this.rwMaxBox.Location = new System.Drawing.Point(73, 13);
            this.rwMaxBox.Name = "rwMaxBox";
            this.rwMaxBox.Size = new System.Drawing.Size(97, 20);
            this.rwMaxBox.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label3.Location = new System.Drawing.Point(30, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(622, 21);
            this.label3.TabIndex = 3;
            this.label3.Text = "Create one test file and measure time to read and write sequencial records. ";
            // 
            // rwTitle
            // 
            this.rwTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.rwTitle.BackColor = System.Drawing.Color.Gainsboro;
            this.rwTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rwTitle.Location = new System.Drawing.Point(23, 27);
            this.rwTitle.Name = "rwTitle";
            this.rwTitle.Size = new System.Drawing.Size(629, 16);
            this.rwTitle.TabIndex = 2;
            this.rwTitle.Text = "Read and Write File Performance";
            this.rwTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // minGrp
            // 
            this.minGrp.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.minGrp.Controls.Add(this.rwMinScroller);
            this.minGrp.Controls.Add(this.label1);
            this.minGrp.Controls.Add(this.rwMinBox);
            this.minGrp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.minGrp.ForeColor = System.Drawing.Color.White;
            this.minGrp.Location = new System.Drawing.Point(26, 133);
            this.minGrp.Name = "minGrp";
            this.minGrp.Size = new System.Drawing.Size(626, 36);
            this.minGrp.TabIndex = 1;
            this.minGrp.TabStop = false;
            this.minGrp.Text = "Minimum Record Size";
            // 
            // rwMinScroller
            // 
            this.rwMinScroller.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.rwMinScroller.LargeChange = 1;
            this.rwMinScroller.Location = new System.Drawing.Point(173, 13);
            this.rwMinScroller.Name = "rwMinScroller";
            this.rwMinScroller.Size = new System.Drawing.Size(450, 20);
            this.rwMinScroller.TabIndex = 2;
            this.rwMinScroller.ValueChanged += new System.EventHandler(this.rwMinScroller_ValueChanged);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(6, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Min:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rwMinBox
            // 
            this.rwMinBox.Location = new System.Drawing.Point(73, 13);
            this.rwMinBox.Name = "rwMinBox";
            this.rwMinBox.Size = new System.Drawing.Size(97, 20);
            this.rwMinBox.TabIndex = 0;
            // 
            // DirScanTab
            // 
            this.DirScanTab.BackColor = System.Drawing.Color.DarkRed;
            this.DirScanTab.Controls.Add(this.label8);
            this.DirScanTab.Controls.Add(this.dsTab);
            this.DirScanTab.Controls.Add(this.dirScanTitle);
            this.DirScanTab.Location = new System.Drawing.Point(4, 22);
            this.DirScanTab.Name = "DirScanTab";
            this.DirScanTab.Padding = new System.Windows.Forms.Padding(3);
            this.DirScanTab.Size = new System.Drawing.Size(680, 648);
            this.DirScanTab.TabIndex = 1;
            this.DirScanTab.Text = "Dir Scan";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.White;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(195, 97);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(296, 29);
            this.label8.TabIndex = 2;
            this.label8.Text = "Page Not Yet Available !";
            // 
            // dsTab
            // 
            this.dsTab.Controls.Add(this.dsGraphTab);
            this.dsTab.Controls.Add(this.dsDetailTab);
            this.dsTab.Location = new System.Drawing.Point(168, 266);
            this.dsTab.Name = "dsTab";
            this.dsTab.SelectedIndex = 0;
            this.dsTab.Size = new System.Drawing.Size(490, 359);
            this.dsTab.TabIndex = 1;
            // 
            // dsGraphTab
            // 
            this.dsGraphTab.Controls.Add(this.dsGraph);
            this.dsGraphTab.Location = new System.Drawing.Point(4, 22);
            this.dsGraphTab.Name = "dsGraphTab";
            this.dsGraphTab.Padding = new System.Windows.Forms.Padding(3);
            this.dsGraphTab.Size = new System.Drawing.Size(482, 333);
            this.dsGraphTab.TabIndex = 0;
            this.dsGraphTab.Text = "Graph";
            this.dsGraphTab.UseVisualStyleBackColor = true;
            // 
            // dsGraph
            // 
            this.dsGraph.AutoSize = true;
            this.dsGraph.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.dsGraph.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dsGraph.Location = new System.Drawing.Point(3, 3);
            this.dsGraph.Name = "dsGraph";
            this.dsGraph.Settings = null;
            this.dsGraph.Size = new System.Drawing.Size(476, 327);
            this.dsGraph.TabIndex = 1;
            // 
            // dsDetailTab
            // 
            this.dsDetailTab.Location = new System.Drawing.Point(4, 22);
            this.dsDetailTab.Name = "dsDetailTab";
            this.dsDetailTab.Padding = new System.Windows.Forms.Padding(3);
            this.dsDetailTab.Size = new System.Drawing.Size(482, 333);
            this.dsDetailTab.TabIndex = 1;
            this.dsDetailTab.Text = "Detail";
            this.dsDetailTab.UseVisualStyleBackColor = true;
            // 
            // dirScanTitle
            // 
            this.dirScanTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dirScanTitle.BackColor = System.Drawing.Color.Gainsboro;
            this.dirScanTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dirScanTitle.Location = new System.Drawing.Point(17, 23);
            this.dirScanTitle.Name = "dirScanTitle";
            this.dirScanTitle.Size = new System.Drawing.Size(641, 23);
            this.dirScanTitle.TabIndex = 0;
            this.dirScanTitle.Text = "Directory Scan Performance";
            this.dirScanTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // closeBtn
            // 
            this.closeBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.closeBtn.AutoSize = true;
            this.closeBtn.Location = new System.Drawing.Point(578, 3);
            this.closeBtn.Name = "closeBtn";
            this.closeBtn.Size = new System.Drawing.Size(61, 24);
            this.closeBtn.TabIndex = 1;
            this.closeBtn.Text = "Close";
            this.toolTip.SetToolTip(this.closeBtn, "Close program and forget test results");
            this.closeBtn.UseVisualStyleBackColor = true;
            this.closeBtn.Click += new System.EventHandler(this.closeBtn_Click);
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 63);
            this.panel1.TabIndex = 2;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Black;
            this.panel2.Controls.Add(this.logoPicture);
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Location = new System.Drawing.Point(26, 9);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(616, 63);
            this.panel2.TabIndex = 3;
            // 
            // logoPicture
            // 
            this.logoPicture.Image = ((System.Drawing.Image)(resources.GetObject("logoPicture.Image")));
            this.logoPicture.Location = new System.Drawing.Point(203, 0);
            this.logoPicture.Name = "logoPicture";
            this.logoPicture.Size = new System.Drawing.Size(481, 60);
            this.logoPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.logoPicture.TabIndex = 3;
            this.logoPicture.TabStop = false;
            // 
            // SaveBtn
            // 
            this.SaveBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.SaveBtn.AutoSize = true;
            this.SaveBtn.Location = new System.Drawing.Point(3, 3);
            this.SaveBtn.Name = "SaveBtn";
            this.SaveBtn.Size = new System.Drawing.Size(61, 24);
            this.SaveBtn.TabIndex = 4;
            this.SaveBtn.Text = "Save";
            this.toolTip.SetToolTip(this.SaveBtn, "Save test results as either an image (.png) or text (.csv)");
            this.SaveBtn.UseVisualStyleBackColor = true;
            this.SaveBtn.Click += new System.EventHandler(this.SaveBtn_Click);
            // 
            // printBtn
            // 
            this.printBtn.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.printBtn.AutoSize = true;
            this.printBtn.BackColor = System.Drawing.Color.DimGray;
            this.printBtn.Location = new System.Drawing.Point(278, 3);
            this.printBtn.Name = "printBtn";
            this.printBtn.Size = new System.Drawing.Size(76, 24);
            this.printBtn.TabIndex = 5;
            this.printBtn.Text = "Print";
            this.toolTip.SetToolTip(this.printBtn, "Print - not currently implemented");
            this.printBtn.UseVisualStyleBackColor = false;
            // 
            // timer
            // 
            this.timer.Interval = 500;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // rwTableBtns
            // 
            this.rwTableBtns.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.rwTableBtns.ColumnCount = 3;
            this.rwTableBtns.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33F));
            this.rwTableBtns.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33F));
            this.rwTableBtns.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 34F));
            this.rwTableBtns.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.rwTableBtns.Controls.Add(this.SaveBtn, 0, 0);
            this.rwTableBtns.Controls.Add(this.closeBtn, 2, 0);
            this.rwTableBtns.Controls.Add(this.printBtn, 1, 0);
            this.rwTableBtns.Location = new System.Drawing.Point(47, 758);
            this.rwTableBtns.Name = "rwTableBtns";
            this.rwTableBtns.RowCount = 1;
            this.rwTableBtns.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.rwTableBtns.Size = new System.Drawing.Size(642, 30);
            this.rwTableBtns.TabIndex = 5;
            // 
            // saveRwDialog
            // 
            this.saveRwDialog.DefaultExt = "png";
            this.saveRwDialog.Filter = "Png|*.png|Csv|*.csv";
            this.saveRwDialog.Title = "Save Read/Write Test Results";
            // 
            // logoTimer
            // 
            this.logoTimer.Interval = 3000;
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(736, 797);
            this.Controls.Add(this.rwTableBtns);
            this.Controls.Add(this.mainTab);
            this.Controls.Add(this.panel2);
            this.Name = "mainForm";
            this.Text = "FilePerf - v1.0";
            this.mainTab.ResumeLayout(false);
            this.ReadWriteTab.ResumeLayout(false);
            this.ReadWriteTab.PerformLayout();
            this.rwTab.ResumeLayout(false);
            this.rwTabGraph.ResumeLayout(false);
            this.graphPanel.ResumeLayout(false);
            this.graphPanel.PerformLayout();
            this.rwTabDetail.ResumeLayout(false);
            this.settingTab.ResumeLayout(false);
            this.rwDriveGrp.ResumeLayout(false);
            this.sizeGrp.ResumeLayout(false);
            this.sizeGrp.PerformLayout();
            this.maxGrp.ResumeLayout(false);
            this.maxGrp.PerformLayout();
            this.minGrp.ResumeLayout(false);
            this.minGrp.PerformLayout();
            this.DirScanTab.ResumeLayout(false);
            this.DirScanTab.PerformLayout();
            this.dsTab.ResumeLayout(false);
            this.dsGraphTab.ResumeLayout(false);
            this.dsGraphTab.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.logoPicture)).EndInit();
            this.rwTableBtns.ResumeLayout(false);
            this.rwTableBtns.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl mainTab;
        private System.Windows.Forms.TabPage ReadWriteTab;
        private System.Windows.Forms.TabPage DirScanTab;
        private System.Windows.Forms.Button closeBtn;
        private System.Windows.Forms.GroupBox minGrp;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox rwMinBox;
        private System.Windows.Forms.HScrollBar rwMinScroller;
        private System.Windows.Forms.Label rwTitle;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox maxGrp;
        private System.Windows.Forms.HScrollBar rwMaxScroller;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox rwMaxBox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox sizeGrp;
        private System.Windows.Forms.HScrollBar rwFSizeScroll;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox rwFSizeBox;
        private System.Windows.Forms.Panel graphPanel;
        private BarGraph rwGraph;
        private System.Windows.Forms.Button rwStartBtn;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.GroupBox rwDriveGrp;
        private System.Windows.Forms.Button rwStopBtn;
        private System.Windows.Forms.Button rwPauseBtn;
        private System.Windows.Forms.ProgressBar rwSubTestProgressBar;
        private System.Windows.Forms.ProgressBar rwTestProgressBar;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox rwStatus;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TabControl rwTab;
        private System.Windows.Forms.TabPage rwTabDetail;
        private System.Windows.Forms.TabPage rwTabGraph;
        private System.Windows.Forms.ListView rwListView;
        private System.Windows.Forms.ColumnHeader colReadSpd;
        private System.Windows.Forms.ColumnHeader colWrtSpd;
        private System.Windows.Forms.ColumnHeader colRecSize;
        private System.Windows.Forms.TabPage settingTab;
        private System.Windows.Forms.PropertyGrid graphPropertyGrid;
        private System.Windows.Forms.TabControl dsTab;
        private System.Windows.Forms.TabPage dsGraphTab;
        private System.Windows.Forms.TabPage dsDetailTab;
        private System.Windows.Forms.Label dirScanTitle;
        private BarGraph dsGraph;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button SaveBtn;
        private System.Windows.Forms.TableLayoutPanel rwTableBtns;
        private System.Windows.Forms.Button printBtn;
        private System.Windows.Forms.SaveFileDialog saveRwDialog;
        private System.Windows.Forms.ListView rwDriveList;
        private System.Windows.Forms.Button addBtn;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader colDrive;
        private System.Windows.Forms.PictureBox logoPicture;
        private System.Windows.Forms.Timer logoTimer;
    }
}

