using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    [SerializeField] Animator animator;
    void Awake()
    {
        if (!animator)
        {
            if (!TryGetComponent<Animator>(out animator))
            {
                animator = GetComponentInChildren<Animator>();
                if (!animator)
                {
                    Debug.LogError("Animator component not found on PlayerAnimations script attached object or its children.");
                }
            }
        }

    }
    public void PlayRunAnimation(float speed)
    {
        animator.SetFloat("speed", speed);
    }
}
