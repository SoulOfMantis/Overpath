using UnityEngine;
using UnityEngine.UI;

public class IntBlockInputField : MonoBehaviour
{
    public InputField Field;
    public IntBlock LinkedBlock;
    public TerminalUI terminalUI;

    void Start()
    {
        Field.onSubmit.AddListener(ValueChange);
        Field.onValueChanged.AddListener(PaintText);
    }

    void OnEnable()
    {
        Field.text = LinkedBlock.n.ToString();
        Field.textComponent.color = Color.black;

    }
    public void ValueChange(string NewText)
    {
        if (int.TryParse(NewText, out int NewN))
        {
            if ((NewN != LinkedBlock.n) && (NewN > 0) && terminalUI.Algorithm.ChangeOfAlgorithm())            
            {
                LinkedBlock.n = NewN % 4;
                Field.textComponent.color = Color.black;
            }
        }
    }

    void PaintText(string Text)
    {
        Field.textComponent.color = Color.red;
    }

}

// public class InternalIntBlockInputField : IntBlockInputField
// {
//     override public InternalIntBlock LinkedBlock;
// }