using UnityEngine;


public class Follower : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _xOffset;

    private Vector3 _position;

    private void Awake()
    {
        _position = transform.position;
    }

    private void Update()
    {
        _position.x = _target.position.x + _xOffset;

        transform.position = _position;
    }
}
