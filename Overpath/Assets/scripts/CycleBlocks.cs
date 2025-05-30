using UnityEditor;

public class LoopBlock : InternalIntBlock
{
    int i = 0;

    public override void Execute(ref int currentLine, RobotController robotController)
    {
        ExecuteNestedBlocks(ref currentLine, robotController);
        i++;
        
        if (i == n)
        {
            i = 0;
            currentLine++;
        }        
    }
}

//WIP
// public class WhileBlock : InternalBlock
// {
//     public bool CheckCondition(ref int currentLine, RobotController robotController)
//     {
//         //Implement
//     }

//     public override void Execute(ref currentLine, robotController)
//     {
//         if (CheckCondition(ref int currentLine, RobotController robotController))
//             ExecuteNestedBlocks(ref int currentLine, RobotController robotController);
//         else currentLine++;
//     }
// }