﻿using System.IO;
using UnityEngine;

namespace CardboardCore.Cameras.VirtualCameras
{
    public static class VirtualCameraIdsGenerator
    {
        public static void Write(string sceneName, VirtualCameraManager virtualCameraManager)
        {
            string className = $"VirtualCameraIds_{sceneName}";
            string dirPath = Path.Combine(Application.dataPath, "CardboardCore", "Cameras", "Generated");
            string filePath = Path.Combine(dirPath, $"{className}.cs");

            if (!Directory.Exists(dirPath))
            {
                Directory.CreateDirectory(dirPath);
            }

            using StreamWriter streamWriter = new StreamWriter(filePath);

            const string warning = "/*GENERATED FILE, DO NOT MODIFY MANUALLY!*/\n";
            streamWriter.Write(warning);

            string source = $"/*GENERATED BY \"{nameof(VirtualCameraIdsGenerator)}\"*/\n\n";
            streamWriter.Write(source);

            const string startNamespace = "namespace CardboardCore.Cameras\n{\n";
            streamWriter.Write(startNamespace);

            const string resharperDisable = "    // ReSharper disable once InconsistentNaming\n";

            streamWriter.Write(resharperDisable);

            string startClass = $"    public static class {className}\n    " + "{\n";
            streamWriter.Write(startClass);

            const string property = "        public const string {0} = \"{1}\";\n";

            for (int i = 0; i < virtualCameraManager.VirtualCameras.Count; i++)
            {
                string propertyName = virtualCameraManager.VirtualCameras[i].Id;
                string propertyValue = virtualCameraManager.VirtualCameras[i].Id;

                string propertyFormatted = string.Format(property, propertyName, propertyValue);
                streamWriter.Write(propertyFormatted);
            }

            const string endClass = "    }\n";
            streamWriter.Write(endClass);

            const string endNamespace = "}\n";
            streamWriter.Write(endNamespace);
        }
    }
}
