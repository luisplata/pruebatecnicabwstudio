using UnityEngine;

public abstract class ScreenPlay : MonoBehaviour
{
    [SerializeField] private ScreenPlayIdentity _id;
    [SerializeField] protected Evaluators[] evaluators;
    protected ScreenPlayIdentity _nextScreenPlay;
    protected Evaluators _currentEvaluator;

    private void Reset()
    {
        var evas =GetComponents<Evaluators>();
        if (evas.Length > 0)
        {
            evaluators = evas;
        }
    }

    public virtual void Config()
    {
        
    }

    public abstract void Doing();

    public virtual bool IsFinish()
    {
        foreach (var eva in evaluators)
        {
            if (eva.IsFinished())
            {
                _nextScreenPlay = eva.NextScreenPlay();
                _currentEvaluator = eva;
                return true;
            }
        }

        return false;
    }

    public string Id => _id.Id;

    public virtual void ResetData()
    {
        
    }

    public ScreenPlayIdentity NextScreenPlay()
    {
        return _nextScreenPlay;
    }
}