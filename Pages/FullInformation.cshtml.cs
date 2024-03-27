using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplication1.Pages
{
    public class FullInformationModel : PageModel
    {
        public List<Sneakers> SneakersList = new List<Sneakers>() { new Sneakers { name = "Adidas Superstar", shortDesc = "��������� ������", longDesc = "������������ ��������� � ���������� �����-�������� � ����� ��������� �� �����, ��������� ��� ������������� �����.", img = "/img/Adidas Superstar.jpg", price = 9000, isFavourite = true, available = true, brand = "Adidas" },
            new Sneakers { name = "Nike Cortez", shortDesc = "����� ��������", longDesc = "����������� ������, ���������� ����� ��������� ������� ����, ������������� ��������� ���-���������.", img = "/img/Nike Cortez.jpg", price = 9000, isFavourite = true, available = true, brand = "Nike" },
            new Sneakers { name = "Adidas Gazelle", shortDesc = "��������� ��������", longDesc = "���������� ��������� � �������� ������ � ����������� ����� ��������� �� ��������, ������ ����� 90-�.", img = "/img/Adidas Gazelle.jpg", price = 7500, isFavourite = true, available = true, brand = "Adidas" },
            new Sneakers { name = "Adidas NMD", shortDesc = "������������� �����", longDesc = "������������� ���������, ������������ ����������� ������ � ��������� ����������, ��� ����������� ������ �����.", img = "/img/Adidas NMD.jpg", price = 11000, isFavourite = true, available = true, brand = "Adidas" },
            new Sneakers { name = "Nike Air Force 1", shortDesc = "����������� ��������", longDesc = "��������� ��������� � ��������� ������������, ������������ ������ ��� �������������� �������������.", img = "/img/Nike Air Force 1.jpg", price = 9000, isFavourite = true, available = true, brand = "Nike" },
            new Sneakers { name = "Nike Air Max", shortDesc = "��������� �����������", longDesc = "����������� ��������� � ������� �������� Air � �������, �������������� ������� � �����.", img = "/img/Nike Air Max.jpg", price = 14000, isFavourite = true, available = true, brand = "Nike" },
            new Sneakers { name = "Adidas Stan Smith", shortDesc = "������������ �������", longDesc = "���������� ��������� ��� �������, ��������� � ������������ ������������ ���������� �� �������, ������� ������ ������� ����.", img = "/img/Adidas Stan Smith.jpg", price = 9000, isFavourite = true, available = true, brand = "Adidas" },
            new Sneakers { name = "Nike Blazer", shortDesc = "�������� ������������", longDesc = "�������� ��������� � ������� ������, ������������ ���������� �������� � ��������� �� ������ ����.", img = "/img/Nike Blazer.jpg", price = 9000, isFavourite = true, available = true, brand = "Nike" } };

        public Sneakers FullSneakers = new Sneakers();

        public Sneakers FullSneakesr = new Sneakers();

        DataContextDapper _dapper;

        public FullInformationModel(IConfiguration config)
        {
            _dapper = new DataContextDapper(config);
        }
        public void OnGet()
        {
            string? SnkName = Request.Query["SneakersName"];

            string sql = $"Select * from ourhome.customers where 'Name' = {SnkName}";

            //FullSneakesr = _dapper.LoadDataSingle<Sneakers>(sql);

            foreach (var item in SneakersList)
            {
                if (item.name == SnkName) FullSneakers = item; 
            }
        }
    }
}
