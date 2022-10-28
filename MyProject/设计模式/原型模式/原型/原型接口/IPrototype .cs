using System;
using System.Collections.Generic;
using System.Text;

namespace MyProject.设计模式.原型模式.原型接口
{
    interface IPrototype
    {
        public object ShallowClone();
        public object DeepClone();

    }
}
