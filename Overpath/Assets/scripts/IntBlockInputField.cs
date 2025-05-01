using UnityEngine;
using UnityEngine.UI;

public class IntBlockInputField : MonoBehaviour
{
    public InputField Field;
    public IntBlock LinkedBlock;
    public TerminalUI terminalUI;

    void OnEnable()
    {
        Field.text = LinkedBlock.n.ToString();
    }
    public void ValueChange()
    {
        if (int.TryParse(Field.text, out int NewN))
        {
            if ((NewN != LinkedBlock.n) && (NewN > 0) && terminalUI.Algorithm.ChangeOfAlgorithm())            
                LinkedBlock.n = NewN;
        }
    }
}

// public class InternalIntBlockInputField : IntBlockInputField
// {
//     override public InternalIntBlock LinkedBlock;
// }