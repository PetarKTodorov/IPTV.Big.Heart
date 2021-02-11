namespace IPTV.Big.Heart.DTOs.BindingModels.User
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class RegisterBindingModel
    {
        [Required]
        [StringLength(255, MinimumLength = 2)]
        public string Username { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public Guid CountryId { get; set; }
    }
}
