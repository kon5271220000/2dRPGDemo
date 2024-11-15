using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NaginataEnemyGroundedState : EnemyStates
{
    protected Transform player;
    protected NaginataEnemy enemy;
    public NaginataEnemyGroundedState(Enemy enemyBase, EnemyStateMachine stateMachine, string animBoolName, NaginataEnemy enemy) : base(enemyBase, stateMachine, animBoolName)
    {
        this.enemy = enemy;
    }

    public override void Enter()
    {
        base.Enter();

        player = PlayerManager.instance.player.transform;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();

        if (enemy.PlayerDetected() || Vector2.Distance(enemy.transform.position, player.position) < 2)
        {
            stateMachine.ChangeState(enemy.Battle);
        }
    }
}
