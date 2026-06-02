using DemoSite.DTO;

namespace DemoSite.Factory
{
    public static class FactoryDtoWebTables
    {
        public static DTOWebTables Default => new WebTablesDefaultDTO();
        public static DTOWebTables SpecialChars => new WebTablesSpecialCharsDTO();
        public static DTOWebTables Invalid => new WebTablesInvalidDTO();
        public static DTOWebTables Empty => new WebTablesEmptyDTO();
        public static DTOWebTables UserDelete => new WebTablesUserDelete();
        public static DTOWebTables UserSearch => new WebTablesUserSearchDTO();
        public static DTOWebTables EditUser => new WebTablesEditUserDTO();
    }

    //Data for editing a specific user
    public class WebTablesEditUserDTO : DTOWebTables
    {
        public override string FirstName => "Kevin";
        public override string LastName => "Castillo";
        public override string Email => "kevinCastillo@gmail.com";
        public override string Age => "24";
        public override string Salary => "10000";
        public override string Department => "System";
    }

    //data for deleting a specific user
    public class WebTablesUserDelete : DTOWebTables
    {
        public override string FirstName => "Cierra";
        public override string LastName => "Vega";
        public override string Email => "cierra@example.com";
        public override string Age => "39";
        public override string Salary => "10000";
        public override string Department => "Insurance";
    }

    //Data for searching a specific user
    public class WebTablesUserSearchDTO : DTOWebTables
    {
        public override string FirstName => "Kierra";
        public override string LastName => "Gentry";
        public override string Email => "kierra@example.com";
        public override string Age => "29";
        public override string Salary => "2000";
        public override string Department => "Legal";
    }

    // Data for a normal valid user
    public class WebTablesDefaultDTO : DTOWebTables
    {
        public override string FirstName => "John";
        public override string LastName => "Smith";
        public override string Email => "john.smith@test.com";
        public override string Age => "30";
        public override string Salary => "50000";
        public override string Department => "Engineering";
    }

    // Data with special characters
    public class WebTablesSpecialCharsDTO : DTOWebTables
    {
        public override string FirstName => "Jöhn @#$";
        public override string LastName => "Smïth &%";
        public override string Email => "test+special@test.com";
        public override string Age => "25";
        public override string Salary => "60000";
        public override string Department => "Depàrtment <Special>";
    }

    // Data with invalid values 
    public class WebTablesInvalidDTO : DTOWebTables
    {
        public override string FirstName => "123456";
        public override string LastName => "!@#$%";
        public override string Email => "not-an-email";
        public override string Age => "-1";
        public override string Salary => "-9999";
        public override string Department => "123!@#";
    }

    // Data with empty values
    public class WebTablesEmptyDTO : DTOWebTables
    {
        public override string FirstName => "";
        public override string LastName => "";
        public override string Email => "";
        public override string Age => "";
        public override string Salary => "";
        public override string Department => "";
    }
}