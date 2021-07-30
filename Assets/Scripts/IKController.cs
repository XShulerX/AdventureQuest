using UnityEngine;

[RequireComponent(typeof(Animator))]
public class IKController : MonoBehaviour
{

    #region Fields

    [SerializeField]
    private bool _isActive;

    [SerializeField]
    private Transform _lookObject;
    
    [SerializeField]
    private float _valueWeight;

    private Animator _animator;
    private Transform _transform;

    #endregion

    #region UnityMethods
    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _transform = transform;
    }

    private void OnAnimatorIK(int layerIndex)
    {
        if (_isActive)
        {
            _animator.SetLookAtWeight(_valueWeight);
            _animator.SetLookAtPosition(_lookObject.position);
        }
        else
        {
            _animator.SetLookAtWeight(0);
        }

        if (Vector3.Distance(_transform.position, _lookObject.position) > 5)
            _animator.SetLookAtWeight(0);
    }

    #endregion
}
