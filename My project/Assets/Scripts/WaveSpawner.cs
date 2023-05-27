using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
  //this controls what enemy is spawned
  public Transform enemyPrefab;
  public Transform startPoint;
  public float timeBetweenWaves = 5f;
  private float countDown = 2.0f; //also initial delay
  private int waveNumber = 0;
  void Update()
  {
    if (countDown <= 0f) {
      StartCoroutine(spawnWave());
      countDown = timeBetweenWaves;
    }
    countDown -= Time.deltaTime;
  }

  IEnumerator spawnWave() {
    waveNumber++;
    PlayerStats.Rounds++;
    for(int i = 0; i < waveNumber; i++) {
      spawnEnemy();
      yield return new WaitForSeconds(1.0f);
    }
  }

  void spawnEnemy()
  {
    Instantiate(enemyPrefab, startPoint.position, startPoint.rotation);
  }

  public int getWaveNumber()
  {
    return waveNumber;
  }
  public void RestartGame()
  {
    waveNumber = 0;
    PlayerStats.Rounds = 0;
    // Also needs to remove all instances of enemy.
  }

}
