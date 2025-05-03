using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.UI;

public class IfDropdown : MonoBehaviour
{
    public Dropdown dropdown;
    public TerminalUI terminalUI;
    private int chosenOption;

    void Start()
    {
        chosenOption = dropdown.value;
        dropdown.onValueChanged.AddListener(ValueChange);
    }
    public void ValueChange(int newValue)
    {
        if (chosenOption == newValue)
            return;
        if (terminalUI.Algorithm.ChangeOfAlgorithm())
            chosenOption = newValue;
        else dropdown.value = chosenOption;
    }
}
