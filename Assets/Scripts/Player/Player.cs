using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : Entity
{
    #region PlayerController

    public bool isBusy;

    [Header("Attack variable")]
    public Vector2[] attackMovement;
    public float counterAttackDuration = 0.2f;

    [Header("Movement Variable")]
    public float acceleration = 50f;
    public float maxSpeed = 15f;
    public float linearDrag = 7f;
    public bool isChangingDirection => ((rb.velocity.x > 0 && !isFacingRight) || (rb.velocity.x < 0 && isFacingRight));
    

    [Header("Jump Variable")]
    public float jumpForce = 15f;
    public float wallJumpForce = 5f;
    public float airLinearDrag = 10f;
    [SerializeField] private float fallMultiplier = 10f;
    //[SerializeField] private float lowJumpFallMultiplier = 8f;
    public int extraJump = 1;
    public int valueOfExtraJump;
    public bool canJump => (Input.GetKeyDown(KeyCode.Space) &&(IsOnGround() || valueOfExtraJump > 0));

    [Header("Dash Variable")]
    
    
    public float dashDuration = 0.2f;
    public float dashSpeed = 0.75f;
    public float dashDirection { get; private set; }


    #endregion

    public SkillManager skill { get; private set; }

    #region states
    public PlayerStateMachine stateMachine { get; private set; }
    public PlayerIdleState Idle { get; private set; }
    public PlayerMoveState Move { get; private set; }
    public PlayerJumpState Jump { get; private set; }
    public PlayerAirState OnAir { get; private set; }
    public PlayerDashState Dash { get; private set; }
    public PlayerWallSlide WallSlide { get; private set; }
    public PlayerWallJumpState WallJump { get; private set; }
    public PlayerPrimaryAttackState PrimaryAttack { get; private set; }
    public PlayerCounterAttackState CounterAttack { get; private set; }
    public PlayerAimKusarigamaState AimKusarigama { get; private set; }
    public PlayerCatchKusarigamaState CatchKusarigama { get; private set; }
    public PlayerDeathState Death { get; private set; }
    #endregion

    protected override void Awake()
    {
        base.Awake();

        stateMachine = new PlayerStateMachine();

        Idle = new PlayerIdleState(this, stateMachine, "idle");
        Move = new PlayerMoveState(this, stateMachine, "move");
        Jump = new PlayerJumpState(this, stateMachine, "jump");
        OnAir = new PlayerAirState(this, stateMachine, "onAir");
        Dash = new PlayerDashState(this, stateMachine, "dash");
        WallSlide = new PlayerWallSlide(this, stateMachine, "wallSlide");
        WallJump = new PlayerWallJumpState(this, stateMachine, "jump");
        PrimaryAttack = new PlayerPrimaryAttackState(this, stateMachine, "attack");
        CounterAttack = new PlayerCounterAttackState(this, stateMachine, "counterAttack");
        AimKusarigama = new PlayerAimKusarigamaState(this, stateMachine, "aimKusarigama");
        CatchKusarigama = new PlayerCatchKusarigamaState(this, stateMachine, "catchKusarigama");
        Death = new PlayerDeathState(this, stateMachine, "die");
    }

    protected override void Start()
    {
        base.Start();
        stateMachine.Initialize(Idle);

        skill = SkillManager.instance;
    }

    protected override void Update()
    {
        base.Update();

        stateMachine.currentState.Update();

        CheckDashInput();
        
    }

    private void FixedUpdate()
    {
        if(!IsOnGround())
        {
            ApplyAirLinearDrag();
            FallMultiplier();
        }
        else
        {
            valueOfExtraJump = extraJump;
        }
    }

    public IEnumerator BusyFor(float second)
    {
        isBusy = true;

        yield return new WaitForSeconds(second);

        isBusy = false;
    }

    public void AnimationTrigger() => stateMachine.currentState.AnimationFinishTrigger();

    private void CheckDashInput()
    {
        if(IsOnWall())
        {
            return;
        }

        

        if(Input.GetKeyDown(KeyCode.LeftShift) && SkillManager.instance.dashSkill.CanUseSkill())
        {
         
            dashDirection = Input.GetAxisRaw("Horizontal");

            rb.gravityScale = 3f;

            if(dashDirection == 0)
            {
                dashDirection = FacingDirection;
            }

            stateMachine.ChangeState(Dash);
        }
    }
    public void OnMove(float xInput)
    {
        rb.AddForce(new Vector2(xInput, 0f) * acceleration);

        if(Mathf.Abs(rb.velocity.x) > maxSpeed)
        {
            rb.velocity = new Vector2(Mathf.Sign(rb.velocity.x) * maxSpeed, rb.velocity.y);
        }
    }

    

    public void ApplyLinearDrag(float xInput)
    {
        if(Mathf.Abs(xInput) < 0.04f || isChangingDirection)
        {
            rb.drag = linearDrag;
        }
        else
        {
            rb.drag = 0f;
        }
    }

   public void ApplyAirLinearDrag() 
    {
        rb.drag = airLinearDrag;
    }

    private void FallMultiplier()
    {
        if (rb.velocity.y < 0)
        {
            rb.gravityScale = fallMultiplier;
        }
        //else if (rb.velocity.x > 0 && !Input.GetKeyDown(KeyCode.Space))
        //{
          //  rb.gravityScale = lowJumpFallMultiplier;
       //}
        else 
        { 
            rb.gravityScale = 2.5f;
        }
    }
    public void OnJump()
    {
        if (!IsOnGround())
        {
            valueOfExtraJump--;
        }
        rb.velocity = new Vector2(rb.velocity.x, 0);

        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }

    public void OnWallJump()
    {
        rb.velocity = new Vector2(rb.velocity.x, 0);
        rb.AddForce(new Vector2(-FacingDirection, 2) * wallJumpForce, ForceMode2D.Impulse);
        
    }

    public override void Die()
    {
        base.Die();

        stateMachine.ChangeState(Death);
    }
}
