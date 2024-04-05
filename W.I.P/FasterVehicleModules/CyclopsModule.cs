using Nautilus.Assets;
using Nautilus.Assets.Gadgets;
using Nautilus.Assets.PrefabTemplates;
using HarmonyLib;

//SetVehicleUpgradeModule will not work with cyclops!
[HarmonyPatch(typeof(SubRoot), nameof(SubRoot.SetCyclopsUpgrades))]
public class CyclopsSpeed
{
    // To access the TechType anywhere in the project
    public static PrefabInfo Info { get; private set; }

    static TechType SpeedModule1;
    static TechType SpeedModuleP1;
    static TechType SpeedModuleP2;
    static TechType SpeedModulePM;
    static TechType SpeedModule2;
    static TechType SpeedModule3;

    public static void Register()
    {
        Info = PrefabInfo.WithTechType("CyclopsSpeedModule1", "Cyclops Speed module MK1", "Enchances the Cyclops forward speed by 1.6x.")
        .WithIcon(SpriteManager.Get(TechType.Cyclops));
        var CyclopsPrefab = new CustomPrefab(Info);
        SpeedModule1 = Info.TechType;

        var CyclopsObj = new CloneTemplate(Info, TechType.CyclopsThermalReactorModule);
        CyclopsPrefab.SetGameObject(CyclopsObj);
        CyclopsPrefab.SetRecipe(new Nautilus.Crafting.RecipeData()
        {
            craftAmount = 1,
            Ingredients = new List<CraftData.Ingredient>()
            {
                new CraftData.Ingredient(TechType.Titanium, 3),
                new CraftData.Ingredient(TechType.AdvancedWiringKit, 3)
            }
        })
        .WithFabricatorType(CraftTree.Type.CyclopsFabricator)
        .WithStepsToFabricatorTab("VanillaCyclopsFabricator")
        .WithCraftingTime(6.12f);
        CyclopsPrefab.SetEquipment(EquipmentType.CyclopsModule);
        CyclopsPrefab.Register();
        Info = PrefabInfo.WithTechType("CyclopsSpeedModuleP1", "Cyclops Speed module PeeperMK1", "Enchances the Cyclops speed by 1.2x.\nReal forward speed is 1.25x, Real turn speed is 1.2x\nTrains and uses Peepers to help haul the Cyclops without using more power.\n\nDon't worry, the 2 Peepers are fine with hauling the cyclops, it's very heavy for two though.")
        .WithIcon(SpriteManager.Get(TechType.Peeper));
        CyclopsPrefab = new CustomPrefab(Info);
        SpeedModuleP1 = Info.TechType;
        CyclopsObj = new CloneTemplate(Info, TechType.CyclopsThermalReactorModule);
        CyclopsPrefab.SetGameObject(CyclopsObj);
        CyclopsPrefab.SetRecipe(new Nautilus.Crafting.RecipeData()
        {
            craftAmount = 1,
            Ingredients = new List<CraftData.Ingredient>()
            {
                //Don't worry, the 2 Peepers love hauling the cyclops!
                new CraftData.Ingredient(TechType.Peeper, 2),
                new CraftData.Ingredient(TechType.Titanium, 3),
                new CraftData.Ingredient(TechType.WiringKit, 3)
            }
        })
        .WithFabricatorType(CraftTree.Type.CyclopsFabricator)
        .WithStepsToFabricatorTab("VanillaCyclopsFabricator")
        .WithCraftingTime(9.32f);
        CyclopsPrefab.SetEquipment(EquipmentType.CyclopsModule);
        CyclopsPrefab.Register();

        Info = PrefabInfo.WithTechType("CyclopsSpeedModuleP2", "Cyclops Speed module PeeperMK2", "Enchances the Cyclops speed by 1.4x.\nReal forward speed is 1.4x, Real turn speed is 1.5x\nTrains and uses Peepers to help haul the Cyclops without using more power.\n\nDon't worry, the 16 Peepers like hauling the cyclops! But it's very crouded and they might start to argue.")
        .WithIcon(SpriteManager.Get(TechType.Peeper));
        SpeedModuleP2 = Info.TechType;
        CyclopsPrefab = new CustomPrefab(Info);
        CyclopsObj = new CloneTemplate(Info, TechType.CyclopsThermalReactorModule);
        CyclopsPrefab.SetGameObject(CyclopsObj);
        CyclopsPrefab.SetRecipe(new Nautilus.Crafting.RecipeData()
        {
            craftAmount = 1,
            Ingredients = new List<CraftData.Ingredient>()
            {
                new CraftData.Ingredient(SpeedModuleP1, 2),
            }
        })
        .WithFabricatorType(CraftTree.Type.CyclopsFabricator)
        .WithStepsToFabricatorTab("VanillaCyclopsFabricator")
        .WithCraftingTime(17.789f);
        CyclopsPrefab.SetEquipment(EquipmentType.CyclopsModule);
        CyclopsPrefab.Register();

        Info = PrefabInfo.WithTechType("CyclopsSpeedModule2", "Cyclops Speed module MK2", "Enchances the Cyclops speed by 2.6x.\nReal forward speed is 2.6x, Real turn speed is 2.46x")
        .WithIcon(SpriteManager.Get(TechType.Cyclops));
        SpeedModule2 = Info.TechType;
        CyclopsPrefab = new CustomPrefab(Info);
        CyclopsObj = new CloneTemplate(Info, TechType.CyclopsThermalReactorModule);
        CyclopsPrefab.SetGameObject(CyclopsObj);
        CyclopsPrefab.SetRecipe(new Nautilus.Crafting.RecipeData()
        {
            craftAmount = 1,
            Ingredients = new List<CraftData.Ingredient>()
            {
                new CraftData.Ingredient(SpeedModule1, 1),
                new CraftData.Ingredient(TechType.Titanium, 3),
                new CraftData.Ingredient(TechType.AdvancedWiringKit, 2)
            }
        })
        .WithFabricatorType(CraftTree.Type.CyclopsFabricator)
        .WithStepsToFabricatorTab("VanillaCyclopsFabricator")
        .WithCraftingTime(10.789f);
        CyclopsPrefab.SetEquipment(EquipmentType.CyclopsModule);
        CyclopsPrefab.Register();

        Info = PrefabInfo.WithTechType("CyclopsSpeedModulePM", "Cyclops Speed module PeeperMK-Max", "Enchances the Cyclops speed by 3.0x.\nReal forward speed is 3.0x, Real turn speed is 2.6x\nTrains and uses Peepers to help haul the Cyclops without using more power.\n\nDon't worry, the 16 Peepers like hauling the cyclops! But it's very crouded and they might start to argue.")
        .WithIcon(SpriteManager.Get(TechType.Peeper));
        SpeedModulePM = Info.TechType;
        CyclopsPrefab = new CustomPrefab(Info);
        CyclopsObj = new CloneTemplate(Info, TechType.CyclopsThermalReactorModule);
        CyclopsPrefab.SetGameObject(CyclopsObj);
        CyclopsPrefab.SetRecipe(new Nautilus.Crafting.RecipeData()
        {
            craftAmount = 1,
            Ingredients = new List<CraftData.Ingredient>()
            {
                //Don't worry, the 16 Peepers love hauling the cyclops!
                new CraftData.Ingredient(SpeedModuleP2, 4),
                new CraftData.Ingredient(TechType.AdvancedWiringKit, 6),
            }
        })
        .WithFabricatorType(CraftTree.Type.CyclopsFabricator)
        .WithStepsToFabricatorTab("VanillaCyclopsFabricator")
        .WithCraftingTime(17.789f);
        CyclopsPrefab.SetEquipment(EquipmentType.CyclopsModule);
        CyclopsPrefab.Register();
       
        Info = PrefabInfo.WithTechType("CyclopsSpeedModule3", "Cyclops Speed module MK3", "Enchances the Cyclops speed by 3.0x.\nReal forward speed is 3.0x, Real turn speed is 2.46x")
        .WithIcon(SpriteManager.Get(TechType.Cyclops));
        SpeedModulePM = Info.TechType;
        CyclopsPrefab = new CustomPrefab(Info);
        CyclopsObj = new CloneTemplate(Info, TechType.CyclopsThermalReactorModule);
        CyclopsPrefab.SetGameObject(CyclopsObj);
        CyclopsPrefab.SetRecipe(new Nautilus.Crafting.RecipeData()
        {
            craftAmount = 1,
            Ingredients = new List<CraftData.Ingredient>()
            {
                new CraftData.Ingredient(SpeedModule2, 1),
                new CraftData.Ingredient(TechType.PrecursorIonBattery, 2),
                new CraftData.Ingredient(TechType.UraniniteCrystal, 1)
            }
        })
        .WithFabricatorType(CraftTree.Type.CyclopsFabricator)
        .WithStepsToFabricatorTab("VanillaCyclopsFabricator")
        .WithCraftingTime(50.312612f);
        CyclopsPrefab.SetEquipment(EquipmentType.CyclopsModule);
        CyclopsPrefab.Register();
    }

