using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using DG.Tweening;
using Unity.VisualScripting;

public class TestButtonScaler : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{

    public void OnPointerEnter(PointerEventData eventData)
    {
        transform.ScaleDO(2);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        transform.ScaleDONT();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        transform.ScaleDONT();
    }

}
