using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebuffManager : MonoBehaviour
{
    [SerializeField] private GameObject flashbangPrefab;

    public void FlashBang()
    {
        Instantiate(flashbangPrefab, new Vector3(0,0,0), Quaternion.identity);
    }

    public void SlowTime()
    {
        StartCoroutine(ApplySlow());
    }

    public void FastTime()
    {
        StartCoroutine(ApplyFast());
    }

    public void Shield()
    {

    }

    public void DoubleJump()
    {

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
