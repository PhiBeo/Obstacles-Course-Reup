using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instant;
    private float timer = 0f;
    public bool isWin = false;
    [SerializeField] GameObject panel;
    // Start is called before the first frame update
    void Start()
    {
        if (Instant == null)
        {
            Instant = this;
        }
        else
        {
            Destroy(gameObject);
        }

        panel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(!isWin)
        {
            timer += Time.deltaTime;
        }
        if(isWin)
        {
            panel.SetActive(true);
        }
    }

    public float getTimer()
    {
        return Mathf.Round( timer);
    }

    public void setWin(bool win)
    {
        isWin = win;
    }
}
