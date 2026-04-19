using System;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "NoiseChannelSO", menuName = "Events/Noise event")]
public class NoiseChannelSO : ScriptableObject
{
    public event Action<Vector3, float> OnNoiseMade;

    public void RaiseEvent(Vector3 sourcePos, float noiseRadius)
    {
        OnNoiseMade?.Invoke(sourcePos, noiseRadius);
    }
}
