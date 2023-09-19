using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] float speed = 10f;
    [SerializeField] private bool movingX = false;
    [SerializeField] private bool movingY = false;
    [SerializeField] private bool movingZ = false;
    [SerializeField] private float movingOffset = 200f;
    private Vector3 originalPosition;
    private int Xdirection = 1;
    private int Ydirection = 1;
    private int Zdirection = 1;
    void Start()
    {
        originalPosition = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(movingX)
        {
            transform.Translate(Xdirection * speed * Time.deltaTime, 0, 0);
            if(transform.position.x > originalPosition.x + movingOffset || transform.position.x < originalPosition.x - movingOffset)
            {
                Xdirection *= -1;

                if(transform.position.x > originalPosition.x + movingOffset)
                {
                    transform.position = new Vector3(originalPosition.x + movingOffset, transform.position.y, transform.position.z);
                }
                else
                {
                    transform.position = new Vector3(originalPosition.x - movingOffset, transform.position.y, transform.position.z);
                }
                
            }
        }
        if(movingY)
        {
            transform.Translate(0, Ydirection * speed * Time.deltaTime, 0);
            if (transform.position.y > originalPosition.y + movingOffset || transform.position.y < originalPosition.y - movingOffset)
            {
                Ydirection *= -1;
                if (transform.position.y > originalPosition.y + movingOffset)
                {
                    transform.position = new Vector3(transform.position.x, originalPosition.y + movingOffset, transform.position.z);
                }
                else
                {
                    transform.position = new Vector3(transform.position.x , originalPosition.y - movingOffset, transform.position.z);
                }
            }
        }
        if(movingZ)
        {
            transform.Translate(0, 0 , Zdirection * speed * Time.deltaTime);
            if (transform.position.z > (originalPosition.z + movingOffset) || transform.position.z < (originalPosition.z - movingOffset))
            {
                Zdirection *= -1;
                if (transform.position.z > originalPosition.z + movingOffset)
                {
                    transform.position = new Vector3(transform.position.x, transform.position.y, originalPosition.z + movingOffset);
                }
                else
                {
                    transform.position = new Vector3(transform.position.x, transform.position.y, originalPosition.z - movingOffset);
                }
            }
        }
    }
}
