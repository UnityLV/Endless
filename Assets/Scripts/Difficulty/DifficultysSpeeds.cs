using UnityEngine;

[CreateAssetMenu]
public sealed class DifficultysSpeeds : ScriptableObject
{
    [SerializeField] private float[] _speeds = new float[3];
    
    public float GetSpeedByDifficulty(Difficulty difficulty)
    {
        return _speeds[(int)difficulty];
    }    
}


