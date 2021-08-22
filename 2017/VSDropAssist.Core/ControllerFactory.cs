using System;
using System.Collections.Generic;

namespace VSDropAssist.Core
{
    public class ControllerFactory : IControllerFactory
    {
        private readonly IViewFactory _viewFactory;
        private readonly IDictionary<Type, Func<IViewFactory, IController>> _controllers;

        public ControllerFactory(IViewFactory viewFactory, IDictionary<Type, Func<IViewFactory, IController >> controllers )
        {
            _viewFactory = viewFactory;
            _controllers = controllers;
        }

        public T Create<T>() where T : IController
        {
            // find the requested controller
            if(!_controllers.ContainsKey(typeof(T)))
                throw new ArgumentOutOfRangeException("T", typeof(T), "Controller Type not registered");
            var f = _controllers[typeof (T)];

            return (T)f(_viewFactory);
        }
    }
}