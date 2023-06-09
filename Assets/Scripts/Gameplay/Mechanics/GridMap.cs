using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GridMap : MonoBehaviour
{
    [SerializeField] private int width, height; 
    [SerializeField] private MapTile tilePrefab;
    [SerializeField] private Transform cam;
    [SerializeField] private GameObject character;
    [SerializeField] private TextMeshProUGUI levelLabel;
    [SerializeField] private GameObject battleIcon, nextIcon;
    public static GridMap Instance;

    void Awake() {
        if (GameData.Map_CurrentLayout == null) {
            GameData.generateRandomMapLayout();
        }
        Instance = this;
        GenerateGrid();
        character.transform.position = new Vector3(GameData.Map_CharacterPos.x, GameData.Map_CharacterPos.y, character.transform.position.z);
        
    }

    void Update() {
        levelLabel.text = "Level " + GameData.currentLevel;
    }

    void GenerateGrid() {
        for (int x = 0; x < width; x++) {
            for (int y = 0; y < height; y++) {
                if (GameData.Map_CurrentLayout[x, y] != MapTileType.blocked) {
                    var spawnedTile = Instantiate(tilePrefab, new Vector3(x, y), Quaternion.identity);
                    spawnedTile.name = $"Tile {x} {y}";
                    spawnedTile.setPosition(new Vector2(x, y));
                    if (GameData.Map_CurrentLayout[x, y] == MapTileType.battle) {
                         var icon = Instantiate(battleIcon, new Vector3(x, y), Quaternion.identity);
                         icon.transform.position = new Vector2(x, y);
                    } else if (GameData.Map_CurrentLayout[x, y] == MapTileType.next_level) {
                         var icon = Instantiate(nextIcon, new Vector3(x, y), Quaternion.identity);
                         icon.transform.position = new Vector2(x, y);
                    }
                }
            }
        }
    }

    public int getWidth()
    {
        return width;
    }

    public int getHeight()
    {
        return height;
    }

    public void move(Directions dir) {
        switch (dir) {
            case Directions.up:
                if ((int) GameData.Map_CharacterPos.y + 1 < height && GameData.Map_CurrentLayout[(int) GameData.Map_CharacterPos.x, (int) GameData.Map_CharacterPos.y + 1] != MapTileType.blocked) {
                    GameData.Map_CharacterPos = new Vector2(GameData.Map_CharacterPos.x, GameData.Map_CharacterPos.y + 1);
                    character.transform.position = new Vector3(character.transform.position.x, character.transform.position.y + 1, -1);
                }
                break;
            case Directions.down:
                if ((int) GameData.Map_CharacterPos.y - 1 > -1 && GameData.Map_CurrentLayout[(int) GameData.Map_CharacterPos.x, (int) GameData.Map_CharacterPos.y - 1] != MapTileType.blocked) {
                    GameData.Map_CharacterPos = new Vector2(GameData.Map_CharacterPos.x, GameData.Map_CharacterPos.y - 1);
                    character.transform.position = new Vector3(character.transform.position.x, character.transform.position.y - 1, -1);
                }
                break;
            case Directions.left:
                if ((int) GameData.Map_CharacterPos.x - 1 > -1 && GameData.Map_CurrentLayout[(int) GameData.Map_CharacterPos.x - 1, (int) GameData.Map_CharacterPos.y] != MapTileType.blocked) {
                    GameData.Map_CharacterPos = new Vector2(GameData.Map_CharacterPos.x - 1, GameData.Map_CharacterPos.y);
                    character.transform.position = new Vector3(character.transform.position.x - 1, character.transform.position.y, -1);
                }
                break;
            case Directions.right:
                if ( (int) GameData.Map_CharacterPos.x + 1 < width && GameData.Map_CurrentLayout[(int) GameData.Map_CharacterPos.x + 1, (int) GameData.Map_CharacterPos.y] != MapTileType.blocked) {
                    GameData.Map_CharacterPos = new Vector2(GameData.Map_CharacterPos.x + 1, GameData.Map_CharacterPos.y);
                    character.transform.position = new Vector3(character.transform.position.x + 1, character.transform.position.y, -1);
                }
                break;
        }


        if (GameData.Map_CurrentLayout[(int) GameData.Map_CharacterPos.x, (int) GameData.Map_CharacterPos.y] == MapTileType.battle) {
            GameObject.FindGameObjectWithTag("BattleScreenMusic").GetComponent<MusicPlayer>().playMusic();
            SceneManager.LoadScene("BattleScene");
        } else if (GameData.Map_CurrentLayout[(int) GameData.Map_CharacterPos.x, (int) GameData.Map_CharacterPos.y] == MapTileType.next_level) {
            GameData.currentLevel++;
            GameData.generateRandomMapLayout();
            SceneManager.LoadScene("MapScene");
        }
    }
}

public enum Directions {
    up,
    down,
    left,
    right
}
