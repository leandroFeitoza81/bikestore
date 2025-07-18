namespace BikeStore.Application.Exceptions;

public class DataBaseException(string message, Exception exception) : Exception(message, exception);