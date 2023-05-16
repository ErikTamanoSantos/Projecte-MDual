using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameState State;

    public static event Action<GameState> OnGameStateChanged;

    [SerializeField] public List<GameObject> unitPrefabs;

    void Awake() {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateGameState(GameState newState) {
        State = newState;

        switch (newState) {
            case GameState.PreparingBattle:
                break;
            case GameState.BattleStarted:
                break;
            case GameState.BattleWon:
                break;
            case GameState.BattleLost:
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(newState), newState, null);
        }

        OnGameStateChanged?.Invoke(newState);
    }
}

public enum GameState
{
    PreparingBattle,
    BattleStarted,
    BattleWon,
    BattleLost
}