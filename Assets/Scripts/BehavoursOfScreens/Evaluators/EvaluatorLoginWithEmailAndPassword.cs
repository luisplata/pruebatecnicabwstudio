using SL;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EvaluatorLoginWithEmailAndPassword : Evaluators
{
    [SerializeField] private Button button, showHidePasswordButton;
    [SerializeField] private TMP_InputField emailInputField;
    [SerializeField] private TMP_InputField passwordInputField;
    [SerializeField] private Sprite showPassword, hidePassword;
    private Image _imageShowHidePassword;

    public override void Config()
    {
        base.Config();
        button.onClick.AddListener(() =>
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
        ServiceLocator.Instance.GetService<IFireBaseService>().Login(email, pass, () =>
        {
            _isFinished = true;
            Debug.Log("Success Create User");
        },()=>
        {
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