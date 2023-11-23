using UnityEngine;

public class EvaluatorToListOfOptions : EvaluatorsWithButton
{
    [SerializeField] private SelectOptionsElements optionsElementsInt;
    private string _option;

    public override void Config()
    {
        base.Config();
        optionsElementsInt.onValueChanged += option =>
        {
            Debug.Log($"option selected in action: {option}");
            _option = option;
            _isFinished = true;
        };
        optionsElementsInt.Config();
    }

    public override string GetData()
    {
        return _option;
    }
}