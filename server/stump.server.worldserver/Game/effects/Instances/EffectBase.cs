using System;
using System.IO;
using System.Linq;
using System.Text;
using NLog;
using Stump.DofusProtocol.D2oClasses;
using Stump.DofusProtocol.Enums;
using Stump.DofusProtocol.Types;
using Stump.Server.WorldServer.Database.Effects;
using Stump.Server.WorldServer.Database.Spells;
using Stump.Server.WorldServer.Game.Effects.Handlers.Spells.Targets;

namespace Stump.Server.WorldServer.Game.Effects.Instances
{
    public enum EffectGenerationContext
    {
        Item,
        Spell,
    }

    public enum EffectGenerationType
    {
        Normal,
        MaxEffects,
        MinEffects,
    }

    [Serializable]
    public class EffectBase : ICloneable
    {
        static readonly Logger logger = LogManager.GetCurrentClassLogger();
        string targetMask;
        int diceNum;
        bool visibleInBuffUi;
        bool visibleInFight;
        int targetId;
        int effectElement;
        int effectUid;
        int dispellable;
        string triggers;
        int spellId;
        int duration;
        int random;
        short effectId;
        int delay;
        int diceSide;
        bool visibleInTooltip;
        string rawZone;
        bool forClientOnly;
        int value;
        int order;
        int group;
        int modificator;

        [NonSerialized] TargetCriterion[] targets = new TargetCriterion[0];

        [NonSerialized] protected EffectTemplate template;
        bool trigger;
        uint zoneMinSize;
        SpellShapeEnum zoneShape;
        uint zoneSize;
        int zoneEfficiencyPercent;
        int zoneMaxEfficiency;

        [NonSerialized] int priority;

        public EffectBase()
        {
        }

        public EffectBase(EffectBase effect)
        {
            effectId = effect.Id;
            effectUid = effect.Uid;
            template = EffectManager.Instance.GetTemplate(effect.Id);
            targets = effect.Targets;
            targetMask = effect.TargetMask;
            delay = effect.Delay;
            duration = effect.Duration;
            group = effect.Group;
            random = effect.Random;
            modificator = effect.Modificator;
            trigger = effect.Trigger;
            triggers = effect.Triggers;
            zoneSize = effect.zoneSize;
            zoneMinSize = effect.zoneMinSize;
            zoneShape = effect.ZoneShape;
            zoneMaxEfficiency = effect.ZoneMaxEfficiency;
            zoneEfficiencyPercent = effect.ZoneEfficiencyPercent;

            spellId = effect.SpellId;
            forClientOnly = effect.ForClientOnly;
            order = effect.Order;
            dispellable = effect.Dispellable;
            effectElement = effect.EffectElement;
            ParseTargets();
        }

        public EffectBase(short id, EffectBase effect)
            : this(effect)
        {
            Id = id;
        }

        public EffectBase(EffectInstance effect)
        {
            effectId = (short) effect.effectId;
            effectUid = (int) effect.effectUid;

            template = EffectManager.Instance.GetTemplate(Id);

            targetMask = effect.targetMask;
            delay = effect.delay;
            duration = effect.duration;
            group = effect.group;
            random = effect.random;
            modificator = effect.modificator;
            trigger = effect.trigger;
            triggers = effect.triggers;

            order = effect.order;
            spellId = effect.spellId;
            dispellable = effect.dispellable;
            effectElement = effect.effectElement;
            forClientOnly = effect.forClientOnly;
            ParseRawZone(effect.rawZone);
            ParseTargets();
        }

        public virtual int ProtocoleId => 76;

        public virtual byte SerializationIdenfitier => 1;

        public short Id
        {
            get { return effectId; }
            set
            {
                effectId = value;
                IsDirty = true;
            }
        }

        public int Uid
        {
            get { return effectUid; }
            set
            {
                effectUid = value;
                IsDirty = true;
            }
        }


        public EffectsEnum EffectId
        {
            get { return (EffectsEnum) Id; }
            set
            {
                Id = (short) value;
                IsDirty = true;
            }
        }

