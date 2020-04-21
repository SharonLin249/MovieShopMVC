using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MovieShop.Data
{
    public class Repository<T> : IRepository<T> where T : class //base class implement IRepository
    {
        //
        protected readonly IDbSet<T> _dbSet; 
        protected MovieShopDbContext _context;
        protected Repository(MovieShopDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }
        //


        //implementation
        public virtual void Add(T entity)
        {
            _dbSet.Add(entity); //Add method from IDbSet...
        }
        public void Update(T entity)
        {
            _dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }
        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }
        public void Delete(Expression<Func<T, bool>> where)
        {
            var objects = _dbSet.Where(where).AsEnumerable();
            foreach (var obj in objects)
                _dbSet.Remove(obj);
        }
        public virtual T GetById(int id)
        {
            return _dbSet.Find(id);
        }
        public virtual T Get(Expression<Func<T, bool>> where) //goes to ur dbset, based on condition, go to db, and get
        {
            return _dbSet.Where(where).FirstOrDefault();  //where is from IQuerable 
            //var test = new List<int>();
            //extention of LinQ, instead of List
            //test.Where 
                //any class who is implementing IEnuable can use where
                //list class is implementing IEnuable, so can use where
                //(this) class has implement ()!!!
        }
        public virtual IEnumerable<T> GetAll()
        {
            return _dbSet.AsNoTracking().ToList();
        }
        public virtual IEnumerable<T> GetMany(Expression<Func<T, bool>> where)
        {
            return _dbSet.Where(where).ToList();
        }
    }
}
