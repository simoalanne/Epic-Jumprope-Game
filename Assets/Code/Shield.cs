using System.Collections;
using UnityEngine;

public class Shield : MonoBehaviour
{
    private bool _shieldActive = false;
    public bool ShieldActive => _shieldActive;
    public void ActivateShield()
    {
        transform.GetChild(0).gameObject.SetActive(true); // Activate the shield object
        _shieldActive = true;
    }

    public void DeactivateShield()
    {
        _shieldActive = false;
        StartCoroutine(FlashShield());
    }

    IEnumerator FlashShield()
    {
        var shield = transform.GetChild(0).gameObject;
        var shieldRenderer = shield.GetComponent<SpriteRenderer>();
        var flashDuration = 0.25f;
        var flashCount = 1;
        for (int i = 0; i < flashCount; i++)
        {
            shieldRenderer.enabled = false;
            yield return new WaitForSeconds(flashDuration);
            shieldRenderer.enabled = true;
            yield return new WaitForSeconds(flashDuration);
        }
        shield.SetActive(false);
    }
}

