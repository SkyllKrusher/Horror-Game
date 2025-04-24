using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float dmg = 25f;
    [SerializeField]
    private float searchRadius = 5f;
    [SerializeField]
    private LayerMask searchLayers;
    [SerializeField]
    private float moveSpeed;
    [SerializeField]
    private float searchTickTime = 0.25f;
    private bool isSearchOn = true;
    private Transform chaseTargetTransform;

    private void Detect()
    {
        Vector3 origin = transform.position;
        RaycastHit hit;
        if (Physics.SphereCast(origin, searchRadius, transform.forward, out hit, searchLayers))
        {
            chaseTargetTransform = hit.transform;
        }
        else
        {
            chaseTargetTransform = null;
        }
    }

    private IEnumerator DetectPeriodically()
    {
        while (isSearchOn)
        {
            Detect();
            yield return new WaitForSeconds(searchTickTime);
        }
    }

    private void Start()
    {
        StartCoroutine(DetectPeriodically());
    }

    private void Update()
    {
        if (!chaseTargetTransform) return;

        ChaseTarget();
    }

    private void ChaseTarget()
    {
        Vector3 direction = (chaseTargetTransform.position - transform.position).normalized;
        transform.position += direction * moveSpeed * Time.deltaTime; ;
    }
}
