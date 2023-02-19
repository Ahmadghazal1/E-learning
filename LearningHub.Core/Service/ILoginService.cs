using LearningHub.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace LearningHub.Core.Service
{
    public interface ILoginService
    {
        List<ApiLogin> GetAllLogin();
        ApiLogin GetLoginById(int id);
        void CreateLogin(ApiLogin apiLogin);
        void UpdateLogin(ApiLogin apiLogin);
        void DeleteLogin(int id);
    }
}
