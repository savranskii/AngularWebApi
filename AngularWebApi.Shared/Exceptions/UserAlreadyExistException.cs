﻿namespace AngularWebApi.Application.Exceptions;

public class UserAlreadyExistException : Exception
{
    public UserAlreadyExistException()
    {
    }

    public UserAlreadyExistException(string? message) : base(message)
    {
    }

    public UserAlreadyExistException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}