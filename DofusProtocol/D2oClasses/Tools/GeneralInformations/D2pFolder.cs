using System;
using System.Collections.Generic;
using System.IO;

namespace D2pReader.GeneralInformations
{
    public class D2pFolder
    {
        public D2pFolder(string d2pFolderPath)
        {
            FolderPath = d2pFolderPath;
            FolderContent = new List<D2pFile>();
            D2pFilesCount = 0;

            Initialize();
        }


        private void Initialize()
        {
            if (!Directory.Exists(FolderPath))
                throw new IOException("Directory " + FolderPath + " does not exist");

            foreach (var d2pFile in Directory.GetFiles(FolderPath))
            {
                if (Path.GetExtension(d2pFile) != ".d2p")
                    continue;

                FolderContent.Add(new D2pFile(d2pFile));
                D2pFilesCount++;
            }

            if (D2pFilesCount == 0)
                new ArgumentException("Invalid folder, no .d2p files found in " + FolderPath);
        }

        #region Vars

        #endregion

        #region Properties

        public string FolderPath { get; }

        public List<D2pFile> FolderContent { get; }

        public uint D2pFilesCount { get; private set; }

        #endregion
    }
}