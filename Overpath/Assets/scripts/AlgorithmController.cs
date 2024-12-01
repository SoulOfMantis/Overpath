using UnityEngine;
public class AlgorithmController : MonoBehaviour
{
    public CommandBlock[] commandBlocks;
    public RobotController robotController;
    Player player;
    private int currentLine = 0;

    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Player>(); 
    }
    public void ExecuteCurrentCommand()
    {
        if (currentLine < commandBlocks.Length)
            {
                commandBlocks[currentLine].Execute(ref currentLine, robotController);
            }
        player.MyTurn = true;
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