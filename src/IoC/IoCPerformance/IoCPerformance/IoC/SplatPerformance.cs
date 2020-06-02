using IoCPerformance.IoC.Base;
using IoCPerformance.Services.Test;
using Splat;

namespace IoCPerformance.IoC
{
    public class SplatPerformance : IPerformance
    {
        private readonly int _numberOfTests;

        private IMutableDependencyResolver _mutableContainer { get; set; }

        private IReadonlyDependencyResolver _container { get; set; }

        public SplatPerformance(int numberOfTests)
        {
            _numberOfTests = numberOfTests;
            _mutableContainer = Locator.CurrentMutable;
            _container = Locator.Current;
        }

        public void Registration()
        {
            for (int i = 0; i < _numberOfTests + 1; i++)
            {
                _mutableContainer.Register(() => new TestService(), contract: $"Class{i}");
            }
        }

        public void FirstResolve()
        {
            _container.GetService<TestService>($"Class0");
        }

        public void Resolve()
        {
            for (int i = 1; i < _numberOfTests + 1; i++)
            {
                _container.GetService<TestService>($"Class{i}");
            }
        }
    }
}