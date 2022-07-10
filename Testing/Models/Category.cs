namespace Testing.Models
{
    public class Category
    {
        public int CategoryID { get; set; }
        public string Name { get; set; }
        public int DepartmentID { get; set; }

        public Category(int categoryID, string name, int departmentID )
        {
            CategoryID = categoryID;
            Name = name;
            DepartmentID = departmentID;
        }

    }
}
