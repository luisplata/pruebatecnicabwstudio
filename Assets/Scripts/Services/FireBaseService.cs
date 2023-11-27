using System;
using Firebase;
using SL;
using UnityEngine;

public class FireBaseService : ServiceCustom, IFireBaseService
{
  private FirebaseApp _app;
  private Firebase.Auth.FirebaseAuth _auth;
  private IAuthCustom _authGoogle, _authEmailAndPassword;
  private bool _useGoogle;

  protected override bool Validation()
  {
    return FindObjectsOfType<FireBaseService>().Length > 1;
  }

  protected override void RegisterService()
  {
    ServiceLocator.Instance.RegisterService<IFireBaseService>(this);
    
    _auth = Firebase.Auth.FirebaseAuth.DefaultInstance;
    FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task =>
    {
      var dependencyStatus = task.Result;
      if (dependencyStatus == DependencyStatus.Available)
      {
        _app = FirebaseApp.DefaultInstance;
        //strategy pattern
        _authEmailAndPassword = new AuthWithEmailAndPassword(_auth);
        _authGoogle = new AuthWithGoogle(_auth, "531598773011-inhf44skdjt9nphjv5ghqtlafgdt57ri.apps.googleusercontent.com");
      }
      else
      {
        Debug.LogError(System.String.Format("Could not resolve all Firebase dependencies: {0}", dependencyStatus));
      }
    });
  }

  protected override void RemoveService()
  {
    ServiceLocator.Instance.RemoveService<IFireBaseService>();
  }

  public void CreateUser(string user, string pass, Action onSuccess, Action onFail)
  {
    if (_useGoogle)
      _authGoogle.CreateUser(user, pass, onSuccess, onFail);
    else
      _authEmailAndPassword.CreateUser(user, pass, onSuccess, onFail);
  }

  public void Login(string user, string pass, Action onSuccess, Action onFail)
  {
    if (_useGoogle)
      _authGoogle.Login(user, pass, onSuccess, onFail);
    else
      _authEmailAndPassword.Login(user, pass, onSuccess, onFail);
  }

  public void UseEmailAndPassword()
  {
    _useGoogle = false;
  }

  public void UseGoogle()
  {
    _useGoogle = true;    
  }
}