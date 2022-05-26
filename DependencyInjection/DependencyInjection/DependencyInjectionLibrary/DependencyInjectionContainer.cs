﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjection.DependencyInjectionLibrary
{
    delegate object GetObjectDelegate(Type type); 

    internal class DependencyInjectionContainer
    {
        private Dictionary<Type, object> SingletonsDictionary = new Dictionary<Type, object>();
        private Dictionary<Type, GetObjectDelegate> GetObjectDictionary = new Dictionary<Type, GetObjectDelegate> ();
        private Dictionary<Type, ConstructorInfo> ConstructorsDictionary = new Dictionary<Type, ConstructorInfo>();
        
        //creation of singleton
        public void AddSingletonCreation<T>()
        {
            Type type = typeof(T);
            GetObjectDictionary[type] = GetSingleton;
            ConstructorsDictionary[type] = type.GetConstructors()[0];
        }

        //craetion of transient
        public void AddTransientCreation<T>()
        {
            Type type = typeof(T);
            GetObjectDictionary[type] = GetSingleton;
            ConstructorsDictionary[type] = type.GetConstructors().Single();
        }

        //creating object(or getting if singleton) by its type(class)
        public T GetObject<T>()
        {
            Type type = typeof(T);
            if(!GetObjectDictionary.ContainsKey(type))
            {
                throw new Exception("can't get such object!!!");
            }
            
            return (T)GetObjectDictionary[type](type);
        }

        //returns singleton
        private object GetSingleton(Type type)
        {
            if(!SingletonsDictionary.ContainsKey(type))
            {
                var Singleton = GetTransient(type);
                SingletonsDictionary[type] = Singleton;
            }

            return SingletonsDictionary[type];
        }

        //creating object by Type
        public object GetObjectByType(Type type)
        {
            if (!GetObjectDictionary.ContainsKey(type))
            {
                throw new Exception("can't create such object!!!");
            }

            return GetObjectDictionary[type](type);
        }

        //returns transient
        private object GetTransient(Type type)
        {
            var constructor = ConstructorsDictionary[type];
            var parametres = constructor.GetParameters();
            List<object> parametersList = new List<object>();

            foreach(var param in parametres)
            {
                parametersList.Add(this.GetObjectByType(param.ParameterType));
            }

            return constructor.Invoke(parametersList.ToArray());
        }
    }
}
