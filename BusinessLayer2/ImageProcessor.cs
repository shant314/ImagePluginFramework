using BusinessLayer2.Abstractions;
using BusinessLayer2.Helpers;
using BusinessLayer2.Models;
using System;
using System.Drawing;
using System.IO;

namespace BusinessLayer2
{
    public class ImageProcessor : IImageProcessor
    {
        public byte[] ProcessImage(byte[] data, int width, int height)
        {
            return ProcessImage(data, width, height,new ImageEffect { EffectType = Constants.ImageEffectType.None }, 0);
        }
    
        public byte[] ProcessImage(byte[] data, int width, int height , ImageEffect imageEffect)
        {
            return ProcessImage(data, width, height, imageEffect, 0);
        }
      
        public byte[] ProcessImage(byte[] data, int width, int height, int blurPixelSize)
        {
            return ProcessImage(data, width, height, new ImageEffect { EffectType = Constants.ImageEffectType.None }, blurPixelSize);
        }

        public byte[] ProcessImage(byte[] data, int width, int height, ImageEffect imageEffect, int blurPixelSize)
        {
            ImageSetting imageSetting = new ImageSetting
            {
                Height = height,
                Width = width,
                BlurPixelSize = blurPixelSize,
            };
            return ImageProcess(data, imageEffect, imageSetting);
        }

        public byte[] GetImageFromFile(string filePath)
        {
            if (!File.Exists(filePath))
                throw new FileNotFoundException();

            // Load file meta data with FileInfo
            FileInfo fileInfo = new FileInfo(filePath);

            // The byte[] to save the data in
            byte[] data = new byte[fileInfo.Length];

            // Load a filestream and put its content into the byte[]
            using (FileStream fs = fileInfo.OpenRead())
            {
                fs.Read(data, 0, data.Length);
            }

            return data;
        }


        private byte[] ImageProcess(byte[] data, ImageEffect imageEffect, ImageSetting imageSetting )
        {
            try
            {
                using (MemoryStream StartMemoryStream = new MemoryStream())
                {
                    // write the string to the stream  
                    StartMemoryStream.Write(data, 0, data.Length);
                    // create the start Bitmap from the MemoryStream that contains the image  
                    Bitmap startBitmap = new Bitmap(StartMemoryStream);

                    Bitmap bitmap = ResizeImage(startBitmap, imageSetting.Width, imageSetting.Height);

                    if (imageSetting.BlurPixelSize > 0)
                        bitmap = ImageBlur.Blur(bitmap, imageSetting.BlurPixelSize);

                    // Simulate effect

                    switch (imageEffect.EffectType)
                    {
                        case Constants.ImageEffectType.None:
                            //skip
                            break;
                        case Constants.ImageEffectType.Effect1:
                            //apply effect 1.
                            break;
                        case Constants.ImageEffectType.Effect2:
                            //apply effect 2.
                            break;
                        case Constants.ImageEffectType.Effect3:
                            //apply effect 2.
                            break;
                        default:
                            break;
                    }

                    return ImageToByte(bitmap);
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }


        public static byte[] ImageToByte(Image img)
        {
            ImageConverter converter = new ImageConverter();
            return (byte[])converter.ConvertTo(img, typeof(byte[]));
        }

        // Resize a Bitmap  
        private Bitmap ResizeImage(Bitmap image, int width, int height)
        {
            Bitmap resizedImage = new Bitmap(width, height);
            using (Graphics gfx = Graphics.FromImage(resizedImage))
            {
                gfx.DrawImage(image, new Rectangle(0, 0, width, height),
                    new Rectangle(0, 0, image.Width, image.Height), GraphicsUnit.Pixel);
            }
            return resizedImage;
        }


    }
}
