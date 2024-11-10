using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    public bool IsGround => _platformCount > 0;

    private int _platformCount = 0;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent<Platform>(out Platform platform))
            _platformCount++;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent<Platform>(out Platform platform))
        {
            _platformCount--;
            if (_platformCount < 0)
            {
                _platformCount = 0;
            }
        }
    }

}
