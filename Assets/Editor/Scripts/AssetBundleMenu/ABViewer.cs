using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEditor;
using UnityEditor.UIElements;

namespace Rawrshak
{
    public class ABViewer : ScriptableObject
    {
        ABData mAssetBundle;

        // UI
        Box mHelpBoxHolder;
        Box mViewer;
        
        VisualTreeAsset mBundleTreeAsset;

        public void SetAssetBundle(ABData assetBundle)
        {
            mAssetBundle = assetBundle;

            mViewer.Clear();

            TemplateContainer bundleTree = mBundleTreeAsset.CloneTree();
            
            var bundleView = bundleTree.contentContainer.Query<Box>("info-box").First();
            SerializedObject so = new SerializedObject(mAssetBundle);
            bundleView.Bind(so);

            mViewer.Add(bundleTree);
        }
        
        public void LoadUI(VisualElement root)
        {
            // Load View UML
            mBundleTreeAsset = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>("Assets/Editor/UXML/AssetBundleMenu/AssetBundleView.uxml");

            mHelpBoxHolder = root.Query<Box>("helpbox-holder").First();

            // Asset Bundle Entries
            mViewer = root.Query<Box>("asset-bundle-viewer").First();
        }

        public void AddErrorHelpbox(string errorMsg)
        {
            mHelpBoxHolder.Add(new HelpBox(errorMsg, HelpBoxMessageType.Error));
        }
    }

}