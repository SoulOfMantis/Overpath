using UnityEngine;

public class terminal : InteractableObject
{
    public GameObject TerminalMenu;

    void Start()
    {
        transform.position = tilemap.GetCellCenterWorld(tilemap.WorldToCell(transform.position));
    }

    public override void Interacted()
    {
        TerminalMenu.SetActive(true);
        
        GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().MyTurn = false;
    }
}