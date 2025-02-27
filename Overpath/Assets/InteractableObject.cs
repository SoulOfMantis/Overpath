using UnityEngine;
using UnityEngine.Tilemaps;

public abstract class InteractableObject : MonoBehaviour
{
    public Tilemap tilemap;
    public abstract void Interacted();
}