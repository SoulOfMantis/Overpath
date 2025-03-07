using UnityEngine;
public class AlgorithmController : MonoBehaviour
{
    public CommandBlock[] commandBlocks;
    public CommandPanel[] commandPanels;
    public RobotController robotController;
    public Player player;
    private int currentLine = 0;

    void Start()
    {
    }
    public void ExecuteCurrentCommand()
    {
        if (currentLine < commandBlocks.Length)
            {
                commandBlocks[currentLine].Execute(ref currentLine, robotController);
            }
        player.MyTurn = true;
    }
    
    public void SwapBlocksAndPanels(int indexA, int indexB)
    {
        (commandBlocks[indexA], commandBlocks[indexB]) = (commandBlocks[indexB], commandBlocks[indexA]);

        (commandPanels[indexA], commandPanels[indexB]) = (commandPanels[indexB], commandPanels[indexA]);

        commandPanels[indexA].BlockNumber = indexA;
        commandPanels[indexB].BlockNumber = indexB;
    }
}