using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonoSceneChanger : MonoBehaviour
{
    public Slider SliderBar;
    public GameObject LoadingScreen;
    public string SceneName;

    public void LoadSceneAsync() => SceneChanger.LoadSceneAsync(SceneName, LoadingScreen, SliderBar, this);
}