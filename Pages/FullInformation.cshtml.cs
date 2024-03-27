using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplication1.Pages
{
    public class FullInformationModel : PageModel
    {
        public List<Sneakers> SneakersList = new List<Sneakers>() { new Sneakers { name = "Adidas Superstar", shortDesc = "Культовый дизайн", longDesc = "Классические кроссовки с знаменитым носом-ракушкой и тремя полосками по бокам, идеальные для повседневного стиля.", img = "/img/Adidas Superstar.jpg", price = 9000, isFavourite = true, available = true, brand = "Adidas" },
            new Sneakers { name = "Nike Cortez", shortDesc = "Ретро культура", longDesc = "Иконическая модель, популярная среди любителей уличной моды, вдохновленная культурой Лос-Анджелеса.", img = "/img/Nike Cortez.jpg", price = 9000, isFavourite = true, available = true, brand = "Nike" },
            new Sneakers { name = "Adidas Gazelle", shortDesc = "Винтажная эстетика", longDesc = "Спортивные кроссовки с замшевым верхом и знаменитыми тремя полосками на боковине, символ стиля 90-х.", img = "/img/Adidas Gazelle.jpg", price = 7500, isFavourite = true, available = true, brand = "Adidas" },
            new Sneakers { name = "Adidas NMD", shortDesc = "Инновационный стиль", longDesc = "Инновационные кроссовки, объединяющие современный дизайн и передовые технологии, для динамичного образа жизни.", img = "/img/Adidas NMD.jpg", price = 11000, isFavourite = true, available = true, brand = "Adidas" },
            new Sneakers { name = "Nike Air Force 1", shortDesc = "Иконическое удобство", longDesc = "Культовые кроссовки с воздушной амортизацией, классический дизайн для универсального использования.", img = "/img/Nike Air Force 1.jpg", price = 9000, isFavourite = true, available = true, brand = "Nike" },
            new Sneakers { name = "Nike Air Max", shortDesc = "Воздушная амортизация", longDesc = "Легендарные кроссовки с видимой единицей Air в подошве, обеспечивающие комфорт и стиль.", img = "/img/Nike Air Max.jpg", price = 14000, isFavourite = true, available = true, brand = "Nike" },
            new Sneakers { name = "Adidas Stan Smith", shortDesc = "Классический комфорт", longDesc = "Изначально созданные для тенниса, кроссовки с изображением легендарного теннисиста на заднике, ставшие иконой уличной моды.", img = "/img/Adidas Stan Smith.jpg", price = 9000, isFavourite = true, available = true, brand = "Adidas" },
            new Sneakers { name = "Nike Blazer", shortDesc = "Стильная элегантность", longDesc = "Стильные кроссовки с высоким верхом, отличающиеся элегантным дизайном и удобством на каждый день.", img = "/img/Nike Blazer.jpg", price = 9000, isFavourite = true, available = true, brand = "Nike" } };

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
