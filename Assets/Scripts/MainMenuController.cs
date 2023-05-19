using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{

    [SerializeField] Button buttonEquipment, buttonParty, buttonExit;

    // Start is called before the first frame update
    void Start()
    {
        buttonEquipment.onClick.AddListener(delegate {GameObject.FindGameObjectWithTag("clickSound").GetComponent<ButtonClickSound>().playSound();SceneManager.LoadScene("EquipmentScene");});
        buttonParty.onClick.AddListener(delegate {GameObject.FindGameObjectWithTag("clickSound").GetComponent<ButtonClickSound>().playSound();SceneManager.LoadScene("PartyScene");});
        buttonExit.onClick.AddListener(delegate {GameObject.FindGameObjectWithTag("clickSound").GetComponent<ButtonClickSound>().playSound();SceneManager.LoadScene("MapScene");});
    }
}
