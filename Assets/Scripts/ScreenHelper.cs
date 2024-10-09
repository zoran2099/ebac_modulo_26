using Screens;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenHelper : MonoBehaviour
{
    public ScreenType screenType;


    public void OnClick() {

        ScreenManager.Instance.ShowByType(screenType);  
    }
}
