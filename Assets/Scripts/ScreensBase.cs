using DG.Tweening;
using NaughtyAttributes;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

        private void Start()
        {
            if (startHided) ShowComponets(false);
        }

        [Button]
        protected virtual void Show() {

            Debug.Log("Show");
            //ShowComponets();
            ShowComponetsScaleAnimation();
        }
        
        [Button]
        protected virtual void Hide() {

            Debug.Log("Hide");
            //ShowComponets(false);
            HideComponetsScaleAnimation();
        }

        private void ShowComponets( bool show = true)
        {
            
            listOfComponents.ForEach(t => {t.gameObject.SetActive(show);});
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
