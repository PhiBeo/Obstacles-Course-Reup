using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyCannonBall : MonoBehaviour
{
    [Header("Cannon Value: ")]
    [SerializeField] float speed = 2f;
    [SerializeField] float flyingTime = 2f;
    [SerializeField] float minColdDownTime = 2f;
    [SerializeField] float maxColdDownTime = 5f;

    [Header("Flying config: ")]
    [SerializeField] bool FlyingXDirection;
    [SerializeField] bool Xreverse;
    [SerializeField] bool FlyingYDirection;
    [SerializeField] bool Yreverse;
    [SerializeField] bool FlyingZDirection;
    [SerializeField] bool Zreverse;
   

    private float coldDownTime;
    private Vector3 originalPosition;
    private float defaultFlyTime;

    private void Start()
    {
        coldDownTime = Random.Range(minColdDownTime, maxColdDownTime);
        originalPosition = this.transform.position;
        defaultFlyTime = flyingTime;
    }

    void Update()
    {
        coldDownTime -= Time.deltaTime;
        if (coldDownTime <= 0)
        {
            flyingTime -= Time.deltaTime;
            if (FlyingXDirection)
            {
                if (!Xreverse)
                {
                    transform.Translate(speed * Time.deltaTime, 0f, 0f);
                }
                else
                {
                    transform.Translate(-speed * Time.deltaTime, 0f, 0f);
                }
            }
            if (FlyingYDirection)
            {
                if (!Yreverse)
                {
                    transform.Translate(0f, speed * Time.deltaTime, 0f);
                }
                else
                {
                    transform.Translate(0f, -speed * Time.deltaTime, 0f);
                }
            }
            if (FlyingZDirection)
            {
                if (!Zreverse)
                {
                    transform.Translate(0f, 0f, speed * Time.deltaTime);
                }
                else
                {
                    transform.Translate(0f, 0f, -speed * Time.deltaTime);
                }
            }
        }
        if(flyingTime <= 0)
        {
            transform.position = originalPosition;
            coldDownTime = Random.Range(minColdDownTime, maxColdDownTime);
            flyingTime = defaultFlyTime;
        }
    }
}
