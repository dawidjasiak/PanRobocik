using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyState
{

    protected Enemy enemyBase;
    protected EnemyStateMachine stateMachine;
    
    protected string animBoolName;
    protected float stateTimer;

    protected bool triggerCalled;

    public EnemyState(Enemy enemyBase, EnemyStateMachine stateMachine, string animBoolName)
    {
        this.enemyBase = enemyBase;
        this.stateMachine = stateMachine;
        this.animBoolName = animBoolName;
    }
    public virtual void Enter()
    {
        enemyBase.Anim.SetBool(animBoolName, true);

        triggerCalled = false;
    }
    
    public virtual void Update()
    {
        stateTimer -= Time.deltaTime;
    }

    public virtual void Exit()
    {
        enemyBase.Anim.SetBool(animBoolName, false);
    }

    public void AnimationTrigger()
    {
        triggerCalled = true;
    }
    
    protected Vector3 GetNextPathPoint()
    {
        NavMeshAgent agent = enemyBase.Agent;
        NavMeshPath path = agent.path;

        if (path.corners.Length < 2)
            return agent.destination;

        for (int i = 0; i < path.corners.Length; i++)
        {
            if (Vector3.Distance(agent.transform.position, path.corners[i]) < 1)
            {
                return path.corners[i + 1];
            }
        }

        return agent.destination;
    }

    public virtual void AbilityTrigger()
    {
        
    }
}