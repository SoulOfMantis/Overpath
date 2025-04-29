using System.Collections.Generic;
using UnityEngine;

public class PressureButton : MonoBehaviour
{
    public Vector3Int buttonPosition;

    public List<GameObject> State1Objects; // Активны по умолчанию
    public List<GameObject> State2Objects; // Активны при нажатии

    public List<Vector3Int> State1Positions; // Координаты блокирующих клеток для состояния 1
    public List<Vector3Int> State2Positions; // Координаты для состояния 2

    private bool isPressed = false;

    void Start()
    {
        buttonPosition = ActorManager.Instance.tilemap.WorldToCell(transform.position);
        ActorManager.Instance.allButtons.Add(this);
    }

    public void EvaluateButton()
    {
        bool pressedNow = false;

        foreach (var actor in Actor.AllActors)
        {
            if (actor.currentGridPosition == buttonPosition)
            {
                pressedNow = true;
                break;
            }
        }

        if (pressedNow != isPressed)
        {
            isPressed = pressedNow;
            UpdateState();
        }
    }

    private void UpdateState()
    {
        if (isPressed)
        {
            // Переключаем визуальные объекты
            foreach (var obj in State1Objects) obj.SetActive(false);
            foreach (var obj in State2Objects) obj.SetActive(true);

            // Обновляем препятствия
            foreach (var pos in State1Positions) Obstacle.Remove(pos);
            foreach (var pos in State2Positions) Obstacle.Add(pos);
        }
        else
        {
            foreach (var obj in State1Objects) obj.SetActive(true);
            foreach (var obj in State2Objects) obj.SetActive(false);

            foreach (var pos in State2Positions) Obstacle.Remove(pos);
            foreach (var pos in State1Positions) Obstacle.Add(pos);
        }
    }
}
