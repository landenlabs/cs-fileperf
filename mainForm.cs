using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

using wrapper;

namespace FilePerf
{
    public partial class mainForm : Form
    {
        public mainForm()
        {
            InitializeComponent();

            // TODO - Load disk drive letter pull-down

            rwInit();
            this.rwGraph.DefaultSettings();
            this.dsGraph.DefaultSettings();
            this.DefaultScanGraphSettings(this.dsGraph);
            this.RestoreSettings();
            this.graphPropertyGrid.SelectedObject = this.rwGraph.Settings;
            this.rwDriveList.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);

            this.logoTimer.Tick += new EventHandler(logoTimer_Tick);
            this.logoTimer.Start();
        }

        void logoTimer_Tick(object sender, EventArgs e)
        {
            // FrameDimension dimension = new FrameDimension(this.logoPicture.Image.FrameDimensionsList[0]);
            // int frameCount = this.logoPicture.Image.GetFrameCount(dimension);
            // this.logoPicture.Image.SelectActiveFrame(dimension, 0);

            // ImageAnimator.StopAnimate(this.logoPicture.Image, new EventHandler(OnFrameChanged));
            this.logoPicture.Image = new Bitmap(this.logoPicture.Image, this.logoPicture.Image.Size);
            logoTimer.Stop();
        }
        private void OnFrameChanged(object o, EventArgs e) 
        {
        }

        public void DefaultScanGraphSettings(BarGraph barGraph)
        {
            BarGraph.BarGraphSettings s = new BarGraph.BarGraphSettings();

            s.AutoScale = true;

            s.VlColor = Pens.Wheat;
            s.HlColor = Pens.Tan;
            s.FrameColor = Pens.Violet;

            s.BgBrush = new SolidBrush(Color.White);
            s.BgGrid = new SolidBrush(Color.LightGray);
            s.TxBrush = new SolidBrush(Color.Blue);

            s.CellSize = new Size(50, 50);
            s.BarSize = new Size(20, 20);
            s.BarMargin = new Size(2, 2);

            s.GrFont = new Font(this.Font.FontFamily, this.Font.Size, FontStyle.Bold);
            int fontHeight = s.GrFont.Height;
            s.TitleSize = new Size(0, fontHeight + 2);
            s.UlMargin = new Size(40, FontHeight + 2);
            s.LrMargin = s.UlMargin;
            s.UlMargin += s.TitleSize;

            Point left = new Point(0, 0);
            Point right = new Point(600, 0);
            s.BarBrushes = new LinearGradientBrush[2];
            s.BarBrushes[0] = new LinearGradientBrush(left, right, Color.Red, Color.DarkRed);
            s.BarBrushes[1] = new LinearGradientBrush(left, right, Color.Green, Color.DarkGreen);

            s.HTitle = "Measure Directory Scan Performance (Files/s)";
            string[] tips = new string[2] { "Read {0:F2} MB/s, {1:F0} Bytes", "Write {0:F2} MB/s, {1:F0} Bytes" };
            s.HScale = 1.0 / 1000;

            barGraph.Settings = s;
            double[] testData = new double[9] { 64, 10e3, 12e3, 256, 14e3, 16e3, 512, 21e3, 18e3 };
            barGraph.Data(testData, 3, tips);
        }

        WFilePerfCmd wFilePerfCmd = new WFilePerfCmd();
        System.Media.SoundPlayer sPlayer = new System.Media.SoundPlayer();
        

        private void closeBtn_Click(object sender, EventArgs e)
        {
            this.Close();
            wFilePerfCmd.Dispose();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            this.SaveSettings();
            base.OnClosing(e);
        }

        public void SaveSettings()
        {
            BarGraph.BarGraphSettings rwSettings = this.rwGraph.Settings as BarGraph.BarGraphSettings;

            string ourStuff = System.Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            ourStuff += @"\fileperf.xml";

#if true
            Stream stream = File.Open(ourStuff, FileMode.Create);
            BinaryFormatter bFormatter = new BinaryFormatter();
            bFormatter.Serialize(stream, rwSettings);
            stream.Close();
#endif
        }

        public void RestoreSettings()
        {
            BarGraph.BarGraphSettings rwSettings = this.rwGraph.Settings as BarGraph.BarGraphSettings;

            string ourStuff = System.Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            ourStuff += @"\fileperf.xml";

            try
            {
#if false
                Stream stream = File.Open(ourStuff, FileMode.Open);
                BinaryFormatter bFormatter = new BinaryFormatter();
                this.rwGraph.Settings = (BarGraph.BarGraphSettings)bFormatter.Deserialize(stream);
                stream.Close();
#endif
            }
            catch { };
        }

