using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MODI;
using System.Drawing;

namespace MagicReader
{
    class ImageProcessor
    {
        #region constants
        const string DEFAULT_FILE_PATH = "C:/Users/Nick/Documents/Hobby Projects/MagicReader/MagicReader/Resources/";
        #endregion
        public string Name { get; set; }
        public string Expansion { get; set; }
        public string imageFilePath { get; set; }

        private Document modiDoc;
        private MODI.Image modiImage;

        public ImageProcessor(string filePath)
        {
            modiDoc = new Document();
            Name = GetText(filePath);
            modiDoc.Close();
        }

        public ImageProcessor(Bitmap image)
        {
            string filePath = DEFAULT_FILE_PATH + "image.bmp";

            Name = "";
            Expansion = "";

            image.Save(filePath, System.Drawing.Imaging.ImageFormat.Bmp);

            modiDoc = new Document();
            Name = GetText(filePath);
            modiDoc.Close();
        }

        string GetText(string Filepath)
        {
            string imageText = "INVALID";
            int numTries = 0;
            modiDoc.Create(Filepath);

            while(numTries <= 5 && imageText == "INVALID")
            {
                try
                {
                    modiDoc.OCR(MiLANGUAGES.miLANG_ENGLISH);
                    modiImage = (MODI.Image)modiDoc.Images[0];
                    imageText = modiImage.Layout.Text;
                }
                catch
                {
                    switch (numTries)
                    {
                        case 0:
                            //increase contrast
                            break;
                        case 1:
                            //invert colors
                            break;
                        case 2:
                            break;
                        case 3:
                            break;
                        case 4:
                            break;
                        default:
                            break;

                    }
                    numTries++;
                }
            }

            return imageText;
        }
    }
}
