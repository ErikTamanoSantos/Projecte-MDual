using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;
using UnityEngine.UI;


public class GameData
{

    public static string userId;
    // MAP DATA
    public static int currentLevel = 1;
    public static Vector2 Map_CharacterPos = new Vector2(4, 1);
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

    new MapTileType[,] {
        {MapTileType.walkable, MapTileType.walkable, MapTileType.walkable, MapTileType.battle, MapTileType.walkable, MapTileType.walkable, MapTileType.walkable, MapTileType.walkable, MapTileType.walkable},
        {MapTileType.walkable, MapTileType.walkable, MapTileType.walkable, MapTileType.walkable, MapTileType.walkable, MapTileType.walkable, MapTileType.walkable, MapTileType.walkable, MapTileType.walkable},
        {MapTileType.walkable, MapTileType.walkable, MapTileType.walkable, MapTileType.walkable, MapTileType.walkable, MapTileType.walkable, MapTileType.walkable, MapTileType.walkable, MapTileType.walkable},
        {MapTileType.walkable, MapTileType.walkable, MapTileType.walkable, MapTileType.walkable, MapTileType.walkable, MapTileType.walkable, MapTileType.walkable, MapTileType.walkable, MapTileType.walkable},
        {MapTileType.walkable, MapTileType.walkable, MapTileType.walkable, MapTileType.walkable, MapTileType.walkable, MapTileType.walkable, MapTileType.walkable, MapTileType.walkable, MapTileType.walkable},
        {MapTileType.walkable, MapTileType.walkable, MapTileType.walkable, MapTileType.walkable, MapTileType.walkable, MapTileType.walkable, MapTileType.walkable, MapTileType.walkable, MapTileType.walkable},
        {MapTileType.walkable, MapTileType.walkable, MapTileType.walkable, MapTileType.walkable, MapTileType.walkable, MapTileType.walkable, MapTileType.walkable, MapTileType.walkable, MapTileType.walkable},
        {MapTileType.walkable, MapTileType.walkable, MapTileType.walkable, MapTileType.walkable, MapTileType.walkable, MapTileType.walkable, MapTileType.walkable, MapTileType.walkable, MapTileType.walkable},
        {MapTileType.walkable, MapTileType.walkable, MapTileType.walkable, MapTileType.walkable, MapTileType.walkable, MapTileType.walkable, MapTileType.walkable, MapTileType.walkable, MapTileType.walkable},
        */
    
    public static MapTileType[,]  Map_CurrentLayout;
    // PARTY DATA
    public static List<CharacterData> Party_ActiveParty = new List<CharacterData>();
    public static List<CharacterData> Party_InactiveParty = new List<CharacterData>();

    //EQUIPMENT DATA
    public static List<HeadEquipment> Equipment_UnusedHeadEq = new List<HeadEquipment>();
    public static List<ChestEquipment> Equipment_UnusedChestEq = new List<ChestEquipment>();
    public static List<LegsEquipment> Equipment_UnusedLegsEq = new List<LegsEquipment>();
    public static List<FeetEquipment> Equipment_UnusedFeetEq = new List<FeetEquipment>();
    public static int Equipment_pageIndex = 0;

    public static void generateRandomMapLayout() {
        var random = (int) Mathf.Round(Random.Range(0, 3));
        Debug.Log(random);
        switch (random) {
            case 0:
            /*
            x x x x x x x x x
            x x x x x x x x x
            x x x x s x x x x
            x x b b b b b x x
            x x x x b x x x x
            x x x x n x x x x
            x x x x x x x x x
            x x x x x x x x x
            x x x x x x x x x
            */
            Map_CurrentLayout = new MapTileType[,] {
                {MapTileType.blocked, MapTileType.blocked, MapTileType.blocked, MapTileType.blocked, MapTileType.blocked, MapTileType.blocked, MapTileType.blocked, MapTileType.blocked, MapTileType.blocked}, 
                {MapTileType.blocked, MapTileType.blocked, MapTileType.blocked, MapTileType.blocked, MapTileType.blocked, MapTileType.blocked, MapTileType.blocked, MapTileType.blocked, MapTileType.blocked}, 
                {MapTileType.blocked, MapTileType.blocked, MapTileType.battle, MapTileType.blocked, MapTileType.blocked, MapTileType.blocked, MapTileType.blocked, MapTileType.blocked, MapTileType.blocked},
                {MapTileType.blocked, MapTileType.blocked, MapTileType.battle, MapTileType.blocked, MapTileType.blocked, MapTileType.blocked, MapTileType.blocked, MapTileType.blocked, MapTileType.blocked},
                {MapTileType.blocked, MapTileType.start, MapTileType.battle, MapTileType.battle, MapTileType.next_level, MapTileType.blocked, MapTileType.blocked, MapTileType.blocked, MapTileType.blocked},
                {MapTileType.blocked, MapTileType.blocked, MapTileType.battle, MapTileType.blocked, MapTileType.blocked, MapTileType.blocked, MapTileType.blocked, MapTileType.blocked, MapTileType.blocked},
                {MapTileType.blocked, MapTileType.blocked, MapTileType.battle, MapTileType.blocked, MapTileType.blocked, MapTileType.blocked, MapTileType.blocked, MapTileType.blocked, MapTileType.blocked},
                {MapTileType.blocked, MapTileType.blocked, MapTileType.blocked, MapTileType.blocked, MapTileType.blocked, MapTileType.blocked, MapTileType.blocked, MapTileType.blocked, MapTileType.blocked}, 
                {MapTileType.blocked, MapTileType.blocked, MapTileType.blocked, MapTileType.blocked, MapTileType.blocked, MapTileType.blocked, MapTileType.blocked, MapTileType.blocked, MapTileType.blocked}, 
            };
            Map_CharacterPos = new Vector2(4, 1);
            break;
            case 1:
            /*
            x x x x x x x x x
            x x x x x x x x x
            x x b x n x x x x
            x x b b b b b x x
            x x x x b x b x x
            x x x x s x x x x
            x x x x x x x x x
            x x x x x x x x x
            x x x x x x x x x
            */
            Map_CurrentLayout = new MapTileType[,] {
                {MapTileType.blocked, MapTileType.blocked, MapTileType.blocked, MapTileType.blocked, MapTileType.blocked, MapTileType.blocked, MapTileType.blocked, MapTileType.blocked, MapTileType.blocked}, 
                {MapTileType.blocked, MapTileType.blocked, MapTileType.blocked, MapTileType.blocked, MapTileType.blocked, MapTileType.blocked, MapTileType.blocked, MapTileType.blocked, MapTileType.blocked}, 
                {MapTileType.blocked, MapTileType.battle, MapTileType.battle, MapTileType.blocked, MapTileType.blocked, MapTileType.blocked, MapTileType.blocked, MapTileType.blocked, MapTileType.blocked},
                {MapTileType.blocked, MapTileType.blocked, MapTileType.battle, MapTileType.blocked, MapTileType.blocked, MapTileType.blocked, MapTileType.blocked, MapTileType.blocked, MapTileType.blocked},
                {MapTileType.blocked, MapTileType.start, MapTileType.battle, MapTileType.battle, MapTileType.next_level, MapTileType.blocked, MapTileType.blocked, MapTileType.blocked, MapTileType.blocked},
                {MapTileType.blocked, MapTileType.blocked, MapTileType.battle, MapTileType.blocked, MapTileType.blocked, MapTileType.blocked, MapTileType.blocked, MapTileType.blocked, MapTileType.blocked},
                {MapTileType.blocked, MapTileType.blocked, MapTileType.battle, MapTileType.battle, MapTileType.blocked, MapTileType.blocked, MapTileType.blocked, MapTileType.blocked, MapTileType.blocked},
                {MapTileType.blocked, MapTileType.blocked, MapTileType.blocked, MapTileType.blocked, MapTileType.blocked, MapTileType.blocked, MapTileType.blocked, MapTileType.blocked, MapTileType.blocked}, 
                {MapTileType.blocked, MapTileType.blocked, MapTileType.blocked, MapTileType.blocked, MapTileType.blocked, MapTileType.blocked, MapTileType.blocked, MapTileType.blocked, MapTileType.blocked}, 
            };
            Map_CharacterPos = new Vector2(4, 1);
            break;
            case 2:
            Map_CurrentLayout = new MapTileType[,] {
                {MapTileType.blocked, MapTileType.battle, MapTileType.battle, MapTileType.battle, MapTileType.battle, MapTileType.battle, MapTileType.blocked, MapTileType.blocked, MapTileType.blocked}, 
                {MapTileType.blocked, MapTileType.battle, MapTileType.blocked, MapTileType.blocked, MapTileType.blocked, MapTileType.blocked, MapTileType.blocked, MapTileType.blocked, MapTileType.blocked}, 
                {MapTileType.blocked, MapTileType.battle, MapTileType.blocked, MapTileType.blocked, MapTileType.blocked, MapTileType.blocked, MapTileType.blocked, MapTileType.blocked, MapTileType.blocked},
                {MapTileType.blocked, MapTileType.battle, MapTileType.blocked, MapTileType.blocked, MapTileType.blocked, MapTileType.blocked, MapTileType.blocked, MapTileType.blocked, MapTileType.blocked},
                {MapTileType.blocked, MapTileType.start, MapTileType.battle, MapTileType.battle, MapTileType.next_level, MapTileType.blocked, MapTileType.blocked, MapTileType.blocked, MapTileType.blocked},
                {MapTileType.blocked, MapTileType.blocked, MapTileType.blocked, MapTileType.blocked, MapTileType.blocked, MapTileType.blocked, MapTileType.blocked, MapTileType.blocked, MapTileType.blocked},
                {MapTileType.blocked, MapTileType.blocked, MapTileType.blocked, MapTileType.blocked, MapTileType.blocked, MapTileType.blocked, MapTileType.blocked, MapTileType.blocked, MapTileType.blocked},
                {MapTileType.blocked, MapTileType.blocked, MapTileType.blocked, MapTileType.blocked, MapTileType.blocked, MapTileType.blocked, MapTileType.blocked, MapTileType.blocked, MapTileType.blocked}, 
                {MapTileType.blocked, MapTileType.blocked, MapTileType.blocked, MapTileType.blocked, MapTileType.blocked, MapTileType.blocked, MapTileType.blocked, MapTileType.blocked, MapTileType.blocked}, 
            };
            Map_CharacterPos = new Vector2(4, 1);
            break;
            case 3:
            /*
            x x x x x x x x x
            x x x x x x x x x
            x x b x n x x x x
            x b b b b b x x x
            x b x x b x x x x
            x x x x s x x x x
            x x x x x x x x x
            x x x x x x x x x
            x x x x x x x x x
            */
            Map_CurrentLayout = new MapTileType[,] {
                {MapTileType.blocked, MapTileType.blocked, MapTileType.blocked, MapTileType.blocked, MapTileType.blocked, MapTileType.blocked, MapTileType.blocked, MapTileType.blocked, MapTileType.blocked}, 
                {MapTileType.blocked, MapTileType.blocked, MapTileType.battle, MapTileType.battle, MapTileType.blocked, MapTileType.blocked, MapTileType.blocked, MapTileType.blocked, MapTileType.blocked}, 
                {MapTileType.blocked, MapTileType.blocked, MapTileType.blocked, MapTileType.battle, MapTileType.battle, MapTileType.blocked, MapTileType.blocked, MapTileType.blocked, MapTileType.blocked},
                {MapTileType.blocked, MapTileType.blocked, MapTileType.blocked, MapTileType.battle, MapTileType.blocked, MapTileType.blocked, MapTileType.blocked, MapTileType.blocked, MapTileType.blocked},
                {MapTileType.blocked, MapTileType.start, MapTileType.battle, MapTileType.battle, MapTileType.next_level, MapTileType.blocked, MapTileType.blocked, MapTileType.blocked, MapTileType.blocked},
                {MapTileType.blocked, MapTileType.blocked, MapTileType.blocked, MapTileType.battle, MapTileType.blocked, MapTileType.blocked, MapTileType.blocked, MapTileType.blocked, MapTileType.blocked},
                {MapTileType.blocked, MapTileType.blocked, MapTileType.blocked, MapTileType.blocked, MapTileType.blocked, MapTileType.blocked, MapTileType.blocked, MapTileType.blocked, MapTileType.blocked},
                {MapTileType.blocked, MapTileType.blocked, MapTileType.blocked, MapTileType.blocked, MapTileType.blocked, MapTileType.blocked, MapTileType.blocked, MapTileType.blocked, MapTileType.blocked}, 
                {MapTileType.blocked, MapTileType.blocked, MapTileType.blocked, MapTileType.blocked, MapTileType.blocked, MapTileType.blocked, MapTileType.blocked, MapTileType.blocked, MapTileType.blocked}, 
            };
            Map_CharacterPos = new Vector2(4, 1);
            break;
        }
    }
}

public enum MapTileType
{
    start,
    blocked,
    walkable,
    battle,
    next_level
}
