using System;
using System.Collections.Generic;
using CustomPlayerEffects;
using Exiled.API.Enums;
using Exiled.API.Features;
using Exiled.API.Features.Spawn;
using Exiled.CustomItems.API;
using Exiled.CustomItems.API.Features;
using Exiled.Events.EventArgs;
using MEC;
namespace Custom500s
{
    public class SCP330 : CustomItem
    {
        public override uint Id { get; set; } = 42;
        public override string Name { get; set; } = "SCP-330";
        public override string Description { get; set; } = "Pills that give a random effect after consuming.";
        public override float Weight { get; set; } = 1f;
        public override SpawnProperties SpawnProperties { get; set; } = new SpawnProperties
        {
            DynamicSpawnPoints = new List<DynamicSpawnPoint>()
            {
                new DynamicSpawnPoint() {Chance = 100, Location = SpawnLocation.InsideLczWc},
                new DynamicSpawnPoint() {Chance = 100, Location = SpawnLocation.Inside049Armory},
                new DynamicSpawnPoint() {Chance = 100, Location = SpawnLocation.Inside914},
                new DynamicSpawnPoint() {Chance = 100, Location = SpawnLocation.InsideGr18},
                new DynamicSpawnPoint() {Chance = 100, Location = SpawnLocation.Inside173Armory},
                new DynamicSpawnPoint() {Chance = 100, Location = SpawnLocation.Inside096},
                new DynamicSpawnPoint() {Chance = 100, Location = SpawnLocation.InsideNukeArmory},
                new DynamicSpawnPoint() {Chance = 100, Location = SpawnLocation.InsideServersBottom},
                new DynamicSpawnPoint() {Chance = 100, Location = SpawnLocation.InsideLczCafe},
                new DynamicSpawnPoint() {Chance = 100, Location = SpawnLocation.Inside012Bottom},

            }
        };
        
        public List<EffectType> Effects { get; set; } = new List<EffectType>()
        {
            EffectType.Amnesia,
            EffectType.Asphyxiated,
            EffectType.Bleeding,
            EffectType.Blinded,
            EffectType.Burned,
            EffectType.Concussed,
            EffectType.Deafened,
            EffectType.Hemorrhage,
            EffectType.Invigorated,
            EffectType.Poisoned,
            EffectType.Scp207,
            EffectType.Invisible,
            EffectType.Ensnared
        };

        Random rng = new Random();

        public void OnUsingItem(UsingItemEventArgs ev)
        {
            ev.Player.ShowHint("<color=#9e0000><size=30><b>YOU HAVE USED SCP-330! A RANDOM EFFECT HAS BEEN APPLIED FOR A RANDOM AMOUNT OF TIME!</b></size></color>!", 10);
            ev.Player.EnableEffect(Effects[rng.Next(1, 14)], rng.Next(15, 31), false);
        }

        protected override void SubscribeEvents()
        {
            Exiled.Events.Handlers.Player.UsingItem += OnUsingItem;
            base.SubscribeEvents();
        }

        protected override void UnsubscribeEvents()
        {
            Exiled.Events.Handlers.Player.UsingItem -= OnUsingItem;
            base.UnsubscribeEvents();
        }

        protected override void OnPickingUp(PickingUpItemEventArgs ev)
        {
            ev.Player.ShowHint("<color=#9e0000><size=30><b>YOU HAVE PICKED UP SCP-330! USING THIS ITEM WILL GIVE YOU A RANDOM EFFECT!</b></size></color>", 10);
            base.OnPickingUp(ev);
        }

    }
}
