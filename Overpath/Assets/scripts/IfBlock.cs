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
        case "Препятствие":
        {
            condition = !robotController.IsValidMove(SearchedPosition);
            break;
        }
        
        case "Объект":
        {
            condition = robotController.tilemap.HasTile(SearchedPosition);
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