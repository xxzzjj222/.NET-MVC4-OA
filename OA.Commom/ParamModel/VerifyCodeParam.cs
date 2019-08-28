using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace OA.Commom.ParamModel
{
    public class VerifyCodeParam
    {
        public VerifyCodeParam()
        {
            CodeWidth = 80;
            CodeHeight = 30;
            FontSize = 16;
            Colors = new Color[] { Color.Black, Color.Red, Color.Blue, Color.Green, Color.Orange, Color.Brown, Color.Brown, Color.DarkBlue };
            Fonts = new string[] { "Times New Roman" };
            characters = new char[] { '1', '2', '3', '4', '5', '6', '7', '8', '9', 'a', 'b', 'd', 'e', 'f', 'h', 'k', 'm', 'n', 'r', 'x', 'y', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'J', 'K', 'L', 'M', 'N', 'P', 'R', 'S', 'T', 'W', 'X', 'Y' };
            CodeLength = 4;
            InterLineCount = 3;
        }

        public int CodeWidth { get; set; }
        public int CodeHeight { get; set; }
        public int FontSize { get; set; }
        public Color[] Colors;
        public string[] Fonts;
        public char[] characters;
        public int CodeLength { get; set; }
        public int InterLineCount { get; set; }
    }
}
