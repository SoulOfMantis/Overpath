public class RotateBlock : IntBlock
{    public override void Execute(ref int currentLine, RobotController robotController)
    {
        for (int i = 0; i < n; i++)
        {
            robotController.Rotate();
        }
        currentLine++;
    }
}