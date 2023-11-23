using UnityEngine;

public class SelectOptionsElementsIntToDatesYear : SelectOptionsElementsInt
{
    [SerializeField] private int dateToStart, dateToEnd;
    protected override void OnEnable()
    {
        options = new int[dateToEnd - dateToStart + 1];
        for (int i = 0; i < options.Length; i++)
        {
            options[i] = dateToStart + i;
        }
        base.OnEnable();
    }
}