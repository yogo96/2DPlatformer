using UnityEngine;

public class FirstAidKitSpawner : MonoBehaviour
{
    [SerializeField] private FirstAidKit _prefab;
    
    private void Awake()
    {
        Instantiate(_prefab, transform.position, Quaternion.identity);
    }
}
