using UnityEngine;
using UnityEngine.Tilemaps;

public class Player : MonoBehaviour
{
    private Vector3Int currentGridPosition;
    public Tilemap tilemap;
    public GameObject[] Robots;
    public GameObject[] InteractableObjects;
    public GameObject GameOver;
    public bool MyTurn = true;
    public SpriteRenderer spriteRenderer; // Компонент для управления спрайтом
    public Vector3Int direction = Vector3Int.up;

    void Start()
    {
        currentGridPosition = tilemap.WorldToCell(transform.position);
        UpdatePlayerPosition();
        Robots = GameObject.FindGameObjectsWithTag("Enemy"); 
        InteractableObjects = GameObject.FindGameObjectsWithTag("Interactable");
    }

    void Update()
    {
        if (MyTurn)
        {
            if (Input.GetKeyDown(KeyCode.W)) Move(Vector3Int.up);
            if (Input.GetKeyDown(KeyCode.S)) Move(Vector3Int.down);
            if (Input.GetKeyDown(KeyCode.A)) Move(Vector3Int.left);
            if (Input.GetKeyDown(KeyCode.D)) Move(Vector3Int.right);
            if (Input.GetKeyDown(KeyCode.F)) Interact();
            if (Input.GetKeyDown(KeyCode.Space)) EndOfTurn();
        }
    }

    void EndOfTurn()
    {
        MyTurn = false;
        foreach (GameObject robot in Robots)
        {
            robot.SendMessage("ExecuteCurrentCommand");
        }
    }

    void Interact()
    {        
        Vector3Int newPosition = currentGridPosition + direction;
        foreach (GameObject Object in InteractableObjects)
        {
            if (Object.transform.position == tilemap.GetCellCenterWorld(newPosition))
                {
                    Object.SendMessage("Interacted");
                    EndOfTurn();
                    break;
                }
        }
    }

    void Move(Vector3Int dir)
    {
        Vector3Int newPosition = currentGridPosition + dir;

        direction = dir;
        if (IsValidMove(newPosition))
        {
            currentGridPosition = newPosition;
            UpdatePlayerPosition();
           // RotatePlayer(direction); // Поворот персонажа
        }
        EndOfTurn();
    }

    bool IsValidMove(Vector3Int position)
    {
        return !tilemap.HasTile(position);
    }

    void UpdatePlayerPosition()
    {
        transform.position = tilemap.GetCellCenterWorld(currentGridPosition);
    }

    // void RotatePlayer(Vector3Int direction)
    // {
    //     float angle = 0f;
    //     if (direction == Vector3Int.up) angle = 90;
    //     else if (direction == Vector3Int.down) angle = 270f;
    //     else if (direction == Vector3Int.left) angle = 180f;
    //     else if (direction == Vector3Int.right) angle = 360f;
    //     transform.eulerAngles = new Vector3(0, 0, angle);
    // }
}
