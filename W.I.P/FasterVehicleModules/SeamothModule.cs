using HarmonyLib;
using Nautilus.Assets;
using Nautilus.Assets.Gadgets;
using Nautilus.Assets.PrefabTemplates;
using Nautilus.Options;
using Nautilus.Options.Attributes;
using UnityEngine;

[HarmonyPatch(typeof(SeaMoth), nameof(SeaMoth.Update))]
public class SeamothSpeedModule
{
    // To access the TechType anywhere in the project
    public static PrefabInfo Info { get; private set; }
    static float Forward = 12.52f;
    static float Backward = 5.45f;
    static float Side = 12.52f;
    static float Vertical = 11.93f;
    public static void Register()
    {
        Info = PrefabInfo.WithTechType("SeamothSpeedModule1", "Seamoth Speed module MK1", "Enchances the Seamoth forward speed by 1.7x.")
            .WithIcon(SpriteManager.Get(TechType.Seamoth));
        var SeamothPrefab = new CustomPrefab(Info);

        var SeamothObj = new CloneTemplate(Info, TechType.VehiclePowerUpgradeModule);
        SeamothPrefab.SetGameObject(SeamothObj);
        SeamothPrefab.SetRecipe(new Nautilus.Crafting.RecipeData()
        {
            craftAmount = 1,
            Ingredients = new List<CraftData.Ingredient>()
            {
                new CraftData.Ingredient(TechType.Titanium, 3),
                new CraftData.Ingredient(TechType.AdvancedWiringKit, 3)
            }
        })
        .WithFabricatorType(CraftTree.Type.SeamothUpgrades)
        .WithStepsToFabricatorTab("SeamothModules")
        .WithCraftingTime(6.12f);
        // This first function defines the equipment type and the quick slot type.
        SeamothPrefab.SetVehicleUpgradeModule(EquipmentType.SeamothModule, QuickSlotType.Passive)
        .WithOnModuleAdded((Vehicle vehicleInstance, int slotId) =>
        {
            Subtitles.Add("Seamoth forward Speed now 1.7x");
            vehicleInstance.forwardForce = Forward * 1.7f;
            vehicleInstance.enginePowerRating = 1/1.7f;
        })
        .WithOnModuleRemoved((Vehicle vehicleInstance, int slotId) => {
            Subtitles.Add("Seamoth forward Speed now 1x");
            vehicleInstance.forwardForce = Forward;
            vehicleInstance.enginePowerRating = 1f;
        });
        SeamothPrefab.Register();
        Info = PrefabInfo.WithTechType("SeamothSpeedModule3", "Seamoth Speed module MK3", "Enchances the Seamoth forward speed by 2.7x.")
            .WithIcon(SpriteManager.Get(TechType.Seamoth));
        SeamothPrefab = new CustomPrefab(Info);

        SeamothObj = new CloneTemplate(Info, TechType.VehiclePowerUpgradeModule);
        SeamothPrefab.SetGameObject(SeamothObj);
        SeamothPrefab.SetRecipe(new Nautilus.Crafting.RecipeData()
        {
            craftAmount = 1,
            Ingredients = new List<CraftData.Ingredient>()
            {
                new CraftData.Ingredient(TechType.Titanium, 2),
                new CraftData.Ingredient(TechType.UraniniteCrystal, 3),
                new CraftData.Ingredient(TechType.AdvancedWiringKit, 3)
            }
        })
        .WithFabricatorType(CraftTree.Type.SeamothUpgrades)
        .WithStepsToFabricatorTab("SeamothModules")
        .WithCraftingTime(6.12f);
        // This first function defines the equipment type and the quick slot type.
        SeamothPrefab.SetVehicleUpgradeModule(EquipmentType.SeamothModule, QuickSlotType.Passive)
        .WithOnModuleAdded((Vehicle vehicleInstance, int slotId) =>
        {
            Subtitles.Add("Seamoth forward Speed now 2.7x");
            vehicleInstance.forwardForce = Forward * 2.7f;
            vehicleInstance.enginePowerRating = 1/2.7f;
        })
        .WithOnModuleRemoved((Vehicle vehicleInstance, int slotId) => {
            Subtitles.Add("Seamoth forward Speed now 1x");
            vehicleInstance.forwardForce = Forward;
            vehicleInstance.enginePowerRating = 1f;
        });
        SeamothPrefab.Register();
        Info = PrefabInfo.WithTechType("SeamothSpeedModuleP1", "Seamoth Speed module PeeperMK1", "Enchances the Seamoth speed by 0.6x.\nReal forward speed is 0.6, Real sideways speed is 0.9x\nTrains and uses Peepers to help haul the Seamoth without using more power.\n\nDon't worry, the 2 Peepers love hauling the Seamoth!")
            .WithIcon(SpriteManager.Get(TechType.Peeper));
        SeamothPrefab = new CustomPrefab(Info);

        SeamothObj = new CloneTemplate(Info, TechType.VehiclePowerUpgradeModule);
        SeamothPrefab.SetGameObject(SeamothObj);
        SeamothPrefab.SetRecipe(new Nautilus.Crafting.RecipeData()
        {
            craftAmount = 1,
            Ingredients = new List<CraftData.Ingredient>()
            {
                //Don't worry, the 2 Peepers love hauling the Seamoth!
                new CraftData.Ingredient(TechType.Peeper, 2),
                new CraftData.Ingredient(TechType.Titanium, 3),
                new CraftData.Ingredient(TechType.WiringKit, 3),
                new CraftData.Ingredient(TechType.UraniniteCrystal, 2)
            }
        })
        .WithFabricatorType(CraftTree.Type.SeamothUpgrades)
        .WithStepsToFabricatorTab("SeamothModules")
        .WithCraftingTime(9.32f);
        SeamothPrefab.SetVehicleUpgradeModule(EquipmentType.SeamothModule, QuickSlotType.Passive)
        .WithOnModuleAdded((Vehicle vehicleInstance, int slotId) =>
        {
            Subtitles.Add("Seamoth forward Speed now 1.25x");
            vehicleInstance.forwardForce = Forward*1.25f;
            Subtitles.Add("Seamoth sideways Speed now 1.2x");
            vehicleInstance.sidewardForce= Side*1.2f;
        })
        .WithOnModuleRemoved((Vehicle vehicleInstance, int slotId) => {
            Subtitles.Add("Seamoth forward Speed now 1x");
            vehicleInstance.forwardForce = Forward;
            Subtitles.Add("Seamoth sideways Speed now 1x");
            vehicleInstance.sidewardForce = Side;
        });
        SeamothPrefab.Register();

        Info = PrefabInfo.WithTechType("SeamothSpeedModulePM", "Seamoth Speed module PeeperMK-Max", "Enchances the Seamoth speed by 1.5x.\nReal forward speed is 3.9x, Real sideways speed is 0.6x\nTrains and uses Peepers to help propel the Seamoth without using more power.\n\nDon't worry, the 5 Peepers love hauling the Seamoth! But it's a little crouded and they might start to argue.")
            .WithIcon(SpriteManager.Get(TechType.Peeper));
        SeamothPrefab = new CustomPrefab(Info);

        SeamothObj = new CloneTemplate(Info, TechType.VehiclePowerUpgradeModule);
        SeamothPrefab.SetGameObject(SeamothObj);
        SeamothPrefab.SetRecipe(new Nautilus.Crafting.RecipeData()
        {
            craftAmount = 1,
            Ingredients = new List<CraftData.Ingredient>()
            {
                //Don't worry, the 16 Peepers love hauling the Seamoth!
                new CraftData.Ingredient(TechType.Peeper, 5),
                new CraftData.Ingredient(TechType.Titanium, 4),
                new CraftData.Ingredient(TechType.WiringKit, 5)
            }
        })
    .WithFabricatorType(CraftTree.Type.SeamothUpgrades)
    .WithStepsToFabricatorTab("SeamothModules")
    .WithCraftingTime(17.789f);
        SeamothPrefab.SetVehicleUpgradeModule(EquipmentType.SeamothModule, QuickSlotType.Passive)
        .WithOnModuleAdded((Vehicle vehicleInstance, int slotId) =>
        {
            Subtitles.Add("Seamoth forward Speed now 3.0x");
            vehicleInstance.forwardForce = Forward*3f;
            Subtitles.Add("Seamoth sideways Speed now 2.6x");
            vehicleInstance.sidewardForce = Side*2.6f;
        })
        .WithOnModuleRemoved((Vehicle vehicleInstance, int slotId) => {
            Subtitles.Add("Seamoth forward Speed now 1.0x");
            vehicleInstance.forwardForce = Forward;
            Subtitles.Add("Seamoth sideways Speed now 1.0x");
            vehicleInstance.sidewardForce = Side;
        });
        SeamothPrefab.SetEquipment(EquipmentType.SeamothModule);
        SeamothPrefab.Register();
        
        Info = PrefabInfo.WithTechType("SeamothSpeedModuleEML", "Seamoth Emergency Speed module live", "Enchances the Seamoth speed by 2.0x.\nReal forward speed is 2.0x, Real sideways speed is 1.6x\nturns the SeaMoth into an escape vehicle.")
            .WithIcon(SpriteManager.Get(TechType.Seamoth));
        SeamothPrefab = new CustomPrefab(Info);

        SeamothObj = new CloneTemplate(Info, TechType.VehiclePowerUpgradeModule);
        SeamothPrefab.SetGameObject(SeamothObj);
        SeamothPrefab.SetRecipe(new Nautilus.Crafting.RecipeData()
        {
            craftAmount = 1,
            Ingredients = new List<CraftData.Ingredient>()
            {
                new CraftData.Ingredient(TechType.Battery, 1),
                new CraftData.Ingredient(TechType.Titanium, 4),
                new CraftData.Ingredient(TechType.UraniniteCrystal, 2),
                new CraftData.Ingredient(TechType.AdvancedWiringKit, 2)
            }
        })
    .WithFabricatorType(CraftTree.Type.SeamothUpgrades)
    .WithStepsToFabricatorTab("SeamothModules")
    .WithCraftingTime(6.789f);
        SeamothPrefab.SetVehicleUpgradeModule(EquipmentType.SeamothModule, QuickSlotType.Passive)
        .WithOnModuleAdded((Vehicle vehicleInstance, int slotId) =>
        {
            Subtitles.Add("Seamoth forward Speed now 2.0x");
            vehicleInstance.forwardForce = Forward*2f;
            Subtitles.Add("Seamoth sideways Speed now 1.6");
            vehicleInstance.sidewardForce = Side*1.6f;
            vehicleInstance.enginePowerRating = 1/8.12f;
        })
        .WithOnModuleRemoved((Vehicle vehicleInstance, int slotId) => {
            Subtitles.Add("Seamoth forward Speed now 1.0x");
            vehicleInstance.forwardForce = Forward;
            Subtitles.Add("Seamoth sideways Speed now 1.0x");
            vehicleInstance.sidewardForce = Side;
            vehicleInstance.enginePowerRating = 1f;
        });
        SeamothPrefab.SetEquipment(EquipmentType.SeamothModule);
        SeamothPrefab.Register();
        
        Info = PrefabInfo.WithTechType("SeamothSpeedModuleEM", "Seamoth Emergency Speed module", "Enchances the Seamoth speed by 2.0x.\nReal forward speed is 2.0x, Real sideways speed is 1.6x\nturns the SeaMoth into an escape vehicle.")
            .WithIcon(SpriteManager.Get(TechType.Seamoth));
        SeamothPrefab = new CustomPrefab(Info);

        SeamothObj = new CloneTemplate(Info, TechType.VehiclePowerUpgradeModule);
        SeamothPrefab.SetGameObject(SeamothObj);
        SeamothPrefab.SetRecipe(new Nautilus.Crafting.RecipeData()
        {
            craftAmount = 1,
            Ingredients = new List<CraftData.Ingredient>()
            {
                new CraftData.Ingredient(TechType.Battery, 3),
                new CraftData.Ingredient(TechType.Titanium, 5),
                new CraftData.Ingredient(TechType.AdvancedWiringKit, 2)
            }
        })
    .WithFabricatorType(CraftTree.Type.SeamothUpgrades)
    .WithStepsToFabricatorTab("SeamothModules")
    .WithCraftingTime(2.789f);
    SeamothPrefab.SetVehicleUpgradeModule(EquipmentType.SeamothModule, QuickSlotType.Selectable)
    .WithCooldown(68.9741f)
    .WithEnergyCost(10f)
    .WithOnModuleUsed((Vehicle vehicleInstance, int slotID, float charge, float chargeScalar) =>
    {
        SeaMoth Seamoth = (SeaMoth)vehicleInstance;
        var startTime = Time.time;
        //while (Time.time < (startTime + 13f))
        {
            Subtitles.Add("Seamoth forward Speed now 2.0x");
            vehicleInstance.forwardForce = Forward*2f;
            Subtitles.Add("Seamoth sideways Speed now 1.6x");
            vehicleInstance.sidewardForce = Side*1.6f;
            vehicleInstance.enginePowerRating = 1/8.12f;

            if (Seamoth)
            {
try{
                    Seamoth.volumeticLights[0].color = new Color(1f, 0f, 0f, 1f);
                    Seamoth.volumeticLights[1].color = new Color(1f, 0f, 0f, 1f);
                    Seamoth.gameObject.FindChild("lights_parent").FindChild("light_left").GetComponent<Light>().color = new Color(1f, 0f, 0f, 1f);
                    Seamoth.gameObject.FindChild("lights_parent").FindChild("light_right").GetComponent<Light>().color = new Color(1f, 0f, 0f, 1f);
                    EmergencyTime = startTime;
                    EmergencyInstance = Seamoth;
}catch(Exception){}
            }
        }
    })
    .WithOnModuleRemoved((Vehicle vehicleInstance, int slotId) => {
        vehicleInstance.forwardForce = Forward;
        vehicleInstance.sidewardForce = Side;
        vehicleInstance.enginePowerRating = 1f;
    });
        SeamothPrefab.SetEquipment(EquipmentType.SeamothModule);
        SeamothPrefab.Register();
    }
    static float EmergencyTime;
    static SeaMoth? EmergencyInstance;
    static bool Emergency = false;

