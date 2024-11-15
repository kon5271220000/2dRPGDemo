using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NaginataEnemyAinmationTrigger : MonoBehaviour
{
    private NaginataEnemy enemy => GetComponentInParent<NaginataEnemy>();

    private void AnimationFinishTrigger()
    {
        enemy.AnimationFinishTrigger();
    }

    private void AttackTrigger()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(enemy.attackCheck.position, enemy.attackDistanceRadius);

        foreach(var hit in colliders)
        {
            if(hit.GetComponent<Player>() != null)
            {
                PlayerStats target = hit.GetComponent<PlayerStats>();
                //hit.GetComponent<Player>().Damage();
                enemy.characterStat.DoDamage(target);
            }
        }
    }

    private void OpenCounterWindown()
    {
        enemy.OpenCounterAttackWindow();
    }

    private void CloseCounterWindown()
    {
        enemy.CloseCounterAttackWindow();
    }
}
