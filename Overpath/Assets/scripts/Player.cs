using UnityEngine;
using UnityEngine.Tilemaps;

public class Player : MonoBehaviour
{
    private Vector3Int currentGridPosition;
    public Tilemap tilemap;
    public SpriteRenderer spriteRenderer; // Компонент для управления спрайтом
    public Tilemap collisionLayer; //поле коллизий
    void Start()
    {
        currentGridPosition = tilemap.WorldToCell(transform.position);
        UpdatePlayerPosition();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W)) Move(Vector3Int.up);
        if (Input.GetKeyDown(KeyCode.S)) Move(Vector3Int.down);
        if (Input.GetKeyDown(KeyCode.A)) Move(Vector3Int.left);
        if (Input.GetKeyDown(KeyCode.D)) Move(Vector3Int.right);
        // if (Input.GetKeyDown(KeyCode.F)) functional();
        // if (Input.GetKeyDown(KeyCode.Space)) Skip();
    }

    // void functional()
    // {
    //     // блок для взаимодействия с функциональной клавишей
    //     Skip();
    // }

    // void Skip()
    // {
    //     // пропуск хода
    // }


    void Move(Vector3Int direction)
    {
        Vector3Int newPosition = currentGridPosition + direction;

        if (IsValidMove(newPosition))
        {
            currentGridPosition = newPosition;
            UpdatePlayerPosition();
            RotatePlayer(direction); // Поворот персонажа
        }
    }

    bool IsValidMove(Vector3Int position)
    {
        return !collisionLayer.HasTile(position);
    }

    

    void UpdatePlayerPosition()
    {
        transform.position = tilemap.GetCellCenterWorld(currentGridPosition);
    }

    void RotatePlayer(Vector3Int direction)
    {
        float angle = 0f;
        if (direction == Vector3Int.up) angle = 90;
        else if (direction == Vector3Int.down) angle = 270f;
        else if (direction == Vector3Int.left) angle = 180f;
        else if (direction == Vector3Int.right) angle = 360f;
        transform.eulerAngles = new Vector3(0, 0, angle);
    }
}
