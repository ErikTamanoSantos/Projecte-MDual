using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GridMap : MonoBehaviour
{
    [SerializeField] private int width, height; 
    [SerializeField] private MapTile tilePrefab;
    [SerializeField] private Transform cam;
    [SerializeField] private GameObject character;

    private Dictionary<Vector2, MapTile> tiles;

    public static GridMap Instance;

    private static Vector2 characterPos = new Vector2(3, 2);

    void Awake() {
        Instance = this;
        GenerateGrid();
        character.transform.position = new Vector3(characterPos.x, characterPos.y, -1);

        
    }

    void Update() {

    }

    void GenerateGrid() {
        tiles = new Dictionary<Vector2, MapTile>();
        for (int y = 2; y < 8; y++) {
            var spawnedTile = Instantiate(tilePrefab, new Vector3(3, y), Quaternion.identity);
            spawnedTile.name = $"Tile {0} {y}";
            spawnedTile.setPosition(new Vector2(3, y));
            tiles[new Vector2(3, y)] = spawnedTile;
        }

        cam.transform.position = new Vector3((float) width/2 -0.5f, (float) height/2 -0.5f, -10);
    }

    public MapTile getTile(Vector2 pos) {
        if (tiles.TryGetValue(pos, out var tile)) {
            return tile;
        }
        return null;
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
                if (tiles.ContainsKey(new Vector2(characterPos.x, characterPos.y + 1))) {
                    characterPos = new Vector2(characterPos.x, characterPos.y + 1);
                    character.transform.position = new Vector3(character.transform.position.x, character.transform.position.y + 1, -1);
                }
                break;
            case Directions.down:
                if (tiles.ContainsKey(new Vector2(characterPos.x, characterPos.y - 1))) {
                    characterPos = new Vector2(characterPos.x, characterPos.y - 1);
                    character.transform.position = new Vector3(character.transform.position.x, character.transform.position.y - 1, -1);
                }
                break;
            case Directions.left:
                if (tiles.ContainsKey(new Vector2(characterPos.x - 1, characterPos.y))) {
                    characterPos = new Vector2(characterPos.x - 1, characterPos.y);
                    character.transform.position = new Vector3(character.transform.position.x - 1, character.transform.position.y, -1);
                }
                break;
            case Directions.right:
                if (tiles.ContainsKey(new Vector2(characterPos.x + 1, characterPos.y))) {
                    characterPos = new Vector2(characterPos.x + 1, characterPos.y);
                    character.transform.position = new Vector3(character.transform.position.x + 1, character.transform.position.y, -1);
                }
                break;
        }

        if (characterPos == new Vector2(3, 7)) {
            SceneManager.LoadScene("BattleScene");
        }
    }
}

public enum Directions {
    up,
    down,
    left,
    right
}
