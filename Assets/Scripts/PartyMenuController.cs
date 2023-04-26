using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PartyMenuController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI ActiveMember_Name_1, ActiveMember_Name_2, ActiveMember_Name_3, ActiveMember_Name_4, ActiveMember_Name_5, ActiveMember_Name_6, ActiveMember_Name_7;
    // Start is called before the first frame update
    void Start()
    {
        ActiveMember_Name_1.text = GameData.Party_ActiveParty[0].name;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
