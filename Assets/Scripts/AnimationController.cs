using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AnimationController : MonoBehaviour
{
    private Animator _animator;
    
    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void SetSpeed(float forwardSpeed, float strafeSpeed)
    {
        _animator.SetFloat("ForwardSpeed", forwardSpeed);
        _animator.SetFloat("StrafeSpeed", strafeSpeed);

    }
}
