using UnityEngine;
using UnityEngine.UI;

//класс команд блоков
public abstract class CommandBlock : MonoBehaviour
{
    public string blockName; //(Move, Rotate, If, Goto)
    //public int lineNumber;

    public abstract void Execute(ref int currentLine, RobotController robotController);
}

public abstract class IntBlock : CommandBlock
{
    public int n = 1;
}

public abstract class InternalBlock : CommandBlock
{
    public CommandBlock[] NestedBlocks;

    public void ExecuteNestedBlocks(ref int currentLine, RobotController robotController)
    {
        foreach (CommandBlock block in NestedBlocks)
        {
            block.Execute(ref currentLine, robotController);
        }
    }
}

public abstract class InternalIntBlock : InternalBlock
{
    public int n = 1;
}