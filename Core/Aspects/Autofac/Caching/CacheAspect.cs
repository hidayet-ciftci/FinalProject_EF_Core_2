using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Caching;
using Core.Utilities.Interceptors;
using Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Aspects.Autofac.Caching
{

    public class CacheAspect : MethodInterception
    {
        private int _duration;
        private ICacheManager _cacheManager;

        public CacheAspect(int duration = 60)
        {
            _duration = duration;
            _cacheManager = ServiceTool.ServiceProvider.GetService<ICacheManager>();
        }

        public override void Intercept(IInvocation invocation)
        {
            var methodName = string.Format($"{invocation.Method.ReflectedType.FullName}.{invocation.Method.Name}");
            // MethodName = "Business.Concrete.ProductManager"."GetProductById" gibi bir sey olur.
            var arguments = invocation.Arguments.ToList();
            // arguments 4,3,1,ankara ise arguments=(4,3,1,ankara) olur
            var key = $"{methodName}({string.Join(",", arguments.Select(x => x?.ToString() ?? "<Null>"))})";
            // key ise = Business.Concrete.ProductManager.GetProductById(4,3,1,ankara) olur.
            if (_cacheManager.IsAdd(key))
            { // cache'de bu key ile daha once deger eklenmis mi kontrol
                invocation.ReturnValue = _cacheManager.Get(key); // eklenmis ise Get ile cache'den edinilen degeri
                return; // invocation.ReturnValue ile dondur
            }
            invocation.Proceed(); // eger ki isAdd false gelirse Proceed ile invocation'i yani func'i calistir
            _cacheManager.Add(key, invocation.ReturnValue, _duration);
            // bu key ile invocation.returnValue ile donen degeri , duration ile cache'E kaydet
            // invocation.ReturnValue ise func'dan donen deger oluyor. İF kosulunda hic calismadigi icin biz bunu
            // sanki metod calismis gibi cache'den alip funcka yani invotaion'a return ediyoruz.
        }
    }
}
