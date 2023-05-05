using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;
using UnityEngine.UI;


public class LegsEquipment
{
    public int bonusHP, bonusMP, bonusATK, bonusMAG, bonusATKSPD, bonusMOVSPD, bonusRange;
    public string name;

    public LegsEquipment(string name, int bonusHP, int bonusMP, int bonusATK, int bonusMAG, int bonusATKSPD, int bonusMOVSPD, int bonusRange) {
        this.name = name;
        this.bonusHP = bonusHP;
        this.bonusMP = bonusMP;
        this.bonusATK = bonusATK;
        this.bonusMAG = bonusMAG;
        this.bonusATKSPD = bonusATKSPD;
        this.bonusMOVSPD = bonusMOVSPD;
        this.bonusRange = bonusRange;
    }
}
