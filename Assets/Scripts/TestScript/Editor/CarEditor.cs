using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Car))]
public class CarEditor : Editor
{
    public override void OnInspectorGUI()
    {
        //base.OnInspectorGUI();
        Car myTarget = (Car)target;

        myTarget.carPrefab = (GameObject)EditorGUILayout.ObjectField(myTarget.carPrefab, typeof(GameObject), true);

        
        myTarget.speed = EditorGUILayout.IntField("My Speed is", myTarget.speed);
        myTarget.gear = EditorGUILayout.IntField("My Gear is", myTarget.gear);

        EditorGUILayout.LabelField("My Total Speed is", myTarget.TotalSpeed.ToString());

        EditorGUILayout.HelpBox("Calculate the total speed", MessageType.Info);

        GUI.color = Color.red;
        if(myTarget.TotalSpeed > 200)
        {
            EditorGUILayout.HelpBox("Oh no! Too fast!", MessageType.Error);
        }

        GUI.color = Color.yellow;

        if(GUILayout.Button("Create Car"))
        {
            myTarget.CreateCar();
        }

    }


}
