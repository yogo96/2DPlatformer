using UnityEngine;

public class FirstAidKit : MonoBehaviour
{
    [SerializeField] private int _restoreValue = 25;

    private bool _isPicked;
    
    public bool TryPickUp(out int value)
    {
        value = _restoreValue;
        
        if (_isPicked)
            return false;

        _isPicked = true;
        gameObject.SetActive(false);
        return _isPicked;
    }

    public void Reset()
    {
        _isPicked = false;
        gameObject.SetActive(true);
    }
}
