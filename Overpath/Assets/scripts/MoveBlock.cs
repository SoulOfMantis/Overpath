public class MoveBlock : IntBlock
{
    public override void Execute(ref int currentLine, RobotController robotController)
    {
        for (int i = 0; i < n; i++)
        {
            robotController.Step();
        }
        currentLine++;
    }
}