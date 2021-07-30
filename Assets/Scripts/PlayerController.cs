using UnityEngine;

public class PlayerController : MonoBehaviour
{

    #region Fields
    [SerializeField] private float _speed;
    private Rigidbody _rigidbody;

    #endregion

    #region UnityMethods

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");

        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, _rigidbody.velocity.y, moveVertical);

        _rigidbody.velocity = movement * _speed;
        _rigidbody.angularVelocity = new Vector3(0, 0, 0);
    }

    #endregion

}
