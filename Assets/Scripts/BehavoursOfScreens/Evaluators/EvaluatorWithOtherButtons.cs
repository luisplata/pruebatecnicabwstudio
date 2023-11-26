using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class EvaluatorWithOtherButtons : EvaluatorsWithButton
{
    [SerializeField] private EvaluatorButtonSpecific[] buttons;
    [SerializeField] private int minOption, maxOption;
    private int _optionsSelected;
    private List<int> _option;
    public List<int> Option => _option;

    private void OnEnable()
    {
        _option = new List<int>();
        foreach (var button in buttons)
        {
            button.onClick += option =>
            {
                _option.Add(option);
                _optionsSelected++;
                ClickInternal();
            };
            button.onRelease += option =>
            {
                _option.Remove(option);
                _optionsSelected--;
                ClickInternal();
            };
            button.Config(this);
        }
    }

    private void ClickInternal()
    {
        if (_optionsSelected <= maxOption && _optionsSelected >= minOption)
        {
            _isFinished = true;
            BounceAnimation();
        }
        else
        {
            _isFinished = false;
            _wasFinished = false;
        }
    }

    public override string GetData()
    {
        return Option.ToString();
    }

    public bool CanClick()
    {
        return _isFinished;
    }
    
}