
namespace System
{
    public class Type
    {
        internal Type(string fullName)
        {
            FullName = fullName;
        }

        //public static Type GetTypeFromHandle(RuntimeTypeHandle handle)
        //{
        //    return new Type();
        //}

        public string FullName { get; private set; }
    }
}


