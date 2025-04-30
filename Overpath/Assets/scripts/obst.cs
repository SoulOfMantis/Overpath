using System.Collections.Generic;
using UnityEngine;

public static class Obstacle
{
    private static HashSet<Vector3Int> blockedPositions = new HashSet<Vector3Int>();
    public static void Add(Vector3Int pos) => blockedPositions.Add(pos);
    public static void Remove(Vector3Int pos) => blockedPositions.Remove(pos);
    public static bool IsBlocked(Vector3Int pos) => blockedPositions.Contains(pos);
}