        public EffectTemplate Template
        {
            get { return template ?? (template = EffectManager.Instance.GetTemplate(Id)); }
            protected set
            {
                template = value;
                IsDirty = true;
            }
        }

        public string TargetMask
        {
            get { return targetMask; }
            set
            {
                targetMask = value;
                IsDirty = true;
            }
        }

        public TargetCriterion[] Targets
        {
            get { return targets; }
            set
            {
                targets = value;
                IsDirty = true;
            }
        }

        public int Priority
        {
            get
            {
                if (Template != null)
                {
                    return priority == 0 ? Template.EffectPriority : priority;
                }
                else
                {
                    return priority;
                }
            } //priority == 0 ? Template.EffectPriority : priority; } NOT USED OBLIVIOUSLY
            set { priority = value; }
        }

        public int Duration
        {
            get { return duration; }
            set
            {
                duration = value;
                IsDirty = true;
            }
        }

        public int Delay
        {
            get { return delay; }
            set
            {
                delay = value;
                IsDirty = true;
            }
        }

        public int Random
        {
            get { return random; }
            set
            {
                random = value;
                IsDirty = true;
            }
        }

        public int Group
        {
            get { return group; }
            set
            {
                group = value;
                IsDirty = true;
            }
        }

        public int Modificator
        {
            get { return modificator; }
            set
            {
                modificator = value;
                IsDirty = true;
            }
        }

        public string Triggers
        {
            get { return triggers; }
            set
            {
                triggers = value;
                IsDirty = true;
            }
        }

        public bool Trigger
        {
            get { return trigger; }
            set
            {
                trigger = value;
                IsDirty = true;
            }
        }

        public uint ZoneSize
        {
            get { return zoneSize >= 63 ? (byte) 63 : (byte) zoneSize; }
            set
            {
                zoneSize = value;
                IsDirty = true;
            }
        }

        public SpellShapeEnum ZoneShape
        {
            get { return zoneShape; }
            set
            {
                zoneShape = value;
                IsDirty = true;
            }
        }

        public uint ZoneMinSize
        {
            get { return zoneMinSize >= 63 ? (byte) 63 : (byte) zoneMinSize; }
            set
            {
                zoneMinSize = value;
                IsDirty = true;
            }
        }

        public int ZoneEfficiencyPercent
        {
            get { return zoneEfficiencyPercent; }
            set
            {
                zoneEfficiencyPercent = value;
                IsDirty = true;
            }
        }

        public int ZoneMaxEfficiency
        {
            get { return zoneMaxEfficiency; }
            set
            {
                zoneMaxEfficiency = value;
                IsDirty = true;
            }
        }

        public int SpellId
        {
            get { return spellId; }
            set
            {
                spellId = value;
                IsDirty = true;
            }
        }

        public int Order
        {
            get { return order; }
            set
            {
                order = value;
                IsDirty = true;
            }
        }

        public int EffectElement
        {
            get { return effectElement; }
            set
            {
                effectElement = value;
                IsDirty = true;
            }
        }

        public bool ForClientOnly
        {
            get { return forClientOnly; }
            set
            {
                forClientOnly = value;
                IsDirty = true;
            }
        }

        public int Dispellable
        {
            get { return dispellable; }
            set
            {
                dispellable = value;
                IsDirty = true;
            }
        }

        public static Logger Logger => logger;

        public int DiceNum
        {
            get => diceNum;
            set => diceNum = value;
        }

        public bool VisibleInBuffUi
        {
            get => visibleInBuffUi;
            set => visibleInBuffUi = value;
        }

        public bool VisibleInFight
        {
            get => visibleInFight;
            set => visibleInFight = value;
        }

        public int TargetId
        {
            get => targetId;
            set => targetId = value;
        }

        public int EffectUid
        {
            get => effectUid;
            set => effectUid = value;
        }

        public int DiceSide
        {
            get => diceSide;
            set => diceSide = value;
        }

        public bool VisibleInTooltip
        {
            get => visibleInTooltip;
            set => visibleInTooltip = value;
        }

        public string RawZone
        {
            get => rawZone;
            set => rawZone = value;
        }

        public int Value
        {
            get => value;
            set => value = value;
        }

