using System.Linq;
using Stump.DofusProtocol.Enums;
using Stump.Server.WorldServer.Database.Spells;
using Stump.Server.WorldServer.Game.Effects.Instances;
using Stump.Server.WorldServer.Game.Spells;

namespace Stump.Server.WorldServer.AI.Fights.Spells
{
    public class SpellIdentifier
    {
        public static SpellCategory GetSpellCategories(Spell spell)
        {
            return GetSpellCategories(spell.CurrentSpellLevel);
        }

        public static SpellCategory GetSpellCategories(SpellLevelTemplate spellLevel)
        {
            return spellLevel.Effects.Aggregate(SpellCategory.None,
                (current, effect) => current | GetEffectCategories(effect));
        }

        public static SpellCategory GetEffectCategories(EffectDice effect)
        {
            switch (effect.EffectId)
            {
                case EffectsEnum.Effect_93:
                    return SpellCategory.DamagesAir | SpellCategory.Healing;
                case EffectsEnum.Effect_91:
                    return SpellCategory.DamagesWater | SpellCategory.Healing;
                case EffectsEnum.Effect_94:
                    return SpellCategory.DamagesFire | SpellCategory.Healing;
                case EffectsEnum.Effect_92:
                    return SpellCategory.DamagesEarth | SpellCategory.Healing;
                case EffectsEnum.Effect_95:
                    return SpellCategory.DamagesNeutral | SpellCategory.Healing;
                case EffectsEnum.Effect_99:
                case EffectsEnum.Effect_278:
                case EffectsEnum.Effect_1133:
                case EffectsEnum.Effect_88:
                case EffectsEnum.Effect_1015:
                    return SpellCategory.DamagesFire;
                case EffectsEnum.Effect_96:
                case EffectsEnum.Effect_275:
                case EffectsEnum.Effect_1132:
                case EffectsEnum.Effect_85:
                case EffectsEnum.Effect_1014:
                    return SpellCategory.DamagesWater;
                case EffectsEnum.Effect_98:
                case EffectsEnum.Effect_277:
                case EffectsEnum.Effect_1131:
                case EffectsEnum.Effect_87:
                case EffectsEnum.Effect_1013:
                    return SpellCategory.DamagesAir;
                case EffectsEnum.Effect_100:
                case EffectsEnum.Effect_279:
                case EffectsEnum.Effect_1134:
                case EffectsEnum.Effect_672:
                case EffectsEnum.Effect_89:
                case EffectsEnum.Effect_1012:
                    return SpellCategory.DamagesNeutral;
                case EffectsEnum.Effect_97:
                case EffectsEnum.Effect_276:
                case EffectsEnum.Effect_1135:
                case EffectsEnum.Effect_86:
                case EffectsEnum.Effect_1016:
                    return SpellCategory.DamagesEarth;
                case EffectsEnum.Effect_108:
                case EffectsEnum.Effect_143:
                case EffectsEnum.Effect_81:
                case EffectsEnum.Effect_1109:
                    return SpellCategory.Healing;
                case EffectsEnum.Effect_141:
                case EffectsEnum.Effect_405:
                    return SpellCategory.Damages;
                case EffectsEnum.Effect_181:
                case EffectsEnum.Effect_180:
                case EffectsEnum.Effect_185:
                case EffectsEnum.Effect_621:
                case EffectsEnum.Effect_623:
                case EffectsEnum.Effect_401:
                case EffectsEnum.Effect_402:
                    return SpellCategory.Summoning;
                case EffectsEnum.Effect_780:
                    return SpellCategory.Summoning | SpellCategory.Healing;
                case EffectsEnum.Effect_265:
                case EffectsEnum.Effect_212:
                case EffectsEnum.Effect_213:
                case EffectsEnum.Effect_210:
                case EffectsEnum.Effect_211:
                case EffectsEnum.Effect_214:
                case EffectsEnum.Effect_242:
                case EffectsEnum.Effect_243:
                case EffectsEnum.Effect_240:
                case EffectsEnum.Effect_241:
                case EffectsEnum.Effect_244:
                case EffectsEnum.Effect_119:
                case EffectsEnum.Effect_118:
                case EffectsEnum.Effect_126:
                case EffectsEnum.Effect_110:
                case EffectsEnum.Effect_123:
                case EffectsEnum.Effect_115:
                case EffectsEnum.Effect_418:
                case EffectsEnum.Effect_420:
                case EffectsEnum.Effect_112:
                case EffectsEnum.Effect_165:
                case EffectsEnum.Effect_121:
                case EffectsEnum.Effect_424:
                case EffectsEnum.Effect_428:
                case EffectsEnum.Effect_426:
                case EffectsEnum.Effect_422:
                case EffectsEnum.Effect_430:
                case EffectsEnum.Effect_114:
                case EffectsEnum.Effect_107:
                case EffectsEnum.Effect_164:
                case EffectsEnum.Effect_105:
                case EffectsEnum.Effect_111:
                case EffectsEnum.Effect_178:
                case EffectsEnum.Effect_124:
                case EffectsEnum.Effect_176:
                case EffectsEnum.Effect_412:
                case EffectsEnum.Effect_128:
                case EffectsEnum.Effect_137:
                case EffectsEnum.Effect_142:
                case EffectsEnum.Effect_184:
                case EffectsEnum.Effect_416:
                case EffectsEnum.Effect_414:
                case EffectsEnum.Effect_117:
                case EffectsEnum.Effect_136:
                case EffectsEnum.Effect_182:
                case EffectsEnum.Effect_125:
                case EffectsEnum.Effect_1078:
                case EffectsEnum.Effect_753:
                case EffectsEnum.Effect_752:
                case EffectsEnum.Effect_9:
                case EffectsEnum.Effect_160:
                case EffectsEnum.Effect_161:
                case EffectsEnum.Effect_150:
                case EffectsEnum.Effect_106:
                case EffectsEnum.Effect_120:
                case EffectsEnum.Effect_765:
                case EffectsEnum.Effect_79:
                case EffectsEnum.Effect_138:
                case EffectsEnum.Effect_1020:
                    return SpellCategory.Buff;
                case EffectsEnum.Effect_4:
                    return SpellCategory.Teleport;
                case EffectsEnum.Effect_5:
                case EffectsEnum.Effect_6:
                case EffectsEnum.Effect_1042:
                case EffectsEnum.Effect_1041:
                case EffectsEnum.Effect_8:
                case EffectsEnum.Effect_101:
                case EffectsEnum.Effect_127:
                case EffectsEnum.Effect_130:
                case EffectsEnum.Effect_131:
                case EffectsEnum.Effect_133:
                case EffectsEnum.Effect_134:
                case EffectsEnum.Effect_135:
                case EffectsEnum.Effect_140:
                case EffectsEnum.Effect_145:
                case EffectsEnum.Effect_152:
                case EffectsEnum.Effect_153:
                case EffectsEnum.Effect_154:
                case EffectsEnum.Effect_155:
                case EffectsEnum.Effect_156:
                case EffectsEnum.Effect_157:
                case EffectsEnum.Effect_162:
                case EffectsEnum.Effect_163:
                case EffectsEnum.Effect_755:
                case EffectsEnum.Effect_754:
                case EffectsEnum.Effect_168:
                case EffectsEnum.Effect_1079:
                case EffectsEnum.Effect_169:
                case EffectsEnum.Effect_116:
                case EffectsEnum.Effect_171:
                case EffectsEnum.Effect_172:
                case EffectsEnum.Effect_173:
                case EffectsEnum.Effect_175:
                case EffectsEnum.Effect_177:
                case EffectsEnum.Effect_179:
                case EffectsEnum.Effect_186:
                case EffectsEnum.Effect_197:
                case EffectsEnum.Effect_215:
                case EffectsEnum.Effect_216:
                case EffectsEnum.Effect_217:
                case EffectsEnum.Effect_218:
                case EffectsEnum.Effect_219:
                case EffectsEnum.Effect_245:
                case EffectsEnum.Effect_246:
                case EffectsEnum.Effect_247:
                case EffectsEnum.Effect_248:
                case EffectsEnum.Effect_249:
                case EffectsEnum.Effect_255:
                case EffectsEnum.Effect_256:
                case EffectsEnum.Effect_257:
                case EffectsEnum.Effect_258:
                case EffectsEnum.Effect_259:
                case EffectsEnum.Effect_266:
                case EffectsEnum.Effect_267:
                case EffectsEnum.Effect_268:
                case EffectsEnum.Effect_269:
                case EffectsEnum.Effect_270:
                case EffectsEnum.Effect_271:
                case EffectsEnum.Effect_411:
                case EffectsEnum.Effect_413:
                case EffectsEnum.Effect_419:
                case EffectsEnum.Effect_417:
                case EffectsEnum.Effect_421:
                case EffectsEnum.Effect_423:
                case EffectsEnum.Effect_425:
                case EffectsEnum.Effect_427:
                case EffectsEnum.Effect_429:
                case EffectsEnum.Effect_431:
                case EffectsEnum.Effect_440:
                case EffectsEnum.Effect_441:
                case EffectsEnum.Effect_77:
                case EffectsEnum.Effect_202:
                case EffectsEnum.Effect_1075:
                case EffectsEnum.Effect_786:
                case EffectsEnum.Effect_90:
                case EffectsEnum.Effect_132:
                case EffectsEnum.Effect_776:
                case EffectsEnum.Effect_781:
                    return SpellCategory.Curse;


                case EffectsEnum.Effect_792:
                case EffectsEnum.Effect_793:
                case EffectsEnum.Effect_1160:
                case EffectsEnum.Effect_1017:
                case EffectsEnum.Effect_2160:
                case EffectsEnum.Effect_1175:
                case EffectsEnum.Effect_2792:
                case EffectsEnum.Effect_2794:
                    var spell = SpellManager.Instance.GetSpellLevel(effect.DiceNum, effect.DiceFace);
                    if (spell != null)
                    {
                        if (spell.Effects.Any(x =>
                            (x.EffectId == EffectsEnum.Effect_792 ||
                             x.EffectId == EffectsEnum.Effect_793 ||
                             x.EffectId == EffectsEnum.Effect_1017 ||
                             x.EffectId == EffectsEnum.Effect_1160 ||
                             x.EffectId == EffectsEnum.Effect_1175 ||
                             x.EffectId == EffectsEnum.Effect_2160 ||
                             x.EffectId == EffectsEnum.Effect_1017 ||
                             x.EffectId == EffectsEnum.Effect_1160 ||
                             x.EffectId == EffectsEnum.Effect_1175 || x.EffectId == EffectsEnum.Effect_2792 ||
                             x.EffectId == EffectsEnum.Effect_1017 ||
                             x.EffectId == EffectsEnum.Effect_1160 ||
                             x.EffectId == EffectsEnum.Effect_1175 ||
                             x.EffectId == EffectsEnum.Effect_2794) &&
                            x.DiceNum == effect.SpellId))
                            return SpellCategory.None;
                        return GetSpellCategories(spell);
                    }
                    else
                    {
                        return SpellCategory.None;
                    }
            }

            return SpellCategory.None;
        }
    }
}