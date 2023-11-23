using System.Collections.Generic;
using UnityEngine;

public class StatePattern : MonoBehaviour
{
    [SerializeField] private ScreenPlay[] screenPlays;
    [SerializeField] private ScreenPlayIdentity firstScreenPlay;
    private Dictionary<string, ScreenPlay> _screenPlays;
    private TeaTime _prepare, _doing, _finish;
    private ScreenPlay _currentScreenPlay;
    void Start()
    {
        _screenPlays = new Dictionary<string, ScreenPlay>();
        foreach (var screenPlay in screenPlays)
        {
            _screenPlays.Add(screenPlay.Id, screenPlay);
        }

        _currentScreenPlay = _screenPlays[firstScreenPlay.Id];
        
        _prepare = this.tt().Pause().Add(() =>
        {
            _currentScreenPlay.gameObject.SetActive(true);
            _currentScreenPlay.Config();
            _doing.Play();
        });
        
        _doing = this.tt().Pause().Add(() =>
        {
            _currentScreenPlay.Doing();
        }).Wait(()=>_currentScreenPlay.IsFinish(),0.1f).Add(() =>
        {
            _finish.Play();
                
        });
        
        _finish = this.tt().Pause().Add(() =>
        {
            _currentScreenPlay.ResetData();
            _currentScreenPlay.gameObject.SetActive(false);
            _currentScreenPlay = _screenPlays[_currentScreenPlay.NextScreenPlay().Id];
            _prepare.Restart();
        });
        
        _prepare.Play();
    }
}