﻿namespace BitzArt.Flux.REST;

internal interface IFluxRestSetIdEndpointOptions<TModel, TInputParameters>
    : IFluxRestSetEndpointOptions<TModel, TInputParameters>, IFluxRestSetIdEndpointOptions<TModel>
    where TModel : class
    where TInputParameters : IRequestParameters?
{
}

internal interface IFluxRestSetIdEndpointOptions<TModel>
    : IFluxRestSetEndpointOptions<TModel>
    where TModel : class
{
}
