using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;


public class RegisterController : MonoBehaviour
{

    public static RegisterController Instance;
    [SerializeField] private Button registerButton, backButton;
    [SerializeField] private TMP_InputField usernameInput, passwordInput;
    [SerializeField] public TextMeshProUGUI errorText;
    // Start is called before the first frame update
    void Start()
    {
        backButton.onClick.AddListener(delegate {GameObject.FindGameObjectWithTag("clickSound").GetComponent<ButtonClickSound>().playSound();SceneManager.LoadScene("StartScene");});
        Instance = this;
        registerButton.onClick.AddListener(LoginEvent);
        errorText.enabled = false;
    }

    void LoginEvent()
    {
        GameObject.FindGameObjectWithTag("clickSound").GetComponent<ButtonClickSound>().playSound();
        StartCoroutine(UtilsServer.register(usernameInput.text, passwordInput.text));
        
    }
}
