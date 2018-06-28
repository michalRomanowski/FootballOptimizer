using System;

namespace ActivationFunctions
{
    public static class CActivationFunctionProvider
    {
        public static IActivationFunction GetActivationFunction(EActivationFunctionType type)
        {
            if(type == EActivationFunctionType.Sum)
            {
                return (IActivationFunction)new CSum();
            }
            else if(type == EActivationFunctionType.Tanh)
            {
                return (IActivationFunction)new CTanh();
            }
            else if (type == EActivationFunctionType.Step)
            {
                return (IActivationFunction)new CStep();
            }

            throw new ApplicationException(type.ToString() + " is not supported.");
        }
    }
}
