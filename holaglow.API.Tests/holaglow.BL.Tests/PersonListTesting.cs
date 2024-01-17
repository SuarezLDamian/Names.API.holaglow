using BLL;
using Names.API_Holaglow.Controllers;
using BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using BOL;

namespace holaglow.BL.Tests;

public class PersonListTesting
{
    private readonly PersonController _controller;
    private readonly IPersonList _personList;
    private readonly ILogger<PersonList> _logger = new NullLogger<PersonList>();

    public PersonListTesting()
    {
        _personList = new PersonListBL(_logger);
        _controller = new PersonController(_personList);
    }

    [Fact]
    public void GetFilteredList()
    {
        var result = _controller.Filter("M", "a");

        Assert.IsType<OkObjectResult>(result);
        Assert.NotNull(result);
    }
}
