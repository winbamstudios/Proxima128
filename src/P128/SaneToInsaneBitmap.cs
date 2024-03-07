using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxima128.P128
{
    public class BitmapConverter
    {

        public static Mirage.GraphicsKit.Canvas CGSTOMIRRAGE(Cosmos.System.Graphics.Bitmap CGSImage)
        {

            Mirage.GraphicsKit.Canvas MBMP = new((ushort)CGSImage.Width, (ushort)CGSImage.Height);
            for (int x = 0; x < CGSImage.Width; x++)
            {
                for (int y = 0; y < CGSImage.Height; y++)
                {

                    MBMP[x, y] = new Mirage.GraphicsKit.Color((uint)CGSImage.RawData[x + (y * CGSImage.Width)]);

                }
            }

            return MBMP;

        }

    }
}