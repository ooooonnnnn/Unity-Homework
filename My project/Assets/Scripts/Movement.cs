using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float speed;
    private float currentSpeed;
    [SerializeField] private float driftTime;
    private float driftTimer;
    [SerializeField] private float jumpHeight;
    [SerializeField] private int jumpTime;
    [SerializeField] private AnimationCurve jumpCurve;
    private bool grounded = true;
    
    //coroutines
    private Coroutine moveLateral, moveLeft;

    private void Update()
    {
        //left right movement
        if (Input.GetKey(KeyCode.RightArrow))
        {
            if (moveLateral != null) StopCoroutine(moveLateral);
            moveLateral = StartCoroutine(MoveLateral(speed));
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (moveLateral != null) StopCoroutine(moveLateral);
            moveLateral = StartCoroutine(MoveLateral(-speed));
        }
        
        //jumping
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (grounded)
            {
                grounded = false;
                StartCoroutine(Jump());
            }
        }
    }

    IEnumerator MoveLateral(float initialSpeed)
    {
        currentSpeed = initialSpeed;
        driftTimer = driftTime;

        while (driftTimer >= 0)
        {
            transform.Translate(currentSpeed * Time.deltaTime * Vector3.right);
            driftTimer -= Time.deltaTime;
            currentSpeed = initialSpeed * driftTimer / driftTime; //linear slow down
            yield return null;
        }
    }

    IEnumerator Jump()
    {
        int timer = 0;
        while (timer < jumpTime)
        {
            Vector3 position = transform.position;
            position.y = jumpCurve.Evaluate((float)timer / (jumpTime - 1)) * jumpHeight;
            transform.position = position;
            timer++;
            yield return null;
        }
        grounded = true;
    }
}