    static float CyclopsSpeed0 = 4.68f;
    static float CyclopsSpeed1 = 6.27f;
    static float CyclopsSpeed2 = 7.3f;
    static float Turn = 0.75f;

    [HarmonyPostfix]
    public static void Postfix(SubRoot __instance)
    {
        try
        {
            if (__instance.upgradeConsole != null && __instance.live.IsAlive() && __instance.gameObject.GetComponent<SubControl>() != null)
            {
                SubControl Cyclops = __instance.gameObject.GetComponent<SubControl>();
                Equipment modules = __instance.upgradeConsole.modules;
                bool FoundSpeedModule = false;
                for (int i = 0; i < 6; i++)
                {
                    string slot = SubRoot.slotNames[i];
                    TechType techTypeInSlot = modules.GetTechTypeInSlot(slot);
                    if (techTypeInSlot == SpeedModuleP1)
                    {
                        if (FoundSpeedModule)
                        {
                            ErrorMessage.AddMessage("All speed modules do not stack with one of the same or different type!");
                            return;
                        }
                        Subtitles.Add("Cyclops forward Speed now 1.25x");
                        Subtitles.Add("Cyclops turning Speed now 1.2x");
                        Cyclops.cyclopsMotorMode.motorModeSpeeds[0] = CyclopsSpeed0*1.25f;
                        Cyclops.cyclopsMotorMode.motorModeSpeeds[1] = CyclopsSpeed1*1.25f;
                        Cyclops.cyclopsMotorMode.motorModeSpeeds[2] = CyclopsSpeed2*1.3f;
                        Cyclops.BaseTurningTorque = Turn*1.2f;
                        FoundSpeedModule = true;
                    }
                    else if (techTypeInSlot == SpeedModule1)
                    {
                        if (FoundSpeedModule)
                        {
                            ErrorMessage.AddMessage("All speed modules do not stack with one of the same or different type!");
                            return;
                        }
                        Subtitles.Add("Cyclops forward Speed now 1.6x");
                        Cyclops.cyclopsMotorMode.motorModeSpeeds[0] = CyclopsSpeed0;
                        Cyclops.cyclopsMotorMode.motorModeSpeeds[1] = CyclopsSpeed1*1.6f;
                        Cyclops.cyclopsMotorMode.motorModeSpeeds[2] = CyclopsSpeed2*1.6f;
                        FoundSpeedModule = true;
                    }
                    else if (techTypeInSlot == SpeedModule2)
                    {
                        if (FoundSpeedModule)
                        {
                            ErrorMessage.AddMessage("All speed modules do not stack with one of the same or different type!");
                            return;
                        }
                        Subtitles.Add("Cyclops forward Speed now 2.2x");
                        Cyclops.cyclopsMotorMode.motorModeSpeeds[0] = CyclopsSpeed0;
                        Cyclops.cyclopsMotorMode.motorModeSpeeds[1] = CyclopsSpeed1*1.6f;
                        Cyclops.cyclopsMotorMode.motorModeSpeeds[2] = CyclopsSpeed2*1.6f;
                        FoundSpeedModule = true;
                    }
                    else if (techTypeInSlot == SpeedModulePM)
                    {
                        if (FoundSpeedModule)
                        {
                            ErrorMessage.AddMessage("All speed modules do not stack with one of the same or different type!");
                            return;
                        }
                        Subtitles.Add("Cyclops forward Speed now 3.0x");
                        Subtitles.Add("Cyclops turning Speed now 2.6x");
                        Cyclops.cyclopsMotorMode.motorModeSpeeds[0] = CyclopsSpeed0*3f;
                        Cyclops.cyclopsMotorMode.motorModeSpeeds[1] = CyclopsSpeed1*3f;
                        Cyclops.cyclopsMotorMode.motorModeSpeeds[2] = CyclopsSpeed2*4f;
                        Cyclops.BaseTurningTorque = Turn*2.6f;
                        FoundSpeedModule = true;
                    }
                    else if (techTypeInSlot == SpeedModuleP2)
                    {
                        if (FoundSpeedModule)
                        {
                            ErrorMessage.AddMessage("All speed modules do not stack with one of the same or different type!");
                            return;
                        }
                        Subtitles.Add("Cyclops forward Speed now 1.4x");
                        Subtitles.Add("Cyclops turning Speed now 1.5x");
                        Cyclops.cyclopsMotorMode.motorModeSpeeds[0] = CyclopsSpeed0*1.4f;
                        Cyclops.cyclopsMotorMode.motorModeSpeeds[1] = CyclopsSpeed1*1.4f;
                        Cyclops.cyclopsMotorMode.motorModeSpeeds[2] = CyclopsSpeed2*1.4f;
                        Cyclops.BaseTurningTorque = Turn*1.5f;
                        FoundSpeedModule = true;
                    }
                    else if (techTypeInSlot == SpeedModule2)
                    {
                        if (FoundSpeedModule)
                        {
                            ErrorMessage.AddMessage("All speed modules do not stack with one of the same or different type!");
                            return;
                        }
                        Subtitles.Add("Cyclops forward Speed now 2.6x");
                        Subtitles.Add("Cyclops turning Speed now 2.46x");
                        Cyclops.cyclopsMotorMode.motorModeSpeeds[0] = CyclopsSpeed1;
                        Cyclops.cyclopsMotorMode.motorModeSpeeds[1] = CyclopsSpeed1*2.6f;
                        Cyclops.cyclopsMotorMode.motorModeSpeeds[2] = CyclopsSpeed2*2.6f;
                        Cyclops.BaseTurningTorque = Turn*2.46f;
                        FoundSpeedModule = true;
                    }
                    else if (techTypeInSlot == SpeedModule2)
                    {
                        if (FoundSpeedModule)
                        {
                            ErrorMessage.AddMessage("All speed modules do not stack with one of the same or different type!");
                            return;
                        }
                        Subtitles.Add("Cyclops forward Speed now 2.6x");
                        Subtitles.Add("Cyclops turning Speed now 2.46x");
                        Cyclops.cyclopsMotorMode.motorModeSpeeds[0] = CyclopsSpeed1;
                        Cyclops.cyclopsMotorMode.motorModeSpeeds[1] = CyclopsSpeed1*2.6f;
                        Cyclops.cyclopsMotorMode.motorModeSpeeds[2] = CyclopsSpeed2*2.6f;
                        Cyclops.BaseTurningTorque = Turn*2.46f;
                        FoundSpeedModule = true;
                    }
                    else if (techTypeInSlot == SpeedModule3)
                    {
                        if (FoundSpeedModule)
                        {
                            ErrorMessage.AddMessage("All speed modules do not stack with one of the same or different type!");
                            return;
                        }
                        Subtitles.Add("Cyclops forward Speed now 3.0x");
                        Subtitles.Add("Cyclops turning Speed now 2.46x");
                        Cyclops.cyclopsMotorMode.motorModeSpeeds[0] = CyclopsSpeed1;
                        Cyclops.cyclopsMotorMode.motorModeSpeeds[1] = CyclopsSpeed1*3f;
                        Cyclops.cyclopsMotorMode.motorModeSpeeds[2] = CyclopsSpeed2*3f;
                        Cyclops.BaseTurningTorque = Turn*2.46f;
                        FoundSpeedModule = true;
                    }
                    else if (!FoundSpeedModule)
                    {
                        //Subtitles.Add("No modules");
                        Cyclops.cyclopsMotorMode.motorModeSpeeds[0] = CyclopsSpeed0;
                        Cyclops.cyclopsMotorMode.motorModeSpeeds[1] = CyclopsSpeed1;
                        Cyclops.cyclopsMotorMode.motorModeSpeeds[2] = CyclopsSpeed2;
                        Cyclops.BaseTurningTorque = Turn;
                    }
                    /*switch (techTypeInSlot)
                    {
                        case SpeedModule1:
                            __instance.shieldUpgrade = true;
                            break;
                    }*/
                }
            }
            //else
                //Subtitles.Add("Cyclops not found...");
        }
        //Just don't crash.
        catch (Exception E) { Subtitles.Add("Error: " + E.ToString()); }
    }
}


