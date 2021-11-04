using BepInEx;
using HarmonyLib;
using System.Collections.Generic;
using System.Reflection.Emit;
using UnityEngine;

namespace MF22Mods.RightclickDeselect
{
    [BepInPlugin(GUID, Name, Version)]
    public class Main : BaseUnityPlugin
    {
        public const string GUID = "de.benediktwerner.mf22.rightclickdeselect";
        public const string Name = "RightclickDeselect";
        public const string Version = "1.0.0";

        private void Awake()
        {
            Harmony.CreateAndPatchAll(typeof(Patch));
        }
    }

    [HarmonyPatch]
    class Patch
    {
        [HarmonyTranspiler]
        [HarmonyPatch(typeof(BoardEditor), "updateSelection")]
        public static IEnumerable<CodeInstruction> BoardEditor_updateSelection_Transpiler(IEnumerable<CodeInstruction> instructions)
        {
            return new CodeMatcher(instructions).MatchForward(false,
                    new CodeMatch(OpCodes.Ldarg_0),
                    new CodeMatch(OpCodes.Ldc_I4_1),
                    new CodeMatch(OpCodes.Call, AccessTools.Method(typeof(BoardEditor), "rotateSelection"))
                )
                .Advance(1)
                .RemoveInstruction()
                .SetOperandAndAdvance(AccessTools.Method(typeof(BoardEditor), "cleanupSelection"))
                .InstructionEnumeration();
        }

        [HarmonyPrefix]
        [HarmonyPatch(typeof(MachineGroup), "checkRot")]
        public static bool MachineGroup_checkRot_Prefix(MachineGroup __instance, bool uiMoused)
        {
            if (Input.GetMouseButtonDown(1) && !uiMoused)
            {
                __instance.CancelPlacement();
            }
            return false;
        }
    }
}
