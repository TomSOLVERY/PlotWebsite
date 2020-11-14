using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;

namespace LeagueOfPlots.Helpers
{
    public static class ImageHelper
    {
        private static readonly string[] Extensions = { ".jpg", ".jpeg", ".gif", ".png" };
        public static Boolean IsImageFile(String filename)
        {
            return Extensions.Contains(Path.GetExtension(filename), StringComparer.OrdinalIgnoreCase);
        }

        public static Byte[] Resize(Byte[] imageBytes, int maxWidth, int maxHeight)
        {
            using (Image<Rgba32> image = Image.Load(imageBytes))
            using (MemoryStream stream = new MemoryStream())
            {
                Int32 width = image.Width;
                Int32 height = image.Height;
                Int32 croppedLength = Math.Min(width, height);
                Int32 x = width / 2 - croppedLength / 2;
                Int32 y = height / 2 - croppedLength / 2;
                image.Mutate(img => img
                .Crop(new Rectangle(x, y, croppedLength, croppedLength))
                .Resize(new ResizeOptions { Size = new Size(maxWidth, maxHeight), Mode = ResizeMode.Max }));
                image.SaveAsPng(stream);
                return stream.ToArray();
            }
        }
    }
}
