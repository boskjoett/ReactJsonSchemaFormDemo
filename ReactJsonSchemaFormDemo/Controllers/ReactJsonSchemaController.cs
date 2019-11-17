using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ReactWebApplication.Models;

namespace ReactWebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReactJsonSchemaController : ControllerBase
    {
        private readonly ILogger<ReactJsonSchemaController> _logger;

        private const string jsonSchema =
          "{" +
            "\"title\": \"A registration form\"," +
            "\"description\": \"A simple form example.\"," +
            "\"type\": \"object\"," +
            "\"required\": [" +
              "\"firstName\"," +
              "\"lastName\"" +
            "]," +
            "\"properties\": {" +
              "\"firstName\": {" +
                "\"type\": \"string\"," +
                "\"title\": \"First name\"," +
                "\"default\": \"Chuck\"" +
              "}," +
              "\"lastName\": {" +
                "\"type\": \"string\"," +
                "\"title\": \"Last name\"" + 
              "}," +
              "\"age\": {" +
                "\"type\": \"integer\"," +
                "\"title\": \"Age\"" + 
              "}," +
              "\"bio\": {" +
                "\"type\": \"string\"," +
                "\"title\": \"Bio\"" +
              "}," +
              "\"password\": {" +
                "\"type\": \"string\"," +
                "\"title\": \"Password\"," +
                "\"minLength\": 3" +
              "}," +
              "\"telephone\": {" +
                "\"type\": \"string\"," +
                "\"title\": \"Telephone\"," +
                "\"minLength\": 10" +
              "}" +
            "}" +
          "}";

        private const string uiSchema = 
          "{" +
            "\"firstName\": {" +
              "\"ui:autofocus\": true," +
              "\"ui:emptyValue\": \"\"" +
            "}," +
            "\"age\": {" +
              "\"ui:widget\": \"updown\"," +
              "\"ui:title\": \"Age of person\"," +
              "\"ui:description\": \"(earthian year)\"" +
            "}," +
            "\"bio\": {" +
              "\"ui:widget\": \"textarea\"" +
            "}," +
            "\"password\": {" +
              "\"ui:widget\": \"password\"," +
              "\"ui:help\": \"Hint: Make it strong!\"" +
            "}," +
            "\"date\": {" +
              "\"ui:widget\": \"alt-datetime\"" +
            "}," +
            "\"telephone\": {" +
              "\"ui:options\": {" +
                "\"inputType\": \"tel\"" +
              "}" +
            "}" +
          "}";

        public ReactJsonSchemaController(ILogger<ReactJsonSchemaController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public ConfigurationBundle Get(string name)
        {
            _logger.LogInformation("Name = " + name);

            return  new ConfigurationBundle
            {
                Name = "Registration form",
                JsonSchema = jsonSchema,
                UiSchema = uiSchema
            };
        }
    }
}