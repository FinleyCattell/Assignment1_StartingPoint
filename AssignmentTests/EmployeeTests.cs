using Assignment;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AssignmentTests
{
    [TestClass]
    public class EmployeeTests
    {
        [TestMethod]
        public void CreateEmployee_WithValidName_ShouldStoreNameCorrectly()
        {
            Employee employee = new Employee("Graham");

            Assert.AreEqual("Graham", employee.EmpName);
        }

        [TestMethod]
        public void FindEmployee_WhenEmployeeExists_ShouldReturnEmployee()
        {
            EmployeeManager manager = new EmployeeManager();
            manager.AddEmployee(new Employee("Graham"));

            Employee result = manager.FindEmployee("Graham");

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void FindEmployee_WhenEmployeeDoesNotExist_ShouldReturnNull()
        {
            EmployeeManager manager = new EmployeeManager();

            Employee result = manager.FindEmployee("Alice");

            Assert.IsNull(result);
        }
    }
}
