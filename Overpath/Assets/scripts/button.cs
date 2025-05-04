using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PressureButton : MonoBehaviour
{
    public Vector3Int buttonPosition;
    public Tilemap tilemap;
    private Animator animator;
    public List<Barrier> State1Objects; // Активны по умолчанию
    public List<Barrier> State2Objects; // Активны при нажатии

    public List<Vector3Int> State1Positions; // Координаты блокирующих клеток для состояния 1
    public List<Vector3Int> State2Positions; // Координаты для состояния 2

    private bool isPressed = false;

    void Start()
    {
        animator = GetComponent<Animator>();
        buttonPosition = tilemap.WorldToCell(transform.position);
        transform.position = tilemap.GetCellCenterWorld(buttonPosition);
        Actor.allButtons.Add(this);

        foreach (var obj in State1Objects)
        {
            State1Positions.Add(tilemap.WorldToCell(obj.transform.position));
            obj.SetBarrier(true);
        }

        foreach (var obj in State2Objects)
        {
            State2Positions.Add(tilemap.WorldToCell(obj.transform.position));
            obj.SetBarrier(false);
        }

        foreach (var pos in State1Positions)
        Obstacle.Add(pos);

        EvaluateButton();
        
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
        UpdateButton(isPressed);
    }

    private void UpdateState()
    {
        if (isPressed)
        {
            // Переключаем визуальные объекты
            foreach (var obj in State1Objects) obj.SetBarrier(false);
            foreach (var obj in State2Objects) obj.SetBarrier(true);

            // Обновляем препятствия
            foreach (var pos in State1Positions) Obstacle.Remove(pos);
            foreach (var pos in State2Positions) 
            {
                Obstacle.Add(pos);
                foreach (var actor in Actor.AllActors)
                if (actor.currentGridPosition == pos)
                    actor.Death();
            }
        }
        else
        {
            foreach (var obj in State1Objects) obj.SetBarrier(true);
            foreach (var obj in State2Objects) obj.SetBarrier(false);

            foreach (var pos in State2Positions) Obstacle.Remove(pos);
            foreach (var pos in State1Positions) 
            {
                Obstacle.Add(pos);
                foreach (var actor in Actor.AllActors)
                if (actor.currentGridPosition == pos)
                    actor.Death();
            }
        }
    }

    public void UpdateButton(bool button)
    {
        animator.SetBool("ButtonControl", button);
    }
}
