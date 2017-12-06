using System;
using System.Net;
using System.Collections.Generic;
using Newtonsoft.Json;
namespace Week9PrismExampleApp.Models
{
    public static class PokemonItemModel
    {
        // To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
       //
       //    using QuickType;
       //
       //    var data = PokemonItem.FromJson(jsonString);
       //


        public partial class PokemonItem
        {
            [JsonProperty("abilities")]
            public Ability[] Abilities { get; set; }

            [JsonProperty("base_experience")]
            public long BaseExperience { get; set; }

            [JsonProperty("forms")]
            public Form[] Forms { get; set; }

            [JsonProperty("game_indices")]
            public GameIndex[] GameIndices { get; set; }

            [JsonProperty("height")]
            public long Height { get; set; }

            [JsonProperty("held_items")]
            public object[] HeldItems { get; set; }

            [JsonProperty("id")]
            public long Id { get; set; }

            [JsonProperty("is_default")]
            public bool IsDefault { get; set; }

            [JsonProperty("location_area_encounters")]
            public string LocationAreaEncounters { get; set; }

            [JsonProperty("moves")]
            public Move[] Moves { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("order")]
            public long Order { get; set; }

            [JsonProperty("species")]
            public Form Species { get; set; }

            [JsonProperty("sprites")]
            public Sprites Sprites { get; set; }

            [JsonProperty("stats")]
            public Stat[] Stats { get; set; }

            [JsonProperty("types")]
            public PurpleType[] Types { get; set; }

            [JsonProperty("weight")]
            public long Weight { get; set; }
        }

        public partial class PurpleType
        {
            [JsonProperty("slot")]
            public long Slot { get; set; }

            [JsonProperty("type")]
            public Form Type { get; set; }
        }

        public partial class Stat
        {
            [JsonProperty("base_stat")]
            public long BaseStat { get; set; }

            [JsonProperty("effort")]
            public long Effort { get; set; }

            [JsonProperty("stat")]
            public Form PurpleStat { get; set; }
        }

        public partial class Sprites
        {
            [JsonProperty("back_default")]
            public string BackDefault { get; set; }

            [JsonProperty("back_female")]
            public object BackFemale { get; set; }

            [JsonProperty("back_shiny")]
            public string BackShiny { get; set; }

            [JsonProperty("back_shiny_female")]
            public object BackShinyFemale { get; set; }

            [JsonProperty("front_default")]
            public string FrontDefault { get; set; }

            [JsonProperty("front_female")]
            public object FrontFemale { get; set; }

            [JsonProperty("front_shiny")]
            public string FrontShiny { get; set; }

            [JsonProperty("front_shiny_female")]
            public object FrontShinyFemale { get; set; }
        }

        public partial class Move
        {
            [JsonProperty("move")]
            public Form PurpleMove { get; set; }

            [JsonProperty("version_group_details")]
            public VersionGroupDetail[] VersionGroupDetails { get; set; }
        }

        public partial class VersionGroupDetail
        {
            [JsonProperty("level_learned_at")]
            public long LevelLearnedAt { get; set; }

            [JsonProperty("move_learn_method")]
            public Form MoveLearnMethod { get; set; }

            [JsonProperty("version_group")]
            public Form VersionGroup { get; set; }
        }

        public partial class GameIndex
        {
            [JsonProperty("game_index")]
            public long PurpleGameIndex { get; set; }

            [JsonProperty("version")]
            public Form Version { get; set; }
        }

        public partial class Ability
        {
            [JsonProperty("is_hidden")]
            public bool IsHidden { get; set; }

            [JsonProperty("ability")]
            public Form PurpleAbility { get; set; }

            [JsonProperty("slot")]
            public long Slot { get; set; }
        }

        public partial class Form
        {
            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("url")]
            public string Url { get; set; }
        }

        public partial class PokemonItem
        {
            public static PokemonItem FromJson(string json) => JsonConvert.DeserializeObject<PokemonItem>(json, Converter.Settings);
        }


        public static string ToJson(this PokemonItem self) => JsonConvert.SerializeObject(self, Converter.Settings);


        public class Converter
        {
            public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
            {
                MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
                DateParseHandling = DateParseHandling.None,
            };
        }
    }

    }

