using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int _playerCount;
    public int PlayerCount
    {
        get { return _playerCount; }
        set { _playerCount = value; }
    }

    public static GameManager Instance;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
}
