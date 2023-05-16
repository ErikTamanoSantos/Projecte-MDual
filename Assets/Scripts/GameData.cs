using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;
using UnityEngine.UI;


public class GameData : MonoBehaviour
{
    // MAP DATA
    public static int currentLevel = 1;
    public static Vector2 Map_CharacterPos = new Vector2(3, 2);
    /*
    public static MapTileType[,] Map_CurrentLayout = new MapTileType[,] {
        {MapTileType.blocked, MapTileType.blocked, MapTileType.blocked, MapTileType.blocked, MapTileType.blocked, MapTileType.blocked, MapTileType.blocked, MapTileType.blocked}, 
        {MapTileType.blocked, MapTileType.blocked, MapTileType.blocked, MapTileType.blocked, MapTileType.blocked, MapTileType.blocked, MapTileType.blocked, MapTileType.blocked}, 
        {MapTileType.blocked, MapTileType.blocked, MapTileType.blocked, MapTileType.walkable, MapTileType.blocked, MapTileType.blocked, MapTileType.blocked, MapTileType.blocked},
        {MapTileType.blocked, MapTileType.blocked, MapTileType.blocked, MapTileType.walkable, MapTileType.blocked, MapTileType.blocked, MapTileType.blocked, MapTileType.blocked},
        {MapTileType.blocked, MapTileType.blocked, MapTileType.blocked, MapTileType.walkable, MapTileType.blocked, MapTileType.blocked, MapTileType.blocked, MapTileType.blocked}, 
        {MapTileType.blocked, MapTileType.blocked, MapTileType.blocked, MapTileType.walkable, MapTileType.blocked, MapTileType.blocked, MapTileType.blocked, MapTileType.blocked}, 
        {MapTileType.blocked, MapTileType.blocked, MapTileType.blocked, MapTileType.walkable, MapTileType.blocked, MapTileType.blocked, MapTileType.blocked, MapTileType.blocked}, 
        {MapTileType.blocked, MapTileType.blocked, MapTileType.blocked, MapTileType.blocked, MapTileType.blocked, MapTileType.blocked, MapTileType.blocked, MapTileType.blocked}, 
        {MapTileType.blocked, MapTileType.blocked, MapTileType.blocked, MapTileType.blocked, MapTileType.blocked, MapTileType.blocked, MapTileType.blocked, MapTileType.blocked},  
        {MapTileType.blocked, MapTileType.blocked, MapTileType.blocked, MapTileType.blocked, MapTileType.blocked, MapTileType.blocked, MapTileType.blocked, MapTileType.blocked} };
        */
    
    public static MapTileType[,] Map_CurrentLayout = new MapTileType[,] {
        {MapTileType.walkable, MapTileType.walkable, MapTileType.walkable, MapTileType.battle, MapTileType.walkable, MapTileType.walkable, MapTileType.walkable, MapTileType.walkable, MapTileType.walkable},
        {MapTileType.walkable, MapTileType.walkable, MapTileType.walkable, MapTileType.walkable, MapTileType.walkable, MapTileType.walkable, MapTileType.walkable, MapTileType.walkable, MapTileType.walkable},
        {MapTileType.walkable, MapTileType.walkable, MapTileType.walkable, MapTileType.walkable, MapTileType.walkable, MapTileType.walkable, MapTileType.walkable, MapTileType.walkable, MapTileType.walkable},
        {MapTileType.walkable, MapTileType.walkable, MapTileType.walkable, MapTileType.walkable, MapTileType.walkable, MapTileType.walkable, MapTileType.walkable, MapTileType.walkable, MapTileType.walkable},
        {MapTileType.walkable, MapTileType.walkable, MapTileType.walkable, MapTileType.walkable, MapTileType.walkable, MapTileType.walkable, MapTileType.walkable, MapTileType.walkable, MapTileType.walkable},
        {MapTileType.walkable, MapTileType.walkable, MapTileType.walkable, MapTileType.walkable, MapTileType.walkable, MapTileType.walkable, MapTileType.walkable, MapTileType.walkable, MapTileType.walkable},
        {MapTileType.walkable, MapTileType.walkable, MapTileType.walkable, MapTileType.walkable, MapTileType.walkable, MapTileType.walkable, MapTileType.walkable, MapTileType.walkable, MapTileType.walkable},
        {MapTileType.walkable, MapTileType.walkable, MapTileType.walkable, MapTileType.walkable, MapTileType.walkable, MapTileType.walkable, MapTileType.walkable, MapTileType.walkable, MapTileType.walkable},
        {MapTileType.walkable, MapTileType.walkable, MapTileType.walkable, MapTileType.walkable, MapTileType.walkable, MapTileType.walkable, MapTileType.walkable, MapTileType.walkable, MapTileType.walkable},

    };
    // PARTY DATA
    public static CharacterData[] Party_ActiveParty = new CharacterData[7] {new CharacterData("test", 1, 1, 1, 1, 1, 1, 1, 1), null, null, null, null, null, null};
    public static List<CharacterData> Party_InactiveParty = new List<CharacterData>();

    //EQUIPMENT DATA
    public static List<HeadEquipment> Equipment_UnusedHeadEq = new List<HeadEquipment>();
    public static List<ChestEquipment> Equipment_UnusedChestEq = new List<ChestEquipment>();
    public static List<LegsEquipment> Equipment_UnusedLegsEq = new List<LegsEquipment>();
    public static List<FeetEquipment> Equipment_UnusedFeetEq = new List<FeetEquipment>();
    public static int Equipment_pageIndex = 0;
}

public enum MapTileType
{
    blocked,
    walkable,
    battle    
}
