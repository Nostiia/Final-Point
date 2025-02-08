using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;



public class SPforFirstMenu : MonoBehaviour
{
    public AudioClip preview;
    private AudioSource audioSource;

    public GameObject thePlayer;
    // Start is called before the first frame update
    void Start()
    {
        thePlayer.transform.position = transform.position;
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            Debug.LogError("AudioSource component not found!");
        }
        if (audioSource != null && preview != null)
        {
            audioSource.PlayOneShot(preview);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
