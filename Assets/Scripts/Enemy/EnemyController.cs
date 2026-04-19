using UnityEngine;
using UnityEngine.AI;
public class EnemyController : MonoBehaviour
{
   

    [SerializeField] private NoiseChannelSO noiseChannel;
    
    [SerializeField] private NavMeshAgent agent;

    private Vector3 noisePos;

    bool isChasingPlayer = false;



    private void OnEnable()
    {
        noiseChannel.OnNoiseMade += OnNoiseHeard;
    }
    private void OnDisable()
    {
        noiseChannel.OnNoiseMade -= OnNoiseHeard;
    }

    private void OnNoiseHeard(Vector3 noisePosition, float radius)
    {
        float distance = Vector3.Distance(transform.position, noisePosition);


        if (distance <= radius)
        {
            Debug.Log($"{gameObject.name} heard a noise at {noisePosition}!");
            noisePos = noisePosition;
            agent.SetDestination(noisePos); //moves to positon of noise
        }

    }


}
