using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private AudioClip _audioClip;
    [SerializeField] private int _price = 5;
    
    public int PickUp()
    {
        AudioSource.PlayClipAtPoint(_audioClip, transform.position);
        gameObject.SetActive(false);
        return _price;
    }
}
