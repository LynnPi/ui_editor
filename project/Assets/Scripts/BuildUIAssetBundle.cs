using UnityEngine;
using System.Collections;
using UnityEditor;
public class BuildUIAssetBundle : EditorWindow {
    private const string PANEL_NAME = "Build UI Panel";
    private string _currentBundleStorePath;

    [MenuItem("Custom/Build UI Panel")]
    public static void OpenBuildUIPanel() {
        var window = (BuildUIAssetBundle)EditorWindow.GetWindow<BuildUIAssetBundle>();
        window.titleContent = new GUIContent(PANEL_NAME);
        window.Show();
    }

    private void OnGUI() {
        if (GUILayout.Button("Specify The Folder To Store Bundles")) {
            Debug.Log("Specify The Folder To Store Bundles!");
            string path = EditorUtility.OpenFolderPanel("Please Specify The Store Folder", "", "");

            if (!string.IsNullOrEmpty(path)) {
                _currentBundleStorePath = path;
                //EditorPrefs.SetString("The Folder To Store Bundles", _currentBundleStorePath);    
            }
        }

        GUILayout.TextField(string.Format("Folder: {0}", _currentBundleStorePath));

        if (GUILayout.Button("Build")) {
            Debug.Log("Build");
            Build(_currentBundleStorePath);
        }

        if (GUILayout.Button("Commit")) {
            Debug.Log("Commit");

#if UNITY_EDITOR_WIN
            Debug.Log("UNITY_EDITOR_WIN");
            string cmd = "C:/ProgramData/Microsoft/Windows/Start Menu/Programs/Git/Git GUI.lnk";
            System.Diagnostics.Process.Start(cmd);
#endif

#if UNITY_EDITOR_OSX
            Debug.Log("UNITY_EDITOR_OSX");
#endif
        }

        if (GUILayout.Button("Update")) {
            Debug.Log("Update");
        }

    }

    private void Build(string outputPath, BuildTarget platform = BuildTarget.Android) {
        if(!string.IsNullOrEmpty(outputPath)){
            Debug.Log(string.Format("Build(), outputPath: {0}, platform: {1}", outputPath, platform));
            BuildPipeline.BuildAssetBundles(outputPath, BuildAssetBundleOptions.None, platform);
        }
        else{
            Debug.LogError("outputPath is invalid!");
        }
   
    }

}
