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
            this.ConsoleOutputBox = new System.Windows.Forms.Label();
            this.SelectImageButton = new System.Windows.Forms.Button();
            this.ConvertImageButton = new System.Windows.Forms.Button();
            this.ImageDisplayBox = new System.Windows.Forms.PictureBox();
            this.SaveImageButton = new System.Windows.Forms.Button();
            this.OpenImageDialog = new System.Windows.Forms.OpenFileDialog();
            this.SaveImageDialog = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.ImageDisplayBox)).BeginInit();
            this.SuspendLayout();
            // 
            // ConsoleOutputBox
            // 
            this.ConsoleOutputBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.ConsoleOutputBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ConsoleOutputBox.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConsoleOutputBox.ForeColor = System.Drawing.Color.White;
            this.ConsoleOutputBox.Location = new System.Drawing.Point(746, 11);
            this.ConsoleOutputBox.Name = "ConsoleOutputBox";
            this.ConsoleOutputBox.Size = new System.Drawing.Size(308, 432);
            this.ConsoleOutputBox.TabIndex = 0;
            this.ConsoleOutputBox.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
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
            // ImageDisplayBox
            // 
            this.ImageDisplayBox.Location = new System.Drawing.Point(156, 12);
            this.ImageDisplayBox.Margin = new System.Windows.Forms.Padding(2);
            this.ImageDisplayBox.Name = "ImageDisplayBox";
            this.ImageDisplayBox.Size = new System.Drawing.Size(585, 431);
            this.ImageDisplayBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ImageDisplayBox.TabIndex = 3;
            this.ImageDisplayBox.TabStop = false;
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
            this.SaveImageButton.Text = "Save image";
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1064, 450);
            this.Controls.Add(this.SaveImageButton);
            this.Controls.Add(this.ImageDisplayBox);
            this.Controls.Add(this.ConvertImageButton);
            this.Controls.Add(this.SelectImageButton);
            this.Controls.Add(this.ConsoleOutputBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Text = "EdgeDetector";
            ((System.ComponentModel.ISupportInitialize)(this.ImageDisplayBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label ConsoleOutputBox;
        private System.Windows.Forms.Button SelectImageButton;
        private System.Windows.Forms.Button ConvertImageButton;
        private System.Windows.Forms.PictureBox ImageDisplayBox;
        private System.Windows.Forms.Button SaveImageButton;
        private System.Windows.Forms.OpenFileDialog OpenImageDialog;
        private System.Windows.Forms.SaveFileDialog SaveImageDialog;
    }
}

