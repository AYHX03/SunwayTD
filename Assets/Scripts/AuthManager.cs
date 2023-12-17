using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Services.Core;
using Unity.Services.Authentication;
using System.Threading.Tasks;
using UnityEngine.UI;
using UnityEditor.SearchService;
using UnityEngine.SceneManagement;
using TMPro;
using Unity.VisualScripting;

public class AuthManager : MonoBehaviour
{
    //public Text logTxt;
    [SerializeField] GameObject emailUI;
    [SerializeField] GameObject passwordUI;

    async void Start()
    {
        await UnityServices.InitializeAsync();

       
 
    }

    // register button
    public async void Register()
    {
        string email = emailUI.GetComponent<TMP_InputField>().text;
        string password = passwordUI.GetComponent<TMP_InputField>().text;
        print("email: " + email);
        print("password: " + password);

        if (!string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(password))
        {
            await SignUpWithUsernamePassword(email, password);
        }

        if (string.IsNullOrEmpty(email)) 
        {
            print("email is empty!");
        }

        if (string.IsNullOrEmpty(password))
        {
            print("password is empty!");
        }


    }

    // sign in button
    public async void SignIn()
    {
        string email = emailUI.GetComponent<TMP_InputField>().text;
        string password = passwordUI.GetComponent<TMP_InputField>().text;
        await SignInWithUsernamePasswordAsync(email, password);
    }

    // sign in anonmymously
    public async void SignInAnonymous()
    {
        await SignInAnonymouslyAsync();
    }


    // to sign in anonymously (without login credentials)
    public async Task SignInAnonymouslyAsync()
    {
        try {
            await AuthenticationService.Instance.SignInAnonymouslyAsync();
            print("Sign In Anonymously Sucess!");
            print("Player Id: " + AuthenticationService.Instance.PlayerId);
            //logTxt.text = "Player id: " + AuthenticationService.Instance.PlayerId;
            SceneManager.LoadScene("MainMenu");
        }
        catch(AuthenticationException ex) {
            print("Sign in failed!");
            Debug.LogException(ex);
        }
        
    }

    public async Task SignUpWithUsernamePassword(string username, string password)
    {
        try
        {
            await AuthenticationService.Instance.SignUpWithUsernamePasswordAsync(username, password);
            Debug.Log("SignUp is successful.");
            SceneManager.LoadScene("Login");
        }
        catch (AuthenticationException ex)
        {
            // Compare error code to AuthenticationErrorCodes
            // Notify the player with the proper error message
            Debug.LogException(ex);
        }
        catch (RequestFailedException ex)
        {
            // Compare error code to CommonErrorCodes
            // Notify the player with the proper error message
            Debug.LogException(ex);
        }
    }

    async Task SignInWithUsernamePasswordAsync(string username, string password)
    {
        try
        {
            await AuthenticationService.Instance.SignInWithUsernamePasswordAsync(username, password);
            Debug.Log("SignIn is successful.");
            print("Player Id: " + AuthenticationService.Instance.PlayerId);
            //logTxt.text = "Player id: " + AuthenticationService.Instance.PlayerId;
            SceneManager.LoadScene("MainMenu");
        }
        catch (AuthenticationException ex)
        {
            // Compare error code to AuthenticationErrorCodes
            // Notify the player with the proper error message
            Debug.LogException(ex);
        }
        catch (RequestFailedException ex)
        {
            // Compare error code to CommonErrorCodes
            // Notify the player with the proper error message
            Debug.LogException(ex);
        }
    }
}
