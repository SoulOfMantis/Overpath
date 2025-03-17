public class GotoBlock : CommandBlock
{
    public int jumpToLine = 0;

    public override void Execute(ref int currentLine, RobotController robotController)
    {
        currentLine = jumpToLine;
    }
}