using UnityEngine;
using UnityEngine.UI;

public class TerminalUI : MonoBehaviour
{
    public AlgorithmController algorithmController;

    //public InputField ifConditionInputField;

    public Button CloseButton;

    void Start()
    {
        CloseButton.onClick.AddListener(Close);
    }


    void Close()
    {
        var player = GameObject.FindWithTag("Player").GetComponent<Player>();
        player.EndOfTurn();
        gameObject.SetActive(false);
    }
}