        public SpellEffectFix EffectFix1
        {
            get => EffectFix;
            set => EffectFix = value;
        }


        [NonSerialized] public SpellEffectFix EffectFix;

        public bool IsDirty { get; set; }

        #region ICloneable Members

        public object Clone()
        {
            return MemberwiseClone();
        }

        #endregion

        protected void ParseTargets()
        {
            if (string.IsNullOrEmpty(targetMask) || targetMask == "a,A" || targetMask == "A,a")
            {
                targets = new TargetCriterion[0];
                return; // default target = ALL
            }

            var data = targetMask.Split(',');

            targets = data.Select(TargetCriterion.ParseCriterion).ToArray();
        }

        protected void ParseRawZone(string rawZone)
        {
            if (string.IsNullOrEmpty(rawZone))
            {
                zoneShape = 0;
                zoneSize = 0;
                zoneMinSize = 0;
                return;
            }

            var shape = (SpellShapeEnum)rawZone[0]; //ToDo //TEMPORARY VALUE FOR TESTS
            byte size = 0;
            byte minSize = 0;
            int zoneEfficiency = 0;
            int zoneMaxEfficiency = 0;

            var data = rawZone.Remove(0, 1).Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries);
            var hasMinSize = shape == SpellShapeEnum.C || shape == SpellShapeEnum.X || shape == SpellShapeEnum.Q ||
                             shape == SpellShapeEnum.plus || shape == SpellShapeEnum.sharp;


            try
            {
                if (data.Length >= 4)
                {
                    size = byte.Parse(data[0]);
                    minSize = byte.Parse(data[1]);
                    zoneEfficiency = byte.Parse(data[2]);
                    zoneMaxEfficiency = byte.Parse(data[2]);
                }
                else
                {
                    if (data.Length >= 1)
                        size = byte.Parse(data[0]);

                    if (data.Length >= 2)
                        if (hasMinSize)
                            minSize = byte.Parse(data[1]);
                        else
                            zoneEfficiency = byte.Parse(data[1]);

                    if (data.Length >= 3)
                        if (hasMinSize)
                            zoneEfficiency = byte.Parse(data[2]);
                        else
                            zoneMaxEfficiency = byte.Parse(data[2]);
                }
            }
            catch (Exception ex)
            {
                zoneShape = 0;
                zoneSize = 0;
                zoneMinSize = 0;

                logger.Error("ParseRawZone() => Cannot parse {0}", rawZone);
            }

            zoneShape = shape;
            zoneSize = size;
            zoneMinSize = minSize;
            zoneEfficiencyPercent = zoneEfficiency;
            zoneMaxEfficiency = zoneMaxEfficiency;
        }

        protected string BuildRawZone()
        {
            var builder = new StringBuilder();

            builder.Append((char) (int) ZoneShape);
            builder.Append(ZoneSize);

            var hasMinSize = ZoneShape == SpellShapeEnum.C || ZoneShape == SpellShapeEnum.X ||
                             ZoneShape == SpellShapeEnum.Q || ZoneShape == SpellShapeEnum.plus ||
                             ZoneShape == SpellShapeEnum.sharp;

            if (hasMinSize)
            {
                if (ZoneMinSize <= 0)
                    return builder.ToString();

                builder.Append(",");
                builder.Append(ZoneMinSize);

                if (ZoneEfficiencyPercent > 0)
                {
                    builder.Append(",");
                    builder.Append(ZoneEfficiencyPercent);

                    if (ZoneMaxEfficiency > 0)
                    {
                        builder.Append(",");
                        builder.Append(ZoneEfficiencyPercent);
                    }
                }
            }
            else
            {
                if (ZoneMinSize <= 0)
                    return builder.ToString();

                builder.Append(",");
                builder.Append(ZoneEfficiencyPercent);

                if (ZoneMaxEfficiency > 0)
                {
                    builder.Append(",");
                    builder.Append(ZoneMaxEfficiency);
                }
            }

            return builder.ToString();
        }

        public virtual object[] GetValues()
        {
            return new object[0];
        }

