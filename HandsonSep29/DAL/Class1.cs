using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    [Key]
    [Required]
    public int borrowerid
    {
        get;
        set;
    }
    [MaxLength(20, ErrorMessage = "Not more than 20")]
    [MinLength(2, ErrorMessage = "Not more than 2")]
    public string borrowername
    {
        get;
        set;
    }
    public ICollection<borrower> GetBorrowers
    {
        get;
        set;
    }
}
public class loan
{
    [Key]
    [Required]
    public int loanid
    {
        get;
        set;
    }
    public int borrowerid
    {
        get;
        set;
    }
    public double amount
    {
        get;
        set;
    }
    public double interest
    {
        get;
        set;
    }
    public double getinterest(double amount)
    {
        return amount + (0.10 * amount);

    }
    public ICollection<loan> GetLoans
    {
        get;
        set;

    }
    [ForeignKey("borrowerid")]
    public virtual borrower borrowerdetails
    {
        get;
        set;
    }
}
public class MyContext : DbContext
{
    public MyContext() : base("MyContext")
    {
        Database.SetInitializer<MyContext>(new CreateDatabaseIfNotExists<MyContext>());
    }
    public virtual DbSet<borrower> Borrowers { get; set; }
    public virtual DbSet<loan> Loans { get; set; }
}

