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
        string imagePath = "";
        Bitmap edgeMap = null;

        public Form1()
        {
            InitializeComponent();
            Console.Init(ConsoleOutputBox);
        }

        private void SelectImageButton_Click(object sender, EventArgs e)
        {
            Console.Print("User is selecting an image...");
            if (OpenImageDialog.InitialDirectory == "")
                OpenImageDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            if (OpenImageDialog.ShowDialog() == DialogResult.OK)
            {
                imagePath = OpenImageDialog.FileName;
                Console.Print($"User chose image <{imagePath}>");
            }
        }

        private void SaveImageButton_Click(object sender, EventArgs e)
        {
            Console.Print("User is saving the edge map...");
            if (edgeMap == null)
            {
                Console.Print("No edge map to save!");
                return;
            }
            if (SaveImageDialog.InitialDirectory == "")
                SaveImageDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            if (SaveImageDialog.ShowDialog() == DialogResult.OK)
            {
                string fileName = SaveImageDialog.FileName;
                FileManager.BitmapToPath(edgeMap, fileName);
                Console.Print($"User saved the image at <{fileName}>");
            }
        }

        private void ConvertImageButton_Click(object sender, EventArgs e)
        {
            if (imagePath == "")
            {
                Console.Print($"User has not selected an image file");
                return;
            }
            Console.Print("Starting conversion process:");

            Console.Print("\tReading image file to Bitmap...");
            Bitmap image = FileManager.ImagePathToBitmap(imagePath);

            Console.Print("\tConverting image to edge map...");
            if (edgeMap != null)
            {
                edgeMap.Dispose();
                edgeMap = null;
            }
            edgeMap = Converter.GetEdgeMap(image, new Operator(Operator.Operators.Prewitt));
            image.Dispose();

            ImageDisplayBox.Image = edgeMap;
        }
    }
}