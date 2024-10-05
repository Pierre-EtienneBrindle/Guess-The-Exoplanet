using UnityEngine;

namespace SingletonBehavior
{
    //Inspired from https://gist.github.com/rickyah/271e3aa31ff8079365bc 

    /// <summary>
    /// An abstract class that makes its children Singletons
    /// </summary>
    /// <typeparam name="T">The type of the child class</typeparam>
    public abstract class SingletonMonobehavior<T> : MonoBehaviour where T : SingletonMonobehavior<T>
    {
        [Header("Singleton Variables")]

        [SerializeField] bool isPersistant = false;
        [SerializeField] bool shouldPrintLogs = true;


        static T instance = null;

        /// <summary>
        /// The instance of the Singleton
        /// </summary>
        public static T Instance
        {
            get
            {
                if (instance == null)
                    CheckForInstance();

                return instance;
            }
        }

        /// <summary>
        /// Checks the scene to find if there are any active Object
        /// </summary>
        private static void CheckForInstance()
        {
            Object temp = FindObjectOfType(typeof(T));
            instance = (T)temp;
        }

        /// <summary>
        /// Unity's awake function
        /// </summary>
        /// <remarks>You ABSOLUTELY need to write base.Awake() at the start when overriding</remarks>
        protected virtual void Awake()
        {
            if (instance != null && instance != this)
            {
                TryPrintLogs($"Destroyed a copy of Singleton {typeof(T)}");
                Destroy(this);
                return;
            }

            instance = (T)this;

            if (isPersistant)
                DontDestroyOnLoad(this);
        }

        /// <summary>
        /// Unity's OnDestroy function
        /// </summary>
        /// <remarks>You ABSOLUTELY need to write base.Awake() at the start when overriding</remarks>
        protected virtual void OnDestroy()
        {
            //If it's a clone, do nothing
            if (instance != this)
                return;

            TryPrintLogs($"Destroyed Singleton of type {typeof(T)}");
        }

        /// <summary>
        /// Prints the log if we want to
        /// </summary>
        /// <param name="message">The message to log</param>
        void TryPrintLogs(object message)
        {
            if (shouldPrintLogs)
                print(message);
        }
    }
}