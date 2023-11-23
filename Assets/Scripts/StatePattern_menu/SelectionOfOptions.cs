using UnityEngine;
using UnityEngine.UI;

public class SelectionOfOptions : ScreenPlay
{
    [SerializeField] private Button button;
    private bool _isFinished;
    
    private void OnEnable()
    {
        button.onClick.AddListener(() =>
        {
            _isFinished = true;
            Debug.Log($"option selected: {(_currentEvaluator != null ? _currentEvaluator.GetData() : "None")}");
        });
    }

    public override void Doing()
    {
        
    }

    public override bool IsFinish()
    {
        base.IsFinish();
        return _isFinished;
    }
}