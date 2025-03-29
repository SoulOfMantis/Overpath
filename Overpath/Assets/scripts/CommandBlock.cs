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
    public CommandBlock[] nestedBlocks;
    public NestedPanel[] nestedPanels;
    public AlgorithmController algorithm;

    public void ExecuteNestedBlocks(ref int currentLine, RobotController robotController)
    {
        foreach (CommandBlock block in nestedBlocks)
        {
            block.Execute(ref currentLine, robotController);
        }
    }

    public void SwapNestedBlocksAndPanels(int indexA, int indexB)
    { 
        if (algorithm.ChangeOfAlgorithm())
        {
            (nestedBlocks[indexA], nestedBlocks[indexB]) = (nestedBlocks[indexB], nestedBlocks[indexA]);
            (nestedPanels[indexA], nestedPanels[indexB]) = (nestedPanels[indexB], nestedPanels[indexA]);
        
            nestedPanels[indexA].BlockNumber = indexA;
            nestedPanels[indexB].BlockNumber = indexB;
        }

    }
}

public abstract class InternalIntBlock : InternalBlock
{
    public int n = 1;
}