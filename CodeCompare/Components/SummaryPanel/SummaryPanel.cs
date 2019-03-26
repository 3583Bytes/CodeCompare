using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;

namespace SummaryPanel
{
    public partial class SummaryPanel : UserControl
    {
        #region Delegates

        public delegate void MouseDownHandler(object sender, EventArgs e);

        #endregion

        private int clickedLine;
        private double differenceLinePosition;

        private ArrayList differenceLines;
        private double panelHeight;
        private double screenEnd;
        private double screenStart;
        private double totalNumberLines;

        public SummaryPanel()
        {
            InitializeComponent();
        }

        public ArrayList DifferenceLines
        {
            set { differenceLines = value; }
        }

        public int TotalNumberLines
        {
            set { totalNumberLines = value; }
        }

        public int ScreenStart
        {
            set { screenStart = value; }
        }

        public int ScreenEnd
        {
            set { screenEnd = value; }
        }

        public int ClickedLine
        {
            get { return clickedLine; }
        }

        public event MouseDownHandler SummaryPanelMouseDown;


        private void SummaryPanel_Paint(object sender, PaintEventArgs e)
        {
            if (BackColor == Color.Red)
            {
                return;
            }
            BackColor = Color.FromArgb(243, 242, 231);

            if (differenceLines != null && totalNumberLines > 0)
            {
                if (differenceLines.Count == 0)
                {
                    BackColor = Color.FromArgb(243, 242, 231);
                }
                else if (differenceLines.Count > 0)
                {
                    if (differenceLines.Count == totalNumberLines && totalNumberLines > 30)
                    {
                        BackColor = Color.Red;
                        return;
                    }


                    panelHeight = Height;

                    GraphicsBuffer graphicsBuffer = new GraphicsBuffer();
                    graphicsBuffer.CreateGraphicsBuffer(e.Graphics, Width, Height);


                    Graphics g = graphicsBuffer.Graphics;

                    SolidBrush solidBrush = new SolidBrush(Color.White);

                    int y1 = (int) ((screenStart/totalNumberLines)*panelHeight);

                    int y2 = (int) ((screenEnd/totalNumberLines)*panelHeight);

                    g.FillRectangle(solidBrush, 0, y1, Width, y2 - y1);

                    foreach (int line in differenceLines)
                    {
                        Pen pen = new Pen(Color.Gray, 1);
                        int y;

                        differenceLinePosition = line;

                        y = (int) ((differenceLinePosition/totalNumberLines)*panelHeight);

                        g.DrawLine(pen, 0, y, Width, y);
                    }

                    g.DrawRectangle(new Pen(Color.Black, 1), 0, y1, Width, y2 - y1);

                    graphicsBuffer.Render(CreateGraphics());

                    g.Dispose();
                }
            }
        }


        private void SummaryPanel_MouseDown(object sender, MouseEventArgs e)
        {
            double Y = e.Y;

            clickedLine = (int) (totalNumberLines*(Y/panelHeight));

            if (SummaryPanelMouseDown != null)
            {
                SummaryPanelMouseDown(sender, e);
            }
        }
    }
}