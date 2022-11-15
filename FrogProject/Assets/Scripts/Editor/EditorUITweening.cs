using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(UITweening))]
public class EditorUITweening : Editor
{
    UITweening myUI;

    

    public override void OnInspectorGUI()
    {
        myUI = (UITweening)target;

        #region Movement

        //Movement configuration
        myUI.enablemovement = EditorGUILayout.BeginToggleGroup("Enable Movement", myUI.enablemovement);

        //Start position configuration
      
        myUI.startPosition = EditorGUILayout.Vector2Field("Start Position", myUI.startPosition);// GUILayout.Width(300));

        EditorGUILayout.BeginHorizontal();

            if (GUILayout.Button("Set start position"))
            {
                SetPosition(out myUI.startPosition);
            }

            if (GUILayout.Button("Move to start position"))
            {
                MoveTo(myUI.startPosition);
            }

        EditorGUILayout.EndHorizontal();
        //End position configuration
        myUI.endPosition = EditorGUILayout.Vector2Field("End Position", myUI.endPosition);// GUILayout.Width(300));

        EditorGUILayout.BeginHorizontal();

            if (GUILayout.Button("Set end position"))
            {
                SetPosition(out myUI.endPosition);
            }
            if (GUILayout.Button("Move to end position"))
            {
                MoveTo(myUI.endPosition);
            }

        EditorGUILayout.EndHorizontal();

        myUI.movement_Speed = EditorGUILayout.FloatField("Movement speed", myUI.movement_Speed);

        EditorGUILayout.EndToggleGroup();

        #endregion

        #region Size
        //Scale configuration
        myUI.enableSize = EditorGUILayout.BeginToggleGroup("Enable Scale", myUI.enableSize);

        //Start scale configuration

        myUI.startSize = EditorGUILayout.Vector2Field("Start Scale", myUI.startSize);// GUILayout.Width(300));

        EditorGUILayout.BeginHorizontal();

            if (GUILayout.Button("Set start size"))
            {
                SetSize(out myUI.startSize);
            }
            if (GUILayout.Button("Resize to start size"))
            {
                ResizeTo( myUI.startSize);
            }

        EditorGUILayout.EndHorizontal();
        //End size configuration
        myUI.endSize = EditorGUILayout.Vector2Field("End Size", myUI.endSize);// GUILayout.Width(300));

        EditorGUILayout.BeginHorizontal();

            if (GUILayout.Button("Set end size"))
            {
                SetSize(out myUI.endSize);
            }
            if (GUILayout.Button("Resize to end size"))
            {
                ResizeTo(myUI.endSize);
            }
        EditorGUILayout.EndHorizontal();

        myUI.resize_Speed = EditorGUILayout.FloatField("Scale speed", myUI.resize_Speed);

        myUI.islooping = EditorGUILayout.Toggle("Looping from start", myUI.islooping);

        EditorGUILayout.EndToggleGroup();

        #endregion

     

       
    }



    void SetPosition(out Vector2 position)
    {

        position = myUI.gameObject.GetComponent<RectTransform>().anchoredPosition;
    }

    void MoveTo(Vector2 position)
    {
     
        myUI.gameObject.GetComponent<RectTransform>().anchoredPosition = position;
   
    }

    void SetSize(out Vector2 size)
    {
        size = myUI.gameObject.GetComponent<RectTransform>().sizeDelta;
    }

    void ResizeTo(Vector2 size)
    {
        myUI.gameObject.GetComponent<RectTransform>().sizeDelta = size;
    }
}
