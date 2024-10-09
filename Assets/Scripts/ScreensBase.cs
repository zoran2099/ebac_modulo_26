using DG.Tweening;
using NaughtyAttributes;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Screens
{
    public enum ScreenType
    {
        Panel, 
        InfoPanel, 
        Shop
    }

    public class ScreensBase : MonoBehaviour
    {
        public ScreenType screenType;
        public List<Transform> listOfComponents;

        [Header("Animation")]
        public bool startHided = true;
        public float animationDuration = 0.5f;
        public float delayBetweenComponents = 0.5f;

        public List<Typper> listOfPhrases;

        public Image backgroundUI;


        public void StartTypper()
        {
            for (int i = 0; i < listOfPhrases.Count; i++)
            {
                listOfPhrases[i].StartType();
            }
        }

        private void Start()
        {
            if (backgroundUI != null) listOfComponents.Insert(0,backgroundUI.transform);
            if (startHided) ShowComponets(false);
        }

        [Button]
        public virtual void Show() {

            Debug.Log("Show");
            //ShowComponets();
            ShowComponetsScaleAnimation();
            Invoke(nameof(StartTypper), delayBetweenComponents * listOfComponents.Count);
            //backgroundUI.enabled = true;

        }
        
        [Button]
        public virtual void Hide() {

            Debug.Log("Hide");
            ShowComponets(false);
            //HideComponetsScaleAnimation();
            //backgroundUI.enabled = false;
        }

        private void ShowComponets( bool show = true)
        {
            
            listOfComponents.ForEach(t => {t.gameObject.SetActive(show);});
            //backgroundUI.enabled = show;
        }
        
        private void ShowComponetsScaleAnimation()
        {
            var i = 0;
            listOfComponents.ForEach(t => {
                t.localScale = Vector3.one * 0.01f;
                t.gameObject.SetActive(true);
                t.DOScale(1,animationDuration).SetDelay(i++ * delayBetweenComponents);
            
            });

            
        }
        private void HideComponetsScaleAnimation()
        {
            var i = 0;
            /*listOfComponents.ForEach(t => {                
                t.DOScale(0,animationDuration).SetDelay(i++ * delayBetweenComponents).OnComplete(() => t.gameObject.SetActive(false));
                            
            });*/

            for (int j = listOfComponents.Count - 1; j >= 0; j--)
            {
                var t = listOfComponents[j];
                t.DOScale(0, animationDuration).SetDelay(i++ * delayBetweenComponents).OnComplete(() => t.gameObject.SetActive(false));
            }


        }
    }

   
}
