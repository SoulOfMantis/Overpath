public class MoveBlock : CommandBlock
{
    public int n = 1;

    public override void Execute(ref int currentLine, RobotController robotController)
    {
        for (int i = 0; i < n; i++)
        {
            robotController.Step();
        }
        currentLine++;
    }
}