using System;

public interface IAuthCustom
{
    void CreateUser(string user, string pass, Action onSuccess, Action onFail);
    void Login(string user, string pass, Action onSuccess, Action onFail);
}