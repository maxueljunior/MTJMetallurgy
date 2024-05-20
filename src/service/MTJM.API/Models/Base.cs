
using FluentValidation.Results;
using System.Text.Json.Serialization;

namespace MTJM.API.Models;

public abstract class Base
{

    [JsonIgnore]
    public ValidationResult ValidationResult { get; set; }

    protected virtual void ValidateModel()
    {

    }
}
