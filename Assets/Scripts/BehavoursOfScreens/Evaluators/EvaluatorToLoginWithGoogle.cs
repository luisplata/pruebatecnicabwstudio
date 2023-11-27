using SL;
using UnityEngine;
using UnityEngine.UI;

public class EvaluatorToLoginWithGoogle : Evaluators
{
    [SerializeField] private Button signInButton;
    [SerializeField] private ScreenPlayIdentity onFailLogin;
    public override void Config()
    {
        base.Config();
        signInButton.onClick.AddListener(() =>
        {
            StartSignIn("login", "google");
        });
    }

    private void StartSignIn(string email, string pass)
    {
        ServiceLocator.Instance.GetService<IFireBaseService>().UseGoogle();
        ServiceLocator.Instance.GetService<IFireBaseService>().Login(email, pass, () =>
        {
            _isFinished = true;
            Debug.Log("Success Create User");
        },()=>
        {
            _isFinished = true;
            nextScreenPlay = onFailLogin;
            Debug.Log("Error Create User");
        });
    }
}