using Newtonsoft.Json;
using Xunit;

namespace holaglow.API.Tests;

public class UnitTest1
{
    [Fact]
    public void Test1()
    {
        [Fact]
        public void Read_ShouldReturnListOfPersons_WhenJsonFileExists()
        {
            // Arrange
            var fileContent = "{\"response\": [{\"Id\": 1, \"Name\": \"John\"}, {\"Id\": 2, \"Name\": \"Jane\"}]}";
            var filePath = "/path/to/valid/file.json";

            // Mock System.IO.File para simular la lectura del archivo
            var fileSystemMock = new Mock<IFileSystem>();
            fileSystemMock.Setup(fs => fs.ReadAllText(filePath)).Returns(fileContent);

            // Mock JsonConvert para simular la deserialización
            var jsonConvertMock = new Mock<IJsonConvert>();
            jsonConvertMock.Setup(jc => jc.DeserializeObject<BOL.PersonList>(fileContent)).Returns(new BOL.PersonList { response = new List<BOL.Person>() });

            // Inyecta los mocks en la clase bajo prueba
            var personReader = new PersonReader(fileSystemMock.Object, jsonConvertMock.Object);

            // Act
            var result = personReader.Read();

            // Assert
            Assert.NotNull(result);
            Assert.IsType<List<BOL.Person>>(result);
            Assert.Equal(2, result.Count());
        }
    }
}
