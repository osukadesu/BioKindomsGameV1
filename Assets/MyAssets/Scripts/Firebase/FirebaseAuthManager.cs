using UnityEngine;
using Firebase;
using Firebase.Auth;
using UnityEngine.UI;
using Firebase.Extensions;
using System.Collections;
using UnityEngine.SceneManagement;
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
        SetALert(0, false, 1, false);
    }
    private void InitializeFirebase()
    {
        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWithOnMainThread(task =>
        {
            FirebaseApp app = FirebaseApp.DefaultInstance;
            auth = FirebaseAuth.DefaultInstance;
        });
    }
    void SetALert(int index, bool myBool, int index2, bool myBool2)
    {
        imageAlert[index].SetActive(myBool);
        imageAlert[index2].SetActive(myBool2);
        alertModal.SetBool("showAlert", myBool);
    }
    public void CloseAlert()
    {
        SetALert(0, false, 1, false);
    }
    public void Login()
    {
        StartCoroutine(IELogin());
    }
    IEnumerator IELogin()
    {
        SetALert(0, false, 1, false);
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
                _ => "La cuenta no existe",
            };
            SetALert(0, true, 1, false);
            messageText.text = errorMessage;
        }
        else
        {
            AuthResult result = loginTask.Result;
            FirebaseUser user = result.User;
            SetALert(0, false, 1, true);
            messageText.text = "Inicio de sesión exitoso!";
            CloseAlert();
            ClearLoginInputs();
            yield return new WaitForSeconds(2f);
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