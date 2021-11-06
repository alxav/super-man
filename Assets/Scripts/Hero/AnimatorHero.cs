using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AnimatorHero : MonoBehaviour
{
    private Animator animator;
    private static readonly int State = Animator.StringToHash("State");

    // Start is called before the first frame update
    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void Idle()
    {
        if (animator)
            animator.SetInteger(State, (int) StateAnimatorHero.Idle);
    }

    public void Fly()
    {
        if (animator)
            animator.SetInteger(State, (int) StateAnimatorHero.Fly);
    }
}

public enum StateAnimatorHero
{
    Idle,
    Fly
}