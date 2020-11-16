using System;
using System.IO;
using FlexBackendLessen.Migrations;

namespace FlexBackendLessen.Models
{
    public interface ICar
    {
        void Start();
        void Stop();
    }

    public class Car : ICar
    {
        private IEngine _engine;

        public Car(IEngine engine)
        {
            _engine = engine;
        }

        public void Start()
        {
            _engine.Start();
        }

        public void Stop()
        {
            _engine.Stop();
        }
    }

    public interface IMyLogger
    {
        void Log(string message);
    }

    public class MyLogger : IMyLogger
    {
        public string Name = "MyLogger";

        public void Log(string message)
        {
            Console.WriteLine(message);
        }
    }

    public class DatabaseLogger : IMyLogger
    {
        public string Name = "DbLogger";

        public void Log(string message)
        {
            Console.WriteLine($"DB: {message}");
            //write log to database
        }
    }

    public interface IEngine
    {
        void Start();
        void Stop();
    }

    public class Engine : IEngine
    {
        private IMyLogger _logger;

        private int _startCount { get; set; }

        public Engine(IMyLogger logger)
        {
            _logger = logger;
        }

        public void Start()
        {
            _startCount++;

            _logger.Log("Engine Started!");
        }

        public void Stop()
        {
            _logger.Log("Engine Stopped!");
        }
    }

    // public class MyDependencyInjector
    // {
    //     Add(Type @interface, Type concreteType)
    //     {
    //
    //     }
    //
    //     public void Initial()
    //     {
    //
    //     }
    //
    //     public T Create<T>(Type t)
    //     {
    //
    //     }
    //
    //     public static Object  CreateCar()
    //     {
    //         new MyDependencyInjector().Create<Car>();
    //     }
    // }

}
