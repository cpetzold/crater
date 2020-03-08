using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(GameEvent))]
public class GameEventEditor : Editor {
    public override void OnInspectorGUI() {
        DrawDefaultInspector();

        GameEvent gameEvent = (GameEvent)target;
        if (GUILayout.Button("Raise")) {
            gameEvent.Raise();
        }
    }
}