        private UInt64 ScrollValue(HScrollBar scrollBar, int minShift, int maxShift)
        {
            int rangeShift = maxShift - minShift;
            int bitShift = rangeShift * scrollBar.Value / scrollBar.Maximum + minShift;
            UInt64 one = 1;
            UInt64 val = (one << bitShift);
            return val;
        }

        string ToXBstring(UInt64 val)
        {
            const UInt64 one = 1;
            const UInt64 KB = one << 10;
            const UInt64 MB = one << 20;
            const UInt64 GB = one << 30;

            string XBstr = "";
            if (val < KB)
                XBstr = val.ToString();
            else if (val < MB)
                XBstr = ((float)val / KB).ToString() + " KB";
            else if (val < GB)
                XBstr = ((float)val / MB).ToString() + " MB";
            else
                XBstr = ((float)val / GB).ToString() + " GB";

            return XBstr;
        }

        UInt64 FromXBstring(string valStr)
        {
            int nLen = valStr.LastIndexOfAny(" 0123456789".ToCharArray());
            if (nLen <= 0)
                return 0;

            string units = valStr.Substring(nLen+1);
            UInt64 uNum = UInt64.Parse(valStr.Substring(0, nLen+1));

            const UInt64 one = 1;
            const UInt64 KB = one << 10;
            const UInt64 MB = one << 20;
            const UInt64 GB = one << 30;

            UInt64 val = 0;
            if (string.Compare(units, "KB", true) == 0)
            {
                val = uNum * KB;    
            }
            else if (string.Compare(units, "MB", true) == 0)
            {
                val = uNum * MB;    
            }
            else if (string.Compare(units, "GB", true) == 0)
            {
                val = uNum * GB;    
            }
            else
            {
                val = uNum;    
            }

            return val;
        }

        private void ButtonState(Button but, bool enable)
        {
            but.Enabled = enable;
            if (enable)
                but.BackColor = Color.White;
            else
                but.BackColor = Color.Gray;
        }

        private void rwInit()
        {
            ButtonState(this.rwStartBtn, true);
            ButtonState(this.rwPauseBtn, false);
            ButtonState(this.rwStopBtn, false);

            this.rwFSizeScroll.Value = 50;
            this.rwMinScroller.Value = 30;
            this.rwMaxScroller.Value = 50;
            rwFSizeScroll_ValueChanged(null, EventArgs.Empty);
            rwMinScroller_ValueChanged(null, EventArgs.Empty);
            rwMaxScroller_ValueChanged(null, EventArgs.Empty);

            this.rwDriveList.Items.Clear();
            Array drives = Array.ConvertAll<string, string>(System.Environment.GetLogicalDrives(),
                 delegate(string s) { return s.Trim('\\'); });
            foreach (string s in drives)
                this.rwDriveList.Items.Add(s);
        }

        private void rwSetTest()
        {
            // MRwStats rwStats = wFilePerfCmd.RwGetStats();
            this.rwListView.Items.Clear();
            UInt64 minRec = FromXBstring(this.rwMinBox.Text);
            UInt64 maxRec = FromXBstring(this.rwMaxBox.Text);

            int drvCnt = this.rwDriveList.CheckedItems.Count;
            if (drvCnt != 0)
            {
                ListViewItem item;
                while (minRec <= maxRec)
                {
					int drvIdx = 0;
                    foreach (ListViewItem drvItem in this.rwDriveList.CheckedItems)
                    {
                        item = this.rwListView.Items.Add(drvItem.Text);
						item.SubItems[0].Tag = drvIdx++; //  drvItem.Index;
                        item.SubItems.Add(minRec.ToString());
                        item.SubItems.Add("0");
                        item.SubItems.Add("0");
                    }
                    minRec *= 2;
                }
            }
            else
            {
                ListViewItem item = this.rwListView.Items.Add("No Driver");
                item.SubItems.Add("selected");
                item.ForeColor = Color.Red;
            }
        }

