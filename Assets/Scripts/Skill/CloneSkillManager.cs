using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloneSkillManager : MonoBehaviour
{
    private SpriteRenderer sr;
    private Animator anim;

    [SerializeField] private float colorLoosingSpeed;
    [SerializeField] private Transform attackCheck;
    [SerializeField] private float attackDistanceRadius = 0.8f;
    private Transform closestEnemy;

    
    private float cloneTimer;

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        cloneTimer -= Time.deltaTime;

        if(cloneTimer < 0) 
        {
            sr.color = new Color(1, 1, 1, sr.color.a - (Time.deltaTime * colorLoosingSpeed));

            if(sr.color.a <= 0)
            {
                Destroy(gameObject);
            }
        }


    }
    public void SetUpClone(Transform newTransform, float closeCloneDuration, bool canAttack)
    {
        if (canAttack)
        {
            anim.SetInteger("attackNumber", Random.Range(0, 2));
        }
        
        transform.position = newTransform.position;
        cloneTimer = closeCloneDuration;

        FaceCloseTarger();
    }

    private void AnimationTrigger()
    {
        cloneTimer = -0.1f;
    }

    private void AttackTrigger()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(attackCheck.position, attackDistanceRadius);

        foreach (var hit in colliders)
        {
            if (hit.GetComponent<Enemy>() != null)
            {
                hit.GetComponent<Enemy>().Damage();
            }
        }
    }

    private void FaceCloseTarger()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 25);

        float closestTarget = Mathf.Infinity;

        foreach (var hit in colliders)
        {
            if(hit.GetComponent<Enemy>() != null)
            {
                float distanceToEnemy = Vector2.Distance(transform.position, hit.transform.position);

                if(distanceToEnemy < closestTarget) 
                {
                    closestTarget = distanceToEnemy;
                    closestEnemy = hit.transform;
                }
            }
        }

        if(closestEnemy != null)
        {
            if(transform.position.x > closestEnemy.transform.position.x)
            {
                transform.Rotate(0, 180, 0);
            }
        }
    }
}
