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
        SetALert(0, false);
    }
    private void InitializeFirebase()
    {
        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWithOnMainThread(task =>
        {
            FirebaseApp app = FirebaseApp.DefaultInstance;
            auth = FirebaseAuth.DefaultInstance;
        });
    }
    void SetALert(int index, bool myBool)
    {
        imageAlert[index].SetActive(myBool);
        alertModal.SetBool("showAlert", myBool);
    }
    public void CloseAlert()
    {
        SetALert(0, false);
    }
    public void Login()
    {
        StartCoroutine(IELogin());
    }
    IEnumerator IELogin()
    {
        SetALert(0, true);
        string email = emailInputField.text;
        string password = passwordInputField.text;
        if (email == "")
        {
            messageText.text = "El correo es requerido";
        }
        if (password == "")
        {
            messageText.text = "La contraseña es requerida";
        }
        if (email == "" && password == "")
        {
            messageText.text = "Correo y contraseña requeridos";
        }
        else
        {
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
                    _ => "La cuenta no existe",
                };
                SetALert(0, true);
                messageText.text = errorMessage;
            }
            else
            {
                AuthResult result = loginTask.Result;
                FirebaseUser user = result.User;
                SetALert(1, true);
                messageText.text = "Inicio de sesión exitoso!";
                yield return new WaitForSeconds(1f);
                CloseAlert();
                ClearLoginInputs();
                SceneManager.LoadScene(2);
            }
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