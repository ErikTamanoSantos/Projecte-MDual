using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class LoginController : MonoBehaviour
{

    public static LoginController Instance;
    [SerializeField] private Button loginButton, backButton;
    [SerializeField] private TMP_InputField usernameInput, passwordInput;
    [SerializeField] public TextMeshProUGUI errorText;
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        backButton.onClick.AddListener(delegate {GameObject.FindGameObjectWithTag("clickSound").GetComponent<ButtonClickSound>().playSound();SceneManager.LoadScene("StartScene");});
        loginButton.onClick.AddListener(LoginEvent);
        errorText.enabled = false;
    }

    void LoginEvent()
    {
        GameObject.FindGameObjectWithTag("clickSound").GetComponent<ButtonClickSound>().playSound();
        StartCoroutine(UtilsServer.login(usernameInput.text, passwordInput.text));
        
    }
}
