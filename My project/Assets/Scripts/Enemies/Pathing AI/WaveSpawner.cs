using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class WaveSpawner : MonoBehaviour
{
  // TODO: fix these start points. Either initiate them on Start() or drag them in the editor
  public Transform[] startPoints;
  public static int NumberOfPaths;
  public static int currentSpawnPointIndex;

  // Subscribers to Starting and Ending a wave
  public static Action<float> startNextWave; // the approximate length of the wave is given.

  public static Action EndWave;

  public static Action AllEnemiesDefeated;

  // DON'T CHANGE: Fetches Info from List of Waves in the editor.
  public List<Wave> waves;
  public static int NumberOfWaves;
  public float timeBetweenSubWaves = 0.5f;
  private WavesSurvived _waveManager;
  public GameObject nextWaveButton;
  public GameObject fastForwardButton;
  private GameManager _gameManager;
  public readonly HashSet<int> TrackCoroutines = new HashSet<int>();
  
  //private float countDown = 2.0f; //also initial delay
  private int _waveNumber = 0;

  private void Awake()
  {
    NumberOfWaves = waves.Count;
    _waveManager = WavesSurvived.Waves;
    NumberOfPaths = startPoints.Length;
  }

  void Update()
  {
    if (GameManager.GameIsOver)
    {
      return;
    }
    
    if (TrackCoroutines.Count == 0)
    {
      EndWave?.Invoke();
      if (ChaseableEntity.Entities.Count == 0)
      {
        AllEnemiesDefeated?.Invoke();
        if (_waveNumber < NumberOfWaves)
        {
          nextWaveButton.SetActive(true);
          fastForwardButton.SetActive(false);
        }
        else
        {
          _gameManager = GameManager._gameManager;
          _gameManager.EndGame(true);
        }
      }
    }
    else
    {
      nextWaveButton.SetActive(false);
      fastForwardButton.SetActive(true);
    }
  }

  public void sendNextWave()
  {
    StartCoroutine(spawnWave(waves[_waveNumber++]));
    startNextWave?.Invoke(CalculateWaveTime());
    _waveManager.SendNextRound();
  }

  IEnumerator spawnWave(Wave wave)
  {
    TrackCoroutines.Add(1);
    for (int i = 0; i < wave.subWaves.Count; i++)
    {
      Wave.SubWave subWave = wave.NextSubWave();
      float waitForSeconds = subWave.spawnInterval;
      for (int j = 0; j < subWave.count; j++)
      {
        spawnEnemy(subWave.prefab);
        yield return new WaitForSeconds(waitForSeconds);
      }

      yield return new WaitForSeconds(timeBetweenSubWaves); //delay between subwaves
    }

    TrackCoroutines.Remove(1);
  }

  void spawnEnemy(Transform prefab)
  {
    Instantiate(prefab, startPoints[currentSpawnPointIndex].position, startPoints[currentSpawnPointIndex].rotation);
    currentSpawnPointIndex = (currentSpawnPointIndex + 1) % (startPoints.Length);
  }

  float CalculateWaveTime()
  {
    var time = 0f;
    foreach (var subWave in waves[_waveNumber - 1].subWaves) // we added 1 to waveNumber prior to this being called
    {
      time += subWave.spawnInterval * subWave.count + timeBetweenSubWaves;
    }
    return time;
  }

}
