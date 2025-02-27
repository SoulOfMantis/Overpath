using UnityEngine;
using UnityEngine.UI;

public class IntInputField : MonoBehaviour
{
    public IntCommandBlock Block;
    public InputField Field;
    TerminalUI Terminal;

    void nValueChange()
    {
        if (int.TryParse(Field.text, out int NewN))
            {
                if (NewN > 0 && Terminal.Cnt < Terminal.Target)
                {
                    Block.n = NewN;
                    Terminal.Cnt++;
                }  
            }
    }

}