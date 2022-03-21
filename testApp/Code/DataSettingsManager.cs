using System;
using System.Collections.Generic;

namespace testApp.Code
{
    public sealed class DataSettingsManager
    {

        public static DataSettings Loadsettings()
        {
            if (Singleton<DataSettings>.Instance != null)
                return Singleton<DataSettings>.Instance;


            var ds = new DataSettings();
            ds.ConnectionString = "123";

            Singleton<DataSettings>.Instance = ds;

            return Singleton<DataSettings>.Instance;

        }
    }


    /// <summary>
    /// A statically compiled "singleton" used to store objects throughout the 
    /// lifetime of the app domain. Not so much singleton in the pattern's 
    /// sense of the word as a standardized way to store single instances.
    /// </summary>
    /// <typeparam name="T">The type of object to store.</typeparam>
    /// <remarks>Access to the instance is not synchronized.</remarks>
    public class Singleton<T> : BaseSingleton
    {
        private static T instance;

        /// <summary>
        /// The singleton instance for the specified type T. Only one instance (at the time) of this object for each type of T.
        /// </summary>
        public static T Instance
        {
            get => instance;
            set
            {
                instance = value;
                AllSingletons[typeof(T)] = value;
            }
        }
    }


    /// <summary>
    /// Provides access to all "singletons" stored by <see cref="Singleton{T}"/>.
    /// </summary>
    public class BaseSingleton
    {
        static BaseSingleton()
        {
            AllSingletons = new Dictionary<Type, object>();
        }

        /// <summary>
        /// Dictionary of type to singleton instances.
        /// </summary>
        public static IDictionary<Type, object> AllSingletons { get; }
    }



}
