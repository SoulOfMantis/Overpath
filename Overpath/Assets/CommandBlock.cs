using UnityEngine;
using UnityEngine.UI;

//класс команд блоков
public abstract class CommandBlock : MonoBehaviour
{
    public string blockName; //(Move, Rotate, If, Goto)
    //public int lineNumber;

    public abstract void Execute(ref int currentLine, RobotController robotController);
}

//сами блоки




