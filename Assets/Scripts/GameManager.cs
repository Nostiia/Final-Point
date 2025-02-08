using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Text timeText;
    public GameObject restartButton;
    public GameObject nextLevelButton;
    public GameObject winScreen;
    public GameObject loseScreen;
    public Camera firstPersonCamera;
    public Camera thirdPersonCamera;

    public LayerMask creatureLayer;
    public GameObject explosionPrefab;

    public AudioClip sound;
    public AudioClip deathSound;
    public AudioClip winSound;
    public AudioClip loseSound;
    private AudioSource audioSource;

    private void Awake()
    {
        winScreen.SetActive(false);
        loseScreen.SetActive(false);
    }

    private void Start()
    {
        firstPersonCamera.enabled = false;
        thirdPersonCamera.enabled = true;
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            Debug.LogError("AudioSource component not found!");
        }
        if (audioSource != null && sound != null)
        {
            audioSource.PlayOneShot(sound);
        }
    }

    private void Update()
    {
        UpdateTimeDisplay();
        if (Input.GetMouseButtonDown(0))
        {
            // Create a ray from the camera to the cursor position
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            // Perform ray collision test only with objects in the creature layer
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, creatureLayer))
            {
                // Get the position of the creature
                Vector3 creaturePosition = hit.collider.gameObject.transform.position;
                

                // Instantiate the explosion particle system at the position of the creature
                Instantiate(explosionPrefab, creaturePosition, Quaternion.identity);

                // Play the death sound
                if (audioSource != null && deathSound != null)
                {
                    audioSource.PlayOneShot(deathSound);
                }

                // Destroy the creature GameObject
                Destroy(hit.collider.gameObject);

            }
        }
    }

    public void ActivateWinScreen()
    {
        if (audioSource != null && winSound != null)
        {
            audioSource.Stop();
            audioSource.PlayOneShot(winSound);
        }
        winScreen.SetActive(true);
        Time.timeScale = 0f;
    }

    public void ActivateLoseScreen()
    {
        if (audioSource != null && loseSound != null)
        {
            audioSource.Stop();
            audioSource.PlayOneShot(loseSound);
        }
        loseScreen.SetActive(true);
        Time.timeScale = 0f;
    }

    public void RestartGame()
    {
        Debug.Log("Restart Game");        
        Time.timeScale = 1f;
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }

    public void SwitchCamera()
    {
        Debug.Log("Switch Cameras");
        firstPersonCamera.enabled = !firstPersonCamera.enabled;
        thirdPersonCamera.enabled = !thirdPersonCamera.enabled;
    }

    void UpdateTimeDisplay()
    {
        timeText.text = "Time: " + Time.timeSinceLevelLoad.ToString("F2");
    }

    public void LoadNextLevel()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Level2");
    }

    public void LoadNextLevel3()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Level3");
    }

    public void LoadStart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("FirstMenu");
    }
}


