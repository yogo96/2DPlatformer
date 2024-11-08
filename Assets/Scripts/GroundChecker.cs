using System;
using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    [SerializeField] private bool isGround;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent<Platform>(out Platform platform)) 
            isGround = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent<Platform>(out Platform platform)) 
            isGround = false;
    }

    public bool IsGround()
    {
        return isGround;
    }

}
