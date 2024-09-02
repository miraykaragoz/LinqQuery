using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using LinqQuery.Models;

namespace LinqQuery.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger; 

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        //LINQ -> Language Integrated Query

        var person = new List<PersonModel>
        {
            new PersonModel { FirstName = "Orhan", LastName = "Ekici", Age = 35, IsStudent = false },
            new PersonModel { FirstName = "Nihat", LastName = "Duysak", Age = 36, IsStudent = false },
            new PersonModel { FirstName = "Ayşe", LastName = "Güler", Age = 22, IsStudent = true },
            new PersonModel { FirstName = "Senih", LastName = "Ay", Age = 17, IsStudent = true },
        };
        
        //.Where(x => x.Age > 18) belirli bir koşulu sağlayan öğeleri filtrelemek için kullanılır.
        //.Select(x => x.FirstName) listenin içindeki her bir elemanı dizi haline getirir.
        //.DistinctBy(x => x.IsStudent) tek başına kullanıldığında mükerrer kayıtları siler. (bu sorguda iki grup oluşturur öğrenci olanlar ve olmayanlar olarak, öğrenci olmayanlardan ilkini getirip false değeri verirken, öğrenci olanların da ilkini getirip true değeri verir.)
        //.All(x => x.IsStudent) listenin içindeki tüm elemanları kontrol eder. bütün elemanlar öğrenci ise true döner.
        //.Any(x => x.IsStudent) listenin içindeki tüm elemanları kontrol ederç bir eleman öğrenci olsa bile true döner.
        //.First() listenin içindeki ilk elemanı getirir.
        //.Last() listenin içindeki son elemanı getirir.
        //.ElementAt(3) listenin içindeki denk gelen index numarasındaki elemanı getirir.
        //.DefaultIfEmpty(new Person {}) eğer listenin içi boşsa default tanımladığımız değeri getirir.
        //.GroupBy(x => x.IsStudent) öğrenci olanları ve olmayanları ayrı gruplara koyar. 1 listede 2 ayrı grup olur.
        //.Single(x => x.Name.ToLower().StartWith("sen")) single ilk bulduğunu getirir, id le iş yapacaksak id belirtmemiz lazım.
        // ?? opertatörü null olup olmadığını kontrol eder null ise sağdaki koşulu çalıştırır.
        //.MinBy(x => x.Age) en küçük yaştaki objeyi getirir. .Min ise en küçük yaşı getirir. aynısının max olanı da var.
        //.Select(x => new {FullName = $"{x.FirstName} {x.LastName}"}) yeni bir değişken oluşturarak adı ve soyadı bir değişkene atıyoruz.
        
        return Json(
            person
        );
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}