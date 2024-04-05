using Nautilus.Assets.PrefabTemplates;
using Nautilus.Assets;
using Nautilus.Assets.Gadgets;

namespace FasterVehicleModules
{
    internal class ExoSuitUpgrade
    {
        // To access the TechType anywhere in the project
        public static PrefabInfo Info { get; private set; }
        static float Forward = 8.2f;
        static float Backward = 3f;
        static float Side = 4.2f;
        static float Vertical = 2f;
        static float Ground = 4f;
        static float Thrust = 0.8534355f;
        static float ThrustPowerUsage = 0.09f;
        public static void Register()
        {
            Info = PrefabInfo.WithTechType("ExoSuitSpeedModule1", "Prawn Suit Speed module MK1", "Enchances the Prawn Suit forward speed by 1.7x.")
                .WithIcon(SpriteManager.Get(TechType.Exosuit));
            var ExoSuitPrefab = new CustomPrefab(Info);

            var ExoSuitObj = new CloneTemplate(Info, TechType.VehiclePowerUpgradeModule);
            ExoSuitPrefab.SetGameObject(ExoSuitObj);
            ExoSuitPrefab.SetRecipe(new Nautilus.Crafting.RecipeData()
            {
                craftAmount = 1,
                Ingredients = new List<CraftData.Ingredient>()
            {
                new CraftData.Ingredient(TechType.Titanium, 3),
                new CraftData.Ingredient(TechType.AdvancedWiringKit, 3)
            }
            })
            .WithFabricatorType(CraftTree.Type.SeamothUpgrades)
            .WithStepsToFabricatorTab("ExosuitModules")
            .WithCraftingTime(6.12f);
            // This first function defines the equipment type and the quick slot type.
            ExoSuitPrefab.SetVehicleUpgradeModule(EquipmentType.ExosuitModule, QuickSlotType.Passive)
            .WithOnModuleAdded((Vehicle vehicleInstance, int slotId) =>
            {
                Subtitles.Add("Prawn Suit forward Speed now 1.7x");
                vehicleInstance.forwardForce = Forward * 1.7f;
                vehicleInstance.enginePowerRating = 1/1.7f;
            })
            .WithOnModuleRemoved((Vehicle vehicleInstance, int slotId) => {
                Subtitles.Add("Prawn Suit forward Speed now 1x");
                vehicleInstance.forwardForce = Forward;
                vehicleInstance.enginePowerRating = 1f;
            });
            ExoSuitPrefab.Register();
            TechType oldInfo = Info.TechType;

            Info = PrefabInfo.WithTechType("ExoSuitSpeedModule2", "Prawn Suit Speed module MK2", "Enchances the Prawn Suit forward speed by 2.8x.")
                .WithIcon(SpriteManager.Get(TechType.Exosuit));
            ExoSuitPrefab = new CustomPrefab(Info);

            ExoSuitObj = new CloneTemplate(Info, TechType.VehiclePowerUpgradeModule);
            ExoSuitPrefab.SetGameObject(ExoSuitObj);
            ExoSuitPrefab.SetRecipe(new Nautilus.Crafting.RecipeData()
            {
                craftAmount = 1,
                Ingredients = new List<CraftData.Ingredient>()
            {
                new CraftData.Ingredient(oldInfo, 1),
                new CraftData.Ingredient(TechType.AdvancedWiringKit, 3),
                new CraftData.Ingredient(TechType.Battery, 1)
            }
            })
            .WithFabricatorType(CraftTree.Type.SeamothUpgrades)
            .WithStepsToFabricatorTab("ExosuitModules")
            .WithCraftingTime(12.62f);
            // This first function defines the equipment type and the quick slot type.
            ExoSuitPrefab.SetVehicleUpgradeModule(EquipmentType.ExosuitModule, QuickSlotType.Passive)
            .WithOnModuleAdded((Vehicle vehicleInstance, int slotId) =>
            {
                Subtitles.Add("Prawn Suit forward Speed now 2.8x");
                vehicleInstance.forwardForce = Forward * 2.8f;
                vehicleInstance.enginePowerRating = 1/2.8f;
            })
            .WithOnModuleRemoved((Vehicle vehicleInstance, int slotId) => {
                Subtitles.Add("Prawn Suit forward Speed now 1x");
                vehicleInstance.forwardForce = Forward;
                vehicleInstance.enginePowerRating = 1f;
            });
            ExoSuitPrefab.Register();

            /*Info = PrefabInfo.WithTechType("ExoSuitSuperThruster", "Prawn Suit super jet upgrade", "Enchances the Prawn Suit jet power by 4.8x.")
                .WithIcon(SpriteManager.Get(TechType.Exosuit));
            ExoSuitPrefab = new CustomPrefab(Info);

            ExoSuitObj = new CloneTemplate(Info, TechType.VehiclePowerUpgradeModule);
            ExoSuitPrefab.SetGameObject(ExoSuitObj);
            ExoSuitPrefab.SetRecipe(new Nautilus.Crafting.RecipeData()
            {
                craftAmount = 1,
                Ingredients = new List<CraftData.Ingredient>()
            {
                new CraftData.Ingredient(TechType.Titanium, 3),
                new CraftData.Ingredient(TechType.AdvancedWiringKit, 3)
            }
            })
            .WithFabricatorType(CraftTree.Type.SeamothUpgrades)
            .WithStepsToFabricatorTab("ExosuitModules")
            .WithCraftingTime(12.62f);
            // This first function defines the equipment type and the quick slot type.
            ExoSuitPrefab.SetVehicleUpgradeModule(EquipmentType.ExosuitModule, QuickSlotType.Passive)
            .WithOnModuleAdded((Vehicle vehicleInstance, int slotId) =>
            {
                Exosuit Vehicle = (Exosuit)vehicleInstance;
                Subtitles.Add("Prawn Suit jet thruster now 4.8x");
                Vehicle.verticalForce = Vertical * 4.8f;
                Vehicle.enginePowerRating = 1/2.8f;
            })
            .WithOnModuleRemoved((Vehicle vehicleInstance, int slotId) => {
                Subtitles.Add("ExoSuit forward Speed now 1x");
                vehicleInstance.verticalForce = Forward;
                vehicleInstance.enginePowerRating = 1f;
            });
            ExoSuitPrefab.Register();*/

            Info = PrefabInfo.WithTechType("ExoSuitFlyingThruster", "Prawn Suit rocket module", "Enables the Prawn Suit to fly.\nWarning: When Prawn Suit is underwater the Prawn Suit will start to take damage because of damage to the thrusters.\nYou can upgrade this module to make it protect itself up to 40m underwater.")
                .WithIcon(SpriteManager.Get(TechType.ExosuitJetUpgradeModule));
            ExoSuitPrefab = new CustomPrefab(Info);

            ExoSuitObj = new CloneTemplate(Info, TechType.VehiclePowerUpgradeModule);
            ExoSuitPrefab.SetGameObject(ExoSuitObj);
            ExoSuitPrefab.SetRecipe(new Nautilus.Crafting.RecipeData()
            {
                craftAmount = 1,
                Ingredients = new List<CraftData.Ingredient>()
            {
                new CraftData.Ingredient(TechType.Titanium, 5),
                new CraftData.Ingredient(TechType.AdvancedWiringKit, 6),
                new CraftData.Ingredient(TechType.ReactorRod, 4)
            }
            })
            .WithFabricatorType(CraftTree.Type.SeamothUpgrades)
            .WithStepsToFabricatorTab("ExosuitModules")
            .WithCraftingTime(12.62f);
            // This first function defines the equipment type and the quick slot type.
            ExoSuitPrefab.SetVehicleUpgradeModule(EquipmentType.ExosuitModule, QuickSlotType.Passive)
            .WithOnModuleAdded((Vehicle vehicleInstance, int slotId) =>
            {
                Exosuit Vehicle = (Exosuit)vehicleInstance;
                Subtitles.Add("Prawn Suit thrusters have been replaced.");
                Vehicle.verticalForce = 12f;
                Vehicle.enginePowerRating = 1/6.78f;
                Subtitles.Add("Disabled oxygen production to save power.");
                Vehicle.replenishesOxygen = false;
                Vehicle.oxygenEnergyCost = 0f;
                vehicleInstance.crushDamage.crushDepth = 0f;
            })
            .WithOnModuleRemoved((Vehicle vehicleInstance, int slotId) => {
                Exosuit Vehicle = (Exosuit)vehicleInstance;
                Subtitles.Add("Prawn Suit thrusters are in the original state.");
                vehicleInstance.verticalForce = Vertical;
                vehicleInstance.enginePowerRating = 1f;
                Subtitles.Add("Enabled oxygen production.");
                Vehicle.replenishesOxygen = true;
                Vehicle.oxygenEnergyCost = 0.1f;
                vehicleInstance.crushDamage.crushDepth = 900f;
            }).WithDepthUpgrade(0f, true);
            ExoSuitPrefab.Register();
            oldInfo = Info.TechType;

            Info = PrefabInfo.WithTechType("ExoSuitFlyingThruster2", "Prawn Suit rocket module with underwater protection", "Enables the Prawn Suit to fly.\nWarning: When Prawn Suit is 40m underwater the Prawn Suit will start to take damage because of damage to the thrusters.")
                .WithIcon(SpriteManager.Get(TechType.ExosuitJetUpgradeModule));
            ExoSuitPrefab = new CustomPrefab(Info);

            ExoSuitObj = new CloneTemplate(Info, TechType.VehiclePowerUpgradeModule);
            ExoSuitPrefab.SetGameObject(ExoSuitObj);
            ExoSuitPrefab.SetRecipe(new Nautilus.Crafting.RecipeData()
            {
                craftAmount = 1,
                Ingredients = new List<CraftData.Ingredient>()
            {
                new CraftData.Ingredient(oldInfo, 1),
                new CraftData.Ingredient(TechType.Aerogel, 2)
            }
            })
            .WithFabricatorType(CraftTree.Type.SeamothUpgrades)
            .WithStepsToFabricatorTab("ExosuitModules")
            .WithCraftingTime(12.62f); _=oldInfo;
            // This first function defines the equipment type and the quick slot type.
            ExoSuitPrefab.SetVehicleUpgradeModule(EquipmentType.ExosuitModule, QuickSlotType.Passive)
            .WithOnModuleAdded((Vehicle vehicleInstance, int slotId) =>
            {
                Exosuit Vehicle = (Exosuit)vehicleInstance;
                Subtitles.Add("Prawn Suit thrusters have been replaced.");
                Vehicle.verticalForce = 12f;
                Vehicle.enginePowerRating = 1/8f;
                vehicleInstance.crushDamage.crushDepth = 40f;
            })
            .WithOnModuleRemoved((Vehicle vehicleInstance, int slotId) => {
                Exosuit Vehicle = (Exosuit)vehicleInstance;
                Subtitles.Add("Prawn Suit thrusters are in the original state.");
                vehicleInstance.verticalForce = Vertical;
                vehicleInstance.enginePowerRating = 1f;
                vehicleInstance.crushDamage.crushDepth = 900f;
            }).WithDepthUpgrade(40f, true);
            ExoSuitPrefab.Register();

        }
    }
}
