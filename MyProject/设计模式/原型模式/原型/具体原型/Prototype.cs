using MyProject.设计模式.原型模式.原型接口;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace MyProject.设计模式.原型模式.原型.具体原型
{
    [Serializable]
    class Prototype : IPrototype
    {
        public object DeepClone()
        {
            MemoryStream ms = new MemoryStream();
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(ms, this);
            ms.Seek(0, 0);
            object obj = bf.Deserialize(ms);
            ms.Close();
            return obj;
        }

        public object ShallowClone()
        {
            return this.MemberwiseClone();
        }
    }
}
