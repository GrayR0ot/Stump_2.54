using Stump.Core.IO;

namespace D2pReader.MapInformations.Elements
{
    public class SoundElement : BasicElement
    {
        public SoundElement(BigEndianReader _reader)
        {
            SoundId = _reader.ReadInt();
            BaseVolume = _reader.ReadShort();
            FullVolumeDistance = _reader.ReadInt();
            NullVolumeDistance = _reader.ReadInt();
            MinDelayBetweenLoops = _reader.ReadShort();
            MaxDelayBetweenLoops = _reader.ReadShort();
        }

        #region Vars

        #endregion

        #region Properties

        public int SoundId { get; }

        public int BaseVolume { get; }

        public int FullVolumeDistance { get; }

        public int NullVolumeDistance { get; }

        public int MinDelayBetweenLoops { get; }

        public int MaxDelayBetweenLoops { get; }

        #endregion
    }
}