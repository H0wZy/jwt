namespace jwt.Models;

public record ResponseModel<T>(T? Data, string Message = "", bool Success = false);