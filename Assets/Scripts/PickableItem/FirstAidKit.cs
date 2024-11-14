using UnityEngine;

public class FirstAidKit : PickableItem
{
    [SerializeField] private int _restoreValue = 25;

    public override int PickUp()
    {
        gameObject.SetActive(false);
        return _restoreValue;
    }
}
