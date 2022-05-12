using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    
    void OnCollisionEnter(Collision other)
    {
        switch(other.gameObject.tag)
        {
            case "Start":
                break;

            case "Finish":
                break;

            default:
                Debug.Log("You DEAD!");
                
                break;

        }
    }

    void RestartLevel()
    {
        int currentLevel = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentLevel);
    }
}
