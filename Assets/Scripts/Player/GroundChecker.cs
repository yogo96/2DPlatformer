using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    private int _platformCount = 0;

    public bool IsGround => _platformCount > 0;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent<Platform>(out _))
            _platformCount++;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent<Platform>(out _))
        {
            _platformCount--;
            
            if (_platformCount < 0)
            {
                _platformCount = 0;
            }
        }
    }

}
