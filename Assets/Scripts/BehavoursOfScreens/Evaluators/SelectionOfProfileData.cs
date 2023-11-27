using TMPro;
using UnityEngine;

public class SelectionOfProfileData : EvaluatorsWithButton
{ 
    [SerializeField] private EvaluatorsWithColorButton colorButton;
    [SerializeField] private TMP_InputField inputField;
    private bool _changeNickname;

    private void OnEnable()
    {
        inputField.onEndEdit.AddListener(value =>
        {
            _changeNickname = value.Length > 0;
            if (_changeNickname && colorButton.IsFinished())
            {
                BounceAnimation();
            }
            else
            {
                _wasFinished = false;
            }
        });
        colorButton.onClick += () =>
        {
            if (_changeNickname && colorButton.IsFinished())
            {
                BounceAnimation();
            }
            else
            {
                _wasFinished = false;
            }
        };
    }

    public override bool IsFinished()
    {
        return colorButton.IsFinished() && (_changeNickname || inputField.text.Length > 0);
    }

    public override string GetData()
    {
        return $"{colorButton.GetData()},{inputField.text}";
    }

    public override void ResetData()
    {
        base.ResetData();
        inputField.text = "";
        colorButton.ResetData();
        _changeNickname = false;
    }
}