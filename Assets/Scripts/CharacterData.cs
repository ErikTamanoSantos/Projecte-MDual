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

    public string skill_name;
    public string skill_desc;
    

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
        if (name == "nightborne") {
            skill_name = "Energy Drain";
        } else {
            skill_name = "Soul Burst";
        }
        resetSkillDesc();
    }

    public void resetSkillDesc() {
        if (name == "nightborne") {
            skill_desc = "The Nightborne drains his enemy's lifeforce on every 3rd attack, healing themselves " + baseMAG/3 + " HP.";
        } else {
            skill_desc = "The Necromancer casts down a burst of dark energy on every 4th attack, dealing " + baseMAG + " bonus damage.";
        }
    }
}