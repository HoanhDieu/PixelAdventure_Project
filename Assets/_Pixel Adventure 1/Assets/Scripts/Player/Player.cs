using System.Collections;
using System.Collections.Generic;
using GameTool;
using UnityEngine;
using UnityEngine.Serialization;

public class Player : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Animator anim;
    [SerializeField] private SpriteRenderer sprite;
    [SerializeField] private BoxCollider2D coll;
    [SerializeField] private LayerMask jumpableGround;
    
    [SerializeField] private float jumpVelo = 15f;
    [SerializeField] private float moveSpeed = 6f;
    [SerializeField] private float dirX;
    [SerializeField] private bool isGrounded; 

    private enum MovementState
    {
        Idle,
        Run,
        Jump,
        Fall
    }
    
    
    private void Start()
    {
        AudioManager.Instance.PlayMusic(eMusicName.Game);
        jumpVelo = 15f;
        moveSpeed = 6f;
    }
    private void Update()
    {
        isGrounded = Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, 
            Vector2.down, .1f, jumpableGround);
        dirX = Input.GetAxisRaw("Horizontal");
        
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);
        
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpVelo);
            AudioManager.Instance.Shot(eSoundName.Jump);
        }
        
        AnimationUpdate();
    }

    private void AnimationUpdate()
    {
        MovementState state;
        if (dirX > 0f)
        {
            state = MovementState.Run;
            sprite.flipX = false;
        }
        else if (dirX < 0f)
        {
            state = MovementState.Run;
            sprite.flipX = true;
        }
        else
        {
            state = MovementState.Idle;
        }

        if (rb.velocity.y > .1f)
        {
            state = MovementState.Jump;
        }
        else if (rb.velocity.y < -.1f)
        {
            state = MovementState.Fall;
        }
        
        anim.SetInteger("state", (int)state);
    }

}
