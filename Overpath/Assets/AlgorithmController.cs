using UnityEngine;
public class AlgorithmController : MonoBehaviour
{
    public CommandBlock[] commandBlocks;
    public RobotController robotController;
    public Player player;
    private int currentLine = 0;

    public void Update()
    {
    }
    public void ExecuteCurrentCommand()
    {
        if (currentLine < commandBlocks.Length)
        {
            commandBlocks[currentLine].Execute(ref currentLine, robotController);
            player.MyTurn = true;
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
