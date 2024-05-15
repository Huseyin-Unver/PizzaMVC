using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PizzaMVC.Entity
{
    public class DataInitializer : DropCreateDatabaseIfModelChanges<DataContext>
    {
        protected override void Seed(DataContext context)
        {
            var kategoriler = new List<Category>()
            {
                new Category(){ Name = "Büyük Boy Pizza", Description = "BÜYÜK BOY PİZZALAR"},
                new Category(){ Name = "Orta Boy Pizza", Description = "ORTA BOY PİZZALAR"},
                new Category(){ Name = "Küçük Boy Pizza", Description = "KÜÇÜK BOY PİZZALAR"},
                new Category(){ Name = "EXTRA Boy Pizza", Description = "EXTRA BOY PİZZALAR"},
                new Category(){ Name = "İNDİRİMLİ Pizza", Description = "EXTRA BOY PİZZALAR"}


            };

            foreach (var kategori in kategoriler)
            {
                context.Categories.Add(kategori);
            }
            context.SaveChanges();

            var urunler = new List<Product>()
            {
                new Product(){ Name = "Margarita pizza",Description = "Margarita pizza (İtalyanca: Pizza Margherita), domates, mozarella, fesleğen, zeytinyağı ve tuzla yapılan Napoli pizzasıdır.", Price =1200 , Stock =500 , IsApproved =true , CategoryId = 1,IsHome = true, Image= "1.jpg"},
                new Product(){ Name = "Matsa pizza",Description = "Matsa pizza, tabanının pizza hamurundan değil matsadan yapıldığı bir tür pizzadır. Hamursuz Bayramı'nda mayalı ekmek yasak olduğu için Yahudiler tarafından tercih edilir.", Price =1200 , Stock =500 , IsApproved =true , CategoryId = 1,IsHome = true, Image= "2.jpg"},
                new Product(){ Name = "Metrelik pizza",Description = "Metrelik pizza (İtalyanca: pizza al metro), Serrento Yarımadasına özgü bir pizza türüdür. Daha sonra ulusal ve uluslararası alanda yaygınlık kazanmıştır.", Price =1200 , Stock =500 , IsApproved =false , CategoryId = 1,IsHome = true, Image= "3.jpg"},
                new Product(){ Name = "Meksika pizzası",Description = "Meksika pizzası, malzemelerinin Meksika'ya özgü olmasıyla diğerlerinden ayrışan bir pizza çeşididir. Pizzanın kökeni Tijuana'dır ancak bazıları pizzanın kökeninin İtalya ve Japonya olduğunu iddia ediyor.[1] Meksika pizzasının malzemeleri genellikle domates, mısır, tavuk, peynir, kişniş ve karidestir.", Price =1200 , Stock =500 , IsApproved =true , CategoryId = 1,IsHome = true, Image = "4.jpg"},
                new Product(){ Name = "Deniz ürünlü pizza",Description = "Deniz ürünlü pizza, deniz ürünü içeren pizza çeşididir. Bu tür pizzalarda taze, derin dondurulmuş veya konserve halde deniz ürünleri kullanılır. Pizza zincirleri ve restoranların yanı sıra Dr. Oetker gibi dondurulmuş pizza üreten şirketler tarafından müşteriye sunulur.", Price =1200 , Stock =500 , IsApproved =false , CategoryId = 1, Image= "1.jpg"},

                new Product(){ Name = "Dört mevsim pizza", Price =1200 , Stock =500 , IsApproved =true , CategoryId = 2, Image= "1.jpg"},
                new Product(){ Name = "Dört peynirli pizza",Description = "Dört peynirli pizza (İtalyanca: pizza quattro fomaggi), İtalyan mutfağından bir pizza çeşididir. Dört peynir birlikte eritilir ve domates sosu olmadan pizza hamurunun üzerine konur. İtalya başta olmak üzere tüm dünyada yaygındır.", Price =4500 , Stock =1200 , IsApproved =true , CategoryId = 2,IsHome = true, Image= "2.jpg"},
                new Product(){ Name = "Çikolatalı pizza",Description = "Çikolatalı pizza, ana malzemesi çikolata olan bir pizza türüdür. Çoğunlukla ana yemek değil, tatlı olarak sınıflandırılır.", Price =3400 , Stock =0 , IsApproved =false , CategoryId = 2,IsHome = true, Image= "3.jpg"},
                new Product(){ Name = "Hawaii pizzası", Price =2500 , Stock =600 , IsApproved =true , CategoryId = 2, Image= "4.jpg"},
                new Product(){ Name = "Hawaii pizzası",Description = "Hawaii pizzası veya ananaslı pizza, alışılageldik pizza malzamelerine ek olarak ananas içeren pizzadır. Hawaii pizzası, halk arasında Pizzada ananas olur mu? tartışmasına neden olmuştur.", Price =5200 , Stock =500 , IsApproved =true , CategoryId = 2, Image= "1.jpg"},

                new Product(){ Name = "Pictou County pizza", Price =1200 , Stock =500 , IsApproved =true , CategoryId = 3, Image= "1.jpg"},
                new Product(){ Name = "Pictou County pizza",Description = "Pictou County Pizza, Yeni İskoçya'da yapılan pizza, Pictou County Pizza olarak bilinir. Pizzada, un ve tavuk suyu da dahil olmak üzere daha az tipik sos bileşenlerinden ve domates, soğan ve kekik gibi pizza sosunda ortak öğelerden oluşan kullanılır", Price =5600 , Stock =1200 , IsApproved =true , CategoryId = 3, Image= "2.jpg"},
                new Product(){ Name = "Pissaladière",Description = "Pissaladière Fransa'nın Nice bölgesinden bir pizza çeşitti. Hamuru margherita pizza hamurundan biraz daha kalın olur. Pizza'nın üstündeki malzemeler ise karamelize soğan, siyah zeytin, hamsi ve isteğe bağlı olarak pissalat (bir tür hamsi ezmesi)", Price =3400 , Stock =0 , IsApproved =false , CategoryId =3,IsHome = true, Image= "3.jpg"},
                new Product(){ Name = "Pizza capricciosa",Description = "Pizza capricciosa (İtalyanca: kaprisli veya değişken pizza), İtalyan mutfağından mozarella, İtalyan fırınlanmış jambon, mantar, enginar ve domatesle hazırlanan bir pizza türüdür.", Price =2500 , Stock =600 , IsApproved =true , CategoryId = 3,IsHome = true, Image= "4.jpg"},
                new Product(){ Name = "Pizza tost",Description = "Pizza tost, domates ve peynir gibi pizza malzemeleriyle yapılan bir tür açık tosttur", Price =5200 , Stock =500 , IsApproved =true , CategoryId = 3, Image= "1.jpg"},

                new Product(){ Name = "Hint pizzası", Price =1200 , Stock =500 , IsApproved =true , CategoryId = 4, Image= "2.jpg"},
                new Product(){ Name = "APictou County pizza",Description = "Pizza tost, domates ve peynir gibi pizza malzemeleriyle yapılan bir tür açık tosttur", Price =5600 , Stock =1200 , IsApproved =true , CategoryId = 4,IsHome = true, Image= "3.jpg"},
                new Product(){ Name = "Pizza capricciosa",Description = "Pizza tost, domates ve peynir gibi pizza malzemeleriyle yapılan bir tür açık tosttur", Price =3400 , Stock =0 , IsApproved =false , CategoryId =4,IsHome = true, Image= "4.jpg"},
                new Product(){ Name = "Pizza tost",Description = "Pizza tost, domates ve peynir gibi pizza malzemeleriyle yapılan bir tür açık tosttur", Price =2500 , Stock =600 , IsApproved =true , CategoryId = 4, Image= "3.jpg"},
                new Product(){ Name = "Pizza tost",Description = "Pizza tost, domates ve peynir gibi pizza malzemeleriyle yapılan bir tür açık tosttur", Price =5200 , Stock =500 , IsApproved =true , CategoryId = 4, Image= "2.jpg"},

            };

            foreach (var urun in urunler)
            {
                context.Products.Add(urun);
            }

            context.SaveChanges();

            base.Seed(context);
        }
    }
}