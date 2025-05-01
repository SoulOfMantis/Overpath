using UnityEngine;
using UnityEngine.Tilemaps;

public class Terminal : InteractableObject 
{
    public GameObject TerminalUI;
    public Vector3Int currentGridPosition;
    public Tilemap tilemap;

    void Start()
    {
        currentGridPosition = tilemap.WorldToCell(transform.position);
        transform.position = tilemap.GetCellCenterWorld(currentGridPosition);
        Obstacle.Add(currentGridPosition);
    }

    public override void Interacted()
    {
        TerminalUI.SetActive(true);
    }
}