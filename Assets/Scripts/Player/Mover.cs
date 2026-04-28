using UnityEngine;

[RequireComponent(typeof(InputDetector))]
public class Mover : MonoBehaviour
{
    [SerializeField] private float _tapForce;
    [SerializeField] private float _speed;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private float _maxRotationZ;
    [SerializeField] private float _minRotationZ;

    private Rigidbody2D _rigidbody2D;
    private InputDetector _inputDetector;

    private Vector3 _startPosition;
    private Quaternion _maxRotation;
    private Quaternion _minRotation;
    private Vector2 _velocity;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _inputDetector = GetComponent<InputDetector>();

        _startPosition = transform.position;
        _velocity = new Vector2(_speed, _tapForce);

        _maxRotation = Quaternion.Euler(0, 0, _maxRotationZ);
        _minRotation = Quaternion.Euler(0, 0, _minRotationZ);
    }

    private void OnEnable()
    {
        _inputDetector.JumpPressed += Jump;
    }

    private void OnDisable()
    {
        _inputDetector.JumpPressed -= Jump;
    }

    private void Update()
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, _minRotation, _rotationSpeed * Time.deltaTime);
    }

    private void Jump()
    {
        _rigidbody2D.velocity = _velocity;
        transform.rotation = _maxRotation;
    }

    public void Reset()
    {
        _rigidbody2D.velocity = Vector2.zero;
        transform.rotation = Quaternion.identity;
        transform.position = _startPosition;
    }
}
