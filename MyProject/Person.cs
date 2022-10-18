using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace MyProject
{
    [DataContract]
    class Person
    {
        [DataMember]
        internal string name;

        [DataMember]
        internal int age;
    }
}
