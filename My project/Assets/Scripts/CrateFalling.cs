using System;
using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public class CrateFalling : MonoBehaviour
{
    [SerializeField] private float distanceOpenChute;
    private bool chuteOpen = false;
    [SerializeField] private float chuteDrag;
    [SerializeField] private Rigidbody rigidbody;
    [SerializeField] private GameObject parachute; 

    private void Update()
    {
        //check distance
        if (!chuteOpen && Physics.Raycast(transform.position, Vector3.down, distanceOpenChute, 1))
        {
            print("yes");
            chuteOpen = true;
            parachute.SetActive(true);
            rigidbody.drag = chuteDrag;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            print("package caught");
        }
        Destroy(gameObject);
    }
}
