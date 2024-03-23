using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private Animator _animator;
    private bool _isCrouched;


    void Start()
    {
        _animator = GetComponentInChildren<Animator>();    
    }
    
    public void MovePlayer(Vector2 value)
    {
        float movex = value.x * 120;
        float movez = value.y * 120;

        //_animator.SetFloat("MovementZ", 1);
        //_animator.SetFloat("MovementX", 1);

        if (value.x == 0 && value.y == 0)
            PlayerIdle();
        
        //_animator.SetFloat("Direction", )
    }

    public void PlayerIdle()
    {
        _animator.SetFloat("Speed", 0.0f);
    }

    public void RotatePlayer(float value)
    {
        //_animator.SetFloat("MovementX", value);
    }

    public void WalkPlayer()
    {
        _animator.SetFloat("Speed", .23f);
    }

    public void RunPlayer()
    {
        _animator.SetFloat("Speed", .8f);
    }

    public void CrouchPlayer()
    {
        _isCrouched = !_isCrouched;

        _animator.SetBool("Crouch", _isCrouched);
    }

    public void JumpPlayer()
    {
        _animator.SetBool("Jump", true);
        StartCoroutine(JumpTimer());
    }

    IEnumerator JumpTimer()
    {
        yield return new WaitForSeconds(.2f);
        _animator.SetBool("Jump", false);
    }

}
