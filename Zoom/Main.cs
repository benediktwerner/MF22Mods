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
        public const string GUID = "de.benediktwerner.mf22.zoom";
        public const string Name = "Zoom";
        public const string Version = "1.0.0";

        private void Awake()
        {
            Harmony.CreateAndPatchAll(typeof(Patch));
        }
    }

    [HarmonyPatch]
    class Patch
    {
        [HarmonyPostfix]
        [HarmonyPatch(typeof(BoardEditor), "Update")]
        public static void BoardEditor_Update_Postfix(BoardEditor __instance)
        {
            var board = AccessTools.Field(typeof(BoardEditor), "board").GetValue(__instance) as Board;
            if (board is null) return;
            var camera = board.GetCamera();
            if (camera is null) return;
            camera.fieldOfView -= Input.mouseScrollDelta.y;

            if (Input.GetMouseButton(2))
            {
                var pos = camera.transform.position;
                pos.x -= Input.GetAxis("Mouse X");
                pos.z -= Input.GetAxis("Mouse Y");
                camera.transform.position = pos;
            }
        }
    }
}
