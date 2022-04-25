using UnityEngine;
using System;

static class Utils
{

    public static R[,] Select<T, R>(this T[,] items, Func<T, R> f)
    {
        int d0 = items.GetLength(0);
        int d1 = items.GetLength(1);
        R[,] result = new R[d0, d1];
        for (int i0 = 0; i0 < d0; i0 += 1)
            for (int i1 = 0; i1 < d1; i1 += 1)
                result[i0, i1] = f(items[i0, i1]);
        return result;
    }

    public static bool onChance(float chance, float overal) {
		if(chance <= 0.0f || overal <= 0.0f || overal < chance) return false;
		if(overal == chance) return true;
		return UnityEngine.Random.Range(0, overal) >= (overal - chance);
	}

	public static bool onChance(float percent) {
		if(percent < 0.0f) return false;
		if(percent > 100.0f) return true;
		return onChance(percent, 100.0f);
	}

	public static double linearRGB(byte b) {
		return b / 255.0;
    }

	public static double calculateLuminance(Game.Color color) {
		return linearRGB(color.r) * 0.2126 + linearRGB(color.g) * 0.7152 + linearRGB(color.b) * 0.0722;
	}

    public static int calculateHue(Game.Color color) {
        // convert rgb values to the range of 0-1
        float h = 0;
        float r = color.r;
        float g = color.g;
        float b = color.b;
        r /= 255;
        g /= 255;
        b /= 255;

        // find min and max values out of r,g,b components
        float max = Math.Max(Math.Max(r, g), b);
        float min = Math.Min(Math.Min(r, g), b);

        // all greyscale colors have hue of 0deg
        if (max - min == 0)
        {
            return 0;
        }

        if (max == r)
        {
            // if red is the predominent color
            h = (g - b) / (max - min);
        }
        else if (max == g)
        {
            // if green is the predominent color
            h = 2 + (b - r) / (max - min);
        }
        else if (max == b)
        {
            // if blue is the predominent color
            h = 4 + (r - g) / (max - min);
        }

        h *= 60; // find the sector of 60 degrees to which the color belongs

        // make sure h is a positive angle on the color wheel between 0 and 360
        h %= 360;
        if (h < 0)
        {
            h += 360;
        }

        return (int) Math.Round(h);
    }

    public static double average(double[] values) {
        double sum = 0.0;
        foreach (double value in values) { sum += value; }
        return sum / values.Length;
    }

    public static double average(double[,] values) {
        double sum = 0.0;
        for (int i = 0; i < values.GetLength(0); i++)
            for (int j = 0; j < values.GetLength(1); j++)
                sum += values[i, j];
        return sum / values.Length;
    }

    public static Tuple<double, double> calculateMidAndVariance(double[] values) {
        var avg = average(values);
        double variance = 0.0;
        if (values.Length > 1) {
            foreach (double value in values) {
                variance += Math.Pow(value - avg, 2.0);
            }
            variance /= (values.Length - 1);
        }
        return Tuple.Create(avg, variance);
    }

    public static Tuple<double, double> calculateMidAndVariance(double[,] values) {
        var avg = average(values);
        double variance = 0.0;
        if (values.Length > 1) {
            for (int i = 0; i < values.GetLength(0); i++)
                for (int j = 0; j < values.GetLength(1); j++)
                    variance += Math.Pow(values[i, j] - avg, 2.0);
            variance /= (values.Length - 1);
        }
        return Tuple.Create(avg, variance);
    }

    public static Color32 ToColor32(this Game.Color color)
    {
        return new Color32(color.r, color.g, color.b, Byte.MaxValue);
    }

    public static Game.Color ToColor(this Color32 color32)
    {
        return new Game.Color(color32.r, color32.g, color32.b, color32.a);
    }

}
