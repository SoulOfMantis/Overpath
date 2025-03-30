using UnityEngine;
using UnityEngine.Tilemaps;

public class Player : Actor
{
    public GameObject GameOver;
    public bool MyTurn = true;
    public SpriteRenderer spriteRenderer; // Компонент для управления спрайтом
    void Start()
    {
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


    void Move(Vector3Int dir)
    {        
        Vector3Int newPosition = currentGridPosition + dir;
        direction = dir;
        if (IsValidMove(newPosition))
        {
            AllActors.Remove(currentGridPosition);
            currentGridPosition = newPosition;
            AllActors[currentGridPosition] = this;
            UpdatePosition();
            EndOfTurn();
            //RotatePlayer(direction); // Поворот персонажа
        }
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

    public override void Death()
    {
     GameOver.SetActive(true);
     MyTurn = false;   
     AllActors.Clear();
    }

}
