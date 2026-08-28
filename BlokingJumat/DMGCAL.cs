using System;

public enum ElementType { Fire, Water, Earth }

public class DMGCAL 
{
    private float GetElementMultiplier(ElementType attacker, ElementType defender)
    {
        if (attacker == defender) return 1.0f;

        bool isSuperEffective =
          (attacker == ElementType.Fire && defender == ElementType.Earth) ||
          (attacker == ElementType.Earth && defender == ElementType.Water) ||
          (attacker == ElementType.Water && defender == ElementType.Fire);

        return isSuperEffective ? 1.5f : 0.5f;
    }

    public int CalculateDamage(int baseDamage, ElementType attackerType,
                  ElementType defenderType, int defenderDefense)
    {
        float damage = baseDamage;

        // 1) Terapkan pengali elemen
        damage *= GetElementMultiplier(attackerType, defenderType);

        // 2) Terapkan peluang critical hit (20%)
        bool isCritical = new Random().NextDouble() < 0.2;
        if (isCritical)
        {
            damage *= 2f;
        }

        // 3) Kurangi defense SETELAH seluruh pengali diterapkan
        damage -= defenderDefense;

        // 4) Pastikan damage akhir minimal 1
        int finalDamage = Math.Max(1, (int)Math.Round(damage));

        return finalDamage;
    }
}