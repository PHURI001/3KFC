using System;
using UnityEngine;

public class WaveSpawnManager : MonoBehaviour
{
    public Action OnAllwaveComplete;
    public Action OnStartWave;

    public Wave[] waveConfigurations;
    public WaveController waveController;

    private int currentWave = 0;
    private float waveEndTime = 0f;

    private bool isAlreadyClear = false;
    private bool isStart = false;

    void StartWave()
    {
    }

    void Update()
    {
        if (isStart == false) return;
        if (isAlreadyClear) return;

        //Debug.Log($"IsComplete{waveController.IsComplete()}");
        if (currentWave >= waveConfigurations.Length)
            return;

        if (Time.time >= waveEndTime && waveController.IsComplete())
        {
            currentWave++;
            if (currentWave >= waveConfigurations.Length)
            {
                Debug.Log("All waves completed!");
                OnAllwaveComplete?.Invoke();
                isAlreadyClear = true;
            }
            else
            {
                waveController.StartWave(waveConfigurations[currentWave]);
                waveEndTime = Time.time + waveConfigurations[currentWave].waveInterval;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && !waveController.IsComplete())
        {
            waveController.StartWave(waveConfigurations[currentWave]);
            waveEndTime = Time.time + waveConfigurations[currentWave].waveInterval;
            OnStartWave?.Invoke();
            isStart = true;
        }
    }
}