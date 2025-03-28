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
    void nValueChange()
    {
        if (int.TryParse(Field.text, out int NewN))
        {
            if (NewN > 0 && terminalUI.Algorithm.CodeChanges < terminalUI.Algorithm.Target)
            {
                LinkedBlock.n = NewN;
                terminalUI.Algorithm.ChangeOfAlgorithm();
            }  
        }
    }
}

// public class InternalIntBlockInputField : IntBlockInputField
// {
//     override public InternalIntBlock LinkedBlock;
// }