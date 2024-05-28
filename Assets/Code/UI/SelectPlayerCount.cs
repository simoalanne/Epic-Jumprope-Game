using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SelectPlayerCount : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private TMP_Text _text;

    public void CheckPlayerCount()
    {
        if (_slider.value <= 0.5f)
        {
            _text.text = "Players: 1";
            GameManager.Instance.PlayerCount= 1;
        }
        else
        {
            _text.text = "Players: 2";
            GameManager.Instance.PlayerCount = 2;
        }
    }
}
