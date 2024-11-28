using UnityEngine;
using Firebase;
using Firebase.Auth;
using UnityEngine.UI;
using Firebase.Extensions;
using System.Collections;
using UnityEngine.SceneManagement;
using System;
public class FirebaseAuthManager : MonoBehaviour
{
    [Header("Firebase")]
    public FirebaseAuth auth;
    public FirebaseUser user;
    [Space]
    [Header("Login")]
    public InputField emailInputField;
    public InputField passwordInputField;
    public Text messageText;
    [SerializeField] GameObject[] imageAlert;
    [SerializeField] Animator alertModal;
    void Start()
    {
        InitializeFirebase();
        CloseAlert();
    }
    private void InitializeFirebase()
    {
        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWithOnMainThread(task =>
        {
            FirebaseApp app = FirebaseApp.DefaultInstance;
            auth = FirebaseAuth.DefaultInstance;
        });
    }
    void SetALert(int _type)
    {
        Action action = _type switch
        {
            0 => () =>
            {
                imageAlert[0].SetActive(true);
                imageAlert[1].SetActive(false);
                alertModal.SetBool("showAlert", true);
            }
            ,
            1 => () =>
            {
                imageAlert[0].SetActive(false);
                imageAlert[1].SetActive(true);
                alertModal.SetBool("showAlert", true);
            }
            ,
            _ => () =>
            {
                imageAlert[0].SetActive(false);
                imageAlert[1].SetActive(false);
                alertModal.SetBool("showAlert", false);
            }
        };
        action();
    }
    public void CloseAlert()
    {
        SetALert(2);
    }
    public void Login()
    {
        StartCoroutine(IELogin());
    }
    IEnumerator IELogin()
    {
        string email = emailInputField.text + "@gmail.com";
        string password = passwordInputField.text;
        var loginTask = auth.SignInWithEmailAndPasswordAsync(email, password);
        yield return new WaitUntil(() => loginTask.IsCompleted);
        if (loginTask.Exception != null)
        {
            Debug.LogError(loginTask.Exception);
            FirebaseException firebaseException = loginTask.Exception.GetBaseException() as FirebaseException;
            AuthError authError = (AuthError)firebaseException.ErrorCode;
            string errorMessage = "Error al iniciar sesión porque: ";
            errorMessage += authError switch
            {
                AuthError.InvalidEmail => "El correo no es valido",
                AuthError.WrongPassword => "La contraseña es erronea",
                AuthError.MissingEmail => "No hay correo",
                AuthError.MissingPassword => "No hay contraseña",
                AuthError.UserNotFound => "El usuario no existe",
                _ => "Hubo un error desconocido!",
            };
            SetALert(0);
            messageText.text = errorMessage;
        }
        else
        {
            AuthResult result = loginTask.Result;
            FirebaseUser user = result.User;
            SetALert(1);
            messageText.text = "Inicio de sesión exitoso!";
            yield return new WaitForSeconds(1f);
            CloseAlert();
            ClearLoginInputs();
            yield return new WaitForSeconds(0.4f);
            SceneManager.LoadScene(2);
        }
    }
    void ClearLoginInputs()
    {
        emailInputField.text = "";
        passwordInputField.text = "";
    }
    public void ButtonExit()
    {
        Application.Quit();
    }
}