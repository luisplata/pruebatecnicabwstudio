using System;
using UnityEngine;
using UnityEngine.UI;

public class EvaluatorButtonSpecific : MonoBehaviour
{
    [SerializeField] private int option;
    [SerializeField] private Button button;
    [SerializeField] private Image image;
    [SerializeField] private Sprite spriteOn, spriteOff;
    public Action<int> onClick, onRelease;
    private EvaluatorWithOtherButtons _evaluatorWithOtherButtons;
    private bool _isPressed;

    private void Reset()
    {
        button = GetComponent<Button>();
        image = GetComponent<Image>();
    }

    private void OnEnable()
    {
        button.onClick.AddListener(() =>
        {
            if (_isPressed)
            {
                onRelease?.Invoke(option);
                _isPressed = false;
                image.sprite = spriteOff;
                return;
            }
            image.sprite = spriteOn;
            onClick?.Invoke(option);
            _isPressed = true;
        });
        image.sprite = spriteOff;
    }

    public void Config(EvaluatorWithOtherButtons evaluatorWithOtherButtons)
    {
        _evaluatorWithOtherButtons = evaluatorWithOtherButtons;
    }
}