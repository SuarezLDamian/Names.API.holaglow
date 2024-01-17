using BOL;
using DAL;
using BusinessLogic.Interfaces;
using Microsoft.Extensions.Logging;

namespace BLL
{
	public class PersonListBL : IPersonList
    {
        private readonly ILogger<PersonList> _logger;
        private readonly ILoggerFactory _loggerFactory;

        public PersonListBL(ILogger<PersonList> logger, ILoggerFactory loggerFactory)
        {
            _logger = logger;
            _loggerFactory = loggerFactory;
        }

        public List<BOL.Person> GetList(string? gender, string? name)
		{
            try
            {
                ILogger<db> dbLogger = _loggerFactory.CreateLogger<db>();
                var _db = new db(dbLogger);
                var result = _db.Read();

                if (!string.IsNullOrEmpty(gender))
                {
                    result = result.Where(Person => Person.Gender.Equals(gender, StringComparison.OrdinalIgnoreCase));
                }

                if (!string.IsNullOrEmpty(name))
                {
                    result = result.Where(Person => Person.Name.StartsWith(name, StringComparison.OrdinalIgnoreCase));
                }

                _logger.LogInformation("Datos obtenidos con éxito");
                return result.ToList();
            }
            catch (Exception Ex)
            {
                _logger.LogError(Ex, "Error al fitrar. Se recbió un listado vacío.");
                return null;
            }
            
        }
	}
}

