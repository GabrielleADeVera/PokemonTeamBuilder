using System;
using Newtonsoft.Json;
using System.Net;
using System.Collections.Generic;
namespace Week9PrismExampleApp.Models
{
    public static class PokemonCharcModel
    {
        public partial class PokemonCharc
        {
            [JsonProperty("base_happiness")]
            public long BaseHappiness { get; set; }

            [JsonProperty("capture_rate")]
            public long CaptureRate { get; set; }

            [JsonProperty("color")]
            public Habitat Color { get; set; }

            [JsonProperty("egg_groups")]
            public Habitat[] EggGroups { get; set; }

            [JsonProperty("evolution_chain")]
            public EvolutionChain EvolutionChain { get; set; }

            [JsonProperty("evolves_from_species")]
            public object EvolvesFromSpecies { get; set; }

            [JsonProperty("flavor_text_entries")]
            public FlavorTextEntry[] FlavorTextEntries { get; set; }

            [JsonProperty("form_descriptions")]
            public object[] FormDescriptions { get; set; }

            [JsonProperty("forms_switchable")]
            public bool FormsSwitchable { get; set; }

            [JsonProperty("gender_rate")]
            public long GenderRate { get; set; }

            [JsonProperty("genera")]
            public Genus[] Genera { get; set; }

            [JsonProperty("generation")]
            public Habitat Generation { get; set; }

            [JsonProperty("growth_rate")]
            public Habitat GrowthRate { get; set; }

            [JsonProperty("habitat")]
            public Habitat Habitat { get; set; }

            [JsonProperty("has_gender_differences")]
            public bool HasGenderDifferences { get; set; }

            [JsonProperty("hatch_counter")]
            public long HatchCounter { get; set; }

            [JsonProperty("id")]
            public long Id { get; set; }

            [JsonProperty("is_baby")]
            public bool IsBaby { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("names")]
            public Name[] Names { get; set; }

            [JsonProperty("order")]
            public long Order { get; set; }

            [JsonProperty("pal_park_encounters")]
            public PalParkEncounter[] PalParkEncounters { get; set; }

            [JsonProperty("pokedex_numbers")]
            public PokedexNumber[] PokedexNumbers { get; set; }

            [JsonProperty("shape")]
            public Habitat Shape { get; set; }

            [JsonProperty("varieties")]
            public Variety[] Varieties { get; set; }
        }

        public partial class Variety
        {
            [JsonProperty("is_default")]
            public bool IsDefault { get; set; }

            [JsonProperty("pokemon")]
            public Habitat Pokemon { get; set; }
        }

        public partial class PokedexNumber
        {
            [JsonProperty("entry_number")]
            public long EntryNumber { get; set; }

            [JsonProperty("pokedex")]
            public Habitat Pokedex { get; set; }
        }

        public partial class PalParkEncounter
        {
            [JsonProperty("area")]
            public Habitat Area { get; set; }

            [JsonProperty("base_score")]
            public long BaseScore { get; set; }

            [JsonProperty("rate")]
            public long Rate { get; set; }
        }

        public partial class Name
        {
            [JsonProperty("language")]
            public Habitat Language { get; set; }

            [JsonProperty("name")]
            public string PurpleName { get; set; }
        }

        public partial class Genus
        {
            [JsonProperty("language")]
            public Habitat Language { get; set; }

            [JsonProperty("genus")]
            public string PurpleGenus { get; set; }
        }

        public partial class FlavorTextEntry
        {
            [JsonProperty("flavor_text")]
            public string FlavorText { get; set; }

            [JsonProperty("language")]
            public Habitat Language { get; set; }

            [JsonProperty("version")]
            public Habitat Version { get; set; }
        }

        public partial class EvolutionChain
        {
            [JsonProperty("url")]
            public string Url { get; set; }
        }

        public partial class Habitat
        {
            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("url")]
            public string Url { get; set; }
        }

        public partial class PokemonCharc
        {
            public static PokemonCharc FromJson(string json) => JsonConvert.DeserializeObject<PokemonCharc>(json, Converter.Settings);
        }

        public static string ToJson(this PokemonCharc self) => JsonConvert.SerializeObject(self, Converter.Settings);

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
