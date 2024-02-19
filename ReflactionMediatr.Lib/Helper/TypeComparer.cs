namespace ReflactionMediatr.Lib.Helper
{
    /// <summary>
    /// gönderilen tip ile karşılaştırılan tip uyuşuyorsa true dön
    /// </summary>
    public static class TypeComparer
    {
        public static bool IsAssignableToGenericType(Type given, Type generic)
        {
            // gelenlerden interface ten türeyenler var mı?
            var interfaces = given.GetInterfaces();

            foreach (var i in interfaces)
            {
                if (IsGeneric(i, generic))
                    return true;
            }

            if (IsGeneric(given, generic))
                return true;

            Type baseType = given.BaseType;
            if (baseType == null) return false;

            // recursive
            return IsAssignableToGenericType(baseType,generic);
        }

        private static bool IsGeneric(Type given, Type generic)
        {
            return given.IsGenericType && given.GetGenericTypeDefinition() == generic;
        }
    }
}
