using System;

public interface IFireBaseService
{
    void CreateUser(string user, string pass, Action onSuccess, Action onFail);
    void Login(string user, string pass, Action onSuccess, Action onFail);

    void UseEmailAndPassword();
    void UseGoogle();
}