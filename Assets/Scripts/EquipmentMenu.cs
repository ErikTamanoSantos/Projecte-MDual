using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;
using UnityEngine.SceneManagement;

public class EquipmentMenu : MonoBehaviour
{
    private int currentPage = 0;
    [SerializeField] private TextMeshProUGUI name, lvl, hp, atk, mag, xp, spd, skill_name, skill_desc;
    [SerializeField] private Button button_return, button_prev, button_next;
    // Start is called before the first frame update
    void Start()
    {
        button_return.onClick.AddListener(delegate {GameObject.FindGameObjectWithTag("clickSound").GetComponent<ButtonClickSound>().playSound();SceneManager.LoadScene("MenuScene");});
        button_prev.onClick.AddListener(delegate {prevPage();});
        button_next.onClick.AddListener(delegate {nextPage();});
        renderData();   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void renderData() {
        name.text = GameData.Party_ActiveParty[currentPage].name;
        lvl.text = "" + GameData.Party_ActiveParty[currentPage].currentLvl;
        hp.text = "" +GameData.Party_ActiveParty[currentPage].currentHP + "/" + GameData.Party_ActiveParty[currentPage].maxHP;
        atk.text = "" + GameData.Party_ActiveParty[currentPage].baseATK;
        mag.text = "" +GameData.Party_ActiveParty[currentPage].baseMAG;
        xp.text = "" +GameData.Party_ActiveParty[currentPage].currentXP;
        spd.text = "" +GameData.Party_ActiveParty[currentPage].baseATKSPD;
        skill_name.text = GameData.Party_ActiveParty[currentPage].skill_name;
        skill_desc.text= GameData.Party_ActiveParty[currentPage].skill_desc;
    }

    void prevPage() {
        GameObject.FindGameObjectWithTag("clickSound").GetComponent<ButtonClickSound>().playSound();
        if (currentPage == 0) {
            currentPage = GameData.Party_ActiveParty.Count-1;
        } else {
            currentPage--;
        }
        renderData();
    }

    void nextPage() {
        GameObject.FindGameObjectWithTag("clickSound").GetComponent<ButtonClickSound>().playSound();
        if (currentPage == GameData.Party_ActiveParty.Count-1) {
            currentPage = 0;
        } else {
            currentPage++;
        }
        renderData();
    }
}
