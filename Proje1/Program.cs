using System;

namespace Proje1
{
    class Program
    {
        static void Main()
        {
            DiziListe liste = new DiziListe();

            // Ekleme testleri
            liste.SonaEkle("Yazılım");
            liste.SonaEkle("Algoritma");
            liste.ArayaEkle(1, "Veri Yapıları");
            liste.SonaEkle("C#");

            // Özellik, endeksleyici ve arama
            Console.WriteLine($"Sayı: {liste.ElemanSayisi}");
            Console.WriteLine($"1. İndeks: {liste[1]}");
            Console.WriteLine($"C# var mı: {liste.VarMi("C#")}");
            Console.WriteLine($"Java indeksi: {liste.Bul("Java")}");

            // Sıralama
            liste.Sirala();
            Console.WriteLine("\n--- Sıralı ---");
            foreach (var item in liste)
                Console.WriteLine(item);

            // Ters çevirme
            liste.TersCevir();
            Console.WriteLine("\n--- Ters ---");
            foreach (var item in liste)
                Console.WriteLine(item);

            // Silme ve temizleme
            liste.Sil("Algoritma");
            liste.Sil(0);
            Console.WriteLine($"\nSilme sonrası: {liste.ElemanSayisi}");

            liste.Temizle();
            Console.WriteLine($"Temizle sonrası: {liste.ElemanSayisi}");
        }
    }
}
