using System.Collections;
using System.Collections.Generic;
using Enemies;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
  //this controls what enemy is spawned
  public Transform enemyPrefab;
  public Transform healerPrefab;
  public Transform startPoint;
  
  // DON'T CHANGE: Fetches Info from List of Waves in the editor.
  public List<Wave> waves;
  public static int NumberOfWaves;
  public float timeBetweenWaves;
  private WavesSurvived _waveManager;
  public Button nextWaveButton;
  private GameManager _gameManager;
  private readonly HashSet<int> _trackCoroutines = new HashSet<int>();
  
  //private float countDown = 2.0f; //also initial delay
  private int _waveNumber = 0;

  private void Awake()
  {
    NumberOfWaves = waves.Count;
    _waveManager = WavesSurvived.Waves;
  }

  void Update()
  {
    if (GameManager.GameIsOver)
    {
      return;
    }
    
    if (ChaseableEntity.Entities.Count == 0 && _trackCoroutines.Count == 0)
    {
      if (_waveNumber < NumberOfWaves)
      {
        nextWaveButton.interactable = true;
      }
      else
      {
        _gameManager = GameManager._gameManager;
        _gameManager.EndGame(true);
      }
    }
    else
    {
      nextWaveButton.interactable = false;
    }
  }

  public void sendNextWave()
  {
    StartCoroutine(spawnWave(waves[_waveNumber++]));
    _waveManager.SendNextRound();
  }

  IEnumerator spawnWave(Wave wave)
  {
    _trackCoroutines.Add(1);
    for (int i = 0; i < wave.subWaves.Count; i++)
    {
      Wave.SubWave subWave = wave.NextSubWave();
      float waitForSeconds = subWave.spawnInterval;
      for (int j = 0; j < subWave.count; j++)
      {
        spawnEnemy(subWave.prefab);
        yield return new WaitForSeconds(waitForSeconds);
      }

      yield return new WaitForSeconds(timeBetweenWaves); //delay between subwaves
    }

    _trackCoroutines.Remove(1);
  }

  void spawnEnemy(Transform prefab)
  {
    Instantiate(prefab, startPoint.position, startPoint.rotation);
  }

}
