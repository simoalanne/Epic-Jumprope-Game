using TMPro;
using UnityEngine;

public class RopeCollisionCheck : MonoBehaviour
{
    [SerializeField] private GameObject _targetRope;
    [SerializeField] private GameObject _endMenu;
    [SerializeField] private GameObject _deathSoundPlayer;
    [SerializeField] private TMP_Text _playerWinsText;
    [SerializeField] private TMP_Text[] _highScoreTexts;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Jump[] jumps = FindObjectsOfType<Jump>();
        int highestJump = 0;

        foreach (Jump jump in jumps)
        {
            if (jump.JumpTimes > highestJump)
            {
                highestJump = jump.JumpTimes;
            }
        }
        int getScore = highestJump;
        FindObjectOfType<HighScoreManager>().CheckForHighScore(getScore);

        for (int i = 0; i < FindObjectOfType<HighScoreManager>().HighScores.Count; i++)
        {
            _highScoreTexts[i].text = i + 1 + ". " + FindObjectOfType<HighScoreManager>().HighScores[i].ToString();
        }

        if (GameManager.Instance.PlayerCount == 2)
        {
            if (collision.gameObject.CompareTag("Player2"))
            {
                Destroy(collision.gameObject);
                _playerWinsText.text = "Player 1 wins!";
                _endMenu.SetActive(true);
                Destroy(_targetRope);
                _deathSoundPlayer.GetComponent<SoundEffectPlayer>().PlaySoundEffect(0);
            }
            else if (collision.gameObject.CompareTag("Player"))
            {
                Destroy(collision.gameObject);
                _playerWinsText.text = "Player 2 wins!";
                _endMenu.SetActive(true);
                Destroy(_targetRope);
                _deathSoundPlayer.GetComponent<SoundEffectPlayer>().PlaySoundEffect(0);
            }
            FindObjectOfType<DisplayScore>().displayScore(getScore);
            return;
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            if (FindObjectOfType<Shield>().ShieldActive)
            {
                FindObjectOfType<Shield>().DeactivateShield();
                return;
            }
            _deathSoundPlayer.GetComponent<SoundEffectPlayer>().PlaySoundEffect(0);
            _endMenu.SetActive(true);
            FindObjectOfType<DisplayScore>().displayScore(getScore);
            Destroy(_targetRope);
        }
    }
}
