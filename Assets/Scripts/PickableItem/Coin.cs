using UnityEngine;

public class Coin : PickableItem
{
    [SerializeField] private AudioClip _audioClip;
    [SerializeField] private int _price = 5;
    
    public override int PickUp()
    {
        AudioSource.PlayClipAtPoint(_audioClip, transform.position);
        gameObject.SetActive(false);
        return _price;
    }
}
