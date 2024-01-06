﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PsSQL.Models.Entities
{
    [Table("UserLogin")]
    public class UserLogin
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string? UserName { get; set; }

        public string? UserPassword { get; set; }

        public int UserStatus { get; set; }

        public int CenterId { get; set; }

        public DateTime LastLogin { get; set; }

        public DateTime SessionCreateDateTime { get; set; }

        public string? SessionId { get; set; }


    }
}
