using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    public Camera m_Camera;

    private void FixedUpdate()
    {
        m_Camera = Camera.main;

        transform.LookAt(transform.position + m_Camera.transform.rotation * Vector3.forward, m_Camera.transform.rotation * Vector3.up);
    }
}