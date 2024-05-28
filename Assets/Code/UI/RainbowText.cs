using System.Collections;
using UnityEngine;
using TMPro;

public class RainbowText : MonoBehaviour
{
    [SerializeField] private TMP_Text[] _texts;

    void Start()
    {
        StartCoroutine(RainbowEffect());
    }

    private IEnumerator RainbowEffect()
    {
        while (true)
        {
            foreach (var text in _texts)
            {
                var color = text.color;
                color.r = Random.Range(0f, 1f);
                color.g = Random.Range(0f, 1f);
                color.b = Random.Range(0f, 1f);
                text.color = color;
            }
            yield return new WaitForSeconds(0.5f);
        }
    }
}
