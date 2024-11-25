namespace RGBtoCMYK
{
	partial class Form1
	{
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
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
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			bezierPictureBox = new PictureBox();
			mainImagePictureBox = new PictureBox();
			cyanPictureBox = new PictureBox();
			yellowPictureBox = new PictureBox();
			magentaPictureBox = new PictureBox();
			blackPictureBox = new PictureBox();
			allCurvesCheckBox = new CheckBox();
			cyanRadioButton = new RadioButton();
			magentaRadioButton = new RadioButton();
			yellowRadioButton = new RadioButton();
			blackRadioButton = new RadioButton();
			noBackButton = new Button();
			fullBackButton = new Button();
			ucrButton = new Button();
			gcrButton = new Button();
			allPicturesButton = new Button();
			changePictureButton = new Button();
			saveCurveButton = new Button();
			loadCurveButton = new Button();
			blackWhiteButton = new Button();
			savePictureButton = new Button();
			openFileDialog1 = new OpenFileDialog();
			saveFileDialog1 = new SaveFileDialog();
			((System.ComponentModel.ISupportInitialize)bezierPictureBox).BeginInit();
			((System.ComponentModel.ISupportInitialize)mainImagePictureBox).BeginInit();
			((System.ComponentModel.ISupportInitialize)cyanPictureBox).BeginInit();
			((System.ComponentModel.ISupportInitialize)yellowPictureBox).BeginInit();
			((System.ComponentModel.ISupportInitialize)magentaPictureBox).BeginInit();
			((System.ComponentModel.ISupportInitialize)blackPictureBox).BeginInit();
			SuspendLayout();
			// 
			// bezierPictureBox
			// 
			bezierPictureBox.BackColor = Color.Silver;
			bezierPictureBox.Location = new Point(12, 12);
			bezierPictureBox.Name = "bezierPictureBox";
			bezierPictureBox.Size = new Size(570, 556);
			bezierPictureBox.TabIndex = 0;
			bezierPictureBox.TabStop = false;
			bezierPictureBox.Paint += bezierPictureBox_Paint;
			bezierPictureBox.MouseDown += bezierPictureBox_MouseDown;
			bezierPictureBox.MouseMove += bezierPictureBox_MouseMove;
			bezierPictureBox.MouseUp += bezierPictureBox_MouseUp;
			// 
			// mainImagePictureBox
			// 
			mainImagePictureBox.BackColor = Color.White;
			mainImagePictureBox.Location = new Point(608, 12);
			mainImagePictureBox.Name = "mainImagePictureBox";
			mainImagePictureBox.Size = new Size(559, 344);
			mainImagePictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
			mainImagePictureBox.TabIndex = 1;
			mainImagePictureBox.TabStop = false;
			// 
			// cyanPictureBox
			// 
			cyanPictureBox.BackColor = Color.White;
			cyanPictureBox.Location = new Point(608, 362);
			cyanPictureBox.Name = "cyanPictureBox";
			cyanPictureBox.Size = new Size(276, 186);
			cyanPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
			cyanPictureBox.TabIndex = 2;
			cyanPictureBox.TabStop = false;
			// 
			// yellowPictureBox
			// 
			yellowPictureBox.BackColor = Color.White;
			yellowPictureBox.Location = new Point(608, 554);
			yellowPictureBox.Name = "yellowPictureBox";
			yellowPictureBox.Size = new Size(276, 186);
			yellowPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
			yellowPictureBox.TabIndex = 3;
			yellowPictureBox.TabStop = false;
			// 
			// magentaPictureBox
			// 
			magentaPictureBox.BackColor = Color.White;
			magentaPictureBox.Location = new Point(891, 362);
			magentaPictureBox.Name = "magentaPictureBox";
			magentaPictureBox.Size = new Size(276, 186);
			magentaPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
			magentaPictureBox.TabIndex = 4;
			magentaPictureBox.TabStop = false;
			// 
			// blackPictureBox
			// 
			blackPictureBox.BackColor = Color.White;
			blackPictureBox.Location = new Point(891, 554);
			blackPictureBox.Name = "blackPictureBox";
			blackPictureBox.Size = new Size(276, 186);
			blackPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
			blackPictureBox.TabIndex = 5;
			blackPictureBox.TabStop = false;
			// 
			// allCurvesCheckBox
			// 
			allCurvesCheckBox.AutoSize = true;
			allCurvesCheckBox.Location = new Point(25, 716);
			allCurvesCheckBox.Name = "allCurvesCheckBox";
			allCurvesCheckBox.Size = new Size(132, 24);
			allCurvesCheckBox.TabIndex = 6;
			allCurvesCheckBox.Text = "Show all curves";
			allCurvesCheckBox.UseVisualStyleBackColor = true;
			allCurvesCheckBox.CheckedChanged += allCurvesCheckBox_CheckedChanged;
			// 
			// cyanRadioButton
			// 
			cyanRadioButton.AutoSize = true;
			cyanRadioButton.Checked = true;
			cyanRadioButton.Location = new Point(25, 587);
			cyanRadioButton.Name = "cyanRadioButton";
			cyanRadioButton.Size = new Size(62, 24);
			cyanRadioButton.TabIndex = 7;
			cyanRadioButton.TabStop = true;
			cyanRadioButton.Tag = "0";
			cyanRadioButton.Text = "Cyan";
			cyanRadioButton.UseVisualStyleBackColor = true;
			cyanRadioButton.CheckedChanged += RadioButton_CheckedChanged;
			// 
			// magentaRadioButton
			// 
			magentaRadioButton.AutoSize = true;
			magentaRadioButton.Location = new Point(25, 617);
			magentaRadioButton.Name = "magentaRadioButton";
			magentaRadioButton.Size = new Size(89, 24);
			magentaRadioButton.TabIndex = 8;
			magentaRadioButton.Tag = "1";
			magentaRadioButton.Text = "Magenta";
			magentaRadioButton.UseVisualStyleBackColor = true;
			magentaRadioButton.CheckedChanged += RadioButton_CheckedChanged;
			// 
			// yellowRadioButton
			// 
			yellowRadioButton.AutoSize = true;
			yellowRadioButton.Location = new Point(25, 647);
			yellowRadioButton.Name = "yellowRadioButton";
			yellowRadioButton.Size = new Size(73, 24);
			yellowRadioButton.TabIndex = 9;
			yellowRadioButton.Tag = "2";
			yellowRadioButton.Text = "Yellow";
			yellowRadioButton.UseVisualStyleBackColor = true;
			yellowRadioButton.CheckedChanged += RadioButton_CheckedChanged;
			// 
			// blackRadioButton
			// 
			blackRadioButton.AutoSize = true;
			blackRadioButton.Location = new Point(25, 677);
			blackRadioButton.Name = "blackRadioButton";
			blackRadioButton.Size = new Size(84, 24);
			blackRadioButton.TabIndex = 10;
			blackRadioButton.Tag = "3";
			blackRadioButton.Text = "(K)Black";
			blackRadioButton.UseVisualStyleBackColor = true;
			blackRadioButton.CheckedChanged += RadioButton_CheckedChanged;
			// 
			// noBackButton
			// 
			noBackButton.Location = new Point(148, 587);
			noBackButton.Name = "noBackButton";
			noBackButton.Size = new Size(145, 29);
			noBackButton.TabIndex = 11;
			noBackButton.Text = "0% cofnięcia";
			noBackButton.UseVisualStyleBackColor = true;
			noBackButton.Click += noBackButton_Click;
			// 
			// fullBackButton
			// 
			fullBackButton.Location = new Point(148, 622);
			fullBackButton.Name = "fullBackButton";
			fullBackButton.Size = new Size(145, 29);
			fullBackButton.TabIndex = 12;
			fullBackButton.Text = "100% cofnięcia";
			fullBackButton.UseVisualStyleBackColor = true;
			fullBackButton.Click += fullBackButton_Click;
			// 
			// ucrButton
			// 
			ucrButton.Location = new Point(148, 657);
			ucrButton.Name = "ucrButton";
			ucrButton.Size = new Size(145, 29);
			ucrButton.TabIndex = 13;
			ucrButton.Text = "UCR";
			ucrButton.UseVisualStyleBackColor = true;
			ucrButton.Click += ucrButton_Click;
			// 
			// gcrButton
			// 
			gcrButton.Location = new Point(148, 692);
			gcrButton.Name = "gcrButton";
			gcrButton.Size = new Size(145, 29);
			gcrButton.TabIndex = 14;
			gcrButton.Text = "GCR";
			gcrButton.UseVisualStyleBackColor = true;
			gcrButton.Click += gcrButton_Click;
			// 
			// allPicturesButton
			// 
			allPicturesButton.Location = new Point(299, 587);
			allPicturesButton.Name = "allPicturesButton";
			allPicturesButton.Size = new Size(132, 29);
			allPicturesButton.TabIndex = 15;
			allPicturesButton.Text = "Show all pictures";
			allPicturesButton.UseVisualStyleBackColor = true;
			allPicturesButton.Click += allPicturesButton_Click;
			// 
			// changePictureButton
			// 
			changePictureButton.Location = new Point(299, 622);
			changePictureButton.Name = "changePictureButton";
			changePictureButton.Size = new Size(132, 29);
			changePictureButton.TabIndex = 16;
			changePictureButton.Text = "Change picture";
			changePictureButton.UseVisualStyleBackColor = true;
			changePictureButton.Click += changePictureButton_Click;
			// 
			// saveCurveButton
			// 
			saveCurveButton.Location = new Point(299, 657);
			saveCurveButton.Name = "saveCurveButton";
			saveCurveButton.Size = new Size(132, 29);
			saveCurveButton.TabIndex = 17;
			saveCurveButton.Text = "Save curve";
			saveCurveButton.UseVisualStyleBackColor = true;
			saveCurveButton.Click += saveCurveButton_Click;
			// 
			// loadCurveButton
			// 
			loadCurveButton.Location = new Point(299, 692);
			loadCurveButton.Name = "loadCurveButton";
			loadCurveButton.Size = new Size(132, 29);
			loadCurveButton.TabIndex = 18;
			loadCurveButton.Text = "Load curve";
			loadCurveButton.UseVisualStyleBackColor = true;
			loadCurveButton.Click += loadCurveButton_Click;
			// 
			// blackWhiteButton
			// 
			blackWhiteButton.Location = new Point(446, 587);
			blackWhiteButton.Name = "blackWhiteButton";
			blackWhiteButton.Size = new Size(127, 64);
			blackWhiteButton.TabIndex = 19;
			blackWhiteButton.Text = "Black and White";
			blackWhiteButton.UseVisualStyleBackColor = true;
			blackWhiteButton.Click += blackWhiteButton_Click;
			// 
			// savePictureButton
			// 
			savePictureButton.Location = new Point(446, 657);
			savePictureButton.Name = "savePictureButton";
			savePictureButton.Size = new Size(127, 64);
			savePictureButton.TabIndex = 20;
			savePictureButton.Text = "Save pictures";
			savePictureButton.UseVisualStyleBackColor = true;
			savePictureButton.Click += savePictureButton_Click;
			// 
			// openFileDialog1
			// 
			openFileDialog1.FileName = "openFileDialog1";
			// 
			// Form1
			// 
			AutoScaleDimensions = new SizeF(8F, 20F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(1179, 752);
			Controls.Add(savePictureButton);
			Controls.Add(blackWhiteButton);
			Controls.Add(loadCurveButton);
			Controls.Add(saveCurveButton);
			Controls.Add(changePictureButton);
			Controls.Add(allPicturesButton);
			Controls.Add(gcrButton);
			Controls.Add(ucrButton);
			Controls.Add(fullBackButton);
			Controls.Add(noBackButton);
			Controls.Add(blackRadioButton);
			Controls.Add(yellowRadioButton);
			Controls.Add(magentaRadioButton);
			Controls.Add(cyanRadioButton);
			Controls.Add(allCurvesCheckBox);
			Controls.Add(blackPictureBox);
			Controls.Add(magentaPictureBox);
			Controls.Add(yellowPictureBox);
			Controls.Add(cyanPictureBox);
			Controls.Add(mainImagePictureBox);
			Controls.Add(bezierPictureBox);
			MaximumSize = new Size(1197, 799);
			MinimumSize = new Size(1197, 799);
			Name = "Form1";
			Text = "Form1";
			((System.ComponentModel.ISupportInitialize)bezierPictureBox).EndInit();
			((System.ComponentModel.ISupportInitialize)mainImagePictureBox).EndInit();
			((System.ComponentModel.ISupportInitialize)cyanPictureBox).EndInit();
			((System.ComponentModel.ISupportInitialize)yellowPictureBox).EndInit();
			((System.ComponentModel.ISupportInitialize)magentaPictureBox).EndInit();
			((System.ComponentModel.ISupportInitialize)blackPictureBox).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private PictureBox bezierPictureBox;
		private PictureBox mainImagePictureBox;
		private PictureBox cyanPictureBox;
		private PictureBox yellowPictureBox;
		private PictureBox magentaPictureBox;
		private PictureBox blackPictureBox;
		private CheckBox allCurvesCheckBox;
		private RadioButton cyanRadioButton;
		private RadioButton magentaRadioButton;
		private RadioButton yellowRadioButton;
		private RadioButton blackRadioButton;
		private Button noBackButton;
		private Button fullBackButton;
		private Button ucrButton;
		private Button gcrButton;
		private Button allPicturesButton;
		private Button changePictureButton;
		private Button saveCurveButton;
		private Button loadCurveButton;
		private Button blackWhiteButton;
		private Button savePictureButton;
		private OpenFileDialog openFileDialog1;
		private SaveFileDialog saveFileDialog1;
	}
}
