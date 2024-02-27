using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary1;
using ClassLibrary2;
using ClassLibrary3;
using System.Text.RegularExpressions;

namespace ConsoleApp15
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("hej og velkommen til denne opgave (fodboldopgave) tryk enter for at fortsætte"); //udskriver det du har fået den til //
            Console.ReadKey();


            Console.WriteLine("tryk enter igen for at se udfalget at ''kampen'' . du kan selv vælge at skifte tallet i programmet");
            Console.ReadKey();

            Fodbold fodbold1 = new Fodbold(); //lavet en ny klasse//
            fodbold1.pass = 0; //brugt en int variabel. (i denne opgave skal du selv ændre værdien for at få den udskrevet//
            fodbold1.mål = "olë"; // udskriver olé hvis mål//
            {
                if (fodbold1.pass < 0) //lavet en if sætning det vil sige hvis 0 afleveringer gør den det her ellers det næste etc etc.. //
                    Console.WriteLine("det er ikke muligt");

                else if (fodbold1.pass < 1)
                    Console.WriteLine("shh");

                else if (fodbold1.pass >= 10)
                    Console.WriteLine("high five");

                else if (fodbold1.mål == "olë")

                    for (int i = 0; i < 10; i++)
                        Console.WriteLine("huh");

                Console.ReadKey();  //læser brugerens tast på keyboard//
                Console.Clear();  //rengør consolen// 
            }

            Console.WriteLine("til opgave 2 ''dansekonkurrence'' tryk enter for at fortsætte ");
            Console.ReadKey();

            {
                DKamp dansekamp = new DKamp();  //lavet en ny klasse// 

                Random rnd = new Random();  //i denne opgave bliver der udgivet en tilfældig værdi //

                dansekamp.navn1 = "random navn";
                dansekamp.navn2 = "random navn";

                dansekamp.point1 = rnd.Next(1, 15);  //her giver vi den værdien mellem 1 og eller 15 //
                dansekamp.point2 = rnd.Next(1, 15);  //her giver vi den værdien mellem 1 og eller 15 //
                dansekamp.sum = dansekamp.point1 + dansekamp.point2; // Opdater summen

                Console.WriteLine($"randomnavn 1: {dansekamp.point1}, randomnavn 2: {dansekamp.point2}, dansekamp.sum: {dansekamp.sum}");

                // Tjek betingelserne baseret på summen af dansekamp.point1 og dansekamp.point2

                if (dansekamp.sum < 0)
                    Console.WriteLine("i er for dårlige");
                else if (dansekamp.sum >= 20)
                    Console.WriteLine("i fik mellem 20 points eller højere");
                else if (dansekamp.sum >= 15)
                    Console.WriteLine("i fik mellem 15 og 20 points");
                else if (dansekamp.sum >= 10)
                    Console.WriteLine("i fik mellem 10 og 14 point");
                else if (dansekamp.sum >= 5)
                    Console.WriteLine("i fik mellem 5 og 9 point point");

                Console.ReadLine();
                Console.Clear();

                // Angiv stien til filen, hvor brugeroplysninger gemmes
                string filVej = @"C:\Users\Matal\Desktop\login.txt";

                // Skriv brugernavn og adgangskode til filen
                File.WriteAllText(filVej, "brugernavn: admin. adgangskode :hej1234567890hej!");

                // Læs brugeroplysninger fra filen
                string info = File.ReadAllText(filVej);

                // Udskriv brugeroplysningerne
                Console.WriteLine(info);

                {
                    Console.WriteLine("Velkommen! Opret en bruger:");
                    CreateUser();

                    Console.WriteLine("\nLog ind med din bruger:");
                    Login();
                }

                 void CreateUser()
                {
                    Console.Write("Indtast brugernavn: ");
                    string username = Console.ReadLine();

                    // Tjek om brugernavnet allerede eksisterer
                    if (File.Exists(username + @"C:\Users\Matal\Desktop\login.txt"))
                    {
                        Console.WriteLine("Brugernavnet eksisterer allerede. Vælg et andet brugernavn.");
                        CreateUser(); // Kald CreateUser rekursivt for at få et nyt brugernavn
                        return;
                    }

                    string password;
                    do
                    {
                        Console.Write("Indtast password: ");
                        password = Console.ReadLine();
                    } while (!IsValidPassword(password, username));

                    // Gem brugernavn og password i en tekstfil
                    File.WriteAllText(username + ".txt", $"{username}:{password}");

                    Console.WriteLine("Bruger oprettet!");
                }

                 void Login()
                {
                    Console.Write("Brugernavn: ");
                    string username = Console.ReadLine();

                    Console.Write("Password: ");
                    string password = Console.ReadLine();

                    // Tjek om brugeren findes
                    if (!File.Exists(username + @"C:\Users\Matal\Desktop\login.txt"))
                    {
                        Console.WriteLine("Brugernavn eller password er forkert.");
                        return;
                    }

                    // Indlæs brugerens gemte password
                    string[] userInfo = File.ReadAllText(username + @"C:\Users\Matal\Desktop\login.txt").Split(':');
                    string savedPassword = userInfo[1];

                    // Tjek om det indtastede password matcher det gemte password
                    if (password == savedPassword)
                    {
                        Console.WriteLine("Login succesfuld!");
                    }
                    else
                    {
                        Console.WriteLine("Brugernavn eller password er forkert.");
                    }
                }

                 bool IsValidPassword(string password, string username)
                {
                    // Tjek om passwordet opfylder alle krav
                    if (password.Length < 12)
                    {
                        Console.WriteLine("Passwordet skal være mindst 12 tegn langt.");
                        return false;
                    }

                    if (!Regex.IsMatch(password, "[A-Z]"))
                    {
                        Console.WriteLine("Passwordet skal indeholde mindst ét stort bogstav.");
                        return false;
                    }

                    if (!Regex.IsMatch(password, "[a-z]"))
                    {
                        Console.WriteLine("Passwordet skal indeholde mindst ét lille bogstav.");
                        return false;
                    }

                    if (!Regex.IsMatch(password, "[0-9]"))
                    {
                        Console.WriteLine("Passwordet skal indeholde mindst ét tal.");
                        return false;
                    }

                    if (!Regex.IsMatch(password, @"[!""#$%&'()*+,-./:;<=>?@[\\\]^_`{|}~]"))
                    {
                        Console.WriteLine("Passwordet skal indeholde mindst ét specialtegn.");
                        return false;
                    }

                    if (char.IsDigit(password[0]) || char.IsDigit(password[1]))
                    {
                        Console.WriteLine("Tal må ikke være i starten eller slutningen af passwordet.");
                        return false;
                    }

                    if (password.Contains(" "))
                    {
                        Console.WriteLine("Passwordet må ikke indeholde mellemrum.");
                        return false;
                    }

                    if (username.ToLower() == password.ToLower())
                    {
                        Console.WriteLine("Brugernavn og password må ikke være ens.");
                        return false;
                    }

                    return true;
                }
            }
        }
        }

    }

