using System.Configuration;
using System.Data.SqlClient;
using System.Web.Mvc;
using Dapper;
using System.Collections.Generic;
using System.Web.Configuration;
using System.Linq;
using System;
using System.Web.Services.Description;
using coding_test_todolist.Models;

namespace coding_test_todolist.Controllers
{
    public class LoginController : Controller
    {
        private RegisterUsers _registerUsers;

        public LoginController()
        {
            _registerUsers = new RegisterUsers();
        }

        // Método GET para renderizar a página de login
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        // Método POST para processar o login
        [HttpPost]
        public ActionResult Login(string Username, string Password)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Consulta o usuário no banco de dados
                var query = "SELECT * FROM Users WHERE Username = @Username";
                var user = connection.QueryFirstOrDefault<Users>(query, new { Username });

                // Verifica se o usuário existe e a senha está correta
                if (user != null && user.PasswordHash == Password)
                {
                    Session["UserId"] = user.Id;
                    Session["Username"] = user.Username;

                    TempData["UserName"] = user.Username;
                    TempData["SuccessMessage"] = "Você está logado com sucesso!";

                    return RedirectToAction("Index", "Login");
                }
            }

            TempData["ErrorMessage"] = "Usuário ou senha inválidos!";
            return View();
        }

        // Método para renderizar a página de registro
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        // Método para processar o cadastro
        [HttpPost]
        public ActionResult Register(string NewUsername, string NewPassword)
        {
            if (_registerUsers.IsUsernameExists(NewUsername))
            {
                TempData["ErrorMessage"] = "Nome de usuário já está em uso. Por favor, escolha outro.";
                return View("Login");
            }

            _registerUsers.RegisterNewUser(NewUsername, NewPassword);

            TempData["SuccessMessage"] = "Usuário cadastrado com sucesso! Faça login para continuar.";
            return View("Login");
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
    }
}
