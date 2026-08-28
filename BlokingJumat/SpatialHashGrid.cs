using System;
using System.Collections.Generic;

// Class GameObject tiruan untuk pengganti objek Unity
public class GameObject
{
    public string Name { get; set; }
    public Vector3 Position { get; set; }

    public GameObject(string name, Vector3 position)
    {
        Name = name;
        Position = position;
    }
}

public class SpatialHashGrid
{
    private readonly float cellSize;
    private readonly Dictionary<(int, int), List<GameObject>> cells
        = new Dictionary<(int, int), List<GameObject>>();

    public SpatialHashGrid(float cellSize)
    {
        this.cellSize = cellSize;
    }

    private (int, int) GetCellCoord(Vector3 pos)
    {
        int cx = (int)Math.Floor(pos.x / cellSize);
        int cy = (int)Math.Floor(pos.z / cellSize);
        return (cx, cy);
    }

    public void Clear() => cells.Clear();

    public void Insert(GameObject obj)
    {
        var coord = GetCellCoord(obj.Position);
        if (!cells.TryGetValue(coord, out var list))
        {
            list = new List<GameObject>();
            cells[coord] = list;
        }
        list.Add(obj);
    }

    public List<GameObject> GetNearbyObjects(GameObject obj)
    {
        var result = new List<GameObject>();
        var (cx, cy) = GetCellCoord(obj.Position);
        for (int dx = -1; dx <= 1; dx++)
        {
            for (int dy = -1; dy <= 1; dy++)
            {
                if (cells.TryGetValue((cx + dx, cy + dy), out var list))
                {
                    result.AddRange(list);
                }
            }
        }
        return result;
    }
}