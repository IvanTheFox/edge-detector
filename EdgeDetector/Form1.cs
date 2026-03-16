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

        private void UpdateTimeInfo(int? newTime)
        {
            CompletionTimeInfo.Invoke((MethodInvoker)delegate
            {
                if (newTime.HasValue)
                    CompletionTimeInfo.Text = $"Completed in: {(double)newTime / 1000} sec";
                else
                    CompletionTimeInfo.Text = "Completed in: - sec";
            });
        }

        private void UpdateImageSizeInfo(int? width = null, int? height = null)
        {
            if (!width.HasValue || !height.HasValue)
                ImageSizeInfo.Text = "Image size: -x-";
            else
                ImageSizeInfo.Text = $"Image size: {width.Value}x{height.Value}";
        }

        private void UpdateOutputSizeInfo(int? width = null, int? height = null)
        {
            CompletionTimeInfo.Invoke((MethodInvoker)delegate
            {
                if (!width.HasValue || !height.HasValue)
                    OutputSizeInfo.Text = "Output size: -x-";
                else
                    OutputSizeInfo.Text = $"Output size: {width.Value}x{height.Value}";
            });
        }

        private void UpdateOperatorSizeInfo(int? width = null, int? height = null)
        {
            if (!width.HasValue || !height.HasValue)
                OperatorSizeInfo.Text = "Image size: -x-";
            else
                OperatorSizeInfo.Text = $"Operator size: {width.Value}x{height.Value}";
        }

        private bool CheckConversionState(bool showPopup = true)
        {
            bool temp = _isConverting;
            if (_isConverting)
                MessageBox.Show("Conversion is in progress. Please wait.", "Program is busy");
            return temp;
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

                UpdateImageSizeInfo(_image.Width, _image.Height);
                UpdateOutputSizeInfo();
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

                if (SmootheningCheckBox1.Checked)
                {
                    int deviation = (int)SmootheningInput1.Value;
                    Kernel gaussian = Kernel.Gaussian(deviation);
                    krnl.X = Converter.Convolve(krnl.X, gaussian.X);
                    krnl.Y = Converter.Convolve(krnl.Y, gaussian.X);
                    krnl.Size = krnl.X.GetLength(0);
                }

                UpdateOperatorSizeInfo(krnl.Size, krnl.Size);

                int? threshold = null;
                if (ThresholdCheckBox1.Checked)
                    threshold = (int)ThresholdValueInput1.Value;

                conversionCall = () =>
                {
                    int startTime = Environment.TickCount;
                    _edgeMap = Converter.GetGradientEdgeMap(_image, krnl, threshold);
                    UpdateTimeInfo(Environment.TickCount - startTime);
                    UpdateOutputSizeInfo(_edgeMap.Width, _edgeMap.Height);
                    EdgeMapDisplay.Image = _edgeMap;
                    _isConverting = false;
                };
            }
            else
            {
                Kernel krnl = Kernel.Laplacian;

                int? gaussianDeviation = null;
                if (SmootheningCheckBox2.Checked)
                {
                    gaussianDeviation = (int)SmootheningInput2.Value;
                    Kernel gaussian = Kernel.Gaussian(gaussianDeviation.Value);
                    krnl.X = Converter.Convolve(krnl.X, gaussian.X);
                    krnl.Size = krnl.X.GetLength(0);
                }

                UpdateOperatorSizeInfo(krnl.Size, krnl.Size);

                int? threshold = null;
                if (ThresholdCheckBox2.Checked)
                    threshold = (int)ThresholdValueInput2.Value;

                conversionCall = () =>
                {
                    int startTime = Environment.TickCount;
                    _edgeMap = Converter.GetLaplacianEdgeMap(_image, threshold, gaussianDeviation);
                    UpdateTimeInfo(Environment.TickCount - startTime);
                    UpdateOutputSizeInfo(_edgeMap.Width, _edgeMap.Height);
                    EdgeMapDisplay.Image = _edgeMap;
                    _isConverting = false;
                };
            }

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