using UnityEngine;

[CreateAssetMenu(menuName ="Prototype/Data/Camera")]
public class CameraData : ScriptableObject
{
    [SerializeField] private float _time;

    [SerializeField] private float _maxDistanceCenter;

    public float Time { get => _time; }

    public float MaxDistanceCenter { get => _maxDistanceCenter; }
}
