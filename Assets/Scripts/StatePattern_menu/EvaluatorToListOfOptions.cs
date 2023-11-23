using UnityEngine;

public class EvaluatorToListOfOptions : EvaluatorsWithButton
{
    [SerializeField] private SelectOptionsElements optionsElementsInt;
    private string _option;

    private void OnEnable()
    {
        optionsElementsInt.onValueChanged += option =>
        {
            _option = option;
            _isFinished = true;
        };
    }

    public override string GetData()
    {
        return _option.ToString();
    }
}