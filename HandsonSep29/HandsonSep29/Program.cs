using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using System.Runtime.Remoting.Contexts;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;




namespace HandsonSep29
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MyContext context = new MyContext();
            Console.WriteLine("1.Borrower 2.Loan");
            int h = Convert.ToInt32(Console.ReadLine());
            switch (h)
            {
                case 1:
                    Console.WriteLine("1.Add 2.Update 3.Delete 4.Find 5.Showall 6.Count");
                    int j = Convert.ToInt32(Console.ReadLine());
                    switch (j)
                    {
                        case 1:
                            borrower b = new borrower();
                            Console.WriteLine("Enter borrower id");
                            b.borrowerid = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Enter Borrower Name");
                            b.borrowername = Console.ReadLine();
                            context.Borrowers.Add(b);
                            context.SaveChanges();
                            break;
                        case 2:
                            Console.WriteLine("Enter id to update");
                            int j1 = Convert.ToInt32(Console.ReadLine());
                            borrower b1 = new borrower();
                            Console.WriteLine("Enter borrower id");
                            b1.borrowerid = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Enter Borrower Name");
                            b1.borrowername = Console.ReadLine();
                            List<borrower> l = context.Borrowers.ToList();
                            borrower b2 = l.Find(borrower => borrower.borrowerid == j1);
                            b2.borrowerid = b1.borrowerid;
                            b2.borrowername = b1.borrowername;






                            context.SaveChanges();

                            break;
                        case 3:
                            Console.WriteLine("Enter id to delete");
                            int j11 = Convert.ToInt32(Console.ReadLine());
                            List<borrower> list1 = context.Borrowers.ToList();
                            borrower b3 = list1.Find(borrower => borrower.borrowerid == j11);
                            context.Borrowers.Remove(b3);
                            context.SaveChanges();
                            break;
                        case 4:
                            Console.WriteLine("Enter id to find");
                            int n1 = Convert.ToInt32(Console.ReadLine());
                            List<borrower> list2 = context.Borrowers.ToList();
                            borrower b4 = new borrower();
                            b4 = list2.Find(borrower => borrower.borrowerid == n1);
                            if (b4 != null)
                            {
                                Console.WriteLine(b4.borrowerid + " " + b4.borrowername);
                            }
                            else
                            {
                                Console.WriteLine("Not found");
                            }
                            break;
                        case 5:
                            Console.WriteLine("list of borrowers");
                            List<borrower> list4 = context.Borrowers.ToList();
                            foreach (var item in list4)
                            {
                                Console.WriteLine(item.borrowerid + " " + item.borrowername);
                            }
                            break;
                        case 6:
                            List<borrower> list8 = context.Borrowers.ToList();
                            Console.WriteLine("No. of count" + " " + list8.Count);
                            break;
                    }
                    break;
                case 2:
                    Console.WriteLine("1.Add 2.Update 3.Delete 4.Find 5.Showall 6.Count");
                    int p = Convert.ToInt32(Console.ReadLine());
                    switch (p)
                    {
                        case 1:
                            loan po = new loan();
                            Console.WriteLine("Enter loan id");
                            po.loanid = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Enter borrower id");
                            po.borrowerid = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Enter Amount");
                            po.amount = Convert.ToDouble(Console.ReadLine());
                            po.interest = po.getinterest(po.amount);
                            context.Loans.Add(po);
                            context.SaveChanges();
                            break;
                        case 2:
                            Console.WriteLine("Enter id to update");
                            int i = Convert.ToInt32(Console.ReadLine());
                            loan p1 = new loan();
                            Console.WriteLine("Enter loan id");
                            p1.loanid = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Enter borrower id");
                            p1.borrowerid = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Enter Amount");
                            p1.amount = Convert.ToDouble(Console.ReadLine());
                            p1.interest = p1.getinterest(p1.amount);
                            List<loan> pol = context.Loans.ToList();
                            loan bh = pol.Find(borrower => borrower.borrowerid == i);
                            bh.loanid = p1.loanid;
                            bh.borrowerid = p1.borrowerid;
                            bh.amount = p1.amount;
                            bh.interest = p1.interest;
                            context.SaveChanges();
                            break;
                        case 3:
                            Console.WriteLine("Enter id to update");
                            int id1 = Convert.ToInt32(Console.ReadLine());
                            List<loan> plt = context.Loans.ToList();
                            loan l1 = plt.Find(loan => loan.loanid == id1);
                            context.Loans.Remove(l1);
                            context.SaveChanges();
                            break;
                        case 4:
                            Console.WriteLine("Enter id to find");
                            int id2 = Convert.ToInt32(Console.ReadLine());
                            List<loan> pt = context.Loans.ToList();
                            loan l12 = pt.Find(loan => loan.loanid == id2);
                            if (l12 != null)
                            {
                                Console.WriteLine(l12.loanid + " " + l12.borrowerid + " " + l12.amount + " " + l12.interest);
                            }
                            break;
                        case 5:
                            List<loan> ptr = context.Loans.ToList();
                            foreach (var item in ptr)
                            {
                                Console.WriteLine(item.loanid + " " + item.borrowerid + " " + item.amount + " " + item.interest);
                            }

                            break;
                        case 6:
                            List<loan> ptr1 = context.Loans.ToList();
                            Console.WriteLine("No. of loan" + " " + ptr1.Count);

                            break;
                    }
                    break;
            }
            Console.ReadLine();

        }
    }
}
    }
}
