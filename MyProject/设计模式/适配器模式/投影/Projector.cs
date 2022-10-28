using MyProject.设计模式.适配器模式.实现类;
using MyProject.设计模式.适配器模式.接口;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyProject.设计模式.适配器模式.投影
{
    public class Projector<T>
    {
        public void Projection(T t)
        {
            if(t.GetType() == typeof(IVGA))
            {
                Console.WriteLine("projection start");
                IVGA v = new VGAimp();
                v = (IVGA)t;
            }
        }


    }
}
