using UnityEngine;

public class PlayerAnimatorDetector : MonoBehaviour
{
    private PlayerController playerController;
    private Animator animator;

    void Start()
    {
        playerController = GetComponent<PlayerController>();
        animator = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        if(playerController.isMoving==true)
        {
            animator.SetBool("Walk", true);
        }
        else
        {
            animator.SetBool("Walk", false);
        }
    }
}