        private void rwTimerDelegate()
        {
            MRwStats rwStats = wFilePerfCmd.RwGetStats();

            if (rwStats.runningTest == -1)
            {
                this.rwSubTestProgressBar.Value = rwStats.makeFilePercent;
                this.rwTestProgressBar.Value = 0;
                SetRwStatus("Creating Test File", false);
                this.sPlayer.SoundLocation = @"c:\windows\media\tada.wav";
                this.sPlayer.Play();
            }
            else if (rwStats.runningTest == -2)
            {                                     
                // Test done

                rwStopBtn_Click(null, EventArgs.Empty);
                SetRwStatus("Done", false);
                this.rwTestProgressBar.Value = 0;
                this.rwSubTestProgressBar.Value = 0;

                rwStats = wFilePerfCmd.RwGetFullStats();
                // Convert.FromBase64CharArray(rwStats.message, 0, rwStats.message.Length);
                // string msg = System.Text.Encoding.Default.GetBytes(rwStats.message);

                this.rwGraph.Data(rwStats.pTestValues, MRwStats.eTestWidth, null);

                this.rwListView.Items.Clear();
                for (int tstIdx = 0; tstIdx < rwStats.numTests; tstIdx++)
                {
                    string[] drvList = rwStats.drvList.Split(';');
					int drvIdx = (int)rwStats.pTestValues[tstIdx * MRwStats.eTestWidth + 0];

                    ListViewItem item = this.rwListView.Items.Add(drvList[drvIdx]);
					item.SubItems[0].Tag = drvIdx;
                    item.SubItems.Add(rwStats.pTestValues[tstIdx * MRwStats.eTestWidth + 1].ToString());
                    item.SubItems.Add(rwStats.pTestValues[tstIdx * MRwStats.eTestWidth + 2].ToString("###,###,###.000"));
                    item.SubItems.Add(rwStats.pTestValues[tstIdx * MRwStats.eTestWidth + 3].ToString("###,###,###.000"));
                }

                this.sPlayer.SoundLocation = @"c:\windows\media\tada.wav";
                this.sPlayer.Play();
            }
            else if (rwStats.numTests > 0)
            {
                this.rwSubTestProgressBar.Value = rwStats.runningPercent <= 100 ?
                    rwStats.runningPercent : 100;
                this.rwTestProgressBar.Value =
                    rwStats.runningTest * 100 /
                    rwStats.numTests;

                if (rwStats.runningSubTest == 0)
                    SetRwStatus("Writing record:" + rwStats.runningSize.ToString(), false);
                else
                    SetRwStatus("Reading record:" + rwStats.runningSize.ToString(), false);

                rwStats = wFilePerfCmd.RwGetFullStats();
                if (rwStats.pTestValues != null)
                {
                    this.rwGraph.Data(rwStats.pTestValues, MRwStats.eTestWidth, null);
                    for (int tstIdx = 0; tstIdx < rwStats.numTests; tstIdx++)
                    {
                        if (this.rwListView.Items.Count <= tstIdx) 
                        {
                            ListViewItem itemTmp = this.rwListView.Items.Add("drive");
                            itemTmp.SubItems.Add("recSize");
                            itemTmp.SubItems.Add("read");
                            itemTmp.SubItems.Add("write");
                        }

                        ListViewItem item = this.rwListView.Items[tstIdx];
                        item.SubItems[0].Text = item.Text = rwStats.pTestValues[tstIdx * MRwStats.eTestWidth + MRwStats.eDrvIdx].ToString();
                        item.SubItems[1].Text = item.Text = rwStats.pTestValues[tstIdx * MRwStats.eTestWidth + MRwStats.eRecSize].ToString();
                        item.SubItems[2].Text = rwStats.pTestValues[tstIdx * MRwStats.eTestWidth + MRwStats.eReadSpd].ToString("###,###,###.000");
                        item.SubItems[3].Text = rwStats.pTestValues[tstIdx * MRwStats.eTestWidth + MRwStats.eWriteSpd].ToString("###,###,###.000");
                    }
                }
            }
           

            Application.DoEvents();
        }

        private string GetDrives()
        {
            string drives = "";
            foreach (ListViewItem driveItem in  this.rwDriveList.CheckedItems)
            {
                if (drives.Length != 0)
                    drives += ";";
                drives += driveItem.Text;
            }

            return drives;
        }

