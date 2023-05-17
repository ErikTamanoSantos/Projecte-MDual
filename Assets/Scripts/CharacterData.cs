using UnityEngine;
using UnityEngine;
using UnityEngine.UI;


public class CharacterData
{
    public string name;
    public int   maxHP;
    public int   maxMP;
    public int   baseATK;
    public int   baseMAG;
    public float baseATKSPD;
    public float baseMOVSPD;
    public int   baseRange;

    public int currentXP;
    public int currentLvl;

    public int   currentHP;

    public HeadEquipment headEquipment;
    public ChestEquipment chestEquipment;
    public LegsEquipment legsEquipment;
    public FeetEquipment feetEquipment;
    

    public CharacterData(string name, int currentLvl, int currentXP) {
        this.name = name;
        this.maxHP = 40+(3*(currentLvl-1));
        this.maxMP = 100;
        this.baseATK = 5+(5*(currentLvl-1));
        this.baseMAG = 5+(5*(currentLvl-1));
        this.baseATKSPD = 5f+(5*(currentLvl-1));
        this.baseMOVSPD = 0f;
        this.baseRange = 0;
        this.currentXP = currentXP;
        this.currentLvl = currentLvl;
        this.currentHP = this.maxHP;
    }
}