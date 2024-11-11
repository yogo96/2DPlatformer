using UnityEngine;

public class Coin : MonoBehaviour, IPickable
{
    [SerializeField] private AudioClip _audioClip;
    [SerializeField] private int _price = 5;
    
    public void PickUp(Player player)
    {
        AudioSource.PlayClipAtPoint(_audioClip, transform.position);
        gameObject.SetActive(false);
        player.AddCoin(_price);
    }
}
