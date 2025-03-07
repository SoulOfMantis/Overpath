using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    public GameObject Menu;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<Player>().MyTurn = false;
            Interacted();
        }
    }
    public void Interacted()
    {
    Menu.SetActive(true);
    }
}