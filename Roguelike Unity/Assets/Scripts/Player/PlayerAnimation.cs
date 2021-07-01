using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : Player
{
    private Animator m_Animator;

    private string m_CurrentAnimation = "";
    
    private enum FacingDirection
    {
        FacingRight, 
        FacingLeft,
        FacingUp,
        FacingDown
    }
    
    private enum AnimeNames
    {
        WalkRight,
        WalkLeft,
        WalkUp,
        WalkDown,
        IdleRight,
        IdleLeft,
        IdleUp,
        IdleDown
    }
    
    private FacingDirection m_FacingDirection;

    // Start is called before the first frame update
    protected override void Awake()
    {
        base.Awake();
        m_Animator = GetComponent<Animator>();
        m_FacingDirection = FacingDirection.FacingDown;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        UpdateAnimation();
    }

    private void UpdateAnimation()
    {
        if (m_Rb.velocity == Vector2.zero)
        {
            if (m_FacingDirection == FacingDirection.FacingRight)
            {
                ChangeAnimation(AnimeNames.IdleRight);
            }
            else if (m_FacingDirection == FacingDirection.FacingLeft)
            {
                ChangeAnimation(AnimeNames.IdleLeft);
            }
            else if (m_FacingDirection == FacingDirection.FacingUp)
            {
                ChangeAnimation(AnimeNames.IdleUp);
            }
            else if (m_FacingDirection == FacingDirection.FacingDown)
            {
                ChangeAnimation(AnimeNames.IdleDown);
            }
        }
        
        else if (m_Rb.velocity.x > 0.1f)
        {
            ChangeAnimation(AnimeNames.WalkRight);
            m_FacingDirection = FacingDirection.FacingRight;
        }
        else if (m_Rb.velocity.x < -0.1f)
        {
            ChangeAnimation(AnimeNames.WalkLeft);
            m_FacingDirection = FacingDirection.FacingLeft;
        }
        else if (m_Rb.velocity.y > 0.1f)
        {
            ChangeAnimation(AnimeNames.WalkUp);
            m_FacingDirection = FacingDirection.FacingUp;
        }
        else if (m_Rb.velocity.y < -0.1f)
        {
            ChangeAnimation(AnimeNames.WalkDown);
            m_FacingDirection = FacingDirection.FacingDown;
        }
    }

    private void ChangeAnimation(AnimeNames animationName)
    {
        if (m_CurrentAnimation == animationName.ToString()) return;

        m_CurrentAnimation = animationName.ToString();
        m_Animator.Play(m_CurrentAnimation);
    }
}
