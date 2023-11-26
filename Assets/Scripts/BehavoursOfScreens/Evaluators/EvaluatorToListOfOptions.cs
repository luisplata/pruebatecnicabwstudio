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
            _option = option;
            _isFinished = true;
            BounceAnimation();
            _wasFinished = false;
        };
        optionsElementsInt.Config();
    }

    public override string GetData()
    {
        return _option;
    }
}