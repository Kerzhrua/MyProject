using MyProject.抽象工厂.产品;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyProject.抽象工厂
{
    class AFactory : AbsFcatory
    {
        public product CreateProduct(string orderType)
        {
            product p = null;
            if ("product1".Equals(orderType))
            {
                p = new AProduct1();
            }
            else if ("product2".Equals(orderType))
            {
                p = new AProduct2();
            }
            return p;
        }

    }
}
