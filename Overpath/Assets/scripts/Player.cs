using UnityEngine;
using UnityEngine.Tilemaps;

public class Player : MonoBehaviour
{
    private Vector3Int currentGridPosition;
    public Tilemap tilemap;
    public GameObject[] Robots;
    public GameObject[] Interactable;
    public GameObject GameOver;
    Vector3Int dir = Vector3Int.down; // Более явное начальное значение
    public bool MyTurn = true;
    public SpriteRenderer spriteRenderer;
    private Animator animator;

    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        if (animator == null)
        {
            Debug.LogError("Animator not found on Player_Sprite!");
        }

        currentGridPosition = tilemap.WorldToCell(transform.position);
        UpdatePlayerPosition();
        Robots = GameObject.FindGameObjectsWithTag("Enemy");
        Interactable = GameObject.FindGameObjectsWithTag("Interactable");
        
        // Получаем начальное направление анимации
        int initialDirection = GetDirectionInt();
        Debug.Log("Initial direction: " + initialDirection);
        UpdateAnimatorDirection(initialDirection);
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

    void Interact()
    {
        Vector3Int newPosition = currentGridPosition + dir;
        foreach (var Object in Interactable)
            if (Object.transform.position == tilemap.GetCellCenterWorld(newPosition))
            {
                Object.SendMessage("Interacted");
                EndOfTurn();
                break;
            }
    }

    public void EndOfTurn()
    {
        MyTurn = false;

        foreach (GameObject robot in Robots)
        {
            robot.SendMessage("ExecuteCurrentCommand");
        }
    }

    void Move(Vector3Int direction)
    {
        Debug.Log("Move direction: " + direction);
        Vector3Int newPosition = currentGridPosition + direction;
        dir = direction;
        if (IsValidMove(newPosition))
        {
            EndOfTurn();
            currentGridPosition = newPosition;
            UpdatePlayerPosition();

            // Получаем направление анимации после движения
            int newDirection = GetDirectionInt();
            Debug.Log("New direction: " + newDirection);
            UpdateAnimatorDirection(newDirection);
        }
    }

    bool IsValidMove(Vector3Int position)
    {
        return !tilemap.HasTile(position);
    }

    void UpdatePlayerPosition()
    {
        transform.position = tilemap.GetCellCenterWorld(currentGridPosition);
    }

    void PlayerDeath()
    {
        GameOver.SetActive(true);
        MyTurn = false;
    }

    int GetDirectionInt()
    {
        if (dir == Vector3Int.up) return 1;
        else if (dir == Vector3Int.right) return 2;
        else if (dir == Vector3Int.down) return 3;
        else if (dir == Vector3Int.left) return 4;
        Debug.LogWarning("Unknown direction, defaulting to down");
        return 3; // Вниз по умолчанию
    }

    void UpdateAnimatorDirection(int direction)
    {
        Debug.Log("Setting animator direction to: " + direction);
        animator.SetInteger("Vector", direction);
    }
}