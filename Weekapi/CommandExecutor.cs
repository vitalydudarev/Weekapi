using System;
using System.Linq;
using System.Reflection;

namespace Weekapi
{
    public static class CommandExecutor
    {
        public static void Run(string handlerName, string[] args)
        {
            try
            {
                var type = typeof(Commands);
                var targetMethod = type.GetMethod(handlerName, BindingFlags.Static | BindingFlags.Public);
                if (targetMethod == null)
                    throw new MissingMethodException(type.FullName, handlerName);

                object[] parameters = GetParameters(args, targetMethod);
                
                targetMethod.Invoke(null, parameters);
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.InnerException?.Message ?? exc.Message);
            }
        }

        private static object[] GetParameters(string[] args, MethodInfo mi)
        {
            var parametersInfo = mi.GetParameters();
            var argsCount = args.Length;
            var parametersCount = parametersInfo.Length;
            if (parametersCount == 0)
                return new object[0];

            var parameters = new object[parametersCount];

            for (int i = 0; i < argsCount; i++)
            {
                var arg = args[i];
                object value;
                
                var type = parametersInfo[i].ParameterType;
                if (type.IsArray)
                {
                    var methodInfo = typeof(CommandExecutor).GetMethod("ConvertToArray");
                    var method = methodInfo.MakeGenericMethod(type.GetElementType());
                    value = method.Invoke(null, new object[] { arg });
                }
                else
                    value = Convert.ChangeType(arg, type);

                parameters[i] = value;


            }

            var remainingParameterCount = parametersCount - argsCount;
            if (remainingParameterCount > 0)
            {
                for (int i = argsCount; i <= parametersCount - remainingParameterCount; i++)
                    parameters[i] = Type.Missing;
            }

            return parameters;
        }
        
        public static T[] ConvertToArray<T>(string str)
        {
            return str.Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries)
                .Select(s => (T) Convert.ChangeType(s, typeof(T)))
                .ToArray();
        }
    }
}