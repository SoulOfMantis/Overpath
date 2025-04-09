using UnityEngine;
using UnityEngine.Tilemaps;

public class Player : Actor
{
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
        
        // Получаем начальное направление анимации
        int initialDirection = GetDirectionInt();
        Debug.Log("Initial direction: " + initialDirection);
        UpdateAnimatorDirection(initialDirection);
        IsPlayer = true;
        currentGridPosition = tilemap.WorldToCell(transform.position);
        UpdatePosition();
        AllActors[currentGridPosition] = this;
        foreach (var m in GameObject.FindGameObjectsWithTag("Interactable"))
            Interactable[tilemap.WorldToCell(m.transform.position)] = m.GetComponent<InteractableObject>();
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
    Vector3Int newPosition = currentGridPosition + direction;
    if (Interactable.ContainsKey(newPosition))
        {
            Interactable[newPosition].Interacted();
            EndOfTurn();
        }
    }

    public void EndOfTurn()
    {
        MyTurn = false;

        foreach (var robot in AllActors.Values)
        {
            if (!robot.IsPlayer)  
            {
                robot.gameObject.SendMessage("ExecuteCurrentCommand");
                if (robot.currentGridPosition == currentGridPosition) Death();
            }
        }
    }

    void Move(Vector3Int direction)
    {
        Debug.Log("Move direction: " + direction);
        Vector3Int newPosition = currentGridPosition + direction;
        dir = direction;
        if (IsValidMove(newPosition))
        {
            AllActors.Remove(currentGridPosition);
            currentGridPosition = newPosition;
            AllActors[currentGridPosition] = this;
            UpdatePosition();
            EndOfTurn();

            // Получаем направление анимации после движения
            int newDirection = GetDirectionInt();
            Debug.Log("New direction: " + newDirection);
            UpdateAnimatorDirection(newDirection);
        }
    }
    public override void Death()
    {
     GameOver.SetActive(true);
     MyTurn = false;   
     AllActors.Clear();
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