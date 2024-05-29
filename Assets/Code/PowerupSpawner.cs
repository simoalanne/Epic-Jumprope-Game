using UnityEngine;

public class PowerupSpawner : MonoBehaviour
{
    [SerializeField] GameObject flashbangPrefab;
    [SerializeField] GameObject bubblePrefab;
    [SerializeField] GameObject doublejumpPrefab;
    [SerializeField] GameObject speedupPrefab;
    [SerializeField] GameObject speeddownPrefab;
    // Kuinka usein spawnaa
    [SerializeField] private float spawnRate;
    // Spawnerialue
    [SerializeField] private float spawnRadius;

    private float spawnTimer;

    void Awake()
    {
        if (GameManager.Instance.PlayerCount == 2)
        {
            gameObject.SetActive(false); // Disable powerup spawner if there are two players
        }
    }

    void Update()
    {
        spawnTimer += Time.deltaTime;

        if (spawnTimer >= spawnRate)
        {
            spawnTimer = 0;
            spawnPowerup();
        }
    }

    private void spawnPowerup()
    {
        Vector3 spawnPosition = transform.position + Random.insideUnitSphere * spawnRadius;
        var random = Random.Range(0, 5);
        switch (random)
        {
            case 0:
                Instantiate(flashbangPrefab, spawnPosition, Quaternion.identity);
                break;
            case 1:
                Instantiate(bubblePrefab, spawnPosition, Quaternion.identity);
                break;
            case 2:
                Instantiate(doublejumpPrefab, spawnPosition, Quaternion.identity);
                break;
            case 3:
                Instantiate(speedupPrefab, spawnPosition, Quaternion.identity);
                break;
            case 4:
                Instantiate(speeddownPrefab, spawnPosition, Quaternion.identity);
                break;
            default:
                break;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, spawnRadius);
    }
}
