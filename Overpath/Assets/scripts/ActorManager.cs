public bool IsValidPosition(Vector3Int position)
{
    return !Actor.AllActors.ContainsKey(position) && 
           !Obstacle.AllObstaclePositions.Contains(position) &&
           !tilemap.HasTile(position);
}


using UnityEngine;
using System.Collections.Generic;

public class PressureButton : MonoBehaviour
{
    public List<GameObject> State1Objects;
    public List<GameObject> State2Objects;

    public List<Vector3Int> State1Positions;
    public List<Vector3Int> State2Positions;

    private bool isPressed = false;

    void Update()
    {
        bool newState = false;

        foreach (var actor in Actor.AllActors.Values)
        {
            if (ActorManager.Instance.tilemap.WorldToCell(actor.transform.position) == 
                ActorManager.Instance.tilemap.WorldToCell(transform.position))
            {
                newState = true;
                break;
            }
        }

        if (newState != isPressed)
        {
            isPressed = newState;
            UpdateBarrierState();
        }
    }

    void UpdateBarrierState()
    {
        if (isPressed)
        {
            foreach (var obj in State1Objects)
                obj.SetActive(false);
            foreach (var obj in State2Objects)
                obj.SetActive(true);

            foreach (var pos in State1Positions)
                Obstacle.RemoveObstacle(pos);
            foreach (var pos in State2Positions)
                Obstacle.AddObstacle(pos);
        }
        else
        {
            foreach (var obj in State1Objects)
                obj.SetActive(true);
            foreach (var obj in State2Objects)
                obj.SetActive(false);

            foreach (var pos in State2Positions)
                Obstacle.RemoveObstacle(pos);
            foreach (var pos in State1Positions)
                Obstacle.AddObstacle(pos);
        }
    }
}
