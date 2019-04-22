using AppFocGenova.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AppFocGenova.Interface
{
    public interface IFocacBookRepository
    {
        List<FocaccePost> GetAllPost();
        void AddItem(FocaccePost focaccePost);
        void DeleteItem(FocaccePost focaccePost);
    }
}
