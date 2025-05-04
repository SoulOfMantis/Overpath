using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Actor : MonoBehaviour
{
    public Vector3Int currentGridPosition;
    public Tilemap tilemap;
    public bool IsPlayer;
    public static List<int> Dead = new();
    public static List<Actor> AllActors = new();
    public static List<PressureButton> allButtons = new List<PressureButton>();
    public static Dictionary<Vector3Int, InteractableObject> Interactable = new();
    public Vector3Int direction; // Направление взгляда
    
    public static void ClearAll()
    {
        Dead.Clear();
        AllActors.Clear();
        allButtons.Clear();
        Interactable.Clear();
        Obstacle.blockedPositions.Clear();
    }

    public void UpdatePosition()
    {
        transform.position = tilemap.GetCellCenterWorld(currentGridPosition);
    }

    public bool IsValidMove(Vector3Int position)
    {
        return !(tilemap.HasTile(position) || Obstacle.IsBlocked(position));
    }
    public virtual void Death()
    {
        Dead.Add(AllActors.FindIndex(x => x == this));
    }

    public static void FinalDeath()
    {
        Dead.Sort();
        Dead.Reverse();
        foreach (var ind in Dead)
        {
            var r = AllActors[ind];
            Debug.Log($"Робот номер {ind} умер!");            
            AllActors.Remove(r);
            r.gameObject.SetActive(false);
        }
        Dead.Clear();
    }
}
