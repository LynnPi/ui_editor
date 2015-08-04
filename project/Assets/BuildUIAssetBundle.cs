using UnityEngine;
using System.Collections;
using UnityEditor;
public class BuildUIAssetBundle : EditorWindow {
    private const string PANEL_NAME = "Build UI Panel";
    [MenuItem("Custom/Build UI Panel")]
    public static void OpenBuildUIPanel() {
        var window = (BuildUIAssetBundle)EditorWindow.GetWindow<BuildUIAssetBundle>();
        window.titleContent = new GUIContent(PANEL_NAME);
        window.Show();
    }

    private void OnGUI() {
        if (GUILayout.Button("Build")) {
            Debug.Log("Build");
            Build(string.Empty);
        }

        if (GUILayout.Button("Commit")) {
            Debug.Log("Commit");
            System.Diagnostics.Process.Start("explorer.exe", @"c:/");
        }

        if (GUILayout.Button("Update")) {
            Debug.Log("Update");
        }
    }

    private void Build(string outputPath, BuildTarget platform = BuildTarget.Android) {
        if(string.IsNullOrEmpty(outputPath)){
            Debug.LogError("outputPath is invalid!");
            return;
        }
        else{
            Debug.Log(string.Format("Build(), outputPath: {0}, platform: {1}", outputPath, platform));    
        }

        BuildPipeline.BuildAssetBundles(outputPath, BuildAssetBundleOptions.None, platform);
    }

}
