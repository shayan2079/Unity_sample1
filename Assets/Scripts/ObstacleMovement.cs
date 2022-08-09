using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    [SerializeField] float speed = 10f;
    [SerializeField] float amountToIncreseSpeed = 5f;
    [SerializeField] float maxSpeed = 70f;

    void Update()
    {
        var currSpeed = speed + ((int)(Time.timeSinceLevelLoad / Periods.speedUpPeriod) * amountToIncreseSpeed);
        currSpeed = Math.Clamp(currSpeed, speed, maxSpeed);
        transform.position -= new Vector3(0, 0,  currSpeed * Time.deltaTime);
    }
}
