using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BattleManager : MonoBehaviour
{
    public static BattleManager Instance;

    [SerializeField] public List<GameObject> playerPositions = new List<GameObject>();
    [SerializeField] public List<CharacterController> playerUnits = new List<CharacterController>();

    [SerializeField] public List<GameObject> enemyPositions = new List<GameObject>();
    [SerializeField] public List<CharacterController> enemyUnits = new List<CharacterController>();

    private bool battleStarted;

    public Side currentTurn;

    void Awake() {
        Instance = this;
        GameManager.OnGameStateChanged += OnGameStateChanged;
        Debug.Log(playerPositions.Count - playerUnits.Count);
        for (int i = 0; i <= playerPositions.Count - playerUnits.Count; i++) {
            playerUnits.Add(null);
        }
        for (int i = 0; i <= enemyPositions.Count - enemyUnits.Count; i++) {
            enemyUnits.Add(null);
        }
    }

    void OnDestroy() {
        GameManager.OnGameStateChanged -= OnGameStateChanged;
    }

    void OnGameStateChanged(GameState state) {
        switch (state) {
            case GameState.PreparingBattle:
                break;
            case GameState.BattleStarted:
                StartBattle();
                break;
            case GameState.BattleWon:
                SceneManager.LoadScene("MapScene");
                break;
            case GameState.BattleLost:
                SceneManager.LoadScene("MapScene");
                break;
        }
    }

    void StartBattle() {
        battleStarted = true;
        if (playerUnits[0].currentATKSPD > enemyUnits[0].currentATKSPD) {
            currentTurn = Side.player;
        } else {
            currentTurn = Side.enemy;
        }
    }

    public void removePlayerUnit(CharacterController unit) {
        playerUnits.Remove(unit);
        var emptyParty = true;
        for (int i = 0; i < playerUnits.Count; i++) {
            if (playerUnits[i] != null) {
                emptyParty = false;
                break;
            }
        }
        if (emptyParty) {
            GameManager.Instance.UpdateGameState(GameState.BattleLost);
            Debug.Log("LOSE");
        }
    }

    public void removeEnemyUnit(CharacterController unit) {
        enemyUnits.Remove(unit);
        Debug.Log(enemyUnits.Count);
        var emptyParty = true;
        for (int i = 0; i < enemyUnits.Count; i++) {
            if (enemyUnits[i] != null) {
                emptyParty = false;
                break;
            }
        }
        if (emptyParty) {
            GameManager.Instance.UpdateGameState(GameState.BattleWon);
            Debug.Log("WIN");
        }
    }

    public void addPlayerUnit(CharacterController unit) {
        playerUnits.Add(unit);
    }

    public void addEnemyUnit(CharacterController unit) {
        enemyUnits.Add(unit);
    }

    public List<CharacterController> getPlayerUnits() {
        return playerUnits;
    }

    public List<CharacterController> getEnemyUnits() {
        return enemyUnits;
    }

    public void swapPlayerUnits(int firstIndex, int secondIndex) {
        CharacterController firstUnit = playerUnits[firstIndex];
        Debug.Log("first: " + firstIndex + " second: " + secondIndex);
        if (playerUnits[secondIndex] == null) {
            for (int i = 0; i < playerUnits.Count; i++) {
                Debug.Log("first i " + i);
                if (playerUnits[i] == null) {
                    playerUnits[i] = firstUnit;
                    firstUnit.transform.position = new Vector3 (playerPositions[i].transform.position.x, playerPositions[i].transform.position.y, firstUnit.transform.position.z);
                    firstUnit.orderPosition = i;
                    break;
                }
            }
            advancePlayerteam(firstIndex);
        } else {
            CharacterController secondUnit = playerUnits[secondIndex];
            playerUnits[firstIndex] = secondUnit;
            playerUnits[secondIndex] = firstUnit;
            firstUnit.transform.position = new Vector3 (playerPositions[secondIndex].transform.position.x, playerPositions[secondIndex].transform.position.y, firstUnit.transform.position.z);
            secondUnit.transform.position = new Vector3 (playerPositions[firstIndex].transform.position.x, playerPositions[firstIndex].transform.position.y, secondUnit.transform.position.z);
            var firstPosition = firstUnit.orderPosition;
            var secondPosition = secondUnit.orderPosition;
            firstUnit.orderPosition = secondPosition;
            secondUnit.orderPosition = firstPosition;
            Debug.Log("1Pos: " + firstUnit.orderPosition + " 2Pos: " + secondUnit.orderPosition);
        }
    }

    public void advancePlayerteam(int startingPoint) {
        for (int i = startingPoint+1; i < playerUnits.Count; i++) {
            if (playerUnits[i] != null) {
                playerUnits[i].transform.position = new Vector3 (playerPositions[i-1].transform.position.x, playerPositions[i-1].transform.position.y, playerUnits[i].transform.position.z);
                playerUnits[i].orderPosition = i-1;
                playerUnits[i-1] = playerUnits[i];
                playerUnits[i] = null;
            }
        }
    }

    public void changeTurn() {
        if (currentTurn == Side.player) {
            currentTurn = Side.enemy;
        } else {
            currentTurn = Side.player;
        }
    }

}