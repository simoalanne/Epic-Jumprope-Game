using UnityEngine;

public class SoundEffectPlayer : MonoBehaviour
{
    [SerializeField] private AudioClip[] _soundEffect;
    [SerializeField] private bool _loopSound = false;
    [SerializeField] private float _volumeFromZeroToOne = 0.1f;
    private AudioSource _audioSource;

    private void Awake()
    {
        if (!TryGetComponent(out _audioSource))
        {
            _audioSource = gameObject.AddComponent<AudioSource>();
        }

        _audioSource.playOnAwake = false;
        _audioSource.volume = _volumeFromZeroToOne;
    }

    public void PlaySoundEffect(int index)
    {
        if (index < 0 || index >= _soundEffect.Length)
        {
            Debug.LogError("SoundEffectPlayer: Index out of range");
            return;
        }

        else
        {
            _audioSource.clip = _soundEffect[index];
            _audioSource.loop = _loopSound;
            _audioSource.Play();
        }
    }

    public void StopSoundEffect()
    {
        if (_audioSource.isPlaying)
        {
            _audioSource.Stop();
        }
    }
}
