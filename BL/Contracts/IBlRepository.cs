using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Contracts
{
    public interface IBlRepository
    {
        public List<Repository> Getall();

        public Repository GetById(int id);

        public void Createrepo(Repository repo);

        public void Updaterepo(Repository repo);
        public void Deleterepo(int id);
    }
}
