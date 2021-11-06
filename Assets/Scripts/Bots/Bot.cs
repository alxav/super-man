using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(NavMeshAgent))]
public class Bot : MonoBehaviour
{
    public static event Action<bool> KillBadBot;
    [SerializeField] private integerVariable kills;
    
    private NavMeshAgent navMeshAgent;
    private Animator animator;
    private HelperBot helperBot;
    private EnumBot type;
    private bool isKill;

    private float x;
    private float y;
    private static readonly int State = Animator.StringToHash("State");


    void Awake()
    {
        animator = GetComponent<Animator>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        helperBot = new HelperBot();
    }

    public void Constructor(EnumBot type, float speed, float x, float y)
    {
        this.type = type;
        this.x = x;
        this.y = y;
        navMeshAgent.speed = speed;
        navMeshAgent.SetDestination(helperBot.GeneratePoint(x, y));
    }

    public void Kill()
    {
        if (type == EnumBot.Good || isKill) return;

        isKill = true;
        
        navMeshAgent.enabled = false;

        kills.Value++;

        animator.SetInteger(State, (int)StateAnimatorBot.Death);
        
        StartCoroutine(CoroutineDestroy());
    }


    private IEnumerator CoroutineDestroy()
    {
        yield return new WaitForSeconds(0.5f);
        
        KillBadBot?.Invoke(true);
        Destroy(gameObject);
    }

    private void Update()
    {
        if (isKill) return;
        
        if (navMeshAgent && navMeshAgent.remainingDistance <= 0.1f)
        {
            navMeshAgent.SetDestination(helperBot.GeneratePoint(x, y));
        }
    }
    
}

public enum StateAnimatorBot
{
    Run,
    Death
}