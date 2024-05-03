using System.Text.Json.Serialization;

namespace WebApi.Shared.DTOs;

public record ProvinceDto(
    [property: JsonPropertyName("id")] int Id,
    [property: JsonPropertyName("name")] string Name
);