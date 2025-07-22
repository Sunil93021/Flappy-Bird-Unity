using UnityEngine;

public class MovePoles : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 1f;
    [SerializeField] private int score = 1;

    private const string PLAYER = "Player";
    private AudioManager audioManager;

    void Update()
    {
        transform.position -= new Vector3 (moveSpeed * Time.deltaTime,0,0);
        audioManager  = FindAnyObjectByType<AudioManager>();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == PLAYER)
        {
            ScoreKeeper.GetInstance().AddScore(score);
            audioManager.PlayScoreSound();
        }
    }
}
