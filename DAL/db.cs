using Newtonsoft.Json;
using Microsoft.Extensions.Logging;

namespace DAL
{
	public class db
	{
        private readonly ILogger<db> _logger;

        public db(ILogger<db> logger)
        {
            _logger = logger;
        }

        public IEnumerable<BOL.Person> Read()
		{
            try
            {
                // Ruta del archivo JSON
                string filePath = Path.Combine("../names.json");

                //Lee el contenido del archivo JSON
                string jsonContent = System.IO.File.ReadAllText(filePath);

                //Convierte el contenido JSON en un objeto
                BOL.PersonList resultado = JsonConvert.DeserializeObject<BOL.PersonList>(jsonContent)!;

                //Accede a la lista de personas en el objeto resultado
                List<BOL.Person> personList = resultado.response;

                return personList;
            }
            catch (FileNotFoundException Ex)
            {
                _logger.LogError(Ex, "Error en la ruta del archivo.");
                return null;
            }
            catch (Exception Ex)
            {
                _logger.LogError(Ex, "Error al consultar la base de datos.");
                return null;
            }
        }
	}
}

