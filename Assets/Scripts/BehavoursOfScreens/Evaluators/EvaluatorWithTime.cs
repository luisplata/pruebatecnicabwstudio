using System.Collections;
using UnityEngine;

public class EvaluatorWithTime : Evaluators
{
    [SerializeField] private float timeToWait;
    private void OnEnable()
    {
        StartCoroutine(CountDown());
    }

    private IEnumerator CountDown()
    {
        yield return new WaitForSeconds(timeToWait);
        _isFinished = true;
    }

}