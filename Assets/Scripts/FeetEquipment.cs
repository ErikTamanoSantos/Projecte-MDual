using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;
using UnityEngine.UI;


public class FeetEquipment
{
    public int bonusHP, bonusMP, bonusATK, bonusMAG, bonusATKSPD, bonusMOVSPD, bonusRange;
    public string name;

    public FeetEquipment(string name, int bonusHP, int bonusMP, int bonusATK, int bonusMAG, int bonusATKSPD, int bonusMOVSPD, int bonusRange) {
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
