using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    
    [SerializeField]float delayTime ;
    [SerializeField]AudioClip crashSFX;
    [SerializeField]AudioClip finishSFX;

    bool isTransitioning = false ;

    AudioSource sfx;

    void Start()
    {
        
        sfx = GetComponent<AudioSource>();
    }


    void OnCollisionEnter(Collision other)
    {

        if(isTransitioning){ return;}

        switch(other.gameObject.tag)
        {
            case "Start":
                break;

            case "Finish":
                DelayNextLevel();
                

                break;

            default:
                Debug.Log("You DEAD!");
                DelayRestartLevel();
                
                
                break;

        }
    }

    void DelayRestartLevel()
    {
        isTransitioning = true;
        sfx.Stop();
        sfx.PlayOneShot(crashSFX);
        GetComponent<Movement>().enabled = false;
        Invoke("RestartLevel",delayTime);

    }

        void DelayNextLevel()
    {
        isTransitioning = true;
        sfx.Stop();
        sfx.PlayOneShot(finishSFX);
        GetComponent<Movement>().enabled = false;
        Invoke("LoadNextLevel",delayTime);

    }

    

    void RestartLevel()
    {
        int currentLevel = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentLevel);
    }

    void LoadNextLevel()
    {
        int currentIndexLevel = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentIndexLevel + 1;

        if(nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0;
        }

        SceneManager.LoadScene(nextSceneIndex);
    }
}
