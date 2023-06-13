using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

/*
 * A Wave contains many sub-waves.
 * This allows you to send rushes of enemies with customizable spacings.
 * each sub-wave is summoned as a Coroutine
 * By default each sub-wave is summoned one second after another.
 */

public class Wave : MonoBehaviour
{
    [System.Serializable]
    public class SubWave
    {
        public string tag;
        public Transform prefab;
        public int count;
        public float spawnInterval;
    }

    public List<SubWave> subWaves;

    private int _currSubWave = 0;
    
    public SubWave NextSubWave()
    {
        return subWaves[_currSubWave++];
    }
}
