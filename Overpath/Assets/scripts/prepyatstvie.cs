using UnityEngine;
using System.Collections.Generic;

public class Obstacle : MonoBehaviour
{
    public static HashSet<Vector3Int> AllObstaclePositions = new HashSet<Vector3Int>();

    public Vector3Int GridPosition;

    void Start()
    {
        GridPosition = ActorManager.Instance.tilemap.WorldToCell(transform.position);
        AllObstaclePositions.Add(GridPosition);
    }

    public static void RemoveObstacle(Vector3Int pos)
    {
        AllObstaclePositions.Remove(pos);
    }

    public static void AddObstacle(Vector3Int pos)
    {
        AllObstaclePositions.Add(pos);
    }
}
