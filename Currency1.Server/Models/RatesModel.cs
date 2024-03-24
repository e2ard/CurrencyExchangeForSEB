using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Currency1.Server.Models
{
    public class RatesModel : IValidatableObject
    {
        [Required]
        public decimal? Amount { get; set; }

        [Required]
        public string? From { get; set; }

        [Required]
        public string? To { get; set; }
        public string? Date { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();
            if (Amount <= 0)
            {
                results.Add(new ValidationResult(
                    $"Error on {nameof(Amount)}",
                    new[] { nameof(Amount) }));
            }

            if (string.IsNullOrEmpty(From))
            {
                results.Add(new ValidationResult(
                    $"Error on {nameof(From)}",
                    new[] { nameof(From) }));
            }

            if (string.IsNullOrEmpty(To))
            {
                results.Add(new ValidationResult(
                    $"Error on  {nameof(Amount)}",
                    new[] { nameof(To) }));
            }
            return results;
        }
    }
}
