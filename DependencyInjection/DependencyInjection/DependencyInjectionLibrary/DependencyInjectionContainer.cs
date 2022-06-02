using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjection.DependencyInjectionLibrary
{
    delegate object GetObjectDelegate(Type type, List<Type> types); 

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
            GetObjectDictionary[type] = GetInstance;
            ConstructorsDictionary[type] = type.GetConstructors().Single();
        }

        //creating object(or getting if singleton) by its type(class)
        public T GetObject<T>()
        {
            List<Type> InstanseTypeList = new List<Type>();
            Type type = typeof(T);
            if(!GetObjectDictionary.ContainsKey(type))
            {
                throw new Exception("can't get such object!!!");
            }

            var instance = GetObjectDictionary[type](type, InstanseTypeList);
            InstanseTypeList.Clear();
            return (T)instance;
        }

        //returns singleton
        private object GetSingleton(Type type, List<Type> InstanseTypeList)
        {
            if(!SingletonsDictionary.ContainsKey(type))
            {
                var Singleton = GetInstance(type, InstanseTypeList);
                SingletonsDictionary[type] = Singleton;
            }

            return SingletonsDictionary[type];
        }

        //creating object by Type
        public object GetObjectByType(Type type, List<Type> InstanseTypeList)
        {
            if (!GetObjectDictionary.ContainsKey(type))
            {
                throw new Exception("can't create such object!!!");
            }

            return GetObjectDictionary[type](type, InstanseTypeList);
        }

        //returns instance
        private object GetInstance(Type type, List<Type> InstanseTypeList)
        {
            if (InstanseTypeList.Contains(type))
            {
                throw new Exception("cycle exception!!!");
            }

            InstanseTypeList.Add(type);
            var constructor = ConstructorsDictionary[type];
            var parametres = constructor.GetParameters();
            List<object> parametersList = new List<object>();

            foreach(var param in parametres)
            {
                parametersList.Add(this.GetObjectByType(param.ParameterType, InstanseTypeList));
                InstanseTypeList.Remove(param.ParameterType);
            }
            
            var instance = constructor.Invoke(parametersList.ToArray());
            return instance;
        }
    }
}
