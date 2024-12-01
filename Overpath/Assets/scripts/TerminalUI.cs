using UnityEngine;
using UnityEngine.UI;

public class TerminalUI : MonoBehaviour
{
    public AlgorithmController algorithmController;

    public InputField moveInputField;
    public InputField rotateInputField;
    //public InputField ifConditionInputField;

    public Button ConfirmButton;

    void Start()
    {
        //applyMoveButton.onClick.AddListener(OnApplyMove);
        //applyRotateButton.onClick.AddListener(OnApplyRotate);
        //applyIfConditionButton.onClick.AddListener(OnApplyIfCondition);
        ConfirmButton.onClick.AddListener(Close);
    }

    public void ApplyMove()
    {
        if (int.TryParse(moveInputField.text, out int moveValue))
        {
            if (moveValue > 0)
            {
            algorithmController.UpdateBlockParameter("Move", moveValue);
            }
        }
    }

    public void ApplyRotate()
    {
        if (int.TryParse(rotateInputField.text, out int rotateValue))
        {
            if (rotateValue > 0)
            {
            algorithmController.UpdateBlockParameter("Rotate", rotateValue);
            }
        }
    }

    //void ApplyIfCondition()
    //{
    //     if (bool.TryParse(ifConditionInputField.text, out bool conditionValue))
    //   {
    //       algorithmController.UpdateIfCondition("If", conditionValue);
    //  }
    //  }

    void Close()
    {
        var player = GameObject.FindWithTag("Player").GetComponent<Player>();
        player.EndOfTurn();
        gameObject.SetActive(false);
    }
}
