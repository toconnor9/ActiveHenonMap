namespace ActiveHenonMap
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.pnlMain = new System.Windows.Forms.Panel();
            this.txtIncrementY = new System.Windows.Forms.TextBox();
            this.txtIncrementX = new System.Windows.Forms.TextBox();
            this.lblIncrementY = new System.Windows.Forms.Label();
            this.lblIncrementX = new System.Windows.Forms.Label();
            this.txtPointsPerOrbit = new System.Windows.Forms.TextBox();
            this.txtNumOrbits = new System.Windows.Forms.TextBox();
            this.txtStartingY = new System.Windows.Forms.TextBox();
            this.txtStartingX = new System.Windows.Forms.TextBox();
            this.txtBottom = new System.Windows.Forms.TextBox();
            this.txtTop = new System.Windows.Forms.TextBox();
            this.txtRight = new System.Windows.Forms.TextBox();
            this.txtLeft = new System.Windows.Forms.TextBox();
            this.txtPhaseAngle = new System.Windows.Forms.TextBox();
            this.lblPointsPerOrbit = new System.Windows.Forms.Label();
            this.lblNumOrbits = new System.Windows.Forms.Label();
            this.lblStartingY = new System.Windows.Forms.Label();
            this.lblStartingX = new System.Windows.Forms.Label();
            this.lblPhaseAngle = new System.Windows.Forms.Label();
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.lblImageBoundaries = new System.Windows.Forms.Label();
            this.lblInfo = new System.Windows.Forms.Label();
            this.txtlocation = new System.Windows.Forms.TextBox();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.AllowDrop = true;
            this.pnlMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlMain.BackgroundImage = global::ActiveHenonMap.Properties.Resources.WhiteBox;
            this.pnlMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlMain.Location = new System.Drawing.Point(248, 2);
            this.pnlMain.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(1266, 873);
            this.pnlMain.TabIndex = 2;
            this.pnlMain.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pnlMain_MouseClick);
            this.pnlMain.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlMain_MouseDown);
            this.pnlMain.MouseEnter += new System.EventHandler(this.pnlMain_MouseEnter);
            this.pnlMain.MouseLeave += new System.EventHandler(this.pnlMain_MouseLeave);
            this.pnlMain.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pnlMain_MouseMove);
            this.pnlMain.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pnlMain_MouseUp);
            // 
            // txtIncrementY
            // 
            this.txtIncrementY.Location = new System.Drawing.Point(123, 331);
            this.txtIncrementY.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtIncrementY.Name = "txtIncrementY";
            this.txtIncrementY.Size = new System.Drawing.Size(70, 26);
            this.txtIncrementY.TabIndex = 8;
            this.txtIncrementY.Text = "0.03";
            this.txtIncrementY.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtIncrementY.TextChanged += new System.EventHandler(this.TextBoxChanged);
            this.txtIncrementY.MouseEnter += new System.EventHandler(this.textBox_MouseEnter);
            this.txtIncrementY.MouseLeave += new System.EventHandler(this.textBox_MouseLeave);
            // 
            // txtIncrementX
            // 
            this.txtIncrementX.Location = new System.Drawing.Point(123, 298);
            this.txtIncrementX.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtIncrementX.Name = "txtIncrementX";
            this.txtIncrementX.Size = new System.Drawing.Size(70, 26);
            this.txtIncrementX.TabIndex = 7;
            this.txtIncrementX.Text = "0.04";
            this.txtIncrementX.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtIncrementX.TextChanged += new System.EventHandler(this.TextBoxChanged);
            this.txtIncrementX.MouseEnter += new System.EventHandler(this.textBox_MouseEnter);
            this.txtIncrementX.MouseLeave += new System.EventHandler(this.textBox_MouseLeave);
            // 
            // lblIncrementY
            // 
            this.lblIncrementY.AutoSize = true;
            this.lblIncrementY.Location = new System.Drawing.Point(14, 334);
            this.lblIncrementY.Name = "lblIncrementY";
            this.lblIncrementY.Size = new System.Drawing.Size(96, 20);
            this.lblIncrementY.TabIndex = 87;
            this.lblIncrementY.Text = "Increment Y";
            // 
            // lblIncrementX
            // 
            this.lblIncrementX.AutoSize = true;
            this.lblIncrementX.Location = new System.Drawing.Point(14, 300);
            this.lblIncrementX.Name = "lblIncrementX";
            this.lblIncrementX.Size = new System.Drawing.Size(96, 20);
            this.lblIncrementX.TabIndex = 86;
            this.lblIncrementX.Text = "Increment X";
            // 
            // txtPointsPerOrbit
            // 
            this.txtPointsPerOrbit.Location = new System.Drawing.Point(123, 398);
            this.txtPointsPerOrbit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtPointsPerOrbit.Name = "txtPointsPerOrbit";
            this.txtPointsPerOrbit.Size = new System.Drawing.Size(70, 26);
            this.txtPointsPerOrbit.TabIndex = 10;
            this.txtPointsPerOrbit.Text = "1000";
            this.txtPointsPerOrbit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtPointsPerOrbit.TextChanged += new System.EventHandler(this.TextBoxChanged);
            this.txtPointsPerOrbit.MouseEnter += new System.EventHandler(this.textBox_MouseEnter);
            this.txtPointsPerOrbit.MouseLeave += new System.EventHandler(this.textBox_MouseLeave);
            // 
            // txtNumOrbits
            // 
            this.txtNumOrbits.Location = new System.Drawing.Point(123, 362);
            this.txtNumOrbits.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtNumOrbits.Name = "txtNumOrbits";
            this.txtNumOrbits.Size = new System.Drawing.Size(70, 26);
            this.txtNumOrbits.TabIndex = 9;
            this.txtNumOrbits.Text = "38";
            this.txtNumOrbits.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtNumOrbits.TextChanged += new System.EventHandler(this.TextBoxChanged);
            this.txtNumOrbits.MouseEnter += new System.EventHandler(this.textBox_MouseEnter);
            this.txtNumOrbits.MouseLeave += new System.EventHandler(this.textBox_MouseLeave);
            // 
            // txtStartingY
            // 
            this.txtStartingY.Location = new System.Drawing.Point(123, 265);
            this.txtStartingY.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtStartingY.Name = "txtStartingY";
            this.txtStartingY.Size = new System.Drawing.Size(70, 26);
            this.txtStartingY.TabIndex = 6;
            this.txtStartingY.Text = "0.061";
            this.txtStartingY.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtStartingY.TextChanged += new System.EventHandler(this.TextBoxChanged);
            this.txtStartingY.MouseEnter += new System.EventHandler(this.textBox_MouseEnter);
            this.txtStartingY.MouseLeave += new System.EventHandler(this.textBox_MouseLeave);
            // 
            // txtStartingX
            // 
            this.txtStartingX.Location = new System.Drawing.Point(123, 231);
            this.txtStartingX.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtStartingX.Name = "txtStartingX";
            this.txtStartingX.Size = new System.Drawing.Size(70, 26);
            this.txtStartingX.TabIndex = 5;
            this.txtStartingX.Text = "0.098";
            this.txtStartingX.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtStartingX.TextChanged += new System.EventHandler(this.TextBoxChanged);
            this.txtStartingX.MouseEnter += new System.EventHandler(this.textBox_MouseEnter);
            this.txtStartingX.MouseLeave += new System.EventHandler(this.textBox_MouseLeave);
            // 
            // txtBottom
            // 
            this.txtBottom.Location = new System.Drawing.Point(81, 135);
            this.txtBottom.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtBottom.Name = "txtBottom";
            this.txtBottom.Size = new System.Drawing.Size(70, 26);
            this.txtBottom.TabIndex = 3;
            this.txtBottom.Text = "-1.2";
            this.txtBottom.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtBottom.TextChanged += new System.EventHandler(this.TextBoxChanged);
            this.txtBottom.MouseEnter += new System.EventHandler(this.textBox_MouseEnter);
            this.txtBottom.MouseLeave += new System.EventHandler(this.textBox_MouseLeave);
            // 
            // txtTop
            // 
            this.txtTop.Location = new System.Drawing.Point(81, 71);
            this.txtTop.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtTop.Name = "txtTop";
            this.txtTop.Size = new System.Drawing.Size(70, 26);
            this.txtTop.TabIndex = 0;
            this.txtTop.Text = "1.2";
            this.txtTop.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtTop.TextChanged += new System.EventHandler(this.TextBoxChanged);
            this.txtTop.MouseEnter += new System.EventHandler(this.textBox_MouseEnter);
            this.txtTop.MouseLeave += new System.EventHandler(this.textBox_MouseLeave);
            // 
            // txtRight
            // 
            this.txtRight.Location = new System.Drawing.Point(148, 102);
            this.txtRight.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtRight.Name = "txtRight";
            this.txtRight.Size = new System.Drawing.Size(70, 26);
            this.txtRight.TabIndex = 2;
            this.txtRight.Text = "1.2";
            this.txtRight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtRight.TextChanged += new System.EventHandler(this.TextBoxChanged);
            this.txtRight.MouseEnter += new System.EventHandler(this.textBox_MouseEnter);
            this.txtRight.MouseLeave += new System.EventHandler(this.textBox_MouseLeave);
            // 
            // txtLeft
            // 
            this.txtLeft.Location = new System.Drawing.Point(18, 102);
            this.txtLeft.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtLeft.Name = "txtLeft";
            this.txtLeft.Size = new System.Drawing.Size(70, 26);
            this.txtLeft.TabIndex = 1;
            this.txtLeft.Text = "-1.2";
            this.txtLeft.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtLeft.TextChanged += new System.EventHandler(this.TextBoxChanged);
            this.txtLeft.MouseEnter += new System.EventHandler(this.textBox_MouseEnter);
            this.txtLeft.MouseLeave += new System.EventHandler(this.textBox_MouseLeave);
            // 
            // txtPhaseAngle
            // 
            this.txtPhaseAngle.Location = new System.Drawing.Point(123, 199);
            this.txtPhaseAngle.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtPhaseAngle.Name = "txtPhaseAngle";
            this.txtPhaseAngle.Size = new System.Drawing.Size(70, 26);
            this.txtPhaseAngle.TabIndex = 4;
            this.txtPhaseAngle.Text = "1.111";
            this.txtPhaseAngle.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtPhaseAngle.TextChanged += new System.EventHandler(this.TextBoxChanged);
            this.txtPhaseAngle.MouseEnter += new System.EventHandler(this.textBox_MouseEnter);
            this.txtPhaseAngle.MouseLeave += new System.EventHandler(this.textBox_MouseLeave);
            // 
            // lblPointsPerOrbit
            // 
            this.lblPointsPerOrbit.AutoSize = true;
            this.lblPointsPerOrbit.Location = new System.Drawing.Point(14, 400);
            this.lblPointsPerOrbit.Name = "lblPointsPerOrbit";
            this.lblPointsPerOrbit.Size = new System.Drawing.Size(91, 20);
            this.lblPointsPerOrbit.TabIndex = 85;
            this.lblPointsPerOrbit.Text = "Points/Orbit";
            // 
            // lblNumOrbits
            // 
            this.lblNumOrbits.AutoSize = true;
            this.lblNumOrbits.Location = new System.Drawing.Point(14, 366);
            this.lblNumOrbits.Name = "lblNumOrbits";
            this.lblNumOrbits.Size = new System.Drawing.Size(82, 20);
            this.lblNumOrbits.TabIndex = 84;
            this.lblNumOrbits.Text = "# of Orbits";
            // 
            // lblStartingY
            // 
            this.lblStartingY.AutoSize = true;
            this.lblStartingY.Location = new System.Drawing.Point(14, 268);
            this.lblStartingY.Name = "lblStartingY";
            this.lblStartingY.Size = new System.Drawing.Size(80, 20);
            this.lblStartingY.TabIndex = 83;
            this.lblStartingY.Text = "Starting Y";
            // 
            // lblStartingX
            // 
            this.lblStartingX.AutoSize = true;
            this.lblStartingX.Location = new System.Drawing.Point(14, 234);
            this.lblStartingX.Name = "lblStartingX";
            this.lblStartingX.Size = new System.Drawing.Size(80, 20);
            this.lblStartingX.TabIndex = 82;
            this.lblStartingX.Text = "Starting X";
            // 
            // lblPhaseAngle
            // 
            this.lblPhaseAngle.AutoSize = true;
            this.lblPhaseAngle.Location = new System.Drawing.Point(14, 201);
            this.lblPhaseAngle.Name = "lblPhaseAngle";
            this.lblPhaseAngle.Size = new System.Drawing.Size(99, 20);
            this.lblPhaseAngle.TabIndex = 81;
            this.lblPhaseAngle.Text = "Phase Angle";
            // 
            // btnLoad
            // 
            this.btnLoad.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnLoad.Location = new System.Drawing.Point(69, 514);
            this.btnLoad.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(127, 52);
            this.btnLoad.TabIndex = 12;
            this.btnLoad.Text = "&Load";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click_1);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(69, 449);
            this.btnSave.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(127, 52);
            this.btnSave.TabIndex = 11;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click_1);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "henon";
            this.saveFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.saveFileDialog1_FileOk_1);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // lblImageBoundaries
            // 
            this.lblImageBoundaries.AutoSize = true;
            this.lblImageBoundaries.Location = new System.Drawing.Point(14, 31);
            this.lblImageBoundaries.Name = "lblImageBoundaries";
            this.lblImageBoundaries.Size = new System.Drawing.Size(143, 20);
            this.lblImageBoundaries.TabIndex = 90;
            this.lblImageBoundaries.Text = "Image Boundaries:";
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.Location = new System.Drawing.Point(44, 629);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(0, 20);
            this.lblInfo.TabIndex = 91;
            // 
            // txtlocation
            // 
            this.txtlocation.Cursor = System.Windows.Forms.Cursors.Cross;
            this.txtlocation.Location = new System.Drawing.Point(21, 599);
            this.txtlocation.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtlocation.Multiline = true;
            this.txtlocation.Name = "txtlocation";
            this.txtlocation.Size = new System.Drawing.Size(208, 164);
            this.txtlocation.TabIndex = 92;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "BurgundyBox.bmp");
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1518, 892);
            this.Controls.Add(this.txtlocation);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.lblImageBoundaries);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtIncrementY);
            this.Controls.Add(this.txtIncrementX);
            this.Controls.Add(this.lblIncrementY);
            this.Controls.Add(this.lblIncrementX);
            this.Controls.Add(this.txtPointsPerOrbit);
            this.Controls.Add(this.txtNumOrbits);
            this.Controls.Add(this.txtStartingY);
            this.Controls.Add(this.txtStartingX);
            this.Controls.Add(this.txtBottom);
            this.Controls.Add(this.txtTop);
            this.Controls.Add(this.txtRight);
            this.Controls.Add(this.txtLeft);
            this.Controls.Add(this.txtPhaseAngle);
            this.Controls.Add(this.lblPointsPerOrbit);
            this.Controls.Add(this.lblNumOrbits);
            this.Controls.Add(this.lblStartingY);
            this.Controls.Add(this.lblStartingX);
            this.Controls.Add(this.lblPhaseAngle);
            this.Controls.Add(this.pnlMain);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "Active Henon Map";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.Form_MouseScroll);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.TextBox txtIncrementY;
        private System.Windows.Forms.TextBox txtIncrementX;
        private System.Windows.Forms.Label lblIncrementY;
        private System.Windows.Forms.Label lblIncrementX;
        private System.Windows.Forms.TextBox txtPointsPerOrbit;
        private System.Windows.Forms.TextBox txtNumOrbits;
        private System.Windows.Forms.TextBox txtStartingY;
        private System.Windows.Forms.TextBox txtStartingX;
        private System.Windows.Forms.TextBox txtBottom;
        private System.Windows.Forms.TextBox txtTop;
        private System.Windows.Forms.TextBox txtRight;
        private System.Windows.Forms.TextBox txtLeft;
        private System.Windows.Forms.TextBox txtPhaseAngle;
        private System.Windows.Forms.Label lblPointsPerOrbit;
        private System.Windows.Forms.Label lblNumOrbits;
        private System.Windows.Forms.Label lblStartingY;
        private System.Windows.Forms.Label lblStartingX;
        private System.Windows.Forms.Label lblPhaseAngle;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label lblImageBoundaries;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.TextBox txtlocation;
        private System.Windows.Forms.ImageList imageList1;
    }
}

