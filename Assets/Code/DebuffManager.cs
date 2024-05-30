using System.Collections;
using UnityEngine;

public class DebuffManager : MonoBehaviour
{
    [SerializeField] private GameObject flashbangPrefab;

    public void FlashBang()
    {
        if (FindObjectOfType<Flashbang>() != null)
        {
            return;
        }

        Instantiate(flashbangPrefab, new Vector3(0, 0, 0), Quaternion.identity);
    }

    public void SlowTime()
    {
        GetComponent<SoundEffectPlayer>().PlaySoundEffect(0);
        if (Time.timeScale == 0.7f)
        {
            return;
        }

        StartCoroutine(ApplySlow());
    }

    public void FastTime()
    {
        GetComponent<SoundEffectPlayer>().PlaySoundEffect(0);
        if (Time.timeScale == 1.3f)
        {
            return;
        }

        StartCoroutine(ApplyFast());
    }

    public void Shield()
    {
        GetComponent<SoundEffectPlayer>().PlaySoundEffect(0);
        if (FindObjectOfType<Shield>().ShieldActive)
        {
            return;
        }
        FindObjectOfType<Shield>().ActivateShield();
    }

    public void DoubleJump()
    {
        GetComponent<SoundEffectPlayer>().PlaySoundEffect(0);
        if (FindObjectOfType<Jump>().AllowDoubleJump)
        {
            return;
        }

        FindObjectOfType<Jump>().AllowDoubleJump = true; // Find the Jump script and set the AllowDoubleJump property to true
    }

    private IEnumerator ApplySlow()
    {
        var debuffTime = 2f;
        var slowTimeScale = 0.7f;

        Time.timeScale = slowTimeScale;
        yield return new WaitForSeconds(debuffTime);
        Time.timeScale = 1;
        yield break;
    }

    private IEnumerator ApplyFast()
    {
        var debuffTime = 2f;
        var fastTimeScale = 1.3f;

        Time.timeScale = fastTimeScale;
        yield return new WaitForSeconds(debuffTime);
        Time.timeScale = 1;
        yield break;
    }
}
