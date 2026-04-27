namespace EdgeDetector
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
            this.SelectImageButton = new System.Windows.Forms.Button();
            this.ConvertImageButton = new System.Windows.Forms.Button();
            this.ImageDisplay = new System.Windows.Forms.PictureBox();
            this.SaveImageButton = new System.Windows.Forms.Button();
            this.OpenImageDialog = new System.Windows.Forms.OpenFileDialog();
            this.SaveImageDialog = new System.Windows.Forms.SaveFileDialog();
            this.OperatorOption1 = new System.Windows.Forms.RadioButton();
            this.OperatorOption2 = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.GradientOperatorPanel = new System.Windows.Forms.Panel();
            this.SmootheningCheckBox1 = new System.Windows.Forms.CheckBox();
            this.SmootheningInput1 = new System.Windows.Forms.NumericUpDown();
            this.ThresholdCheckBox1 = new System.Windows.Forms.CheckBox();
            this.ThresholdValueInput1 = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.GradientKernelSelection = new System.Windows.Forms.ComboBox();
            this.LaplacianOperatorPanel = new System.Windows.Forms.Panel();
            this.ThresholdCheckBox2 = new System.Windows.Forms.CheckBox();
            this.ThresholdValueInput2 = new System.Windows.Forms.NumericUpDown();
            this.SmootheningCheckBox2 = new System.Windows.Forms.CheckBox();
            this.SmootheningInput2 = new System.Windows.Forms.NumericUpDown();
            this.EdgeMapDisplay = new System.Windows.Forms.PictureBox();
            this.CompletionTimeInfo = new System.Windows.Forms.Label();
            this.ImageSizeInfo = new System.Windows.Forms.Label();
            this.OutputSizeInfo = new System.Windows.Forms.Label();
            this.OperatorSizeInfo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ImageDisplay)).BeginInit();
            this.panel1.SuspendLayout();
            this.GradientOperatorPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SmootheningInput1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ThresholdValueInput1)).BeginInit();
            this.LaplacianOperatorPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ThresholdValueInput2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SmootheningInput2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EdgeMapDisplay)).BeginInit();
            this.SuspendLayout();
            // 
            // SelectImageButton
            // 
            this.SelectImageButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.SelectImageButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SelectImageButton.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SelectImageButton.ForeColor = System.Drawing.Color.White;
            this.SelectImageButton.Location = new System.Drawing.Point(12, 12);
            this.SelectImageButton.Name = "SelectImageButton";
            this.SelectImageButton.Size = new System.Drawing.Size(139, 37);
            this.SelectImageButton.TabIndex = 1;
            this.SelectImageButton.Text = "Select image";
            this.SelectImageButton.UseVisualStyleBackColor = false;
            this.SelectImageButton.Click += new System.EventHandler(this.SelectImageButton_Click);
            // 
            // ConvertImageButton
            // 
            this.ConvertImageButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.ConvertImageButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ConvertImageButton.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConvertImageButton.ForeColor = System.Drawing.Color.White;
            this.ConvertImageButton.Location = new System.Drawing.Point(12, 56);
            this.ConvertImageButton.Name = "ConvertImageButton";
            this.ConvertImageButton.Size = new System.Drawing.Size(139, 37);
            this.ConvertImageButton.TabIndex = 2;
            this.ConvertImageButton.Text = "Convert image";
            this.ConvertImageButton.UseVisualStyleBackColor = false;
            this.ConvertImageButton.Click += new System.EventHandler(this.ConvertImageButton_Click);
            // 
            // ImageDisplay
            // 
            this.ImageDisplay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ImageDisplay.Location = new System.Drawing.Point(468, 12);
            this.ImageDisplay.Margin = new System.Windows.Forms.Padding(2);
            this.ImageDisplay.Name = "ImageDisplay";
            this.ImageDisplay.Size = new System.Drawing.Size(585, 426);
            this.ImageDisplay.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ImageDisplay.TabIndex = 3;
            this.ImageDisplay.TabStop = false;
            // 
            // SaveImageButton
            // 
            this.SaveImageButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.SaveImageButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SaveImageButton.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SaveImageButton.ForeColor = System.Drawing.Color.White;
            this.SaveImageButton.Location = new System.Drawing.Point(12, 100);
            this.SaveImageButton.Name = "SaveImageButton";
            this.SaveImageButton.Size = new System.Drawing.Size(139, 37);
            this.SaveImageButton.TabIndex = 4;
            this.SaveImageButton.Text = "Save output";
            this.SaveImageButton.UseVisualStyleBackColor = false;
            this.SaveImageButton.Click += new System.EventHandler(this.SaveImageButton_Click);
            // 
            // OpenImageDialog
            // 
            this.OpenImageDialog.FileName = "openFileDialog1";
            this.OpenImageDialog.Filter = "All image types (*.png; *.jpg)|*.png; *.jpg";
            this.OpenImageDialog.RestoreDirectory = true;
            // 
            // SaveImageDialog
            // 
            this.SaveImageDialog.FileName = "output.png";
            this.SaveImageDialog.Filter = "Image files (*.png)|*.png";
            this.SaveImageDialog.RestoreDirectory = true;
            // 
            // OperatorOption1
            // 
            this.OperatorOption1.AutoSize = true;
            this.OperatorOption1.Checked = true;
            this.OperatorOption1.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OperatorOption1.ForeColor = System.Drawing.Color.White;
            this.OperatorOption1.Location = new System.Drawing.Point(3, 35);
            this.OperatorOption1.Name = "OperatorOption1";
            this.OperatorOption1.Size = new System.Drawing.Size(100, 26);
            this.OperatorOption1.TabIndex = 5;
            this.OperatorOption1.TabStop = true;
            this.OperatorOption1.Text = "Gradient";
            this.OperatorOption1.UseVisualStyleBackColor = true;
            this.OperatorOption1.CheckedChanged += new System.EventHandler(this.OperatorOption1_CheckedChanged);
            // 
            // OperatorOption2
            // 
            this.OperatorOption2.AutoSize = true;
            this.OperatorOption2.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OperatorOption2.ForeColor = System.Drawing.Color.White;
            this.OperatorOption2.Location = new System.Drawing.Point(3, 67);
            this.OperatorOption2.Name = "OperatorOption2";
            this.OperatorOption2.Size = new System.Drawing.Size(108, 26);
            this.OperatorOption2.TabIndex = 6;
            this.OperatorOption2.Text = "Laplacian";
            this.OperatorOption2.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(-1, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 22);
            this.label1.TabIndex = 7;
            this.label1.Text = "Operator type:";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.OperatorOption1);
            this.panel1.Controls.Add(this.OperatorOption2);
            this.panel1.ForeColor = System.Drawing.Color.White;
            this.panel1.Location = new System.Drawing.Point(12, 143);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(139, 105);
            this.panel1.TabIndex = 8;
            // 
            // GradientOperatorPanel
            // 
            this.GradientOperatorPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.GradientOperatorPanel.Controls.Add(this.SmootheningCheckBox1);
            this.GradientOperatorPanel.Controls.Add(this.SmootheningInput1);
            this.GradientOperatorPanel.Controls.Add(this.ThresholdCheckBox1);
            this.GradientOperatorPanel.Controls.Add(this.ThresholdValueInput1);
            this.GradientOperatorPanel.Controls.Add(this.label3);
            this.GradientOperatorPanel.Controls.Add(this.GradientKernelSelection);
            this.GradientOperatorPanel.Location = new System.Drawing.Point(157, 12);
            this.GradientOperatorPanel.Name = "GradientOperatorPanel";
            this.GradientOperatorPanel.Size = new System.Drawing.Size(306, 236);
            this.GradientOperatorPanel.TabIndex = 9;
            // 
            // SmootheningCheckBox1
            // 
            this.SmootheningCheckBox1.AutoSize = true;
            this.SmootheningCheckBox1.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SmootheningCheckBox1.ForeColor = System.Drawing.Color.White;
            this.SmootheningCheckBox1.Location = new System.Drawing.Point(3, 93);
            this.SmootheningCheckBox1.Name = "SmootheningCheckBox1";
            this.SmootheningCheckBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.SmootheningCheckBox1.Size = new System.Drawing.Size(141, 26);
            this.SmootheningCheckBox1.TabIndex = 13;
            this.SmootheningCheckBox1.Text = "Smoothening";
            this.SmootheningCheckBox1.UseVisualStyleBackColor = true;
            // 
            // SmootheningInput1
            // 
            this.SmootheningInput1.BackColor = System.Drawing.Color.Black;
            this.SmootheningInput1.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SmootheningInput1.ForeColor = System.Drawing.Color.White;
            this.SmootheningInput1.Location = new System.Drawing.Point(168, 93);
            this.SmootheningInput1.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.SmootheningInput1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.SmootheningInput1.Name = "SmootheningInput1";
            this.SmootheningInput1.Size = new System.Drawing.Size(133, 29);
            this.SmootheningInput1.TabIndex = 12;
            this.SmootheningInput1.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // ThresholdCheckBox1
            // 
            this.ThresholdCheckBox1.AutoSize = true;
            this.ThresholdCheckBox1.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ThresholdCheckBox1.ForeColor = System.Drawing.Color.White;
            this.ThresholdCheckBox1.Location = new System.Drawing.Point(3, 49);
            this.ThresholdCheckBox1.Name = "ThresholdCheckBox1";
            this.ThresholdCheckBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ThresholdCheckBox1.Size = new System.Drawing.Size(114, 26);
            this.ThresholdCheckBox1.TabIndex = 11;
            this.ThresholdCheckBox1.Text = "Threshold";
            this.ThresholdCheckBox1.UseVisualStyleBackColor = true;
            // 
            // ThresholdValueInput1
            // 
            this.ThresholdValueInput1.BackColor = System.Drawing.Color.Black;
            this.ThresholdValueInput1.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ThresholdValueInput1.ForeColor = System.Drawing.Color.White;
            this.ThresholdValueInput1.Location = new System.Drawing.Point(168, 49);
            this.ThresholdValueInput1.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.ThresholdValueInput1.Name = "ThresholdValueInput1";
            this.ThresholdValueInput1.Size = new System.Drawing.Size(133, 29);
            this.ThresholdValueInput1.TabIndex = 10;
            this.ThresholdValueInput1.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(3, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 22);
            this.label3.TabIndex = 9;
            this.label3.Text = "Kernel:";
            // 
            // GradientKernelSelection
            // 
            this.GradientKernelSelection.BackColor = System.Drawing.Color.Black;
            this.GradientKernelSelection.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GradientKernelSelection.ForeColor = System.Drawing.Color.White;
            this.GradientKernelSelection.FormattingEnabled = true;
            this.GradientKernelSelection.Location = new System.Drawing.Point(168, 7);
            this.GradientKernelSelection.Name = "GradientKernelSelection";
            this.GradientKernelSelection.Size = new System.Drawing.Size(133, 30);
            this.GradientKernelSelection.TabIndex = 0;
            this.GradientKernelSelection.Text = "Prewitt";
            // 
            // LaplacianOperatorPanel
            // 
            this.LaplacianOperatorPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LaplacianOperatorPanel.Controls.Add(this.ThresholdCheckBox2);
            this.LaplacianOperatorPanel.Controls.Add(this.ThresholdValueInput2);
            this.LaplacianOperatorPanel.Controls.Add(this.SmootheningCheckBox2);
            this.LaplacianOperatorPanel.Controls.Add(this.SmootheningInput2);
            this.LaplacianOperatorPanel.Location = new System.Drawing.Point(157, 254);
            this.LaplacianOperatorPanel.Name = "LaplacianOperatorPanel";
            this.LaplacianOperatorPanel.Size = new System.Drawing.Size(306, 236);
            this.LaplacianOperatorPanel.TabIndex = 12;
            this.LaplacianOperatorPanel.Visible = false;
            // 
            // ThresholdCheckBox2
            // 
            this.ThresholdCheckBox2.AutoSize = true;
            this.ThresholdCheckBox2.Checked = true;
            this.ThresholdCheckBox2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ThresholdCheckBox2.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ThresholdCheckBox2.ForeColor = System.Drawing.Color.White;
            this.ThresholdCheckBox2.Location = new System.Drawing.Point(3, 14);
            this.ThresholdCheckBox2.Name = "ThresholdCheckBox2";
            this.ThresholdCheckBox2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ThresholdCheckBox2.Size = new System.Drawing.Size(114, 26);
            this.ThresholdCheckBox2.TabIndex = 15;
            this.ThresholdCheckBox2.Text = "Threshold";
            this.ThresholdCheckBox2.UseVisualStyleBackColor = true;
            // 
            // ThresholdValueInput2
            // 
            this.ThresholdValueInput2.BackColor = System.Drawing.Color.Black;
            this.ThresholdValueInput2.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ThresholdValueInput2.ForeColor = System.Drawing.Color.White;
            this.ThresholdValueInput2.Location = new System.Drawing.Point(168, 14);
            this.ThresholdValueInput2.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.ThresholdValueInput2.Name = "ThresholdValueInput2";
            this.ThresholdValueInput2.Size = new System.Drawing.Size(133, 29);
            this.ThresholdValueInput2.TabIndex = 14;
            this.ThresholdValueInput2.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // SmootheningCheckBox2
            // 
            this.SmootheningCheckBox2.AutoSize = true;
            this.SmootheningCheckBox2.Checked = true;
            this.SmootheningCheckBox2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.SmootheningCheckBox2.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SmootheningCheckBox2.ForeColor = System.Drawing.Color.White;
            this.SmootheningCheckBox2.Location = new System.Drawing.Point(3, 61);
            this.SmootheningCheckBox2.Name = "SmootheningCheckBox2";
            this.SmootheningCheckBox2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.SmootheningCheckBox2.Size = new System.Drawing.Size(141, 26);
            this.SmootheningCheckBox2.TabIndex = 15;
            this.SmootheningCheckBox2.Text = "Smoothening";
            this.SmootheningCheckBox2.UseVisualStyleBackColor = true;
            // 
            // SmootheningInput2
            // 
            this.SmootheningInput2.BackColor = System.Drawing.Color.Black;
            this.SmootheningInput2.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SmootheningInput2.ForeColor = System.Drawing.Color.White;
            this.SmootheningInput2.Location = new System.Drawing.Point(168, 61);
            this.SmootheningInput2.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.SmootheningInput2.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.SmootheningInput2.Name = "SmootheningInput2";
            this.SmootheningInput2.Size = new System.Drawing.Size(133, 29);
            this.SmootheningInput2.TabIndex = 14;
            this.SmootheningInput2.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // EdgeMapDisplay
            // 
            this.EdgeMapDisplay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.EdgeMapDisplay.Location = new System.Drawing.Point(468, 442);
            this.EdgeMapDisplay.Margin = new System.Windows.Forms.Padding(2);
            this.EdgeMapDisplay.Name = "EdgeMapDisplay";
            this.EdgeMapDisplay.Size = new System.Drawing.Size(585, 426);
            this.EdgeMapDisplay.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.EdgeMapDisplay.TabIndex = 13;
            this.EdgeMapDisplay.TabStop = false;
            // 
            // CompletionTimeInfo
            // 
            this.CompletionTimeInfo.AutoSize = true;
            this.CompletionTimeInfo.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CompletionTimeInfo.ForeColor = System.Drawing.Color.Gray;
            this.CompletionTimeInfo.Location = new System.Drawing.Point(12, 537);
            this.CompletionTimeInfo.Name = "CompletionTimeInfo";
            this.CompletionTimeInfo.Size = new System.Drawing.Size(175, 22);
            this.CompletionTimeInfo.TabIndex = 14;
            this.CompletionTimeInfo.Text = "Completed in: - sec";
            // 
            // ImageSizeInfo
            // 
            this.ImageSizeInfo.AutoSize = true;
            this.ImageSizeInfo.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ImageSizeInfo.ForeColor = System.Drawing.Color.Gray;
            this.ImageSizeInfo.Location = new System.Drawing.Point(12, 559);
            this.ImageSizeInfo.Name = "ImageSizeInfo";
            this.ImageSizeInfo.Size = new System.Drawing.Size(134, 22);
            this.ImageSizeInfo.TabIndex = 15;
            this.ImageSizeInfo.Text = "Image size: -x-";
            // 
            // OutputSizeInfo
            // 
            this.OutputSizeInfo.AutoSize = true;
            this.OutputSizeInfo.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OutputSizeInfo.ForeColor = System.Drawing.Color.Gray;
            this.OutputSizeInfo.Location = new System.Drawing.Point(12, 581);
            this.OutputSizeInfo.Name = "OutputSizeInfo";
            this.OutputSizeInfo.Size = new System.Drawing.Size(136, 22);
            this.OutputSizeInfo.TabIndex = 16;
            this.OutputSizeInfo.Text = "Output size: -x-";
            // 
            // OperatorSizeInfo
            // 
            this.OperatorSizeInfo.AutoSize = true;
            this.OperatorSizeInfo.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OperatorSizeInfo.ForeColor = System.Drawing.Color.Gray;
            this.OperatorSizeInfo.Location = new System.Drawing.Point(12, 603);
            this.OperatorSizeInfo.Name = "OperatorSizeInfo";
            this.OperatorSizeInfo.Size = new System.Drawing.Size(129, 22);
            this.OperatorSizeInfo.TabIndex = 17;
            this.OperatorSizeInfo.Text = "Operator size:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1064, 845);
            this.Controls.Add(this.OperatorSizeInfo);
            this.Controls.Add(this.OutputSizeInfo);
            this.Controls.Add(this.ImageSizeInfo);
            this.Controls.Add(this.CompletionTimeInfo);
            this.Controls.Add(this.EdgeMapDisplay);
            this.Controls.Add(this.LaplacianOperatorPanel);
            this.Controls.Add(this.GradientOperatorPanel);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.SaveImageButton);
            this.Controls.Add(this.ImageDisplay);
            this.Controls.Add(this.ConvertImageButton);
            this.Controls.Add(this.SelectImageButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Text = "EdgeDetector";
            ((System.ComponentModel.ISupportInitialize)(this.ImageDisplay)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.GradientOperatorPanel.ResumeLayout(false);
            this.GradientOperatorPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SmootheningInput1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ThresholdValueInput1)).EndInit();
            this.LaplacianOperatorPanel.ResumeLayout(false);
            this.LaplacianOperatorPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ThresholdValueInput2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SmootheningInput2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EdgeMapDisplay)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button SelectImageButton;
        private System.Windows.Forms.Button ConvertImageButton;
        private System.Windows.Forms.PictureBox ImageDisplay;
        private System.Windows.Forms.Button SaveImageButton;
        private System.Windows.Forms.OpenFileDialog OpenImageDialog;
        private System.Windows.Forms.SaveFileDialog SaveImageDialog;
        private System.Windows.Forms.RadioButton OperatorOption1;
        private System.Windows.Forms.RadioButton OperatorOption2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel GradientOperatorPanel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox GradientKernelSelection;
        private System.Windows.Forms.NumericUpDown ThresholdValueInput1;
        private System.Windows.Forms.CheckBox ThresholdCheckBox1;
        private System.Windows.Forms.Panel LaplacianOperatorPanel;
        private System.Windows.Forms.PictureBox EdgeMapDisplay;
        private System.Windows.Forms.CheckBox SmootheningCheckBox1;
        private System.Windows.Forms.NumericUpDown SmootheningInput1;
        private System.Windows.Forms.CheckBox SmootheningCheckBox2;
        private System.Windows.Forms.NumericUpDown SmootheningInput2;
        private System.Windows.Forms.CheckBox ThresholdCheckBox2;
        private System.Windows.Forms.NumericUpDown ThresholdValueInput2;
        private System.Windows.Forms.Label CompletionTimeInfo;
        private System.Windows.Forms.Label ImageSizeInfo;
        private System.Windows.Forms.Label OutputSizeInfo;
        private System.Windows.Forms.Label OperatorSizeInfo;
    }
}

