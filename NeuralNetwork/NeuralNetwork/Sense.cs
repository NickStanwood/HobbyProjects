using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace NeuralNetwork
{
    public class Sense
    {
        public object FullInput;
        public List<object> PartialInput;


        public Sense()
        {
            FullInput = null;
            PartialInput = null;
        }
    }

    public class ImageSense : Sense
    {
        public new Bitmap FullInput;
        public new List<Color> PartialInput;

        /// <summary>
        /// Initilaizes FullInput to the givin Bitmap 
        /// and PartialInput to a List of type Color for each pixel in the Bitmap
        /// </summary>
        /// <param name="img"></param>
        public ImageSense(Bitmap img)
        {
            FullInput = img;
            PartialInput = new List<Color>();

            for (int y = 0; y < img.Size.Height; y++)
            {
                for (int x = 0; x < img.Size.Width; x++)
                {
                    PartialInput.Add(img.GetPixel(x, y));
                }

            }
        }
    }

    public class StringSense : Sense
    {
        public new string FullInput;
        public new List<char> PartialInput;
        /// <summary>
        /// Initilaizes FullInput to the givin Bitmap 
        /// and PartialInput to a List of type Color for each pixel in the Bitmap
        /// </summary>
        /// <param name="img"></param>
        public StringSense(string str)
        {
            FullInput = str;
            PartialInput = new List<char>();

            for (int i = 0; i < str.Length; i++)
            {
                PartialInput.Add(str.ElementAt(i));
            }
        }
    }

    public class IntSense : Sense
    {
        public new int FullInput;
        public new List<int> PartialInput;

        public IntSense(int num)
        {
            FullInput = num;
            PartialInput = new List<int>();

            int temp = num;
            do
            {
                PartialInput.Add(temp % 10);

            } while ((temp /= 10) != 0); 
        }
    }
        
}
