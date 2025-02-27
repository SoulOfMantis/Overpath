using UnityEngine;
public class AlgorithmController : MonoBehaviour
{
    public CommandBlock[] commandBlocks;
    public RobotController robotController;
<<<<<<< Updated upstream:Overpath/Assets/scripts/AlgorithmController.cs
    Player player;
=======
    public Player player;
>>>>>>> Stashed changes:Overpath/Assets/AlgorithmController.cs
    private int currentLine = 0;

    void Start()
    {
<<<<<<< Updated upstream:Overpath/Assets/scripts/AlgorithmController.cs
        player = GameObject.FindWithTag("Player").GetComponent<Player>(); 
=======
>>>>>>> Stashed changes:Overpath/Assets/AlgorithmController.cs
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