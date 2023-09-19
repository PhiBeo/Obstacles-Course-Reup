using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    [SerializeField] private float minimumSpawnTime = 5;
    [SerializeField] private float maximumSpawnTime = 10;

    private float countDown;

    private void Update()
    {
        countDown -= Time.deltaTime;
        if (countDown <= 0)
        {
            Instantiate(prefab, transform.position, Quaternion.identity);
            restartCountdown();
        }
    }

    private void Start()
    {
        countDown = Random.Range(minimumSpawnTime, maximumSpawnTime);
    }

    void restartCountdown()
    {
        countDown = Random.Range(minimumSpawnTime, maximumSpawnTime);
    }
}
