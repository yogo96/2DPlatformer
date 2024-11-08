using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(SpriteRenderer))]
public class Coin : MonoBehaviour
{
    private AudioSource _audioSource;
    private SpriteRenderer _spriteRenderer;
    private bool _isPicked;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void PickUp()
    {
        if (_isPicked)
            return;
         
        StartCoroutine(PlayingSound());
    }

    private IEnumerator PlayingSound()
    {
        _isPicked = true;
        _audioSource.Play();
        _spriteRenderer.enabled = false;
        
        yield return new WaitForSeconds(_audioSource.clip.length);

        _audioSource.Stop();
        gameObject.SetActive(false);
    }
}
