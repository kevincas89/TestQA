namespace DemoSite.DTO
{
    public abstract class TextBoxDTO
    {
        public abstract string FullName { get; }
        public abstract string Email { get; }
        public abstract string CurrentAddress { get; }
        public abstract string PermanentAddress { get; }

        
        public static class Profiles
        {
            public static TextBoxDTO Default => new TextBoxDefaultDTO();
            public static TextBoxDTO SpecialChars => new TextBoxSpecialCharsDTO();
            public static TextBoxDTO Invalid => new TextBoxInvalidDTO();
            public static TextBoxDTO Empty => new TextBoxEmptyDTO();
        }
    }

    
    public class TextBoxDefaultDTO : TextBoxDTO
    {
        public override string FullName => "Test User";
        public override string Email => "test@test.com";
        public override string CurrentAddress => "123 Main St, Anytown, USA";
        public override string PermanentAddress => "456 Elm St, Othertown, USA";
    }

    
    public class TextBoxSpecialCharsDTO : TextBoxDTO
    {
        public override string FullName => "Tëst Üser @#$";
        public override string Email => "test+special@test.com";
        public override string CurrentAddress => "123 Ñoño St & Ave.";
        public override string PermanentAddress => "456 <Elm> St \"Quoted\"";
    }

    
    public class TextBoxInvalidDTO : TextBoxDTO
    {
        public override string FullName => "123456";
        public override string Email => "not-an-email";
        public override string CurrentAddress => "";
        public override string PermanentAddress => "";
    }

    
    public class TextBoxEmptyDTO : TextBoxDTO
    {
        public override string FullName => "";
        public override string Email => "";
        public override string CurrentAddress => "";
        public override string PermanentAddress => "";
    }
}