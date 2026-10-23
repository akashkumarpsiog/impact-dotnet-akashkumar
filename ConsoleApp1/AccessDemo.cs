using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement
{
    public class AccessDemo
    {
        public string PublicValue = "public"; //anywhere
        private string PrivateValue = "Private"; // only within type
        protected string ProtectedValue = "protected"; // with contained type and its derived type
        internal string InternalValue = "internal"; // within same assembly
        protected internal string ProtectedInternalValue = "Protected internal"; // same assembly or a derived type in another assembly
        private protected string PrivateProtectedValue = "Private Protected"; // same assembly AND derived type

        public void ShowInsideClass()
        {
            Console.WriteLine(PrivateValue);
        }
    }

    public class ChildAccessDemo : AccessDemo
    {
        public void ShowInheritedMembers()
        {
            Console.WriteLine(PublicValue);
            Console.WriteLine(ProtectedValue);
            Console.WriteLine(InternalValue);
            Console.WriteLine(PrivateProtectedValue);
            Console.WriteLine(ProtectedInternalValue);
            //Console.WriteLine(PrivateValue); not allowed
        }
    }
}
