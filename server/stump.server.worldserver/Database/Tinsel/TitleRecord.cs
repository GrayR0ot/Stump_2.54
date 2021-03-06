#region License GNU GPL

// TitleRecord.cs
// 
// Copyright (C) 2013 - BehaviorIsManaged
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

using Stump.DofusProtocol.D2oClasses;
using Stump.DofusProtocol.D2oClasses.Tools.D2o;
using Stump.ORM;
using Stump.ORM.SubSonic.SQLGeneration.Schema;
using Stump.Server.WorldServer.Database.I18n;

namespace Stump.Server.WorldServer.Database.Tinsel
{
    public class TitleRelator
    {
        public static string FetchQuery = "SELECT * FROM tinsel_titles";
    }

    [D2OClass("Title")]
    [TableName("tinsel_titles")]
    public class TitleRecord : IAssignedByD2O, IAutoGeneratedRecord
    {
        private string m_name;

        [PrimaryKey("Id", false)] public int Id { get; set; }

        public uint NameId { get; set; }

        public string Name => m_name ?? (m_name = TextManager.Instance.GetText(NameId));

        public bool Visible { get; set; }

        public int CategoryId { get; set; }

        public void AssignFields(object d2oObject)
        {
            var title = (Title) d2oObject;
            Id = title.id;
            NameId = title.nameMaleId;
            Visible = title.visible;
            CategoryId = title.categoryId;
        }
    }
}