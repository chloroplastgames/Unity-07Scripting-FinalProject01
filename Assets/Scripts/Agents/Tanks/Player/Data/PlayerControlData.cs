using UnityEngine;

[CreateAssetMenu(fileName = "NewPlayerControl", menuName = "ScriptableObject/Agents/Tanks/Player/Control/PlayerControl")]
public class PlayerControlData : ScriptableObject
{
    public KeyCode Forward => forward;
    public KeyCode Backward => backward;
    public KeyCode TurnRight => turnRight;
    public KeyCode TurnLeft => turnLeft;
    public KeyCode Shoot => shoot;
    public KeyCode Special => special;

    [SerializeField] private KeyCode forward;
    [SerializeField] private KeyCode backward;
    [SerializeField] private KeyCode turnRight;
    [SerializeField] private KeyCode turnLeft;
    [SerializeField] private KeyCode shoot;
    [SerializeField] private KeyCode special;
}