        private void rwStartBtn_Click(object sender, EventArgs e)
        {
            MRwStats rwStats = new MRwStats();
            rwStats.numTests = this.rwListView.Items.Count;
            rwStats.pTestValues = new double[this.rwListView.Items.Count * MRwStats.eTestWidth];
                
            for (int testIdx = 0; testIdx < this.rwListView.Items.Count; testIdx++)
            {
                ListViewItem item = this.rwListView.Items[testIdx];

                for (int subidx = 0; subidx < item.SubItems.Count; subidx++)
                {
					string v = item.SubItems[subidx].Text;
                    double d = (item.SubItems[subidx].Tag != null) ?
                        (int)item.SubItems[subidx].Tag :
                        double.Parse(item.SubItems[subidx].Text);

                    rwStats.pTestValues[testIdx * MRwStats.eTestWidth + subidx] = d;
                }
            }

            // wFilePerfCmd.RwSetStats(rwStats);
            rwStats.drvList = string.Empty;
            foreach (ListViewItem item in this.rwDriveList.CheckedItems)
            {
                if (rwStats.drvList.Length != 0)
                    rwStats.drvList += ";";
                rwStats.drvList += item.Text;
            }

            if (rwStats.drvList.Length > 0)
            {
                wFilePerfCmd.RwStartTest(rwStats);

                this.rwListView.Items.Clear();
                this.rwGraph.Clear();

                ButtonState(this.rwStartBtn, false);
                ButtonState(this.rwPauseBtn, true);
                ButtonState(this.rwStopBtn, true);

                this.rwTestProgressBar.Value = 0;
                this.rwSubTestProgressBar.Value = 0;
                this.timerDelegate = rwTimerDelegate;
                this.timer.Start();
            }
            else
            {
                SetRwStatus("Please check one or more Drives before pressing start", true);
            }
        }

        private void SetRwStatus(string msg, bool error)
        {
            this.rwStatus.Text = msg;
            if (error == true)
            {
                this.sPlayer.SoundLocation = @"c:\windows\media\chord.wav";
                this.sPlayer.Play();
                this.rwStatus.BackColor = Color.Red;
            }
            else
            {
                this.rwStatus.BackColor = Color.LightGray;
            }
        }

        private void rwPauseBtn_Click(object sender, EventArgs e)
        {
            if (this.rwPauseBtn.Text == "Pause")
            {
                ButtonState(this.rwStopBtn, false);
                this.rwPauseBtn.Text = "Resume";
                wFilePerfCmd.RwPauseTest();
            }
            else
            {
                ButtonState(this.rwStopBtn, true);
                this.rwPauseBtn.Text = "Pause";
                wFilePerfCmd.RwResumeTest();
            }
        }

        private void rwStopBtn_Click(object sender, EventArgs e)
        {
            ButtonState(this.rwStartBtn, true);
            ButtonState(this.rwPauseBtn, false);
            ButtonState(this.rwStopBtn, false);
            wFilePerfCmd.RwStopTest();
            this.timer.Stop();
        }

        private void rwFSizeScroll_ValueChanged(object sender, EventArgs e)
        {
            // 1<<10= 1024, 1<<20=1MB  1<<30=1GB  1<<33 = 8GB
            this.rwFSizeBox.Text = ToXBstring(ScrollValue(rwFSizeScroll, 25, 33));
        }

        private void rwMinScroller_ValueChanged(object sender, EventArgs e)
        {
            // 1<<9 =512,   1<<23 = 8MB
            this.rwMinBox.Text = ToXBstring(ScrollValue(rwMinScroller, 9, 23));
            if (rwMaxScroller.Value < rwMinScroller.Value)
                rwMaxScroller.Value = rwMinScroller.Value;
            rwSetTest();
        }

        private void rwMaxScroller_ValueChanged(object sender, EventArgs e)
        {
            // 1<<9 =512,   1<<23 = 8MB
            this.rwMaxBox.Text = ToXBstring(ScrollValue(rwMaxScroller, 9, 23));
            if (rwMinScroller.Value > rwMaxScroller.Value)
                rwMinScroller.Value = rwMaxScroller.Value;
            rwSetTest();
        }

