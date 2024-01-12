namespace TestMVC.Attributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true, Inherited = false)]
    public class ApiIdAttribute : Attribute
    {
        private readonly string _idName;
        private readonly bool _isDefault;
        public ApiIdAttribute(string idName, bool isDefault = false) {
            _idName = idName;
            _isDefault = isDefault;
        }

        public string IdName
        {
            get { return _idName; }
        }
        public bool IsDefault
        {
            get { return _isDefault; }
        }
    }
}
