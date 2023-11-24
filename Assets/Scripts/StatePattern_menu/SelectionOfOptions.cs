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
            if(_currentEvaluator == null)
            {
                //Debug.Log($"Select any option");
                return;
            }
            _isFinished = true;
            Debug.Log($"option selected: {_currentEvaluator.GetData()}");
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