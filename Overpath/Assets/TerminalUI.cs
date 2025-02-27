using UnityEngine;
using UnityEngine.UI;

public class TerminalUI : MonoBehaviour
{
    public AlgorithmController algorithmController;

    public InputField moveInputField;
    public InputField rotateInputField;
    public Button CloseButton;

    public int Cnt = 0;
    public int Target = 3;

    void Start()
    {  
        CloseButton.onClick.AddListener(Close);
    }

    void Close()
    {
        gameObject.SetActive(false);
    }

}