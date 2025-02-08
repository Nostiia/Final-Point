using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityStandardAssets.Utility.TimedObjectActivator;
using UnityEngine.UI;

public class Detector : MonoBehaviour
{
    public GameObject[] enemies;
    public float dangerDistance = 5f;
    public Text messageText;

    public AudioClip nearSound;
    private AudioSource audioSource;


    IEnumerator Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            Debug.LogError("AudioSource component not found!");
        }

        yield return StartCoroutine(DoCheck());
    }

    IEnumerator DoCheck()
    {
        while (true)
        {
            if (ProximityCheck())
            {
                if (audioSource != null && nearSound != null)
                {
                    // Play the sound at the position of the object with the AudioSource component
                    AudioSource.PlayClipAtPoint(nearSound, audioSource.transform.position);
                }

                messageText.text = "Enemy detected within danger distance!";
                
            }
            else
            {
                if (audioSource != null)
                {
                    audioSource.Stop(); // Stop playing the music
                }

                // Clear the message when no enemies are within danger distance
                messageText.text = "";
            }
            yield return new WaitForSeconds(0.1f); // Adjust the interval as needed
        }
    }

    bool ProximityCheck()
    {
        if (enemies == null)
        {
            Debug.LogWarning("Enemies array is null. Make sure to assign enemies in the Inspector.");
            return false;
        }

        for (int i = 0; i < enemies.Length; i++)
        {
            if (enemies[i] != null && Vector3.Distance(transform.position, enemies[i].transform.position) < dangerDistance)
            {
                return true;
            }
        }
        return false;
    }
}
