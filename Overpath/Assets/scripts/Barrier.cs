using UnityEngine;

public class Barrier : MonoBehaviour
{
    
    public Animator animator;

    private bool ButtonPressed = false;

    public void Start()
    {
        animator = GetComponent<Animator>();
        SetBarrier(true);
    }

    /// <summary>
    /// для установки аниматора true/false (вкл и выкл барьера)
    /// </summary>
    /// <param name="Button"></param>
    public void SetBarrier(bool Button)
    {
        ButtonPressed = Button;
        animator.SetBool("Control", ButtonPressed);
    }
}
