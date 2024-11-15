using UnityEngine;

public class BoundsChecker : MonoBehaviour
{
    [SerializeField] private float _outPosition = 1; 
    [SerializeField] private Transform _targetTransform;

    private IBoundsHandler _target;

    private void Awake()
    {
        _target = _targetTransform.GetComponent<IBoundsHandler>();
    }

    private void Update()
    {
        if (_targetTransform.localPosition.y < _outPosition)
            _target.HandleOutOfBounds();
    }
}