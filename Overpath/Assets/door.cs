using UnityEngine;

public class door : InteractableObject
{
    public GameObject VictoryMenu;

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