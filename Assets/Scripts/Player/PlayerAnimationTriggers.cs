using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationTriggers : MonoBehaviour
{
   private Player player => GetComponentInParent<Player>();
   
    private void AnimationTrigger()
    {
        player.AnimationTrigger();
    }

    private void AttackTrigger()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(player.attackCheck.position, player.attackDistanceRadius);

        foreach(var hit in colliders)
        {
            if(hit.GetComponent<Enemy>() != null)
            {
                EnemyStats target = hit.GetComponent<EnemyStats>();
                //hit.GetComponent<Enemy>().Damage();
                //hit.GetComponent<CharacterStat>().TakeDamge(player.characterStat.damage.GetValue());
                player.characterStat.DoDamage(target);
            }
        }
    }

    private void Throw()
    {
        SkillManager.instance.kusarigamaSkill.CreateKusarigama();
    }
}
