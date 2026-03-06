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
            this.ThresholdCheckBox = new System.Windows.Forms.CheckBox();
            this.ThresholdValueInput = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.GradientKernelSelection = new System.Windows.Forms.ComboBox();
            this.LaplacianOperatorPanel = new System.Windows.Forms.Panel();
            this.EdgeMapDisplay = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.ImageDisplay)).BeginInit();
            this.panel1.SuspendLayout();
            this.GradientOperatorPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ThresholdValueInput)).BeginInit();
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
            this.OpenImageDialog.Filter = "Image files (*.png)|*.png";
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
            this.GradientOperatorPanel.Controls.Add(this.ThresholdCheckBox);
            this.GradientOperatorPanel.Controls.Add(this.ThresholdValueInput);
            this.GradientOperatorPanel.Controls.Add(this.label3);
            this.GradientOperatorPanel.Controls.Add(this.GradientKernelSelection);
            this.GradientOperatorPanel.Location = new System.Drawing.Point(157, 12);
            this.GradientOperatorPanel.Name = "GradientOperatorPanel";
            this.GradientOperatorPanel.Size = new System.Drawing.Size(306, 236);
            this.GradientOperatorPanel.TabIndex = 9;
            // 
            // ThresholdCheckBox
            // 
            this.ThresholdCheckBox.AutoSize = true;
            this.ThresholdCheckBox.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ThresholdCheckBox.ForeColor = System.Drawing.Color.White;
            this.ThresholdCheckBox.Location = new System.Drawing.Point(3, 49);
            this.ThresholdCheckBox.Name = "ThresholdCheckBox";
            this.ThresholdCheckBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ThresholdCheckBox.Size = new System.Drawing.Size(114, 26);
            this.ThresholdCheckBox.TabIndex = 11;
            this.ThresholdCheckBox.Text = "Threshold";
            this.ThresholdCheckBox.UseVisualStyleBackColor = true;
            // 
            // ThresholdValueInput
            // 
            this.ThresholdValueInput.BackColor = System.Drawing.Color.Black;
            this.ThresholdValueInput.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ThresholdValueInput.ForeColor = System.Drawing.Color.White;
            this.ThresholdValueInput.Location = new System.Drawing.Point(168, 49);
            this.ThresholdValueInput.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.ThresholdValueInput.Name = "ThresholdValueInput";
            this.ThresholdValueInput.Size = new System.Drawing.Size(133, 29);
            this.ThresholdValueInput.TabIndex = 10;
            this.ThresholdValueInput.Value = new decimal(new int[] {
            255,
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
            this.LaplacianOperatorPanel.Location = new System.Drawing.Point(157, 23);
            this.LaplacianOperatorPanel.Name = "LaplacianOperatorPanel";
            this.LaplacianOperatorPanel.Size = new System.Drawing.Size(306, 236);
            this.LaplacianOperatorPanel.TabIndex = 12;
            this.LaplacianOperatorPanel.Visible = false;
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1064, 878);
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
            ((System.ComponentModel.ISupportInitialize)(this.ThresholdValueInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EdgeMapDisplay)).EndInit();
            this.ResumeLayout(false);

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
        private System.Windows.Forms.NumericUpDown ThresholdValueInput;
        private System.Windows.Forms.CheckBox ThresholdCheckBox;
        private System.Windows.Forms.Panel LaplacianOperatorPanel;
        private System.Windows.Forms.PictureBox EdgeMapDisplay;
    }
}

