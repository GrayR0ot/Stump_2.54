using System.Collections.Generic;
using Stump.Core.IO;
using Stump.DofusProtocol.D2oClasses.Tools.D2o;
using Stump.ORM;
using Stump.ORM.SubSonic.SQLGeneration.Schema;
using Stump.Server.WorldServer.Database.Npcs.Replies;
using Stump.Server.WorldServer.Game.Actors.RolePlay.Npcs;

namespace Stump.Server.WorldServer.Database.Npcs
{
    public class NpcMessageRelator
    {
        public static string FetchQuery = "SELECT * FROM npcs_messages";
    }

    [TableName("npcs_messages")]
    [D2OClass("NpcMessage", "com.ankamagames.dofus.datacenter.npcs")]
    public sealed class NpcMessage : IAssignedByD2O, IAutoGeneratedRecord
    {
        private IList<string> m_parameters;
        private string m_parametersCSV;
        private List<NpcReply> m_replies;

        [PrimaryKey("Id", false)] public int Id { get; set; }

        public uint MessageId { get; set; }

        public string ParametersCSV
        {
            get => m_parametersCSV;
            set
            {
                m_parametersCSV = value;
                m_parameters = value.FromCSV<string>("|");
            }
        }

        [Ignore]
        public IList<string> Parameters
        {
            get => m_parameters;
            set
            {
                m_parameters = value;
                ParametersCSV = value.ToCSV("|");
            }
        }

        public List<NpcReply> Replies => m_replies ?? (m_replies = NpcManager.Instance.GetMessageReplies(Id));

        #region IAssignedByD2O Members

        public void AssignFields(object d2oObject)
        {
            var message = (DofusProtocol.D2oClasses.NpcMessage) d2oObject;
            Id = message.id;
            MessageId = message.messageId;
            ParametersCSV = "";
        }

        #endregion
    }
}