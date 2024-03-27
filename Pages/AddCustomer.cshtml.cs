using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace WebApplication1.Pages
{
    public class AddCustomerModel : PageModel
    {
        public Customer customer = new Customer();
        public string errorMessage = "";
        public string successMessage = "";
        DataContextDapper _dapper;
        public AddCustomerModel(IConfiguration config)
        {
            _dapper = new DataContextDapper(config);
        }
        public void OnGet()
        {
        }
        public void OnPost()
        {
            customer.Name = Request.Form["Name"];
            customer.Surname = Request.Form["Surname"];
            customer.Number = Request.Form["Number"];
            customer.Email = Request.Form["Email"];


            string sql = @"INSERT INTO ourhome.customers (
      Name,
      Surname,
      Number,
      Email
      ) VALUE (" +
        customer.Name + "," +
        customer.Surname + "," +
        customer.Number + "," +
        customer.Email
      + ");";

            if (customer.Name.Length == 0 || customer.Surname.Length == 0 || customer.Number.Length == 0 ||
                customer.Email.Length == 0)
            {
                errorMessage = "Все поля должны быть заполнены";
                return;
            }

            try
            {
                _dapper.ExecuteSql(sql);
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return;
            }

            customer.Name = ""; customer.Surname = ""; customer.Number = "";
            customer.Email = "";
            successMessage = "Вы успешно добавлены!";

            Response.Redirect("/HomePage");
        }
    }
}
