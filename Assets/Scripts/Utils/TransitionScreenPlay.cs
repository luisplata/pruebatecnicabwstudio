using DG.Tweening;
using UnityEngine;

public class TransitionScreenPlay : MonoBehaviour
{
    [SerializeField] private RectTransform beginWaypoint, centerWaypoint, endWaypoint;
    [SerializeField] private float duration;
    private bool _finishedTransition;

    public void TransitionOn(ScreenPlay currentScreenPlay)
    {
        currentScreenPlay.gameObject.SetActive(true);
        // Obtener las posiciones iniciales y finales de los RectTransform
        Vector2 startPos = beginWaypoint.anchoredPosition;
        Vector2 endPos = centerWaypoint.anchoredPosition;

        // Posicionar inicialmente el objeto en la posición de inicio
        currentScreenPlay.GetComponent<RectTransform>().anchoredPosition = startPos;

        // Mover el RectTransform del punto de inicio al punto final durante 'duration' segundos con easing
        currentScreenPlay.GetComponent<RectTransform>().DOAnchorPos(endPos, duration).SetEase(Ease.OutQuad)
            .OnComplete(() => OnTransitionComplete(currentScreenPlay.gameObject));
    }
    
    private void OnTransitionComplete(GameObject currentScreenPlay)
    {
        _finishedTransition = true;
    }
    
    public bool IsFinish()
    {
        return _finishedTransition;
    }
    public void TransitionOff(ScreenPlay currentScreenPlay)
    {
        // Obtener las posiciones iniciales y finales de los RectTransform
        Vector2 startPos = centerWaypoint.anchoredPosition;
        Vector2 endPos = endWaypoint.anchoredPosition;

        // Posicionar inicialmente el objeto en la posición de inicio
        currentScreenPlay.GetComponent<RectTransform>().anchoredPosition = startPos;

        // Mover el RectTransform del punto de inicio al punto final durante 'duration' segundos con easing
        currentScreenPlay.GetComponent<RectTransform>().DOAnchorPos(endPos, duration).SetEase(Ease.OutQuad)
            .OnComplete(() => DeactivateObject(currentScreenPlay.gameObject));
    }

    private void DeactivateObject(GameObject obj)
    {
        obj.SetActive(false);
        _finishedTransition = true;
    }
}