using System.Collections.Generic;
using UnityEngine;
using System.Linq;

/// <summary>
/// Spawner of power ups. Spawns one power up for spot every some seconds during each round
/// </summary>

public class PowerUpSpawner : MonoBehaviour, IObserver<StartRoundEventArgs>, IObserver<EndRoundEventArgs>
{
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] GameObject[] powerUps;
    [SerializeField] private int timeBetweenPowerUps = 5;

    private readonly List<GameObject> powerUpInstancesList = new List<GameObject>();

    private List<Transform> spawnPointsList = new List<Transform>();
    private Coroutine spawnRoutine;

    private GameController gameController;

    private void Awake()
    {
        gameController = FindObjectOfType<GameController>();
    }

    private void Start()
    {
        gameController.StartRoundSubject.Add(this);
        gameController.EndRoundSubject.Add(this);

        ResetSpawner();
    }

    private void OnDestroy()
    {
        gameController.StartRoundSubject?.Remove(this);
        gameController.EndRoundSubject?.Remove(this);
    }

    public void OnNotify(StartRoundEventArgs parameter)
    {
        StartSpawner();
    }

    public void OnNotify(EndRoundEventArgs parameter)
    {
        StopSpawner();
    }

    private void StartSpawner()
    {
        if (spawnPointsList.Count == 0) return;

        int powerUpIndex = Random.Range(0, powerUps.Length);
        int pointIndex = Random.Range(0, spawnPointsList.Count);

        Vector3 spawnPosition =
            new Vector3(
                spawnPointsList[pointIndex].position.x,
                spawnPointsList[pointIndex].position.y + 0.5f,
                spawnPointsList[pointIndex].position.z
                );

        GameObject powerUpInstance =
            Instantiate(powerUps[powerUpIndex], spawnPosition, spawnPointsList[pointIndex].rotation, transform);

        powerUpInstancesList.Add(powerUpInstance);

        // In order to avoid multiple power ups spawning in the same spot
        spawnPointsList.RemoveAt(pointIndex);

        spawnRoutine = CoroutinesHelperSingleton.Instance.WaitForSeconds(timeBetweenPowerUps, () => StartSpawner());
    }

    private void StopSpawner()
    {
        CoroutinesHelperSingleton.Instance.StopCoroutine(spawnRoutine);

        // Destroy power ups for new round
        foreach(GameObject instance in powerUpInstancesList)
        {
            Destroy(instance);
        }

        ResetSpawner();
    }

    private void ResetSpawner()
    {
        spawnPointsList.Clear();
        spawnPointsList = spawnPoints.ToList();

        powerUpInstancesList.Clear();
    }
}