using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Firebase;
using Firebase.Auth;
using Google;

public class AuthWithGoogle : IAuthCustom
{
    private readonly FirebaseAuth _auth;
    private GoogleSignInConfiguration _configuration;

    public AuthWithGoogle(FirebaseAuth auth, string key)
    {
        _auth = auth;
        _configuration = new GoogleSignInConfiguration
        {
            WebClientId = key, //"531598773011-inhf44skdjt9nphjv5ghqtlafgdt57ri.apps.googleusercontent.com",
            RequestIdToken = true,
            RequestEmail = true
        };
    }

    public void CreateUser(string user, string pass, Action onSuccess, Action onFail)
    {
        
    }

    public void Login(string user, string pass, Action onSuccess, Action onFail)
    {
        OnSignIn();
    }
    
    
    private void OnSignIn()
    {
        GoogleSignIn.Configuration = _configuration;
        GoogleSignIn.Configuration.UseGameSignIn = false;
        GoogleSignIn.Configuration.RequestIdToken = true;
        
        GoogleSignIn.DefaultInstance.SignIn().ContinueWith(OnAuthenticationFinished);
    }


    private void OnAuthenticationFinished(Task<GoogleSignInUser> task)
    {
        if (task.IsFaulted)
        {
            using (IEnumerator<Exception> enumerator = task.Exception.InnerExceptions.GetEnumerator())
            {
                if (enumerator.MoveNext())
                {
                    GoogleSignIn.SignInException error = (GoogleSignIn.SignInException)enumerator.Current;
                    //AddToInformation("Got Error: " + error.Status + " " + error.Message);
                }
                else
                {
                    //AddToInformation("Got Unexpected Exception?!?" + task.Exception);
                }
            }
        }
        else if (task.IsCanceled)
        {
            //AddToInformation("Canceled");
        }
        else
        {
            //AddToInformation("Welcome: " + task.Result.DisplayName + "!");
            //AddToInformation("Email = " + task.Result.Email);
            //AddToInformation("Google ID Token = " + task.Result.IdToken);
            //AddToInformation("Email = " + task.Result.Email);
            SignInWithGoogleOnFirebase(task.Result.IdToken);
        }
    }

    private void SignInWithGoogleOnFirebase(string idToken)
    {
        Credential credential = GoogleAuthProvider.GetCredential(idToken, null);

        _auth.SignInWithCredentialAsync(credential).ContinueWith(task =>
        {
            var ex = task.Exception;
            if (ex?.InnerExceptions[0] is FirebaseException inner && inner.ErrorCode != 0)
            {
                //AddToInformation("\nError code = " + inner.ErrorCode + " Message = " + inner.Message);   
            }
        });
    }
}