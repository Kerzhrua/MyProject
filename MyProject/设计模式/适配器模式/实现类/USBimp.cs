using MyProject.设计模式.适配器模式.接口;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyProject.设计模式.适配器模式.实现类
{
    class USBimp : IUSB
    {
        public void Show()
        {
            Console.WriteLine("IUSB");
        }
    }
}
