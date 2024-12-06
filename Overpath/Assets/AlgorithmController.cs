using UnityEngine;
public class AlgorithmController : MonoBehaviour
{
    public CommandBlock[] commandBlocks;
    public RobotController robotController;
    private int currentLine = 0;

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            if (currentLine < commandBlocks.Length)
            {
                commandBlocks[currentLine].Execute(ref currentLine, robotController);
            }
        }
    }

    public void UpdateBlockParameter(string blockName, int newValue)
    {
        foreach (var block in commandBlocks)
        {
            if (block.blockName == blockName)
            {
                if (block is MoveBlock moveBlock) moveBlock.n = newValue;
                if (block is RotateBlock rotateBlock) rotateBlock.n = newValue;
            }
        }
    }

    public void UpdateIfCondition(string blockName, bool newCondition)
    {
        foreach (var block in commandBlocks)
        {
            if (block.blockName == blockName && block is IfBlock ifBlock)
            {
                ifBlock.condition = newCondition;
            }
        }
    }
}