using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public CharacterData data;
    [SerializeField] private int maxHP;
    [SerializeField] private int maxMP;
    [SerializeField] private int baseATK;
    [SerializeField] private int baseMAG;
    [SerializeField] private float baseATKSPD;
    [SerializeField] private float baseMOVSPD;
    [SerializeField] private int baseRange;
    [SerializeField] private int BattleOrder;

    public int currentHP;
    public int currentMP;
    public int currentATK;
    public int currentMAG;
    public float currentATKSPD;
    public float currentMOVSPD;
    public int currentRange;

    public static event Action<bool> isBeingDragged;

    private Vector2 position;
    private Vector2 targetPosition;

    public CharacterState characterState;

    [SerializeField] public Side side;

    private CharacterController target;

    private bool targetable;

    private float timeToAttack;

    public int orderPosition;

    private bool isPressed = false;

    private Animator playerAnim;

    private float lastPositionX, lastPositionY;
    int counter = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        if (side == Side.enemy) {
            maxHP = 25+(10*(GameData.currentLevel-1));
            currentHP = 25+(10*(GameData.currentLevel-1));
            currentATK = 3+(7*(GameData.currentLevel-1));
            currentMAG = 3+(7*(GameData.currentLevel-1));
            currentATKSPD = 4f+(4*(GameData.currentLevel-1));
        }
        playerAnim = GetComponent<Animator>();
        // for (int x = 0; x < GridManager.Instance.getWidth(); x++) {
        //     for (int y = 0; y < GridManager.Instance.getHeight(); y++) {
        //         Tile curTile = GridManager.Instance.getTile(new Vector2(x, y));
        //         possibleTile.Add(curTile, !curTile.isOccupied());
        //     }
        // }
        changeState(CharacterState.standby);
        if (side == Side.enemy) {
            this.transform.localScale = new Vector3(-(this.transform.localScale.x), this.transform.localScale.y, this.transform.localScale.z);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.State == GameState.BattleStarted) {
            switch (characterState)
            {
                case CharacterState.standby:
                    playerAnim.SetBool("Attacking", false);
                    playerAnim.SetBool("Hurt", false);
                    if (BattleManager.Instance.currentTurn == side && orderPosition == 0) {
                        changeState(CharacterState.attacking);
                    }
                    break;
                case CharacterState.attacking:
                    // Wait for the current animation to finish
                    playerAnim.SetBool("Attacking", true);
                    if (side == Side.player) {
                        BattleManager.Instance.enemyUnits[0].changeState(CharacterState.hurt);
                    } else {
                        BattleManager.Instance.playerUnits[0].changeState(CharacterState.hurt);
                    }
                    BattleManager.Instance.changeTurn();
                    changeState(CharacterState.waiting);
                    break;
                case CharacterState.hurt:
                    playerAnim.SetBool("Attacking", false);
                    break;
                case CharacterState.waiting:
                    break;
                case CharacterState.dead:
                    playerAnim.SetBool("Dead", true);
                    break;
            }
        } else {
            if (side == Side.player) {
                Vector3 mousePos = Input.mousePosition;
                Vector2 screenPosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
                Vector2 worldPosition = Camera.main.ScreenToWorldPoint(screenPosition);
                if (Input.GetMouseButtonDown(0)) {
                    //Vector3 mousePos = Input.mousePosition;
                    //Vector2 screenPosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
                    //Vector2 worldPosition = Camera.main.ScreenToWorldPoint(screenPosition);
                    lastPositionX = this.transform.position.x;
                    lastPositionY = this.transform.position.y;
                    if (Math.Round(worldPosition.x) == Math.Round(this.transform.position.x) && Math.Round(worldPosition.y) == Math.Round(this.transform.position.y)) {
                        isPressed = true;
                        isBeingDragged?.Invoke(true);
                    }
                }
                if (isPressed) {
                    if (Input.GetMouseButton(0)) {
                        // Agafa la posició del mouse en l'escena
                        mousePos.z = 5.23f;
                        this.transform.position = (worldPosition);
                    } else {
                        var positionX = (float) Math.Round(worldPosition.x);
                        var positionY = (float) Math.Round(worldPosition.y);
                        var validPosition = false;
                        for (int i = 0; i < BattleManager.Instance.playerPositions.Count; i++) {
                            if (positionX == Math.Round(BattleManager.Instance.playerPositions[i].transform.position.x) && positionY == Math.Round(BattleManager.Instance.playerPositions[i].transform.position.y)) {
                                BattleManager.Instance.swapPlayerUnits(orderPosition, i);
                                validPosition = true;
                                break;
                            }
                        }
                        if (!validPosition) {
                            this.transform.position = new Vector3(lastPositionX, lastPositionY, this.transform.position.z);
                        }
                        isPressed = false;
                    }
                }
            }
        }
        
    }

    public void changeState(CharacterState newState) 
    {
        if (this.characterState != newState) {
            if (this.side == Side.enemy) {
                Debug.Log(counter + " " + newState);
                counter++;
            }
        characterState = newState;
        }
    }

    public void takeDMG(int dmg) 
    {
        currentHP -= dmg;
        if (currentHP <= 0) {
            changeState(CharacterState.dead);
        } else {
            playerAnim.SetBool("Hurt", true);
        }
    }

    void finishHurtAnim() {
        playerAnim.SetBool("Hurt", false);
        changeState(CharacterState.standby);
    }

    public bool isTargetable()
    {
        return targetable;
    }

    public Side getSide()
    {
        return side;
    }

    public void Attack() {
        playerAnim.SetBool("Attacking", false);
        if (side == Side.player) {
            BattleManager.Instance.enemyUnits[0].takeDMG(currentATK);
        } else {
            BattleManager.Instance.playerUnits[0].takeDMG(currentATK);
        }
    }

    void Die() {
        if (side == Side.player) {
            BattleManager.Instance.removePlayerUnit(this);
        } else {
            BattleManager.Instance.removeEnemyUnit(this);
        }
        UnityEngine.Object.Destroy(gameObject);
    }

    public void setStats() {
        currentHP = data.currentHP;
        currentMP = 0;
        currentATK = data.baseATK;
        currentMAG = data.baseMAG;
        currentATKSPD = data.baseATKSPD;
        currentMOVSPD = data.baseMOVSPD;
        currentRange = data.baseRange;
    }
}

public enum Side
{
    player,
    enemy
}

public enum CharacterState
{
    standby,
    hurt,
    attacking,
    casting,
    waiting,
    dead
}