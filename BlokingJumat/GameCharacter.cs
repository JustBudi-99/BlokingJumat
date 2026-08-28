using System;

public abstract class GameCharacter
{
    public string namaKarakter;
    public int hpMaksimum;
    protected int hpSaatIni;

    protected virtual void Awake()
    {
        hpSaatIni = hpMaksimum;
    }

    public void TakeDamage(int dmg)
    {
        hpSaatIni -= dmg;
        if (hpSaatIni < 0) hpSaatIni = 0;
    }

    public bool IsAlive()
    {
        return hpSaatIni > 0;
    }

    public abstract void Attack();
}

public class Player : GameCharacter
{
    public int exp = 0;
    public int level = 1;

    public override void Attack()
    {
        Console.WriteLine(namaKarakter + " menyerang menggunakan senjata!");
    }

    public void GainExp(int jumlahExp)
    {
        exp += jumlahExp;
        if (exp >= level * 100)
        {
            LevelUp();
        }
    }

    private void LevelUp()
    {
        level++;
        hpMaksimum += 20;
        Console.WriteLine(namaKarakter + " naik ke Level " + level + "!");
    }
}