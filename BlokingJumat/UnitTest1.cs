using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace BlokingJumat
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestKalkulasiDamage()
        {
            DMGCAL calc = new DMGCAL();
            int damage = calc.CalculateDamage(100, ElementType.Fire, ElementType.Earth, 10);

            // Damage harus lebih dari 0
            Assert.IsTrue(damage > 0);
        }

        [TestMethod]
        public void TestPlayerLevelUp()
        {
            Player player = new Player();
            player.namaKarakter = "Hero";
            player.hpMaksimum = 100;

            // Tambah 100 EXP untuk naik level
            player.GainExp(100);

            // Level harus naik ke 2 dan HP Maksimum bertambah jadi 120
            Assert.AreEqual(2, player.level);
            Assert.AreEqual(120, player.hpMaksimum);
        }

        [TestMethod]
        public void TestSpatialHashGrid()
        {
            SpatialHashGrid grid = new SpatialHashGrid(10f);
            GameObject obj1 = new GameObject("Enemy1", new Vector3(2, 0, 2));

            grid.Insert(obj1);
            List<GameObject> nearby = grid.GetNearbyObjects(obj1);

            // Memastikan objek berhasil ditemukan dalam grid
            Assert.AreEqual(1, nearby.Count);
        }
    }
}