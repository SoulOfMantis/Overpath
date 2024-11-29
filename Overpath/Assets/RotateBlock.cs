public class RotateBlock : CommandBlock
{
    public int n = 1;

    public override void Execute(ref int currentLine, RobotController robotController)
    {
        for (int i = 0; i < n; i++)
        {
            robotController.Rotate();
        }
        currentLine++;
    }
}