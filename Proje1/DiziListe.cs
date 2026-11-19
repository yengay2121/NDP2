using System;
using System.Collections;

namespace Proje1
{
    public class DiziListe : IEnumerable
    {
        private object[] elemanlar;
        private int _elemanSayısı;
        // Count
        public int ElemanSayisi => _elemanSayısı;

        public DiziListe() : this(4)
        {
        }

        public DiziListe(int baslangicKapasite)
        {
            // negatif kontrolü
            if (baslangicKapasite < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(baslangicKapasite), "Kapasite negatif olamaz.");
            }

            // Bellekte yer ayırıp sayacı 0'lama
            elemanlar = new object[baslangicKapasite];
            _elemanSayısı = 0;
        }

        private void kapasiteKontrol(int gerekli)
        {
            if (elemanlar.Length >= gerekli)
            return;

            int yeniKapasite = elemanlar.Length == 0 ? 4 : elemanlar.Length * 2;

            if (yeniKapasite < gerekli)
            {
                yeniKapasite = gerekli;
            }

            object[] yeniDizi = new object[yeniKapasite];
            // eski elemanları yeni diziye kopyalama

            for (int i = 0; i < _elemanSayısı; i++)
            {
                yeniDizi[i] = elemanlar[i];
            }

            elemanlar = yeniDizi;

        }

        // sona ekleme
        public int SonaEkle(object eleman)
        {
            // kapasite kontrolü
            kapasiteKontrol(_elemanSayısı + 1);
            // sona eleman ekleme
            elemanlar[_elemanSayısı] = eleman;
            // sayaç arttırma
            _elemanSayısı++;
            // değerleri döndürme
            return _elemanSayısı -1;
        }

        // Araya ekleme
        public void ArayaEkle(int indeks, object eleman)
        {
            // sınır kontrolü
            if (indeks < 0 || indeks > _elemanSayısı)
            {
                throw new ArgumentOutOfRangeException(nameof(indeks), "İndeks geçersiz.");
            }
            // kapasite kontrolü -tekrar-

            kapasiteKontrol(_elemanSayısı + 1);
            kapasiteKontrol(_elemanSayısı);

            // elemanları sağdan başlayığ sağa kaydırma

            for (int i = _elemanSayısı; i > indeks; i--)
            {
                elemanlar[i] = elemanlar[i - 1];
            }

            // boşalan yere eleman koyma
            elemanlar[indeks] = eleman;
            // sayaç arttırma
            _elemanSayısı++;

        }
        
        // Değere göre eleman silme

        public void Sil(object eleman)
        {
            // baştan sona elamanları tarama

            for (int i = 0; i < _elemanSayısı; i++)
            {
                // eşleşen varsa sil
                if (Equals(elemanlar[i], eleman))
                {
                    Sil(i);
                    return;
                }
            }
        }

        // İndekse göre eleman silme

        public void Sil(int indeks)
        {
            // sınır kontrolü
            if (indeks < 0 || indeks >= _elemanSayısı)
            {
                throw new ArgumentOutOfRangeException(nameof(indeks), "Geçersiz indeks..");
            }

            // elemanları soldan sağa kaydırma
            for (int i = indeks; i < _elemanSayısı - 1; i++)
            {
                elemanlar[i] = elemanlar[i+1];
            }
            // sayacı azaltma ve bellekten temizleme
            elemanlar[_elemanSayısı - 1] = null;
            _elemanSayısı--;
        }


        public int Bul(object eleman)
        {
            // elemanları tarama
            for(int i = 0; i < _elemanSayısı; i++)
            {
                if (Equals(elemanlar[i], eleman))
                {
                    return i;
                }
            }
            return -1;
        }

        public bool VarMi(object eleman)
        {
            for (int i = 0; i < _elemanSayısı; i++)
            {
                if (Equals(elemanlar[i], eleman))
                {
                    return true;
                }
            }
            return false;
        }

        public void Temizle()
        {
            for (int i = 0; i < _elemanSayısı; i++)
            {
                elemanlar[i] = null; 
            }
            // sayacı sıfırlama
            _elemanSayısı = 0;
        }

        public void Sirala()
        {
            //bubble sort algoritması
            for (int i = 0; i < _elemanSayısı -1; i++)
            {
                for (int j = 0; j < _elemanSayısı -1 - i; j++)
                {
                    int fark = Comparer.Default.Compare(elemanlar[j], elemanlar[j + 1]);

                    if (fark > 0)
                    {
                        object gecici = elemanlar[j];
                        elemanlar[j] = elemanlar[j + 1];
                        elemanlar[j + 1] = gecici;
                    }
                }
            }
        }



        // listeyi ters çevirme 
        public void TersCevir()
        {
            int sol = 0;
            int sag = _elemanSayısı - 1;

            while (sol < sag)
            {
                object gecici = elemanlar[sol];
                elemanlar[sol] = elemanlar[sag];
                elemanlar[sag] = gecici;

                sol++;
                sag--;
            }
        }

        // Endeksleyici liste[i] erişimi

        public object this[int indeks]
        {
            get
            {
                // sınır kontrolü
                if (indeks < 0 || indeks >= _elemanSayısı)
                {
                    throw new IndexOutOfRangeException("İndeks sınır dışında");

                }
                return elemanlar[indeks];
            }
            set
            {
                // sınır kontrolü
                if (indeks < 0 || indeks >= _elemanSayısı)
                {
                    throw new IndexOutOfRangeException("İndeks sınır dışında");

                }
                // indekse değer atama
                elemanlar[indeks] = value;

            }
        }


        // Nümeratör
        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < _elemanSayısı; i++)
            {
                yield return elemanlar[i];
            }
        }


    }
}