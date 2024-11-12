using UnityEngine;

public class FirstAidKit : MonoBehaviour, IPickable
{
    [SerializeField] private int _restoreValue = 25;

    public void PickUp(Player player)
    {
        player.Heal(_restoreValue);
        gameObject.SetActive(false);
    }
}
