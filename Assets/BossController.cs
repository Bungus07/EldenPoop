using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BossController : MonoBehaviour
{
    private NavMeshAgent agent;
    public float Radius;
    public Transform CentrePoint;
    public bool IsAggressive;
    private EnemyControls EnemyControlscript;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        CentrePoint = gameObject.transform;
        EnemyControlscript = gameObject.GetComponent<EnemyControls>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!IsAggressive)
        {
            if (agent.remainingDistance <= agent.stoppingDistance)
            {
                Vector3 Point;
                if (RandomPoints(CentrePoint.position, Radius, out Point))
                {
                    Debug.DrawRay(Point, Vector3.up, Color.green, 1.0f);
                    agent.SetDestination(Point);
                }
            }
        }
        else if(IsAggressive) 
        {
            agent.SetDestination(EnemyControlscript.Player.gameObject.transform.position);
        }
    }
    bool RandomPoints(Vector3 Centre, float range, out Vector3 result)
    {
        Vector3 RandomPoint = Centre + Random.insideUnitSphere * range;
        NavMeshHit Hit;
        if (NavMesh.SamplePosition(RandomPoint, out Hit, 1.0f, NavMesh.AllAreas))
        {
            result = Hit.position;
            return true;
        }
        result = Vector3.zero; 
        return false;
    }
}

