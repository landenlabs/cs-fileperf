using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace FilePerf
{
    public partial class BarGraph : UserControl
    {
	double[] dataArray;
	int dataWidth;
	string[] dataTip;
	string[] vLegend;
	double minVal, maxVal;

    [Serializable]
    internal class BarGraphSettings
	{
        public BarGraphSettings()
        {
            vlColor = Pens.Wheat;
            hlColor = Pens.Tan;
            frameColor = Pens.Violet;

            bgBrush = new SolidBrush(Color.White);
            bgGrid = new SolidBrush(Color.LightGray);
            txBrush = new SolidBrush(Color.Blue);
            barBack = new SolidBrush(Color.Black);

            Point left = new Point(0, 0);
            Point right = new Point(600, 0);
            barBrushes = new LinearGradientBrush[2];
            barBrushes[0] = new LinearGradientBrush(left, right, Color.Red, Color.DarkRed);
            barBrushes[1] = new LinearGradientBrush(left, right, Color.Green, Color.DarkGreen);
        }

	    Font grFont;
	    bool autoScale;
	    float scale;

	    [CategoryAttribute("General"),
	    DescriptionAttribute("Label and Legend font")]
	    public Font GrFont
	    {
		get { return grFont; }
		set { grFont = value; }
	    }

	    [CategoryAttribute("General"),
	    DescriptionAttribute("Automatic horizontal scaling")]
	    public bool AutoScale
	    {
		get { return autoScale; }
		set { autoScale = value; }
	    }

	    [CategoryAttribute("General"),
	    DescriptionAttribute("Horizontal scaling")]
	    public float Scale
	    {
		get { return scale; }
		set { scale = value; }
	    }

        [NonSerialized]
	    Pen vlColor,
	        hlColor,
	        frameColor;

	    [CategoryAttribute("Colors"),
	    Browsable(false),
	    DescriptionAttribute("Vertical Line Color")]
	    public Pen VlColor
	    {
		get { return vlColor; }
		set { vlColor = value; }
	    }
	    [CategoryAttribute("Colors"),
	    DescriptionAttribute("Vertical Line Color")]
	    public Color VlPenColor
	    {
		get { return vlColor.Color; }
		set { vlColor = new Pen(value, vlColor.Width); }
	    }

	    [CategoryAttribute("Colors"),
        Browsable(false),
	    DescriptionAttribute("Horizontal Line Color")]
	    public Pen HlColor
	    {
		get { return hlColor; }
		set { hlColor = value; }
	    }
	    [CategoryAttribute("Colors"),
	    DescriptionAttribute("Horizontal Line Color")]
	    public Color HlPenColor
	    {
		get { return hlColor.Color; }
		set { hlColor = new Pen(value, hlColor.Width);}
	    }

	    [CategoryAttribute("Colors"),
        Browsable(false),
	    DescriptionAttribute("Frame Line Color")]
	    public Pen FrameColor
	    {
		get { return frameColor; }
		set { frameColor = value; }
	    }
	    [CategoryAttribute("Colors"),
	    DescriptionAttribute("Frame Line Color")]
	    public Color FramePenColor
	    {
		    get { return frameColor.Color; }
            set { frameColor = new Pen(value, frameColor.Width); }
	    }

        [NonSerialized]
        SolidBrush bgBrush,
            bgGrid,
            txBrush,
            barBack;
        [NonSerialized]
        Brush[] barBrushes;

	    [CategoryAttribute("Colors"),
        Browsable(false),
	    DescriptionAttribute("Legend background Color")]
	    public SolidBrush BgBrush
	    {
		get { return bgBrush; }
		set { bgBrush = value; }
	    }
	    [CategoryAttribute("Colors"),
	    DescriptionAttribute("Legend background Color")]
	    public Color BgLegendColor
	    {
		get { return bgBrush.Color; }
		set { bgBrush.Color = value; }
	    }

	    [CategoryAttribute("Colors"),
         Browsable(false),
	     DescriptionAttribute("Graph background Color")]
	    public SolidBrush BgGrid
	    {
		get { return bgGrid; }
		set { bgGrid = value; }
	    }
	    [CategoryAttribute("Colors"),
	    DescriptionAttribute("Graph background Color")]
	    public Color BgGridColor
	    {
		get { return bgGrid.Color; }
		set { bgGrid.Color = value; }
	    }

	    [CategoryAttribute("Colors"),
         Browsable(false),
	     DescriptionAttribute("Text foreground Color")]
	    public SolidBrush TxBrush
	    {
		get { return txBrush; }
		set { txBrush = value; }
	    }
	    [CategoryAttribute("Colors"),
	    DescriptionAttribute("Text foreground Color")]
	    public Color TextFgColor
	    {
		get { return txBrush.Color; }
		set { txBrush.Color = value; }
	    }

	    [CategoryAttribute("Colors"),
         Browsable(false),
	     DescriptionAttribute("Bar Color(s)")]
	    public Brush[] BarBrushes
	    {
		get { return barBrushes; }
		set { barBrushes = value; }
	    }

	    [CategoryAttribute("Colors"),
	    DescriptionAttribute("Bar Left Color(s)")]
	    public Color[] BarLeftColors
	    {
		get
		{
		    if (barBrushes != null && barBrushes[0] is LinearGradientBrush)
		    {
		    return new Color[2] {
		    (barBrushes[0] as LinearGradientBrush).LinearColors[0],
		    (barBrushes[1] as LinearGradientBrush).LinearColors[0]};
		    }
		    else
		    {
			return new Color[2] { Color.Red, Color.Green };
		    }
		}

		set
		{
		     if (barBrushes != null && barBrushes[0] is LinearGradientBrush)
		     {
		    (barBrushes[0] as LinearGradientBrush).LinearColors[0] = value[0];
		    (barBrushes[1] as LinearGradientBrush).LinearColors[0] = value[1];
		    }
		}
	    }

	    [CategoryAttribute("Colors"),
	    DescriptionAttribute("Bar Right Color(s)")]
	    public Color[] BarRighttColors
	    {
		get
		{

		    if (barBrushes != null && barBrushes[0] is LinearGradientBrush)
		    {

		    return new Color[2] {
		    (barBrushes[0] as LinearGradientBrush).LinearColors[1],
		    (barBrushes[1] as LinearGradientBrush).LinearColors[1]};
		    }
		    else
		    {
			return new Color[2] { Color.Red, Color.Green };
		    }
		}

		set
		{

		    if (barBrushes != null && barBrushes[0] is LinearGradientBrush)
		    {

		    (barBrushes[0] as LinearGradientBrush).LinearColors[1] = value[0];
		    (barBrushes[1] as LinearGradientBrush).LinearColors[1] = value[1];
		    }
		}
	    }

        [CategoryAttribute("Colors"),
       DescriptionAttribute("Bar background Color")]
        public Color BarBackColor
        {
            get { return barBack.Color; }
            set { barBack.Color = value; }
        }

        [CategoryAttribute("Colors"),       
        Browsable(false),
        DescriptionAttribute("Bar background Color")]
        public SolidBrush BarBack
        {
            get { return barBack; }
            set { barBack = value; }
        }

	    Size cellSize;
	    Size barSize;
	    Size shadowSize;
	    Size barMargin;
	    Size ulMargin;
	    Size lrMargin;

	    [CategoryAttribute("Sizes"),
	    DescriptionAttribute("Cell Size")]
	    public Size CellSize
	    {
		get { return cellSize; }
		set { cellSize = value; }
	    }

	    [CategoryAttribute("Sizes"),
	    DescriptionAttribute("Bar Size")]
	    public Size BarSize
	    {
		get { return barSize; }
		set { barSize = value; }
	    }

        [CategoryAttribute("Sizes"),
        DescriptionAttribute("Bar Shadow")]
        public Size ShadowSize
        {
            get { return shadowSize; }
            set { shadowSize = value; }
        }

	    [CategoryAttribute("Sizes"),
	    DescriptionAttribute("Bar Margin Size")]
	    public Size BarMargin
	    {
		get { return barMargin; }
		set { barMargin = value; }
	    }

	    [CategoryAttribute("Sizes"),
	     DescriptionAttribute("UpperLeft Margin")]
	    public Size UlMargin
	    {
		get { return ulMargin; }
		set { ulMargin = value; }
	    }

	    [CategoryAttribute("Sizes"),
	    DescriptionAttribute("LowerRight Margin")]
	    public Size LrMargin
	    {
		get { return lrMargin; }
		set { lrMargin = value; }
	    }

	    Size titleSize;
	    double hScale;
	    double vScale;
	    string hTitle;
	    string vTitle;

	    [CategoryAttribute("Text"),
	    DescriptionAttribute("Title Size")]
	    public Size TitleSize
	    {
		get { return titleSize; }
		set { titleSize = value; }
	    }

	    [CategoryAttribute("Text"),
	    DescriptionAttribute("Horizontal Scale")]
	    public double HScale
	    {
		get { return hScale; }
		set { hScale = value; }
	    }

	    [CategoryAttribute("Text"),
	    DescriptionAttribute("Vertical Scale")]
	    public double VScale
	    {
		get { return vScale; }
		set { vScale = value; }
	    }

	    [CategoryAttribute("Text"),
	    DescriptionAttribute("Horizontal Title")]
	    public string HTitle
	    {
		get { return hTitle; }
		set { hTitle = value; }
	    }

	    [CategoryAttribute("Text"),
	    DescriptionAttribute("Vertical Scale")]
	    public string VTitle
	    {
		get { return vTitle; }
		set { vTitle = value; }
	    }
	};

	BarGraphSettings s;

	public object Settings
	{
	    get { return s; }
	    set { s = value as BarGraphSettings; }
	}

	const UInt64 one = 1;
	const UInt64 KB = one << 10;
	const UInt64 MB = one << 20;
	const UInt64 GB = one << 30;

    public BarGraph()
    {
        DefaultSettings();
        InitializeComponent();
    }

	public void DefaultSettings()
	{
	    s = new BarGraphSettings();

	    s.AutoScale = true;

	    s.VlColor = Pens.Wheat;
	    s.HlColor = Pens.Tan;
	    s.FrameColor = Pens.Violet;

	    s.BgBrush = new SolidBrush(Color.White);
	    s.BgGrid = new SolidBrush(Color.LightGray);
	    s.TxBrush = new SolidBrush(Color.Blue);
        s.BarBack = new SolidBrush(Color.DarkGray);

	    s.CellSize = new Size(50, 50);
	    s.BarSize = new Size(10, 10);
        s.ShadowSize = new Size(4, 4);
	    s.BarMargin = new Size(4, 4);

	    s.GrFont = new Font(this.Font.FontFamily, this.Font.Size, FontStyle.Bold);
	    int fontHeight = s.GrFont.Height;
	    s.TitleSize = new Size(0, fontHeight + 2);
	    s.UlMargin = new Size(40, FontHeight + 2);
	    s.LrMargin = s.UlMargin;
	    s.UlMargin += s.TitleSize;

	    s.BarBrushes = new LinearGradientBrush[2];
	    Point left = new Point(0, 0);
	    Point right = new Point(600, 0);
        s.BarBrushes[0] = new LinearGradientBrush(left, right, Color.Red, Color.DarkRed); 
	    s.BarBrushes[1] = new LinearGradientBrush(left, right, Color.Green, Color.DarkGreen);

	    s.HTitle = "Measure Sequencial File Performance (MB/s)";
	    string[] tip = new string[2] { "Read {0:F2} MB/s, {1:F0} Bytes", "Write {0:F2} MB/s, {1:F0} Bytes" };
	    s.HScale = 1.0 / 1000;
	    double[] testData = new double[9] { 64, 10e3, 12e3, 256, 14e3, 16e3, 512, 21e3, 18e3 };
        Data(testData, 3, tip);
	}

	public void Clear()
	{
	    this.dataArray = null;
	    this.dataWidth = 0;
	    this.Refresh();
	}

	public void Data(double[] _dataArray, int _dataWidth, string[] _tip)
	{
	    dataArray = _dataArray;
	    dataWidth = _dataWidth;

        if (_tip != null)
            dataTip = _tip;

	    minVal = double.MaxValue;
	    maxVal = double.MinValue;

	    if (dataArray == null || dataArray.Length == 0)
		return;

	    int numTst = dataArray.Length / dataWidth;
	    vLegend = new string[numTst];
	    for (int tstIdx = 0; tstIdx < numTst; tstIdx++)
	    {
		double size = dataArray[tstIdx * 3 + 0];
		double rKBs = dataArray[tstIdx * 3 + 1];
		double wKBs = dataArray[tstIdx * 3 + 2];

		string tstLegend = "";

		if (size < KB)
		    tstLegend = ((UInt64)size).ToString();
		else if (size < MB)
		{
		    tstLegend = ((UInt64)(size / KB)).ToString() + "KB";
		}
		else if (size < GB)
		{
		    tstLegend = ((UInt64)(size / MB)).ToString() + "MB";
		}
		else
		{
		    tstLegend = ((UInt64)(size / GB)).ToString() + "GB";
		}
		vLegend[tstIdx] = tstLegend;

		minVal = Math.Min(minVal, Math.Min(rKBs, wKBs));
		maxVal = Math.Max(maxVal, Math.Max(rKBs, wKBs));
	    }

	    if (s.AutoScale)
	    {
		int n10 = 1;
		double tmpMax = this.maxVal;
		while (tmpMax >= 10)
		{
		    n10 *= 10;
		    tmpMax /= 10;
		}

		s.Scale = n10;
		while (tmpMax > 0)
		{
		    s.Scale += n10;
		    tmpMax -= 1;
		}
	    }

	    this.Refresh();
	}

	protected override void OnPaintBackground(PaintEventArgs e)
	{
	    base.OnPaintBackground(e);

        if (s == null || s.CellSize.Width == 0 || s.BgBrush == null)
            DefaultSettings();

	    e.Graphics.FillRectangle(s.BgBrush, this.DisplayRectangle);

	    Size dspSize = DisplayRectangle.Size;
	    Size grSize = dspSize - s.UlMargin - s.LrMargin;

	    if (this.vLegend != null)
	    {
		    int legendIdx = 0;
		    float fontMidHeight = s.GrFont.Height / 2.0f;
		    foreach (string legendStr in this.vLegend)
		    {
		        string legend_hyphen = legendStr + "-";
		        SizeF legendSize = e.Graphics.MeasureString(legend_hyphen, s.GrFont);

		        float col = s.UlMargin.Width - legendSize.Width - 1;
		        float row = s.CellSize.Height * (legendIdx + 0.5f) + s.UlMargin.Height - fontMidHeight;

		        e.Graphics.DrawString(legend_hyphen, s.GrFont, s.TxBrush, col, row);

                // double val1 = this.dataArray[legendIdx * 3 + 1];
                // e.Graphics.DrawString(

		        legendIdx++;
		    }

		    SizeF hTitleSize = e.Graphics.MeasureString(s.HTitle, s.GrFont);
		    e.Graphics.DrawString(s.HTitle, s.GrFont, s.TxBrush, s.UlMargin.Width + (grSize.Width - hTitleSize.Width) / 2, 0);

		    float lblRow = s.TitleSize.Height;
		    for (float lblCol = s.CellSize.Width; lblCol <= grSize.Width; lblCol += s.CellSize.Width)
		    {
		        double val = lblCol / grSize.Width * s.Scale;
		        val *= s.HScale;
		        string label = val.ToString("F0");
		        SizeF  labelSize = e.Graphics.MeasureString(label, s.GrFont);
		        e.Graphics.DrawString(label, s.GrFont, s.TxBrush, lblCol + s.UlMargin.Width - labelSize.Width / 2, lblRow);
		    }
	    }

	    e.Graphics.TranslateTransform(s.UlMargin.Width, s.UlMargin.Height);
	    e.Graphics.FillRectangle(s.BgGrid, 0, 0, grSize.Width, grSize.Height);

	    if (this.dataArray != null)
	    {
		    float barOff = s.BarSize.Height + s.BarMargin.Height/2;

		    for (int tstIdx = 0; tstIdx < this.dataArray.Length/this.dataWidth; tstIdx++)
		    {
		        double val1 = this.dataArray[tstIdx * 3 + 1];
		        double val2 = this.dataArray[tstIdx * 3 + 2];

		        float midRow = s.CellSize.Height * (tstIdx + 0.5f);
		        float rPercent = (float)(val1 / s.Scale);
		        float wPercent = (float)(val2 / s.Scale);

		        float bar1y = midRow - barOff;
		        float bar2y = midRow + s.BarMargin.Height / 2;

                if (s.ShadowSize.Width > 0 || s.ShadowSize.Height > 0)
                {
                    e.Graphics.FillRectangle(s.BarBack, 0, bar1y + s.ShadowSize.Height, grSize.Width * rPercent + s.ShadowSize.Width, s.BarSize.Height);
                    e.Graphics.FillRectangle(s.BarBack, 0, bar2y + s.ShadowSize.Height, grSize.Width * wPercent + s.ShadowSize.Width, s.BarSize.Height);
                }
                e.Graphics.FillRectangle(s.BarBrushes[0], 0, bar1y, grSize.Width * rPercent, s.BarSize.Height);
                e.Graphics.FillRectangle(s.BarBrushes[1], 0, bar2y, grSize.Width * wPercent, s.BarSize.Height);
            };
	    }

	    for (int vColumn = 0; vColumn < grSize.Width; vColumn += s.CellSize.Width)
	    {
		    e.Graphics.DrawLine(s.VlColor, vColumn, 0, vColumn, grSize.Height);
		    e.Graphics.DrawLine(Pens.Black, vColumn + 1, 0, vColumn + 1, grSize.Height);
	    }
	    for (int hRow = 0; hRow < grSize.Height; hRow += s.CellSize.Height)
	    {
		    e.Graphics.DrawLine(s.HlColor, 0, hRow, grSize.Width, hRow);
		    e.Graphics.DrawLine(Pens.Green, 0, hRow + 1, grSize.Width, hRow + 1);
	    }
	    e.Graphics.DrawRectangle(s.FrameColor, 0, 0, grSize.Width, grSize.Height);
	    e.Graphics.TranslateTransform(-s.UlMargin.Width, -s.UlMargin.Height); 
	}

	protected override void OnPrint(PaintEventArgs e)
	{
	    base.OnPrint(e);
	}

	private void BarGraph_MouseMove(object sender, MouseEventArgs e)
	{
	    if (this.dataArray == null || this.dataArray.Length == 0 ||s.CellSize.Width == 0)
		    return;

	    Size mouseLoc = new Size(e.Location.X, e.Location.Y);
	    mouseLoc -= s.UlMargin;
	    if (mouseLoc.Width > 0 && mouseLoc.Height > 0)
	    {
		int testNum = (mouseLoc.Height / s.CellSize.Height);
		int subTestHeight = s.CellSize.Height / (this.dataWidth - 1);

		int subTestNum = Math.Min(dataTip.Length-1, (mouseLoc.Height - testNum * s.CellSize.Height) / subTestHeight);

		// System.Diagnostics.Debug.WriteLine(testNum.ToString()+  " " + subTestNum.ToString());

		if (testNum < this.dataArray.Length / this.dataWidth)
		{
		    float x = e.Location.X + 20;
		    float y = testNum * s.CellSize.Height + s.UlMargin.Height +
			(subTestNum + 0.5f) * subTestHeight;
		    string msg = string.Format(dataTip[subTestNum],
			this.dataArray[testNum * 3 + 1 + subTestNum] * s.HScale,
			this.dataArray[testNum * 3 + 0]);
		    this.toolTip.Show(msg, this, (int)x, (int)y, 5000);
		}
	    }
	}
    }
}
