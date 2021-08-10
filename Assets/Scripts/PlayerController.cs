using UnityEngine;

public class PlayerController : MonoBehaviour
{

    #region PrivateData

    private AnimationController _animController;
    private Rigidbody _rigidbody;
    private float _speedMultiplier;
    private float _moveHorizontal;
    private float _moveVertical;

    #endregion

    #region UnityMethods

    private void Start()
    {
        _animController = GetComponent<AnimationController>();
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        _animController.SetSpeed(_moveVertical * _speedMultiplier, _moveHorizontal * _speedMultiplier);    
    }

    private void FixedUpdate()
    {
        _moveHorizontal = Input.GetAxis("Horizontal");

        _moveVertical = Input.GetAxis("Vertical");

        if (Input.GetButton("Run"))
        {
            _speedMultiplier = 5f;
        }
        else
        {
            _speedMultiplier = 2f;
        }

        Vector3 movement = new Vector3(_moveHorizontal, 0, _moveVertical);

        _rigidbody.velocity = movement * _speedMultiplier;
        _rigidbody.angularVelocity = new Vector3(0, 0, 0);
    }

    #endregion

}
