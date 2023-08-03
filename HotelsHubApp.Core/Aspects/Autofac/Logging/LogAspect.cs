using Castle.DynamicProxy;
using HotelsHubApp.Core.CrossCuttingConcerns.Logging.LogModels;
using HotelsHubApp.Core.Utilities.Interceptors;
using Serilog;

namespace HotelsHubApp.Core.Aspects.Autofac.Logging
{

    public class LogAspect : MethodInterception
    {
        protected override void OnBefore(IInvocation invocation)
        {
            var logParameters = invocation.Method.GetParameters().Select((v, i) => new LogParameter
            {
                Name = v.Name,
                Type = v.ParameterType.Name,
                Value = invocation.Arguments[i]

            }).ToList();

            var logDetail = new LogDetail
            {
                FullName = invocation.Method.DeclaringType.Name,
                MethodName = invocation.Method.Name,
                Parameters = logParameters
            };

            Log.Information("{@LogDetail}", logDetail);
        }
    }
}
