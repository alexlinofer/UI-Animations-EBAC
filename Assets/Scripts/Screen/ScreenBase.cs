using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;
using DG.Tweening;
using UnityEngine.UI;

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
        public List<Typer> listOfPhrases;


        public Image uiBackground;
        public bool startHidden = false;

        [Header("Animation")]
        public float animationDuration = 0.3f;
        public float delayBetweenObjects = 0.1f;

        private void Start()
        {
            if(startHidden) HideObjects();
        }


        [Button]
        public virtual void Show()
        {
            ShowObjects();
            Debug.Log("Show");
        }

        [Button]
        public virtual void Hide()
        {
            HideObjects();
            Debug.Log("Hide");
        }

        private void HideObjects()
        {
            listOfObjects.ForEach(i => i.gameObject.SetActive(false));
            EraseType();
            uiBackground.enabled = false;
            
        }
        private void ShowObjects()
        {
            for (int i = 0; i< listOfObjects.Count; i++)
            {
                var obj = listOfObjects[i];

                obj.gameObject.SetActive(true);
                obj.DOScale(0, animationDuration).From().SetDelay(i * delayBetweenObjects);
            }
            Invoke(nameof(StartType), delayBetweenObjects * listOfObjects.Count);
            uiBackground.enabled = true;

        }

        private void StartType()
        {
            for (int i = 0; i < listOfPhrases.Count; i++)
            {
                listOfPhrases[i].StartType();
            }
        }

        private void EraseType()
        {
            for (int i = 0; i < listOfPhrases.Count; i++)
            {
                listOfPhrases[i].Erase();
            }
        }

        private void ForceShowObjects()
        {
            listOfObjects.ForEach(i => i.gameObject.SetActive(true));
        }

    }
}
