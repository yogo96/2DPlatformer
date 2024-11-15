using System.Collections;
using UnityEngine;


public class PlayerDetector : MonoBehaviour
{
    private const string PlayerLayerName = "Player";
    
    public bool IsFindTarget { get; private set; }
    public Player Target { get; private set; }
    
    private Coroutine _targetFindingCoroutine;
    private WaitForSeconds _findDelay = new WaitForSeconds(0.1f);
    private int _findDistance = 12;
    private int _raycastLayer;

    private void Awake()
    {
        _raycastLayer = LayerMask.GetMask(PlayerLayerName);
        StartCoroutine(TargetFinding());
    }

    public void OnDisable()
    {
        if(_targetFindingCoroutine != null)
            StopCoroutine(_targetFindingCoroutine);
    }

    private IEnumerator TargetFinding()
    {
        while (enabled)
        {
            RaycastHit2D hit =
                Physics2D.Raycast(transform.position, transform.right, _findDistance, _raycastLayer);

            if (hit.collider != null && hit.transform.TryGetComponent(out Player player))
            {
                IsFindTarget = true;
                Target = player;
            }
            else
            {
                IsFindTarget = false;
                Target = null;
            }

            yield return _findDelay;
        }
    }
}