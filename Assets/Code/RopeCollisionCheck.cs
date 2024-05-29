using TMPro;
using UnityEngine;

public class RopeCollisionCheck : MonoBehaviour
{
    [SerializeField] private GameObject _targetRope;
    [SerializeField] private GameObject _endMenu;
    [SerializeField] private GameObject _deathSoundPlayer;
    [SerializeField] private TMP_Text _textMeshPro;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (GameManager.Instance.PlayerCount == 2)
        {
            if (collision.gameObject.CompareTag("Player2"))
            {
                Destroy(collision.gameObject);
                _textMeshPro.text = "Player 2 wins!";
                _endMenu.SetActive(true);
                Destroy(_targetRope);
                return;

            }
            else if (collision.gameObject.CompareTag("Player"))
            {
                Destroy(collision.gameObject);
                _textMeshPro.text = "Player 1 wins!";
                _endMenu.SetActive(true);
                Destroy(_targetRope);
                return;
            }
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            if (FindObjectOfType<Shield>().ShieldActive)
            {
                FindObjectOfType<Shield>().DeactivateShield();
                return;
            }
            _deathSoundPlayer.GetComponent<SoundEffectPlayer>().PlaySoundEffect(0);
            Debug.Log("Player collided with rope");
            _endMenu.SetActive(true);

            Destroy(_targetRope);
            int getScore = FindObjectOfType<Jump>().JumpTimes;
            FindObjectOfType<DisplayScore>().displayScore(getScore);
        }
    }
}
