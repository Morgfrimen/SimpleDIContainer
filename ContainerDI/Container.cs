using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace ContainerDI
{
	/// <summary>
	/// Реализация простотого DI контейнера
	/// </summary>
	public sealed class Container
    {
        private static Container _container;

        private Container() { }

        public static Container GetContainer() => _container ??= new Container();

        private Dictionary<Type, object> FactoriesDictionary { get; } = new Dictionary<Type, object>();

        public void Regicter<TType,TObj>() where TObj : new() => FactoriesDictionary.Add(typeof(TType), new TObj());

        public void Regicter<TType, TObj>(TObj obj) => FactoriesDictionary.Add(typeof(TType), obj);

        public TType Resolve<TType>() where TType : class => FactoriesDictionary[typeof(TType)] as TType;

        public void ChangeRecordContainer<TType, TObj>() where TObj : new() => FactoriesDictionary[typeof(TType)] = new TObj();
        public void ChangeRecordContainer<TType, TObj>(TObj obj) => FactoriesDictionary[typeof(TType)] = obj;

        public void ClearContainer() => FactoriesDictionary.Clear();
    }
}
