using UnityEngine;

public class Follower : MonoBehaviour
{
    [SerializeField] private Player _target;

    private void LateUpdate()
    {
        Vector3 targetPosition = _target.transform.position;
        transform.position = new Vector3(targetPosition.x, targetPosition.y, transform.position.z);
    }
}
