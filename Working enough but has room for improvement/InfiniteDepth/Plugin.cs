using BepInEx;
using BepInEx.Logging;
using Nautilus.Assets.PrefabTemplates;
using Nautilus.Assets;
using System;
using System.Collections.Generic;
using Nautilus.Assets.Gadgets;

namespace FinnyBeast_TheVogels.FasterVehicleModules
{
    [BepInPlugin(MyGuid, PluginName, VersionString)]
    [BepInDependency("com.snmodding.nautilus")] // marks Nautilus as a dependency for this mod
    public class FasterVehiclesPlugin : BaseUnityPlugin
    {
        private const string MyGuid = "com.thevogels.depth";
        private const string PluginName = "Infinite Depth";
        private const string VersionString = "0.1.1";

        //private static readonly Harmony Harmony = new Harmony(MyGuid);

        public static ManualLogSource Log;

        public static PrefabInfo Info { get; private set; }

        private void Awake()
        {
            //Harmony.PatchAll();
            Logger.LogInfo(PluginName + " " + VersionString + " " + "loaded.");
            Log = Logger;
            //Initalize all prefabs
            Info = PrefabInfo.WithTechType("VehicleDepthInf", "Vehicle Depth Pressure Lifter", "Removes the depth pressure problem.")
                            .WithIcon(SpriteManager.Get(TechType.VehicleHullModule3));
            var SeamothPrefab = new CustomPrefab(Info);

            var SeamothObj = new CloneTemplate(Info, TechType.VehicleHullModule3);
            SeamothPrefab.SetGameObject(SeamothObj);
            SeamothPrefab.SetRecipe(new Nautilus.Crafting.RecipeData()
            {
                craftAmount = 1,
                Ingredients = new List<CraftData.Ingredient>()
            {
                new CraftData.Ingredient(TechType.Titanium, 1),
                new CraftData.Ingredient(TechType.TitaniumIngot, 2),
                new CraftData.Ingredient(TechType.UraniniteCrystal, 5),
                new CraftData.Ingredient(TechType.WiringKit, 1)
            }
            })
            .WithFabricatorType(CraftTree.Type.SeamothUpgrades)
            .WithStepsToFabricatorTab("GeneralModules")
            .WithCraftingTime(6.12f);
            // This first function defines the equipment type and the quick slot type.
            SeamothPrefab.SetVehicleUpgradeModule(EquipmentType.VehicleModule, QuickSlotType.Passive)
            .WithDepthUpgrade(float.MaxValue, true).WithOnModuleAdded((Vehicle vehicleInstance, int slotId) =>
            {
                vehicleInstance.crushDamage.enabled = false;
                ErrorMessage.AddMessage("Crush depth no longer is in effect.\nNote: The vehicle will still warn you about the non-existent depth limit.");
            })
            .WithOnModuleRemoved((Vehicle vehicleInstance, int slotId) =>
            {
                vehicleInstance.crushDamage.enabled = true;
                ErrorMessage.AddMessage("Crush depth is in effect.");
            });
            SeamothPrefab.Register();
        }
    }
}
