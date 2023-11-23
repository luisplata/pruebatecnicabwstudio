using UnityEngine;

public class EvaluatorWithOtherButtons : EvaluatorsWithButton
{
    [SerializeField] private EvaluatorButtonSpecific[] buttons;
    private int _option;
    public int Option => _option;

    private void OnEnable()
    {
        foreach (var button in buttons)
        {
            button.onClick += option =>
            {
                _option = option;
                _isFinished = true;
            };
        }
    }

    public override string GetData()
    {
        return Option.ToString();
    }
}