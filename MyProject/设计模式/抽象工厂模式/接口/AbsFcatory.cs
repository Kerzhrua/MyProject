using MyProject.抽象工厂.产品;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyProject
{
    interface AbsFcatory
    {
        product CreateProduct(string orderType);

    }
}
