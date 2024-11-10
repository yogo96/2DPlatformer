using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private AudioClip _audioClip;

    public void PickUp()
    {
        AudioSource.PlayClipAtPoint(_audioClip, transform.position);
        gameObject.SetActive(false);
    }
}
