using TMPro;
using UnityEngine;

public class WavesSurvived : MonoBehaviour
{
    public TextMeshProUGUI Text;

    public static WavesSurvived Waves;

    private void Awake()
    {
        if (Waves != null)
        {
            return;
        }

        Waves = this;
    }

    private void Start()
    {
        Text.text = "Wave: " + PlayerStats.Rounds + " / " + WaveSpawner.NumberOfWaves;
    }

    public void SendNextRound()
    {
        PlayerStats.Rounds++;
        
        Text.text = "Wave: " + PlayerStats.Rounds + " / " + WaveSpawner.NumberOfWaves;
    }
}