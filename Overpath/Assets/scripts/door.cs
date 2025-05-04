using UnityEngine;
using UnityEngine.Tilemaps;

public class Door : InteractableObject
{
    public GameObject VictoryMenu;
    public Tilemap tilemap;

    void Start()
    {
        transform.position = tilemap.GetCellCenterWorld(tilemap.WorldToCell(transform.position));
    }

    public override void Interacted()
    {
        VictoryMenu.SetActive(true);
        GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().MyTurn = false;
    }
}