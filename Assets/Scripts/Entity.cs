using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{

    #region component
    public Animator anim { get; private set; }
    public Rigidbody2D rb { get; private set; }
    public EntityFx entityFx { get; private set; }
    public CharacterStat characterStat { get; private set; }
    public CapsuleCollider2D cd { get; private set; }
    #endregion

    [Header("Layer Transform")]
    public Transform attackCheck;
    public float attackDistanceRadius;
    [SerializeField] protected Transform groundCheck;
    [SerializeField] protected float groundCheckDistance;
    [SerializeField] protected Transform wallCheck;
    [SerializeField] protected float wallCheckDistance;
    [SerializeField] protected LayerMask whatIsGround;

    [Header("Knockback Variables")]
    [SerializeField] protected Vector2 knockbackDirection;
    protected bool isKnockback;
    [SerializeField] protected float knockbackDuration;
    public float FacingDirection { get; private set; } = 1;
    protected bool isFacingRight = true;

    protected virtual void Awake()
    {
        
    }

    protected virtual void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
        entityFx = GetComponent<EntityFx>();
        characterStat = GetComponent<CharacterStat>();
        cd = GetComponent<CapsuleCollider2D>();
    }

    protected virtual void Update()
    { 

    }

    public void SetZeroVelocity()
    {
        if (isKnockback)
            return;

        rb.velocity = new Vector2(0, 0);
    }
    public void SetVelocity(float x, float y)
    {
        if (isKnockback)
            return;

        rb.velocity = new Vector2(x, y);
        
    }

    public virtual void FlipController(float xInput)
    {
        if (isFacingRight && xInput < 0)
        {
            Flip();
        }
        else if (!isFacingRight && xInput > 0)
        {
            Flip();
        }
    }
    public virtual void Flip()
    {
        FacingDirection *= -1;
        isFacingRight = !isFacingRight;
        transform.Rotate(0, 180, 0);
    }



    public virtual bool IsOnGround() => Physics2D.Raycast(groundCheck.position, Vector2.down, groundCheckDistance, whatIsGround);
    public virtual bool IsOnWall() => Physics2D.Raycast(wallCheck.position, Vector2.right * FacingDirection, wallCheckDistance, whatIsGround);
    protected virtual void OnDrawGizmos()
    {
        Gizmos.DrawLine(groundCheck.position, new Vector3(groundCheck.position.x, groundCheck.position.y - groundCheckDistance));
        Gizmos.DrawLine(wallCheck.position, new Vector3(wallCheck.position.x + wallCheckDistance, wallCheck.position.y));
        Gizmos.DrawWireSphere(attackCheck.position, attackDistanceRadius);
    }

    public virtual void Damage()
    {
        StartCoroutine("HitKnockBack");
        entityFx.StartCoroutine("FlashFx");
        Debug.Log(gameObject.name + "damaged");
    }

    protected virtual IEnumerator HitKnockBack()
    {
        isKnockback = true;

        rb.velocity = new Vector2(knockbackDirection.x * -FacingDirection, knockbackDirection.y);
        yield return new WaitForSeconds(knockbackDuration);

        isKnockback = false;
    }

    public virtual void Die()
    {

    }
}
