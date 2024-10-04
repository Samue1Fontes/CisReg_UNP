using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace CisReg_Website.Models
{

    public class PersonalInfoModel
    {
        public string CompleteName { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string CPF { get; set; } = string.Empty;

        [DataType(DataType.Date)]
        public DateTime BornDate { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;

    }
}