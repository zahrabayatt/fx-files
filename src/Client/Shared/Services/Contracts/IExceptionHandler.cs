﻿namespace Functionland.FxFiles.Client.Shared.Services.Contracts;

public interface IExceptionHandler
{
    void Handle(Exception exception, IDictionary<string, object?>? parameters = null, bool showError = true);
}
