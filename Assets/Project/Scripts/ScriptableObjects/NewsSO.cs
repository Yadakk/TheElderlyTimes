using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New NewsSO", menuName = "ScriptableObjects/News", order = 282)]
public class NewsSO : ScriptableObject
{
    public Sprite Sprite;
    public Theme Theme;
    public bool IsVip;
}