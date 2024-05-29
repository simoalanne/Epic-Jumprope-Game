using UnityEngine;

public class SpawnPlayers : MonoBehaviour
{
    [SerializeField] private GameObject _playerPrefab;
    [SerializeField] private GameObject _playerPrefab2;
    void Start()
    {
        if (GameManager.Instance.PlayerCount > 1)
        {
            Instantiate(_playerPrefab, new Vector2(-1.1f, -0.56f), Quaternion.identity);
            Instantiate(_playerPrefab2, new Vector2(1.1f, -0.56f), Quaternion.identity);
        }

        else
        {
            Instantiate(_playerPrefab, new Vector2(0, -0.56f), Quaternion.identity);
        }
    }
}
