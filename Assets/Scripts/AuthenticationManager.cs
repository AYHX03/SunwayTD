using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Services.Core;
using Unity.Services.Authentication;
using System.Threading.Tasks;
using TMPro;
using System;
using UnityEditor.SearchService;
using UnityEngine.SceneManagement;

public class AuthenticationManager : MonoBehaviour
{

    [SerializeField] private GameObject signInDisplay = default;
    [SerializeField] private TMP_InputField usernameInput= default;
    [SerializeField] private TMP_InputField passwordInput = default;
    [SerializeField] private TextMeshProUGUI errorMessageText = default;
    public float displayErrorDuration = 5f;
    // Start is called before the first frame update
    async void Start()
    {
        await UnityServices.InitializeAsync();
        bool isSignedIn = AuthenticationService.Instance.IsSignedIn;
        if (isSignedIn)
        {
            signInDisplay.SetActive(false);                                                
        }
    }

    public async void Create()
    {
        string usernameText = usernameInput.text;
        string passwordText = passwordInput.text;
        await SignUpWithUsernameAndPassword(usernameText, passwordText);
    }

    public async void SignIn()
    {
        string usernameText = usernameInput.text;
        string passwordText = passwordInput.text;
        await SignInWithUsernameAndPassword(usernameText, passwordText);
     
    }
    async Task SignUpWithUsernameAndPassword(string username, string password)
    {
        try
        {
            await AuthenticationService.Instance.SignUpWithUsernamePasswordAsync(username, password);
            Debug.Log("Sign up Successful");
        }
        catch (AuthenticationException ex)
        {
            ShowErrorMessage(ex.Message);
        }
        catch (RequestFailedException ex)
        {
            ShowErrorMessage(ex.Message);
        }
    }
    async Task SignInWithUsernameAndPassword(string username, string password)
    {
        try
        {
            await AuthenticationService.Instance.SignInWithUsernamePasswordAsync(username, password);
            Debug.Log("Sign In Successful");
            /*SceneManager.LoadScene("MainMenu");*/
            SceneManager.LoadScene("LevelSelection");
        }
        catch (AuthenticationException ex)
        {
            ShowErrorMessage(ex.Message);
        }
        catch (RequestFailedException ex)
        {
            ShowErrorMessage(ex.Message);
        }
    }

    public void ShowErrorMessage(string message)
    {
        errorMessageText.text =message;
        errorMessageText.gameObject.SetActive(true);
        Invoke("HideErrorMessage", displayErrorDuration);
    }

    private void HideErrorMessage()
    {
        errorMessageText.gameObject.SetActive(false);
    }
}
