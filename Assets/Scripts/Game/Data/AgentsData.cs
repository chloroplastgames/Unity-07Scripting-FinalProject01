using UnityEngine;

[CreateAssetMenu(fileName = "NewAgents", menuName = "ScriptableObject/Game/Agents")]
public class AgentsData : ScriptableObject
{
    public GameObject Player1Tank => player1Tank;
    public GameObject Player2Tank => player2Tank;
    public GameObject CPUTank => cpuTank;

    [SerializeField] private GameObject player1Tank;
    [SerializeField] private GameObject player2Tank;
    [SerializeField] private GameObject cpuTank;
}