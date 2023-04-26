using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;
using UnityEngine.UI;


public class GameData : MonoBehaviour
{
    // MAP DATA
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
        {MapTileType.walkable, MapTileType.walkable, MapTileType.walkable, MapTileType.walkable, MapTileType.walkable, MapTileType.walkable, MapTileType.walkable, MapTileType.walkable, MapTileType.walkable},
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
    public static ArrayList Party_InactiveParty = new ArrayList();
}

public enum MapTileType
{
    blocked,
    walkable,
    battle    
}
