using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;
using UnityEngine.SceneManagement;

public class PartyMenuController : MonoBehaviour
{
    [SerializeField] private List<TextMeshProUGUI> ActiveParty_Names, ActiveParty_HP, InactiveParty_names, InactiveParty_HP;
    [SerializeField] private List<Button> ActiveParty_Cells, InactiveParty_Cells;
    [SerializeField] private Button button_return;
    // Start is called before the first frame update
    void Start()
    {
        button_return.onClick.AddListener(delegate {GameObject.FindGameObjectWithTag("clickSound").GetComponent<ButtonClickSound>().playSound();SceneManager.LoadScene("MenuScene");});
        for (int i = 0; i < ActiveParty_Cells.Count; i++) {
            int index = i;
            ActiveParty_Cells[i].onClick.AddListener(delegate{if (GameData.Party_ActiveParty[index] != null) {moveToInactiveParty(index);}});
        }

        for (int i = 0; i < InactiveParty_Cells.Count; i++) {
            int index = i;
            InactiveParty_Cells[i].onClick.AddListener(delegate{if (GameData.Party_InactiveParty.Count-1 >= index && GameData.Party_InactiveParty[index] != null) {moveToActiveParty(index);}});
            
        }
        renderData();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void moveToInactiveParty(int index) {
        CharacterData character = GameData.Party_ActiveParty[index];
        if (character != null) {
            GameData.Party_ActiveParty.Remove(character);
            GameData.Party_InactiveParty.Add(character);
            renderData();
        }
    }

    void moveToActiveParty(int index) {
        CharacterData character = GameData.Party_InactiveParty[index];
        if (character != null) {
            GameData.Party_InactiveParty.Remove(character);
            GameData.Party_ActiveParty.Add(character);
        }
        renderData();
    }

    void renderData() {
        for (int i = 0; i < ActiveParty_Names.Count; i++) {
            if (GameData.Party_ActiveParty.Count > i && GameData.Party_ActiveParty[i] != null) {
                Debug.Log(GameData.Party_ActiveParty[i].name);
                ActiveParty_Names[i].text = GameData.Party_ActiveParty[i].name;
            } else {
                 ActiveParty_Names[i].text = "";
            }
        }
        for (int i = 0; i < ActiveParty_HP.Count; i++) {
            if (GameData.Party_ActiveParty.Count > i && GameData.Party_ActiveParty[i] != null) {
                ActiveParty_HP[i].text = "HP: " + GameData.Party_ActiveParty[i].currentHP + "/" + GameData.Party_ActiveParty[i].maxHP;
            } else {
                ActiveParty_HP[i].text = "";
            }
        }
        for (int i = 0; i < InactiveParty_names.Count; i++) {
            if (GameData.Party_InactiveParty.Count > i &&GameData.Party_InactiveParty[i] != null) {
                InactiveParty_names[i].text = GameData.Party_InactiveParty[i].name;
            } else {
                 InactiveParty_names[i].text = "";
            }
        }
        for (int i = 0; i < InactiveParty_HP.Count; i++) {
            if (GameData.Party_InactiveParty.Count > i &&  GameData.Party_InactiveParty[i] != null) {
                InactiveParty_HP[i].text = "HP: " + GameData.Party_InactiveParty[i].currentHP + "/" + GameData.Party_InactiveParty[i].maxHP;
            } else {
                InactiveParty_HP[i].text = "";
            }
        }
    }

}
