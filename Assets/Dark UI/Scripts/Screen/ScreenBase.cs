using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;
using DG.Tweening;

namespace Screens
{
    public enum Screentype
    {
        Panel,
        InfoPanel,
        Shop
    }

    public class ScreenBase : MonoBehaviour
    {
        public Screentype screenType;

        public List<Transform> listOfObjects;

        public bool startHidden = false;

        [Header("Animation")]
        public float animationDuration = 0.3f;
        public float delayBetweenObjects = 0.1f;

        private void Start()
        {
            if(startHidden) HideObjects();
        }


        [Button]
        protected virtual void Show()
        {
            ShowObjects();
            Debug.Log("Show");
        }

        [Button]
        protected virtual void Hide()
        {
            HideObjects();
            Debug.Log("Hide");
        }

        private void HideObjects()
        {
            listOfObjects.ForEach(i => i.gameObject.SetActive(false));
        }
        private void ShowObjects()
        {
            for (int i = 0; i< listOfObjects.Count; i++)
            {
                var obj = listOfObjects[i];

                obj.gameObject.SetActive(true);
                obj.DOScale(0, animationDuration).From().SetDelay(i * delayBetweenObjects);
            }
        }

        private void ForceShowObjects()
        {
            listOfObjects.ForEach(i => i.gameObject.SetActive(true));
        }

    }
}
