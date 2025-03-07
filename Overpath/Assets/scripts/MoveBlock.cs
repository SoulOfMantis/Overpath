<<<<<<< Updated upstream:Overpath/Assets/scripts/MoveBlock.cs
public class MoveBlock : IntBlock
=======
public class MoveBlock : IntCommandBlock
>>>>>>> Stashed changes:Overpath/Assets/MoveBlock.cs
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