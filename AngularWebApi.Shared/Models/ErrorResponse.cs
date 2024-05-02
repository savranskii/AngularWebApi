namespace AngularWebApi.Application.Models;

public record ErrorResponse(
    int Status,
    string Title,
    string Detail,
    string Instance);