using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAttack : MonoBehaviour
{
    public float detectionRadius = 5.0f;
    private Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, detectionRadius);
        bool isCharacterNearby = false;
        Vector3 targetPosition = Vector3.zero;

        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.CompareTag("Character") && hitCollider.gameObject != this.gameObject)
            {
                isCharacterNearby = true;
                targetPosition = hitCollider.transform.position;
                break;
            }
        }
        
        animator.SetBool("isAttacking", isCharacterNearby);
        if (isCharacterNearby)
        {
            Vector3 direction = (targetPosition - transform.position).normalized;
            Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
        }
    }
    void OnDrawGizmos()
    {
        if (Vuforia.VuforiaBehaviour.Instance.enabled)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, detectionRadius);
        }
    }
}
