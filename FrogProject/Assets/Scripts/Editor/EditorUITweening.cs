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
      
        if (GUILayout.Button("Set start position"))
        {
            SetPosition(out myUI.startPosition);
        }

        //End position configuration
        myUI.endPosition = EditorGUILayout.Vector2Field("End Position", myUI.endPosition);// GUILayout.Width(300));

        if (GUILayout.Button("Set end position"))
        {
            SetPosition(out myUI.endPosition);
        }


        EditorGUILayout.EndToggleGroup();

        #endregion

        #region Size
        //Scale configuration
        myUI.enableSize = EditorGUILayout.BeginToggleGroup("Enable Scale", myUI.enableSize);

        //Start scale configuration

        myUI.startSize = EditorGUILayout.Vector2Field("Start Scale", myUI.startSize);// GUILayout.Width(300));

        if (GUILayout.Button("Set start size"))
        {
            SetScale(out myUI.startSize);
        }

        //End size configuration
        myUI.endSize = EditorGUILayout.Vector2Field("End Size", myUI.endSize);// GUILayout.Width(300));

        if (GUILayout.Button("Set end size"))
        {
            SetScale(out myUI.endSize);
        }

        EditorGUILayout.EndToggleGroup();

        #endregion

     

        myUI.activate_begining = EditorGUILayout.Toggle("Activate in the begining", myUI.activate_begining);

        myUI.deactivate_ending = EditorGUILayout.Toggle("Deactivate in the end", myUI.deactivate_ending);

        if (GUILayout.Button("debug")) 
        {
            // myUI.gameObject.GetComponent<RectTransform>().position = myUI.startPosition;
            // myUI.gameObject.GetComponent<RectTransform>().sizeDelta = myUI.startSize;

           // myUI.StartCoroutine(myUI.MoveUI(false));
        }
    }



    void SetPosition(out Vector2 position)
    {
        position = myUI.gameObject.GetComponent<RectTransform>().position;
    }

    void SetScale(out Vector2 scale)
    {
        scale = myUI.gameObject.GetComponent<RectTransform>().sizeDelta;
    }
}
