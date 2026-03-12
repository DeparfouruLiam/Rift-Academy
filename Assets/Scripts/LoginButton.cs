using UnityEngine;
using Firebase.Auth;
using TMPro;

public class LoginButton : MonoBehaviour
{
    [SerializeField] TMP_InputField Username;
    [SerializeField] TMP_InputField Password;
    private FirebaseAuth auth;

    private void Start() {
        auth = FirebaseAuth.DefaultInstance;
    }
    

    public async void LoginClick()
    {
        var result = await auth.SignInWithEmailAndPasswordAsync(Username.text, Password.text);

    FirebaseUser user = result.User;

    Debug.Log("Connected UID: " + user.UserId);
    }

    public async void RegisterClick()
    {
        Debug.Log(auth);
        Debug.Log(Username.text);
        Debug.Log(Password.text);

        var result = await auth.CreateUserWithEmailAndPasswordAsync(Username.text, Password.text);

        FirebaseUser user = result.User;

        Debug.Log("User created: " + user.UserId);
    }
}
