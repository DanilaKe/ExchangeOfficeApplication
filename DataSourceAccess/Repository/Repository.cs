using System.Collections.Generic;

namespace DataSourceAccess
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private IRepository<T> _repositoryImplementation;

        public Repository(IRepository<T> repositoryImplementation)
        {
            _repositoryImplementation = repositoryImplementation;
        }

        public void Dispose()
        {
            _repositoryImplementation.Dispose();
        }

        public IEnumerable<T> GetList()
        {
            return _repositoryImplementation.GetList();
        }

        public T Get(int id)
        {
            return _repositoryImplementation.Get(id);
        }

        public void Create(T item)
        {
            _repositoryImplementation.Create(item);
        }

        public void Update(T item)
        {
            _repositoryImplementation.Update(item);
        }

        public void Delete(int id)
        {
            _repositoryImplementation.Delete(id);
        }

        public void Save()
        {
            _repositoryImplementation.Save();
        }
    }
}