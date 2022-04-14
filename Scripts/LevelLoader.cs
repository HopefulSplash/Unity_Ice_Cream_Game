using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelLoader : MonoBehaviour
{

    public Animator transition;
    // Update is called once per frame
    void Update()
    {
        //when to pplay
        if (true)
        {
            LoadNextLevel();
        }
    }

    public void LoadNextLevel()
    {
        // laod scene
        StartCoroutine(LoadLevel());
    }

    private IEnumerator LoadLevel()
    {
        transition.SetTrigger("Start");
        
        yield return new WaitForSeconds(1);

    }
}
