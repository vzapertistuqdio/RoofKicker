using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunState : MonoBehaviour,IState
{
    public float Speed { get => speed; }
    private float speed = 3f;
    public RunState(Animator playerAnim)
    {
        playerAnim.SetBool("isAttack",false);
    }

    public bool CheckIsDamage()
    {
        return false;
    }
}
