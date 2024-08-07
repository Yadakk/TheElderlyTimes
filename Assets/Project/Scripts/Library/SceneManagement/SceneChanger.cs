using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using DG.Tweening;

public static class SceneChanger
{
    public static IEnumerator LoadSceneAsync(string sceneName, Slider sliderBar)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);

        while(!operation.isDone)
        {
            float progressValue = Mathf.Clamp01(operation.progress / 0.9f);
            sliderBar.value = progressValue;
            yield return null;
        }
    }

    public static void LoadSceneAsync(string sceneName, GameObject loadingScreen, Slider sliderBar, MonoBehaviour context)
    {
        loadingScreen.SetActive(true);
        context.StartCoroutine(LoadSceneAsync(sceneName, sliderBar));
    }
}
