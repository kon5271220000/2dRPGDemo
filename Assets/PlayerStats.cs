using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : CharacterStat
{
    public Player player;

    protected override void Start()
    {
        base.Start();
    }

    protected override void TakeDamge(int damage)
    {
        base.TakeDamge(damage);

        player.Damage();
    }

    protected override void Die()
    {
        base.Die();

        player.Die();
    }
}
