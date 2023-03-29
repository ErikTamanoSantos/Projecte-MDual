using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    public static BattleManager Instance;

    private List<CharacterController> playerUnits = new List<CharacterController>();

    private List<CharacterController> enemyUnits = new List<CharacterController>();

    private bool battleStarted;

    void Awake() {
        Instance = this;
        GameManager.OnGameStateChanged += OnGameStateChanged;
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
                break;
            case GameState.BattleLost:
                break;
        }
    }

    void StartBattle() {
        battleStarted = true;
    }

    public void removePlayerUnit(CharacterController unit) {
        playerUnits.Remove(unit);
        if (playerUnits.Count == 0) {
            GameManager.Instance.UpdateGameState(GameState.BattleLost);
        }
    }

    public void removeEnemyUnit(CharacterController unit) {
        enemyUnits.Remove(unit);
        if (enemyUnits.Count == 0) {
            GameManager.Instance.UpdateGameState(GameState.BattleWon);
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
}