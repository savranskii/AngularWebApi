using System.Text.Json.Serialization;

namespace AngularWebApi.Application.DTOs;

public record ProvinceDto(
    [property: JsonPropertyName("id")] int Id,
    [property: JsonPropertyName("name")] string Name
);