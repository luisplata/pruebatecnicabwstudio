using System.Collections.Generic;
using UnityEngine;

public class StatePattern : MonoBehaviour
{
    [SerializeField] private ScreenPlay[] screenPlays;
    [SerializeField] private ScreenPlayIdentity firstScreenPlay;
    [SerializeField] private TransitionScreenPlay transitionScreenPlay;
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
                transitionScreenPlay.TransitionOn(_currentScreenPlay);
                _currentScreenPlay.Config();
            })
            .Wait(() => transitionScreenPlay.IsFinish(), 0.1f)
            .Add(() =>
            {
                _currentScreenPlay.Doing();
                _doing.Play();
            });

        _doing = this.tt().Pause().Add(() => { _currentScreenPlay.Doing(); })
            .Wait(() => _currentScreenPlay.IsFinish(), 0.1f)
            .Add(() => { _finish.Play(); });

        _finish = this.tt().Pause()
            .Add(() =>
            {
                transitionScreenPlay.TransitionOff(_currentScreenPlay);
            })
            .Wait(() => transitionScreenPlay.IsFinish())
            .Add(() =>
            {
                _currentScreenPlay = _screenPlays[_currentScreenPlay.NextScreenPlay().Id];
                _currentScreenPlay.ResetData();
                _prepare.Restart();
            });

        _prepare.Play();
    }
}