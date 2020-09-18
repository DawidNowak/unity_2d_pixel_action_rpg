using UnityEngine;


public static class DamageFormula
{
    public static int CountDamage<T>(int minDmg, int maxDmg, CharacterStat<T> statistics) where T : StatModifier
    {
        var rand = Random.Range(0f, 1f);
        return Mathf.RoundToInt((minDmg + rand * (maxDmg - minDmg)) * (1 + (statistics.CurrentValue / 10f)));
    }
}
