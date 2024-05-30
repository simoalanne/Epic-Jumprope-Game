using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Debuff : MonoBehaviour
{
    private GameObject debuffManager;
    private string _prefabTag;

    private void Awake()
    {
        debuffManager = GameObject.Find("DebuffManager");
        _prefabTag = gameObject.tag;
    }

    private void OnMouseDown()
    {
        switch (_prefabTag)
        {
            case "Slow":
                debuffManager.GetComponent<DebuffManager>().SlowTime();
                Destroy(gameObject);
                break;
            case "Fast":
                debuffManager.GetComponent<DebuffManager>().FastTime();
                Destroy(gameObject);
                break;
            case "Flash":
                debuffManager.GetComponent<DebuffManager>().FlashBang();
                Destroy(gameObject);
                break;
            case "Shield":
                debuffManager.GetComponent<DebuffManager>().Shield();
                Destroy(gameObject);
                break;
            case "DoubleJump":
                debuffManager.GetComponent<DebuffManager>().DoubleJump();
                Destroy(gameObject);
                break;
            default:
                Destroy(gameObject);
                break;

        }
    }
}
