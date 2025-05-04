using UnityEngine;
using UnityEngine.Tilemaps;

public class Door : InteractableObject
{
    public GameObject VictoryMenu;
    public Tilemap tilemap;
    private NewButtonContoller buttonController;

    void Start()
    {
        transform.position = tilemap.GetCellCenterWorld(tilemap.WorldToCell(transform.position));
        buttonController = FindFirstObjectByType<NewButtonContoller>();
    }

    public override void Interacted()
    {
        VictoryMenu.SetActive(true);
        var player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        player.MyTurn = false;
        buttonController.SetGameOverState(true);
    }
}