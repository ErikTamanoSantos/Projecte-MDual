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

    public int   currentHP;

    public HeadEquipment headEquipment;
    public ChestEquipment chestEquipment;
    public LegsEquipment legsEquipment;
    public FeetEquipment feetEquipment;
    

    public CharacterData(string name, int maxHP, int maxMP, int baseATK, int baseMAG, float baseATKSPD, float baseMOVSPD, int baseRange, int currentHP) {
        this.name       = name;
        this.maxHP      = maxHP;
        this.maxMP      = maxMP;
        this.baseATK    = baseATK;
        this.baseMAG    = baseMAG;
        this.baseMOVSPD = baseMOVSPD;
        this.baseRange  = baseRange;
        this.currentHP  = currentHP;
    }
}