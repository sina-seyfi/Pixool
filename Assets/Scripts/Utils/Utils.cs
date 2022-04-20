using UnityEngine;

public class Utils
{
    public static bool onChance(float chance, float overal) {
		if(chance <= 0.0f || overal <= 0.0f || overal < chance) return false;
		if(overal == chance) return true;
		return Random.Range(0, overal) >= (overal - chance);
	}

	public static bool onChance(float percent) {
		if(percent < 0.0f) return false;
		if(percent > 100.0f) return true;
		return onChance(percent, 100.0f);
	}

	public static double linearRGB(byte b) {
		return b / 255.0;
    }

	public static double calculateLuminance(Color32 color) {
		return (linearRGB(color.r) * 0.2126 + linearRGB(color.g) * 0.7152 + linearRGB(color.b) * 0.0722) * linearRGB(color.a);
	}

}
