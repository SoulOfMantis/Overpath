using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Actor : MonoBehaviour
{
    public Vector3Int currentGridPosition;
    public Tilemap tilemap;
    public bool IsPlayer;
    public static Dictionary< Vector3Int, Actor> AllActors = new();
    public static Dictionary< Vector3Int, InteractableObject> Interactable = new();
    public Vector3Int direction; // Направление взгляда
    
    public void UpdatePosition()
    {
        transform.position = tilemap.GetCellCenterWorld(currentGridPosition);
    }

    public bool IsValidMove(Vector3Int position)
    {
        return !tilemap.HasTile(position) ;
    }
    
    public virtual void Death()
    {
        AllActors.Remove(currentGridPosition);
        gameObject.SetActive(false);
    }
}
