using AppFocGenova.Interface;
using AppFocGenova.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace AppFocacBook
{
    public class FocacBookRepository: IFocacBookRepository
    {

        private List<FocaccePost> mListaFocaccePost = new List<FocaccePost>();

        public FocacBookRepository()
        {
            mListaFocaccePost.Add(new FocaccePost() { Id = Guid.NewGuid().ToString(),
                NomeUtente = "gptucci",
                Luogo = "Genova, Focacceria XYZ",
                DataOra = DateTime.Now,
                Voto=5
            });


    }


        public List<FocaccePost> GetAllPost()
        {
            return mListaFocaccePost;
        }
        public void AddItem(FocaccePost focaccePost)
        {
            
            focaccePost.Id = Guid.NewGuid().ToString();
            mListaFocaccePost.Add(focaccePost); 
        }

        public void DeleteItem(FocaccePost focaccePost)
        {
            mListaFocaccePost.Remove(focaccePost);
        }
    }
}
