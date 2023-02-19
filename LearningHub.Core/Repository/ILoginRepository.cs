using LearningHub.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace LearningHub.Core.Repository
{
    public interface ILoginRepository
    {
        List<ApiLogin> GetAllLogin();
        ApiLogin GetLoginById(int id);
        void CreateLogin(ApiLogin apiLogin);
        void UpdateLogin(ApiLogin apiLogin);
        void DeleteLogin(int id);
    }
}
