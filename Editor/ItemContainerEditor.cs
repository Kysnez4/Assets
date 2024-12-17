using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(ItemContainer))]
public class ItemContainerEditor : Editor
{
    public  void OnInspectorGuUI()
    {
        ItemContainer container =  target as ItemContainer;
        if (GUILayout.Button("Clear container"))
        {
            if (container != null)
                for (int i = 0; i < container.slots.Count; i++)
                {
                    container.slots[i].Clear();
                }
        } 
        DrawDefaultInspector();
    }
}