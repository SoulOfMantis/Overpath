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
        Debug.Log($"Закрыт терминал {Actor.AllActors.FindIndex(x => Algorithm.robotController)}");
        Algorithm.player.EndOfTurn();
        gameObject.SetActive(false);
    }
}
