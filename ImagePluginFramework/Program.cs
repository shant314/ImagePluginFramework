using BusinessLayer2;
using BusinessLayer2.Abstractions;
using BusinessLayer2.Models;
using System;

namespace ImagePluginFramework
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Insert image path"); //D:\1.jpg
            string imagePath = Console.ReadLine();//"D:\\1.jpg"


            ServiceFactory serviceFactory = new ServiceFactory();
            IImageProcessor imageProcessor = serviceFactory.CreateImaeService();
            byte[] fileData = imageProcessor.GetImageFromFile(imagePath);

            var data1 = imageProcessor.ProcessImage(data: fileData, width: 100, height: 100);

            //if an effect is checked.
            var data2 = imageProcessor.ProcessImage(data: fileData, width: 100, height: 100,
                new ImageEffect { EffectType = Constants.ImageEffectType.Effect2 });

            var data3 = imageProcessor.ProcessImage(data: fileData, width: 100, height: 100, blurPixelSize: 5);

            var data4 = imageProcessor.ProcessImage(data: fileData, width: 100, height: 100,
                new ImageEffect { EffectType = Constants.ImageEffectType.Effect2 }, blurPixelSize: 5);

        }
    }
}
