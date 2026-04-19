using UnityEngine;

public class PlayerFootStep : MonoBehaviour
{

    [Header("depenencies")]
    [SerializeField] private PlayerController playerController;
    [SerializeField] private NoiseChannelSO noiseChannel;


    [Header("settings")]
    [SerializeField] private float timeBetweenSteps = 0.4f;
    [SerializeField] public float noiseRadius = 10;


    private float stepTimer;

    private void Update()
    {

        if (!playerController.IsMoving) // reset timer if not moving
        {
            stepTimer = 0;
            return;
        }

        if (playerController.IsSneaking) // no noise when sneaking
        {
            return;
        }

        stepTimer -= Time.deltaTime; //player moving

        if (stepTimer <= 0)
        {
            if(noiseChannel != null)
            {
                noiseChannel.RaiseEvent(transform.position, noiseRadius);
            }
            stepTimer = timeBetweenSteps; // reset timer
        }


    }
       
}
