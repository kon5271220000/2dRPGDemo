using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Entity
{
    [Header("Move variables")]
    public float walkSpeed = 2f;
    public float idleTime = 2f;
    public float battleTime = 4f;

    [Header("Attack variables")]
    public float attackDistance;
    public float attackCooldonw;
    public float lastTimeAttack;

    [Header("Stun Variables")]
    public float stunDuration;
    public Vector2 stunDirection;
    protected bool canBeStun;
    [SerializeField] protected GameObject counterImage;

    [SerializeField] protected LayerMask playerLayer;

    public EnemyStateMachine stateMachine { get; private set; }
    public string lastAnimBoolName {  get; private set; }


    protected override void Awake()
    {
        base.Awake();

        stateMachine = new EnemyStateMachine();
    }


    // Update is called once per frame
    protected override void Update()
    {
        base.Update();

        stateMachine.currentState.Update();


    }

    public virtual void AssignLastAnimBoolName(string animBoolName)
    {
        lastAnimBoolName = animBoolName;

    }

    public virtual RaycastHit2D PlayerDetected() => Physics2D.Raycast(wallCheck.position, Vector2.right * FacingDirection, 50, playerLayer);

    public virtual void AnimationFinishTrigger() => stateMachine.currentState.AnimationFinishTrigger();

    public virtual void OpenCounterAttackWindow()
    {
        canBeStun = true;
        counterImage.SetActive(true);
    }

    public virtual void CloseCounterAttackWindow()
    {
        canBeStun = false;
        counterImage.SetActive(false);
    }

    public virtual bool CanBeStun()
    {
        if (canBeStun)
        {
            CloseCounterAttackWindow();
            return true;
        }
        return false;
    }
}
