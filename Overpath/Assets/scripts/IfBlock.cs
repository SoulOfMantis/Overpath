using UnityEngine;
using UnityEngine.UI;
public class IfBlock : InternalBlock
{
    public Dropdown Sign;
    public Dropdown Object;
    public bool condition;

    public override void Execute(ref int currentLine, RobotController robotController)
    {
    Vector3Int SearchedPosition = robotController.currentGridPosition + robotController.direction;   
    switch (Object.captionText.text)
    {
        case "Obstacle":
        {
            condition = !robotController.IsValidMove(SearchedPosition);
            break;
        }
        
        case "Wall":
        {
            condition = robotController.tilemap.HasTile(SearchedPosition);
            break;
        }

        case "Object":
        {
            condition = Obstacle.IsBlocked(SearchedPosition);
            break;
        }
        
        case "Creature":
        {
            condition = false;
            
            foreach (var actor in Actor.AllActors)
            {
                if (actor.currentGridPosition == SearchedPosition)
                {
                    condition = true;
                    break;
                }
            }
            break;
        }
        // case "Человек":
        // {
        //     condition = ;
        //     break;
        // }

        // case "Робот":
        // {
        //     condition = ;
        //     break;
        // }
    }
    
    switch (Sign.captionText.text)
    {
        case "!=":
        {
            condition = !condition;
            break;
        }
    }

    if (condition)
        ExecuteNestedBlocks(ref currentLine, robotController);

    currentLine++;
    }
}