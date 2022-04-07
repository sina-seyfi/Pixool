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

}
