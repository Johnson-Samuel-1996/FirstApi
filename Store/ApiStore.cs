using FirstApi.Models;

namespace FirstApi.Store
{
    public static class ApiStore
    {
        public static List<Employee> EmployeesList = new List<Employee>
            {
                new Employee { Id = 1, Name = "John",Age =35 },
                new Employee { Id = 2, Name = "Jane",Age =35},
                new Employee { Id = 3, Name = "Bob",Age =35 }
            }; 
    }
}
