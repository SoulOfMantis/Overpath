using UnityEngine;
using UnityEngine.UI;
public class IfBlock : CommandBlock
{
    // public Dropdown Direction;
    // public Dropdown Sign;
    // public Dropdown Object;
    public bool condition;
    public int jumpToLine = 3;

    public override void Execute(ref int currentLine, RobotController robotController)
    {
        Vector3Int nextPosition = robotController.currentGridPosition + robotController.direction;
        condition = !robotController.IsValidMove(nextPosition);

        if (condition)
        {
            currentLine++;
        }
        else
        {
            currentLine = jumpToLine;
        }
    }
}