using ImageMagick;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLibrary
{
    public class ImageSplitHelper
    {
        public static string Splice10(List<GachaValueReturn> gachas)
        {
           
            var mainpath = AppDomain.CurrentDomain.BaseDirectory;//获取程序集目录
            using (MagickImage image = new MagickImage())
            {
                MagickReadSettings settings = new MagickReadSettings()
                {
                    ColorSpace = ColorSpace.sRGB,
                    Format = MagickFormat.Png,
                    UseMonochrome = false,
                    Width = 685,
                    Height = 324
                };
                image.SetProfile(ColorProfile.SRGB);
                if (Directory.Exists(@$"{mainpath}GachaResult.png"))
                {
                    image.Read(@$"{mainpath}GachaResult.png", settings);
                }
                else
                {
                    Bitmap bitmap = new Bitmap(685, 324);
                    Graphics g = Graphics.FromImage(bitmap);
                    g.Clear(Color.Transparent);
                    g.Save();
                    g.Dispose();
                    bitmap.Save(@$"{mainpath}GachaResult.png", ImageFormat.Png);
                }

                image.Read(@$"{mainpath}GachaResult.png", settings);

                for (int i = 0; i < gachas.Count; i++)
                {
                    MagickImage photo = new MagickImage();
                    if (gachas[i].type == 0)
                    {
                        photo = new MagickImage(@$"{mainpath}Res\Image\Role\{gachas[i].value}.png");
                    }
                    else
                    {
                        photo = new MagickImage(@$"{mainpath}Res\Image\Weapon\{gachas[i].value}.png");
                    }

                    if (i < 5)
                    {
                        image.Composite(photo, 133 * i + 3, 0, CompositeOperator.Copy);
                    }
                    else
                    {
                        image.Composite(photo, 133 * (i - 5) + 3, 162, CompositeOperator.Copy);
                    }
                }

                // image.Write(@$"{AppDomain.CurrentDomain.BaseDirectory}\GachaResult.png"); // caption_long_en.png

                return image.ToBase64();
            }
        }
    }
}