/*
using Nautilus.Assets;
using Nautilus.Assets.Gadgets;
using Nautilus.Assets.PrefabTemplates;

//Won't work correctly... We need to find out another way.
public class CyclopsSpeed
{
    // To access the TechType anywhere in the project
    public static PrefabInfo Info { get; private set; }

    public static void Register()
    {
        Info = PrefabInfo.WithTechType("CyclopsSpeedModule1", "Cyclops Speed module MK1", "Enchances the Cyclops forward speed by 0.6x.")
            .WithIcon(SpriteManager.Get(TechType.Cyclops));
        var CyclopsPrefab = new CustomPrefab(Info);

        var CyclopsObj = new CloneTemplate(Info, TechType.Cyclops);
        CyclopsPrefab.SetGameObject(CyclopsObj);
        CyclopsPrefab.SetRecipe(new Nautilus.Crafting.RecipeData()
        {
            craftAmount = 1,
            Ingredients = new List<CraftData.Ingredient>()
            {
                new CraftData.Ingredient(TechType.Titanium, 3),
                new CraftData.Ingredient(TechType.AdvancedWiringKit, 3)
            }
        })
        .WithFabricatorType(CraftTree.Type.CyclopsFabricator)
        .WithStepsToFabricatorTab("root")
        .WithCraftingTime(6.12f);
        // This first function defines the equipment type and the quick slot type.
        CyclopsPrefab.SetVehicleUpgradeModule(EquipmentType.CyclopsModule, QuickSlotType.Passive)
        .WithOnModuleAdded((Vehicle vehicleInstance, int slotId) =>
            {
                Subtitles.Add("Cyclops forward Speed now 1.6x");
                vehicleInstance.forwardForce*=1.6f;
                vehicleInstance.enginePowerRating/=1.6f;
            })
            .WithOnModuleRemoved((Vehicle vehicleInstance, int slotId) => {
                Subtitles.Add("Cyclops forward Speed now 1x");
                vehicleInstance.forwardForce/= 1.6f;
                vehicleInstance.enginePowerRating*=1.6f;
            });
        CyclopsPrefab.Register();
        Info = PrefabInfo.WithTechType("CyclopsSpeedModuleP1", "Cyclops Speed module PeeperMK1", "Enchances the Cyclops speed by 0.2x.\nReal forward speed is 1.25, Real turn speed is 1.2x\nTrains and uses Peepers to help haul the Cyclops without using more power.\n\nDon't worry, the 2 Peepers love hauling the cyclops!")
            .WithIcon(SpriteManager.Get(TechType.Peeper));
        CyclopsPrefab = new CustomPrefab(Info);

        CyclopsObj = new CloneTemplate(Info, TechType.Cyclops);
        CyclopsPrefab.SetGameObject(CyclopsObj);
        CyclopsPrefab.SetRecipe(new Nautilus.Crafting.RecipeData()
        {
            craftAmount = 1,
            Ingredients = new List<CraftData.Ingredient>()
            {
                //Don't worry, the 2 Peepers love hauling the cyclops!
                new CraftData.Ingredient(TechType.Peeper, 2),
                new CraftData.Ingredient(TechType.Titanium, 3),
                new CraftData.Ingredient(TechType.WiringKit, 3)
            }
        })
    .WithFabricatorType(CraftTree.Type.CyclopsFabricator)
    .WithStepsToFabricatorTab("root")
    .WithCraftingTime(9.32f);
        CyclopsPrefab.SetVehicleUpgradeModule(EquipmentType.CyclopsModule, QuickSlotType.Passive)
        .WithOnModuleAdded((Vehicle vehicleInstance, int slotId) =>
        {
            Subtitles.Add("Cyclops forward Speed now 1.25x");
            vehicleInstance.forwardForce*=1.25f;
            Subtitles.Add("Cyclops turn Speed now 1.2x");
            vehicleInstance.sidewardForce*=1.2f;
        })
        .WithOnModuleRemoved((Vehicle vehicleInstance, int slotId) => {
            Subtitles.Add("Cyclops forward Speed now 1x");
            vehicleInstance.forwardForce/= 1.25f;
            Subtitles.Add("Cyclops turn Speed now 1x");
            vehicleInstance.sidewardForce/=1.2f;
        });
        CyclopsPrefab.Register();

        Info = PrefabInfo.WithTechType("CyclopsSpeedModulePM", "Cyclops Speed module PeeperMK-Max", "Enchances the Cyclops speed by 3.0x.\nReal forward speed is 3.0x, Real turn speed is 2.6x\nTrains and uses Peepers to help haul the Cyclops without using more power.\n\nDon't worry, the 16 Peepers love hauling the cyclops! But it's very crouded and they might start to argue.")
            .WithIcon(SpriteManager.Get(TechType.Peeper));
        CyclopsPrefab = new CustomPrefab(Info);

        CyclopsObj = new CloneTemplate(Info, TechType.Cyclops);
        CyclopsPrefab.SetGameObject(CyclopsObj);
        CyclopsPrefab.SetRecipe(new Nautilus.Crafting.RecipeData()
        {
            craftAmount = 1,
            Ingredients = new List<CraftData.Ingredient>()
            {
                //Don't worry, the 16 Peepers love hauling the cyclops!
                new CraftData.Ingredient(TechType.Peeper, 16),
                new CraftData.Ingredient(TechType.Titanium, 5),
                new CraftData.Ingredient(TechType.WiringKit, 7)
            }
        })
    .WithFabricatorType(CraftTree.Type.CyclopsFabricator)
    .WithStepsToFabricatorTab("root")
    .WithCraftingTime(17.789f);
        CyclopsPrefab.SetVehicleUpgradeModule(EquipmentType.CyclopsModule, QuickSlotType.Passive)
        .WithOnModuleAdded((Vehicle vehicleInstance, int slotId) =>
        {
            Subtitles.Add("Cyclops forward Speed now 3.0x");
            vehicleInstance.forwardForce*=3f;
            Subtitles.Add("Cyclops turn Speed now 2.6x");
            vehicleInstance.sidewardForce*=2.6f;
        })
        .WithOnModuleRemoved((Vehicle vehicleInstance, int slotId) => {
            Subtitles.Add("Cyclops forward Speed now 3.0x");
            vehicleInstance.forwardForce/=3f;
            Subtitles.Add("Cyclops turn Speed now 2.6x");
            vehicleInstance.sidewardForce/=2.6f;
        });
        CyclopsPrefab.Register();
    }
}
*/