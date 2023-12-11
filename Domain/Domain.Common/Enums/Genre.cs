using System.Text.Json.Serialization;

namespace Domain.Common.Enums;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum Genre
{
    Rock,
    Metal,
    AlternativeAndPunk,
    RockAndRoll,
    Blues,
    Latin,
    Reggae,
    Pop,
    Soundtrack,
    EasyListening,
    HeavyMetal,
    RnBSoul,
    ElectronicaDance,
    World,
    HipHopRap,
    Alternative,
    Classical,
    Opera,
}
