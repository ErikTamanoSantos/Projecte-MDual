using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    CharacterData data;
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

    private CharacterState characterState;

    [SerializeField] private Side side;

    private CharacterController target;

    private bool targetable;

    private float timeToAttack;

    public int orderPosition;

    private bool isPressed = false;

    private Animator playerAnim;

    private float lastPositionX, lastPositionY;
    
    // Start is called before the first frame update
    void Start()
    {
        playerAnim = GetComponent<Animator>();
        // for (int x = 0; x < GridManager.Instance.getWidth(); x++) {
        //     for (int y = 0; y < GridManager.Instance.getHeight(); y++) {
        //         Tile curTile = GridManager.Instance.getTile(new Vector2(x, y));
        //         possibleTile.Add(curTile, !curTile.isOccupied());
        //     }
        // }

        currentHP = maxHP;
        currentMP = maxMP;
        currentATK = baseATK;
        currentMAG = baseMAG;
        currentATKSPD = baseATKSPD;
        currentMOVSPD = baseMOVSPD;
        currentRange = baseRange;
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
                    if (BattleManager.Instance.currentTurn == side && orderPosition == 0) {
                        changeState(CharacterState.attacking);
                    }
                    // if (target == null) 
                    // {
                    //     List<CharacterController> targets;
                    //     if (side == 0) {
                    //         targets = BattleManager.Instance.getEnemyUnits();
                    //     } else {
                    //         targets = BattleManager.Instance.getPlayerUnits();
                    //     }
                    //     for (int i = 0; i < targets.Count; i++) {
                    //         if (
                    //             target == null || 
                    //             Vector3.Distance(this.transform.position, target.transform.position) > Vector3.Distance(this.transform.position, targets[i].transform.position)) 
                    //             {
                    //                 target = targets[i];
                    //         }
                    //     }
                    //     if ((this.position.x - target.getPosition().x + this.position.y - target.getPosition().y) > baseRange) {
                    //         if (this.position.y < target.getPosition().y) {
                    //         bool pathFound = false;
                    //         while (pathFound) {
                    //             if (route.Count == 0) {

                    //                 if (possibleTile[GridManager.Instance.getTile(new Vector2(this.position.x, this.position.y + (this.position.y > target.getPosition().y ? -1 : 1)))]) {
                    //                     route.Add(GridManager.Instance.getTile(new Vector2(this.position.x, this.position.y + (this.position.y > target.getPosition().y ? -1 : 1))));
                    //                 } else if (possibleTile[GridManager.Instance.getTile(new Vector2(this.position.x + (this.position.x > target.getPosition().x ? -1 : 1), this.position.y))]) {
                    //                     route.Add(GridManager.Instance.getTile(new Vector2(this.position.x + (this.position.x > target.getPosition().x ? -1 : 1), this.position.y)));
                    //                 } else if (possibleTile[GridManager.Instance.getTile(new Vector2(this.position.x + (this.position.x > target.getPosition().x ? 1 : -1), this.position.y))]) {
                    //                     route.Add(GridManager.Instance.getTile(new Vector2(this.position.x + (this.position.x > target.getPosition().x ? 1 : -1), this.position.y)));
                    //                 } else if (possibleTile[GridManager.Instance.getTile(new Vector2(this.position.x + (this.position.x > target.getPosition().x ? 1 : -1), this.position.y))]) {
                    //                     route.Add(GridManager.Instance.getTile(new Vector2(this.position.x, (this.position.y > target.getPosition().y ? 1 : -1))));
                    //                 }
                                    
                    //             } else if(route[route.Count-1].getPosition().x - target.getPosition().x + route[route.Count-1].getPosition().y - target.getPosition().y < baseRange) {
                    //                 changeState(CharacterState.walking);
                    //                 pathFound = true;
                    //             } else {
                    //                 if (possibleTile[GridManager.Instance.getTile(new Vector2(route[route.Count - 1].getPosition().x, route[route.Count - 1].getPosition().y + (route[route.Count - 1].getPosition().y > target.getPosition().y ? -1 : 1)))]) {
                    //                     /*if (GridManager.Instance.getTile(new Vector2(route[route.Count - 1].getPosition().x, route[route.Count - 1].getPosition().y + (route[route.Count - 1].position.y > target.getPosition().y ? -1 : 1))).Equals(route[route.Count - 1])) {
                    //                         possibleTile[GridManager.Instance.getTile(new Vector2(route[route.Count - 1].getPosition().x, route[route.Count - 1].getPosition().y + (route[route.Count - 1].position.y > target.getPosition().y ? -1 : 1)))] = false;
                                            
                    //                     } else {
                    //                     }*/
                    //                 } else if (possibleTile[GridManager.Instance.getTile(new Vector2(this.position.x + (this.position.x > target.getPosition().x ? -1 : 1), this.position.y))]) {
                    //                     route.Add(GridManager.Instance.getTile(new Vector2(this.position.x + (this.position.x > target.getPosition().x ? -1 : 1), this.position.y)));
                    //                 } else if (possibleTile[GridManager.Instance.getTile(new Vector2(this.position.x + (this.position.x > target.getPosition().x ? 1 : -1), this.position.y))]) {
                    //                     route.Add(GridManager.Instance.getTile(new Vector2(this.position.x + (this.position.x > target.getPosition().x ? 1 : -1), this.position.y)));
                    //                 } else if (possibleTile[GridManager.Instance.getTile(new Vector2(this.position.x + (this.position.x > target.getPosition().x ? 1 : -1), this.position.y))]) {
                    //                     route.Add(GridManager.Instance.getTile(new Vector2(this.position.x, (this.position.y > target.getPosition().y ? 1 : -1))));
                    //                 }
                    //             }
                    //         }   
                    //     }
                    //         changeState(CharacterState.walking);
                    //     } else {
                    //         timeToAttack = Time.time + 1/currentATKSPD;
                    //         changeState(CharacterState.attacking);
                    //     }
                    // }
                    break;
                // case CharacterState.walking:
                //     if ((this.position.x - target.getPosition().x + this.position.y - target.getPosition().y) > baseRange) {
                //         timeToAttack = Time.time + 1/currentATKSPD;
                //         changeState(CharacterState.attacking);
                //     } else {
                //     }
                //     break;
                case CharacterState.attacking:
                    // Wait for the current animation to finish
                    playerAnim.SetBool("Attacking", true);
                    break;
                case CharacterState.dead:
                    if (side == Side.player) {
                        BattleManager.Instance.removePlayerUnit(this);
                    } else {
                        BattleManager.Instance.removeEnemyUnit(this);
                    }
                    UnityEngine.Object.Destroy(gameObject);
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
                        // if (positionY < 0 || positionX < 0 || positionY > 8 || positionX > 16 || GridManager.Instance.getTile(new Vector2(positionX, positionY)).isOccupied()) {
                        //     this.transform.position = this.position;
                        // } else {
                        //     GridManager.Instance.getTile(this.position).setOccupied(false);
                        //     this.transform.position = new Vector2(positionX, positionY);
                        //     this.position = new Vector2((float) Math.Round(worldPosition.x), (float) Math.Round(worldPosition.y));
                        //     GridManager.Instance.getTile(this.position).setOccupied(true);
                        // }
                        // isPressed = false;
                        // isBeingDragged?.Invoke(false);
                    }
                }
            }
        }
        
    }

    void changeState(CharacterState newState) 
    {
        Debug.Log(newState);
        characterState = newState;
    }

    public void takeDMG(int dmg) 
    {
        currentHP -= dmg;
        Debug.Log(side + " took " + dmg + ", current HP " + currentHP);
        if (currentHP <= 0) {
            changeState(CharacterState.dead);
        } else {
            BattleManager.Instance.changeTurn();
        }
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
        changeState(CharacterState.standby);
        if (side == Side.player) {
            BattleManager.Instance.enemyUnits[0].takeDMG(currentATK);
        } else {
            BattleManager.Instance.playerUnits[0].takeDMG(currentATK);
        }
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
    walking,
    attacking,
    casting,
    dead
}