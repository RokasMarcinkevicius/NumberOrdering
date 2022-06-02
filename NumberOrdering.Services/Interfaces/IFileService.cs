﻿using System.Collections.Generic;

namespace NumberOrdering.Services.Interfaces
{
    internal interface IFileService
    {
        public bool SaveToFile(string fileName);
        public int LoadFileContent(string fileName);
        public List<int> LoadLatestFile();

    }
}
