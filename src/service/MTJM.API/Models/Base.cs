
using FluentValidation.Results;
using System.Text.Json.Serialization;

namespace MTJM.API.Models;

public abstract class Base
{
    #region Properties
    public int Id { get; private set; }

    [JsonIgnore]
    public ValidationResult ValidationResult { get; set; }
    #endregion

    #region Methods
    public void SetId(int id) => Id = id;

    public bool IsValid() => ValidationResult.IsValid;

    protected virtual void ValidateModel()
    {

    }
    #endregion
}
