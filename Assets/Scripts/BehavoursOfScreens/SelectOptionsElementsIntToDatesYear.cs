using UnityEngine;

public class SelectOptionsElementsIntToDatesYear : SelectOptionsElementsInt
{
    [SerializeField] private int dateToStart;
    private int dateToEnd;

    public override void Config()
    {
        dateToEnd = System.DateTime.Now.Year;
        options = new int[dateToEnd - dateToStart + 1];
        for (int i = 0; i < options.Length; i++)
        {
            options[i] = dateToStart + i;
        }
        base.Config();
    }
}