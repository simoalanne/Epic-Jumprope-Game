using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSwitcher : MonoBehaviour
{
    [SerializeField] private GameObject _hideMenu;
    [SerializeField] private GameObject _showMenu;

    public void switchMenu()
    {
        _showMenu.SetActive(true);
        _hideMenu.SetActive(false);
    }
}
