using System;
using UnityEngine;
using UnityEngine.UI;

public class EvaluatorButtonSpecific : MonoBehaviour
{
    [SerializeField] private int option;
    [SerializeField] private Button button;

    private void Reset()
    {
        button = GetComponent<Button>();
    }

    private void OnEnable()
    {
        button.onClick.AddListener(() =>
        {
            onClick?.Invoke(option);
        });
    }
    public Action<int> onClick;
}