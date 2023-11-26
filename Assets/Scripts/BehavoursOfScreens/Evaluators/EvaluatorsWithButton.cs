using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class EvaluatorsWithButton : Evaluators
{
    [SerializeField] protected Button button;
    protected bool _wasFinished;
    private void OnEnable()
    {
        button.onClick.AddListener(() =>
        {
            _isFinished = true;
        });
    }
    protected void BounceAnimation()
    {
        if(_wasFinished)
            return;
        Debug.Log($"BounceAnimation {gameObject.name}");
        button.transform.DOScale(new Vector3(1.2f, 1.2f, 1.2f), 0.5f) // Escala aumentada en 20%
            .SetEase(Ease.OutElastic) // Efecto de rebote
            .OnComplete(() =>
            {
                button.transform.DOScale(Vector3.one, 0.3f); // Escala vuelve a su tamaño original
            });
        _wasFinished = true;
    }
}