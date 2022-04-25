using System;

namespace Game
{
    public record Color
    {
        public byte r { get; private set; }
        public byte g { get; private set; }
        public byte b { get; private set; }
        public byte a { get; private set; }

        public Color(byte r, byte g, byte b, byte a)
        {
            this.r = r;
            this.g = g;
            this.b = b;
            this.a = a;
        }

        public Color(byte r, byte g, byte b) {
            this.r = r;
            this.g = g;
            this.b = b;
            this.a = Byte.MaxValue;
        }

    }
    public interface MissedPixelsCalculator
    {
        public Tuple<int, int>[] calculate(Color[,] pixelColors);
    }

    public class MissedPixelsCalculatorFactory
    {
        public static MissedPixelsCalculator create()
        {
            return new VarianceMissedPixelsCalculator();
        }
    }
}