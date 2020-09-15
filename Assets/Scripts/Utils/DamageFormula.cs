using UnityEngine;


public static class DamageFormula
{
    public static int CountDamage<T>(int baseDamage, CharacterStat<T> statistics) where T : StatModifier
    {
        return Mathf.RoundToInt(baseDamage * (1 + (statistics.CurrentValue / 10f)));
    }
}
