using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    private const string PlayerLayerName = "Player";

    [SerializeField] private Transform[] _points;
    [SerializeField] private float _speed;

    private float _distanceToPoint = 0.1f;
    private int _currentPointIndex = 0;
    private float _outBoundsPosition;
    private int _positionModifier = 1;
    private int _rotateDegrees = 180;
    private int _rotateZeroDegrees = 0;
    private int _followDistance = 12;
    private Vector3 _movePosition;
    private int _raycastLayer;

    private void Awake()
    {
        _raycastLayer = LayerMask.GetMask(PlayerLayerName);
        Spawn();
        _outBoundsPosition = transform.position.y - _positionModifier;
    }
    
    private void FixedUpdate()
    {
        RaycastHit2D hit =
            Physics2D.Raycast(transform.position, transform.right, _followDistance, _raycastLayer);

        if (hit.collider != null && hit.transform.TryGetComponent(out Player player))
        {
            _movePosition = player.transform.position;
        }
        else
        {
            _movePosition = _points[_currentPointIndex].position;
        }
    }

    public void Move()
    {
        RespawnIfOutOfBounds();

        RotateTo(_movePosition);

        if ((transform.position - _movePosition).sqrMagnitude <= _distanceToPoint)
        {
            ChangePointIndex();
        }

        transform.position =
            Vector3.MoveTowards(transform.position, _movePosition, _speed * Time.deltaTime);
    }
    
    private void RespawnIfOutOfBounds()
    {
        if (transform.position.y <= _outBoundsPosition)
        {
            Spawn();
        }
    }

    private void Spawn()
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