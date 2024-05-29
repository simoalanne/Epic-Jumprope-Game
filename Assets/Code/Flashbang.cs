using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Flashbang : MonoBehaviour
{
    [SerializeField] private AudioClip _flashbangSound;
    [SerializeField] private float _flashDuration = 2f;
    private float _alphaValue = 1f;
    private RawImage _flashImage;

    public void Start()
    {
        GetComponent<SoundEffectPlayer>().PlaySoundEffect(0);
        _flashImage = GetComponentInChildren<RawImage>();
        _flashImage.color = new Color(1, 1, 1, _alphaValue);
        StartCoroutine(FlashAnim());
    }

    IEnumerator FlashAnim()
    {
        yield return new WaitForSeconds(0.5f);
        float startTime = Time.time;
        float endTime = startTime + _flashDuration;
        while (Time.time < endTime)
        {
            float elapsed = Time.time - startTime;
            float normalizedTime = elapsed / _flashDuration;
            _alphaValue = Mathf.Exp(-normalizedTime * 2.5f);
            _flashImage.color = new Color(1, 1, 1, _alphaValue);
            yield return null;
        }

        _flashImage.color = new Color(1, 1, 1, 0);
        Destroy(gameObject);
    }
}
