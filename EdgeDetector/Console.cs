using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EdgeDetector
{
    internal class Console
    {
        static Label label;
        static ArrayList lines;

        public static void Init(Label _label)
        {
            label = _label;
            lines = new ArrayList();
        }
        public static void Refresh()
        {
            string output = "";
            foreach (string line in lines)
                output += line + "\n";
            label.Text = output;
        }
        public static void Clear()
        {
            lines.Clear();
            Refresh();
        }
        public static void Print(string text)
        {
            lines.Add(text);
            Refresh();
        }
    }
}
