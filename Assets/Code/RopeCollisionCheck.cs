using UnityEngine;

public class RopeCollisionCheck : MonoBehaviour
{
    [SerializeField] private GameObject _targetRope;
    [SerializeField] private GameObject _endMenu;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (FindObjectOfType<Shield>().ShieldActive)
            {
                FindObjectOfType<Shield>().DeactivateShield();
                return;
            }

            Debug.Log("Player collided with rope");
            _endMenu.SetActive(true);

            Destroy(_targetRope);
            int getScore = FindObjectOfType<Jump>().JumpTimes;
            FindObjectOfType<DisplayScore>().displayScore(getScore);
        }
    }
}
