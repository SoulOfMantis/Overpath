using UnityEngine;
using UnityEngine.Tilemaps;
 
    public class RobotController : MonoBehaviour
{
    public Vector3Int currentGridPosition; // Текущая позиция в сетке
    public Vector3Int direction = Vector3Int.up; // Направление взгляда
    public Tilemap tilemap; // Ссылка на Tilemap
    void Start()
    {
        // Получаем текущую позицию в сетке и обновляем позицию врага
        currentGridPosition = tilemap.WorldToCell(transform.position);
        UpdateEnemyPosition();
    }
    void UpdateEnemyPosition()
    {
        // Обновляем позицию робота в мире на основе текущей позиции в сетке
        transform.position = tilemap.GetCellCenterWorld(currentGridPosition);
    }
    public void Step()
    {
        Vector3Int newPosition = currentGridPosition + direction;
        if (IsMoveValid(newPosition))
        {
            currentGridPosition = newPosition;
            UpdateEnemyPosition();
        }
    }

    public bool IsMoveValid(Vector3Int position) //пока что без логики проверки валидности
    {
        return !tilemap.HasTile(position);
    }

    public void Rotate()
    {
        if (direction == Vector3Int.up) direction = Vector3Int.right;
        else if (direction == Vector3Int.right) direction = Vector3Int.down;
        else if (direction == Vector3Int.down) direction = Vector3Int.left;
        else direction = Vector3Int.up;
    }
}