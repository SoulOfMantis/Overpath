using UnityEngine;
using UnityEngine.Tilemaps;

public class Player : MonoBehaviour
{
    private Vector3Int currentGridPosition;
    public Tilemap tilemap; 

    void Start()
    {
        currentGridPosition = tilemap.WorldToCell(transform.position);
        UpdatePlayerPosition();
    }
    //считывание клавищ
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W)) Move(Vector3Int.up);
        if (Input.GetKeyDown(KeyCode.S)) Move(Vector3Int.down);
        if (Input.GetKeyDown(KeyCode.A)) Move(Vector3Int.left);
        if (Input.GetKeyDown(KeyCode.D)) Move(Vector3Int.right);
    }
    //расчет и проверка возможности перемещения
    void Move(Vector3Int direction)
    {
        Vector3Int newPosition = currentGridPosition + direction;

        if (IsValidMove(newPosition))
        {
            currentGridPosition = newPosition;
            UpdatePlayerPosition();
        }
    }
    //проверка возможности перемещения (пока условий для перемещения нет)
    bool IsValidMove(Vector3Int position)
    {
        return true; 
    }
    //обновление позиции игрока
    void UpdatePlayerPosition()
    {
        transform.position = tilemap.GetCellCenterWorld(currentGridPosition);
    }
}
