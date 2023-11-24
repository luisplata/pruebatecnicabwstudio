using UnityEngine;

public abstract class Evaluators : MonoBehaviour
{
    [SerializeField] protected ScreenPlayIdentity nextScreenPlay;
    [SerializeField] protected bool _isFinished;

    public virtual bool IsFinished()
    {
        return _isFinished;
    }
    public virtual ScreenPlayIdentity NextScreenPlay()
    {
        return nextScreenPlay;
    }

    public virtual string GetData()
    {
        return nextScreenPlay.Id;
    }

    public virtual void Config()
    {
        
    }

    public void ResetData()
    {
        _isFinished = false;
    }
}