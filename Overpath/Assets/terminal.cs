using UnityEngine;
using UnityEngine.Tilemaps;

public class Terminal : InteractableObject 
{
    public GameObject TerminalUI;
    public Tilemap tilemap;

    void Start()
    {
        transform.position = tilemap.GetCellCenterWorld(tilemap.WorldToCell(transform.position));
    }

    public override void Interacted()
    {
        TerminalUI.SetActive(true);
    }
}