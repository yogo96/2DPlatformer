using UnityEngine;

public class BoundsChecker<T> : MonoBehaviour where T : MonoBehaviour, IBoundsHandler
{
    [SerializeField] private float _outPosition = 1;
    [SerializeField] private T _target;

    private Transform _targetTransform;

    private void Awake()
    {
        _targetTransform = _target.transform;
    }

    private void Update()
    {
        if (_targetTransform.localPosition.y < _outPosition)
            _target.HandleOutOfBounds();
    }
}