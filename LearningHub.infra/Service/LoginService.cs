using LearningHub.Core.Data;
using LearningHub.Core.Repository;
using LearningHub.Core.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace LearningHub.infra.Service
{
    public class LoginService : ILoginService
    {
        private readonly ILoginRepository loginRepository;

        public LoginService(ILoginRepository loginRepository)
        {
            this.loginRepository = loginRepository;
        }
        public void CreateLogin(ApiLogin apiLogin)
        {
            loginRepository.CreateLogin(apiLogin);
        }

        public void DeleteLogin(int id)
        {
            loginRepository.DeleteLogin(id);
        }

        public List<ApiLogin> GetAllLogin()
        {
            return loginRepository.GetAllLogin();
        }

        public ApiLogin GetLoginById(int id)
        {
            return loginRepository.GetLoginById(id);
        }

        public void UpdateLogin(ApiLogin apiLogin)
        {
            loginRepository.UpdateLogin(apiLogin);
        }
    }
}
