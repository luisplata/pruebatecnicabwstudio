using System;
using Firebase.Auth;
using UnityEngine;

public class AuthWithEmailAndPassword : IAuthCustom
{
    private readonly FirebaseAuth _auth;

    public AuthWithEmailAndPassword(FirebaseAuth auth)
    {
        _auth = auth;
    }

    public void Login(string user, string pass, Action onSuccess, Action onFail)
    {
        _auth.SignInWithEmailAndPasswordAsync(user, pass).ContinueWith(task => {
            if (task.IsCanceled || task.IsFaulted) {
                Debug.LogError("error: " + task.Exception);
                onFail?.Invoke();
                return;
            }

            var result = task.Result;
            Debug.LogFormat("User signed in successfully: {0} ({1})",
                result.User.DisplayName, result.User.UserId);
            onSuccess?.Invoke();
        });
    }

    public void CreateUser(string user, string pass, Action onSuccess, Action onFail)
    {
        _auth.CreateUserWithEmailAndPasswordAsync(user, pass).ContinueWith(task => {
            if (task.IsCanceled || task.IsFaulted) {
                Debug.LogError("error: " + task.Exception);
                onFail?.Invoke();
                return;
            }

            // Firebase user has been created.
            var result = task.Result;
            Debug.LogFormat("Firebase user created successfully: {0} ({1})",
                result.User.DisplayName, result.User.UserId);
            onSuccess?.Invoke();
        });
    }
}