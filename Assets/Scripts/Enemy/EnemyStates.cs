using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStates 
{
    protected EnemyStateMachine stateMachine;
    protected Enemy enemyBase;
    private string animBoolName;

    protected bool triggerCalled;
    protected float stateTimer;


    public EnemyStates(Enemy enemyBase, EnemyStateMachine stateMachine, string animBoolName)
    {
        this.enemyBase = enemyBase;
        this.stateMachine = stateMachine;
        this.animBoolName = animBoolName;
    }

    public virtual void Enter()
    {
        triggerCalled = false;

        enemyBase.anim.SetBool(animBoolName, true);
    }

    public virtual void Update() 
    {
        stateTimer -= Time.deltaTime;
    }

    public virtual void Exit() 
    {
        enemyBase.anim.SetBool(animBoolName, false);
        enemyBase.AssignLastAnimBoolName(animBoolName);
    }

    public virtual void AnimationFinishTrigger()
    {
        triggerCalled = true;
    }
}
