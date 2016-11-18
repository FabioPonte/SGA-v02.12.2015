using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using System.Windows;
using System.IO;

namespace Atanor.Facilitadores
{
    public class ConverterImagemEmByte
    {

        static public byte[] Converter(ImageSource foto)
        {
            PngBitmapEncoder encoder = new PngBitmapEncoder();
            encoder.Frames.Add(CreateResizedImage(foto,120,120,0));
            byte[] bit = new byte[0];
            using (MemoryStream stream = new MemoryStream())
            {
                //encoder.Frames.Add(BitmapFrame.Create(bitmapSource));
                encoder.Save(stream);
                bit = stream.ToArray();
                stream.Close();
            }


            return bit;
        }

        private static BitmapFrame CreateResizedImage(ImageSource source, int width, int height, int margin)
        {
            var rect = new Rect(margin, margin, width - margin * 2, height - margin * 2);

            var group = new DrawingGroup();
            RenderOptions.SetBitmapScalingMode(group, BitmapScalingMode.Fant);
            group.Children.Add(new ImageDrawing(source, rect));

            var drawingVisual = new DrawingVisual();
            using (var drawingContext = drawingVisual.RenderOpen())
                drawingContext.DrawDrawing(group);

            var resizedImage = new RenderTargetBitmap(
                width, height,         // Resized dimensions
                96, 96,                // Default DPI values
                PixelFormats.Default); // Default pixel format
            resizedImage.Render(drawingVisual);

            

            return BitmapFrame.Create(resizedImage);
        }
    }
}
