using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    
    [SerializeField]float delayTime ;

    void OnCollisionEnter(Collision other)
    {
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
        GetComponent<Movement>().enabled = false;
        Invoke("RestartLevel",delayTime);

    }

        void DelayNextLevel()
    {
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
