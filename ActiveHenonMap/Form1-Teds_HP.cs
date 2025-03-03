using Man2;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ActiveHenonMap
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            PlotHenonMap(true);
        }

        private MyPointList myPoints = new MyPointList();
        private bool calculatingMap = false;


        string _textbox_name = "";
        DateTime _Last_time = new DateTime();

        private void Form_MouseScroll(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            string text_from_control = "";
            double value_from_control = 0;

            DateTime time_of_day = new DateTime();
            TimeSpan time_since_last = new TimeSpan();
            double scroll_amount = 0;
            bool parse_success = false;

            Control curr_textbox = null;


            if (_textbox_name != "")
            {
                curr_textbox = GetCurrTextbox(_textbox_name);

                text_from_control = curr_textbox.Text;
                parse_success = double.TryParse(text_from_control, out value_from_control);

                time_of_day = DateTime.Now;
                time_since_last = (time_of_day - _Last_time);
                _Last_time = time_of_day;


                int msSinceLast = (int)(1000.0 * time_since_last.TotalSeconds);

                if (_textbox_name != "txtNumOrbits" &&
                    _textbox_name != "txtPointsPerOrbit")
                {
                    Console.WriteLine("msSinceLast: " + msSinceLast.ToString());

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
                        scroll_amount *= (double)(e.Delta / 120);

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
                        scroll_amount *= (double)(e.Delta / 120);

                        curr_textbox.Text = (value_from_control + scroll_amount).ToString("0");
                    }
                }


                lblInfo.Text = $"scroll: {scroll_amount}";
                lblInfo.Refresh();
            }
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
                    txtPhaseAngle.Text = ValuesToLoad[0];
                    txtRight.Text = ValuesToLoad[1];
                    txtLeft.Text = ValuesToLoad[2];
                    txtTop.Text = ValuesToLoad[3];
                    txtBottom.Text = ValuesToLoad[4];
                    txtStartingX.Text = ValuesToLoad[5];
                    txtStartingY.Text = ValuesToLoad[6];
                    txtIncrementX.Text = ValuesToLoad[7];
                    txtIncrementY.Text = ValuesToLoad[8];
                    txtNumOrbits.Text = ValuesToLoad[9];
                    txtPointsPerOrbit.Text = ValuesToLoad[10]; ;
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



        /// <summary>
        /// Put the points on the panel
        /// </summary>
        /// <returns>The bitmap of the points</returns>
        private Bitmap Draw_Dataset(Panel pnlTarget, MyPointIntList points)
        {
            Bitmap bmp = new Bitmap(pnlTarget.Width, pnlTarget.Height);


            try
            {

                using (Graphics g = Graphics.FromImage(bmp))
                {
                    foreach (MyPointInt pt in points.points)
                    {
                        if (pt.X >= 0 && pt.X < pnlTarget.Width && pt.Y >= 0 && pt.Y < pnlTarget.Height)
                        {
                            SolidBrush currColor = new SolidBrush(pt.ptColor);

                            g.FillRectangle(currColor, pt.X, pt.Y, 1, 1);
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR: " + ex.Message, "Error Plotting Data", MessageBoxButtons.OK);
                throw;
            }

            return bmp;
        }



        /// <summary>
        /// Calculate the points of the Henon map
        /// </summary>
        /// <returns>True if it was able to convert it</returns>
        private bool PlotHenonMap(bool recalculating)
        {
            bool it_worked = false;
            HenonMapData mapData = new HenonMapData();
            //myPoints


            try
            {
                mapData = new HenonMapData(txtPhaseAngle.Text,
                                           txtStartingX.Text, txtStartingY.Text,
                                           txtIncrementX.Text, txtIncrementY.Text,
                                           txtNumOrbits.Text, txtPointsPerOrbit.Text);

                if (recalculating)
                {
                    myPoints = HenonMap.Calculate(mapData);
                }

                myPoints.MinX = TextToDouble(txtLeft.Text);
                myPoints.MaxX = TextToDouble(txtRight.Text);
                myPoints.MinY = TextToDouble(txtTop.Text);
                myPoints.MaxY = TextToDouble(txtBottom.Text);


                MyPointIntList myScreenPoints = myPoints.ConvertToScreenCoordinates(pnlMain.Width, pnlMain.Height);
                Bitmap bmp = Draw_Dataset(pnlMain, myScreenPoints);
                pnlMain.BackgroundImage = bmp;
                pnlMain.Refresh();

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

        private void TextBoxChanged(object sender, EventArgs e)
        {
            if (((Control)sender).Name == "txtTop"    ||
                ((Control)sender).Name == "txtBottom" ||
                ((Control)sender).Name == "txtLeft"   ||
                ((Control)sender).Name == "txtRight"    )
            {
                PlotHenonMap(false);
            }
            else
            {
                PlotHenonMap(true);
            }
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
        }

        private void pnlMain_MouseMove(object sender, MouseEventArgs e)
        {
            double x = 0;
            double y = 0;
            MyPointList pointsNearby = myPoints;

            x = e.X;
            y = e.Y;
            filled = !((System.Windows.Forms.Control)sender).Location.IsEmpty;


            txtlocation.Text = $"X: {e.X}, Y: {e.Y}";
            txtlocation.Refresh();
            //            txtlocation.Text = $"X: {e.X}, Y: {e.Y}";
            Console.WriteLine("Mouse Move");
        }

        private void showLocation(object sender, EventArgs e)
        {
        }
    }
}
