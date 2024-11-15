using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : CharacterStat
{
    public Enemy enemy;

    protected override void Start()
    {
        base.Start();
    }

    protected override void TakeDamge(int damage)
    {
        base.TakeDamge(damage);

        enemy.Damage();
    }

    protected override void Die()
    {
        base.Die();
        enemy.Die();
    }
}
