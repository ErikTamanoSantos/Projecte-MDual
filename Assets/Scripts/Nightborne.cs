using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nightborne : CharacterController
{
    int AtkCount = 0;
    public void Attack() {
        AtkCount++;
        if (AtkCount == 3) {
            currentHP += currentMAG/3;
            AtkCount = 0;
        }
        base.Attack();
    }
}
