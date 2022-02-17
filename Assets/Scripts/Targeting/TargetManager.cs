using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class TargetManager : NetworkBehaviour
{
    public float targetRange;
    public float minRange;

    public GameObject target;
    public bool hasTarget;

    public delegate void OnTargetChanged();
    public static event OnTargetChanged onTargetChangedCallback;

    // Start is called before the first frame update
    void Start()
    {
        hasTarget = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (FindClosestEnemy() == null)
        {
            if(target != null)
            {
                target.GetComponent<Interactable>().OnDeTargeted();
            }
            hasTarget = false;
            target = null;
            onTargetChangedCallback?.Invoke();
        }
    }

    void OnClosestTarget()
    {
        if (IsClient && IsOwner)
        {
            if (FindClosestEnemy() != null)
            {
                onTargetChangedCallback?.Invoke();
                Transform position = gameObject.GetComponent<Transform>();
                hasTarget = true;
                target = FindClosestEnemy();
                target.GetComponent<Interactable>().OnTargeted(position);
                Debug.Log("Target Found = " + target.name);
            }
        }
    }

    public float DistanceToTarget()
    {
        Vector3 position = transform.position;
        Vector3 diff = target.transform.position - position;
        float distance = diff.sqrMagnitude;
        return distance;
    }

    public GameObject FindClosestEnemy()
    {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("Targetable");
        GameObject closest = null;
        Vector3 position = transform.position;
        float distance = targetRange * targetRange;
        float minDistance = minRange * minRange;
        foreach (GameObject go in gos)
        {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance && curDistance > minDistance)
            {
                closest = go;
                distance = curDistance;
            }
        }
        return closest;

    }
}
