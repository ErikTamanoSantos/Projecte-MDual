using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class BattleManager : MonoBehaviour
{
    public static BattleManager Instance;

    [SerializeField] public List<GameObject> playerPositions = new List<GameObject>();
    public List<CharacterController> playerUnits = new List<CharacterController>();
    [SerializeField] public List<TextMeshProUGUI> playerHPBars = new List<TextMeshProUGUI>();
    [SerializeField] public List<Image> playerHPIcons = new List<Image>();

    [SerializeField] public List<GameObject> enemyPositions = new List<GameObject>();
    [SerializeField] public List<CharacterController> enemyUnits = new List<CharacterController>();
    [SerializeField] public List<TextMeshProUGUI> enemyHPBars = new List<TextMeshProUGUI>();
    [SerializeField] public List<Image> enemyHPIcons = new List<Image>();

    [SerializeField] private TextMeshProUGUI BattleEnd_Title, BattleEnd_Description;

    [SerializeField] private GameObject BattleEnd_bg, BattleEnd_TitleBg;

    [SerializeField] GameObject prefab_nightborne, prefab_necromancer;

    [SerializeField] Button exit_button;

    private bool battleStarted;

    public Side currentTurn;

    void Awake() {
        for (int i = 0; i < GameData.Party_ActiveParty.Count; i++) {
            if (GameData.Party_ActiveParty[i].name == "nightborne") {
                GameObject nightborne = (GameObject) Instantiate(prefab_nightborne);
                var nightborneController = nightborne.GetComponent<CharacterController>();
                nightborneController.data = GameData.Party_ActiveParty[i];
                nightborneController.side = Side.player;
                nightborneController.orderPosition = i;
                nightborneController.setStats();
                playerUnits.Add(nightborneController);
            } else if (GameData.Party_ActiveParty[i].name == "necromancer") {
                GameObject necromancer = (GameObject) Instantiate(prefab_necromancer);
                var necromancerController = necromancer.GetComponent<CharacterController>();
                necromancerController.data = GameData.Party_ActiveParty[i];
                necromancerController.side = Side.player;
                necromancerController.orderPosition = i;
                necromancerController.setStats();
                playerUnits.Add(necromancerController);
            }
        }
        BattleEnd_bg.SetActive(false);
        BattleEnd_TitleBg.SetActive(false);
        BattleEnd_Title.enabled = false;
        BattleEnd_Description.enabled = false;
        exit_button.gameObject.SetActive(false);
        Instance = this;
        GameManager.OnGameStateChanged += OnGameStateChanged;
        Debug.Log(playerPositions.Count - playerUnits.Count);
        for (int i = 0; i < playerUnits.Count; i++) {
            playerUnits[i].transform.position =  new Vector3 (playerPositions[i].transform.position.x, playerPositions[i].transform.position.y, playerUnits[i].transform.position.z);
        }
        for (int i = 0; i < enemyUnits.Count; i++) {
            enemyUnits[i].transform.position =  new Vector3 (enemyPositions[i].transform.position.x, enemyPositions[i].transform.position.y, enemyUnits[i].transform.position.z);
        }
        for (int i = 0; i <= playerPositions.Count - playerUnits.Count; i++) {
            playerUnits.Add(null);
        }
        for (int i = 0; i <= enemyPositions.Count - enemyUnits.Count; i++) {
            enemyUnits.Add(null);
        }
    }

     void Update()
    {
        if (GameManager.Instance.State != GameState.BattleWon && GameManager.Instance.State != GameState.BattleLost) {
            for (int i = 0; i < playerUnits.Count; i++) {
                if (playerUnits[i] != null) {
                    playerHPIcons[i].enabled = true;
                    playerHPBars[i].text = "" + playerUnits[i].currentHP;
                } else {
                    playerHPBars[i].text = "";
                    playerHPIcons[i].enabled = false;
                }
            }
            for (int i = 0; i < enemyUnits.Count; i++) {
                if (enemyUnits[i] != null) {
                    enemyHPIcons[i].enabled = true;
                    enemyHPBars[i].text = "" + enemyUnits[i].currentHP;
                } else {
                    enemyHPIcons[i].enabled = false;
                    enemyHPBars[i].text = "";
                }
            }
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
                BattleEnd_Title.text = "VICTORY!";
                for (int i = 0; i < playerHPBars.Count; i++) {
                    playerHPBars[i].enabled = false;
                }
                for (int i = 0; i < playerHPIcons.Count; i++) {
                    playerHPIcons[i].enabled = false;
                }
                for (int i = 0; i < enemyHPBars.Count; i++) {
                    enemyHPBars[i].enabled = false;
                }
                for (int i = 0; i < enemyHPIcons.Count; i++) {
                    enemyHPIcons[i].enabled = false;
                }
                exit_button.gameObject.SetActive(true);
                BattleEnd_bg.SetActive(true);
                BattleEnd_TitleBg.SetActive(true);
                BattleEnd_Title.enabled = true;
                BattleEnd_Description.enabled = true;
                for (int i = 0; i < playerUnits.Count; i++) {
                    if (playerUnits[i] != null) {
                        playerUnits[i].data.currentXP += 10;
                        if (playerUnits[i].data.currentXP >= 100) {
                            playerUnits[i].data.currentXP -= 100;
                            playerUnits[i].data.currentLvl++;
                            BattleEnd_Description.text += playerUnits[i].data.name + " leveled up!\n";
                        } else {
                            BattleEnd_Description.text += playerUnits[i].data.name + " gained 10 XP\n";   
                        }
                        Debug.Log("EXP: " + playerUnits[i].data.currentLvl + " " + playerUnits[i].data.currentXP);
                    }
                }
                GameData.Map_CurrentLayout[(int) GameData.Map_CharacterPos.x, (int) GameData.Map_CharacterPos.y] = MapTileType.walkable;
                exit_button.onClick.AddListener(delegate{saveAndReturnToMap();});
                //SceneManager.LoadScene("MapScene");
                break;
            case GameState.BattleLost:
                BattleEnd_Title.text = "DEFEAT!";
                for (int i = 0; i < playerHPBars.Count; i++) {
                    playerHPBars[i].enabled = false;
                }
                for (int i = 0; i < playerHPIcons.Count; i++) {
                    Debug.Log("ICON");
                    playerHPIcons[i].enabled = false;
                }
                for (int i = 0; i < enemyHPBars.Count; i++) {
                    enemyHPBars[i].enabled = false;
                }
                for (int i = 0; i < enemyHPIcons.Count; i++) {
                    enemyHPIcons[i].enabled = false;
                }
                exit_button.gameObject.SetActive(true);
                BattleEnd_bg.SetActive(true);
                BattleEnd_TitleBg.SetActive(true);
                BattleEnd_Title.enabled = true;
                BattleEnd_Description.enabled = true;
                exit_button.onClick.AddListener(delegate{GameObject.FindGameObjectWithTag("StartScreenMusic").GetComponent<MusicPlayer>().playMusic(); SceneManager.LoadScene("LoginScene");});
                //SceneManager.LoadScene("MapScene");
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
                playerUnits[i].transform.position = new Vector3 (playerPositions[i].transform.position.x, playerPositions[i].transform.position.y, playerUnits[i].transform.position.z);
                playerUnits[i].orderPosition--;
                break;
            }
        }
        if (emptyParty) {
            GameManager.Instance.UpdateGameState(GameState.BattleLost);
            Debug.Log("LOSE");
        } else {
            resetTurns();
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
        } else {
            resetTurns();
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
        Debug.Log("bef: " + currentTurn);
        if (currentTurn == Side.player) {
            currentTurn = Side.enemy;
        } else {
            currentTurn = Side.player;
        }
        Debug.Log("aft: " +currentTurn);
    }

    public void resetTurns() {
        if (playerUnits[0].currentATKSPD > enemyUnits[0].currentATKSPD) {
            currentTurn = Side.player;
        } else {
            currentTurn = Side.enemy;
        }
        playerUnits[0].changeState(CharacterState.standby);
        enemyUnits[0].changeState(CharacterState.standby);
    }

    void saveAndReturnToMap() {
        GameObject.FindGameObjectWithTag("clickSound").GetComponent<ButtonClickSound>().playSound();
        for (int i = 0; i < playerUnits.Count; i++) {
            if (playerUnits[i] != null) {
                StartCoroutine(UtilsServer.saveUnitData(playerUnits[i].data.name, GameData.userId, playerUnits[i].data.currentXP, playerUnits[i].data.currentLvl));
            }
        }
        GameObject.FindGameObjectWithTag("MapScreenMusic").GetComponent<MusicPlayer>().playMusic();
        SceneManager.LoadScene("MapScene");
    }

}