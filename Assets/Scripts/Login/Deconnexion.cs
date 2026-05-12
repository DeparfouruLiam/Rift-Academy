using UnityEngine;
using Firebase.Auth;
public class Deconnexion : MonoBehaviour
{
    [SerializeField] GameObject LoginButton;
    public void Disconect()
    {
        LoginButton.SetActive(true);
        FirebaseAuth.DefaultInstance.SignOut();
    }
}
