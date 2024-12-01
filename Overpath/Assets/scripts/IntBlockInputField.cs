using UnityEngine;
using UnityEngine.UI;

public class IntBlockInputField : MonoBehaviour
{
    public InputField Field;
    public IntBlock LinkedBlock;

    void OnEnable()
    {
        Field.text = LinkedBlock.n.ToString();
    }

    public void ApplyChange()
    {
        if (int.TryParse(Field.text, out int NewN))
        {
            if (NewN > 0)
            {
                LinkedBlock.n = NewN;
            }
        }
    }
}