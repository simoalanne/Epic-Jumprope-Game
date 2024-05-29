using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SelectPlayerCount : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private TMP_Text _text;
    [SerializeField] private Sprite _1player;
    [SerializeField] private Sprite _2player;
    [SerializeField] private Image _targetImage;

    void Awake()
    {
        CheckPlayerCount();
    }

    public void CheckPlayerCount()
    {
        if (_slider.value <= 0.5f)
        {
            _text.text = "Players: 1";
            GameManager.Instance.PlayerCount = 1;
            _targetImage.sprite = _1player;


        }
        else
        {
            _text.text = "Players: 2";
            GameManager.Instance.PlayerCount = 2;
            _targetImage.sprite = _2player;
        }
    }
}
