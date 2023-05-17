using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LoginController : MonoBehaviour
{
    [SerializeField] private Button loginButton;
    [SerializeField] private TMP_InputField usernameInput, passwordInput;
    // Start is called before the first frame update
    void Start()
    {
        loginButton.onClick.AddListener(LoginEvent);
    }

    void LoginEvent()
    {
        StartCoroutine(UtilsServer.login(usernameInput.text, passwordInput.text));
        
    }
}
