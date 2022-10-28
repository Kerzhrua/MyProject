using MyProject.设计模式.适配器模式.实现类;
using MyProject.设计模式.适配器模式.接口;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyProject.设计模式.适配器模式.适配器
{
    class AdaptorUSB2VGA : USBimp, IVGA
    {
        public void projection()
        {
            base.Show();
        }
    }
}
