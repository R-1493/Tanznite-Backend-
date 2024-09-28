using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using src.Entity;

namespace src.DTO
{
    public class AddressDTO
    {
        /// <summary>
        /// Data Transfer Object (DTO)
        ///This DTO is designed to encapsulate all necessary information.
        /// transfer data between different parts of an application,
        /// such as between services, and repositories.
        /// Mapper used the class down there.
        /// Contains user details such as Street, City, County, ZipCode.
        /// This DTO is designed to encapsulate all necessary information for Address creation.
        /// </summary>
        public class AddressCreateDto
        {
            public string Street { get; set; }
            public string City { get; set; }
            public string County { get; set; }
            public string ZipCode { get; set; }
            public Guid UserId { get; set; }
        }

        public class AddressReadDto
        {
            public Guid AddressId { get; set; }
            public int UserId { get; set; }
            public string Street { get; set; }
            public string City { get; set; }
            public string County { get; set; }
            public string ZipCode { get; set; }
        }

        public class AddressUpdateDto
        {
            public string Street { get; set; }
            public string City { get; set; }
            public string County { get; set; }
            public string ZipCode { get; set; }
        }
    }
}