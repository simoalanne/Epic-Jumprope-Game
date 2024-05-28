using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DisplayScore : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _textMeshPro;

    // Start is called before the first frame update
    
    public void displayScore(int score)
    {
        _textMeshPro.text = "Score: " + score.ToString();
    }
}
