﻿using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace CisReg_Website.Models
{

    public class ProfessionalInfoModel
    {
        public int registrationNumber { get; set; }
        public string specialty { get; set; } = string.Empty;
        public string academicTraining { get; set; } = string.Empty;

    }
}