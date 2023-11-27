using System;
using UnityEngine;
using UnityEngine.UI;

public class EvaluatorButtonColor : MonoBehaviour
{
    [SerializeField] private Color option;
    [SerializeField] private Button button;
    [SerializeField] private Image image;
    public Action<Color> onClick;

    private void Reset()
    {
        button = GetComponent<Button>();
        image = GetComponent<Image>();
    }

    private void OnEnable()
    {
        button.onClick.AddListener(() =>
        {
            onClick?.Invoke(option);
        });
        image.color = option;
    }
}