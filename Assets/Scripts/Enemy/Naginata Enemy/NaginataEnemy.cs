using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NaginataEnemy : Enemy
{
   

    #region States
    public NaginataEnemyIdleState Idle { get; private set; }
    public NaginataEnemyWalkState Walk { get; private set; }
    public NaginataEnemyBattleState Battle { get; private set; }
    public NaginataEnemyAttackState Attack { get; private set; }
    public NaginataEnemyStunState Stun { get; private set; }
    public NaginataEnemyDeathState Death { get; private set; }
    #endregion

    protected override void Awake()
    {
        base.Awake();

        Idle = new NaginataEnemyIdleState(this, stateMachine, "idle", this);
        Walk = new NaginataEnemyWalkState(this, stateMachine, "walk", this);
        Battle = new NaginataEnemyBattleState(this, stateMachine, "walk", this);
        Attack = new NaginataEnemyAttackState(this, stateMachine, "attack", this);
        Stun = new NaginataEnemyStunState(this, stateMachine, "stun", this);
        Death = new NaginataEnemyDeathState(this, stateMachine, "idle", this);
    }

    protected override void Start()
    {
        base.Start();

        stateMachine.Initialize(Idle);
    }

    protected override void Update()
    {
        base.Update();

        if (Input.GetKeyDown(KeyCode.U))
        {
            stateMachine.ChangeState(Stun);
        }
    }

    protected override void OnDrawGizmos()
    {
        base.OnDrawGizmos();

        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.position, new Vector3(transform.position.x + attackDistance * FacingDirection, transform.position.y));
    }

    public override bool CanBeStun()
    {
        if (base.CanBeStun()) 
        {
            stateMachine.ChangeState(Stun);
            return true;
        }
        return false;
    }

    public override void Die()
    {
        base.Die();

        stateMachine.ChangeState(Death);
    }
}
