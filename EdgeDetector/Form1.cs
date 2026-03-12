using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EdgeDetector
{
    public partial class Form1 : Form
    {
        Bitmap image = null;
        Bitmap edgeMap = null;

        public Form1()
        {
            InitializeComponent();

            LaplacianOperatorPanel.Location = GradientOperatorPanel.Location;
            GradientOperatorPanel.Visible = true;
            LaplacianOperatorPanel.Visible = false;

            foreach (var kernelId in Enum.GetValues(typeof(Kernel2d.Kernels)))
                GradientKernelSelection.Items.Add(kernelId.ToString());
            GradientKernelSelection.Text = Kernel2d.Kernels.Roberts.ToString();
        }

        private void SelectImageButton_Click(object sender, EventArgs e)
        {
            if (OpenImageDialog.InitialDirectory == "")
                OpenImageDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            if (OpenImageDialog.ShowDialog() == DialogResult.OK)
            {
                image?.Dispose();
                edgeMap?.Dispose();
                image = FileManager.ImagePathToBitmap(OpenImageDialog.FileName);
                ImageDisplay.Image = image;
                EdgeMapDisplay.Image = null;
            }
        }

        private void SaveImageButton_Click(object sender, EventArgs e)
        {
            if (edgeMap == null)
                return;
            if (SaveImageDialog.InitialDirectory == "")
                SaveImageDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            if (SaveImageDialog.ShowDialog() == DialogResult.OK)
            {
                string fileName = SaveImageDialog.FileName;
                FileManager.BitmapToPath(edgeMap, fileName);
            }
        }

        private void ConvertImageButton_Click(object sender, EventArgs e)
        {
            if (image == null)
            {
                MessageBox.Show("No image has been selected for the conversion", "No image error");
                return;
            }

            if (OperatorOption1.Checked)
            {
                string kernelName = GradientKernelSelection.Text;

                if (!Enum.TryParse<Kernel2d.Kernels>(kernelName, true, out Kernel2d.Kernels kernelId))
                {
                    MessageBox.Show($"Unkwon kernel \"{kernelName}\"", "Input error");
                    return;
                }
                Kernel2d krnl = new Kernel2d(kernelId);

                int? threshold = null;
                if (ThresholdCheckBox.Checked)
                    threshold = (int)ThresholdValueInput.Value;

                edgeMap?.Dispose();
                edgeMap = Converter.GetGradientEdgeMap(image, krnl, threshold);
            }
            else
            {
                edgeMap?.Dispose();
                edgeMap = Converter.GetLaplacianEdgeMap(image);
            }

            EdgeMapDisplay.Image = edgeMap;
        }

        private void OperatorOption1_CheckedChanged(object sender, EventArgs e)
        {
            GradientOperatorPanel.Visible = OperatorOption1.Checked;
            LaplacianOperatorPanel.Visible = OperatorOption2.Checked;
        }
    }
}