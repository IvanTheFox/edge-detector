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
        Bitmap _image = null;
        Bitmap _edgeMap = null;

        bool _isConverting = false;

        public Form1()
        {
            InitializeComponent();

            // Hiding some panels
            LaplacianOperatorPanel.Location = GradientOperatorPanel.Location;
            GradientOperatorPanel.Visible = true;
            LaplacianOperatorPanel.Visible = false;

            // Adding gradient kernel options for selection
            foreach (var kernelId in Enum.GetValues(typeof(Kernel2d.Kernels)))
                GradientKernelSelection.Items.Add(kernelId.ToString());
            GradientKernelSelection.Text = Kernel2d.Kernels.Roberts.ToString();
        }

        private bool CheckConversionState(bool showPopup = true)
        {
            if (_isConverting)
                MessageBox.Show("Conversion is in progress. Please wait.", "Program is busy");
            return _isConverting;
        }

        private void SelectImageButton_Click(object sender, EventArgs e)
        {
            if (CheckConversionState())
                return;

            if (OpenImageDialog.InitialDirectory == "")
                OpenImageDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            if (OpenImageDialog.ShowDialog() == DialogResult.OK)
            {
                _image?.Dispose();
                _edgeMap?.Dispose();
                _image = FileManager.ImagePathToBitmap(OpenImageDialog.FileName);
                ImageDisplay.Image = _image;
                EdgeMapDisplay.Image = null;
            }
        }

        private void SaveImageButton_Click(object sender, EventArgs e)
        {
            if (CheckConversionState())
                return;

            if (_edgeMap == null)
                return;
            if (SaveImageDialog.InitialDirectory == "")
                SaveImageDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            if (SaveImageDialog.ShowDialog() == DialogResult.OK)
            {
                string fileName = SaveImageDialog.FileName;
                FileManager.BitmapToPath(_edgeMap, fileName);
            }
        }

        private void ConvertImageButton_Click(object sender, EventArgs e)
        {
            if (CheckConversionState())
                return;

            if (_image == null)
            {
                MessageBox.Show("No image has been selected for the conversion", "No image error");
                return;
            }

            // Specifying which edge detection method to use and it's parameters
            Action conversionCall;
            if (OperatorOption1.Checked)
            {
                string kernelName = GradientKernelSelection.Text;
                if (!Enum.TryParse(kernelName, true, out Kernel2d.Kernels kernelId))
                {
                    MessageBox.Show($"Unkwon kernel \"{kernelName}\"", "Input error");
                    return;
                }

                Kernel2d krnl = new Kernel2d(kernelId);

                int? threshold = null;
                if (ThresholdCheckBox.Checked)
                    threshold = (int)ThresholdValueInput.Value;

                conversionCall = () =>
                {
                    _edgeMap = Converter.GetGradientEdgeMap(_image, krnl, threshold);
                    EdgeMapDisplay.Image = _edgeMap;
                    _isConverting = false;
                };
            }
            else
                conversionCall = () =>
                {
                    _edgeMap = Converter.GetLaplacianEdgeMap(_image);
                    EdgeMapDisplay.Image = _edgeMap;
                    _isConverting = false;
                };

            // Starting the conversion
            _isConverting = true;
            EdgeMapDisplay.Image = Properties.Resources.ConvertingImage;

            _edgeMap?.Dispose();

            Task conversion = new Task(conversionCall);
            conversion.Start();
        }

        private void OperatorOption1_CheckedChanged(object sender, EventArgs e)
        {
            GradientOperatorPanel.Visible = OperatorOption1.Checked;
            LaplacianOperatorPanel.Visible = OperatorOption2.Checked;
        }
    }
}