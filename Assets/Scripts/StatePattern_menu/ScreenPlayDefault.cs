using UnityEngine;

public class ScreenPlayDefault : ScreenPlay
{
    public override void Doing()
    {
        Debug.Log($"Doing {gameObject.name}");
    }
}