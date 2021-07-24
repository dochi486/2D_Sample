using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;
using UnityEditor;
using System;

public class EditorSceneLoad
{
    [MenuItem("Window/1. Title Scene")]
    public static void TitleSceneLoad()
    {
        LoadScene("Title");
    }

    [MenuItem("Window/2. Main Scene")]
    public static void MainSceneLoad()
    {
        LoadScene("Main");
    }

    private static void LoadScene(string loadSceneName)
    {
        EditorSceneManager.OpenScene($"Assets/Scenes/{loadSceneName}.unity");
    }
}
