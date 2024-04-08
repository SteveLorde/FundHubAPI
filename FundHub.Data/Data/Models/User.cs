﻿using System.ComponentModel.DataAnnotations;

namespace FundHub.Data.Data.Models;



public class User
{
    [Key]
    public Guid Id { get; set; }
    public string Username { get; set; }
    public string Hashedpassword { get; set; }
    public string Usertype { get; set; }
    public int Phonenumber { get; set; }
    public string Email { get; set; }
    public string Facebook { get; set; }
    public string X { get; set; }
    public string Instagram { get; set; }
    public string Profileimage { get; set; }
    public Project? Project { get; set; }
    public IList<Donation> Donations { get; set; }

}