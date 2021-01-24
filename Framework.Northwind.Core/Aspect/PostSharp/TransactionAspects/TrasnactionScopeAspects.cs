using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using PostSharp.Aspects;

namespace Framework.Northwind.Core.Aspect.PostSharp.TransactionAspects
{
    [Serializable]
    public class TrasnactionScopeAspects:OnMethodBoundaryAspect
    {
        public TrasnactionScopeAspects()
        {
            
        }

        override public void OnEntry(MethodExecutionArgs args)
        {
            ((TransactionScope)args.MethodExecutionTag).Complete();
        }

        override public void OnExit(MethodExecutionArgs args)
        {
            ((TransactionScope)args.MethodExecutionTag).Dispose();
        }
    }
}
