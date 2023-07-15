namespace UtilityKit.Components.Nsd.Application.Shared.Delegates;
public delegate TInterface ServiceResolver<TInterface>(string key) where TInterface : class;