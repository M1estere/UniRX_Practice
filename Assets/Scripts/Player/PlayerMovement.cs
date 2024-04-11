using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    private static readonly string HORIZONTAL_INPUT = "Horizontal";
    private static readonly string VERTICAL_INPUT = "Vertical";

    [SerializeField] private float _moveSpeed;

    private Rigidbody _rigidbody;
    
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        _rigidbody.velocity = new Vector3(Input.GetAxisRaw(HORIZONTAL_INPUT), 0, Input.GetAxisRaw(VERTICAL_INPUT)) * _moveSpeed;
    }
}
