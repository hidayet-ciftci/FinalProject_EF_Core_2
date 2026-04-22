using Castle.DynamicProxy;
using IInterceptor = Castle.DynamicProxy.IInterceptor;

namespace Core.Utilities.Interceptors
{
    public partial class Class1
    {
        [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
        public abstract class MethodInterceptionBaseAttribute : Attribute, IInterceptor
        {
            public int Priority { get; set; }

            public virtual void Intercept(IInvocation invocation)
            {

            }

            // Intercept castle.dynamicProxy'den gelen kesici , yani func çalışmadan önce devreye girmesini saglar
            // invocation ise func'in tum bilgilerini tutar.
            // Priority ise bir den fazla attribute kullanımı durumunda oncelik saglar
        }
    }


}