    [HarmonyPostfix]
    public static void Postfix(SeaMoth __instance)
    {
        if((Time.time < EmergencyTime) && EmergencyInstance == __instance)
        {
            __instance.forwardForce = Forward*2f;
            __instance.sidewardForce = Side*1.6f;
            __instance.enginePowerRating = 1/8.12f;
                try{
                    __instance.volumeticLights[0].color = new Color(1f, 0f, 0f, 1f);
                    __instance.volumeticLights[1].color = new Color(1f, 0f, 0f, 1f);
                    __instance.gameObject.FindChild("lights_parent").FindChild("light_left").GetComponent<Light>().color = new Color(1f, 0f, 0f, 1f);
                    __instance.gameObject.FindChild("lights_parent").FindChild("light_right").GetComponent<Light>().color = new Color(1f, 0f, 0f, 1f);
                }catch (Exception) { }
        }
        else if(Emergency &&!((Time.time < EmergencyTime) && EmergencyInstance == __instance))
        { 

        }
    }
}

//Archive Code snippets
/*
            SeaMoth Seamoth = (SeaMoth)vehicleInstance;
            var startTime = Time.time;
            //while (Time.time < (startTime + 13f))
            {
                Subtitles.Add("Seamoth forward Speed now 2.0x");
                vehicleInstance.forwardForce = Forward*2f;
                Subtitles.Add("Seamoth sideways Speed now 1.6x");
                vehicleInstance.sidewardForce = Side*1.6f;
                vehicleInstance.enginePowerRating = 1/8.12f;

                if (Seamoth)
                {
try{
                    Seamoth.volumeticLights[0].color = new Color(1f, 0f, 0f, 1f);
                    Seamoth.volumeticLights[1].color = new Color(1f, 0f, 0f, 1f);
                    Seamoth.gameObject.FindChild("lights_parent").FindChild("light_left").GetComponent<Light>().color = new Color(1f, 0f, 0f, 1f);
                    Seamoth.gameObject.FindChild("lights_parent").FindChild("light_right").GetComponent<Light>().color = new Color(1f, 0f, 0f, 1f);
}catch(Exception){}
                }
            }
        })
        .WithOnModuleRemoved((Vehicle vehicleInstance, int slotId) => {
            vehicleInstance.forwardForce = Forward;
            vehicleInstance.sidewardForce = Side;
            vehicleInstance.enginePowerRating = 1f;
        });
*/