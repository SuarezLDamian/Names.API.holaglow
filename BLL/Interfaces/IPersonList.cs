using System;
namespace BusinessLogic.Interfaces
{
	public interface IPersonList
	{
		public List<BOL.Person> GetList(string? gender, string? name);
	}
}

