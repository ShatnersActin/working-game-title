using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public float radius = 3f;
    [SerializeField]
    bool isTarget = false;
    Transform player;
    [SerializeField]
    bool hasInteracted = false;

    public virtual void Interact()
    {
        Debug.LogError("Interacting with " + transform.name);
    }

    public void Update()
    {
        if (isTarget && !hasInteracted)
        {
            float distance = Vector3.Distance(player.position, transform.position);
            if(distance <= radius)
            {
                Interact();
                hasInteracted = true;
            }
        }
    }

    public void OnTargeted(Transform playerTransform)
    {
        isTarget = true;
        player = playerTransform;
        hasInteracted = false;
    }

    public void OnDeTargeted()
    {
        isTarget = false;
        player = null;
        hasInteracted = false;
    }

    private void OnDrawGizmosSelected ()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }

    private void OnEnable()
    {
        TargetManager.onTargetChangedCallback += OnDeTargeted;
    }

}
