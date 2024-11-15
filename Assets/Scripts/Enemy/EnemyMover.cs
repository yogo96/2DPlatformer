using UnityEngine;

[RequireComponent(typeof(PlayerDetector))]
public class EnemyMover : MonoBehaviour
{
    [SerializeField] private Transform[] _points;
    [SerializeField] private float _speed;

    private float _distanceToPoint = 0.1f;
    private int _currentPointIndex = 0;
    private float _outBoundsPosition;
    private int _positionModifier = 1;
    private int _rotateDegrees = 180;
    private int _rotateZeroDegrees = 0;
    private Vector3 _movePosition;
    private PlayerDetector _playerDetector;

    private void Awake()
    {
        _playerDetector = GetComponent<PlayerDetector>();
        ResetPosition();
        _outBoundsPosition = transform.position.y - _positionModifier;
    }

    private void FixedUpdate()
    {
        if (_playerDetector.IsFindTarget)
        {
            _movePosition = _playerDetector.Target.transform.position;
        }
        else
        {
            _movePosition = _points[_currentPointIndex].position;
        }
    }

    public void Move()
    {
        RotateTo(_movePosition);

        if ((transform.position - _movePosition).sqrMagnitude <= _distanceToPoint)
        {
            ChangePointIndex();
        }

        transform.position =
            Vector3.MoveTowards(transform.position, _movePosition, _speed * Time.deltaTime);
    }

    public void ResetPosition()
    {
        transform.position = _points[_currentPointIndex].position;
    }

    private void RotateTo(Vector3 position)
    {
        Vector3 direction = (position - transform.position).normalized;

        if (direction.x == 0)
            return;

        int rotateDegrees = _rotateDegrees;

        if (direction.x > 0)
            rotateDegrees = _rotateZeroDegrees;

        transform.rotation = Quaternion.Euler(_rotateZeroDegrees, rotateDegrees, _rotateZeroDegrees);
    }

    private void ChangePointIndex()
    {
        _currentPointIndex = ++_currentPointIndex % _points.Length;
        _movePosition = _points[_currentPointIndex].position;
    }
}