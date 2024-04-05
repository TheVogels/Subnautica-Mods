using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using System;

namespace TheVogels.OxygenManager
{
    [BepInPlugin(MyGuid, PluginName, VersionString)]
    [BepInDependency("com.snmodding.nautilus")] // marks Nautilus as a dependency for this mod
    public class FasterVehiclesPlugin : BaseUnityPlugin
    {
        private const string MyGuid = "com.thevogels.oxygenmanager";
        private const string PluginName = "Oxygen Changer";
        private const string VersionString = "0.1.0";

        private static readonly Harmony Harmony = new Harmony(MyGuid);

        public static ManualLogSource Log;

        private void Awake()
        {
            //Harmony.PatchAll();
            Logger.LogInfo(PluginName + " " + VersionString + " " + "loaded.");
            Log = Logger;
            Harmony.PatchAll();
        }
    }

    [HarmonyPatch(typeof(Oxygen), nameof(Oxygen.GetOxygenAvailable))]
    public static class OxygenChange
    {
        //static bool AlreadyApplied = false;
        [HarmonyPostfix]
        public static void Prefix(Oxygen __instance)
        {
            if(__instance.isPlayer)
            __instance.oxygenCapacity = 0.1f;
        }
    }
}
