using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public static class StaticExtensions
{

    public static void Scale(this Transform t, float size = 1.2f)
    {
        t.localScale = Vector3.one * size;
    }
    public static void Scale(this GameObject t, float size = 1.2f)
    {
        t.transform.localScale = Vector3.one * size;
    }

    public static void ScaleDO (this Transform t, float size = 1.2f)
    {
        t.DOKill();
        var defaultScale = t.localScale;
        var scaleDuration = 0.5f;
        t.DOScale(defaultScale * size, scaleDuration);
    }

    public static void ScaleDONT(this Transform t, float size = 1)
    {
        t.DOKill();

        var scaleDuration = 0.5f;
        t.DOScale(1, scaleDuration);
    }

    public static T GetRandom<T>(this List<T> list)
    {
        return list[Random.Range(0, list.Count)];
    }

    public static T GetRandom<T>(this T[] array)
    {
        if (array.Length == 0) return default(T);
        return array[Random.Range(0, array.Length)];
    }

    public static T GetRandomButNotTheSame<T>(this List<T> list, T unique)
    {
        if (list.Count == 1) return unique;
        int randomIndex = Random.Range(0, list.Count);
        return list[randomIndex];
    }

}
