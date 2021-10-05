﻿#region License GNU GPL

// D2pDirectory.cs
// 
// Copyright (C) 2012 - BehaviorIsManaged
// 
// This program is free software; you can redistribute it and/or modify it 
// under the terms of the GNU General Public License as published by the Free Software Foundation;
// either version 2 of the License, or (at your option) any later version.
// 
// This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; 
// without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. 
// See the GNU General Public License for more details. 
// You should have received a copy of the GNU General Public License along with this program; 
// if not, write to the Free Software Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA 02111-1307 USA

#endregion

using System.Collections.Generic;
using System.Linq;

namespace Stump.DofusProtocol.D2oClasses.Tools.D2p
{
    public class D2pDirectory
    {
        private string m_name;

        private D2pDirectory m_parent;

        public D2pDirectory(D2pFile container, string name)
        {
            Container = container;
            Name = name;
            FullName = name;
        }

        public D2pFile Container { get; set; }

        public string Name
        {
            get => m_name;
            internal set
            {
                m_name = value;
                UpdateFullName();
            }
        }

        public string FullName { get; private set; }

        public D2pDirectory Parent
        {
            get => m_parent;
            set
            {
                m_parent = value;
                UpdateFullName();
            }
        }

        public List<D2pEntry> Entries { get; set; } = new List<D2pEntry>();

        public Dictionary<string, D2pDirectory> Directories { get; set; } = new Dictionary<string, D2pDirectory>();

        public bool IsRoot => Parent == null;

        private void UpdateFullName()
        {
            var current = this;
            FullName = current.Name;
            while (current.Parent != null)
            {
                FullName = FullName.Insert(0, current.Parent.Name + "\\");
                current = current.Parent;
            }
        }

        public bool HasDirectory(string directory)
        {
            return Directories.ContainsKey(directory);
        }

        public D2pDirectory TryGetDirectory(string name)
        {
            D2pDirectory directory;
            if (Directories.TryGetValue(name, out directory))
                return directory;

            return null;
        }

        public bool HasEntry(string entryName)
        {
            return Entries.Any(entry => entry.FullFileName == entryName);
        }

        public D2pEntry TryGetEntry(string entryName)
        {
            return Entries.SingleOrDefault(entry => entry.FullFileName == entryName);
        }

        public IEnumerable<D2pEntry> GetAllEntries()
        {
            return Entries.Concat(Directories.SelectMany(x => x.Value.GetAllEntries()));
        }
    }
}