using System.Data.SqlClient;
using System.Data;
namespace CRUDAPI.Models
{
    public class DAL
    {
        public Response GetAllEmployees(SqlConnection connection)
        {
            Response response = new Response();
            SqlDataAdapter da = new SqlDataAdapter("SELECT E.EmployeeId,E.EmployeeName,E.DepartmentId,D.DepartmentName FROM Employee E INNER JOIN Department D ON E.DepartmentId = D.DepartmentId", connection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            List<Employee> lstemployees = new List<Employee>();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Employee emp = new Employee();
                    emp.EmployeeId = Convert.ToInt32(dt.Rows[i]["EmployeeId"]);
                    emp.EmployeeName = Convert.ToString(dt.Rows[i]["EmployeeName"]);
                    emp.DepartmentId = Convert.ToInt32(dt.Rows[i]["DepartmentId"]);
                    emp.DepartmentName = Convert.ToString(dt.Rows[i]["DepartmentName"]);
                    lstemployees.Add(emp);
                }
            }
            if (lstemployees.Count > 0)
            {
                response.StatusMessage = "Data Found";
                response.ListEmployees = lstemployees;
            }
            else
            {
                response.StatusMessage = "No Data Found";
                response.ListEmployees = null;
            }
            return response;
        }

        public Response GetAllEmployeesByDepartmentId(SqlConnection connection, int departmentId)
        {
            Response response = new Response();
            SqlDataAdapter da = new SqlDataAdapter("SELECT E.EmployeeId,E.EmployeeName,E.DepartmentId,D.DepartmentName FROM Employee E INNER JOIN Department D ON E.DepartmentId = D.DepartmentId where D.DepartmentId = " + departmentId + "", connection);
            DataTable dt = new DataTable();
            List<Employee> lstemployees = new List<Employee>();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Employee emp = new Employee();
                    emp.EmployeeId = Convert.ToInt32(dt.Rows[i]["EmployeeId"]);
                    emp.EmployeeName = Convert.ToString(dt.Rows[i]["EmployeeName"]);
                    emp.DepartmentId = Convert.ToInt32(dt.Rows[i]["DepartmentId"]);
                    emp.DepartmentName = Convert.ToString(dt.Rows[i]["DepartmentName"]);
                    lstemployees.Add(emp);
                }
            }
            if (lstemployees.Count > 0)
            {
                response.StatusMessage = "Data Found";
                response.ListEmployees = lstemployees;
            }
            else
            {
                response.StatusMessage = "No Data Found";
                response.ListEmployees = null;
            }
            return response;

        }

        public Response AddEmployee(SqlConnection connection, Employee emp)
        {
            Response response = new Response();
            SqlCommand cmd = new SqlCommand("INSERT INTO Employee (EmployeeName, DepartmentId) VALUES ('" + emp.EmployeeName + "', " + emp.DepartmentId + ")", connection);
            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();
            if (i > 0)
            {
                response.StatusMessage = "Employee Added.";
            }
            else
            {
                response.StatusMessage = "No Data Inserted";
            }
            return response;
        }

        public Response UpdateEmployee(SqlConnection connection, Employee emp)
        {
            Response response = new Response();
            SqlCommand cmd = new SqlCommand("UPDATE Employee SET EmployeeName = '" + emp.EmployeeName + "', DepartmentId = " + emp.DepartmentId + " WHERE EmployeeId = " + emp.EmployeeId + "", connection);
            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();
            if (i > 0)
            {
                response.StatusMessage = "Employee Updated.";
            }
            else
            {
                response.StatusMessage = "No Data Updated";
            }
            return response;
        }

        public Response DeleteEmployee(SqlConnection connection, int Id)
        {
            Response response = new Response();
            SqlCommand cmd = new SqlCommand("DELETE FROM Employee WHERE EmployeeId = " + Id + "", connection);
            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();
            if (i > 0)
            {
                response.StatusMessage = "Employee Deleted.";
            }
            else
            {
                response.StatusMessage = "No Data Deleted";
            }
            return response;
        }

        public Response GetAllDepartments(SqlConnection connection)
        {
            Response response = new Response();
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Department", connection);
            DataTable dt = new DataTable();
            List<Department> lstDepts = new List<Department>();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Department dept = new Department();
                    dept.DepartmentId = Convert.ToInt32(dt.Rows[i]["DepartmentId"]);
                    dept.DepartmentName = Convert.ToString(dt.Rows[i]["DepartmentName"]); ;
                    lstDepts.Add(dept);
                }
            }
            if (lstDepts.Count > 0)
            {
                response.StatusMessage = "Data Found";
                response.ListDepartments = lstDepts;
            }
            else
            {
                response.StatusMessage = "No Data Found";
                response.ListEmployees = null;
            }
            return response;
        }

        public Response AddDepartment(SqlConnection connection, Department dept)
        {
            Response response = new Response();
            SqlCommand cmd = new SqlCommand("INSERT INTO Department (DepartmentName) VALUES ('" + dept.DepartmentName + "')", connection);
            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();
            if (i > 0)
            {
                response.StatusMessage = "Department Added.";
            }
            else
            {
                response.StatusMessage = "No Data Inserted";
            }
            return response;
        }

        public Response UpdateDepartment(SqlConnection connection, Department dept)
        {
            Response response = new Response();
            SqlCommand cmd = new SqlCommand("UPDATE Department SET DepartmentName = '" + dept.DepartmentName + "' WHERE DepartmentId = " + dept.DepartmentId + "", connection);
            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();
            if (i > 0)
            {
                response.StatusMessage = "Department Updated.";
            }
            else
            {
                response.StatusMessage = "No Data Updated";
            }
            return response;
        }

        public Response DeleteDepartment(SqlConnection connection, int Id)
        {
            Response response = new Response();
            SqlCommand cmd = new SqlCommand("DELETE FROM Department WHERE DepartmentId = " + Id + "", connection);
            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();
            if (i > 0)
            {
                response.StatusMessage = "Department Deleted.";
            }
            else
            {
                response.StatusMessage = "No Data Deleted";
            }
            return response;
        }
    }
}
