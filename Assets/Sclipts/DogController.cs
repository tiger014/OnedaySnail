using UnityEngine;
using UnityEngine.AI;

public class DogController : MonoBehaviour
{
    public Transform goal;

    void Update()
    {
        NavMeshAgent agent = GetComponent<NavMeshAgent>();
        agent.destination = goal.position;
    }
}