        public virtual EffectBase GenerateEffect(EffectGenerationContext context,
            EffectGenerationType type = EffectGenerationType.Normal)
        {
            return new EffectBase(this);
        }

        public virtual ObjectEffect GetObjectEffect()
        {
            return new ObjectEffect((ushort) Id);
        }

        public virtual EffectInstance GetEffectInstance()
        {
            return new EffectInstance
            {
                effectId = (uint) Id,
                targetMask = TargetMask,
                delay = Delay,
                duration = Duration,
                group = Group,
                random = Random,
                modificator = Modificator,
                trigger = Trigger,
                triggers = Triggers,
                zoneMinSize = ZoneMinSize,
                zoneSize = ZoneSize,
                zoneShape = (uint) ZoneShape,
                zoneEfficiencyPercent = ZoneEfficiencyPercent,
                zoneMaxEfficiency = ZoneMaxEfficiency,
                forClientOnly = ForClientOnly,
                spellId = SpellId,
                order = Order,
                effectElement = EffectElement,
                dispellable = Dispellable
            };
        }

        public byte[] Serialize()
        {
            var writer = new BinaryWriter(new MemoryStream());

            writer.Write(SerializationIdenfitier);

            InternalSerialize(ref writer);

            return ((MemoryStream) writer.BaseStream).ToArray();
        }

        protected virtual void InternalSerialize(ref BinaryWriter writer)
        {
            if (string.IsNullOrEmpty(TargetMask) &&
                Duration == 0 &&
                Delay == 0 &&
                Random == 0 &&
                Group == 0 &&
                Modificator == 0 &&
                Trigger == false &&
                ZoneSize == 0 &&
                ZoneShape == 0)
            {
                writer.Write('C'); // cutted object

                writer.Write(Id);
            }
            else
            {
                writer.Write('F'); // full
                writer.Write(TargetMask);
                writer.Write(Id); // writer id second 'cause targets can't equals to 'C' but id can
                writer.Write(Uid);
                writer.Write(Duration);
                writer.Write(Delay);
                writer.Write(Random);
                writer.Write(Group);
                writer.Write(Modificator);
                writer.Write(Trigger);
                writer.Write(Triggers);

                string rawZone = BuildRawZone();
                if (rawZone == null)
                    writer.Write(string.Empty);
                else
                    writer.Write(rawZone);

                writer.Write(Order);
                writer.Write(SpellId);
                writer.Write(EffectElement);
                writer.Write(Dispellable);
                writer.Write(ForClientOnly);
            }
        }

        /// <summary>
        /// Use EffectManager.Deserialize
        /// </summary>
        public void DeSerialize(byte[] buffer, ref int index)
        {
            var reader = new BinaryReader(new MemoryStream(buffer, index, buffer.Length - index));

            InternalDeserialize(ref reader);

            index += (int) reader.BaseStream.Position;
        }

        protected virtual void InternalDeserialize(ref BinaryReader reader)
        {
            var header = reader.ReadChar();
            if (header == 'C')
            {
                effectId = reader.ReadInt16();
            }
            else if (header == 'F')
            {
                TargetMask = reader.ReadString();
                effectId = reader.ReadInt16();
                effectUid = reader.ReadInt32();
                duration = reader.ReadInt32();
                delay = reader.ReadInt32();
                random = reader.ReadInt32();
                group = reader.ReadInt32();
                modificator = reader.ReadInt32();
                trigger = reader.ReadBoolean();
                triggers = reader.ReadString();

                ParseRawZone(reader.ReadString());

                order = reader.ReadInt32();
                spellId = reader.ReadInt32();
                effectElement = reader.ReadInt32();
                dispellable = reader.ReadInt32();
                forClientOnly = reader.ReadBoolean();

                ParseTargets();
            }
            else
            {
                throw new Exception($"Wrong header : {header}");
            }
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof(EffectBase)) return false;
            return Equals((EffectBase) obj);
        }

        public static bool operator ==(EffectBase left, EffectBase right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(EffectBase left, EffectBase right)
        {
            return !Equals(left, right);
        }

        public bool Equals(EffectBase other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return other.Id == Id;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}