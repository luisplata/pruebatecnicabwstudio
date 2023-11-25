﻿using UnityEngine;
using UnityEngine.UI;

public class EvaluatorsWithColorButton : EvaluatorsWithButton
{
    [SerializeField] private EvaluatorButtonColor[] buttons;
    [SerializeField] private Image colorSelected;
    private Color _option;
    public Color Option => _option;

    private void OnEnable()
    {
        foreach (var button in buttons)
        {
            button.onClick += option =>
            {
                _option = option;
                colorSelected.color = option;
                _isFinished = true;
            };
        }
    }

    public override string GetData()
    {
        return Option.ToString();
    }
}