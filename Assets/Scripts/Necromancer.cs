using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Necromancer : CharacterController
{
    int AtkCount = 0;
    public override void changeState(CharacterState newState) {
        if (this.characterState != newState && newState == CharacterState.attacking) {
            AtkCount++;
            Debug.Log("Abt " + AtkCount);
            if (AtkCount == 4) {
                AtkCount = 0;
                playerAnim.SetBool("Casting", true);
                Debug.Log("YES");
                if (side == Side.player) {
                    BattleManager.Instance.enemyUnits[0].changeState(CharacterState.hurt);
                } else {
                    BattleManager.Instance.playerUnits[0].changeState(CharacterState.hurt);
                }
                BattleManager.Instance.changeTurn();
                changeState(CharacterState.waiting);
            } else {
                base.changeState(newState);
            }
        } else {
            base.changeState(newState);
        }
    }

    public void cast() {
        attackSound.Play();
        playerAnim.SetBool("Casting", false);
        if (side == Side.player) {
            BattleManager.Instance.enemyUnits[0].takeDMG(currentATK+currentMAG);
        } else {
            BattleManager.Instance.playerUnits[0].takeDMG(currentATK+currentMAG);
        }
    }

}
