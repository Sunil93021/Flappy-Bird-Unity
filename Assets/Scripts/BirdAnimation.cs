using System.Collections;
using UnityEngine;

public class BirdAnimation : MonoBehaviour
{
    private Animator animator;
    private void Awake()
    {
        animator = GetComponent<Animator>();
        
        
    }

    public void StartBirdMoveAnimation()
    {
        
        animator.SetTrigger("StartingGame");
        
    }

    
}
