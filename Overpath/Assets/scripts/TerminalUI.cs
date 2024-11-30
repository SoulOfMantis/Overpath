using UnityEngine;
using UnityEngine.UI;

public class TerminalUI : MonoBehaviour
{
    public AlgorithmController algorithmController;

    public InputField moveInputField;
    public InputField rotateInputField;
    //public InputField ifConditionInputField;

    public Button applyMoveButton;
    public Button applyRotateButton;
    //public Button applyIfConditionButton;

    public Button executeAlgorithmButton;

    void Start()
    {
        applyMoveButton.onClick.AddListener(OnApplyMove);
        applyRotateButton.onClick.AddListener(OnApplyRotate);
    //    applyIfConditionButton.onClick.AddListener(OnApplyIfCondition);
        executeAlgorithmButton.onClick.AddListener(OnExecuteAlgorithm);
    }

    void OnApplyMove()
    {
        if (int.TryParse(moveInputField.text, out int moveValue))
        {
            algorithmController.UpdateBlockParameter("Move", moveValue);
        }
    }

    void OnApplyRotate()
    {
        if (int.TryParse(rotateInputField.text, out int rotateValue))
        {
            algorithmController.UpdateBlockParameter("Rotate", rotateValue);
        }
    }

    //void OnApplyIfCondition()
    //{
    //    if (bool.TryParse(ifConditionInputField.text, out bool conditionValue))
    //    {
    //        algorithmController.UpdateIfCondition("If", conditionValue);
    //    }
    //}

    void OnExecuteAlgorithm()
    {
        algorithmController.Update();
    }
}