        private void rwDriveList_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            rwSetTest();
        }

 

        private delegate void TimerDelegate();
        private TimerDelegate timerDelegate;

        private void timer_Tick(object sender, EventArgs e)
        {
            this.timerDelegate();
        }


        private Image CaptureSelf()
        {
                // Screen.PrimaryScreen.Bounds;
            Rectangle rect = this.Bounds;

            int color = Screen.PrimaryScreen.BitsPerPixel;
            PixelFormat pFormat;

            switch (color)
            {
                case 8:
                case 16:
                    pFormat = PixelFormat.Format16bppRgb565;
                    break;

                case 24:
                    pFormat = PixelFormat.Format24bppRgb;
                    break;

                case 32:
                    pFormat = PixelFormat.Format32bppArgb;
                    break;

                default:
                    pFormat = PixelFormat.Format32bppArgb;
                    break;
            }

            Application.DoEvents();
            Image image = new Bitmap(rect.Width, rect.Height, pFormat);
            Graphics g = Graphics.FromImage(image);
            g.CopyFromScreen(rect.Left, rect.Top, 0, 0, rect.Size);

            return image;
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if (saveRwDialog.ShowDialog() == DialogResult.OK)
            {
                switch (saveRwDialog.FilterIndex)
                {
                case 1: //  png
                    try
                    {
                        SetRwStatus(
                                "Date:"
                                + DateTime.Now.ToShortDateString()
                                + " "
                                + DateTime.Now.ToShortTimeString()
                                + " System:"
                                + System.Environment.MachineName
                                + " "
                                + System.Environment.OSVersion.ToString(), false);

                        CaptureSelf().Save(saveRwDialog.FileName);
                        SetRwStatus("Save to " + saveRwDialog.FileName, false);
                    }
                    catch
                    {
                        SetRwStatus("Failed to save to " + saveRwDialog.FileName, true);
                    }
                    break;

                case 2: // csv
                    if (this.rwListView != null && this.rwListView.Items.Count != 0)
                    {
                        if (this.saveRwDialog.ShowDialog() == DialogResult.OK)
                        {
                            String filePath = this.saveRwDialog.FileName;
                            TextWriter writer = new StreamWriter(filePath);

                            writer.WriteLine("Date" 
                                + DateTime.Now.ToShortDateString()
                                + " "
                                + DateTime.Now.ToShortTimeString());
                            writer.WriteLine(" System:"
                               + System.Environment.MachineName
                               + " "
                               + System.Environment.OSVersion.ToString());
                            writer.WriteLine("Measure Sequencial File Performance");
                            writer.WriteLine("Drive:" + GetDrives());
                            writer.WriteLine("");

                            string txtLine = string.Empty;
                            foreach (ColumnHeader ch in this.rwListView.Columns)
                            {
                                if (txtLine.Length != 0)
                                    txtLine += ",";
                                txtLine += ch.Text;
                            }
                            writer.WriteLine(txtLine);

                            foreach (ListViewItem item in this.rwListView.Items)
                            {
                                txtLine = string.Empty;
                                foreach (ListViewItem.ListViewSubItem subItem in item.SubItems)
                                {
                                    if (txtLine.Length != 0)
                                        txtLine += ",";
                                    txtLine += subItem.Text.Replace(',', ';');
                                }

                                writer.WriteLine(txtLine);
                            }

                            writer.Close();

                            SetRwStatus("Saved to " + filePath, false);
                        }
                    }
                    break;
                }
            }
        }

        private void AddDriveBtn_Click(object sender, EventArgs e)
        {
            DriveDialog driveDialog = new DriveDialog();
            driveDialog.Location = this.rwDriveList.PointToScreen(this.rwDriveList.Location);
            if (driveDialog.ShowDialog() == DialogResult.OK)
            {
                this.rwDriveList.Items.Insert(0, driveDialog.Disk);
            }
        }

        private void ListViewEdit(ListView listView, ListViewItem item)
        {
            // int colCnt = listView.Columns.Count;
            int colCnt = 1;
            for (int colIdx = 0; colIdx < colCnt; colIdx++)
            {
                ColumnHeader colHeader = listView.Columns[colIdx];
                if (colIdx == item.SubItems.Count)
                    item.SubItems.Add(colHeader.Text);

                if (listView.DisplayRectangle.Contains(item.SubItems[colIdx].Bounds.Location) == false)
                {
                    // Force item in view by scrolling box to the right.

                    item.Selected = true;
                    item.Focused = true;

                    int shift = item.SubItems[colIdx].Bounds.Location.X - listView.DisplayRectangle.X;
                    shift /= 8;
                    for (int i = 0; i < shift; i++)
                    {
                        SendKeys.Send("{RIGHT}");
                        SendKeys.Flush();
                    }
                }

                FieldBox fieldBox = new FieldBox();
                fieldBox.FieldText = item.SubItems[colIdx].Text;
                fieldBox.Location = listView.PointToScreen(item.SubItems[colIdx].Bounds.Location);

                if (fieldBox.ShowDialog() == DialogResult.OK)
                {
                    item.SubItems[colIdx].Text = fieldBox.FieldText;
                }
            }
        }

        private void ListViewDbl_Click(object sender, EventArgs e)
        {
            ListView listView = sender as ListView;
            Point p = listView.PointToClient(System.Windows.Forms.Control.MousePosition);
            ListViewItem itemAt = listView.GetItemAt(p.X, p.Y);
            if (itemAt != null)
                ListViewEdit(listView, itemAt);
        }


        private void ListBoxDbl_Click(object sender, EventArgs e)
        {
            ListBox listBox = sender as ListBox;
            Point p = listBox.PointToClient(System.Windows.Forms.Control.MousePosition);
            // ListViewItem itemAt = listBox.GetItemAt(p.X, p.Y);
            // if (itemAt != null)
            //     ListViewEdit(listBox, itemAt);
        }

    }
}
