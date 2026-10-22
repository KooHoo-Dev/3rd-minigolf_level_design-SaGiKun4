using UnityEngine;

public class RockSpawner : MonoBehaviour
{
    [SerializeField] private BoxCollider spawnArea;
    [SerializeField] private GameObject rockPrefab;
    [SerializeField] private int count = 1;
    [SerializeField] private float lifeTime = 20f;

    private GameObject[] rocks;
    private float[] timers;

    private void Start()
    {
        rocks = new GameObject[count];
        timers = new float[count];

        for (int i = 0; i < count; i++)
        {
            rocks[i] = Instantiate(rockPrefab);
            SpawnRock(i);
        }
    }

    private void Update()
    {
        for (int i = 0; i < count; i++)
        {
            if (!rocks[i].activeSelf)
            {
                SpawnRock(i);
                continue;
            }

            timers[i] -= Time.deltaTime;

            if (timers[i] <= 0f)
            {
                rocks[i].SetActive(false);
            }
        }
    }

    private void SpawnRock(int index)
    {
        Vector3 randomPosition = new Vector3(
            Random.Range(-spawnArea.size.x / 2f, spawnArea.size.x / 2f),
            Random.Range(-spawnArea.size.y / 2f, spawnArea.size.y / 2f),
            Random.Range(-spawnArea.size.z / 2f, spawnArea.size.z / 2f)
        );

        randomPosition += spawnArea.center;
        randomPosition = spawnArea.transform.TransformPoint(randomPosition);

        rocks[index].transform.position = randomPosition;
        rocks[index].transform.rotation = Quaternion.identity;
        rocks[index].SetActive(true);

        timers[index] = lifeTime;
    }
}