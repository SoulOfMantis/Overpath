using UnityEngine;
using UnityEngine.Tilemaps;

public class Player : Actor
{
    public GameObject GameOver;
    public Vector3Int dir = Vector3Int.down;
    public bool MyTurn = true;
    public SpriteRenderer spriteRenderer;
    private Animator animator;
    private NewButtonContoller buttonController;

    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        buttonController = FindFirstObjectByType<NewButtonContoller>();

        if (animator == null)
        {
            Debug.LogError("Animator not found on Player_Sprite!");
        }

        int initialDirection = GetDirectionInt();
        Debug.Log("Initial direction: " + initialDirection);
        UpdateAnimatorDirection(initialDirection);
        IsPlayer = true;
        currentGridPosition = tilemap.WorldToCell(transform.position);
        UpdatePosition();
        AllActors.Add(this);
        foreach (var m in GameObject.FindGameObjectsWithTag("Interactable"))
            Interactable[tilemap.WorldToCell(m.transform.position)] = m.GetComponent<InteractableObject>();
    }

    void Update()
    {
        if (MyTurn && !GameOver.activeSelf)
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
        if (GameOver.activeSelf) return;

        Vector3Int newPosition = currentGridPosition + dir;
        if (Interactable.ContainsKey(newPosition))
        {
            Interactable[newPosition].Interacted();
            MyTurn = false;
        }
    }

    public void EndOfTurn()
    {
        if (GameOver.activeSelf) return;

        MyTurn = false;

        for (int i = 0; i < AllActors.Count; i++)
            if (!AllActors[i].IsPlayer && !Dead.Contains(i))
            {
                if (AllActors[i].currentGridPosition == currentGridPosition) Death();
                AllActors[i].gameObject.SendMessage("ExecuteCurrentCommand");
                Debug.Log($"Отправлено сообщение роботу {i}");
            }
        FinalDeath();
        foreach (var b in allButtons)
            b.EvaluateButton();
        MyTurn = true;
    }

    void Move(Vector3Int direction)
    {
        if (GameOver.activeSelf) return;

        Debug.Log("Move direction: " + direction);
        Vector3Int newPosition = currentGridPosition + direction;
        dir = direction;
        UpdateAnimatorDirection(GetDirectionInt());

        if (IsValidMove(newPosition))
        {
            currentGridPosition = newPosition;
            UpdatePosition();
            EndOfTurn();
        }
    }

    public override void Death()
    {
        GameOver.SetActive(true);
        MyTurn = false;
        AllActors.Clear();
        buttonController.SetGameOverState(true);
    }

    int GetDirectionInt()
    {
        if (dir == Vector3Int.up) return 1;
        else if (dir == Vector3Int.right) return 2;
        else if (dir == Vector3Int.down) return 3;
        else if (dir == Vector3Int.left) return 4;
        Debug.LogWarning("Unknown direction, defaulting to down");
        return 3;
    }

    void UpdateAnimatorDirection(int direction)
    {
        Debug.Log("Setting animator direction to: " + direction);
        animator.SetInteger("Vector", direction);
    }
}