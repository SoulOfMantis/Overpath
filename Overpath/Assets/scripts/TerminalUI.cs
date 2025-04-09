using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TerminalUI : MonoBehaviour
{
    public AlgorithmController Algorithm;
    public Button CloseButton;
    public TextMeshProUGUI codeChangesCounter;

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
