using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStates 
{
    protected Player player;
    protected PlayerStateMachine stateMachine;

    private string animBool;

    protected float xInput;

    protected float timeState;

    protected bool triggerCalled;

    public PlayerStates(Player _player, PlayerStateMachine _stateMachine,string _animBool)
    {
     
        this.player = _player;
        this.stateMachine = _stateMachine;
        this.animBool = _animBool;
    }

    public virtual void Enter() 
    {
       
        player.anim.SetBool(animBool, true);
        triggerCalled = false;
    }
    public virtual void Update() 
    {
        xInput = Input.GetAxisRaw("Horizontal");
        player.FlipController(xInput);
        player.anim.SetFloat("yVelocity", player.rb.velocity.y);

        timeState -= Time.deltaTime; 
    }
    public virtual void Exit() 
    {
        player.anim.SetBool(animBool, false);
    }

    public virtual void AnimationFinishTrigger ()
    {
        triggerCalled = true;
    }
}
