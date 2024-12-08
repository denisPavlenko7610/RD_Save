using System.IO;
using UnityEditor;
using UnityEngine;

namespace RD_Save.Runtime
{
    public static class SaveSystemEditor
    {
        [MenuItem("Tools/Save System/Delete All Saves")]
        public static void DeleteAllSaves()
        {
            string saveDirectory = Application.persistentDataPath;

            if (Directory.Exists(saveDirectory))
            {
                if (EditorUtility.DisplayDialog("Delete All Saves",
                        $"Are you sure you want to delete all save files in:\n{saveDirectory}?",
                        "Yes", "No"))
                {
                    Directory.Delete(saveDirectory, true);
                    Debug.Log("All save files deleted.");
                }
            }
            else
            {
                Debug.LogWarning("No save files found to delete.");
            }
        }

        [MenuItem("Tools/Save System/Delete All Saves", true)]
        private static bool ValidateDeleteAllSaves()
        {
            return Directory.Exists(Application.persistentDataPath);
        }
    }
}