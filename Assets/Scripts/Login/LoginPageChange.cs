using System;
using TMPro;
using UnityEngine;

public class LoginPageChange : MonoBehaviour
{
    [SerializeField] TMP_Text TitleText;
    [SerializeField] GameObject LoginButton;
    [SerializeField] GameObject RegisterButton;
    [SerializeField] GameObject UsernameField;
    [SerializeField] GameObject LoginPage;
    [SerializeField] GameObject RegisterPage;

    private void Start() {
        ConnexionPage();
    }
    public void ConnexionPage()
    {
        TitleText.text = "Connexion";
        LoginButton.SetActive(true);
        RegisterButton.SetActive(false);
        UsernameField.SetActive(false);
    }

    public void InscriptionPage()
    {
        TitleText.text = "Inscription";
        LoginButton.SetActive(false);
        RegisterButton.SetActive(true);
        UsernameField.SetActive(true);
    }
}
