namespace MovieMVC.Repostiories.Abstract
{
	public interface IGenericService<T> where T : class, IEntity
	{
		void Add(T item);
		void Delete(T item);
		void Update(T item);
		T GetById(int id);
		List<T> GetAll();
	}
}
