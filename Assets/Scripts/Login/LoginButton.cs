using UnityEngine;
using Firebase;
using Firebase.Auth;
using Firebase.Firestore;
using System.Collections.Generic;
using TMPro;

public class LoginButton : MonoBehaviour
{
    [SerializeField] TMP_InputField Email;
    [SerializeField] TMP_InputField Password;
    [SerializeField] TMP_InputField Username;

    private FirebaseAuth auth;

    private async void Start() {
        var dependencyStatus =
        await FirebaseApp.CheckAndFixDependenciesAsync();

        if (dependencyStatus == DependencyStatus.Available)
        {
            auth = FirebaseAuth.DefaultInstance;
        }
        print("Firebase Auth initialized: " + auth);
    }
    

    public async void LoginClick()
    {
        Debug.Log(auth);
            Debug.Log(Email.text);
            Debug.Log(Password.text);
        var result = await auth.SignInWithEmailAndPasswordAsync(Email.text, Password.text);

    FirebaseUser user = result.User;

    Debug.Log("Connected UID: " + user.UserId);
    }

    public async void RegisterClick()
    {
        try{
            Debug.Log(auth);
            Debug.Log(Email.text);
            Debug.Log(Password.text);

            var result = await auth.CreateUserWithEmailAndPasswordAsync(Email.text, Password.text);

            FirebaseUser user = result.User;

            Debug.Log("User created: " + user.UserId);

            FirebaseFirestore db = FirebaseFirestore.DefaultInstance;

            Dictionary<string, object> NewUser = new Dictionary<string, object>()
            {
                { "Mail", Email.text },
                { "Pseudo", Username.text },
                { "Money", 0 },
                { "Shards", 1000 },
                { "HeroesConst", "0000000000000000000000000000000000000000" }
            };

            await db.Collection("Users").Document(user.UserId).SetAsync(NewUser);


        }

        catch (FirebaseException e)
        {
            Debug.LogError("Registration failed: " + e.Message);
        }
    }
}
