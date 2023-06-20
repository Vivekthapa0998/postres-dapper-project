using BL.Contracts;
using DL.Contracts;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Implementations
{
    public class BlRepository : IBlRepository
    {
        private readonly IDlRepository _IDlrepo;
        public BlRepository(IDlRepository IDlrepo) 
        {
            _IDlrepo= IDlrepo;
        }
        public void Createrepo(Repository repo)
        {
            _IDlrepo.Createrepo(repo);
        }

        public void Deleterepo(int id)
        {
            _IDlrepo.Deleterepo(id);
        }

        public List<Repository> Getall()
        {
            return _IDlrepo.Getall();
        }
        
        public Repository GetById(int id)
        {
            return _IDlrepo.GetById(id);
        }

        public void Updaterepo(Repository repo)
        {
            _IDlrepo.Updaterepo(repo);
        }
    }
}
