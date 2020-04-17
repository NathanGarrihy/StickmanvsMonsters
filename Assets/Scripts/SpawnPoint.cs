using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position,
                               0.25f);
    }
}
