using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] private Vector2 velocity;
    [SerializeField] private Transform playerVisuals;
    [SerializeField] private GameObject pausePanel;

    private Rigidbody2D myrigidbody2d;
    private const string POLES = "Poles";
    private PlayerInput playerInput;
    private Animator animator;
    private bool isPause = false;
    private GameManager gameManager;
    private void Start()
    {
        myrigidbody2d = GetComponent<Rigidbody2D>();
        playerInput = GetComponent<PlayerInput>();
        animator = playerVisuals.GetComponent<Animator>();
        pausePanel.SetActive(false);
        gameManager = FindAnyObjectByType<GameManager>();
        
    }
    private void OnJump(InputValue value)
    {
        myrigidbody2d.linearVelocityY = velocity.y;
        animator.SetBool("isFlying", true);
        StartCoroutine(EndAnimation());

    }
    IEnumerator EndAnimation()
    {
        yield return new WaitForSeconds(0.5f);
        animator.SetBool("isFlying", false);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == POLES)
        {
            Die();
        }
    }

    private void Die()
    {
        playerInput.actions.Disable();
        gameManager.LoadGameOver();
    }

    private void OnPause(InputValue value)
    {
        if (isPause)
        {
            UnPause();
        }
        else
        {
            Pause();
        }
    }

    public void UnPause()
    {
        Time.timeScale = 1.0f;
        isPause = false;
        if(pausePanel != null)
        {
            pausePanel.SetActive(false);

        }   

    }

    public void Pause()
    {
        Time.timeScale = 0.0f;
        isPause = true;
        pausePanel.SetActive(true);
    }

    
}
