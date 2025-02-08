using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalPosition : MonoBehaviour

{
    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("WON!!!. Game is over! Congrat!");
            gameManager = FindObjectOfType<GameManager>();
            gameManager.ActivateWinScreen();
        }
    }
}

