using UnityEngine;

[RequireComponent(typeof(InventoryHolder))]
public class Collector : MonoBehaviour
{
    [SerializeField] LayerMask collectableLayer;
    [SerializeField] float collectRange = 3;

    InventoryHolder inventoryHolder;

    void Awake()
    {
        inventoryHolder = GetComponent<InventoryHolder>();
    }

    void Update()
    {
        if (inventoryHolder == null) return;

        Collider[] colliders = Physics.OverlapSphere(transform.position, collectRange, collectableLayer);
        foreach (Collider collider in colliders)
        {
            if (collider.TryGetComponent<Collectable>(out Collectable collectable))
            {
                if (Vector3.Distance(transform.position, collider.transform.position) <= collectRange)
                {
                    collectable.PickUp(gameObject);
                }
            }
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, collectRange);
    }
}
