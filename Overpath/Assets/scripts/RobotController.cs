using UnityEngine;
using UnityEngine.Tilemaps;

    public class RobotController : MonoBehaviour
{
    public Vector3Int currentGridPosition; // Текущая позиция в сетке
    public Vector3Int direction = Vector3Int.up; // Направление взгляда
    public Tilemap tilemap; // Ссылка на Tilemap
    public GameObject player;
    private Animator animator;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");        
     //   animator = GetComponentInChildren<Animator>();
        // Получаем текущую позицию в сетке и обновляем позицию врага
        currentGridPosition = tilemap.WorldToCell(transform.position);
        UpdateEnemyPosition();
    }



    void UpdateEnemyPosition()
    {
        // Обновляем позицию робота в мире на основе текущей позиции в сетке
        transform.position = tilemap.GetCellCenterWorld(currentGridPosition);
    }
    // void OnTriggerEnter2D(Collider2D other)
    // {
    //     if (other.gameObject.CompareTag("Player"))
    //     {
    //         other.gameObject.SendMessage("PlayerDeath");
    //     }
    // }
    public void Step()
    {
        Vector3Int newPosition = currentGridPosition + direction;
        if (IsValidMove(newPosition))
        {
            currentGridPosition = newPosition;
            UpdateEnemyPosition();
            if (player.transform.position == tilemap.GetCellCenterWorld(newPosition))
                player.SendMessage("PlayerDeath");
            SetAnimatorDirection(GetDirectionInt());
        }
    }
    public bool IsValidMove(Vector3Int position)
    {
        return !tilemap.HasTile(position);
    }
    public void Rotate()
    {
        if (direction == Vector3Int.up) direction = Vector3Int.right;
        else if (direction == Vector3Int.right) direction = Vector3Int.down;
        else if (direction == Vector3Int.down) direction = Vector3Int.left;
        else direction = Vector3Int.up;
        SetAnimatorDirection(GetDirectionInt());
    }
    void SetAnimatorDirection(int direction)
    {
       // animator.SetInteger("Vector", direction);
    }

    
    int GetDirectionInt()
    {
        if (direction == Vector3Int.up) return 1;   // Вверх
        if (direction == Vector3Int.right) return 2;  // Вправо
        if (direction == Vector3Int.down) return 3;  // Вниз
        if (direction == Vector3Int.left) return 4;   // Влево
        return 3; // Вниз по умолчанию
    }
}