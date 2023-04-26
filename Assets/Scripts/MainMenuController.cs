using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{

    [SerializeField] Button buttonEquipment, buttonParty;

    // Start is called before the first frame update
    void Start()
    {
        buttonEquipment.onClick.AddListener(delegate {SceneManager.LoadScene("EquipmentScene");});
        buttonParty.onClick.AddListener(delegate {SceneManager.LoadScene("PartyScene");});
    }
}
