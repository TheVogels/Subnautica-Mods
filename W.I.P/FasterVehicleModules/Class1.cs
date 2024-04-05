using BepInEx;
using BepInEx.Logging;
using FasterVehicleModules;
using HarmonyLib;
//using System;

//Finn, we don't need Harmony. We might later though.
//Now we need Harmony.

namespace FinnyBeast_TheVogels.FasterVehicleModules
{
    [BepInPlugin(MyGuid, PluginName, VersionString)]
    [BepInDependency("com.snmodding.nautilus")] // marks Nautilus as a dependency for this mod
    public class FasterVehiclesPlugin : BaseUnityPlugin
    {
        //Idea: FinnyBeast
        //Code: TheVogels
        //FinnyBeast has access to the code but doesn't want to learn how to code.
        //TheVogels GitHub: TheVogels
        //FinnyBeast GitHub: Breeland

        //Version history: 0.0.1 - Implemented Seamoth
        //Version history: 0.0.2 - Implemented Prawn Suit
        //Version history: 0.0.3 - Implemented Cyclops
        private const string MyGuid = "com.finnybeast-thevogels.fastervehicles";
        private const string PluginName = "Vehicle Speed Modules";
        private const string VersionString = "0.0.3";

        private static readonly Harmony Harmony = new Harmony(MyGuid);

        public static ManualLogSource Log;

        private void Awake()
        {
            Logger.LogInfo(PluginName + " " + VersionString + " " + "loaded.");
            Log = Logger;
            //Initalize all prefabs
            CyclopsSpeed.Register();
            SeamothSpeedModule.Register();
            ExoSuitUpgrade.Register();
            Harmony.PatchAll();
        }
    }
}
