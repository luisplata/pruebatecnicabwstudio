using UnityEngine;
using UnityEngine.UI;

public class EvaluatorsWithButton : Evaluators
{
    [SerializeField] private Button button;
    private void OnEnable()
    {
        button.onClick.AddListener(() =>
        {
            _isFinished = true;
        });
    }
}