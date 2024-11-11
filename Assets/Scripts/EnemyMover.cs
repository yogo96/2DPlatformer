using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private Transform[] _points;
    [SerializeField] private float _speed;

    private float _distanceToPoint = 0.1f;
    private int _currentPointIndex = 0;
    private float _outBoundsPosition;
    private int _positionModifier = 10;
    private int _rotateDegrees = 180;
    private int _rotateZeroDegrees = 0;

    private void Awake()
    {
        Spawn();
        _outBoundsPosition = transform.localPosition.y - _positionModifier;
    }

    private void Update()
    {
        Move();
        RespawnIfOutOfBounds();
    }

    private void RespawnIfOutOfBounds()
    {
        if (transform.localPosition.y < _outBoundsPosition)
        {
            Spawn();
        }
    }

    private void Spawn()
    {
        transform.position = _points[_currentPointIndex].position;
    }

    private void Move()
    {
        Vector3 pointPosition = _points[_currentPointIndex].position;

        transform.position = Vector3.MoveTowards(transform.position, pointPosition, _speed * Time.deltaTime);

        if ((transform.position - pointPosition).sqrMagnitude <= _distanceToPoint)
        {
            ChangePointIndex();
        }
    }

    private void ChangePointIndex()
    {
        transform.Rotate(_rotateZeroDegrees, _rotateDegrees, _rotateZeroDegrees);

        _currentPointIndex = ++_currentPointIndex % _points.Length;
    }
}