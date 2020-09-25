using BusinessLayer2.Models;

namespace BusinessLayer2.Abstractions
{
    public interface IImageProcessor
    {
        byte[] ProcessImage(byte[] data, int width, int height);
        byte[] ProcessImage(byte[] data, int width, int height, ImageEffect imageEffect);
        byte[] ProcessImage(byte[] data, int width, int height, int blurPixelSize);
        byte[] ProcessImage(byte[] data, int width, int height, ImageEffect imageEffect, int blurPixelSize);
        byte[] GetImageFromFile(string filePath);
    }
}
