﻿using IoCPerformance.IoC;
using IoCPerformance.IoC.Base;
using System;
using System.Diagnostics;
using System.Windows.Input;
using Xamarin.Forms;

namespace IoCPerformance.ViewModels
{
    public class MainViewModel : BindableObject
    {
        private string _output;
        private Stopwatch _watch;

        public int NumberOfTests { get; set; }

        public ICommand InitTestCommand => new Command(ExecuteTest);

        public string Output
        {
            get { return _output; }
            set
            {
                _output = value;
                OnPropertyChanged();
            }
        }

        private void ExecuteTest()
        {
            NumberOfTests = 5000;
            _watch = new Stopwatch();

            AutofacPerformance autofacPerformanceTest = new AutofacPerformance(NumberOfTests);
            TinyIocPerformance tinyIocPerformanceTest = new TinyIocPerformance(NumberOfTests);
            UnityPerformance unityPerformanceTest = new UnityPerformance(NumberOfTests);
            SplatPerformance splatPerformance = new SplatPerformance(NumberOfTests);
            DependencyResolver dependencyResolver = new DependencyResolver(NumberOfTests);
            NetCoreServiceProvider netCoreServiceProvider = new NetCoreServiceProvider(NumberOfTests);

            RunTests(autofacPerformanceTest, "AutoFac");
            RunTests(tinyIocPerformanceTest, "TinyIoC");
            RunTests(unityPerformanceTest, "Unity");
            RunTests(splatPerformance, "Splat");
            RunTests(dependencyResolver, "Xamarin.Forms Dependency Resolver");
            RunTests(netCoreServiceProvider, "Microsoft.Net Dependency Injection");
        }

        private void RunTests(IPerformance performanceTest, string testName)
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
            GC.WaitForPendingFinalizers();

            try
            {
                Output += string.Format("Starting performance test for {0}", testName) + Environment.NewLine;

                _watch.Start();

                performanceTest.Registration();

                Output += string.Format("Avg. IOC Registration Time for {0} tests: {1} ms", NumberOfTests, ((double)_watch.Elapsed.Milliseconds / (double)NumberOfTests).ToString()) + Environment.NewLine;

                _watch.Restart();

                performanceTest.FirstResolve();

                Output += string.Format("IOC First Resolution Time: {0} ms", _watch.Elapsed.Milliseconds.ToString()) + Environment.NewLine;

                _watch.Restart();

                performanceTest.Resolve();


                Output += string.Format("Total IOC Resolution Time for {0} tests: {1} ms", NumberOfTests, _watch.Elapsed.Milliseconds) + Environment.NewLine;
                Output += string.Format("Avg. IOC Resolution Time for {0} tests: {1} ms", NumberOfTests, ((double)_watch.Elapsed.Milliseconds / (double)NumberOfTests).ToString()) + Environment.NewLine;
            }
            finally
            {
                _watch.Stop();

                Output += string.Format("Ending performance test {0}", testName) + Environment.NewLine;
                Output += Environment.NewLine;
            }
        }
    }
}