﻿using System.Collections.Generic;
using System.Xml;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Urho3DExporter
{
    public class SceneExporter : BaseNodeExporter, IExporter
    {
        public SceneExporter(AssetCollection assets) : base(assets)
        {
        }

        public void ExportAsset(AssetContext asset, Scene scene)
        {
            var exlusion = new HashSet<Renderer>();
            using (XmlTextWriter writer = CreateXmlFile(asset))
            {
                using (var sceneElement = Element.Start(writer, "scene"))
                {
                    WriteAttribute(writer, "\t", "Name", scene.name);
                    StartCompoent(writer, "\t", "Octree");
                    EndElement(writer, "\t");
                    StartCompoent(writer, "\t", "DebugRenderer");
                    EndElement(writer, "\t");
                    foreach (var gameObject in scene.GetRootGameObjects())
                    {
                        WriteObject(writer, "", gameObject, exlusion);
                    }
                }
            }
        }
        public void ExportAsset(AssetContext asset)
        {
            var go = AssetDatabase.LoadAssetAtPath<SceneAsset>(asset.AssetPath);

            var exclusionSet = new HashSet<Renderer>();
            using (XmlTextWriter writer = CreateXmlFile(asset))
            {
                using (var scene = Element.Start(writer, "scene"))
                {
                }
            }
        }
    }
}