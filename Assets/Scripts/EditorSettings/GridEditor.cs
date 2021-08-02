using UnityEditor;
using UnityEngine;
#if UNITY_EDITOR
[CustomEditor(typeof(GridGenerator))]
public class GridEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        GridGenerator grid = (GridGenerator)target;

        GameObject go = grid.FindElement(grid.updateElement);

        if (go.GetComponent<Movement>())
        {
            grid.hasLimit = EditorGUILayout.Toggle("Has Limit", grid.hasLimit);
            if (grid.hasLimit)
            {
                grid.limitCount = EditorGUILayout.IntField("Limit Count: ", grid.limitCount);
            }
        }

        if (GUILayout.Button("Update Grid"))
        {
            grid.UpdateGrid();
        }

        if (GUILayout.Button("Reset Grid"))
        {
            grid.ResetGrid();
        }
        //if (GUILayout.Button("Fill Grid Array"))
        //{
        //    grid.FillGridArray();
        //    //grid.LoadGridArray();
        //}

        //GUILayout.BeginHorizontal();
        //if (GUILayout.Button("Save Grid"))
        //{
        //    grid.SaveGridArray();
        //}
        //if (GUILayout.Button("Load Grid"))
        //{
        //    grid.FillGridArray();
        //    //grid.LoadGridArray();
        //}
        //GUILayout.EndHorizontal();
    }
}
#endif