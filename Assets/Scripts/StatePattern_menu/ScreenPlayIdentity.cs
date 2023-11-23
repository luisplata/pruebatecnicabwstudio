using System;
using UnityEngine;

[CreateAssetMenu(fileName = "ScreenPlayIdentity", menuName = "Menu/StatePattern/ScreenPlayIdentity")]
public class ScreenPlayIdentity : ScriptableObject 
{
    private void OnEnable()
    {
        _id = $"menu_{Guid.NewGuid().ToString()}";
    }

    [SerializeField] private string _id;
    public string Id => _id;
}