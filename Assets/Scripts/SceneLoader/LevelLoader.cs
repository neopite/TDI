using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public List<string> listOfLevels;
    public int sceneCount;

    public void LoadLevel(TextMeshProUGUI name)
    {
        SceneManager.LoadScene(name.text);
    }

    private void Awake()
    {
        sceneCount = SceneManager.sceneCountInBuildSettings;     
        GetAllScenes();

    }

    private void GetAllScenes()
    {
        for (int i = 1; i < sceneCount; i++)
        {
            string sceneName = System.IO.Path.GetFileNameWithoutExtension(SceneUtility.GetScenePathByBuildIndex(i));
            listOfLevels.Add(sceneName);
        }
    }
}
