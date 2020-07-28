using System;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
namespace Bolt.Samples.Encryption
{
    [CustomEditor(typeof(SetupEncryptionSystem))]
    public class SetupEncryptionSystemEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            if (GUILayout.Button("Generate keys"))
            {
                ((SetupEncryptionSystem) target).GenerateKeys();
            }
        }
    }
}
#endif