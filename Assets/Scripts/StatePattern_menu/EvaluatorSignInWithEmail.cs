using SL;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EvaluatorSignInWithEmail : Evaluators
{
    [SerializeField] private Button signInButton;
    [SerializeField] private TMP_InputField emailInputField;
    [SerializeField] private TMP_InputField passwordInputField;

    public override void Config()
    {
        base.Config();
        signInButton.onClick.AddListener(() =>
        {
            StartSignIn(emailInputField.text, passwordInputField.text);
        });
    }

    private void StartSignIn(string email, string pass)
    {
        ServiceLocator.Instance.GetService<IFireBaseService>().CreateUser(email, pass, () =>
        {
            _isFinished = true;
            Debug.Log("Success");
        },()=>
        {
            Debug.Log("Error");
        });
    }
}