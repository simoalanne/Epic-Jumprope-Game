using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] private string _sceneName;
    public void Play()
    {
        SceneManager.LoadSceneAsync(_sceneName);
    }
}