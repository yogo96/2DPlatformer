using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private Transform[] _movePoints;
    [SerializeField] private float _speed;

    private float _distanceToPoint = 0.1f;
    private int _currentPointIndex = 0;
    private float _fallPosition;
    private int _positionModifier = 10;

    private void Awake()
    {
        Spawn();
        _fallPosition = transform.localPosition.y - _positionModifier;
    }

    private void Update()
    {
        Move();
        CheckFall();
    }

    private void CheckFall()
    {
        if (transform.localPosition.y < _fallPosition)
        {
            Spawn();
        }
    }

    private void Spawn()
    {
        transform.position = _movePoints[_currentPointIndex].position;
    }

    private void Move()
    {
        Vector3 pointPosition = _movePoints[_currentPointIndex].position;

        transform.position = Vector3.MoveTowards(transform.position, pointPosition, _speed * Time.fixedDeltaTime);

        if ((transform.position - pointPosition).sqrMagnitude <= _distanceToPoint)
        {
            ChangePointIndex();
        }
    }

    private void ChangePointIndex()
    {
        _currentPointIndex++;
        transform.Rotate(0, 180, 0);

        if (_currentPointIndex == _movePoints.Length)
        {
            _currentPointIndex = 0;
        }
    }
}