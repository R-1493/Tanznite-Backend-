using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using src.Entity;
using static src.DTO.AddressDTO;

namespace src.DTO
{
    public class UserDTO
    {
        public class UserCreateDto
        {
            [Required]
            public string Name { get; set; }

            [Required]
            [RegularExpression(@"^\+[1-9]\d{1,14}$", ErrorMessage = "Invalid phone number format")]
            public string PhoneNumber { get; set; }

            [Required]
            [EmailAddress]
            public string Email { get; set; }

            [Required]
            [MinLength(8)]
            [RegularExpression(
                @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,}$",
                ErrorMessage = "Password must be at least 8 characters long and contain at least one uppercase letter, one lowercase letter, and one digit."
            )]
            public string Password { get; set; }
        }

        public class UserReadDto
        {
            public Guid UserId { get; set; }
            public string Name { get; set; }
            public string PhoneNumber { get; set; }
            public string Email { get; set; }
            public string Password { get; set; }
            public Role Role { get; set; }
            public byte[]? Salt { get; set; }
        }

        public class AdminUpdateDto
        {
            public Guid UserId { get; set; }
            public string Name { get; set; }
            public string PhoneNumber { get; set; }
            public string Email { get; set; }
            public string Password { get; set; }
            public Role Role { get; set; }
        }

        public class UserLoginDto
        {
            [Required]
            [EmailAddress]
            public string Email { get; set; }

            [Required]
            [MinLength(8)]
            [RegularExpression(
                @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,}$",
                ErrorMessage = "Password must be at least 8 characters long and contain at least one uppercase letter, one lowercase letter, and one digit."
            )]
            public string Password { get; set; }
        }

        public class UserProfileDto
        {
            public string? Name { get; set; }

            [RegularExpression(@"^\+[1-9]\d{1,14}$", ErrorMessage = "Invalid phone number format")]
            public string? PhoneNumber { get; set; }

            [EmailAddress]
            public string? Email { get; set; }

            [MinLength(8)]
            [RegularExpression(
                @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,}$",
                ErrorMessage = "Password must be at least 8 characters long and contain at least one uppercase letter, one lowercase letter, and one digit."
            )]
            public string? Password { get; set; }

            public ICollection<AddressReadDto>? Addresses { get; set; } =
                new List<AddressReadDto>();
            public Role? Role { get; set; }
        }

        public class PasswordUpdateDto
        {
            [Required]
            [MinLength(8)]
            [RegularExpression(
                @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,}$",
                ErrorMessage = "Password must be at least 8 characters long and contain at least one uppercase letter, one lowercase letter, and one digit."
            )]
            public string Password { get; set; }
        }
    }
}
