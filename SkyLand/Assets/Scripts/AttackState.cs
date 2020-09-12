using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class AttackState : MonoBehaviour, IState
{
    public float Speed { get => speed; }
    private float speed = 4f;
    public AttackState(Animator playerAnim)
    {
        playerAnim.SetBool("isAttack",true);
    }

    public bool CheckIsDamage()
    {
        return true;
    }
}
