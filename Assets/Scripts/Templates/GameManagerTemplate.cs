using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerTemplate : MonoBehaviour
{
    [SerializeField] private int numberRoundsToWin = 4;
    [SerializeField] private float startDelay = 3f;
    [SerializeField] private float endDelay = 3f;
    [SerializeField] private CameraController cameraController;
    [SerializeField] private GameObject canvasGameOver;
    [SerializeField] private GameObject cameraGameplayParent;
    [SerializeField] private GameObject tankPrefab;
    [SerializeField] private TankManagerTemplate[] tankManagers;

    private int roundNumber;
    private WaitForSeconds startWait;
    private WaitForSeconds endWait;
    private TankManagerTemplate roundWinner;
    private TankManagerTemplate gameWinner;

    private void Start()
    {
        startWait = new WaitForSeconds(startDelay);
        endWait = new WaitForSeconds(endDelay);

        SpawnAllTanks();
        SetCameraTargets();

        StartCoroutine(GameLoop());
    }

    private void SpawnAllTanks()
    {
        for (int i = 0; i < tankManagers.Length; i++)
        {
            tankManagers[i].Instance = Instantiate(tankPrefab, tankManagers[i].SpawnPoint.position, tankManagers[i].SpawnPoint.rotation);

            tankManagers[i].PlayerNumber = i++;
            tankManagers[i].Setup();
        }
    }

    private void SetCameraTargets()
    {
        Transform[] targets = new Transform[tankManagers.Length];

        for (int i = 0; i < targets.Length; i++)
        {
            targets[i] = tankManagers[i].Instance.transform;
        }

        cameraController.Targets = targets;
    }

    private IEnumerator GameLoop()
    {
        yield return StartCoroutine(RoundStarting());

        yield return StartCoroutine(RoundPlaying());

        yield return StartCoroutine(RoundEnding());

        if (gameWinner != null)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        else
        {
            StartCoroutine(GameLoop());
        }
    }

    private IEnumerator RoundStarting()
    {
        ResetAllTanks();
        DisableTankControl();

        cameraController.ResetCamera();

        roundNumber++;
        // Show round number

        yield return startWait;
    }

    private IEnumerator RoundPlaying()
    {
        EnableTankControl();

        // Clear screen

        while(!OneTankLeft())
        {
            yield return null;
        }
    }

    private IEnumerator RoundEnding()
    {
        DisableTankControl();

        roundWinner = null;

        roundWinner = GetRoundWinner();

        if (roundWinner != null)
        {
            roundWinner.Wins++;
        }

        gameWinner = GetGameWinner();

        // Show game winner or not

        yield return endWait;
    }

    private bool OneTankLeft()
    {
        int numberTanksLeft = 0;

        for (int i = 0; i < tankManagers.Length; i++)
        {
            if (tankManagers[i].Instance.activeSelf)
            {
                numberTanksLeft++;
            }
        }

        return numberTanksLeft <= 1;
    }

    private TankManagerTemplate GetRoundWinner()
    {
        for (int i = 0; i < tankManagers.Length; i++)
        {
            if (tankManagers[i].Instance.activeSelf)
            {
                return tankManagers[i];
            }
        }

        return null;
    }

    private TankManagerTemplate GetGameWinner()
    {
        for (int i = 0; i < tankManagers.Length; i++)
        {
            if (tankManagers[i].Wins == numberRoundsToWin)
            {
                return tankManagers[i];
            }
        }

        return null;
    }

    // Method to show message or panel

    private void ResetAllTanks()
    {
        for (int i = 0; i < tankManagers.Length; i++)
        {
            tankManagers[i].Reset();
        }
    }

    private void EnableTankControl()
    {
        for (int i = 0; i < tankManagers.Length; i++)
        {
            tankManagers[i].EnableControl();
        }
    }

    private void DisableTankControl()
    {
        for (int i = 0; i < tankManagers.Length; i++)
        {
            tankManagers[i].DisableControl();
        }
    }
}