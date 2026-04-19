using UnityEngine;

public class EnemyVision : MonoBehaviour
{
    [Header("Vision settings")]
    public float viewRadius = 10f;
    [Range(0, 360)] public float visionAngle = 90f;


    [Header("Dependencies")]
    [SerializeField] private LayerMask targetMask; // player mask
    [SerializeField] private LayerMask obstructionMask; // walls mask
    [SerializeField] private Transform eyes; //enemy eyes position


    public bool CanSeePlayer {  get; private set; }
    public Vector3 LastKnownPlayerPos { get; private set; }


    private void Update()
    {
        VisionCheck();
    }


    private void VisionCheck()
    {
        CanSeePlayer = false; // resets every frame

        Collider[] targetInViewRadius = Physics.OverlapSphere(eyes.position, viewRadius, targetMask);

        if ( targetInViewRadius.Length > 0 )
        {
            Transform target = targetInViewRadius[0].transform;
            Vector3 dirToTarget = (target.position - eyes.position).normalized;

            //Is the player inside our view cone
            if (Vector3.Angle(eyes.forward, dirToTarget) < visionAngle / 2)
            {
                float distanceToTarget = Vector3.Distance(eyes.position, target.position);
                //raycast to see if there is an obstruction between us and the player
                if (!Physics.Raycast(eyes.position, dirToTarget, distanceToTarget, obstructionMask))
                {
                    CanSeePlayer = true;
                    LastKnownPlayerPos = target.position;
                    Debug.Log($"{gameObject.name} can see the player at {target.position}!");

                    Debug.DrawLine(eyes.position, target.position, Color.red);
                }
            }
        }
    }



}
