using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOT.Actions
{
    class TextImageAction
    {

        /// <summary>
        /// 生成文字图片
        /// </summary>
        /// <param name="text"></param>
        /// <param name="isBold"></param>
        /// <param name="fontSize"></param>
        public Image CreateImage(string text, bool isBold, int fontSize)
        {
            int wid = 400;
            int high = 200;
            Font font;
            if (isBold)
            {
                font = new Font("Arial", fontSize, FontStyle.Bold);

            }
            else
            {
                font = new Font("Arial", fontSize, FontStyle.Regular);

            }
            //绘笔颜色
            SolidBrush brush = new SolidBrush(Color.Black);
            StringFormat format = new StringFormat(StringFormatFlags.NoClip);
            format.Alignment = StringAlignment.Center;
            format.LineAlignment = StringAlignment.Center;
            Bitmap image = new Bitmap(wid, high);
            Graphics g = Graphics.FromImage(image);
            g.Clear(Color.White);//透明

            RectangleF rect = new RectangleF(0, 0, wid, high);
            //绘制图片
            g.DrawString(text, font, brush, rect, format);
            //释放对象
            g.Dispose();
            return image;
        }

    }
}
