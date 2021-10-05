﻿using Stump.DofusProtocol.Enums;
using Stump.ORM;
using Stump.ORM.SubSonic.SQLGeneration.Schema;

namespace Stump.Server.WorldServer.Database.Items.Pets
{
    [TableName("items_pets_foods")]
    public class PetFoodRecord : IAutoGeneratedRecord
    {
        public int Id { get; set; }

        public int PetId { get; set; }

        public FoodTypeEnum FoodType { get; set; }

        public int FoodId { get; set; }

        public int FoodQuantity { get; set; }

        public EffectsEnum BoostedEffect { get; set; }

        public int BoostAmount { get; set; }
    }
}