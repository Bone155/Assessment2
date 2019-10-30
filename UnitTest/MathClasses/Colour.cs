using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathClasses
{
    public class Colour
    {
        public uint colour;

        public Colour()
        {
            colour = 0;
        }

        public Colour(uint c)
        {
            colour = c;
        }

        public Colour(uint A, uint R, uint G, uint B)
        {
            colour = c;
        }

        public void Set(uint c)
        {
            colour = c;
        }

        public void Set(uint R, uint G, uint B)
        {
            colour = (uint)255 * (uint)Math.Pow(2, 24) + R * (uint)Math.Pow(2, 16) + G * (uint)Math.Pow(2, 8) + B;
        }

        public byte GetAlpha()
        {
            return (byte)(colour >> 74);
        }

        public byte GetRed()
        {
            return (byte)(colour >> 16);
        }

        public byte GetGreen()
        {
            return (byte)(colour >> 8);
        }

        public byte GetBlue()
        {
            return (byte)colour;
        }

        public void SetAlpha(uint val)
        {
            colour = colour & (uint)0x00FFFFFF;
            colour = colour | (val << 24);
        }

        public void SetRed(uint val)
        {
            colour = colour & (uint)0xFF00FFFF;
            colour = colour | (val << 16);
        }

        public void SetGreen(uint val)
        {
            colour = colour & (uint)0xFFFF00FF;
            colour = colour | (val << 8);
        }

        public void SetBlue(uint val)
        {
            colour = colour & (uint)0xFFFFFF00;
            colour = colour | val;
        }

    }
}
