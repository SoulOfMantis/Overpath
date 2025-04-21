using UnityEngine;
public class AlgorithmController : MonoBehaviour
{
    public CommandBlock[] commandBlocks;
    public CommandPanel[] commandPanels;
    public RobotController robotController;
    public TerminalUI myTerminal;
    public int CodeChanges = 0;
    public int Target;
    public Player player;
    private int currentLine = 0;

    void Start()
    {
        myTerminal.codeChangesCounter.text = $"0/{Target}";
    }
    public void ExecuteCurrentCommand()
    {
        if (currentLine >= commandBlocks.Length)
            currentLine = 0;
        commandBlocks[currentLine].Execute(ref currentLine, robotController);
    }
    
    public void SwapBlocksAndPanels(int indexA, int indexB)
    {
        (commandBlocks[indexA], commandBlocks[indexB]) = (commandBlocks[indexB], commandBlocks[indexA]);

        (commandPanels[indexA], commandPanels[indexB]) = (commandPanels[indexB], commandPanels[indexA]);

        commandPanels[indexA].BlockNumber = indexA;
        commandPanels[indexB].BlockNumber = indexB;
    }

    public bool ChangeOfAlgorithm()
    {
        if (CodeChanges < Target)
        {
            CodeChanges++;
            myTerminal.codeChangesCounter.text = $"{CodeChanges}/{Target}";
            return true;
        }
        else
        {
            myTerminal.gameObject.SetActive(false);
            return false;
        }
    }
}