using UnityEngine;
using Firebase.Auth;
public class Deconnexion : MonoBehaviour
{
    [SerializeField] GameObject LoginButton;
    [SerializeField] GameObject DisconnectButton;
    public void Disconect()
    {
        LoginButton.SetActive(true);
        DisconnectButton.SetActive(true);
        FirebaseAuth.DefaultInstance.SignOut();
    }
}
