using UnityEngine;
using UnityEngine.Tilemaps;

    public class RobotController : Actor
{
    private Animator animator;

    void Start()
    {   animator = GetComponentInChildren<Animator>();    
        IsPlayer = false;
        currentGridPosition = tilemap.WorldToCell(transform.position);
        UpdatePosition();
        AllActors.Add(this);
    }

    public void Step()
    {
        Vector3Int newPosition = currentGridPosition + direction;
        foreach (var actor in AllActors)
        if (actor.currentGridPosition == newPosition)
        {
            actor.Death();
            break;
        }
        if (IsValidMove(newPosition))
        {   
            currentGridPosition = newPosition;
            UpdatePosition();
            SetAnimatorDirection(GetDirectionInt());
        }
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
        animator.SetInteger("Vector", direction);
    }

    // void OnTriggerEnter2D(Collider2D collision)
    // {
    //     collision.GetComponent<Actor>().Death();    
    // }

    int GetDirectionInt()
    {
        if (direction == Vector3Int.up) return 1;   // Вверх
        if (direction == Vector3Int.right) return 2;  // Вправо
        if (direction == Vector3Int.down) return 3;  // Вниз
        if (direction == Vector3Int.left) return 4;   // Влево
        return 3; // Вниз по умолчанию
    }
}