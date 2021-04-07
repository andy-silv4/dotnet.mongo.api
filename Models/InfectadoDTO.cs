using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using FluentValidation;

namespace CoronaVirus.Api.Models
{
    public class InfectadoDTO
    {
        [JsonIgnore]
        public string Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Sexo { get; set; }
        public double Latitude { get; set; }

        [Required]
        public double Longitude { get; set; }
    }

    public class InfectadoValidator : AbstractValidator<InfectadoDTO> {
        public InfectadoValidator() {
            RuleFor(x => x.Nome).NotNull().Length(3, 30).NotEmpty();
            RuleFor(x => x.DataNascimento).NotNull().NotEmpty();
            RuleFor(x => x.Latitude).NotNull().NotEmpty();
            RuleFor(x => x.Longitude).NotNull().NotEmpty();
        }
    }
}