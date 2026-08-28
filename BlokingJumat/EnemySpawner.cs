using System;
using System.Collections.Generic;

// Vector3 kustom agar tidak tergantung library luar sama sekali
public struct Vector3
{
    public float x, y, z;

    public Vector3(float x, float y, float z)
    {
        this.x = x;
        this.y = y;
        this.z = z;
    }

    public static float Distance(Vector3 a, Vector3 b)
    {
        float dx = a.x - b.x;
        float dy = a.y - b.y;
        float dz = a.z - b.z;
        return (float)Math.Sqrt(dx * dx + dy * dy + dz * dz);
    }
}

public class EnemyAI
{
    public Vector3 Position { get; set; }
    public bool IsChasing { get; private set; }

    public void ChasePlayer(Vector3 playerPosition)
    {
        IsChasing = true;
    }
}

public class EnemySpawner
{
    private Vector3 playerPosition;
    private List<EnemyAI> enemyAIList = new List<EnemyAI>();

    public void Initialize(Vector3 playerPos, List<EnemyAI> enemies)
    {
        this.playerPosition = playerPos;
        this.enemyAIList = enemies;
    }

    public void UpdateSpawner()
    {
        foreach (EnemyAI enemyAI in enemyAIList)
        {
            if (enemyAI == null) continue;

            float distance = Vector3.Distance(enemyAI.Position, playerPosition);
            if (distance < 5f)
            {
                enemyAI.ChasePlayer(playerPosition);
            }
        }
    }
}