using TMPro;
using UnityEngine;

public class SelectionOfProfileData : Evaluators
{ 
    [SerializeField] private EvaluatorsWithColorButton colorButton;
    [SerializeField] private TMP_InputField inputField;
    private bool _changeNickname;

    private void OnEnable()
    {
        inputField.onEndEdit.AddListener(value =>
        {
            _changeNickname = value.Length > 0;
        });
    }

    public override bool IsFinished()
    {
        return colorButton.IsFinished() && (_changeNickname || inputField.text.Length > 0);
    }

    public override string GetData()
    {
        return $"{colorButton.GetData()},{inputField.text}";
    }
}