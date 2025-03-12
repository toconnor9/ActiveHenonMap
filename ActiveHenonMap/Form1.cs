using Man2;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.LinkLabel;

namespace ActiveHenonMap
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private MyPointList myPoints = new MyPointList();
        private bool _movingMap = false;
        private HenonMapData mapData = new HenonMapData();
        private float _zoom = 50.0f;
        private bool inForm = false;
        private bool _allowRecalculating = true;
        Dictionary<int, Color> lastSetOfPoints = new Dictionary<int, Color>();
        private Point _lastPosn = new Point();

        private enum enRecalc
        {
            Recalculate,
            DontRecalculate
        }


        string _textbox_name = "";
        DateTime _Last_time = new DateTime();
        List<HenonMapData> history = new List<HenonMapData>();
        int ptrHistory = -1;



        #region Events

        private void Form_MouseScroll(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            // string text_from_control = "";
            double value_from_control = 0;

            // DateTime time_of_day = new DateTime();
            TimeSpan time_since_last = new TimeSpan();
            double scroll_amount = 0;
            // bool parse_success = false;

            Control curr_textbox = GetCurrTextbox(_textbox_name);

            if (_textbox_name == "Graph")
            {
                time_since_last = GetTimeSinceLast();

                long msSinceLast = (long)(1000.0 * time_since_last.TotalSeconds);

                if (e.Delta > 0)
                {
                    if (msSinceLast < 60)
                        scroll_amount = 0.75;
                    else if (msSinceLast < 400)
                        scroll_amount = 0.85;
                    else if (msSinceLast < 1000)
                        scroll_amount = 0.90;
                    else
                        scroll_amount = 0.95;
                }
                else
                {
                    if (msSinceLast < 60)
                        scroll_amount = 1.25;
                    else if (msSinceLast < 400)
                        scroll_amount = 1.15;
                    else if (msSinceLast < 1000)
                        scroll_amount = 1.10;
                    else
                        scroll_amount = 1.05;
                }

                int t = pnlMain.Top;
                int l = pnlMain.Left;

                MyPoint posn_on_map = Utilities.ConvertFromScreenCoordinates(e.X - l, e.Y - t);

                _allowRecalculating = false;
                txtTop.Text     = (posn_on_map.Y + ((mapData.MaxY - posn_on_map.Y) * scroll_amount)).ToString("#,0.00#");
                txtBottom.Text  = (posn_on_map.Y - ((posn_on_map.Y - mapData.MinY) * scroll_amount)).ToString("#,0.00#");
                txtLeft.Text    = (posn_on_map.X - ((posn_on_map.X - mapData.MinX) * scroll_amount)).ToString("#,0.00#");
                txtRight.Text   = (posn_on_map.X + ((mapData.MaxX - posn_on_map.X) * scroll_amount)).ToString("#,0.00#");
                _allowRecalculating = true;

                GetScreenValues();

                if (history.Count > ptrHistory)
                    history.RemoveRange(ptrHistory, history.Count - ptrHistory);

                history.Add(mapData);
                ptrHistory++;
            }
            else if (_textbox_name != "" && curr_textbox != null)
            {
                value_from_control = GetValueFromControl(_textbox_name);

                time_since_last = GetTimeSinceLast();

                long msSinceLast = (long)(1000.0 * time_since_last.TotalSeconds);

                if (_textbox_name != "txtNumOrbits" &&
                    _textbox_name != "txtPointsPerOrbit")
                {
                    // Console.WriteLine("msSinceLast: " + msSinceLast.ToString());

                    if (msSinceLast < 60)
                        scroll_amount = 0.04;
                    else if (msSinceLast < 400)
                        scroll_amount = 0.003;
                    else if (msSinceLast < 1000)
                        scroll_amount = 0.001;
                    else
                        scroll_amount = 0.0001;

                    if (scroll_amount > 0)
                    {
                        scroll_amount *= (double)(e.Delta / 120);   // This establishes whether the mouse wheel was going up or down

                        curr_textbox.Text = (value_from_control + scroll_amount).ToString("0.0000");
                    }
                }
                else
                {
                    if (msSinceLast < 40)
                        scroll_amount = 100;
                    else if (msSinceLast < 80)
                        scroll_amount = 50;
                    else if (msSinceLast < 160)
                        scroll_amount = 25;
                    else
                        scroll_amount = 10;

                    if (scroll_amount > 0)
                    {
                        scroll_amount *= (double)(e.Delta / 120);   // This establishes whether the mouse wheel was going up or down

                        curr_textbox.Text = (value_from_control + scroll_amount).ToString("0");
                    }
                }


                lblInfo.Text = $"scroll: {scroll_amount}";
                lblInfo.Refresh();
            }
            else if (inForm)
            {
                if (e.Delta < 0)
                    _zoom += 2.0f;
                else
                    _zoom -= 2.0f;

                if (_zoom > 100)
                    _zoom = 100;
                else if (_zoom < 10.0f)
                    _zoom = 10.0f;
            }

            PlotHenonMap(enRecalc.DontRecalculate);
        }

        private double GetValueFromControl(string control_name)
        {
            double value_from_control = 0;
            string text_from_control = "";
            Control curr_textbox = null;
            if (control_name != "")
            {
                curr_textbox = GetCurrTextbox(control_name);
                text_from_control = curr_textbox.Text;
                double.TryParse(text_from_control, out value_from_control);
            }
            return value_from_control;
        }

        private TimeSpan GetTimeSinceLast()
        {
            DateTime time_of_day = new DateTime();
            TimeSpan time_since_last = new TimeSpan();

            time_of_day = DateTime.Now;
            time_since_last = (time_of_day - _Last_time);
            _Last_time = time_of_day;

            return time_since_last;
        }

        private Control GetCurrTextbox(string control_name)
        {
            Control curr_textbox = null;


            switch (_textbox_name)
            {
                case "txtPhaseAngle":
                    curr_textbox = txtPhaseAngle;
                    break;
                case "txtRight":
                    curr_textbox = txtRight;
                    break;
                case "txtLeft":
                    curr_textbox = txtLeft;
                    break;
                case "txtTop":
                    curr_textbox = txtTop;
                    break;
                case "txtBottom":
                    curr_textbox = txtBottom;
                    break;
                case "txtStartingX":
                    curr_textbox = txtStartingX;
                    break;
                case "txtStartingY":
                    curr_textbox = txtStartingY;
                    break;
                case "txtIncrementX":
                    curr_textbox = txtIncrementX;
                    break;
                case "txtIncrementY":
                    curr_textbox = txtIncrementY;
                    break;
                case "txtNumOrbits":
                    curr_textbox = txtNumOrbits;
                    break;
                case "txtPointsPerOrbit":
                    curr_textbox = txtPointsPerOrbit;
                    break;
                case "Graph":
                    curr_textbox = pnlMain;
                    break;
                default:
                    break;
            }

            return curr_textbox;
        }

        private void textBox_MouseEnter(object sender, EventArgs e)
        {
            _textbox_name = ((System.Windows.Forms.Control)sender).Name;
            ((System.Windows.Forms.Control)sender).BackColor = Color.Pink;
        }

        private void textBox_MouseLeave(object sender, EventArgs e)
        {
            _textbox_name = "";
            ((System.Windows.Forms.Control)sender).BackColor = Color.White;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            saveFileDialog1.ShowDialog();
        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            string name = saveFileDialog1.FileName;

            string ValuesToSave = txtPhaseAngle.Text + "|" + txtRight.Text + "|" + txtLeft.Text + "|" + txtTop.Text + "|" + txtBottom.Text + "|" + txtStartingX.Text + "|" + txtStartingY.Text + "|" + txtIncrementX.Text + "|" + txtIncrementY.Text + "|" + txtNumOrbits.Text + "|" + txtPointsPerOrbit.Text;

            File.WriteAllText(name, ValuesToSave);
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            string[] ValuesToLoad = new string[11];

            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK) // Test result.
            {
                string file = openFileDialog1.FileName;
                try
                {
                    string text = File.ReadAllText(file);
                    ValuesToLoad = text.Split('|');

                    if (ValuesToLoad.Length != 11)
                    {
                        MessageBox.Show("File is not in the correct format");
                        return;
                    }
                    txtPhaseAngle.Text      = ValuesToLoad[0];
                    txtRight.Text           = ValuesToLoad[1];
                    txtLeft.Text            = ValuesToLoad[2];
                    txtTop.Text             = ValuesToLoad[3];
                    txtBottom.Text          = ValuesToLoad[4];
                    txtStartingX.Text       = ValuesToLoad[5];
                    txtStartingY.Text       = ValuesToLoad[6];
                    txtIncrementX.Text      = ValuesToLoad[7];
                    txtIncrementY.Text      = ValuesToLoad[8];
                    txtNumOrbits.Text       = ValuesToLoad[9];
                    txtPointsPerOrbit.Text  = ValuesToLoad[10];
                }
                catch (IOException)
                {
                }

            }
        }

        private void txtNumOrbits_TextChanged(object sender, EventArgs e)
        {
            int num_orbits = 0;
            if (int.TryParse(txtNumOrbits.Text, out num_orbits) == false)
            {
                txtNumOrbits.Text = "40";
                num_orbits = 40;
            }
            
            if (num_orbits > 1000)
            {
                txtNumOrbits.Text = "1000";
                num_orbits = 1000;
            }
            else if (num_orbits < 1)
            {
                txtNumOrbits.Text = "1";
                num_orbits = 1;
            }
        }

        private void TextBoxChanged(object sender, EventArgs e)
        {
            if (_allowRecalculating)
            {
                GetScreenValues();

                if (history.Count > ptrHistory)
                    history.RemoveRange(ptrHistory, history.Count - ptrHistory);

                history.Add(mapData);
                ptrHistory++;

                if (((Control)sender).Name == "txtTop" ||
                    ((Control)sender).Name == "txtBottom" ||
                    ((Control)sender).Name == "txtLeft" ||
                    ((Control)sender).Name == "txtRight")
                {
                    PlotHenonMap(enRecalc.DontRecalculate);
                }
                else
                {
                    PlotHenonMap(enRecalc.Recalculate);
                }
            }
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            PlotHenonMap(enRecalc.Recalculate);
        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "Henon Map|*.henon|Text Files|*.txt|All Files|*.*";
            saveFileDialog1.FilterIndex = 0;
            openFileDialog1.FileName = DateTime.Now.ToString("yyyyMMdd-HHmm") + ".henon";
           //  openFileDialog1.InitialDirectory = "D:\\X";

            saveFileDialog1.ShowDialog();
        }

        private void saveFileDialog1_FileOk_1(object sender, CancelEventArgs e)
        {
            string name = saveFileDialog1.FileName;

            string ValuesToSave = txtPhaseAngle.Text + "|" + txtRight.Text + "|" + txtLeft.Text + "|" + txtTop.Text + "|" + txtBottom.Text + "|" + txtStartingX.Text + "|" + txtStartingY.Text + "|" + txtIncrementX.Text + "|" + txtIncrementY.Text + "|" + txtNumOrbits.Text + "|" + txtPointsPerOrbit.Text;

            File.WriteAllText(name, ValuesToSave);
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            Console.WriteLine("File OK");
        }

        private void btnLoad_Click_1(object sender, EventArgs e)
        {
            string[] ValuesToLoad = new string[11];


            openFileDialog1.Filter = "Henon Map|*.henon|Text Files|*.txt|All Files|*.*";
            openFileDialog1.FilterIndex = 0;
            openFileDialog1.InitialDirectory = "D:\\X";

            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK) // Test result.
            {
                string file = openFileDialog1.FileName;
                try
                {
                    string text = File.ReadAllText(file);
                    ValuesToLoad = text.Split('|');

                    if (ValuesToLoad.Length != 11)
                    {
                        MessageBox.Show("File is not in the correct format");
                        return;
                    }
                    txtPhaseAngle.Text     = ValuesToLoad[0];
                    txtRight.Text          = ValuesToLoad[1];
                    txtLeft.Text           = ValuesToLoad[2];
                    txtTop.Text            = ValuesToLoad[3];
                    txtBottom.Text         = ValuesToLoad[4];
                    txtStartingX.Text      = ValuesToLoad[5];
                    txtStartingY.Text      = ValuesToLoad[6];
                    txtIncrementX.Text     = ValuesToLoad[7];
                    txtIncrementY.Text     = ValuesToLoad[8];
                    txtNumOrbits.Text      = ValuesToLoad[9];
                    txtPointsPerOrbit.Text = ValuesToLoad[10]; ;
                }
                catch (IOException)
                {
                }

            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            this.Refresh();

            if (ptrHistory == -1)
            {
                HenonMapData startingPt = new HenonMapData(txtPhaseAngle.Text, txtStartingX.Text, txtStartingY.Text, txtIncrementX.Text, txtIncrementY.Text,
                                                           txtNumOrbits.Text, txtPointsPerOrbit.Text, txtBottom.Text, txtTop.Text, txtLeft.Text, txtRight.Text,
                                                           pnlMain.Width.ToString(), pnlMain.Height.ToString());

                history = new List<HenonMapData>();
                history.Add(startingPt);
                ptrHistory = 1;
            }
        }

        private void pnlMain_MouseDown(object sender, MouseEventArgs e)
        {
            _movingMap = true;

            _lastPosn.X = e.X;
            _lastPosn.Y = e.Y;

            Console.WriteLine($"MouseDown ({e.X}, {e.Y})");
        }

        private void pnlMain_MouseMove(object sender, MouseEventArgs e)
        {
            double dX = (_lastPosn.X - e.X);
            double dY = (e.Y - _lastPosn.Y);


            if (_movingMap)
            {
                MoveGraph(dX, dY);

                _lastPosn.X = e.X;
                _lastPosn.Y = e.Y;

                MyPointIntList pointsOnScreen = myPoints.ConvertThisListToScreenCoordinates(pnlMain.Width, pnlMain.Height, mapData);
                Draw_Point_Dataset(pnlMain, pointsOnScreen);
            }
        }

        private void pnlMain_MouseUp(object sender, MouseEventArgs e)
        {
            double dX = (_lastPosn.X - e.X);
            double dY = (e.Y - _lastPosn.Y);


            if (_movingMap)
            {
                MoveGraph(dX, dY);

                _lastPosn.X = e.X;
                _lastPosn.Y = e.Y;

                Console.WriteLine($"MouseUp ({e.X}, {e.Y})");

                MyPointIntList pointsOnScreen = myPoints.ConvertThisListToScreenCoordinates(pnlMain.Width, pnlMain.Height, mapData);
                Draw_Point_Dataset(pnlMain, pointsOnScreen);
            }

            _movingMap = false;
        }

        private void pnlMain_MouseEnter(object sender, EventArgs e)
        {
            _textbox_name = "Graph";
            inForm = true;
        }

        private void pnlMain_MouseLeave(object sender, EventArgs e)
        {
            _textbox_name = "";
            inForm = false;
        }

        private void pnlMain_MouseClick(object sender, MouseEventArgs e)
        {
            if (((Control)sender).Name == "txtTop" ||
                ((Control)sender).Name == "txtBottom" ||
                ((Control)sender).Name == "txtLeft" ||
                ((Control)sender).Name == "txtRight" ||
                ((Control)sender).Name == "pnlMain")
            {
                PlotHenonMap(enRecalc.DontRecalculate);
            }
            else
            {
                PlotHenonMap(enRecalc.Recalculate);
            }
        }

        private void btnRestartOnOrbitX_Click(object sender, EventArgs e)
        {
            int maxNumberOfOrbits = 0;
            int orbitChosen = 0;
            frmInput frmRestart = new frmInput();


            if (int.TryParse(txtNumOrbits.Text, out maxNumberOfOrbits))
            {
                frmRestart.Title = "Get New Starting Point";
                frmRestart.Prompt = $"What orbit do you want to restart on? (0 - {maxNumberOfOrbits - 1})";
                frmRestart.MinimumValue = 0;
                frmRestart.MaximumValue = maxNumberOfOrbits - 1;
                frmRestart.DefaultValue = "0";

                if (frmRestart.ShowDialog() == DialogResult.OK)
                {
                    if (int.TryParse(frmRestart.ValueGiven(), out orbitChosen))
                    {
                        MyPoint startingPt = myPoints.points[orbitChosen * mapData.PtsPerOrbit];

                        this.txtStartingX.Text = startingPt.X.ToString("0.000");
                        this.txtStartingY.Text = startingPt.Y.ToString("0.000");
                        mapData.StartingX = startingPt.X;
                        mapData.StartingY = startingPt.Y;
                    }
                }
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            HenonMapData X = new HenonMapData();


            if (e.KeyCode == Keys.Z && Control.ModifierKeys == Keys.Control)
            {
                Console.WriteLine(e.KeyCode);

                // Check if ptrHistory > 1
                if (ptrHistory > 1)
                {
                    // Decrement the ptrHistory 
                    X = history[--ptrHistory].Clone();

                    // Put the data from history[ptrHistory] on the form
                    SetScreenValues(X.PhaseAngle, X.StartingX, X.StartingY, X.IncrementX, X.IncrementY,
                                    X.NumOrbits, X.PtsPerOrbit, X.MinX, X.MaxX, X.MinY, X.MaxY);
                }
            }

            if (e.KeyCode == Keys.Y && Control.ModifierKeys == Keys.Control)
            {
                Console.WriteLine(e.KeyCode);

                // Check if ptrHistory history.Count
                if (ptrHistory < history.Count)
                {
                    // Increment the ptrHistory
                    X = history[++ptrHistory].Clone();

                    // Put the data from history[ptrHistory] on the form
                    SetScreenValues(X.PhaseAngle, X.StartingX, X.StartingY, X.IncrementX, X.IncrementY,
                                    X.NumOrbits, X.PtsPerOrbit, X.MinX, X.MaxX, X.MinY, X.MaxY);
                }
            }
        }


        #endregion


        #region Private Methods

        private void Draw_Point_Dataset(Panel pnlMain, MyPointIntList points)
        {
            Bitmap bmp = new Bitmap(pnlMain.Width, pnlMain.Height);

            try
            {
                if (pnlMain != null && pnlMain.Visible == true)
                {
                    using (Graphics g = Graphics.FromImage(bmp))
                    {
                        foreach (MyPointInt pt in points.points)
                        {
                            if (pt.X >= 0 && pt.X < pnlMain.Width && pt.Y >= 0 && pt.Y < pnlMain.Height)
                            {
                                SolidBrush currColor = new SolidBrush(pt.ptColor);

                                g.FillRectangle(currColor, pt.X, pt.Y, pt.Diameter, pt.Diameter);
                            }
                        }
                    }

                    pnlMain.BackgroundImage = bmp;
                    pnlMain.Refresh();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR: " + ex.Message, "Error Plotting Data", MessageBoxButtons.OK);
                throw;
            }
        }

        /// <summary>
        /// Put the points on the panel
        /// </summary>
        /// <returns>The bitmap of the points</returns>
        private void Draw_Line_Dataset(Panel pnlMain, MyLineIntList axes)
        {
            try
            {
                using (Graphics g = Graphics.FromImage(pnlMain.BackgroundImage))
                {
                    foreach (MyLineInt ln in axes.Lines)
                    {
                        if (ln.Start.X >= 0 && ln.Start.X < pnlMain.Width && ln.Start.Y >= 0 && ln.Start.Y < pnlMain.Height)
                        {
                            SolidBrush currColor = new SolidBrush(ln.LineColor);

                            g.DrawLine(new Pen(ln.LineColor, ln.LineWidth), ln.Start.X, ln.Start.Y, ln.End.X, ln.End.Y);
                        }
                    }

                    pnlMain.Refresh();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR: " + ex.Message, "Error Plotting Data", MessageBoxButtons.OK);
                throw;
            }
        }

        /// <summary>
        /// Calculate the points of the Henon map
        /// </summary>
        /// <returns>True if it was able to convert it</returns>
        private bool PlotHenonMap(enRecalc recalculating)
        {
            bool it_worked = false;
            MyLineList myLines = new MyLineList();

            mapData = new HenonMapData();

            try
            {
                mapData = new HenonMapData(txtPhaseAngle.Text,
                                           txtStartingX.Text, txtStartingY.Text,
                                           txtIncrementX.Text, txtIncrementY.Text,
                                           txtNumOrbits.Text, txtPointsPerOrbit.Text,
                                           txtLeft.Text, txtRight.Text,
                                           txtBottom.Text, txtTop.Text,
                                           pnlMain.Width.ToString(),
                                           pnlMain.Height.ToString());

                if (recalculating == enRecalc.Recalculate)
                {
                    myPoints = HenonMap.Calculate(mapData);
                }


                // If the 'Y' axis is in the frame, add it here
                if (mapData.MinX < 0 && mapData.MaxX > 0)
                    myLines.Add(new MyLine(0, mapData.MinY, 0, mapData.MaxY, Color.Blue, 3));

                // If the 'X' axis is in the frame, add it here
                if (mapData.MinY < 0 && mapData.MaxY > 0)
                    myLines.Add(new MyLine(0, mapData.MinX, 0, mapData.MaxX, Color.Blue, 3));


                MyPointIntList pointsOnScreen = myPoints.ConvertThisListToScreenCoordinates(pnlMain.Width, pnlMain.Height, mapData);
                Draw_Point_Dataset(pnlMain, pointsOnScreen);

                it_worked = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ERROR: [{ex.Message}]");
                it_worked = false;
            }

            return it_worked;
        }

        /// <summary>
        /// Try to convert the text passed in to a double
        /// </summary>
        /// <param name="text2Convert">Text to convert</param>
        private double TextToDouble(string text2Convert)
        {
            double val = 0.0;
            if (double.TryParse(text2Convert, out val))
                return val;
            else
                return 0.0;
        }

        /// <summary>
        /// Try to convert the text passed in to an integer
        /// </summary>
        /// <param name="text2Convert">Text to convert</param>
        private int TextToInt(string text2Convert)
        {
            int val = 0;
            if (int.TryParse(text2Convert, out val))
                return val;
            else
                return 0;
        }

        private void MoveGraph(double dX, double dY)
        {
            double dist_moved = Math.Sqrt((dX * dX) + (dY * dY));
            if (dist_moved > 0)
            {
                double dX_on_map = dX / Utilities.scaleX;
                double dY_on_map = dY / Utilities.scaleY;

                // GetScreenValues();

                double l = (mapData.MinX + dX_on_map);
                double r = (mapData.MaxX + dX_on_map);
                double t = (mapData.MaxY + dY_on_map);
                double b = (mapData.MinY + dY_on_map);

                txtTop.Text     = t.ToString("0.000"); txtTop.Refresh();
                txtBottom.Text  = b.ToString("0.000"); txtBottom.Refresh();
                txtRight.Text   = r.ToString("0.000"); txtRight.Refresh();
                txtLeft.Text    = l.ToString("0.000"); txtLeft.Refresh();

                mapData.MinX = l;
                mapData.MaxX = r;
                mapData.MinY = b;
                mapData.MaxY = t;

                Utilities.MinX = l;
                Utilities.MaxX = r;
                Utilities.MinY = b;
                Utilities.MaxY = t;

                Console.WriteLine($"MoveGraph({dX}, {dY}) ==> ({dX_on_map.ToString("0.00")}, {dY_on_map.ToString("0.00")})  &  (l,r,t,b): ({l.ToString("0.00")}, {r.ToString("0.00")}, {t.ToString("0.00")}, {b.ToString("0.00")})");

                MyPointIntList pointsOnScreen = myPoints.ConvertThisListToScreenCoordinates(pnlMain.Width, pnlMain.Height, mapData);
                Draw_Point_Dataset(pnlMain, pointsOnScreen);

                // Console.WriteLine($"Moved {dist_moved.ToString("#,0")} or {dX_on_map}, {dY_on_map}");
            }
        }

        private void DrawPointsAndAxes(MouseEventArgs e)
        {
            MyLineIntList nearbyPoints = new MyLineIntList();
            Graphics g = pnlMain.CreateGraphics();

            GetScreenValues();

            MyPoint map_cursor_location = Utilities.ConvertFromScreenCoordinates(new MyPointInt(e.X, e.Y, Color.Black, 1));

            // PaintCursorCircle(new Point(e.X, e.Y));

            // Draw_Line_Dataset(pnlMain, myPoints.ConvertThisListToScreenCoordinates(pnlMain.Width, pnlMain.Height, mapData));

            // txtlocation.Text = $"# points: {pointsToColor.Count}\r\nX: {map_cursor_location.X.ToString("#,0.000")}, Y: {map_cursor_location.Y.ToString("#,0.000")}\r\nrange: {range}\r\nZoom: {_zoom}";
            // txtlocation.Refresh();
        }

        private void ShowPopUp(string TextToShow, string Title)
        {
            frmPopUp frmPopUp = new frmPopUp();

            frmPopUp.TextToShow = TextToShow;
            frmPopUp.TitleOfBox = Title;
            frmPopUp.Show();
        }

        private void GetScreenValues()
        {
            mapData = new HenonMapData(txtPhaseAngle.Text, txtStartingX.Text, txtStartingY.Text,
                                       txtIncrementX.Text, txtIncrementY.Text, txtNumOrbits.Text, txtPointsPerOrbit.Text, 
                                       txtBottom.Text, txtTop.Text, txtLeft.Text, txtRight.Text, 
                                       pnlMain.Width.ToString(), pnlMain.Height.ToString());

            Utilities.SetRatios(mapData);
        }

        private void SetScreenValues(double phAngle,
                                     double startingX,  double startingY,
                                     double incrX,      double incrY,
                                     int    numOrbits,  int    ptsPerOrbit,
                                     double minX,       double maxX,
                                     double minY,       double maxY)
        {
            txtPhaseAngle.Text      = phAngle.ToString();
            txtStartingX.Text       = startingX.ToString();
            txtStartingY.Text       = startingY.ToString();
            txtIncrementX.Text      = incrX.ToString();
            txtIncrementY.Text      = incrY.ToString();
            txtNumOrbits.Text       = numOrbits.ToString();
            txtPointsPerOrbit.Text  = ptsPerOrbit.ToString();
            txtRight.Text           = maxX.ToString();
            txtLeft.Text            = minX.ToString();
            txtTop.Text             = maxY.ToString();
            txtBottom.Text          = minY.ToString();
        }

        /// <summary>
        /// Put the color in the spots from last time and repaint the spots that are in the circle
        /// </summary>
        /// <param name="cursorPoints"></param>
        /// <param name="cursor_pt"></param>
        private void PaintCursorCircle(Point cursor_pt)
        {
            double range = 10;


            // Reset the points from last time
            foreach (var pt in lastSetOfPoints)
            {
                this.myPoints.points[pt.Key].ptColor = pt.Value;
            }

            // Get the size of the circle here
            range = (mapData.MinY - mapData.MaxY) / _zoom;

            // Get a list of the indecies of points in the circle
            List<int> pointsToColor = myPoints.GetNearbyPoints(cursor_pt.X, cursor_pt.Y, range);

            // Empty the list
            lastSetOfPoints = new Dictionary<int, Color>();

            // Put data the list for next time
            for (int i = 0; i < pointsToColor.Count; i++)
            {
                lastSetOfPoints.Add(pointsToColor[i], myPoints.points[pointsToColor[i]].ptColor);
                this.myPoints.points[pointsToColor[i]].ptColor = Color.Pink;
            }
        }

        #endregion

    }
}
