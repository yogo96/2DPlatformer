using System.Collections;
using UnityEngine;

public class FirstAidKit : MonoBehaviour, IPickable
{
    [SerializeField] private int _restoreValue = 25;

    private Coroutine _respawningCoroutine;
    private WaitForSeconds _respawnTime = new WaitForSeconds(5);

    private void OnDisable()
    {
        if (_respawningCoroutine != null)
            StopCoroutine(_respawningCoroutine);
    }

    public void PickUp(Player player)
    {
        player.Heal(_restoreValue);
        gameObject.SetActive(false);
        StartCoroutine(KitRespawning());
    }

    private IEnumerator KitRespawning()
    {
        yield return _respawnTime;
        gameObject.SetActive(true);
    }
}
