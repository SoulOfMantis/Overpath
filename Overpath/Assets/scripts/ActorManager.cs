using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ActorManager : MonoBehaviour
{
    public static ActorManager Instance;
    public Tilemap tilemap;

    public List<PressureButton> allButtons = new List<PressureButton>();

    void Awake() => Instance = this;
}
