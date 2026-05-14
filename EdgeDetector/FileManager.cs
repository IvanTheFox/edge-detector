using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdgeDetector
{
    /// <summary>
    /// Функциональный класс для сохранения и чтения файлов.
    /// </summary>
    internal class FileManager
    {
        /// <summary>
        /// Считывает изображение по пути и конвертирует его в Bitmap
        /// </summary>
        /// <param name="path">Путь к изображению</param>
        /// <returns>Bitmap</returns>
        public static Bitmap ImagePathToBitmap(string path)
        {
            return new Bitmap(path);
        }

        /// <summary>
        /// Сохраняет Bitmap как файл изображения на компьютер по пути.
        /// </summary>
        /// <param name="bitmap">Изображение</param>
        /// <param name="path">Путь сохранения</param>
        public static void BitmapToPath(Bitmap bitmap, string path)
        {
            using (MemoryStream memory = new MemoryStream())
            {
                using (FileStream fs = new FileStream(path, FileMode.Create, FileAccess.ReadWrite))
                {
                    bitmap.Save(memory, ImageFormat.Png);
                    byte[] bytes = memory.ToArray();
                    fs.Write(bytes, 0, bytes.Length);
                }
            }
        }
    }
}
