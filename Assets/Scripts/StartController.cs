using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class StartController : MonoBehaviour
{

    [SerializeField] private Button registerButton, loginButton;
    // Start is called before the first frame update
    void Start()
    {
        GameObject.FindGameObjectWithTag("StartScreenMusic").GetComponent<MusicPlayer>().playMusic();
        registerButton.onClick.AddListener(delegate {GameObject.FindGameObjectWithTag("clickSound").GetComponent<ButtonClickSound>().playSound();SceneManager.LoadScene("RegisterScene");});
        loginButton.onClick.AddListener(delegate {GameObject.FindGameObjectWithTag("clickSound").GetComponent<ButtonClickSound>().playSound();SceneManager.LoadScene("LoginScene");});
    }
}
