using System.Collections;
using UnityEngine;

public class FirstAidKitSpawner : MonoBehaviour
{
    [SerializeField] private FirstAidKit _prefab;
    
    private Coroutine _respawningCoroutine;
    private WaitForSeconds _respawnTime = new WaitForSeconds(5);
    private FirstAidKit _currentKit;
    private bool _isRespawn;
    
    private void Awake()
    {
        _currentKit = Instantiate(_prefab, transform.position, Quaternion.identity);
    }

    private void Update()
    {
        if (_currentKit.gameObject.activeSelf == false && _isRespawn == false)
        {
            _isRespawn = true;
            StartCoroutine(KitRespawning());
        }
    }

    private void OnDisable()
    {
        if (_respawningCoroutine != null)
            StopCoroutine(_respawningCoroutine);
    }

    private IEnumerator KitRespawning()
    {
        yield return _respawnTime;
        _currentKit.Reset();
        _isRespawn = false;
    }
}
