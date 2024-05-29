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
        shield.GetComponent<SpriteRenderer>().enabled = false;
        yield return new WaitForSeconds(0.15f);
        shield.GetComponent<SpriteRenderer>().enabled = true;
        yield return new WaitForSeconds(0.15f);
        shield.GetComponent<SpriteRenderer>().enabled = false;
        shield.SetActive(false);
    }
}

