﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvSef.Domain.Entities.CustomFood
{
    public class CustomFood
    {
        //For Custom Food & Diet Food
        [Key]
        public int CustomFoodId  { get; set; }

        [Display(Name = "Custom Food Title")]
        [Required(ErrorMessage = "{0} is required")]
        public string CustomFoodTitle { get; set; }

        [Display(Name = "Custom Food Description")]
        [Required(ErrorMessage = "{0} is required")]
        [DataType(DataType.MultilineText)]
        public string CustomFoodDescription { get; set; }


        [Display(Name = "Custom Food Image")]
        public string CustomFoodImage { get; set; }

        [Display(Name = "Register Date")]
        [Required(ErrorMessage = "{0} is required")]
        public DateTime RegisterDate { get; set; }

        [Display(Name = "Active")]
        public bool IsActive { get; set; }

        [Display(Name = "IsDelete")]
        public bool IsDelete { get; set; }

        public int CreatedUser { get; set; }
    }
}