using UnityEngine;

public static class ColorExtensions
{
    public struct HSV { public float h, s, v; }
    public struct RGB { public float r, g, b; }

    public static HSV GetHSV(this Color self)
    {
        return RgbToHsv(self.r, self.g, self.b);
    }

    public static RGB GetRGB(this Color self)
    {
        RGB rgb = new RGB();
        rgb.r = self.r;
        rgb.g = self.g;
        rgb.b = self.b;
        return rgb;
    }

    public static HSV RgbToHsv(RGB rgb)
    {
        return RgbToHsv(rgb.r, rgb.g, rgb.b);
    }

    public static RGB HsvToRgb(HSV hsv)
    {
        return HsvToRgb(hsv.h, hsv.s, hsv.v);
    }

    /**
     * http://stackoverflow.com/questions/3018313/algorithm-to-convert-rgb-to-hsv-and-hsv-to-rgb-in-range-0-255-for-both
     */
    public static HSV RgbToHsv(float r, float g, float b)
    {
        HSV hsv = new HSV();

        float min = Mathf.Min(new float[] { r, g, b });
        float max = Mathf.Max(new float[] { r, g, b });

        hsv.v = max;
        float delta = max - min;

        if (delta < 0.00001f || max <= 0.0f)
        {
            hsv.s = 0.0f;
            hsv.h = 0.0f;
        }
        else
        {
            hsv.s = delta / max;

            if (Mathf.Abs(max - r) < 0.00001f)
                hsv.h = (g - b) / delta;
            else if (Mathf.Abs(max - g) < 0.00001f)
                hsv.h = 2.0f + (b - r) / delta;
            else
                hsv.h = 4.0f + (r - g) / delta;

            hsv.h *= 60.0f;

            while (hsv.h < 0.0f)
                hsv.h += 360.0f;
        }

        return hsv;
    }

    public static RGB HsvToRgb(float h, float s, float v)
    {
        RGB rgb = new RGB();

        if (s <= 0.0f)
        {
            rgb.r = v;
            rgb.g = v;
            rgb.b = v;
        }
        else
        {
            float hh = h;
            if (hh >= 360.0f)
                hh = 0.0f;
            else
                hh /= 60.0f;

            int i = (int)hh;
            float extra = hh - i;
            float p = v * (1.0f - s);
            float q = v * (1.0f - (s * extra));
            float t = v * (1.0f - (s * (1.0f - extra)));

            switch (i)
            {
                case 0:
                    rgb.r = v;
                    rgb.g = t;
                    rgb.b = p;
                    break;
                case 1:
                    rgb.r = q;
                    rgb.g = v;
                    rgb.b = p;
                    break;
                case 2:
                    rgb.r = p;
                    rgb.g = v;
                    rgb.b = t;
                    break;

                case 3:
                    rgb.r = p;
                    rgb.g = q;
                    rgb.b = v;
                    break;
                case 4:
                    rgb.r = t;
                    rgb.g = p;
                    rgb.b = v;
                    break;
                case 5:
                default:
                    rgb.r = v;
                    rgb.g = p;
                    rgb.b = q;
                    break;
            }
        }

        return rgb;
    }
}
