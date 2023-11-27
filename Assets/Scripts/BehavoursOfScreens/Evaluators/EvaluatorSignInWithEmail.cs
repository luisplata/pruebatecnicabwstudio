using SL;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EvaluatorSignInWithEmail : Evaluators
{
    [SerializeField] private Button signInButton, showHidePasswordButton;
    [SerializeField] private TMP_InputField emailInputField;
    [SerializeField] private TMP_InputField passwordInputField;
    [SerializeField] private Sprite showPassword, hidePassword;
    [SerializeField] private ScreenPlayIdentity onFailLogin;
    private Image _imageShowHidePassword;

    public override void Config()
    {
        base.Config();
        signInButton.onClick.AddListener(() =>
        {
            StartSignIn(emailInputField.text, passwordInputField.text);
        });
        showHidePasswordButton.onClick.AddListener(() =>
        {
            ShowPassword(passwordInputField.contentType == TMP_InputField.ContentType.Password);
        });
        _imageShowHidePassword = showHidePasswordButton.GetComponent<Image>();
        _imageShowHidePassword.sprite = showPassword;
    }

    private void StartSignIn(string email, string pass)
    {
        
        Debug.Log("Contraseña ingresada: " + pass);
        ServiceLocator.Instance.GetService<IFireBaseService>().CreateUser(email, pass, () =>
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
    
    private void ShowPassword(bool show)
    {
        passwordInputField.contentType = show ? TMP_InputField.ContentType.Standard : TMP_InputField.ContentType.Password;
        passwordInputField.ForceLabelUpdate();
        _imageShowHidePassword.sprite = show ? hidePassword : showPassword;
    }
}