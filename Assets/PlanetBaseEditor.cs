using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(PlanetBase))]

public class PlanetBaseEditor : Editor
{
    public float lowTemp = -10;
    public float highTemp = 100;
    bool foldOutBasicInfo = false;
    bool foldOutSurface = false;
    bool foldOutlife = false;

    public override void OnInspectorGUI()
    {
        PlanetBase myPlanet = (PlanetBase)target;
        
        foldOutBasicInfo = EditorGUILayout.Foldout(foldOutBasicInfo, "Basic info");
        if (foldOutBasicInfo)
        {
            myPlanet.mainColor = EditorGUILayout.ColorField("Main Plant Color", myPlanet.mainColor);
            myPlanet.GetComponent<Renderer>().material.SetColor("_Color", myPlanet.mainColor);

            myPlanet.planetSize = EditorGUILayout.IntField(new GUIContent("Plant Size", "Radius in Miles, Example: Earth's is 3,959Mi"), myPlanet.planetSize);
            if (myPlanet.planetSize <= 0)
                myPlanet.planetSize = 0;

            myPlanet.transform.localScale = new Vector3(myPlanet.planetSize, myPlanet.planetSize, myPlanet.planetSize);

            myPlanet.hasWater = EditorGUILayout.Toggle("Does the plant have water", myPlanet.hasWater);

            myPlanet.moonAmount = EditorGUILayout.IntField("How many moons", myPlanet.moonAmount);
            if (myPlanet.moonAmount <= 0)
                myPlanet.moonAmount = 0;

            myPlanet.revolutionTime = EditorGUILayout.FloatField(new GUIContent("RevolutionTime", "In Hours"), myPlanet.revolutionTime);
            if (myPlanet.revolutionTime <= 0)
                myPlanet.revolutionTime = 0;

            myPlanet.orbitTime = EditorGUILayout.FloatField(new GUIContent("OrbitTime", "In Days"), myPlanet.orbitTime);
            if (myPlanet.orbitTime <= 0)

                myPlanet.orbitTime = 0;
        }

        foldOutSurface = EditorGUILayout.Foldout(foldOutSurface, "Surface info");
        if (foldOutSurface)
        {
            myPlanet.lowTemp = EditorGUILayout.FloatField(new GUIContent("Low Temp", "In Celsius"), myPlanet.lowTemp);
            myPlanet.highTemp = EditorGUILayout.FloatField(new GUIContent("High Temp", "In Celsius"), myPlanet.highTemp);
            EditorGUILayout.MinMaxSlider(ref myPlanet.lowTemp, ref myPlanet.highTemp, lowTemp, highTemp);

            myPlanet.lowElevation = EditorGUILayout.FloatField(new GUIContent("Lowest Elevation:", "in Miles"), myPlanet.lowElevation);
            if (myPlanet.lowElevation <= 0)
                myPlanet.lowElevation = 0;

            myPlanet.highElevation = EditorGUILayout.FloatField(new GUIContent("Highest Elevation:", "in Miles"), myPlanet.highElevation);
            if (myPlanet.highElevation <= 0)
                myPlanet.highElevation = 0;

            myPlanet.radiationAmount = EditorGUILayout.FloatField(new GUIContent("Radiation:", "in rads"), myPlanet.radiationAmount);

        }

        foldOutlife = EditorGUILayout.Foldout(foldOutlife, "Life on planet info");
        if (foldOutlife)
        {
            myPlanet.isHabitable = EditorGUILayout.Toggle("Is the planet Habitable", myPlanet.isHabitable);
            if (myPlanet.isHabitable == false)
            {
                myPlanet.flora = false;
                myPlanet.fauna = false;
                myPlanet.intelligentCreatures = false;
                myPlanet.icPopulation = 0;
            }

            myPlanet.flora = EditorGUILayout.Toggle(new GUIContent("Does the planet have flora:", "Plants"), myPlanet.flora);//plant

            myPlanet.fauna = EditorGUILayout.Toggle(new GUIContent("Does the planet have fauna:", "animal"), myPlanet.fauna);//animal
            if (myPlanet.fauna == false)
            {
                myPlanet.fauna = false;
                myPlanet.intelligentCreatures = false;
                myPlanet.icPopulation = 0;
            }

            myPlanet.intelligentCreatures = EditorGUILayout.Toggle("Intelligent Creatures? ", myPlanet.intelligentCreatures);
            if (myPlanet.intelligentCreatures == false)
            {
                myPlanet.icPopulation = 0;
            }

            myPlanet.icPopulation = EditorGUILayout.IntField(new GUIContent("Intelligent Creatures", "The number of intelligent creatures"),  myPlanet.icPopulation);
            if (myPlanet.icPopulation <= 0)
                myPlanet.icPopulation = 0;

        }
        SerializedProperty myElem = serializedObject.FindProperty("mainElements");
        EditorGUILayout.PropertyField(myElem, new GUIContent("Elements", "Size is how many"), true);
        serializedObject.ApplyModifiedProperties();


        // base.OnInspectorGUI();
    }
}
